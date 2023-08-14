using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcuradorDeTexto.utils
{
    public static class ButtonUtils
    {
        public static void UpdateButton(Button button)
        {
            if (button.Enabled == true)
            {
                button.Enabled = false;
            }
            else
            {
                button.Enabled = true;
            }
        }
    }
}
