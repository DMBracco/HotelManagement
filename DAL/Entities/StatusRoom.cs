namespace HotelManagement.DAL.Entities
{
    public class StatusRoom
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        public Room? Room { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public int TypeOfStatusId { get; set; }
        public TypeOfStatus? TypeOfStatus { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
