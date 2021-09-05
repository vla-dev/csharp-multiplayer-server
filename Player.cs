using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace AutobahnRacingServer
{
    class Player
    {
        public int id;
        public string username;

        public Vector3 position;
        public Quaternion rotation;
        public Vector3 rb_velocity;

        public Player(int _id, string _username, Vector3 _spawnPosition)
        {
            id = _id;
            username = _username;
            position = _spawnPosition;
            rotation = Quaternion.Identity;
        }

        public void UpdatePositionAndRotation(Vector3 _playerPosition, Quaternion _playerRotation, Vector3 _rb_velocity)
        {
            Console.WriteLine($"[{id}] X: {_playerPosition.X} | Y: {_playerPosition.Y} | Z: {_playerPosition.Z}");
            position = _playerPosition;
            rotation = _playerRotation;
            rb_velocity = _rb_velocity;

            ServerSend.UpdatePlayerPositionAndRotation(this);
        }
    }
}
