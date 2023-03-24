using Upd8.Web.Enums;

namespace Upd8.Web.Dtos
{
    public class CidadeDto
    {
        public int Id { get; set; }
        public string CodigoIbge { get; set; }
        public string Nome { get; set; }
        public EEStado Estado { get; set; }
    }
}
