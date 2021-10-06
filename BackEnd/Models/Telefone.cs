using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Telefone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [Column(TypeName = "varchar(20)")]
        public string NumeroTelefone { get; set; }

        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [Column(TypeName = "varchar(70)")]
        public string Nome { get; set; }

        public Telefone(int id, string numeroTelefone, string nome)
        {
            Id = id;
            NumeroTelefone = numeroTelefone;
            Nome = nome;
        }
    }
}