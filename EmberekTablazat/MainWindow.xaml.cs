using System;
using System.Collections.Generic;
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

namespace EmberekTablazat
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
			List<Ember> lista= new List<Ember>();
		public MainWindow()
		{
			InitializeComponent();
			lista.Add(new Ember("Gipsz Jakab", 42));
			lista.Add(new Ember("Lakatos Béla", 142));
			lista.Add(new Ember("Zajacz Korcs", 20));

			emberek.ItemsSource=lista;
		}

		private void hozzaadgomb_Click(object sender, RoutedEventArgs e)
		{
			string nev = nevtext.Text;
			if (string.IsNullOrEmpty(nev))
			{
				MessageBox.Show("Név mező kitöltése kötelező!", "Hiba");
				return;
			}
			if (!int.TryParse(kortext.Text, out int kor) || kor < 0 || kor > 200)
			{
				MessageBox.Show("Kor mező érvénytelen vagy nincs megadva!", "Hiba");
				return;
			}
			Ember Dzsoni=new Ember(nevtext.Text,Convert.ToInt32(kortext.Text));
			lista.Add(Dzsoni);
			emberek.Items.Refresh();
			nevtext.Clear();
			kortext.Clear();
		}

		private void torolgomb_Click(object sender, RoutedEventArgs e)
		{

			if (emberek.SelectedItem is Ember selectedEmber)
			{
				lista.Remove(selectedEmber);
				emberek.Items.Refresh();
			}
			else
			{
				MessageBox.Show("Kérjük válasszon ki egy embert a törléshez.");
			}
		}
	}
}
