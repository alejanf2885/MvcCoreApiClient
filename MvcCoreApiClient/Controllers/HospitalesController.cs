using Microsoft.AspNetCore.Mvc;
using MvcCoreApiClient.Models;
using MvcCoreApiClient.Services;
using System.Threading.Tasks;

namespace MvcCoreApiClient.Controllers
{
    public class HospitalesController : Controller
    {

        private ServiceHospitales hospitalService;

        public HospitalesController(ServiceHospitales serviceHospitales)
        {
            this.hospitalService = serviceHospitales;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cliente()
        {

            return View();

        }

        public async Task<IActionResult> Servidor()
        {
            List<Hospital> hospitales = await this.hospitalService.GetHospitalsAsync();
            return View(hospitales);
        }

        public async Task<IActionResult> Details(int id)
        {
            Hospital hospital = await this.hospitalService.FindHospitalAsync(id);
            return View(hospital);
        }
    }
}

