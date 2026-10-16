using System.ComponentModel.DataAnnotations;

namespace ToDo.Api.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
    }
}
