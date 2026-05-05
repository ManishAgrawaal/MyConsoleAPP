using Microsoft.AspNetCore.Mvc;
using MyConsoleApp.Models;
using MyConsoleApp.Services;

namespace MyConsoleApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineController : ControllerBase
    {
        private readonly MedicineService _service;

        public MedicineController(MedicineService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Add(Medicine medicine)
        {
            _service.Add(medicine);
            return Ok();
        }
    }
}