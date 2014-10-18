using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace steamBPTest
{
    class SteamClient
    {
        private string Hostname;
        private WebClient wc;
        private string Token;
        public SteamButtonsClient Buttons
        {
            get
            {
                return new SteamButtonsClient(this);

            }
        }
        public SteamMouseClient Mouse
        {
            get
            {
                return new SteamMouseClient(this);

            }
        }
        public SteamKeyboardClient Keyboard
        {
            get
            {
                return new SteamKeyboardClient(this);

            }
        }
        public SteamGamesClient Games
        {
            get
            {
                return new SteamGamesClient(this);

            }
        }
        public SteamMusicClient Music
        {
            get
            {
                return new SteamMusicClient(this);

            }
        }
        private string baseString
        {
            get
            {
                return "https://" + Hostname + ":27037/steam/";
            }
        }
        public SteamClient(string Hostname)
        {
            this.Hostname = Hostname;
            wc = new WebClient();
            ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => true;
        }

        public void Authorize()
        {
            Authorize((string)null);
        }
        public void Authorize(string Name)
        {
            Authorize(Name, GenerateToken());
        }
        public void Authorize(string Name, string Token)
        {
            var authNvc = new NameValueCollection();
            authNvc.Add("device_name", Name);
            authNvc.Add("device_token", Token);

            var auth = Post("authorization/",
                    authNvc
                );
            this.Token = Token;
        }

        public string Post(string Path, NameValueCollection nvc, bool IncludeExtraAuth=false)
        {
            if (IncludeExtraAuth)
            {
                if (nvc == null)
                {
                    nvc = new NameValueCollection();
                }
                nvc.Add("device_token", Token);
            }
            return System.Text.Encoding.Default.GetString(wc.UploadValues(baseString+Path,nvc));
        }

        private string GenerateToken()
        {
            string str = "";
            var rand = new Random();
            for (int i = 0; i < 8; i++) str += (char)('A' + (rand.Next('Z' - 'A')));
            return str;
        }
    }
}
