using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Windows.Forms;



namespace Entity_podejscie_5
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Ubrania3Entities db;
        public MainWindow()
        {

        }

        private void dgUbrania_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Ubrania3Entities();
            dgUbrania.ItemsSource = db.tbl_ubrania3.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {



            tbl_ubrania3 noweubranie = new tbl_ubrania3();


            noweubranie.TYP = TYP_COMBO.Text;
            noweubranie.KOLOR = Kolor_Combo.Text;
            noweubranie.ROZMIAR = rozmiar_combo.Text;
            noweubranie.MARKA = MARKA_TXT.Text;
            noweubranie.OPIS = OPIS_TXT.Text;
            noweubranie.CENA = Convert.ToInt16(CENA_TXT.Text);
            db.tbl_ubrania3.Add(noweubranie);
            db.SaveChanges();


            dgUbrania.ItemsSource = db.tbl_ubrania3.ToList();



        }

        private void TYP_COMBO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DELETE_Click(object sender, RoutedEventArgs e)
        {

            if (dgUbrania.SelectedItem != null)
            {
                tbl_ubrania3 temp = (tbl_ubrania3)dgUbrania.SelectedItem;
                db.tbl_ubrania3.Remove(temp);
                db.SaveChanges();
                dgUbrania.Items.Refresh();
                dgUbrania.ItemsSource = db.tbl_ubrania3.ToList();
                System.Windows.MessageBox.Show("Witam szanownie");
            }

        }

   /*    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource tbl_ubrania3ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tbl_ubrania3ViewSource")));
          //  System.Windows.Data.CollectionViewSource mealViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("mealViewSource")));

            db.tbl_ubrania3.Load();
            //   _db.Meals.Load();

            tbl_ubrania3ViewSource.Source = db.tbl_ubrania3.Local;
           /// foodViewSource.Source = _db.Foods.Local;

            //For filtering in foodDatagrid
          //_foodView = (CollectionView)CollectionViewSource.GetDefaultView(foodDataGrid.ItemsSource);
         //_foodView.Filter = FoodNameFilter;
        }
        */
    }
}
