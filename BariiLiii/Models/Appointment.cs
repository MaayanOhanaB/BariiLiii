using BariiLiii.Areas.Identity.Data;
using BariiLiii.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BariiLiii.Models
{
    public class Appointment
    {
        [Key]
        [Display(Name = "Appointment Id")]
        public int Id { get; set; }

        [Display(Name = "Specialization")]
        public string Specialization { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MinLengthAttribute(9)]
        [MaxLengthAttribute(9)]
        [Display(Name = "Doctor Id")]
        public string DId { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MinLengthAttribute(9)]
        [MaxLengthAttribute(9)]
        [Display(Name = "Patient Id")]
        public string PatientId { get; set; }
        public string userId { get; set; }

        [Display(Name = "AvailabilityQueues")]
        public DateTime AvailabilityQueues { get; set; }

        public MedicalTeam medicalTeam { get; set; }
        public Patient patient { get; set; }
        public BariiLiiiUser user { get; set; }
    }
}