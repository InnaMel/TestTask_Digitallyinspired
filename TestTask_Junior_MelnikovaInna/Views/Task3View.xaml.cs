using HelixToolkit.Wpf;
using Microsoft.Win32;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestTask_Junior_MelnikovaInna.Views
{
    /// <summary>
    /// Interaction logic for Task3View.xaml
    /// </summary>
    public partial class Task3View : UserControl
    {
        public Task3View()
        {
            InitializeComponent();
        }
        private void Load_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            model3D.Content = new Model3DGroup();

            // *** Opening dialog for choosing the object
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Obj files (*.obj)| *.obj";

            string objectsPath = Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar + "3DObjects";
            openFileDialog.InitialDirectory = objectsPath;

            // *** Getting full path of the object
            string fullPath = "Empty";
            try
            {
                if (openFileDialog.ShowDialog() == true)
                    fullPath = openFileDialog.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops, something went wrong ->" + ex.Message);
            }

            // *** Getting directly the object
            ObjReader CurrentHelixObjReader = new ObjReader();
            Model3DGroup MyModel;

            try
            {
                MyModel = CurrentHelixObjReader.Read(fullPath);
            }
            catch (Exception)
            {
                MessageBox.Show("You haven`t selected any objects! \nCath the teapot :)");
                var teaPot = new Teapot();
                MyModel = CurrentHelixObjReader.Read(Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar + "3DObjects" + System.IO.Path.DirectorySeparatorChar + "Teapot.obj");
            }


            // *** Filling our object into the scene
            previewText.Text = String.Empty;
            model3D.Content = MyModel;
        }

        private void Clear_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            model3D.Content = new Model3DGroup();
        }
    }


    public class Task3WindowCommand
    {
        static Task3WindowCommand()
        {
            Load = new RoutedCommand("Load", typeof(UserControl));
            Clear = new RoutedCommand("Clear", typeof(UserControl));
        }
        public static RoutedCommand Load { get; set; }
        public static RoutedCommand Clear { get; set; }
    }
}