namespace CampoMinado
{
    public class PosicionadorDeBombas
    {
        private ICampoMinado _campoMinado;

        public PosicionadorDeBombas(ICampoMinado campoMinado)
        {
            _campoMinado = campoMinado;
        }

        public void PosicionaBombasNoCampo(Posicao[] posicoes)
        {
            foreach (var posicao in posicoes)
            {
                _campoMinado.AdicionarBomba(posicao);
            }
        }
    }
}