using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace QL_Ung_Vien.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Display(Name = "First Name")]
    public string firstName { get; set; }
    [Display(Name = "Last Name")]
    public string lastName { get; set; }
    public ApplicationUser():base()
    {

    }
}