namespace TechSol.StudentManagementSystem.DAL
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        public virtual Task<T> Get<T>(object id)
        {
            return BaseRepository.Get<T>(id);
        }



        //public virtual T Get(object id)
        //{
        //    return BaseRepository.Get<T>(id).Result;
        //}

        //Cann't convert into task.
        public virtual T GetFirstOrDefault(object whereConditions)
        {
            return BaseRepository.GetList<T>(whereConditions).Result?.FirstOrDefault();
        }
        public virtual Task<IEnumerable<T>> GetList(bool includeActive = true)
        {
            return BaseRepository.GetList<T>(includeActive);
        }
        //Add GetListMethode
        public virtual Task<IEnumerable<T>> GetList<T>(object whereConditions)
        {
            return BaseRepository.GetList<T>(whereConditions, includeActive: false);
        }

        //GetListUsingSp
        public virtual Task<IEnumerable<T>> GetListUsingSP<T>(string procedureName, object paramters)
        {
            return BaseRepository.GetListUsingSP<T>(procedureName, paramters);
        }

        public virtual Task<IEnumerable<T>> GetList(object whereConditions)
        {
            return BaseRepository.GetList<T>(whereConditions);
        }
        public virtual Task<IEnumerable<T>> GetList<T>(string conditions, object parameters = null)
        {
            return BaseRepository.GetList<T>(conditions, parameters);
        }
        public virtual Task<IEnumerable<T>> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby, object parameters = null)
        {
            return BaseRepository.GetListPaged<T>(pageNumber, rowsPerPage, conditions, orderby, parameters);
        }
        public virtual Task<IEnumerable<T>> GetListPaged(int pageNumber, int rowsPerPage, Dictionary<string, object> conditions, string orderby, string[] parameters = null)
        {
            return BaseRepository.GetListPaged<T>(pageNumber, rowsPerPage, conditions, orderby, parameters);
        }
        public virtual Task<int> Insert<TEntity>(TEntity entityToInsert)
        {
            return BaseRepository.Insert<TEntity>(entityToInsert);
        }
        public virtual Task<TKey> Insert<TKey, TEntity>(TEntity entityToInsert)
        {
            return BaseRepository.Insert<TKey, TEntity>(entityToInsert);
        }
        //void InsertBulk<TEntity>(IEnumerable<TEntity> entitiesToInsert);
        public virtual Task<int> Update<TEntity>(TEntity entityToUpdate)
        {
            return BaseRepository.Update<TEntity>(entityToUpdate);
        }
        public virtual Task<int> Delete(T entityToDelete)
        {
            return BaseRepository.Delete<T>(entityToDelete);
        }
        public virtual Task<int> Delete(object id)
        {
            return BaseRepository.Delete<T>(id);
        }
        public virtual Task<int> DeleteList(object whereConditions)
        {
            return BaseRepository.DeleteList<T>(whereConditions);
        }
        public virtual Task<int> DeleteList(string conditions, object parameters = null)
        {
            return BaseRepository.DeleteList<T>(conditions, parameters);
        }
        public virtual Task<int> RecordCount(string conditions = "", object parameters = null)
        {
            return BaseRepository.RecordCount<T>(conditions, parameters);
        }
        public virtual Task<int> RecordCount(object whereConditions)
        {
            return BaseRepository.RecordCount<T>(whereConditions);
        }
        public virtual Task<int> RecordCount(Dictionary<string, object> conditions, string[] parameters = null)
        {
            return BaseRepository.RecordCount<T>(conditions, parameters);
        }
        
        //
        public virtual Task<T> CustomQuery<T>(string query)
        {
            return BaseRepository.CustomQuery<T>(query);
        }

        public virtual Task<T> CustomQuery<T>(string query, object param)
        {
            return BaseRepository.CustomQuery<T>(query, param);
        }

        public virtual Task<object> ScalarQuery(string query)
        {
            return BaseRepository.ScalarQuery(query);
        }
        //
        public virtual Task<IEnumerable<T>> GetList<T>()
        {
            return BaseRepository.GetList<T>();
        }
        //
        public virtual Task<IEnumerable<T>> CustomQueryList<T>(string query,object param)
        {
            return BaseRepository.CustomQueryList<T>(query, param);
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ApplicationConfigRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        public Task<IEnumerable<T>> CustomQueryList<T>(string query)
        {
            return BaseRepository.CustomQueryList<T>(query);
        }





        #endregion
    }
}
