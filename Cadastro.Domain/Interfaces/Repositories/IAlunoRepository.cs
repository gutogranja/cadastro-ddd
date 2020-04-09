using Cadastro.Domain.Entities;
using Cadastro.Domain.Entities.Views;

namespace Cadastro.Domain.Interfaces.Repositories
{
    // Feito

    public interface IAlunoRepository : IRepositoryBase<Aluno,AlunoView>
    {
        bool VerificarNomeAluno(string nomeAluno);
    }
}
