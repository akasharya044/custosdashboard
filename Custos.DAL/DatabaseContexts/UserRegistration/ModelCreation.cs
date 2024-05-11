using custos.Models;
using custos.Models.UserRegistration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DatabaseContexts.UserRegistration
{
    public static partial class ModelCreation
    {
        public static void AddRegistration(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<UserRegistrations>();
            temp.HasKey(x => x.Id);
            temp.ToTable(nameof(UserRegistrations));
        }
    }
}
