using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace steamBPTest
{
    class SteamMusicClient
    {
        private SteamClient steamClient;

        public SteamMusicClient(SteamClient steamClient)
        {
            // TODO: Complete member initialization
            this.steamClient = steamClient;
        }

        public void Play()
        {
            this.Action("play");
        }

        private void Action(string actionName, NameValueCollection nvc=null)
        {
            steamClient.Post("music/" + actionName + "/", nvc, true);
        }

        public void SetVolume(double volume)
        {
            var nvc=new NameValueCollection();
            nvc.Add("volume",volume.ToString());
            Action("volume", nvc);
        }
    }
}
