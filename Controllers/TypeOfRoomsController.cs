#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelManagement.DAL.EF;
using HotelManagement.DAL.Entities;
using HotelManagement.DAL.IRepositories;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfRoomsController : ControllerBase
    {
        private readonly IGenericRepository<TypeOfRoom> _repository;

        public TypeOfRoomsController(IGenericRepository<TypeOfRoom> repository)
        {
            _repository = repository;
        }

        // GET: api/TypeOfRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfRoom>>> GetTypeOfRooms()
        {
            return await _repository.GetListAsync();
        }

        // GET: api/TypeOfRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfRoom>> GetTypeOfRoom(int id)
        {
            var typeOfRoom = await _repository.GetByIdOrNullAsync(id);

            if (typeOfRoom == null)
            {
                typeOfRoom = new TypeOfRoom();
            }

            return typeOfRoom;
        }

        // PUT: api/TypeOfRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeOfRoom(int id, TypeOfRoom item)
        {
            if (id != item.Id)
            {
                return new JsonResult("Id неверен");
            }

            try
            {
                await _repository.UpdateAsync(item);

                return new JsonResult($"Запись успешна обновлена");
            }
            catch (DbUpdateConcurrencyException)
            {
                return new JsonResult("Ошибка при обновлении записи");
            }
        }

        // POST: api/TypeOfRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeOfRoom>> PostTypeOfRoom(TypeOfRoom item)
        {
            try
            {
                await _repository.CreateAsync(item);

                return new JsonResult($"Запись создана под id = { item.Id }");
            }
            catch
            {
                return new JsonResult("Ошибка при создании записи");
            }
        }

        // DELETE: api/TypeOfRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeOfRoom(int id)
        {
            if (await _repository.DeleteAsync(id))
            {
                return new JsonResult("Запись успешна удалена");
            }
            else
            {
                return new JsonResult("Ошибка при удалении записи");
            }
        }
    }
}
