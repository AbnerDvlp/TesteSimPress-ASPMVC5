using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_TesteSimpress.Models
{
    [Table("tblProduto")]
    public class Produto
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório", AllowEmptyStrings = false)]
        public string nome { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória", AllowEmptyStrings = false)]
        public string descricao { get; set; }

        [Required(ErrorMessage = "A opção ativo do produto é obrigatória", AllowEmptyStrings = false)]
        public bool ativo { get; set; }

        [Required(ErrorMessage = "A opção perecivel do produto é obrigatória", AllowEmptyStrings = false)]
        public bool perecivel { get; set; }

        [Required(ErrorMessage = "A categoria do produto é obrigatória", AllowEmptyStrings = false)]
        public int idCategoria { get; set; }
    }
}