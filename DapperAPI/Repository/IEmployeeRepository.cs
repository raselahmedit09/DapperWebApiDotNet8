using DapperAPI.Entiities;

namespace DapperAPI.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> Create(Employee employee);
        Task<Employee> Update(Employee employee);
        Task DeleteById(int id);
        Task<IEnumerable<Employee>> GetAll();

        // using Stored Procedure 
        Task<Employee> GetEmployeeByIdSP(int id);
        Task<Employee> CreateSP(Employee employee);
        Task<Employee> UpdateSP(Employee employee);
        Task DeleteByIdSP(int id);
        Task<IEnumerable<Employee>> GetAllSP();

        // dapper contrib
        Task<Employee> GetEmployeeByIdContrib(int id);
        Task<Employee> CreateContrib(Employee employee);
        Task<Employee> UpdateContrib(Employee employee);
        Task DeleteByIdContrib(int id);
        Task<IEnumerable<Employee>> GetAllContrib();

    }
}
