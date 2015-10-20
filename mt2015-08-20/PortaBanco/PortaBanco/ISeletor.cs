using System.Collections.Generic;
namespace PortaBanco
{
    public interface ISeletor
    {
        List<LinhaLog> Filtrar(List<LinhaLog> linhasLog);
    }
}
