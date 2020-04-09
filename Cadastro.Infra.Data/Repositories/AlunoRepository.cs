using Dapper;
using System.Linq;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Entities.Views;
using Cadastro.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Cadastro.Infra.Data.Repositories
{
    // Feito
    public class AlunoRepository : RepositoryBase<Aluno, AlunoView>, IAlunoRepository
    {
        public bool VerificarNomeAluno(string nome)
        {
            return cn.Query<int>($"SELECT TOP 1 1 FROM Alunos WHERE Nome = '{nome}'").Any();
        }
        public override void Excluir(int id)
        {
            cn.Query<Aluno>($"DELETE Alunos WHERE Id = {id}");
        }

        public override IEnumerable<AlunoView> ListarTodos()
        {
            return cn.Query<AlunoView>("SELECT * FROM Alunos").ToList();
        }
    }
}
