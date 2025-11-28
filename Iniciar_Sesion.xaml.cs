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
    /// Lógica de interacción para Iniciar_Sesion.xaml
    /// </summary>
    public partial class Iniciar_Sesion : Window
    {
        static string verusi="";
        //static string vercont="";
        public Iniciar_Sesion()
        {
            InitializeComponent();
        }
        /*public Iniciar_Sesion(string usuario, string password)
        {
            InitializeComponent();
            verusi = usuario;
            vercont = password;
        }*/
        private void CrearCuenta(object sender, RoutedEventArgs e)
        {
            Crear_Cuenta crear= new Crear_Cuenta();
            Close();
            crear.Show();
        }

        private void IniciaSesion(object sender, RoutedEventArgs e)
        {
            string usi = "", contra = "";
            try
            {
                usi = cuenta.Text;
                contra = passwi.Password;
                Error(usi, contra);
                if (!string.IsNullOrEmpty(usi))
                {
                    string ruta = System.IO.Path.Combine("Cuentas", usi + ".txt");
                    if (File.Exists(ruta))
                    {
                        string vercont = File.ReadAllText(ruta);
                        if (contra == vercont)
                        {
                            MessageBox.Show($"Iniciando sesion de {usi}.......", "Inicio de Sesion exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                            Inicio ini = new Inicio(usi);
                            Close();
                            ini.Show();
                        }
                        else
                        {
                            MessageBox.Show($"Contraseña incorrecta", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                            MessageBox.Show($"Eliminacion de cuenta", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Cuenta no encontrada", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"NO SE INGRESO NINGUN TIPO DE USUARIO/CONTRASEÑA", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Error(string usi, string contra)
        {
            if(string.IsNullOrWhiteSpace(usi))
            {
                ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("");
                return;
            }
            if(string.IsNullOrEmpty(contra))
            {
                ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("");
                return;
            }
        }

        private void olvidinC(object sender, RoutedEventArgs e)
        {
            OlvidoContraseña oc = new OlvidoContraseña();
            Hide();
            oc.Show();
        }
    }
}
