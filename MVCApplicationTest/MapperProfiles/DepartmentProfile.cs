using AutoMapper;
using MVCApplicationTest.DAL.Models;
using MVCApplicationTestPL.ViewModels;

namespace MVCApplicationTestPL.MapperProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentViewModel, Department>().ReverseMap();
        }
    }
}
