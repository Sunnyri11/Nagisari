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
using System.IO;
namespace Sistema_de_Certificados
{
    /// <summary>
    /// Lógica de interacción para Crear_Fondo.xaml
    /// </summary>
    public partial class Crear_Fondo : Window
    {
        static string cuenta = "", ruting="";
        public Crear_Fondo(string usuario)
        {
            InitializeComponent();
            cuenta= usuario;
        }

        private void Avanzar(object sender, RoutedEventArgs e)
        {
            var compro=MessageBox.Show($"¿Desea usar esta plantilla?","Confirmacion",MessageBoxButton.YesNo,MessageBoxImage.Warning);
            if (compro == MessageBoxResult.Yes)
            {
                Datos dis = new Datos(ruting, cuenta);
                Close();
                dis.Show();
            }
            else
            {
                Imagen.Source = null;
            }
        }
        private void Retroceso(object sender, RoutedEventArgs e)
        {
            Inicio inici = new Inicio(cuenta);
            Close();
            inici.Show();
        }

        private void Subir(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fondo = new Microsoft.Win32.OpenFileDialog();
            fondo.Filter = "Archivos de imagen (*.jpg;*.png)|*.jpg;*.png";
            if (fondo.ShowDialog() == true)
            {
                ruting = fondo.FileName;
                Imagen.Source = new BitmapImage(new Uri(ruting));
            }
        }
    }
}
