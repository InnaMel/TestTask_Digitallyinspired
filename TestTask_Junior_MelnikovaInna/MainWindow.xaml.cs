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
using TestTask_Junior_MelnikovaInna.Model;
using TestTask_Junior_MelnikovaInna.ViewModels;

namespace TestTask_Junior_MelnikovaInna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // *** Created new styles for event tracking of task check (highlighted or not)
        Style classicTaskStyle = new Style();
        Style highlightedTaskStyle = new Style();

        private void WindowHasLoaded(object obj, RoutedEventArgs e)
        {
            ListModel newListTasks = new ListModel();
            ItemsControl someIC = (ItemsControl)GetTemplateChild("myList");
            someIC.ItemsSource = newListTasks.ListTasks;

            getClassicTaskStyle();
            gethighlightedTaskStyle();
        }

        public void getClassicTaskStyle()
        {
            classicTaskStyle.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(Colors.Transparent)));
            classicTaskStyle.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(0)));
            classicTaskStyle.Setters.Add(new Setter(Control.ForegroundProperty, new SolidColorBrush(Colors.Black)));
            classicTaskStyle.Setters.Add(new Setter(Control.FontFamilyProperty, new FontFamily("DidactGothic-Regular.ttf")));
            classicTaskStyle.Setters.Add(new Setter(Control.FontSizeProperty, 14.0));
        }
        public void gethighlightedTaskStyle()
        {
            highlightedTaskStyle.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(Color.FromRgb(141, 141, 141))));
            highlightedTaskStyle.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(0)));
            highlightedTaskStyle.Setters.Add(new Setter(Control.ForegroundProperty, new SolidColorBrush(Color.FromRgb(255, 255, 255))));
            highlightedTaskStyle.Setters.Add(new Setter(Control.FontFamilyProperty, new FontFamily("DidactGothic-Regular.ttf")));
            highlightedTaskStyle.Setters.Add(new Setter(Control.FontSizeProperty, 14.0));
        }

        // *** Remember last choosing object
        object lasthighlightedTask = new Button();
        public void checkhighlighted(object obj)
        {
            if (lasthighlightedTask != obj)
            {
                (obj as Button).Style = highlightedTaskStyle;
                (lasthighlightedTask as Button).Style = classicTaskStyle;
            }
        }

        // *** Method which generates showing relevant views
        private void Show_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            object tag = ((Button)e.OriginalSource).Tag;
            checkhighlighted(tag);

            lasthighlightedTask = tag;

            string currentContent = (tag as Button).Content.ToString();

            #region
            if (currentContent != null)
            {
                switch (currentContent)
                {
                    case "Task3":
                        DataContext = new Task3ViewModel();
                        break;
                    case "Task4":
                        DataContext = new Task4ViewModel();
                        break;
                    case "Task5":
                        DataContext = new Task5ViewModel();
                        break;
                    default:
                        break;
                }
            }
            #endregion
        }

        // *** Methods for state buttons main window
        #region
        private void ButtonClose(object obj, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonMaximizing(object obj, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void ButtonMinimazing(object obj, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

    }

    public partial class TasksWindowCommand
    {
        static TasksWindowCommand()
        {
            ShowView = new RoutedCommand("show", typeof(MainWindow));
        }
        public static RoutedCommand ShowView { get; set; }
    }
}