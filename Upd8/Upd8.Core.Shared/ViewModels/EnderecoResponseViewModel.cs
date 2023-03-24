using Upd8.Core.Enums;

namespace Upd8.Core.Shared.ViewModels
{
    public class EnderecoResponseViewModel : ICloneable
    {
        public EnderecoResponseViewModel(string complemento, string codigoIbge, string nomeCidade, EEStado estado)
        {
            Complemento = complemento;
            CodigoIbge = codigoIbge;
            NomeCidade = nomeCidade;
            Estado = estado;
        }

        public string Complemento { get; init; }
        public string CodigoIbge { get; init; }
        public string NomeCidade { get; init; }
        public EEStado Estado { get; init; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
