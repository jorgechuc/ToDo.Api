namespace ToDo.Api.DTOs
{
    public class ToDoItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
    }
}
