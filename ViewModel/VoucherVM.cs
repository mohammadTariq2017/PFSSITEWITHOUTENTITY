using System;
using System.ComponentModel.DataAnnotations;

namespace PFSSITEWITHOUTENTITY.ViewModel
{
    public class VoucherVM
    {
        public int VoucherId { get; set; }
        [Display(Name = "Student")]
        [Required(ErrorMessage = "This Field is Required")]
        public int StudentId { get; set; }
        [Display(Name = "Class")]
        [Required(ErrorMessage = "This Field is Required")]
        public int ClassId { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "This Field is Required")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Title { get; set; }
        [Display(Name = "Month")]
        [Required(ErrorMessage = "This Field is Required")]
        [MaxLength(15, ErrorMessage = "Maximum 15 characters")]
        public string Month { get; set; }
        [Display(Name = "Due Date")]
        [Required(ErrorMessage = "This Field is Required")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yyyy}")]
        public DateTime DueDate { get; set; }
        [Display(Name = "Receiving Date")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yyyy}")]
        public DateTime? ReceivingDate { get; set; }
        [Display(Name = "Amount")]
        [Required(ErrorMessage = "This Field is Required")]
        public decimal Amount { get; set; }
        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }
        [Display(Name = "Remaining Amount")]
        public decimal? RemainingAmount { get; set; }
        [Display(Name = "Description")]
        [MaxLength(500, ErrorMessage = "Maximum 500 characters")]
        public string Description { get; set; }

    }
}
