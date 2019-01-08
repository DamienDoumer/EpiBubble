using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBubble.Models
{
    class Arrow
    {
        private Tuple <float,float> Position;
        private EnumColorsArrow Colors;

        public Arrow(Tuple<float, float> Position, EnumColorsArrow Colors)
        {
            this.Position = Position;
            this.Colors = Colors;
        }

       public void setPosition(Tuple<float,float> Position)
        {
            this.Position = Position;
        }

        public Tuple<float,float> getPosition()
        {
            return this.Position;
        }


    }
}
