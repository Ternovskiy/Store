using System.Collections.Generic;
using DataModul.BaseRepository;
using DataModul.Repository;

namespace DataModul.IRepository
{
    public interface IRepository<T>:IBaseContextRepository
        where T : class 
    {
        IBaseQuery<T> BaseQuery { get; set; }
        IEnumerable<T> GetAll(); 
        T GetById(object id); 
        bool Save(T item);  
        bool Delete(object id);
        
    }
    
}