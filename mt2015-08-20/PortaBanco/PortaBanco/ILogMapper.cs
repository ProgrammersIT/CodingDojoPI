namespace PortaBanco
{
    public interface ILogMapper
    {
        bool CanMap(string linhaLog);
        LinhaLog Map(string linhaLog);
    }
}
