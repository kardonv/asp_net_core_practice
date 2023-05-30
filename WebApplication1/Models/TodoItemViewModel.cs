namespace WebApplication1.Models
{
    public class TodoItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasDone { get; set; }
        public DateTime OnDate { get; set; }
    }
}
