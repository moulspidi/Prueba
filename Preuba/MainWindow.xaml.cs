using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;

namespace Preuba
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection cn = new SqlConnection();
        string cs = "Data Source=DESKTOP-BL6TV1O;Initial Catalog=Prueba;Integrated Security=True";
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public MainWindow()
        {
            InitializeComponent();

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            com.CommandText = "select * from pr where city like'%" + textbox1.Text.Replace("'", "''") + "%' ";
            dr = com.ExecuteReader();
            listbox1.Items.Clear();

            while (dr.Read())
            {
                listbox1.Items.Add(dr["Nom"] + " " + "|" + " " + dr["Tel"]);
            }
            dr.Close();
            textbox1.Clear();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cn.ConnectionString = cs;
            cn.Open();
            com.Connection = cn;
            com.CommandText = "select * from pr";
            dr = com.ExecuteReader();

            while (dr.Read())
            {

                listbox1.Items.Add(dr["Nom"] + " "+"|" +" "+dr["city"]+ " " + "|" +" "+ dr["Tel"]);
            }
            dr.Close();
        }

        private void Textbox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}