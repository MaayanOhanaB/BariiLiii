using BariiLiii.Data;
using BariiLiii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BariiLiii.Areas.Identity.Data
{
    public class DbInitializer
    {
        public static void Initialize(BariiLiiiContext context)
        {
            context.Database.EnsureCreated(); //if Db exists
            if (context.MedicalTeams.Any())
            {
                return; //DB is full already
            }

            //MedicalTeam
            //DB is empty
            var medicalTeams = new MedicalTeam[]
            {
                new MedicalTeam{ DId="318465913", FullName="Eyal Moshe", Gender="M", Specialization="Rhinoplasty", Location="Asuta Ashdod, Belinson Petah Tikva", PreviousExprience=10},
                new MedicalTeam{ DId="318465912", FullName="Justin Chembers", Gender="M", Specialization="Rhinoplasty", Location="Asaf Ha-Rofe Rishon Le Zion, Beit Ha-Rofim Tel Aviv", PreviousExprience=15},
                new MedicalTeam{ DId="318465914", FullName="Patrick Dampsi", Gender="M", Specialization="Hyaluronic Acid", Location="Asuta Haifa, Ziv Zefat", PreviousExprience=5},
                new MedicalTeam{ DId="31465919", FullName="Gadi Goldstein", Gender="M", Specialization="Hyaluronic Acid", Location="Rambam Hospital Haifa, Carmel hospital Haifa", PreviousExprience=20},
                new MedicalTeam{ DId="316465920", FullName="Nurit Lerer Ben Hamo", Gender="F", Specialization="Facelift",  Location="Volfson hospital Holon, Asaf Ha-Rofe Rishon Le Zion", PreviousExprience=25},
                new MedicalTeam{ DId="316385919", FullName="Helen Katlin", Gender="F", Specialization="Facelift", Location="Kaplan hospital Rehovot, Asuta Tel Aviv", PreviousExprience=15},
                new MedicalTeam{ DId="317165717", FullName="Gil Lahmi", Gender="M", Specialization="Gastro",  Location="Asuta Ashdod, Belinson Petah Tikva", PreviousExprience=7},
                new MedicalTeam{ DId="247665729", FullName="Alon Moshe", Gender="M", Specialization="Gastro",  Location="Asuta Tel Aviv, Tel Ha-Shomer Ramat Gan", PreviousExprience=15},
                new MedicalTeam{ DId="022165714", FullName="Shaked Roi", Gender="F", Specialization="Orthopedics", Location="Belinson Petah Tikva", PreviousExprience=5},
                new MedicalTeam{ DId="319165896", FullName="Shani Cohen", Gender="F", Specialization="Orthopedics",  Location="Kaplan hospital Rehovot, Hadasah Ein Karem Jerusalem", PreviousExprience=12},
                new MedicalTeam{ DId="205465921", FullName="Dani Galmor", Gender="M", Specialization="Dentist",  Location="Shiba Ramat Gan, Meir Kfar Saba", PreviousExprience=16},
                new MedicalTeam{ DId="022165847", FullName="Arik Bornstein", Gender="M", Specialization="Dentist",  Location="Kaplan hospital Rehovot, Private clinic Nahariya", PreviousExprience=24},
                new MedicalTeam{ DId="315145815", FullName="Alex Sherman", Gender="M", Specialization="General Medicine", Location="Meir Kfar Sab, Maayanei Ha-Yeshua Bnei Brak", PreviousExprience=10},
                new MedicalTeam{ DId="311145624", FullName="Maya Shaul", Gender="F", Specialization="General Medicine", Location="Asuta Ashdod, Hadasah Ein Karem Jerusalem", PreviousExprience=13}
            };

            foreach (MedicalTeam mt in medicalTeams)
            {
                context.MedicalTeams.Add(mt);
            }
            context.SaveChanges();

            //Patients
            var patients = new Patient[]
            {
                new Patient{PatientId = "317228394", Gender="F",Location="Rishon Le-Zion"},
                new Patient{PatientId = "316738320", Gender="M",Location="Shoham"},
                new Patient{PatientId = "316225520", Gender="M",Location="Tel Aviv"},
                new Patient{PatientId = "317916244", Gender="F",Location="Petah Tikva"},
                new Patient{PatientId = "022916982", Gender="F",Location="Jerusalem"},
                new Patient{PatientId = "313415632", Gender="M",Location="Hod Ha-Sharon"},
                new Patient{PatientId = "027116379", Gender="F",Location="Holon"}
            };

            foreach (Patient p in patients)
            {
                context.Patients.Add(p);
            }
            context.SaveChanges();

            //Appointments
            var appointments = new Appointment[]
            {
                new Appointment{Specialization="Dentist", DId="022165847", PatientId="317228394", AvailabilityQueues=DateTime.Parse("12-01-21 8:30")},
                new Appointment{Specialization="Gastro", DId="247665729", PatientId="316738320", AvailabilityQueues=DateTime.Parse("16-11-20 19:00")},
                new Appointment{Specialization="General Medicine",DId="311145624", PatientId="316225520", AvailabilityQueues=DateTime.Parse("29-12-20 12:46")},
                new Appointment{Specialization="Orthopedics", DId="022165714", PatientId="317916244", AvailabilityQueues=DateTime.Parse("17-01-21 17:30")},
                new Appointment{Specialization="Rhinoplasty",DId="318465913", PatientId="022916982", AvailabilityQueues=DateTime.Parse("13-11-20 18:54")},
                new Appointment{Specialization="Facelift", DId="316465920", PatientId="313415632", AvailabilityQueues=DateTime.Parse("16-3-21 14:00")},
                new Appointment{Specialization="Hyaluronic Acid", DId="318465914",PatientId="027116379", AvailabilityQueues=DateTime.Parse("15-02-21 13:00")}
            };

            foreach (Appointment a in appointments)
            {
                context.Appointments.Add(a);
            }
            context.SaveChanges();
        }
    }
}
