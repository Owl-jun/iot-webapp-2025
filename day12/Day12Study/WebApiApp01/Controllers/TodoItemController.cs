using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiApp01.Models;

namespace WebApiApp01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController : ControllerBase
    {
        private readonly DbCtx _ctx;

        public TodoItemController(DbCtx ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> get()
        {
            var tempList = _ctx.TodoItems.ToList();
            return tempList;
        }
        [HttpGet("GetByTitle")]
        public async Task<ActionResult<List<TodoItem>>> gettitle([FromQuery] string title)
        {
            var tempList = _ctx.TodoItems.Where(t=>t.Title.ToLower().Contains(title.ToLower())).ToList();
            return tempList;
        }

        [HttpPost]
        public async Task<IActionResult> post(TodoItem input)
        {
            _ctx.TodoItems.Add(input);
            await _ctx.SaveChangesAsync();
            return Ok("데이터 입력 완료");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TodoItem item)
        {
            if (item == null || item.Id == 0)
                return BadRequest("유효하지 않은 요청입니다.");

            var existingItem = await _ctx.TodoItems.FindAsync(item.Id);
            if (existingItem == null)
                return NotFound($"ID {item.Id}에 해당하는 항목을 찾을 수 없습니다.");

            existingItem.Title = item.Title;
            existingItem.TodoDate = item.TodoDate;
            existingItem.IsComplete = item.IsComplete;

            await _ctx.SaveChangesAsync();

            return Ok(existingItem);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (id <= 0)
                return BadRequest("유효하지 않은 ID입니다.");

            var deletedCount = await _ctx.TodoItems
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();

            if (deletedCount == 0)
                return NotFound("삭제할 항목이 없습니다.");

            return Ok("삭제완료");
        }
    }
}
