using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces.Repositories;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Cadastro.Infra.Data.Repositories
{
    public abstract class RepositoryBase<T, TView> : IRepositoryBase<T, TView> where T : Entity where TView : class
    {
        protected SqlConnection cn = new SqlConnection("");
        public T Alterar(T entity)
        {
            bool ret = cn.Update(entity);
            if (ret)
                return entity;
            return null;
        }

        public virtual void Excluir(int id)
        {
            var entity = ObterPorId(id);
            cn.Delete(entity);
        }

        public T Incluir(T entity)
        {
            var retorno = cn.Insert(entity);
            if (retorno > 0)
                return entity;
            return null;
        }

        public abstract IEnumerable<TView> ListarTodos();

        public T ObterPorId(int id)
        {
            return cn.Get<T>(id);
        }

    }
}
