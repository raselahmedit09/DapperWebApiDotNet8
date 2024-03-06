using AutoMapper;
using DapperAPI.DTOs;
using DapperAPI.Entiities;
using DapperAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DapperAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(
            ILogger<EmployeeController> logger,
            IMapper mapper,
            IEmployeeRepository employeeRepository
            )
        {
            _logger = logger;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }


        [HttpPost("Create")]
        public async Task<ActionResult<EmployeeDto>> Create(EmployeeDto model)
        {
            var employee = await _employeeRepository.Create(_mapper.Map<Employee>(model));
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<EmployeeDto>> Update(EmployeeDto model)
        {
            var employee = await _employeeRepository.Update(_mapper.Map<Employee>(model));
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpGet("DeleteById")]
        public async Task<ActionResult> DeleteById(int id)
        {
            await _employeeRepository.DeleteById(id);
            return Ok(true);
        }

        [HttpGet("GetEmployeeById")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IList<EmployeeDto>>> GetAll()
        {
            var employee = await _employeeRepository.GetAll();
            IList<EmployeeDto> employeeList = _mapper.Map<IEnumerable<EmployeeDto>>(employee).ToList();
            return Ok(employeeList);
        }


        // ---------------------------- Stored Procedure --------------------- 
        [HttpPost("CreateSP")]
        public async Task<ActionResult<EmployeeDto>> CreateSP(EmployeeDto model)
        {
            var employee = await _employeeRepository.CreateSP(_mapper.Map<Employee>(model));
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpPost("UpdateSP")]
        public async Task<ActionResult<EmployeeDto>> UpdateSP(EmployeeDto model)
        {
            var employee = await _employeeRepository.UpdateSP(_mapper.Map<Employee>(model));
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpGet("DeleteByIdSP")]
        public async Task<ActionResult<bool>> DeleteByIdSP(int id)
        {
            await _employeeRepository.DeleteByIdSP(id);
            return Ok(true);
        }

        [HttpGet("GetEmployeeByIdSP")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeByIdSP(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdSP(id);
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpGet("GetAllSP")]
        public async Task<ActionResult<IList<EmployeeDto>>> GetAllSP()
        {
            var employee = await _employeeRepository.GetAllSP();
            IList<EmployeeDto> employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employee).ToList();
            return Ok(employeeDto);
        }


        //------------------ Dapper Contrib --------------- 

        [HttpPost("CreateContrib")]
        public async Task<ActionResult<EmployeeDto>> CreateContrib(EmployeeDto model)
        {
            var employee = await _employeeRepository.CreateContrib(_mapper.Map<Employee>(model));
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpPost("UpdateContrib")]
        public async Task<ActionResult<EmployeeDto>> UpdateContrib(EmployeeDto model)
        {
            var employee = await _employeeRepository.UpdateContrib(_mapper.Map<Employee>(model));
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpGet("DeleteByIdContrib")]
        public async Task<ActionResult<bool>> DeleteByIdContrib(int id)
        {
            await _employeeRepository.DeleteByIdContrib(id);
            return Ok(true);
        }

        [HttpGet("GetEmployeeByIdContrib")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeByIdContrib(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdContrib(id);
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpGet("GetAllContrib")]
        public async Task<ActionResult<IList<EmployeeDto>>> GetAllContrib()
        {
            var employee = await _employeeRepository.GetAllContrib();
            IList<EmployeeDto> employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employee).ToList();
            return Ok(employeeDto);
        }
    }
}
