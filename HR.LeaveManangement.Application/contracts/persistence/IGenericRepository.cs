using HR.LeaveManagement.Domain.common;

namespace HR.LeaveManangement.Application.contracts.persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAsync();
    Task<T?> GetByIdAsync(int id);
    Task CreateAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity); 

}
