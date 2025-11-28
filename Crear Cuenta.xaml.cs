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
using System.IO;
namespace Sistema_de_Certificados
{
    /// <summary>
    /// Lógica de interacción para Crear_Cuenta.xaml
    /// </summary>
    public partial class Crear_Cuenta : Window
    {
        static string cuentam="";
        static string contraseña="";
        public Crear_Cuenta()
        {
            InitializeComponent();
        }

        private void CrearCuenta(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(usuario.Text) && !string.IsNullOrWhiteSpace(password.Text))
            {
                cuentam = usuario.Text;
                contraseña = password.Text;
                string c1=cuentam.ToUpper();
                Directory.CreateDirectory("Cuentas");
                string ruta ="Cuentas\\"+c1+".txt";
                File.WriteAllText(ruta, contraseña);
                MessageBox.Show($"Cuenta creada existosamente", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Iniciar_Sesion ini = new Iniciar_Sesion();
                ini.Show();
                Close();
            }
            else
            {
                MessageBox.Show($"NO SE INGRESO NINGUN TIPO DE USUARIO/CONTRASEÑA", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
