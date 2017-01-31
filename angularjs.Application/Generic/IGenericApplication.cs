using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace angularjs.Application.Generic
{
    public interface IGenericApplication<TEntity, Key> where TEntity : class
    {
        #region SaveMethods

        ///<summary>
        ///<para>Responsável para inserir o objeto passado como parâmetro no contexto</para>
        ///<para>Deverá-se utilizar o método SaveChanges() para confirmar as alterações no Banco de Dados</para>
        ///</summary>
        String Save(TEntity entity);

        #endregion

        #region DbContext

        ///<summary>
        ///<para>Utilizado para confirmar as alterações feitas no contexto</para>
        ///<para>Utilize para persistir as alterações no banco de dados</para>
        ///</summary>
        String SaveChanges();

        ///<summary>
        ///<para>Utilizado para obter a conexão que essa application possui com o banco de dados</para>
        ///<para>Útil se é necessário alterar objetos de contextos diferentes</para>
        ///<para>Deve ser utilizado em conjunto com o método SetContext</para>
        ///</summary>
        DbContext GetContext();

        ///<summary>
        ///<para>Utilizado para alterar a conexão que essa application possui com o banco de dados</para>
        ///<para>Útil se é necessário alterar objetos de contextos diferentes</para>
        ///<para>Deve ser utilizado em conjunto com o método SetContext</para>
        ///</summary>
        void SetContext(DbContext context);

        #endregion

        #region UpdateMethods

        ///<summary>
        ///<para>Responsável por alterar o estado do objeto passado como parâmetro para alterado</para>
        ///<para>Deverá-se utilizar o método SaveChanges() para confirmar as alterações no Banco de Dados</para>
        ///</summary>
        String Update(TEntity entity);

        #endregion

        #region DeleteMethods

        ///<summary>
        ///<para>Responsável por alterar o estado do objeto identificado pelo Id passado como parâmetro para Excluído</para>
        ///<para>Deverá-se utilizar o método SaveChanges() para confirmar as alterações no Banco de Dados</para>
        ///</summary>
        String Delete(Key id);

        ///<summary>
        ///<para>Responsável por alterar o estado do objeto passado como parâmetro para excluído</para>
        ///<para>Deverá-se utilizar o método SaveChanges() para confirmar as alterações no Banco de Dados</para>
        ///</summary>
        String Delete(TEntity entity);

        ///<summary>
        ///<para>Responsável por alterar o estado do objeto identificado através do predicado passado como parâmetro para excluído</para>
        ///<para>Deverá-se utilizar o método SaveChanges() para confirmar as alterações no Banco de Dados</para>
        ///</summary>
        String Delete(Func<TEntity, bool> predicate);

        ///<summary>
        ///<para>Responsável por alterar o estado dos objetos passados como parâmetro para excluídos</para>
        ///<para>Deverá-se utilizar o método SaveChanges() para confirmar as alterações no Banco de Dados</para>
        ///</summary>
        String DeleteAll(IEnumerable<TEntity> entities);

        #endregion

        #region ReadMethods

        ///<summary>
        ///<para>Responsável por retornar todos os registros do banco de dados</para>
        ///</summary>
        IEnumerable<TEntity> GetAll();

        ///<summary>
        ///<para>Retorna todos os registros do banco de dados com o [Include] para as classes passadas como parâmetro</para>
        ///</summary>
        IEnumerable<TEntity> GetAll(params string[] includes);

        ///<summary>
        ///<para>Responsável por retornar todos os registros do banco de dados</para>
        ///</summary>
        IQueryable<TEntity> getAllAsQueryAble();

        ///<summary>
        ///<para>Retorna todos os registros do banco de dados com o [Include] para as classes passadas como parâmetro</para>
        ///</summary>
        IQueryable<TEntity> getAllAsQueryAble(params string[] includes);

        ///<summary>
        ///<para>Retorna os registros do banco de dados que atendem ao predicado passado como parâmetro</para>
        ///<para>retorna os registros com o [Include] para as classes passadas como parâmetro</para>
        ///</summary>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where, params string[] includes);

        ///<summary>
        ///<para>Retorna os registros do banco de dados que atendem ao predicado passado como parâmetro</para>
        ///</summary>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where);

        ///<summary>
        ///<para>Retorna um registro a partir do Id passado como parâmetro</para>
        ///</summary>
        TEntity Single(Key id);

        #endregion

        #region Repository

        ///<summary>
        ///<para>Responsável por fechar o contexto da Application</para>
        ///</summary>
        void Dispose();

        #endregion
    }
}