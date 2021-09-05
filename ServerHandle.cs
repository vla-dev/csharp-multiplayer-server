using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AutobahnRacingServer
{
    class ServerHandle
    {
        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            ServerLogger.LogConnectionIncoming(Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint.ToString(), _username, _fromClient, 1);

            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})");
            }

            Server.clients[_fromClient].SendIntoGame(_username);
        }

        public static void PlayerMovement(int _fromClient, Packet _packet)
        {
            Console.WriteLine("PlayerMovement");
            Vector3 playerPosition = _packet.ReadVector3();
            Quaternion playerRotation = _packet.ReadQuaternion();
            Vector3 rb_velocity = _packet.ReadVector3();
            Server.clients[_fromClient].player.UpdatePositionAndRotation(playerPosition, playerRotation, rb_velocity);
        }
    }
}
