using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClientWCF
{
	public class DataContextUser: INotifyPropertyChanged
	{
		private string name;
		private string familyName;
		private string sex;
		private int age;

		public int Age
		{
			get { return age; }
			set 
			{
				if (value != age)
				{
					age = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age"));
				}
			}
		}

		public string Sex
		{
			get { return sex; }
			set 
			{
				if (value != sex)
				{
					sex = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sex"));
				}
			}
		}

		public string FamilyName
		{
			get { return familyName; }
			set 
			{
				if (value != familyName)
				{
					familyName = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FamilyName"));
				}
			}
		}


		public string Name
		{
			get { return name; }
			set 
			{
				if (value != name)
				{
					name = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
