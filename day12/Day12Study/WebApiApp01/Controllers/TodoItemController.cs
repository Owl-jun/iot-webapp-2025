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
            return Ok("������ �Է� �Ϸ�");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TodoItem item)
        {
            if (item == null || item.Id == 0)
                return BadRequest("��ȿ���� ���� ��û�Դϴ�.");

            var existingItem = await _ctx.TodoItems.FindAsync(item.Id);
            if (existingItem == null)
                return NotFound($"ID {item.Id}�� �ش��ϴ� �׸��� ã�� �� �����ϴ�.");

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
                return BadRequest("��ȿ���� ���� ID�Դϴ�.");

            var deletedCount = await _ctx.TodoItems
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();

            if (deletedCount == 0)
                return NotFound("������ �׸��� �����ϴ�.");

            return Ok("�����Ϸ�");
        }
    }
}
