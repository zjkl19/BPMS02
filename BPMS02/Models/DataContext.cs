using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using BPMS02.Areas.Dev.Models;

namespace BPMS02.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Bridge> Bridges { get; set; }
        public virtual DbSet<StaffProject> StaffProjects { get; set; }
        public virtual DbSet<InspectionType> InspectionTypes { get; set; }
        public virtual DbSet<ProjectInspectionType> ProjectInspectionTypes { get; set; }


        
    }
}
