using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcuradorDeTexto.utils
{
    public static class StringUtils
    {  

        public static bool ContainsIgnoreCase(this string entrada, string comparacao)
        {

            return entrada.ToLower().Contains(comparacao.ToLower());
        }
    }
}
