using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BariiLiii.Models
{
    public class MedicalTeam
    {
        //Avoiding automatic numbering
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MinLengthAttribute(9)]
        [MaxLengthAttribute(9)]
        [Key]
        [Display(Name = "Doctor Id")]
        public string DId { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Specialization")]
        public string Specialization { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Previous Exprience")]
        public int PreviousExprience { get; set; }

        public ICollection<Appointment> appointment { get; set; }
    }
}
