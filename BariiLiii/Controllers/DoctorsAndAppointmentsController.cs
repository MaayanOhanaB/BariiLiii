using BariiLiii.Data;
using BariiLiii.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BariiLiii.Controllers
{
    public class DoctorsAndAppointmentsController: Controller
    {
        private readonly BariiLiiiContext _context;

        public DoctorsAndAppointmentsController(BariiLiiiContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            List<MedicalTeam> DoctorsList = _context.MedicalTeams.ToList();
            List<Appointment> AppointmentsList = _context.Appointments.ToList();

            var JoinList = from m in DoctorsList
                           join a in AppointmentsList on m.DId equals a.DId
                           select new DoctorsAndAppointments { theDoctor = m, theAppointment = a };

            return View(JoinList);
        }
    }
}
