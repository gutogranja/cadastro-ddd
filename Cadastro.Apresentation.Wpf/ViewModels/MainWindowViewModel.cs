using MahApps.Metro.Controls.Dialogs;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Entities.Views;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Services;
using Cadastro.Infra.Data.Repositories;

namespace Cadastro.Apresentation.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        IDialogCoordinator dialog;
        private readonly IAlunoService alunoService;

        public DelegateCommand IncluirCommand { get; set; }
        public DelegateCommand AlterarCommand { get; set; }
        public DelegateCommand ExcluirCommand { get; set; }
        public ProgressDialogController Progresso { get; set; }

        private List<AlunoView> _listaAluno;
        public List<AlunoView> ListaAluno
        {
            get { return _listaAluno; }
            set { SetProperty(ref _listaAluno, value); }
        }

        private AlunoView _aluno = new AlunoView();
        public AlunoView Aluno
        {
            get { return _aluno; }
            set
            {
                SetProperty(ref _aluno, value);
            }
        }

        public MainWindowViewModel(IDialogCoordinator dialog)
        {
            this.dialog = dialog;
            alunoService = new AlunoService(new AlunoRepository());
            IncluirCommand = new DelegateCommand(Incluir);
            AlterarCommand = new DelegateCommand(Alterar);
            ExcluirCommand = new DelegateCommand(Excluir);
            BuscarAlunos();
        }

        private void BuscarAlunos()
        {
            ListaAluno = alunoService.ListarTodos();
        }

        private async void Incluir()
        {
            var novoAluno = new Aluno(Aluno.Nome, Aluno.Endereco, Aluno.Bairro, Aluno.Cidade);
            var alunoCriado = alunoService.Incluir(novoAluno);
            if (!alunoService.Validar)
            {
                var linq = alunoService.Notifications.Select(msg => msg.Mensagem);
                await this.dialog.ShowMessageAsync(this, "Atenção", string.Join("\r\n", linq));
                alunoService.ClearNotifications();
            }
            if (alunoCriado != null)
            {
                Progresso = await dialog.ShowProgressAsync(this, "Progresso", "Incluindo dados do aluno. Aguarde...");
                Progresso.SetIndeterminate();
                var t = Task.Factory.StartNew(() => { BuscarAlunos(); });
                await t;
                Progresso?.CloseAsync();
                await this.dialog.ShowMessageAsync(this, "Atenção", "Aluno cadastrado com sucesso !!!");
            }
        }

        private async void Alterar()
        {
            if (Aluno != null && Aluno.Id > 0)
            {
                var alunoExistente = alunoService.ObterPorId(Aluno.Id);
                alunoExistente.AlterarNome(Aluno.Nome);
                if (alunoExistente.Validar)
                {
                    Progresso = await dialog.ShowProgressAsync(this, "Progresso", "Alterando dados do aluno. Aguarde...");
                    Progresso.SetIndeterminate();
                    var t = Task.Factory.StartNew(() => { alunoService.Alterar(alunoExistente); });
                    await t;
                    Progresso?.CloseAsync();
                    await this.dialog.ShowMessageAsync(this, "Atenção", "Aluno alterado com sucesso !!!");
                }
                else
                {
                    await this.dialog.ShowMessageAsync(this, "Atenção", string.Join("\r\n", alunoExistente.Notifications.Select(s => s.Mensagem)));
                    alunoService.ClearNotifications();
                }
            }
        }

        private async void Excluir()
        {
            if (Aluno != null && Aluno.Id > 0)
            {
                var alunoExistente = alunoService.ObterPorId(Aluno.Id);
                if (alunoExistente.Validar)
                {
                    Progresso = await dialog.ShowProgressAsync(this, "Progresso", "Excluindo dados do aluno. Aguarde...");
                    Progresso.SetIndeterminate();
                    var t = Task.Factory.StartNew(() => { alunoService.Excluir(alunoExistente.Id); });
                    await t;
                    Progresso?.CloseAsync();
                    await this.dialog.ShowMessageAsync(this, "Atenção", "Aluno excluído com sucesso !!!");


                }
                else
                {
                    await this.dialog.ShowMessageAsync(this, "Atenção", string.Join("\r\n", alunoExistente.Notifications.Select(s => s.Mensagem)));
                    alunoService.ClearNotifications();
                }
            }
        }
    }
}
