using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Entities.Views;
using Cadastro.Domain.Interfaces.Repositories;

namespace Cadastro.Infra.Data.Repositories
{
    // Feito


    public class AlunoRepository : IAlunoRepository
    {
        SqlConnection cn = new SqlConnection("Data Source=srvcon,6060;Initial Catalog=Central;Connection Timeout=180;Persist Security Info=True;User ID=Portal;Password=**@pwp0rt4l@**;Application Name=Cadastro");

        public List<AlunoView> ListarTodos()
        {
            return cn.Query<AlunoView>("SELECT * FROM Alunos").ToList();
        }

        public Aluno ObterPorId(int id)
        {
            return cn.Query<Aluno>($"SELECT * FROM Alunos WHERE Id = {id}").FirstOrDefault();
        }

        public Aluno Incluir(Aluno aluno)
        {
            var retorno = cn.Insert(aluno);
            if (retorno > 0)
                return aluno;
            return null;
        }

        public Aluno Alterar(Aluno aluno)
        {
            bool ret = cn.Update(aluno);
            if (ret)
                return aluno;
            return null;
        }

        public bool VerificarNomeAluno(string nome)
        {
            return cn.Query<int>($"SELECT TOP 1 1 FROM Alunos WHERE Nome = '{nome}'").Any();
        }

        public void Excluir(int id)
        {
            cn.Query<Aluno>($"DELETE Alunos WHERE Id = {id}");
        }
    }
}
