using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using custos.Models;
using custos.Models;
using Microsoft.EntityFrameworkCore;

namespace custos.DAL.DatabaseContexts.Tickets
{
    public static partial class ModelCreation
    {
        public static void AddTicket(this ModelBuilder modelBuilder)
        {
            var temp = modelBuilder.Entity<TicketRecord>();
            temp.HasKey(x => x.Id);
            temp.ToTable(nameof(TicketRecord));
        }
    }
}
