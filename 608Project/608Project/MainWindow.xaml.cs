using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace _608Project
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 

	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			SelectSurgeon ss = new SelectSurgeon();
			ss.Show();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			SelectBloodBag ss = new SelectBloodBag();
			ss.Show();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			AddBloodDonation ss = new AddBloodDonation();
			ss.Show();
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			//donor history
			DonorHistory ss = new DonorHistory();
			ss.Show();
		}

		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			//donor lookup
			DonorLookUp ss = new DonorLookUp();
			ss.Show();
		}

		private void Button_Click_6(object sender, RoutedEventArgs e)
		{
			//recipient lookup
			RecipientLookUp ss = new RecipientLookUp();
			ss.Show();
		}

		private void Button_Click_7(object sender, RoutedEventArgs e)
		{
			//surgeon lookup
			SurgeonLookUp ss = new SurgeonLookUp();
			ss.Show();
		}
	}
}
