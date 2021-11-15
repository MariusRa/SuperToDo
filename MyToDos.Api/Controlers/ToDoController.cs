using Microsoft.AspNetCore.Mvc;
using MyToDo.Services;
using MyToDos.Api.viewModels;
using SuperTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDos.Api.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;
        public ToDoController(IToDoService toDoService)
        {
            _service = toDoService;
        }

        [HttpGet]
        public IEnumerable<ToDo> Get([FromQuery] ToDoParameters toDoParameters)
        {
          return _service.GetAll(toDoParameters);
        }

       [HttpGet]
       [Route("GetActive")]

       public IEnumerable<ToDo> GetActive()
        {
            return _service.GetActive();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(ToDoViewModel model)
        {
            ToDo todo = new ToDo() { Title = model.ToDo, IsActive = model.IsActive };
            var result = _service.SaveTodo(todo);
            return Ok(result);
        }
    }
}
