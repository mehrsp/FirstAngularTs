﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Infra.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("MyFirstDb")
        {
           
        }
        public DbSet<Entry> Entries { get; set; }
    }
}
