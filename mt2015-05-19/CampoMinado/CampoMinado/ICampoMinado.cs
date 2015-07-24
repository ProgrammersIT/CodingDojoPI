using System;
namespace CampoMinado
{
    public interface ICampoMinado
    {
        Celula[,] Campo { get; }
        void AdicionarBomba(Posicao posicao);
    }
}
