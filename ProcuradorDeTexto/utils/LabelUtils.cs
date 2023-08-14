using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcuradorDeTexto.utils
{
    public static class LabelUtils
    {
        public static void UpdateLabelInt(Label label,int numero)
        {
            label.Text = numero.ToString();
        }

        public static void UpdateLabelString(Label label,string texto)
        {
            label.Text = texto;
        }

        public static void UpdateLabelConcurrentBag(Label label, ConcurrentBag<String[]> concurrentBag)
        {
            label.Text = concurrentBag.Count.ToString();
        }
    }
}
