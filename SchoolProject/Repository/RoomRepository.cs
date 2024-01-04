using DemoEFApp.Context;
using DemoEFApp.Models;

namespace SchoolProject.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyContext _myContext;
        public RoomRepository(MyContext myContext)
        {
            _myContext = myContext;
        }
        public List<Room> GetAllRooms()
        {
            List<Room> rooms = (from roomObj in _myContext.Rooms
                                      select roomObj).ToList();
            return rooms;
        }
        public void Create(Room room)
        {
            _myContext.Rooms?.Add(room);
            _myContext.SaveChanges();
        }
        public void Delete(int id)
        {  
            Room roomToDelete = _myContext.Rooms.Find(id);

            if (roomToDelete != null)
            {      
                _myContext.Rooms.Remove(roomToDelete); 
                _myContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException($"Room with id {id} not found.");
            }
        }

    }
}
