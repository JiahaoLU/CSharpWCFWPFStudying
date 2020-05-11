using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFClientWCF.ClientWCFServiceReference;

namespace WPFClientWCF
{
	public class UserFolderViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged([CallerMemberName] string str="")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
		}

		private ObservableCollection<ClientWCFServiceReference.ClientFolder> folders;

		public ObservableCollection<ClientFolder> Folders
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

		private ClientFolder selectedFolder;

		public ClientFolder SelectedFolder
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
		private ClientFolder hangedOnFolder;

		public ClientFolder HangedOnFolder
		{
			get { return hangedOnFolder; }
			set
			{
				if (hangedOnFolder != value)
				{
					hangedOnFolder = value;
					NotifyPropertyChanged();
				}
			}
		}

		public UserFolderViewModel()
		{
			var connecter = new ClientFolderServiceClient();
			Folders = new ObservableCollection<ClientFolder>(connecter.GetFolders());
			connecter.Close();
		}

		private ICommand resetSelectedFolder = new RelayCommand<ClientFolder>((folder) => 
		{
			folder.Age = 0;
			folder.Sex = "";
			folder.Name = "";
			folder.FamilyName = "";
		});
		public ICommand ResetSelectedFolder
		{
			get { return resetSelectedFolder; }
		}

		ICommand chooseSelectedFolder;
		public ICommand ChooseSelectedFolder
		{
			get
			{
				if (chooseSelectedFolder == null)
				{
					chooseSelectedFolder = new RelayCommand<ClientFolder>((folder) =>
					{
						HangedOnFolder = new ClientFolder()
						{
							Name = folder.Name,
							FamilyName = folder.FamilyName,
							Sex = folder.Sex,
							Age = folder.Age
						};
						SelectedFolder = folder;
					});
				}
				return chooseSelectedFolder;
			}
		}


		private ICommand addFolder;

		public ICommand AddFolder
		{
			get 
			{
				if (addFolder == null)
				{
					addFolder = new RelayCommand<object>((obj) => 
					{
						var connecter = new ClientFolderServiceClient();
						if (connecter.AddClientFolder())
						{
							Folders = new ObservableCollection<ClientFolder>(connecter.GetFolders());
						}
						connecter.Close();
					});
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
					modifySelectedFolder = new RelayCommand<ClientFolder>((folder) =>
					{
						var connecter = new ClientFolderServiceClient();
						if (connecter.ModifyClientFolder(SelectedFolder, folder))
						{
							Folders = new ObservableCollection<ClientFolder>(connecter.GetFolders());
						}
						connecter.Close();
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
					removeSelectedFolder = new RelayCommand<ClientFolder>((folder) =>
					{
						var connecter = new ClientFolderServiceClient();
						if (connecter.DeleteClientFolder(folder))
						{
							Folders = new ObservableCollection<ClientFolder>(connecter.GetFolders());
						}
						connecter.Close();
					});
				}
				return removeSelectedFolder;
			}
		}

	}
}
