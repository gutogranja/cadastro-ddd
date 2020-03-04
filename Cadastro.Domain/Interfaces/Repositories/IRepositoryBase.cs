using System.Collections.Generic;

namespace Cadastro.Domain.Interfaces.Repositories
{
    // Feito

    public interface IRepositoryBase<T,TView>
    {
        List<TView> ListarTodos();
        T ObterPorId(int id);
        T Incluir(T aluno);
        T Alterar(T aluno);
        void Excluir(int id);
        bool VerificarNomeAluno(string nomeAluno);
    }
}
