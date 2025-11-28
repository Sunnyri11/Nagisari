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
using ClosedXML.Excel;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sistema_de_Certificados
{
    /// <summary>
    /// Lógica de interacción para Datos.xaml
    /// </summary>
    public partial class Datos : Window
    {
        private bool modoFinal = false;
        static List<Datos> datos;
        static string usi= "";
        static string certi;
        private bool isDragging = false;
        private Point clickPosition;
        private UIElement draggedElement;
        public Datos(string certificado,string usuario)
        {
            InitializeComponent();
            usi=usuario;
            certi=certificado;
            ImageBrush fondo = new ImageBrush();
            fondo.ImageSource = new BitmapImage(new Uri(certi));
            CertificadoComplete.Background = fondo;
        }

        private void Añadir(object sender, RoutedEventArgs e)
        {
            // Actualizar datos
            CertificadoLabel.Text = "Nuevo Nombre";
            CertificadoLabel.FontSize = SelectorNombreSize.Value;
            CertificadoLabel.FontFamily = FontSelector.SelectedItem as FontFamily;
            CertificadoLabel.Foreground = new SolidColorBrush(
                (Color)ColorConverter.ConvertFromString((ColorSelector.SelectedItem as ComboBoxItem).Content.ToString()));

            CertificadoCodigo.Text = "Nuevo Código";
            CertificadoCodigo.FontSize = SelectorCodigoSize.Value;
            CertificadoCodigo.FontFamily = FontSelector.SelectedItem as FontFamily;
            CertificadoCodigo.Foreground = CertificadoLabel.Foreground;

            ImagenQR.Width = SelectorImagenSize.Value;
            ImagenQR.Height = SelectorImagenSize.Value;
            ImagenQR.Source = new BitmapImage(new Uri("nuevoQR.png", UriKind.Relative));

            // Cambiar a modo final
            HerramientasPanel.Visibility = Visibility.Collapsed; // oculta herramientas
            modoFinal = true;
        }

        private void Elemento_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (modoFinal) return; // si ya está en modo final, no se mueve
            draggedElement = sender as UIElement;
            isDragging = true;
            clickPosition = e.GetPosition(CertificadoCanvas);
            draggedElement.CaptureMouse();
        }

        private void Elemento_MouseMove(object sender, MouseEventArgs e)
        {
            if (modoFinal) return; // bloquea movimiento en modo final
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
            if (modoFinal) return; // bloquea movimiento en modo final
            isDragging = false;
            if (draggedElement != null)
                draggedElement.ReleaseMouseCapture();
            draggedElement = null;
        }

        private void Guardar(object sender, RoutedEventArgs e)
        {
            // Aquí iría la lógica para capturar CertificadoComplete y exportar
            MessageBox.Show("Guardado!");
        }
    }
}
