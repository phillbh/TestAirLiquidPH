using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirLiquidTestApi.Model
{
	public class DBContext : DbContext
	{
		public DBContext(DbContextOptions<DBContext> options)
			: base(options)
		{ }
		public DbSet<Cliente> clientes { get; set; }
	}
	public class Cliente
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key, Column(Order = 0)]
		public int idSequencial { get; set; }
		public string Id { get; set; }
		public string Nome { get; set; }
		public int Idade { get; set; }
	}
}
