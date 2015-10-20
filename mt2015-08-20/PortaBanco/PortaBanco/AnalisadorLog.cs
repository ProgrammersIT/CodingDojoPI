using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortaBanco
{
    public class AnalisadorLog
    {
        ILogMapper logMapper;
        ISeletor seletor;

        public AnalisadorLog(ILogMapper logMapper, ISeletor seletor)
        {
            this.logMapper = logMapper;
            this.seletor = seletor;
        }

        public List<LinhaLog> AnalisarEntradas(List<string> linhasLog)
        {
            var mapeados = new List<LinhaLog>();

            foreach (var linhaLog in linhasLog)
                if (logMapper.CanMap(linhaLog))
                    mapeados.Add(this.logMapper.Map(linhaLog));

            return seletor.Filtrar(mapeados);
        }
    }
}
