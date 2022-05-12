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
    public class TypeOfStatusController : ControllerBase
    {
        private readonly IGenericRepository<TypeOfStatus> _repository;

        public TypeOfStatusController(IGenericRepository<TypeOfStatus> repository)
        {
            _repository = repository;
        }

        // GET: api/TypeOfStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfStatus>>> GetTypeOfStatuses()
        {
            return await _repository.GetListAsync();
        }

        // GET: api/TypeOfStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfStatus>> GetTypeOfStatus(int id)
        {
            var typeOfStatus = await _repository.GetByIdOrNullAsync(id);

            if (typeOfStatus == null)
            {
                typeOfStatus = new TypeOfStatus();
            }

            return typeOfStatus;
        }

        // PUT: api/TypeOfStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeOfStatus(int id, TypeOfStatus item)
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

        // POST: api/TypeOfStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeOfStatus>> PostTypeOfStatus(TypeOfStatus item)
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

        // DELETE: api/TypeOfStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeOfStatus(int id)
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
