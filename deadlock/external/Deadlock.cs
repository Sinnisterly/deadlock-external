﻿using deadlock.Drawing;
using deadlock.Stuff;
using GameOverlay.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dumper.Schemas.ClientDll;

namespace deadlock.external
{
    internal static class Deadlock
    {
        static Deadlock()
        {
            LocalPlayer = new LocalPlayer();
            Players = new List<Player>();
            for (int i = 1; i < 16; i++)
            {
                Players.Add(new Player(i));
            }
        }

        public static void Update()
        {
            EntityList = Memory.Read<IntPtr>(Memory.ClientPtr + Offsets.dwEntityList);
            LocalPlayer.Update();
            Players.ForEach(x => x.Update());
        }

        public static void Draw(Graphics g)
        {
            Players.ForEach(x => x.Draw(g));
            Radar.Draw(g);
            Resources.Share.Color = new Color(255, 255, 255);
        }

        public static IntPtr EntityList
        {
            get; set;
        }

        public static List<Player> Players
        {
            get; set;
        }

        public static LocalPlayer LocalPlayer
        {
            get; set;
        }
    }
}
