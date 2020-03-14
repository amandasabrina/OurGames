using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OurGames.Common.Logging;
using OurGames.Core.Model.Model;
using OurGames.Repository;

namespace OurGames.UI.Controllers
{
    [Route("api/[controller]")]
    public class LibraryController : Controller
    {
        private readonly OrderRepository _orderRepo;

        public LibraryController(DbContextOptions<OurGamesContext> dbContextOptions)
        {
            _orderRepo = new OrderRepository(dbContextOptions);
        }

        [HttpGet("[action]")]
        public JsonResult GetUserOrders()
        {
            try
            {
                //TODO: get current user id

                //TEMP
                var currentUserId = 10;

                var orders = _orderRepo.GetBy(o => o.CustomerId == currentUserId);

                return Json(new { orders, success = true });
            }
            catch (Exception ex)
            {
                Log.Error("Error while getting user orders.", ex);

                return Json(new { message = "Desculpe, não foi possível carregar essa página.", success = false });
            }
        }
    }
}