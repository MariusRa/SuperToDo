using System;

namespace SuperTodo
{
    public class ToDo
    {

        public int ToDoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
