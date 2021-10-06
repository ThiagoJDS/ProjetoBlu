using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [Column(TypeName = "varchar(50)")]
        public string UnidadeFederacao { get; set; }

        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [Column(TypeName = "varchar(70)")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [Column(TypeName = "varchar(14)")]
        public string Cnpj { get; set; }

        public Empresa(int id, string unidadeFederacao, string nome, string cnpj)
        {
            Id = id;
            UnidadeFederacao = unidadeFederacao;
            Nome = nome;
            Cnpj = cnpj;
        }
    }
}