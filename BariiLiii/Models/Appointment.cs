using BariiLiii.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BariiLiii.Models
{
    public class Appointment
    {
        [Display(Name = "Appointment Id")]
        public int Id { get; set; }

        [Display(Name = "Specialization")]
        public string Specialization { get; set; }

        [Display(Name = "Doctor Id")]
        public string DId { get; set; }

        [Display(Name = "Patient Id")]
        public string PatientId { get; set; }

        [Display(Name = "AvailabilityQueues")]
        public DateTime AvailabilityQueues { get; set; }

        public MedicalTeam medicalTeam { get; set; }
        public Patient patient { get; set; }
    }
}
