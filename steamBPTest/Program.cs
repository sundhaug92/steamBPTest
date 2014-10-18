using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Threading;

namespace steamBPTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hostname=");
            SteamClient steam = new SteamClient(Console.ReadLine());

            Console.Write("App-name=");
            steam.Authorize(Console.ReadLine());

            Console.WriteLine("SetVolume0");
            steam.Music.SetVolume(0);

            Thread.Sleep(500);
            Console.WriteLine("Play");
            steam.Music.Play();

            Thread.Sleep(500);
            Console.WriteLine("SetVolume1");
            steam.Music.SetVolume(1);

            Console.Write("GameID=");
            steam.Games.Run(int.Parse(Console.ReadLine()));
            /*
            var runGame = System.Text.Encoding.Default.GetString(
                    wc.UploadValues("https://localhost:27037/steam/games/220200/run",
                    authNvc
                )
                );
            */
        }
    }
}
