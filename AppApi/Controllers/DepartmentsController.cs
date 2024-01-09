using AutoMapper;
using CoreLayer.DTOs;
using CoreLayer.Modals;
using CoreLayer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Mapping;

namespace AppApi.Controllers
{
    public class DepartmentsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Department> _service;

        public DepartmentsController(IMapper mapper, IService<Department> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var department = await _service.GetAllAsync();
            var departmentDtos = _mapper.Map<List<DepartmentDto>>(department).ToList();
            return CreateActionResult(CustomResponseDto<List<DepartmentDto>>.Success(200, departmentDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _service.GetByIdAsync(id);
            var departmentsDtos = _mapper.Map<DepartmentDto>(department);
            return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(200, departmentsDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(DepartmentDto departmentDto)
        {
            var department = await _service.AddAsync(_mapper.Map<Department>(departmentDto));
            var departmentsDtos = _mapper.Map<DepartmentDto>(department);
            return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(201, departmentsDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(DepartmentDto departmentDto)
        {
            await _service.UpdateAsync(_mapper.Map<Department>(departmentDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _service.GetByIdAsync(id);
            if (department == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Bu id'ye sahip departman bulunamadı"));
            }
            await _service.RemoveAsync(department);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
