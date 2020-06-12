﻿using System;
using System.Collections.Generic;
using System.Text;
 using Microsoft.AspNetCore.Identity;
 using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
 using Microsoft.Extensions.Logging;
 using PocketMenuUI.Models;

namespace PocketMenuUI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
    }

}
