using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BariiLiii.Data;
using BariiLiii.Models;
using Microsoft.EntityFrameworkCore.Internal;
using BariiLiii.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace BariiLiii.Controllers
{
    public class MedicalTeamsController : Controller
    {
        private readonly BariiLiiiContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<BariiLiiiUser> _userManager;
        private readonly SignInManager<BariiLiiiUser> _signInManager;

        public MedicalTeamsController(BariiLiiiContext context, 
            Microsoft.AspNetCore.Identity.UserManager<BariiLiiiUser> userManager, 
            SignInManager<BariiLiiiUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Serach doctors
        public async Task<IActionResult> IndexAsync(string DId, string FullName, string Gender, string Specialization, string Location, int PreviousExprience)
        {
            var searchDoctors = from m in _context.MedicalTeams
                          select m;

            if (!String.IsNullOrEmpty(DId))
            {
                searchDoctors = searchDoctors.Where(S => S.DId.Contains(DId));
            }

            if (!String.IsNullOrEmpty(FullName))
            {
                searchDoctors = searchDoctors.Where(S => S.FullName.Contains(FullName));
            }

            if (!String.IsNullOrEmpty(Gender))
            {
                searchDoctors = searchDoctors.Where(S => S.Gender.Contains(Gender));
            }

            if (!String.IsNullOrEmpty(Specialization))
            {
                searchDoctors = searchDoctors.Where(S => S.Specialization.Contains(Specialization));
            }

            if (!String.IsNullOrEmpty(Location))
            {
                searchDoctors = searchDoctors.Where(S => S.Location.Contains(Location));
            }

            if (PreviousExprience != 0)
            {
                searchDoctors = searchDoctors.Where(S => S.PreviousExprience >= PreviousExprience);
            }

            return View(await searchDoctors.ToListAsync());
        }


        // GET: MedicalTeams
        //public async Task<IActionResult> Index()
        //{
        //    var DoctorScheduler = _context.MedicalTeams
        //        .Join(_context.Appointments,
        //        Ds => Ds.DId,
        //        Av => Av.DId,
        //        (Ds, Av) => new { Doc = Ds, Ava = Av })
        //        .Where(DsAv => DsAv.Doc.DId.Equals(DsAv.Ava.DId));

        //    return View(await _context.MedicalTeams.ToListAsync());
        //}

        // GET: MedicalTeams/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalTeam = await _context.MedicalTeams
                .FirstOrDefaultAsync(m => m.DId == id);
            if (medicalTeam == null)
            {
                return NotFound();
            }

            return View(medicalTeam);
        }

        // GET: MedicalTeams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DId,FullName,Gender,Specialization,Location,PreviousExprience")] MedicalTeam medicalTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalTeam);
        }

        // GET: MedicalTeams/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalTeam = await _context.MedicalTeams.FindAsync(id);
            if (medicalTeam == null)
            {
                return NotFound();
            }
            return View(medicalTeam);
        }

        // POST: MedicalTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DId,FullName,Gender,Specialization,Location,PreviousExprience")] MedicalTeam medicalTeam)
        {
            if (id != medicalTeam.DId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalTeamExists(medicalTeam.DId))
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
            return View(medicalTeam);
        }

        // GET: MedicalTeams/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalTeam = await _context.MedicalTeams
                .FirstOrDefaultAsync(m => m.DId == id);
            if (medicalTeam == null)
            {
                return NotFound();
            }

            return View(medicalTeam);
        }

        // POST: MedicalTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var medicalTeam = await _context.MedicalTeams.FindAsync(id);
            _context.MedicalTeams.Remove(medicalTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalTeamExists(string id)
        {
            return _context.MedicalTeams.Any(e => e.DId == id);
        }
    }
}
