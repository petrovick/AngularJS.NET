using angularjs.Data.Factory;
using angularjs.Data.GenericFactory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace angularjs.Application.Generic
{
    public class GenericApplication<TEntity, Key> : IDisposable, IGenericApplication<TEntity, Key> where TEntity : class
    {
        #region Properties

        protected IRepository<TEntity> repository;

        #endregion Properties

        #region Constructors

        public GenericApplication()
        {
            this.repository = RepositoryFactory<TEntity>.getInstance().GetRepository();
        }

        #endregion

        #region SaveMethods

        ///<summary>
        ///<para>Responsável para inserir o objeto passado como parâmetro no contexto</para>
        ///<para>Deverá-se utilizar o método SaveChanges() para confirmar as alterações no Banco de Dados</para>
        ///</summary>
        public String Save(TEntity entity)
        {
            string erros = "";

            try
            {
                repository.Save(entity);
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

            catch (Exception ex)
            {
                erros = "Ocorreu um erro ao inserir. " + ex.Message;
            }

            return erros;
        }

        #endregion

        #region DbContext

        ///<summary>
        ///<para>Utilizado para confirmar as alterações feitas no contexto</para>
        ///<para>Utilize para persistir as alterações no banco de dados</para>
        ///</summary>
        public String SaveChanges()
        {
            String erros = "";

            try
            {
                repository.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch (Exception ex)
            {
                erros = "Ocorreu um erro ao salvar alterações. " + ex.Message;
                if (ex.InnerException != null)
                    erros += " | " + ex.InnerException.ToString();
            }
            return erros;
        }

        ///<summary>
        ///<para>Utilizado para obter a conexão que essa application possui com o banco de dados</para>
        ///<para>Útil se é necessário alterar objetos de contextos diferentes</para>
        ///<para>Deve ser utilizado em conjunto com o método SetContext</para>
        ///</summary>
        public DbContext GetContext()
        {
            return repository.GetContext();
        }

        ///<summary>
        ///<para>Utilizado para alterar a conexão que essa application possui com o banco de dados</para>
        ///<para>Útil se é necessário alterar objetos de contextos diferentes</para>
        ///<para>Deve ser utilizado em conjunto com o método SetContext</para>
        ///</summary>
        public void SetContext(DbContext context)
        {
            repository.SetContext(context);
        }

        #endregion

        #region UpdateMethods

        ///<summary>
        ///<para>Responsável por alterar o estado do objeto passado como parâmetro para alterado</para>
        ///<para>Deverá-se utilizar o método SaveChanges() para confirmar as alterações no Banco de Dados</para>
        ///</summary>
        public String Update(TEntity entity)
        {
            string erros = "";

            try
            {
                repository.Update(entity);
            }

            catch (Exception ex)
            {
                erros = "Ocorreu um erro ao inserir. " + ex.Message;
            }

            return erros;
        }

        #endregion

        #region DeleteMethods

        ///<summary>
        ///<para>Responsável por alterar o estado do objeto identificado pelo Id passado como parâmetro para Excluído</para>
        ///<para>Deverá-se utilizar o método SaveChanges() para confirmar as alterações no Banco de Dados</para>
        ///</summary>
        public String Delete(Key id)
        {
            string erros = "";

            try
            {
                TEntity entity = Single(id);
                repository.Delete(entity);
            }

            catch (Exception ex)
            {
                erros = "Ocorreu um erro ao excluir. " + ex.Message;
            }

            return erros;
        }

        ///<summary>
        ///<para>Responsável por alterar o estado do objeto passado como parâmetro para excluído</para>
        ///<para>Deverá-se utilizar o método SaveChanges() para confirmar as alterações no Banco de Dados</para>
        ///</summary>
        public String Delete(TEntity entity)
        {
            string erros = "";

            try
            {
                repository.Attach(entity);
                repository.Delete(entity);
                repository.SaveChanges();
            }

            catch (Exception ex)
            {
                erros = "Ocorreu um erro ao excluir. " + ex.Message;
            }

            return erros;
        }

        ///<summary>
        ///<para>Responsável por alterar o estado do objeto identificado através do predicado passado como parâmetro para excluído</para>
        ///<para>Deverá-se utilizar o método SaveChanges() para confirmar as alterações no Banco de Dados</para>
        ///</summary>
        public String Delete(Func<TEntity, bool> predicate)
        {
            string erros = "";

            try
            {
                repository.Delete(predicate);
                repository.SaveChanges();
            }

            catch (Exception ex)
            {
                erros = "Ocorreu um erro ao excluir. " + ex.Message;
            }

            return erros;
        }

        ///<summary>
        ///<para>Responsável por alterar o estado dos objetos passados como parâmetro para excluídos</para>
        ///<para>Deverá-se utilizar o método SaveChanges() para confirmar as alterações no Banco de Dados</para>
        ///</summary>
        public String DeleteAll(IEnumerable<TEntity> entities)
        {
            string erros = "";

            try
            {
                repository.DeleteAll(entities);
            }

            catch (Exception ex)
            {
                erros = "Ocorreu um erro" + ex.Message;
            }

            return erros;
        }

        #endregion

        #region ReadMethods

        ///<summary>
        ///<para>Responsável por retornar todos os registros do banco de dados</para>
        ///</summary>
        public IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> entity = repository.GetAll();
            return entity;
        }

        ///<summary>
        ///<para>Retorna todos os registros do banco de dados com o [Include] para as classes passadas como parâmetro</para>
        ///</summary>
        public IEnumerable<TEntity> GetAll(params string[] includes)
        {
            IEnumerable<TEntity> entity = repository.GetAll(includes);
            return entity;
        }

        ///<summary>
        ///<para>Responsável por retornar todos os registros do banco de dados</para>
        ///</summary>
        public IQueryable<TEntity> getAllAsQueryAble()
        {
            IQueryable<TEntity> entity = repository.GetAll();
            return entity;
        }

        ///<summary>
        ///<para>Retorna todos os registros do banco de dados com o [Include] para as classes passadas como parâmetro</para>
        ///</summary>
        public IQueryable<TEntity> getAllAsQueryAble(params string[] includes)
        {
            IQueryable<TEntity> entity = repository.GetAllAsQueryAble(includes);
            return entity;
        }

        ///<summary>
        ///<para>Retorna os registros do banco de dados que atendem ao predicado passado como parâmetro</para>
        ///<para>retorna os registros com o [Include] para as classes passadas como parâmetro</para>
        ///</summary>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where, params string[] includes)
        {
            IEnumerable<TEntity> entity = repository.Find(where, includes);
            return entity;
        }

        ///<summary>
        ///<para>Retorna os registros do banco de dados que atendem ao predicado passado como parâmetro</para>
        ///</summary>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            if (where != null)
            {
                IEnumerable<TEntity> entity = repository.Find(where);
                return entity;
            }

            else
            {
                return Enumerable.Empty<TEntity>();
            }
        }

        ///<summary>
        ///<para>Retorna um registro a partir do Id passado como parâmetro</para>
        ///</summary>
        public TEntity Single(Key id)
        {
            TEntity entity;
            entity = repository.Single(id);
            return entity;
        }

        #endregion

        #region Repository

        ///<summary>
        ///<para>Responsável por fechar o contexto da Application</para>
        ///</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            repository.Dispose();
        }

        #endregion

    }
}
