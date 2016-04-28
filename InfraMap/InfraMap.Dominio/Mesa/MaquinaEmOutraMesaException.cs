using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.Mesa
{
    public class MaquinaEmOutraMesaException : Exception
    {
        public MaquinaEmOutraMesaException(string message)
            : base(message)
        {
        }
    }
}
