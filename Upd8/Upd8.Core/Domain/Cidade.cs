using Upd8.Core.Enums;

namespace Upd8.Core.Domain
{
    public class Cidade
    {
        public int Id { get; set; }
        public string CodigoIbge { get; set; }
        public string Nome { get; set; }
        public EEStado Estado { get; set; }
    }
}
