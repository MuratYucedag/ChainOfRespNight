using ChainOfRespNight.ChainofRespPattern;
using ChainOfRespNight.DAL;
using ChainOfRespNight.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfRespNight.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;
        public DefaultController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerViewModel customerViewModel)
        {
            Employee treasurer = new Treasurer(_context);
            Employee managerAssistant = new ManagerAssistant(_context);
            Employee manager = new Manager(_context);
            Employee areaDirector = new AreaDirector(_context);

            treasurer.SetNextApprover(managerAssistant);
            managerAssistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirector);

            treasurer.ProcessRequest(customerViewModel);

            return View();
        }
    }
}
