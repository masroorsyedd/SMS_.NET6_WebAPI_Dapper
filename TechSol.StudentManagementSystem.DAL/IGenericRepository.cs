namespace TechSol.StudentManagementSystem.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get<T>(object id);
        //T Get(object id); 
        Task<IEnumerable<T>> GetList(bool inculdeActive = true);
        Task<IEnumerable<T>> GetList(object whereConditions);
        //
        Task<IEnumerable<T>> GetList<T>(object whereConditions);
        //GetListUsingSp
        Task<IEnumerable<T>> GetListUsingSP<T>(string procedureName, object paramters);
        //
        Task<IEnumerable<T>> GetList<T>(string conditions, object parameters = null);
        Task<IEnumerable<T>> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby, object parameters = null);
        Task<IEnumerable<T>> GetListPaged(int pageNumber, int rowsPerPage, Dictionary<string,object> conditions, string orderby, string[] parameters = null);
        Task<int> Insert<TEntity>(TEntity entityToInsert);
        Task<TKey> Insert<TKey, TEntity>(TEntity entityToInsert);
        //void InsertBulk<TEntity>(IEnumerable<TEntity> entitiesToInsert);
        Task<int> Update<TEntity>(TEntity entityToUpdate);
        Task<int> Delete(T entityToDelete);
        Task<int> Delete(object id);
        Task<int> DeleteList(object whereConditions);
        Task<int> DeleteList(string conditions, object parameters = null);
        Task<int> RecordCount(string conditions = "", object parameters = null);
        Task<int> RecordCount(object whereConditions);
        Task<int> RecordCount(Dictionary<string, object> conditions, string[] parameters = null);

        Task<IEnumerable<T>> CustomQueryList<T>(string query);
        Task<T> CustomQuery<T>(string query);
        Task<T> CustomQuery<T>(string query, object param);
        Task<object> ScalarQuery(string query);
        //IEnumerable<T> GetList<T>(object whereConditions)

        Task<IEnumerable<T>> GetList<T>();
        Task<IEnumerable<T>> CustomQueryList<T>(string query, object param);


    }
}
