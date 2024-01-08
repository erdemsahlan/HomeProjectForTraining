using AutoMapper;
using CoreLayer.DTOs;
using CoreLayer.Modals;
using CoreLayer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Mapping;

namespace AppApi.Controllers
{
    public class EmployeesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Employee> _service;

        public EmployeesController(IMapper mapper, IService<Employee> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var employees=await _service.GetAllAsync();
            var employeesDtos = _mapper.Map<List<EmployeeDto>>(employees).ToList();
            return CreateActionResult(CustomResponseDto<List<EmployeeDto>>.Success(200, employeesDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            var employeesDtos = _mapper.Map<EmployeeDto>(employee);
            return CreateActionResult(CustomResponseDto<EmployeeDto>.Success(200, employeesDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(EmployeeDto employeeDto)
        {
            var employee = await _service.AddAsync(_mapper.Map<Employee>(employeeDto));
            var employeesDtos = _mapper.Map<EmployeeDto>(employee);
            return CreateActionResult(CustomResponseDto<EmployeeDto>.Success(201, employeesDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeDto employeeDto)
        {
             await _service.UpdateAsync(_mapper.Map<Employee>(employeeDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee= await _service.GetByIdAsync(id);
            if (employee == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404,"Bu id'ye sahip çalışan bulunamadı"));
            }
            await _service.RemoveAsync(employee);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
