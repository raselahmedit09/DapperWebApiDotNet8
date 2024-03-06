using Dapper;
using Dapper.Contrib.Extensions;
using DapperAPI.Data;
using DapperAPI.Entiities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Data;

namespace DapperAPI.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(Employee employee)
        {
            var query = "INSERT INTO Employees (Name,Age,Position)" +
                "VALUES(@Name,@Age,@Position)" +
                "SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = _context.CreateConnection())
            {
                employee.Id = await connection.ExecuteScalarAsync<int>(query, employee );
                return employee;
            }
        }

        public async Task<Employee> Update(Employee employee)
        {
            var query = "UPDATE Employees " +
                "SET Name =@Name,Age =@Age ,Position =@Position " +
                "WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, employee);
                return employee;
            }
        }

        public async Task DeleteById(int id)
        {
            var query = "DELETE FROM Employees WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var query = "SELECT * FROM Employees";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Employee>(query);
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var query = "SELECT * FROM Employees WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Employee>(query, new { id });
                return company;
            }
        }

        public async Task<Employee> CreateSP(Employee employee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@Name", employee.Name);
            parameters.Add("@Age", employee.Age, DbType.Int32);
            parameters.Add("@Position", employee.Position);

            using (var connection = _context.CreateConnection())
            {
                 await connection.ExecuteAsync("usp_AddCompany", parameters, commandType: CommandType.StoredProcedure);
                employee.Id = parameters.Get<int>("Id");
                return employee;
            }  
        }

        public async Task<Employee> UpdateSP(Employee employee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", employee.Id, DbType.Int32);
            parameters.Add("@Name", employee.Name);
            parameters.Add("@Age", employee.Age, DbType.Int32);
            parameters.Add("@Position", employee.Position);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync("usp_UpdateCompany", parameters, commandType: CommandType.StoredProcedure);
                return employee;
            } 
        }

        public async Task DeleteByIdSP(int id)
        {
            var query = "usp_DeleteEmployees";

            using (var connection = _context.CreateConnection())
            {
                 await connection.ExecuteAsync(query,new { Id = id}, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Employee>> GetAllSP()
        {
            var query = "usp_GetEmployees";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Employee>(query);
            }
        }

        public async Task<Employee> GetEmployeeByIdSP(int id)
        {
            var query = "usp_GetEmployeeById";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Employee>(query, new { EmployeeId = id });
            }
        }


        public async Task<Employee> GetEmployeeByIdContrib(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.GetAsync<Employee>(id);
            }
        }

        public async Task<Employee> CreateContrib(Employee employee)
        {
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.InsertAsync(employee);
                employee.Id = (int)id;
                return employee;
            }
        }

        public async Task<Employee> UpdateContrib(Employee employee)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.UpdateAsync(employee);
                return employee;
            }
        }

        public async Task DeleteByIdContrib(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.DeleteAsync(new Employee { Id = id });
            }
        }

        public async Task<IEnumerable<Employee>> GetAllContrib()
        {
            using (var connection = _context.CreateConnection())
            {
               return await connection.GetAllAsync<Employee>();
            }
        }
    }
}
