using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWithEntity
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var entities = new ServiceBasedDB1Entities())
			{
				Client c = new Client() { Age = 100, Name = "Charles", FamilyName = "de Gaulles", Sex = "M" };
				entities.Clients.Add(c);
				entities.SaveChanges();
				foreach (var client in entities.Clients.Where((client) => client.Sex == "M"))
				{
					Console.WriteLine($"ID:{client.Id}, Name:{client.Name}, Family Name:{client.FamilyName}, Age:{client.Age}, Sex:{client.Sex}");
				}
			}
			Console.ReadLine();
		}
	}
}
