using System.ComponentModel.DataAnnotations;

namespace MyNotebook.Models
{
    public class Note
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(25, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Title { get; set; }

        [StringLength(1000, MinimumLength = 3, ErrorMessage = "field must be atleast 3 characters")]
        public string Description { get; set; }

        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }
    }
}
