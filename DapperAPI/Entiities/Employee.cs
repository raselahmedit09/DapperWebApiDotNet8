using Dapper.Contrib.Extensions;

namespace DapperAPI.Entiities
{
    [Dapper.Contrib.Extensions.Table("Employees")] // use for dapper contrib
    public class Employee
    {
        /*  [Key] Used to treat as primary key. 
            If Primary is Not named 'Id' then we will use this
        [Key] - this property represents a database-generated identity/key
        */
        //[Key] //Dapper.Contrib.Extensions
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
    }
}
