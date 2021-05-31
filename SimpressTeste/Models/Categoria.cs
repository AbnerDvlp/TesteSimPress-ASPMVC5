using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_TesteSimpress.Models
{
    [Table("tblCategoria")]
    public class Categoria
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public bool ativo { get; set; }
    }
}