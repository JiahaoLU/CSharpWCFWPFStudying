using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceWCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface IClientFolderService
	{
		[OperationContract]
		ObservableCollection<ClientFolder> GetFolders();
		[OperationContract]
		ObservableCollection<ClientFolder> GetMaleFolders();
		[OperationContract]
		bool AddClientFolder();
		[OperationContract]
		bool ModifyClientFolder(ClientFolder origin, ClientFolder folder);
		[OperationContract]
		bool DeleteClientFolder(ClientFolder folder);

		// TODO: Add your service operations here
	}


	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	[DataContract]
	public class ClientFolder
	{
		private string name;
		[DataMember]
		public string Name
		{
			get { return name; }
			set { name = value; NotifyPropertyChanged(); }
		}

		private string familyName;
		[DataMember]
		public string FamilyName
		{
			get { return familyName; }
			set { familyName = value; NotifyPropertyChanged(); }
		}

		private string sex;
		[DataMember]
		public string Sex
		{
			get { return sex; }
			set { sex = value; NotifyPropertyChanged(); }
		}
		private int age;
		[DataMember]
		public int Age
		{
			get { return age; }
			set { age = value; NotifyPropertyChanged(); }
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyPropertyChanged([CallerMemberName] string str = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
		}
	}
}
