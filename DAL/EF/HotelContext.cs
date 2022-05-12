using HotelManagement.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.DAL.EF
{
    public class HotelContext : IdentityDbContext<IdentityUser>
    {
        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options) { }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<StatusRoom> StatusRooms => Set<StatusRoom>();
        public DbSet<TypeOfRoom> TypeOfRooms => Set<TypeOfRoom>();
        public DbSet<TypeOfStatus> TypeOfStatuses => Set<TypeOfStatus>();
    }
}
