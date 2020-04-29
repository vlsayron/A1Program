using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcMusicStore.Infrastructure;
using MvcMusicStore.Models;
using NLog;
using PerformanceCounterHelper;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MusicStoreEntities _storeContext = new MusicStoreEntities();

        private readonly ILogger _logger;
        static CounterHelper<Counters> _counterHelper;

        public HomeController(ILogger logger)
        {
            _logger = logger;
            _counterHelper = PerformanceHelper.CreateCounterHelper<Counters>("Enter Home counter instance");
        }

        // GET: /Home/
        public async Task<ActionResult> Index()
        {
            _counterHelper.Increment(Counters.GoToHome);
            _logger.Info("Load home page");
            _logger.Debug($"Load home page. User agent info: {HttpContext.Request.UserAgent}");

            return View(await _storeContext.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(6)
                .ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _storeContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}