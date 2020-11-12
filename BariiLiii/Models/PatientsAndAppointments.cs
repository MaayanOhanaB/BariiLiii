using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BariiLiii.Models
{
    public class PatientsAndAppointments
    {
        public Patient thePatient { get; set; }
        public Appointment theAppointment { get; set; }
        public MedicalTeam theDoc { get; set; }
    }
}
