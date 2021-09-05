using System;
using System.Threading;

namespace AutobahnRacingServer
{
    class Entry
    {
        private static bool isRunning = false;
        static void Main(string[] args)
        {
            Console.Title = "Autobahn Racing - Server";
            
            ServerLogger.Log("Autobahn Racing - Server", ConsoleColor.Green, 1);

            isRunning = true;

            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();

            Server.Start(Constants.MAX_PLAYERS, Constants.PORT);
        }

        private static void MainThread()
        {
            Console.WriteLine($"Main thread started. Running at {Constants.TICKS_PER_SEC} ticks per second");
            DateTime _nextLoop = DateTime.Now;

            while (isRunning)
            {
                while(_nextLoop < DateTime.Now)
                {
                    GameLogic.Update();

                    _nextLoop = _nextLoop.AddMilliseconds(Constants.MS_PER_TICK);

                    if(_nextLoop > DateTime.Now)
                    {
                        Thread.Sleep(_nextLoop - DateTime.Now);   
                    }
                }
            }
        }
    }
}
