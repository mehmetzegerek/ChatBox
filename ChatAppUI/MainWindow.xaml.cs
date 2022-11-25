using ChatAppUI.MVVM.Model;
using ChatBot.Business.ChatBot.Manager.Concrete;
using ChatBot.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatAppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Student> Messages = new ObservableCollection<Student>();
        Sender sender1 = new Sender();
        public MainWindow()
        {
            InitializeComponent();
            this.Topmost = true;
            
            

            Chat.ItemsSource = Messages;
            Chat.SelectedIndex = Chat.Items.Count - 1;
            Chat.ScrollIntoView(Chat.SelectedItem);
        }

        private void brdHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;




        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            sender1.IsDone();
            Application.Current.Shutdown();
        }

        

        private async void messageBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    await sendMessage();
            //    messageBox.Text = "";

                
            //}
        }

        private void Send_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }


        // Login Screen

        ThicknessAnimation thicknessAnimation = new ThicknessAnimation();
        DoubleAnimation doubleAnimation = new DoubleAnimation();

        private void positionAnimation(FrameworkElement obj,Thickness oldPosition,Thickness newPosition, DependencyProperty property, Int32 speed)
        {
            thicknessAnimation.From = oldPosition;
            thicknessAnimation.To = newPosition;
            thicknessAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(speed));
            Timeline.SetDesiredFrameRate(thicknessAnimation, null);
            thicknessAnimation.EasingFunction = new QuarticEase();
            obj.BeginAnimation(property, thicknessAnimation);
        }

        private void scaleAnimation(FrameworkElement obj, double old, double newS, DependencyProperty property, Int32 speed)
        {
            doubleAnimation.From = old;
            doubleAnimation.To = newS;
            doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(speed));
            Timeline.SetDesiredFrameRate(doubleAnimation, null);
            thicknessAnimation.EasingFunction = new QuarticEase();
            obj.BeginAnimation(property, doubleAnimation);
        }

        private bool stack = false;

        private void loginPage_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!stack)
            {
                // position animation
                positionAnimation(deneme, deneme.Margin, new Thickness(0, -200, 0, 0), MarginProperty, 800);
                positionAnimation(LoginContent, LoginContent.Margin, new Thickness(0, 75, 0, 0), MarginProperty, 800);


                // ellipse scale animation
                scaleAnimation(deneme, deneme.Width, 100, WidthProperty, 400);
                scaleAnimation(deneme, deneme.Height, 100, HeightProperty, 400);
            }
            
        }

        private void loginPage_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!stack)
            {
                // position animation
                positionAnimation(deneme, deneme.Margin, new Thickness(0, -50, 0, 0), MarginProperty, 320);
                positionAnimation(LoginContent, LoginContent.Margin, new Thickness(0, 450, 0, 0), MarginProperty, 270);


                // ellipse scale animation
                scaleAnimation(deneme, deneme.Width, 150, WidthProperty, 350);
                scaleAnimation(deneme, deneme.Height, 150, HeightProperty, 350);
            }
            
        }

        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            stack = true;

        }

        private void TextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            stack = false;
        }


        private async Task browserReady(string url,int delay)
        {
            StatusLbl.Content = "Bağlanılıyor..";
            await Task.Run(() => sender1.BrowserReady(url, delay));
        }

        private async Task sendMessage()
        {
            if (messageBox.Text != "")
            {
                await Task.Run(() => Dispatcher.Invoke(() => sender1.SendMessage(messageBox.Text)));
                //Messages.Add(new Student() { FirstMessage = false,Message = messageBox.Text,Time = DateTime.Now});


            }
        }

        private async Task getData()
        {
            
            var message =await Task.Run(() => sender1.GetData());
            
            //var std = Messages.FirstOrDefault(o => o.Message != message.Message);
            if (message != null)
            {
                Messages.Add((Student)message);
            }
            
        }
        
        private async void btnUrlSend_Click(object sender, RoutedEventArgs e)
        {

            
            if (tbxUrl.Text.StartsWith("https://eu.bbcollab.com/guest/"))
            {
                loginBrd.Visibility = Visibility.Hidden;
                ChatPage.Visibility = Visibility.Visible; 
                string url = tbxUrl.Text;
                await browserReady(url, 500);

                StatusLbl.Content = "Çevrimiçi";
                while (true)
                {
                    await getData();
                }
            }
            else
            {
                MessageBox.Show("Hatalı url girildi lütfen tekrar deneyin!");
                tbxUrl.Text = "";
            }
            
        }

        private void Chat_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.OriginalSource is ScrollViewer scrollViewer &&
                Math.Abs(e.ExtentHeightChange) > 0.0)
            {
                scrollViewer.ScrollToBottom();
            }
        }
    }
}
