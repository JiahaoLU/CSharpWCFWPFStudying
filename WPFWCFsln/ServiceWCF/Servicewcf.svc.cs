using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace ServiceWCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Servicewcf" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Servicewcf.svc or Servicewcf.svc.cs at the Solution Explorer and start debugging.
	public class Servicewcf : IClientFolderService
	{
		public ObservableCollection<ClientFolder> GetFolders()
		{
			ObservableCollection<ClientFolder> cf = null;
			using (var entities = new ServiceBasedClientDBEntities())
			{
				cf = new ObservableCollection<ClientFolder>(entities.Clients.Select(
					(Client client) =>
						new ClientFolder()
						{
							Name = client.Name,
							FamilyName = client.FamilyName,
							Sex = client.Sex,
							Age = client.Age.Value
						}
					));
			}
			return cf;
		}

		public bool AddClientFolder()
		{
			try
			{
				using (var entities = new ServiceBasedClientDBEntities())
				{
					entities.Clients.Add(new Client()
					{
						Name = "db default",
						FamilyName = "db default",
						Sex = "db default",
						Age = 0
					});
					entities.SaveChanges();
				}
				return true;
			}
			catch
			{
				return false;
			}
			
		}

		public bool ModifyClientFolder(ClientFolder origin, ClientFolder folder)
		{
			try
			{
				using (var entities = new ServiceBasedClientDBEntities())
				{
					var folderModifier = entities.Clients.FirstOrDefault(
						(client) => client.Name == origin.Name && client.FamilyName == origin.FamilyName);
					if (folderModifier != null)
					{
						folderModifier.Name = folder.Name;
						folderModifier.FamilyName = folder.FamilyName;
						folderModifier.Sex = folder.Sex;
						folderModifier.Age = folder.Age;
						entities.SaveChanges();
					}
					return true;
				}
			}
			catch
			{
				return false;
			}
		}

		public bool DeleteClientFolder(ClientFolder folder)
		{
			try
			{
				using (var entities = new ServiceBasedClientDBEntities())
				{
					var folderModifier = entities.Clients.Where((client) => 
					client.Name == folder.Name && client.FamilyName == folder.FamilyName &&
					client.Age == folder.Age && client.Sex == folder.Sex).ToArray();
					if (folderModifier != null)
					{
						entities.Clients.RemoveRange(folderModifier);
						entities.SaveChanges();
					}
					return true;
				}
			}
			catch
			{
				return false;
			}		
		}

		public ObservableCollection<ClientFolder> GetMaleFolders()
		{
			ObservableCollection<ClientFolder> cf = null;
			using (var entities = new ServiceBasedClientDBEntities())
			{
				cf = new ObservableCollection<ClientFolder>(entities.Clients.Where((client) => client.Sex == "M").Select(
					(Client client) =>
						new ClientFolder()
						{
							Name = client.Name,
							FamilyName = client.FamilyName,
							Sex = client.Sex,
							Age = client.Age.Value
						}
					));
			}
			return cf;
		}
	}
}
