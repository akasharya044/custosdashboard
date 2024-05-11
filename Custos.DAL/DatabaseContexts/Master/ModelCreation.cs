using custos.Models;
using custos.Modelss;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DatabaseContexts.Master
{
    public static partial class ModelCreation
    {
        public static void AddAnswer(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<Answers>();
            temp.HasKey(x => x.Id);
            //temp.HasOne(x => x.Question);
            temp.ToTable(nameof(Answers));
        }
        public static void AddAreas(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<Areas>();
            temp.HasKey(x => x.Id);
            //temp.HasOne(x => x.Categories);
            //temp.HasOne(x => x.SubCategories).WithMany().HasForeignKey(r => r.SubCategoryId).OnDelete(DeleteBehavior.NoAction);
            temp.ToTable(nameof(Areas));
        }
        public static void AddCategories(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<Categories>();
            temp.HasKey(r => r.Id);
            temp.ToTable(nameof(Categories));
        }
        public static void AddDeviceStatus(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<DeviceDailyStatus>();
            temp.HasKey(r => r.Id);
            temp.ToTable(nameof(DeviceDailyStatus));
        }
        public static void AddDeviceDetail(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<DeviceDetails>();
            temp.HasKey(r => r.Id);
            temp.ToTable(nameof(DeviceDetails));
        }
        public static void AddDeviceRunningLog(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<DeviceRunningLog>();
            temp.HasKey(r => r.Id);
            temp.ToTable(nameof(DeviceRunningLog));
        }
        public static void AddPersonDetail(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<PersonDetails>();
            temp.HasKey(r => r.Id);
            temp.ToTable(nameof(PersonDetails));
        }
        public static void AddQuestion(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<Questions>();
            temp.HasKey(x => x.Id);
            //temp.HasOne(x => x.Area);
            temp.ToTable(nameof(Questions));
        }
        public static void AddSearchQuestion(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<SearchQuestion>();
            temp.HasKey(x => x.Id);
            temp.ToTable(nameof(SearchQuestion));
        }
        public static void AddSubCategories(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<SubCategories>();
            temp.HasKey(x => x.Id);
            temp.ToTable(nameof(SubCategories));
        }

    }
}
