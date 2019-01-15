using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBubble.Helpers
{
    public class SetupDialogClosedEventArgs : EventArgs
    {
        public Difficulty DifficultyLevel { get; set; }
        public int NumberOfShotsBeforeNewRow { get; set; }
        public Color PreferedArrowColor { get; set; }
    }
}
