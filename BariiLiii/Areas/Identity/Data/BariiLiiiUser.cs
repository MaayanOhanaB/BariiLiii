using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BariiLiii.Models;
using Microsoft.AspNetCore.Identity;

namespace BariiLiii.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the BariiLiiiUser class
    public class BariiLiiiUser : IdentityUser
    {
    }
}
