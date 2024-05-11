using custos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DatabaseContexts.EventHistories
{
    public static partial class ModelCreation
    {
        public static void AddEventHistory(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<EventHistory>();
            temp.HasKey(x => x.Id);
            temp.ToTable(nameof(EventHistory));
        }
        public static void AddEvent(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<Events>();
            temp.HasKey(x => x.Id);
            temp.ToTable(nameof(Events));
        }
    }
}
