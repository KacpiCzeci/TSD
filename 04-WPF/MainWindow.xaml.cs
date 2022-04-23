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
using HomeLibrary;

namespace _04_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Book> bookList;
        public MainWindow()
        {
            InitializeComponent();
            this.bookList = MyBookCollection.GetMyCollection();
            this.BookList.ItemsSource = this.bookList;
        }

        public void addComponent(object sender, RoutedEventArgs e){
            if(this.BookList.SelectedIndex != -1){
                this.BookList.UnselectAll();
                this.Details.Visibility = Visibility.Hidden;
                this.Add.Visibility = Visibility.Visible;
            }
            else if(this.Add.Visibility == Visibility.Visible) {
                if(string.IsNullOrEmpty(this.ID.Text) || string.IsNullOrEmpty(this.Author.Text) || string.IsNullOrEmpty(this.Title.Text) || string.IsNullOrEmpty(this.Year.Text)){
                    MessageBox.Show("Please provide all data!");
                }
                else if(!int.TryParse(this.ID.Text, out _) || !int.TryParse(this.Year.Text, out _)){
                    MessageBox.Show("Wrong data!");
                }
                else{
                    bookList.Add(new Book(int.Parse(this.ID.Text)){ 
                        Author = this.Author.Text, 
                        Format = this.Format.SelectedItem == null? BookFormat.PaperBack: (BookFormat)this.Format.SelectedItem, 
                        IsRead = this.IsRead.IsChecked ?? false, 
                        Title = this.Title.Text, 
                        Year= int.Parse(this.Year.Text)
                    });
                    this.ID.Clear();
                    this.Author.Clear();
                    this.Format.SelectedItem = -1;
                    this.IsRead.IsChecked = false; 
                    this.Title.Clear();
                    this.Year.Clear();
                    this.BookList.Items.Refresh();
                }
            }
        }

        public void showDetails(object sender, MouseButtonEventArgs e){
            if (e.ClickCount == 1 && Keyboard.Modifiers == ModifierKeys.Control) {
                this.Details.Visibility = Visibility.Hidden;
                this.Add.Visibility = Visibility.Visible;
            }
            if (e.ClickCount == 1 && (Keyboard.Modifiers & ModifierKeys.Control) == 0) {
                this.Add.Visibility = Visibility.Hidden;
                this.Details.Visibility = Visibility.Visible;
            }
        }

        public void outerButton(object sender, RoutedEventArgs e){
            if(this.BookList.SelectedIndex != -1){
                bookList.Remove((Book)this.BookList.SelectedItem);
                this.BookList.Items.Refresh();
            }
            this.Details.Visibility = Visibility.Hidden;
        } 

        public void innerButton(object sender, RoutedEventArgs e){
            if(this.BookList.SelectedIndex != -1){
                MessageBox.Show("Book was deleted!");
            }
        }

        public void sliderChange(object sender, RoutedPropertyChangedEventArgs<double> e){
            int value = (int)(this.Slider.Value) > 255? 255: (int)(this.Slider.Value) < 0? 0: (int)(this.Slider.Value);
            this.fgrid.Background = new SolidColorBrush(Color.FromArgb((byte)value, 0, (byte)value, 100));
        } 
    }

    public class ColorConverter : IValueConverter{
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture){
            BookFormat format = (BookFormat)value;
            if(format == BookFormat.PaperBack){
                return Brushes.Gainsboro;
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture){
            throw new NotImplementedException();
        }
    }

    public class StyleConverter : IValueConverter{
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture){
            bool isRead = (bool)value;
            if(isRead == true){
                return (Style)Application.Current.FindResource("ItemTextBlack");
            }
            return (Style)Application.Current.FindResource("ItemTextRed");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture){
            throw new NotImplementedException();
        }
    }
}
