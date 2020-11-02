using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BariiLiii.Models
{
    public class Patient
    {
        //Avoiding automatic numbering
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MinLengthAttribute(9)]
        [MaxLengthAttribute(9)]
        [Key]
        [Display(Name = "Patient Id")]
        public string PatientId { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        public ICollection<Appointment> appointment { get; set; }
    }  
}
