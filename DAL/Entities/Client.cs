namespace HotelManagement.DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public long Phone { get; set; }

        public string? PassportDetail { get; set; }

        public string? Comments { get; set; }
    }
}
