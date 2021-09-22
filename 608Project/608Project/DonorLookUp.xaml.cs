using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace _608Project
{
	/// <summary>
	/// Interaction logic for DonorLookUp.xaml
	/// </summary>
	public partial class DonorLookUp : Window
	{
		public DonorLookUp()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			DataTable donorInfo1 = new DataTable();
			using (MySqlConnection conn = new MySqlConnection(DBConnection.connstring))
			{
				conn.Open();
				string query = "SELECT d.iddonors, d.first_name, d.last_name, b.type, b.rhesus_factor, d.address, d.age, d.gender, d.phone_number "
						+ "FROM donors d "
						+ "JOIN blood b "
						+ "ON b.donor_id = d.iddonors "
						+ "WHERE d.first_name = '" + first_name1.Text + "' AND d.last_name = '" + last_name1.Text +"' AND d.phone_number LIKE '%" +phone_number1.Text +"' "
						+ "GROUP BY d.iddonors";
				using MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
				da.Fill(donorInfo1);

			}
			donorInfo.ItemsSource = donorInfo1.DefaultView;
		}



	}
}
