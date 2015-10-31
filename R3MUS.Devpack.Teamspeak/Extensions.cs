using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TentacleSoftware.TeamSpeakQuery.ServerQueryResult;

namespace R3MUS.Devpack.Teamspeak
{
    public static partial class ClientInfoResultExtensions
    {
        public static string ClientTicker(this ClientInfoResult cir)
        {
            return string.Concat(cir.ClientNickname.Split(new string[] { "] " }, StringSplitOptions.RemoveEmptyEntries)[0], "]");
        }
        public static string ClientName(this ClientInfoResult cir)
        {
            return cir.ClientNickname.Split(new string[] { "] " }, StringSplitOptions.RemoveEmptyEntries)[1];
        }
    }
}
