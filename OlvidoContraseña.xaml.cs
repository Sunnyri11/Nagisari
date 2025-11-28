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
    /// Lógica de interacción para OlvidoContraseña.xaml
    /// </summary>
    public partial class OlvidoContraseña : Window
    {
        public OlvidoContraseña()
        {
            InitializeComponent();
        }

        private void ResContra(object sender, RoutedEventArgs e)
        {
            string usi = "", contra = "";
            try
            {
                usi = cuenta.Text;
                if (!string.IsNullOrEmpty(usi))
                {
                    string ruta = System.IO.Path.Combine("Cuentas", usi + ".txt");
                    if (File.Exists(ruta))
                    {
                        Iniciar_Sesion inic = new Iniciar_Sesion();
                        contra = passwi.Text;
                        var verfi = MessageBox.Show($"¿Desea cambiar de contraseña?", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (verfi == MessageBoxResult.Yes)
                        {
                            File.WriteAllText(ruta, contra);
                            MessageBox.Show($"Cambio de contraseña existoso","Aviso",MessageBoxButton.OK,MessageBoxImage.Information);
                            Close();
                            inic.Show();
                        }
                        else
                        {
                            MessageBox.Show("Volviendo a iniciar sesion....");
                            Close();
                            inic.Show();
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
    }
}
