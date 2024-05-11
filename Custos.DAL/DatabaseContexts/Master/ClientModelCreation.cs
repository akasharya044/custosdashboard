using custos.Models;
using custos.Models.Master;
using custos.Models.RbacModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DatabaseContexts.Master
{
    public static partial class ClientModelCreation
    {
        public static void AddClient(this ModelBuilder modelBuilder)
        {
            var client = modelBuilder.Entity<Client>();
            client.HasKey(x => x.Id);
            client.ToTable(nameof(Client));
        }

        public static void AddClientLicense(this ModelBuilder modelBuilder)
        {
            var client = modelBuilder.Entity<ClientLicense>();
            client.HasKey(x => x.Id);
            client.ToTable(nameof(ClientLicense));
        }

        public static void AddUserType(this ModelBuilder modelBuilder)
        {
            var client = modelBuilder.Entity<UserType>();
            client.HasKey(x => x.Id);
            client.ToTable(nameof(UserType));
        }

        public static void AddUsers(this ModelBuilder modelBuilder)
        {
            var client = modelBuilder.Entity<Users>();
            client.HasKey(x => x.Id);
            client.ToTable(nameof(Users));
        }

        public static void AddMenus(this ModelBuilder modelBuilder)
        {
            var client = modelBuilder.Entity<Menu>();
            client.HasKey(x => x.Id);
            client.ToTable(nameof(Menu));
        }

        public static void AddUserRights(this ModelBuilder modelBuilder)
        {
            var client = modelBuilder.Entity<UsersRights>();
            client.HasKey(x => x.Id);
            client.HasOne(x => x.Menu);
            client.ToTable(nameof(UsersRights));
        }
		public static void AddState(this ModelBuilder modelBuilder)
		{
			var client = modelBuilder.Entity<State>();
			client.HasKey(x => x.Id);
			client.ToTable(nameof(State));
		}
	}

}
