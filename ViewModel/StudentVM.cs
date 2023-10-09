using Microsoft.Extensions.Primitives;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFSSITEWITHOUTENTITY.ViewModel
{
    public class StudentVM
    {
        public int StudentId { get; set; }
        [Display(Name ="GR NO")]
        [Required(ErrorMessage = "This Field is Required")]
        [MaxLength(11,ErrorMessage ="Maximum 11 characters")]
        public string GRNO { get; set; }
        [Display(Name = "Roll No")]
        [Required(ErrorMessage = "This Field is Required")]
        [MaxLength(11, ErrorMessage = "Maximum 11 characters")]
        public string RollNo { get; set; }
        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "This Field is Required")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters")]
        public string StudentName { get; set; }
        [Display(Name = "Father Name")]
        [Required(ErrorMessage = "This Field is Required")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters")]
        public string FatherName { get; set; }
        [Display(Name = "Class")]
        [Required(ErrorMessage = "This Field is Required")]
        public int ClassId { get; set; }
        [Display(Name = "DOB")]
        [Required(ErrorMessage = "This Field is Required")]
        [DisplayFormat(DataFormatString ="{0:MMM-dd-yyyy}")]
        public DateTime? DOB { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "This Field is Required")]
        public string Gender { get; set; }
        [Display(Name = "Phone1")]
        [Required(ErrorMessage = "This Field is Required")]
        [MaxLength(15, ErrorMessage = "Maximum 15 characters")]
        public string Phone1 { get; set; }
        [Display(Name = "Phone2")]
        [Required(ErrorMessage = "This Field is Required")]
        [MaxLength(15, ErrorMessage = "Maximum 15 characters")]
        public string Phone2 { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "This Field is Required")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters")]
        public string Address { get; set; }
        [Display(Name = "Admission Date")]
        [Required(ErrorMessage = "This Field is Required")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yyyy}")]
        public DateTime AdmissionDate { get; set; }
        [Display(Name = "Status")]
        [Required]
        public string Status { get; set; }
        [Display(Name = "Description")]
        [MaxLength(11, ErrorMessage = "Maximum 500 characters")]
        public string? Description { get; set; }
        [Display(Name = "Father CNIC")]
        [Required(ErrorMessage = "This Field is Required")]
        public string FatherCNIC { get; set; }
        [Display(Name = "Admission Fee")]
        public decimal? AdmissionFee { get; set; }
        [Display(Name = "Monthly Fee")]
        [Required(ErrorMessage = "This Field is Required")]
        public decimal MonthlyFee { get; set; }
        [Display(Name = "Annual Charges")]
        public decimal? AnnualCharges { get; set; }
        [Display(Name = "Stationary")]
        public decimal? StationaryCharges { get; set; }
    }
}
 