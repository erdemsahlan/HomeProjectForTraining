using AutoMapper;
using CoreLayer.DTOs;
using CoreLayer.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile() { 
        CreateMap<Employee,EmployeeDto>().ReverseMap();
        CreateMap<Department, DepartmentDto>().ReverseMap(); 
        }
    }
}
