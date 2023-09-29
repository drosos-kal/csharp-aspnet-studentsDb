using AutoMapper;
using StudentsDbApp.DTO;
using StudentsDbApp.Models;

namespace StudentsDbApp.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<StudentInsertDTO, Student>().ReverseMap();
            CreateMap<StudentUpdateDTO, Student>().ReverseMap();
            CreateMap<StudentReadOnlyDTO, Student>().ReverseMap();

        }
    }
}
