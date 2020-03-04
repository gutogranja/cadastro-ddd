using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastro.Domain.Entities.Views
{
    public class AlunoView
    {
        // Feito
        // Modelo Anêmico

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}
