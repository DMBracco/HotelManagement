using HotelManagement.BLL.IServices;
using HotelManagement.DAL.EF;
using HotelManagement.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.BLL.Services
{
    public class StatusRoomService : IStatusRoomService
    {
        private readonly HotelContext _context;

        public StatusRoomService(HotelContext context)
        {
            _context = context;
        }

        public async Task<List<StatusRoomViewModel>> StatusRoomsAsync()
        {
            var statusRooms = await _context.StatusRooms
                .Include(x => x.Room)
                .Include(x => x.Client)
                .Include(x => x.TypeOfStatus)
                .ToListAsync();

            var statusRoomsView = new List<StatusRoomViewModel>();
            var todayDate = DateTime.Now;

            foreach (var r in statusRooms)
            {
                var Occupied = false;
                if(r.Start <= todayDate && r.End >= todayDate)
                    Occupied = true;

                statusRoomsView.Add(new StatusRoomViewModel
                {
                    Id = r.Id,
                    RoomId = r.RoomId,
                    RoomNumber = r.Room?.Number,
                    ClientId = r.ClientId,
                    ClientFullName = r.Client?.FullName,
                    TypeOfStatusId = r.TypeOfStatusId,
                    TypeName = r.TypeOfStatus?.Name,
                    DateCreate = r.DateCreate,
                    DateStart = r.Start,
                    DateEnd = r.End,
                    Occupied = Occupied
                });
            }

            return statusRoomsView;
        }
    }
}
