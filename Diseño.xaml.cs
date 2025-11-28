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
    /// Lógica de interacción para Diseño.xaml
    /// </summary>
    public partial class Diseño : Window
    {
        private bool isDragging = false;
        private Point clickPosition;
        private UIElement draggedElement;
        static string usuario = "";
        static string certi;
        public Diseño(string rutaImagen,string cuenta)
        {
            InitializeComponent();
            usuario = cuenta;
            certi = rutaImagen;
            ImageBrush fondo = new ImageBrush();
            fondo.ImageSource = new BitmapImage(new Uri(rutaImagen));
            fondo.Stretch = Stretch.UniformToFill;
            this.Background = fondo;
        }
        private void Elemento_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            draggedElement = sender as UIElement;
            isDragging = true;
            clickPosition = e.GetPosition(CertificadoCanvas);
            draggedElement.CaptureMouse();
        }

        private void Elemento_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedElement != null)
            {
                Point currentPosition = e.GetPosition(CertificadoCanvas);
                double offsetX = currentPosition.X - clickPosition.X;
                double offsetY = currentPosition.Y - clickPosition.Y;

                Canvas.SetLeft(draggedElement, Canvas.GetLeft(draggedElement) + offsetX);
                Canvas.SetTop(draggedElement, Canvas.GetTop(draggedElement) + offsetY);

                clickPosition = currentPosition;
            }
        }

        private void Elemento_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            if (draggedElement != null)
                draggedElement.ReleaseMouseCapture();
            draggedElement = null;
        }

        // --- Enviar posiciones y tamaños a la otra pantalla ---
        private void Confirmacion(object sender, RoutedEventArgs e)
        {
            var ventanaDatos = new Datos(usuario, certi);

            // --- Nombre ---
            var borderNombre = (UIElement)CertificadoText.Parent;
            ventanaDatos.CertificadoLabel.Text = CertificadoText.Text;
            ventanaDatos.CertificadoLabel.FontFamily = FontSelector.SelectedItem as FontFamily;
            ventanaDatos.CertificadoLabel.FontSize = SelectorNombreSize.Value;
            ventanaDatos.CertificadoLabel.Foreground = CertificadoText.Foreground;
            ventanaDatos.CertificadoLabel.SetValue(Canvas.LeftProperty, Canvas.GetLeft(borderNombre));
            ventanaDatos.CertificadoLabel.SetValue(Canvas.TopProperty, Canvas.GetTop(borderNombre));

            // --- Código ---
            var borderCodigo = (UIElement)CertificadoCodigo.Parent;
            ventanaDatos.CertificadoCodigo.Text = CertificadoCodigo.Text;
            ventanaDatos.CertificadoCodigo.FontFamily = FontSelector.SelectedItem as FontFamily;
            ventanaDatos.CertificadoCodigo.FontSize = SelectorCodigoSize.Value;
            ventanaDatos.CertificadoCodigo.Foreground = CertificadoCodigo.Foreground;
            ventanaDatos.CertificadoCodigo.SetValue(Canvas.LeftProperty, Canvas.GetLeft(borderCodigo));
            ventanaDatos.CertificadoCodigo.SetValue(Canvas.TopProperty, Canvas.GetTop(borderCodigo));
            var borderQR = (UIElement)ImagenQR.Parent;
            ventanaDatos.ImagenQR.Width = SelectorImagen.Value;
            ventanaDatos.ImagenQR.Height = SelectorImagen.Value;
            ventanaDatos.ImagenQR.SetValue(Canvas.LeftProperty, Canvas.GetLeft(borderQR));
            ventanaDatos.ImagenQR.SetValue(Canvas.TopProperty, Canvas.GetTop(borderQR));

            Close();
            ventanaDatos.Show();
        }
    }
}
