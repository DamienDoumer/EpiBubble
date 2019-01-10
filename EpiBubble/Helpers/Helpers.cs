using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBubble.Helpers
{
    public static class Helpers
    {
        public static Dictionary<int, Color> BallColors { get; set; } = new Dictionary<int, Color>
        {
            { 0, Color.Yellow },
            { 1, Color.Red },
            { 2, Color.Blue },
            { 3, Color.Cyan },
            { 4, Color.Gray },
            { 5, Color.Maroon },
            { 6, Color.Silver },
            { 7, Color.Purple },
            { 8, Color.Fuchsia },
            { 9, Color.Green },
            { 10, Color.Lime },
            { 11, Color.Purple },
        };
        public static Dictionary<int, Color> ArrowColors { get; set; }

        public static Color GetRandomBallColor()
        {
            Random random = new Random();
            return BallColors.ElementAt(random.Next(1, BallColors.Count)).Value;
        }
    }
}
