using MyToDo.DataAccess;
using SuperTodo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyToDo.Services
{
    public class ToDoService : IToDoService
    {
        private readonly Guid _id;
        private readonly ApplicationDbContext _db;

        public ToDoService(ApplicationDbContext db)
        {
            _db = db;
            _id = Guid.NewGuid();
        }

        public IEnumerable<ToDo> GetActive()
        {
            return _db.ToDos.Where(x => x.IsActive == true).ToList();
        }
        public IEnumerable<ToDo> GetAll(ToDoParameters toDoParameters)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.ToDos.Skip((toDoParameters.PageNumber - 1) * toDoParameters.PageSize).Take(toDoParameters.PageSize).ToList();
                
            }
        }

        public ToDo GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    var result = db.ToDos.FirstOrDefault(x => x.ToDoId == id);
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
                
            }
            
        }

        public ToDo SaveTodo(ToDo item)
        {
            using (var db = new ApplicationDbContext())
            {
                item.CreatedAt = DateTime.Now;
                db.Add(item);
                db.SaveChanges();
            }

            return item;
        }

        public ToDo UpdateTodo(ToDo item)
        {
            using (var db = new ApplicationDbContext())
            {
                var todoFromDB = db.ToDos.First(t => t.Title == item.Title);
                todoFromDB.Description = item.Description;

                db.Add(todoFromDB);
                db.SaveChanges();
            }

            return item;
        }
    }
}
