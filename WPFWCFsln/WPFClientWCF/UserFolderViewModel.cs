using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFClientWCF
{
	public class UserFolderViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged([CallerMemberName] string str="")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
		}

		private ObservableCollection<DataContextUser> folders;

		public ObservableCollection<DataContextUser> Folders
		{
			get { return folders; }
			set 
			{
				if (folders != value)
				{
					folders = value;
					NotifyPropertyChanged();
				}
			}
		}

		private DataContextUser selectedFolder;

		public DataContextUser SelectedFolder
		{
			get { return selectedFolder; }
			set
			{
				if (selectedFolder != value)
				{
					selectedFolder = value;
					NotifyPropertyChanged();
				}
			}
		}

		public UserFolderViewModel()
		{
			Folders = new ObservableCollection<DataContextUser>();
			SelectedFolder = new DataContextUser()
			{
				Name = "John",
				FamilyName = "Paul",
				Sex = "Male",
				Age = 33
			};

			Folders.Add(SelectedFolder);
		}

	}
}
