using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBubble.Helpers
{
    public class Helpers
    {
        public static Color GetRandomBallColor()
        {
            Color c = Color.White;
            System.Random rnd = new System.Random();
            int number = rnd.Next(1, 13);
            switch (number)
            {
                case 1:
                    return Color.Black;
                case 2:
                    return Color.Silver;
                case 3:
                    return Color.Gray;
                case 4:
                    return Color.Maroon;
                case 5:
                    return Color.Red;
                case 6:
                    return Color.Purple;
                case 7:
                    return Color.Fuchsia;
                case 8:
                    return Color.Green;
                case 9:
                    return Color.Lime;
                case 10:
                    return Color.Yellow;
                case 11:
                    return Color.Blue;
                case 12:
                    return Color.Cyan;
            }
            return c;
        }
        public static Dictionary<int, Color> ArrowColors { get; set; }
    }
}
