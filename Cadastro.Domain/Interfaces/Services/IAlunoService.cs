using System.Collections.Generic;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Entities.Views;
using Cadastro.Domain.Interfaces.Notifications;

namespace Cadastro.Domain.Interfaces.Services
{
    // Feito

    public interface IAlunoService : INotificationService
    {
        IEnumerable<AlunoView> ListarTodos();
        Aluno ObterPorId(int id);
        Aluno Incluir(Aluno aluno);
        Aluno Alterar(Aluno aluno);
        void Excluir(int id);
    }
}
