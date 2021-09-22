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
	/// Interaction logic for DonorHistory.xaml
	/// </summary>
	public partial class DonorHistory : Window
	{
		public DonorHistory()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			DataTable donorInfo1 = new DataTable();
			DataTable bagDetails1 = new DataTable();
			using (MySqlConnection conn = new MySqlConnection(DBConnection.connstring))
			{
				conn.Open();
				string query = "SELECT d.iddonors, d.first_name, d.last_name, COUNT(b.donor_id) AS 'bags_donated', b.type, b.rhesus_factor, d.age, d.gender, d.phone_number "
					+ "FROM donors d "
					+ "JOIN blood b "
					+ "ON b.donor_id = d.iddonors "
					+ "WHERE d.iddonors = " + donorid1.Text
					+ " GROUP BY d.iddonors";
				using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
					da.Fill(donorInfo1);

				string query1 = "SELECT bag_num, content, cost FROM blood b WHERE b.donor_id = " + donorid1.Text;
				using (MySqlDataAdapter da = new MySqlDataAdapter(query1, conn))
					da.Fill(bagDetails1);
			}
			donorInfo.ItemsSource = donorInfo1.DefaultView;
			bagDetails.ItemsSource = bagDetails1.DefaultView;
		}
	}
}
