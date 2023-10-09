using System.ComponentModel.DataAnnotations;

namespace PFSSITEWITHOUTENTITY.Models
{
    public class Class : BaseEntity
    {

        [Key]
        public int ClassId { get; set; }
        [Display(Name = "Session")]
        [Required]
        public int SessionId { get; set; }
        [Display(Name = "Class Name")]
        [Required]
        public string ClassName { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        public string Session { get; set; }
    }
}
