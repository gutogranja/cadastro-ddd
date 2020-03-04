using System.ComponentModel.DataAnnotations.Schema;
using Cadastro.Domain.Helpers;

namespace Cadastro.Domain.Entities
{
    // Feito
    // Modelo Rico


    [Table("Alunos")]

    public class Aluno : NotificationService
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        private Aluno()
        {
        }

        public Aluno(string nomeAluno, string endAluno, string bairroAluno, string cidadeAluno)
        {
            Nome = nomeAluno;
            Endereco = endAluno;
            Bairro = bairroAluno;
            Cidade = cidadeAluno;
            if (string.IsNullOrEmpty(Nome))
                AddNotification("aluno", "Nome do aluno é obrigatório.");
        }

        //public Aluno(Aluno aluno)
        //{
        //    Nome = aluno.Nome;
        //    Endereco = aluno.Endereco;
        //    Bairro = aluno.Bairro;
        //    Cidade = aluno.Cidade;
        //    if (string.IsNullOrEmpty(Nome))
        //        AddNotification("aluno", "Nome do aluno é obrigatório.");
        //}

        public void AlterarNome(string nomeAluno)
        {
            if (!string.IsNullOrEmpty(nomeAluno))
                Nome = nomeAluno;
            else
                AddNotification("aluno", "Nome do aluno é obrigatório.");
        }
    }
}
