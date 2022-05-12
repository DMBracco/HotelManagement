using HotelManagement.DAL.Entities;

namespace HotelManagement.ViewModel
{
    public class StatusRoomViewModel
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        public int? RoomNumber { get; set; }

        public int ClientId { get; set; }
        public string? ClientFullName { get; set; }

        public int TypeOfStatusId { get; set; }
        public string? TypeName { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public bool Occupied { get; set; }
    }
}
