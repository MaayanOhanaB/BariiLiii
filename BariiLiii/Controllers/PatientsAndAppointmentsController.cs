using BariiLiii.Data;
using BariiLiii.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BariiLiii.Controllers
{
    public class PatientsAndAppointmentsController: Controller
    {
        private readonly BariiLiiiContext _context;

        //constructor
        public PatientsAndAppointmentsController(BariiLiiiContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            List<Patient> PatientsList = _context.Patients.ToList();
            List<Appointment> AppointmentsList = _context.Appointments.ToList();
            List<MedicalTeam> MedicList = _context.MedicalTeams.ToList();

            //code for JOIN
            var JoinList = from p in PatientsList
                           join a in AppointmentsList on p.PatientId equals a.PatientId
                           join m in MedicList on a.DId equals m.DId
                           select new PatientsAndAppointments { thePatient = p, theAppointment = a , theDoc = m};

            return View(JoinList);
        }
    }
}
