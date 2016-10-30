using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ConsoleApplication2;
using ConsoleApplication3;


namespace ConsoleApplication1
{
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }

            // Shorter way to write this in C# using ?? operator :
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >() ;
            // x ?? y -> if x is not null , expression returns x. Else y.
        }

        public void Add(TodoItem todoItem)
        {
          if (_inMemoryTodoDatabase.Where(s => s.Equals(todoItem)).FirstOrDefault() != null)
            {
                throw new DuplicateTodoItemException("duplicate id: {" + todoItem.Id + "}");
            }
            _inMemoryTodoDatabase.Add(todoItem);
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.Where(s => s.Id.Equals(todoId)).FirstOrDefault();
           
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(s => s.IsCompleted == false).ToList();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(s => s.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(s => s.IsCompleted == true).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(s => filterFunction(s) == true).ToList();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem item = _inMemoryTodoDatabase.Where(s => s.Id.Equals(todoId)).FirstOrDefault();
            if (item != null)
            {
                item.MarkAsCompleted();
                return true;
            }
            return false;
            
        }

        public bool Remove(Guid todoId)
        {
            TodoItem item = _inMemoryTodoDatabase.Where(s => s.Id.Equals(todoId)).FirstOrDefault();
            if (item != null)
            {
                _inMemoryTodoDatabase.Remove(item);
                return true;
            }    
            return false;
        }

        public void Update(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                var update = _inMemoryTodoDatabase.Single(s => s.Id.Equals(todoItem.Id));
                todoItem = update;
            }
            else
                _inMemoryTodoDatabase.Add(todoItem);
        }
    }




}
