#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelManagement.DAL.Entities;
using HotelManagement.BLL.IServices;
using HotelManagement.ViewModel;
using HotelManagement.DAL.IRepositories;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusRoomsController : ControllerBase
    {
        private readonly IStatusRoomService _service;
        private readonly IGenericRepository<StatusRoom> _repository;

        public StatusRoomsController(IStatusRoomService service, IGenericRepository<StatusRoom> repository)
        {
            _service = service;
            _repository = repository;
        }

        // GET: api/StatusRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusRoomViewModel>>> GetStatusRooms()
        {
            return await _service.StatusRoomsAsync();
        }

        // GET: api/StatusRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusRoom>> GetStatusRoom(int id)
        {
            var statusRoom = await _repository.GetByIdOrNullAsync(id);

            if (statusRoom == null)
            {
                statusRoom = new StatusRoom();
            }

            return statusRoom;
        }

        // PUT: api/StatusRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusRoom(int id, StatusRoom item)
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

        // POST: api/StatusRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusRoom>> PostStatusRoom(StatusRoom item)
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

        // DELETE: api/StatusRooms/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteStatusRoom(int id)
        //{
        //    if (await _repository.DeleteAsync(id))
        //    {
        //        return new JsonResult("Запись успешна удалена");
        //    }
        //    else
        //    {
        //        return new JsonResult("Ошибка при удалении записи");
        //    }
        //}
    }
}
