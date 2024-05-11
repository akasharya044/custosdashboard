using custos.Models;
using custos.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DatabaseContexts.AdditionalInfo
{
   public static partial  class ModelCreation
    {
        public static void AddAdditionallnformation(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<AdditionalInformation>();
            temp.HasKey(x => x.Id);
            temp.ToTable(nameof(AdditionalInformation));
        }
        public static void AddAdditionallnformationHardDisk(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<AdditionalInformationHardDisk>();
            temp.HasKey(x => x.Id);
            temp.ToTable(nameof(AdditionalInformationHardDisk));
        }
        public static void AddDeviceData(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<DeviceData>();
            temp.HasKey(x => x.Id);
            temp.ToTable(nameof(DeviceData));
        }
        public static void AddMachineRegistration(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<MachineRegistration>();
            temp.HasKey(x => x.Id);
            temp.ToTable(nameof(MachineRegistration));
        }
        public static void AddSystemHardware(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<SystemHardware>();
            temp.HasKey(x => x.Id);
            temp.ToTable(nameof(SystemHardware));
        }
        public static void AddSystemSoftware(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<SystemSoftware>();
            temp.HasKey(x => x.Id);
            temp.ToTable(nameof(SystemSoftware));
        }

        public static void BackgroundData(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<Backgroundservice>();
            temp.HasKey(x => x.UserId);
            temp.ToTable(nameof(Backgroundservice));
        }

    }
}