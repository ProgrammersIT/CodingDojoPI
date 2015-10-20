using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortaBanco
{
    public class HorarioEntradaNaPortaDoBancoDePirinopolisSelector : ISeletor
    {
        public List<LinhaLog> Filtrar(List<LinhaLog> linhasLog)
        {
            return linhasLog.Where(x => x.HorarioLog.Hour >= 10 && 
                (x.HorarioLog.Hour < 16 || 
                (x.HorarioLog.Hour == 16 && x.HorarioLog.Minute == 00))).ToList();
        }
    }
}
