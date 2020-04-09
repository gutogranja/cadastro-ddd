using System.Collections.Generic;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Entities.Views;
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;

namespace Cadastro.Domain.Services
{
    // Feito

    public class AlunoService : BaseService, IAlunoService
    {
        private readonly IAlunoRepository repository;

        public AlunoService(IAlunoRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<AlunoView> ListarTodos()
        {
            return repository.ListarTodos();
        }

        public Aluno ObterPorId(int id)
        {
            return repository.ObterPorId(id);
        }

        public Aluno Incluir(Aluno aluno)
        {
            ValidarAluno(aluno);
            if (Validar)
            {
                bool alunoExistente = repository.VerificarNomeAluno(aluno.Nome);
                if (!alunoExistente)
                {
                    return repository.Incluir(aluno);
                }
                else
                {
                    AddNotification("aluno", "Aluno já existe.");
                }
            }
            return null;
        }

        public Aluno Alterar(Aluno aluno)
        {
            ValidarAluno(aluno);
            if (Validar)
            {
                var alunoExistente = repository.ObterPorId(aluno.Id);
                if (alunoExistente != null)
                {
                    alunoExistente.AlterarNome(aluno.Nome);
                    return repository.Alterar(alunoExistente);
                }
                AddNotification("aluno", "Aluno não existe.");
            }
            return null;
        }

        public void Excluir(int id)
        {
            var alunoExistente = repository.ObterPorId(id);
            if (alunoExistente != null)
            {
                repository.Excluir(id);
            }
            else
            {
                AddNotification("aluno", "Não é possivel excluir um aluno que não existe.");
            }
        }

        private void ValidarAluno(Aluno aluno)
        {
            if (aluno == null)
            {
                AddNotification("aluno", "Aluno é obrigatório.");
            }
            if (!aluno.Validar)
            {
                AddNotification(aluno.Notifications);
            }
        }
    }
}
