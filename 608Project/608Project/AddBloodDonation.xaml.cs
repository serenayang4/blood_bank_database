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
	/// Interaction logic for AddBloodDonation.xaml
	/// </summary>
	public partial class AddBloodDonation : Window
	{
		public AddBloodDonation()
		{
			InitializeComponent();
			bindListBox();
		}

		private readonly string[] types = { "A", "B", "AB", "O" };
		private readonly string[] content = { "Whole", "Plasma", "RBC", "WBC", "Platelets" };
		private readonly int[] rhesus = { 0, 1 };


		private void bindListBox()
		{
			content1.ItemsSource = content;
			rhesus1.ItemsSource = rhesus;
			type1.ItemsSource = types;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			DataTable dt = new DataTable();
			try
			{
				using (MySqlConnection conn = new MySqlConnection(DBConnection.connstring))
				{
					conn.Open();
					MySqlCommand command = conn.CreateCommand();
					command.CommandText = "INSERT INTO blood(donor_id, TYPE, rhesus_factor, content, cost) "
						+ "VALUES (" + recipientID.Text + ", '" + type1.Text + "'," + rhesus1.Text + ", '" + content1.Text + "'," + cost1.Text + ")";
					command.ExecuteNonQuery();


					
					string query = "SELECT * FROM blood b WHERE b.donor_id = " + recipientID.Text;
					using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
						da.Fill(dt);

				}
			}
			catch (Exception)
			{
				MessageBox.Show("Added Blood Donation Fail. Please Try again", "Failure!!", MessageBoxButton.OK);
			}

			newDonation.ItemsSource = dt.DefaultView;
			MessageBox.Show("Added Blood Donation Successful!. You may now close the window", "Success!!", MessageBoxButton.OK);
		}
	}
}
