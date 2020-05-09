using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientWCF
{
	class Program
	{
		static async void AsyncPrint(string input, ServiceReferenceWCF.Service1Client client)
		{
			Console.WriteLine($"Le prix est {client.GetPrice(input)}. ");
		}
		static void Main(string[] args)
		{
			var client = new ServiceReferenceWCF.Service1Client();
			Console.WriteLine("Quel est le nom du produit dont vous voulez obtenir le prix ? (\"q\" pour quitter)");
			string input = Console.ReadLine();

			while (input != "q")
			{
				Task.Run(() => AsyncPrint(input, client));
				Console.WriteLine("Quel est le nom du produit dont vous voulez obtenir le prix ? (\"q\" pour quitter)");
				input = Console.ReadLine();
			}

			client.Close();
		}
	}
}
