using Cadastro.Domain.Helpers;

namespace Cadastro.Domain.Entities
{
    public abstract class Entity : NotificationService
    {
        public int Id { get; protected set; }
    }
}
