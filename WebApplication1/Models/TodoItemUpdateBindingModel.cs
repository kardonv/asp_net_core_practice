using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class TodoItemUpdateBindingModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public bool HasDone { get; set; }

        [Required]
        [UIHint("date")]
        public DateTime OnDate { get; set; }
    }
}
