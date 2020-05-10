using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFClientWCF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		delegate void Delegate1(string str);
		event Delegate1 Event1;

		Button Button2;
		
		public MainWindow()
		{
			InitializeComponent();
			Button2 = new Button();
			Button2.Content = "button from c# side";
			Button2.Click += Button2_Click;

			StackPanel1.Children.Add(Button2);
			Event1 += (str) =>
			{
				Label1.Content = str;
			};
		}

		private void Button1_Click(object sender, RoutedEventArgs e)
		{
			Event1(DateTime.Now.ToString());
		}

		private void Button2_Click(object sender, RoutedEventArgs e)
		{
			Event1(DateTime.Now.Minute.ToString());
		}

		//private void ChangeLabelContent(string str)
		//{
		//	Label1.Content = str;
		//}
	}
}
