using HotelManagement.DAL.EF;
using HotelManagement.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            HotelContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<HotelContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Clients.Any())
            {
                context.Clients.AddRange(
                    new Client { FullName="Антонов Дмитрий", PassportDetail="1236546", Phone=89373454355, Comments="обычный комментарий" },
                    new Client { FullName = "Петров Дмитрий", PassportDetail = "1235345436546", Phone = 89473454355, Comments = "обычный комментарий1" },
                    new Client { FullName = "Быкова Ангелина", PassportDetail = "12364354546", Phone = 89373455655, Comments = "обычный комментарий2" }
                );
                context.SaveChanges();
            }

            if (!context.TypeOfRooms.Any())
            {
                context.TypeOfRooms.AddRange(
                    new TypeOfRoom { Title="обычный", Description="простой" },
                    new TypeOfRoom { Title = "люкс", Description = "лучший" }
                );
                context.SaveChanges();
            }

            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(
                    new Room { Number=1, Capacity=2, Floor=1, Price=10000, TypeOfRoomId=1 },
                    new Room { Number = 3, Capacity = 4, Floor = 2, Price = 100000, TypeOfRoomId = 2 }
                );
                context.SaveChanges();
            }

            if (!context.TypeOfStatuses.Any())
            {
                context.TypeOfStatuses.AddRange(
                    new TypeOfStatus { Name="бронь" },
                    new TypeOfStatus { Name="заселен"}
                );
                context.SaveChanges();
            }

            if (!context.StatusRooms.Any())
            {
                context.StatusRooms.AddRange(
                    new StatusRoom { ClientId=1, DateCreate=DateTime.Now, RoomId=1, TypeOfStatusId=1, Start= DateTime.Now.AddDays(19), End = DateTime.Now.AddDays(29) }
                );
                context.SaveChanges();
            }
        }
    }
}
