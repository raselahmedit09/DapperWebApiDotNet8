using AutoMapper;
using DapperAPI.DTOs;
using DapperAPI.Entiities;

namespace DapperAPI.Extensions
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            //----------------------------- Database to Domain -------------------------
            CreateMap<Employee,EmployeeDto>();

            //----------------------------- Domain to Database -------------------------
            CreateMap<EmployeeDto, Employee>();

        }
    }
}
