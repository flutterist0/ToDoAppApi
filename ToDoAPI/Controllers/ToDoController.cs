using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController(IToDoService toDoService) : ControllerBase
    {
        private readonly IToDoService _toDoService = toDoService;
        [HttpPost("addToDo")]
        public IActionResult Add(ToDoAddDto toDoAddDto)
        {
            var result = _toDoService.Add(toDoAddDto);
            if (result.Success)
            {
                return Ok(result);
            }else
                return BadRequest(result);
        }

        [HttpGet("getAllByUserId: {userId:int:min(1)}")]
        public IActionResult GetAllByUserId(int userId)
        {
            var result = _toDoService.GetAllByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }else
                return BadRequest(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _toDoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }else
                return BadRequest(result);
        }

        [HttpGet("getToDo")]
        public IActionResult Get(int userId,int toDoId)
        {
            var result = _toDoService.Get(userId, toDoId);
            if (result.Success)
            {
                return Ok(result);
            }else
                return BadRequest(result);
        }

        [HttpDelete("deleteToDo")]
        public IActionResult Delete(int userId, int toDoId)
        {
            var result = _toDoService.Delete(userId, toDoId);
            if (result.Success)
            {
                return Ok(result);
            }else
                return BadRequest(result);

        }
        [HttpPut]
        public IActionResult ComplateTask(int userId, int toDoId, bool isComplated)
        {
            var result = _toDoService.CompleteTask(userId, toDoId, isComplated);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

        [HttpGet("getAllByIsComplated: {userId:int:min(1)}")]
        public IActionResult GetAllByIsComplated(int userId)
        {
            var result = _toDoService.GetAllByIsComplated(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

        [HttpPut("updateToDo  {userId:int:min(1)}")]
        public IActionResult Update(int userId, ToDoUpdateDto toDoUpdateDto, int toDoId)
        {
            var result = _toDoService.Update(userId, toDoUpdateDto,toDoId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
    }
}
