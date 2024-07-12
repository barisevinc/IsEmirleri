using IsEmirleri.Business.Abstract;
using IsEmirleri.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsEmirleri.Web.Controllers
{
    [Authorize (Roles="Superadmin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {

            return Json(new { data = _customerService.GetAllWithUserCount() });
        }
        public IActionResult GetById(int id)
        {
            return Ok(_customerService.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            return Ok(_customerService.Delete(id));
        }

        [HttpPost]
        public IActionResult Add(Customer Customer)
        {

            return Ok(_customerService.Add(Customer));
        }

        [HttpPost]
        public IActionResult Update(Customer Customer)
        {

            return Ok(_customerService.Update(Customer));

        }
    }
}
