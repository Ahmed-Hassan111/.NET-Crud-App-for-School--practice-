using DemoEFApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Repository;
using SchoolProject.Respository;

namespace SchoolProject.Controllers
{
    //[Authorize]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View(rooms);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Room room)
        {
            if (room != null)
            {
                _roomRepository.Create(room);
            }
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View("Index",rooms);
        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _roomRepository.Delete(id);
            }
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View("Index", rooms);
        }
    }
}
