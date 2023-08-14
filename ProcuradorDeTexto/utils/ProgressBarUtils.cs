using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcuradorDeTexto.utils
{
    public static class ProgressBarUtils
    {
        public static void UpdateProgressBar(ProgressBar pBar)
        {
            if (pBar.MarqueeAnimationSpeed != 0)
            {
                pBar.MarqueeAnimationSpeed = 0;
                pBar.Style = ProgressBarStyle.Blocks;
                pBar.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                pBar.MarqueeAnimationSpeed = 30;
            }
            
        }
    }

}
