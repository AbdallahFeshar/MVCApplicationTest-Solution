using AutoMapper;
using MVCApplicationTest.DAL.Models;
using MVCApplicationTestPL.ViewModels;

namespace MVCApplicationTestPL.MapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap <EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
