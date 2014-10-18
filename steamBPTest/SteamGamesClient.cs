using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace steamBPTest
{
    class SteamGamesClient
    {
        private SteamClient steamClient;

        public SteamGamesClient(SteamClient steamClient)
        {
            // TODO: Complete member initialization
            this.steamClient = steamClient;
        }

        internal void Run(int p)
        {
            steamClient.Post("games/" + p + "/run", null, true);
        }
    }
}
