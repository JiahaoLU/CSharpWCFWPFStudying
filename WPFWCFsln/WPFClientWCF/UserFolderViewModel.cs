using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

		private ICommand resetSelectedFolder = new RelayCommand<DataContextUser>((user) => 
		{
			user.Age = 0;
			user.Sex = "";
			user.Name = "";
			user.FamilyName = "";
		});

		public ICommand ResetSelectedFolder
		{
			get { return resetSelectedFolder; }
		}

		private ICommand addFolder;

		public ICommand AddFolder
		{
			get 
			{
				if (addFolder == null)
				{
					addFolder = new RelayCommand<object>((obj) => { Folders.Add(new DataContextUser()); });
				}
				return addFolder; }
		}

		private ICommand modifySelectedFolder;

		public ICommand ModifySelectedFolder
		{
			get 
			{
				if (modifySelectedFolder == null)
				{
					modifySelectedFolder = new RelayCommand<DataContextUser>((user) =>
					{
						SelectedFolder = user;
					});
				}
				return modifySelectedFolder;
			}
		}
		private ICommand removeSelectedFolder;

		public ICommand RemoveSelectedFolder
		{
			get
			{
				if (removeSelectedFolder == null)
				{
					removeSelectedFolder = new RelayCommand<DataContextUser>((user) => Folders.Remove(user));
				}
				return removeSelectedFolder;
			}
		}

	}
}
