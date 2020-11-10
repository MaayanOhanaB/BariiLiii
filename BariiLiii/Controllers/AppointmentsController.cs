using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BariiLiii.Data;
using BariiLiii.Models;
using BariiLiii.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace BariiLiii.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly BariiLiiiContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<BariiLiiiUser> _userManager;
        private readonly SignInManager<BariiLiiiUser> _signInManager;

        public AppointmentsController(BariiLiiiContext context,
            Microsoft.AspNetCore.Identity.UserManager<BariiLiiiUser> userManager,
            SignInManager<BariiLiiiUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Serach appointments
        public async Task<IActionResult> IndexAsync(int Id, string Specialization, string DId, string PatientId)
        {
            var searchAppointments = from a in _context.Appointments
                                     select a;

            if (Id != 0)
            {
                searchAppointments = searchAppointments.Where(S => S.Id == Id);
            }

            if (!String.IsNullOrEmpty(Specialization))
            {
                searchAppointments = searchAppointments.Where(S => S.Specialization.Contains(Specialization));
            }


            if (!String.IsNullOrEmpty(DId))
            {
                searchAppointments = searchAppointments.Where(S => S.DId.Contains(DId));
            }

            if (!String.IsNullOrEmpty(PatientId))
            {
                searchAppointments = searchAppointments.Where(S => S.PatientId.Contains(PatientId));
            }

            return View(await searchAppointments.ToListAsync());
        }

        public ActionResult AppointmentGroupBy()
        {
            
            var popularSpecialization = _context.Appointments.GroupBy(s => s.Specialization)
                .Select(s => new { Specialization = s.Key, Count = s.Count() })
                .OrderByDescending(x => x.Count).Take(10);

           
            return View(popularSpecialization.AsEnumerable());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }
        public async Task<IActionResult> RegisterAsync(string Doctorid,string userid,DateTime datetime)
        {
            var Doctor = _context.MedicalTeams.Where(d => d.DId.Equals(Doctorid));
            var user = _context.Users.Where(u => u.Id.Equals(userid));
            var time = DateTime.Now;

            var appointment = new Appointment { Specialization = "Dentist", DId = Doctorid, userId = userid, AvailabilityQueues = datetime };
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Appointments, "Id", "Id");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Specialization,DId,PatientId,AvailabilityQueues")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Appointments, "Id", "Id", appointment.Id);
            return View(appointment);
        }
        public IActionResult CreateNew(int doctorId ,string Specialization, string PatientId,DateTime avaiable)
        {

            return View();
        }

        public IActionResult NewAppointment(string specializtion)
        {
            var Doctors = from m in _context.MedicalTeams
                          select m;
            var SearchDoctors = from m in _context.MedicalTeams
                          select m;
            if(specializtion=="ShowAll")
            {
                return View(Doctors);
            }
            SearchDoctors = Doctors.Where(s => s.Specialization.Contains("Empty"));
            if (!String.IsNullOrEmpty(specializtion))
            {
                SearchDoctors = Doctors.Where(S => S.Specialization.Contains(specializtion));
            }
            return View(SearchDoctors);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Appointments, "Id", "Id", appointment.Id);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Specialization,DId, PatientId,AvailabilityQueues")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Appointments, "Id", "Id", appointment.Id);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}