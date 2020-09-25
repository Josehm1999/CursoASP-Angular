using Dapper;
using Models;
using Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<CustomerList> CustomerPagedList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<CustomerList>("dbo.CustomerPagedList", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
