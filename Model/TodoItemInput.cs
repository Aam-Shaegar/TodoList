namespace TodoApi.Models
{
    public class TodoItemInput
    {
        public required string Name { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
    }
}