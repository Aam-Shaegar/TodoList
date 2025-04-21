namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
    }
}