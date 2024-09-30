using Microsoft.AspNetCore.Mvc;
using NotificationProgect.Models;
using NotificationProgect.Services;
using System.Diagnostics;

namespace NotificationProgect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoService _service;

        public HomeController(ILogger<HomeController> logger, ToDoService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("save")]
        public async Task SaveAsync(ToDoModel model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await _service.SaveChangesAsync(model);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetToDoByIdAsync(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            var result = await _service.GetToDoByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("date")]
        public async Task<IActionResult> GetToDoByDateAsync(DateTime[] date)
        {
            if (date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }

            var result = await _service.GetToDoByDateAsync(date);
            if (result == null)
            {
                throw new ArgumentNullException(nameof(date));
            }
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task DeleteToDoAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException(nameof(id));
            }

            await _service.DeleteToDoAsync(id);
        }

        [HttpGet("getToDoAll")]
        public async Task<IActionResult> GetToDoAll()
        {
            var result = await _service.GetToDoAllAsync();
            return View("ListNotifications",result);
        }
    }
}
