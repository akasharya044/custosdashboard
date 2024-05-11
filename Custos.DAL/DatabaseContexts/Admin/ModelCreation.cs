using custos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DatabaseContexts.Admin
{
    public static partial class ModelCreation
    {
        public static void AddAdminUsers(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<AdminUsers>();
            temp.HasKey(x => x.Id);
            temp.ToTable(nameof(AdminUsers));
        }
        public static void AddDeviceStatusPool(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<DeviceStatusPool>();
            temp.HasKey(x => x.DeviceId);
            temp.ToTable(nameof(DeviceStatusPool));
        }
        public static void AddExceptionLog(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<ExceptionLog>();
            temp.HasKey(x => x.PKExceptionId);
            temp.ToTable(nameof(ExceptionLog));
        }
       
    }
}
