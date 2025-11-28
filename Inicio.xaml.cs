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
using System.Windows.Shapes;

namespace Sistema_de_Certificados
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        string usuario;
        public Inicio(string usuario)
        {
            InitializeComponent();
            Usi.Text = usuario;
        }

        private void CerrarSesion(object sender, RoutedEventArgs e)
        {
            MainWindow m1= new MainWindow();
            Close();
            m1.Show();
        }

        private void Añadir(object sender, RoutedEventArgs e)
        {
            Crear_Fondo cf= new Crear_Fondo(Usi.Text);
            Close();
            cf.Show();
        }
    }
}
