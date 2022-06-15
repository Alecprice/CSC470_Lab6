using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab6
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		


		List<Package> list = new List<Package>();

		// initialize itterator
		public int listPosition = 0;
		bool isFirstClick = true;
		public bool isEditMode = false;
		bool isFirstStateChange = true;

		private void scanButton_Click(object sender, RoutedEventArgs e)
		{
			isEditMode = false;
			Random random = new Random();
			int num = random.Next(1000);
			tbl_arrived.Text = DateTime.Now.ToString();
			tbl_packID.Text = Convert.ToString(num);

			

			//add button
			addButton.IsEnabled = true;
			// per intruction a.
			tbl_address.IsReadOnly = false;
			tbl_city.IsReadOnly = false;
			tbl_zip.IsReadOnly = false;
			tbl_state.IsEnabled = true;
			listPosition = 0;
			tbl_state.SelectedIndex = 0;
			
		}

		private void backButton_Click(object sender, RoutedEventArgs e)
		{
			//checks to see what the itterator is set to if on 0 display position 0 in the list
			//if its greater than 0 subtract 1, --
			tbl_address.IsReadOnly = false;
			tbl_city.IsReadOnly = false;
			tbl_zip.IsReadOnly = false;
			tbl_state.IsEnabled = true;
			//if else
			if (listPosition == 0)
			{

				 isFirstClick = false;
				Package currPackage = list[listPosition];
				tbl_packID.Text = currPackage.ID.ToString();
				tbl_arrived.Text = currPackage.arrive;
				tbl_address.Text = currPackage.address;
				tbl_city.Text = currPackage.city;
				tbl_state.SelectedIndex = currPackage.stateIndex;
				tbl_zip.Text = currPackage.zip.ToString();
			}
			else if(listPosition > 0)
			{
				listPosition--;
				isFirstClick = false;
				Package currPackage = list[listPosition];
				tbl_packID.Text = currPackage.ID.ToString();
				tbl_arrived.Text = currPackage.arrive;
				tbl_address.Text = currPackage.address;
				tbl_city.Text = currPackage.city;
				tbl_state.SelectedIndex = currPackage.stateIndex;
				tbl_zip.Text = currPackage.zip.ToString();

			}

		}

		private void addButton_Click(object sender, RoutedEventArgs e)
		{

			try
			{

				int ID = Convert.ToInt32(tbl_packID.Text);
				string address = tbl_address.Text;
				string city = tbl_city.Text;
				int zip = Convert.ToInt32(tbl_zip.Text);
				string state = tbl_state.Text;
				int stateIndex = tbl_state.SelectedIndex;
				string arrive = tbl_arrived.Text.ToString();

				Package addPackage = new Package(ID, address, zip, city, state, stateIndex, arrive);

				if (isEditMode == false)
				{
					list.Add(addPackage);
					tbl_packID.Text = " ";
					tbl_address.Text = " ";
					tbl_city.Text = " ";
					tbl_zip.Text = " ";
					tbl_state.Text = " ";

				}
				else if (isEditMode == true)
				{
					list[listPosition] = addPackage;
				}

				tbl_packID.Text = " ";
				tbl_address.Text = " ";
				tbl_city.Text = " ";
				tbl_zip.Text = " ";
				tbl_state.Text = " ";
				

				//MessageBox.Show(list.ToString());
			}
			catch(Exception)
			{
				tbl_zip.Text = "";
				MessageBox.Show("zip code will have exactly 5 digits please try again!");
			}
		}

		private void removeButton_Click(object sender, RoutedEventArgs e)
		{
			list.Remove(list[listPosition]);
			tbl_packID.Text = " ";
			tbl_address.Text = " ";
			tbl_city.Text = " ";
			tbl_zip.Text = " ";
			tbl_state.Text = " ";
		}

		private void editButton_Click(object sender, RoutedEventArgs e)
		{
			isEditMode = true;
			tbl_address.IsReadOnly = false;
			tbl_city.IsReadOnly = false;
			tbl_zip.IsReadOnly = false;
			tbl_state.IsEnabled = true;
		}

		private void nextButton_Click(object sender, RoutedEventArgs e)
		{
			

			if (isFirstClick)
			{
				isFirstClick = false;
				listPosition = 0;
				Package currPackage = list[0];


				tbl_packID.Text = currPackage.ID.ToString();
				tbl_arrived.Text = currPackage.arrive;
				tbl_address.Text = currPackage.address;
				tbl_city.Text = currPackage.city;
				tbl_zip.Text = currPackage.zip.ToString();
				tbl_state.SelectedIndex = currPackage.stateIndex;
				


			}
			if (listPosition >= 0 && listPosition < list.Count - 1 && !isFirstClick)
			{
				isFirstClick = false;
				listPosition++;
				Package currPackage = list[listPosition];
				tbl_packID.Text = currPackage.ID.ToString();
				tbl_arrived.Text = currPackage.arrive;
				tbl_address.Text = currPackage.address;
				tbl_city.Text = currPackage.city;
				tbl_zip.Text = currPackage.zip.ToString();
				tbl_state.SelectedIndex = currPackage.stateIndex;
			}
		}

		private void pSent_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			{

				if (!isFirstStateChange)
				{
					Package_Display.Items.Clear();
				}



				List<Int32> IDs = new List<Int32>();
				foreach (Package package in list)
				{
					if (package.stateIndex == pState.SelectedIndex - 1)
					{
						IDs.Add(package.ID);
					}
				}

				foreach (Int32 id in IDs)
				{
					Package_Display.Items.Add(id);
				}

				isFirstStateChange = false;
			}
		}
		}
}
