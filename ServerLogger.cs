using System;
using System.Collections.Generic;
using System.Text;

namespace AutobahnRacingServer
{
    class ServerLogger
    {
        public static void Log(string _msg, ConsoleColor _color, int _blankSpaces)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine(_msg);

            for (int i = 0; i < _blankSpaces; i++)
            {
                Console.WriteLine("");
            }

            Console.ResetColor();
        }

        public static void LogConnectionIncoming(string _ip, string _username, int _userID, int _blankSpaces)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"[{_ip}]:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" \"" + $"{_username}" + "\" ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("connected successfully and is now player");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" " + _userID);

            for (int i = 0; i < _blankSpaces; i++)
            {
                Console.WriteLine("");
            }

            Console.ResetColor();
        }
    }
}
