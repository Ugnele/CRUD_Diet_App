﻿using CrudDietLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDietApp.Data
{
    public class AppDatabases : DbContext
    {
        public AppDatabases(DbContextOptions<AppDatabases> options) : base(options) { }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
