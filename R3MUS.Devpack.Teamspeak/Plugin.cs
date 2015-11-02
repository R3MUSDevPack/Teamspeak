using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TentacleSoftware.TeamSpeakQuery;
using TentacleSoftware.TeamSpeakQuery.ServerQueryResult;

namespace R3MUS.Devpack.Teamspeak
{
    public class Plugin
    {
        private ServerQueryClient client;
        public ClientInfoResult Selected { get; set; }
        private int DBID;
        private int SGID;

        public List<ClientInfoResult> ClientList { get; set; }
        public AddSuccess SuccessType { get; set; }
        public string Message { get; set; }

        public string Url { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public enum AddSuccess
        {
            Success,
            Fail
        }

        public bool Start()
        {
            client = new ServerQueryClient(Url, 10011, TimeSpan.FromSeconds(3));
            try
            {
                ServerQueryBaseResult connected = client.Initialize().Result;
                if (connected.Success)
                {
                    ServerQueryBaseResult login = client.Login(Login, Password).Result;
                    if (login.Success)
                    {
                        ServerQueryBaseResult use = client.Use(UseServerBy.Port, 9987).Result;

                        if (use.Success)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async Task<bool> AddClient(string name, string groupName)
        {
            if (Start())
            {
                try
                {
                    //await client.KeepAlive(TimeSpan.FromMinutes(2));
                    ClientList = client.ClientList().Result.Values;

                    ClientInfoResult ClientInfo = ClientList.Where(m => m.ClientNickname == name).FirstOrDefault();

                    if (ClientInfo != null)
                    {
                        await GetDBID(ClientInfo.ClientUniqueIdentifier);
                        await GetServerGroup(groupName);
                        await AddClient();
                        Message = string.Format("User {0} successfully created on TS Server {1}.", name, Url);
                    }
                    else
                    {
                        SuccessType = AddSuccess.Fail;
                        Message = string.Format("Could not find a valid user on {0}. Please make sure your nickname is {1} and try again.", Url, name);
                    }
                }
                catch (Exception ex)
                {
                    SuccessType = AddSuccess.Fail;
                }
                finally
                {
                    Stop();
                }
            }
            return true;
        }

        public void Stop()
        {
            ServerQueryBaseResult unregister = client.ServerNotifyUnregister().Result;
            ServerQueryBaseResult logout = client.Logout().Result;
            ServerQueryBaseResult quit = client.Quit().Result;
        }

        public async Task GetAllClients()
        {
            if (Start())
            {
                try
                {
                    ClientList = client.ClientList().Result.Values.ToList().Where(client => client.ClientPlatform != "ServerQuery").ToList();
                }
                catch (Exception ex)
                {
                    ClientList = new List<ClientInfoResult>();
                }
                finally
                {
                    Stop();
                }
            }
        }

        private async Task GetDBID(string ID)
        {
            Task<TextResult> result = client.SendCommandAsync(string.Concat("clientgetdbidfromuid cluid=", ID));
            TextResult resultText = await result;
            DBID = Convert.ToInt32(resultText.Response.Substring((resultText.Response.IndexOf("cldbid=") + 7), (resultText.Response.Length - (resultText.Response.IndexOf("cldbid=") + 7))));
        }

        private async Task GetServerGroup(string groupName)
        {
            Task<TextResult> result = client.SendCommandAsync("servergrouplist");
            TextResult resultText = await result;
            string group = resultText.Response.Split(new char[] { '|' }).ToList<string>().Where(sg => sg.Contains(string.Format("name={0} ", groupName))).FirstOrDefault();
            if (group != string.Empty)
            {
                SGID = Convert.ToInt32(group.Split(new char[] { ' ' })[0].Substring(5));
            }
        }

        private async Task AddClient()
        {
            Task<TextResult> result = client.SendCommandAsync(string.Format("servergroupaddclient sgid={0} cldbid={1}", SGID.ToString(), DBID.ToString()));
            TextResult resultText = await result;
            if (resultText.Response.Contains("errorid=0"))
            {
                SuccessType = AddSuccess.Success;
                Message = "Teamspeak Registration Successful!";
            }
            else
            {
                SuccessType = AddSuccess.Fail;
                Message = string.Concat("Teamspeak Registration Unsuccessful: ", resultText.Response);
            }
        }

        public async void Send(string clid, string msg)
        {
            if ((msg.Length > 0) && (Start()))
            {
                try
                {
                    clid.ToList().ForEach(async id => await client.ClientPoke(msg, Convert.ToInt32(clid)));
                }
                catch (TaskCanceledException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Stop();
                }
            }
        }

        public async void Kick(string[] clid, string msg)
        {
            if (Start())
            {
                ServerQueryBaseResult result;
                try
                {
                    result = await client.ClientKick(
                        ReasonIdentifier.REASON_KICK_SERVER, "You should have fixed your nickname",
                        Array.ConvertAll(clid, s => int.Parse(s))
                        );
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Stop();
                }
            }
        }
    }
}