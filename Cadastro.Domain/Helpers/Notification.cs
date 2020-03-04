using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastro.Domain.Helpers
{
    // Feito
    public class Notification
    {
        public string Chave { get; set; }
        public string Mensagem { get; set; }

        public Notification(string key,string message)
        {
            Chave = key;
            Mensagem = message;
        }
    }
}
