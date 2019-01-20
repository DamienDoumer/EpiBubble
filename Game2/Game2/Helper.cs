using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Game2
{
    public class Helper 
    {
        private System.Collections.Generic.List<Bubble> myBubbles;

        public Helper()
        {

        }

        //default
        //      public System.Collections.Generic.List<Color> randomColor()
        //      {
        //          System.Collections.Generic.List<Color> res = new System.Collections.Generic.List<Color>();
        //          System.Random rnd = new System.Random();

        //          for (int i = 0; i < 17;i++)
        //          {
        //              Color c = Color.White;
        //              int number = rnd.Next(1, 13);

        //              if (number == 1) {
        //                  res.Add(Color.Black);
        //             }
        //              if (number == 2) {
        //                res.Add(Color.Silver);
        //              }
        //            if (number == 3) {
        //              res.Add(Color.Gray);
        //            }
        //            if (number == 4)
        //            {
        //              res.Add(Color.Maroon); 
        //             }
        //        if (number == 5)
        //        {
        //            res.Add(Color.Red);
        //        }
        //        if (number == 6)
        //        {
        //            res.Add(Color.Purple);
        //        }
        //        if (number == 7)
        //        {
        //            res.Add(Color.Fuchsia);
        //        }
        //        if (number == 8)
        //        {
        //            res.Add(Color.Green);
        //        }
        //        if (number == 9)
        //        {
        //            res.Add(Color.Lime);
        //        }
        //        if (number == 10)
        //        {
        //            res.Add(Color.Yellow);
        //        }
        //        if (number == 11)
        //        {
        //            res.Add(Color.Blue);
        //        }
        //        if (number == 12)
        //        {
        //            res.Add(Color.Cyan);
        //        }

        //    }
        //    return res;
        //} 

        public System.Collections.Generic.List<Color> randomColorDefault()
        {
            System.Collections.Generic.List<Color> res = new System.Collections.Generic.List<Color>();
            System.Random rnd = new System.Random();

            for (int i = 0; i < 17; i++)
            {
                Color c = Color.White;
                int number = rnd.Next(1, 7);

                if (number == 1)
                {
                    res.Add(Color.Blue);
                }
                if (number == 2)
                {
                    res.Add(Color.Red);
                }
                if (number == 3)
                {
                    res.Add(Color.Cyan);
                }
                if (number == 4)
                {
                    res.Add(Color.Yellow);
                }
                if (number == 5)
                {
                    res.Add(Color.Fuchsia);
                }
                if (number == 6)
                {
                    res.Add(Color.Lime);
                }
            }
            return res;
        }

    }
}