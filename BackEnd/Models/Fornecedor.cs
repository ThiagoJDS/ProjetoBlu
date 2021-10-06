using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Fornecedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Empresa")]
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [Column(TypeName = "varchar(70)")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [Column(TypeName = "varchar(11)")]
        public string Cpf { get; set; }

        [ForeignKey("Cnpj")]
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        public int CnpjId { get; set; }
        public Empresa Cnpj { get; set; }

        [Display(Name = "Idade")]
        [Range(1, 70, ErrorMessage = "{0} não pode ser menor que 1 e maior que 70")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [Column(TypeName = "varchar(12)")]
        public string Rg { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [ForeignKey("Telefone")]
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        public int TelefoneId { get; set; }
        public Telefone Telefone { get; set; }

        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage = "É necessário ser um {0} válido")]
        public string Email { get; set; }

        public Fornecedor(int id, int empresaId, string nome, string cpf, int cnpjId, int idade, string rg, DateTime dataNascimento, DateTime dataCadastro, int telefoneId, string email)
        {
            Id = id;
            EmpresaId = empresaId;
            Nome = nome;
            Cpf = cpf;
            CnpjId = cnpjId;
            Idade = idade;
            Rg = rg;
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;
            TelefoneId = telefoneId;
            Email = email;
        }
    }
}