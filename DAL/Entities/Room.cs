namespace HotelManagement.DAL.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int Floor { get; set; }

        public int Capacity { get; set; }

        public float Price { get; set; }

        public int TypeOfRoomId { get; set; }
        public TypeOfRoom? TypeOfRoom { get; set; }
    }
}
