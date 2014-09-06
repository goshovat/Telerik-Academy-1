namespace Chat.UI.WPF.Views
{
    using System.Windows;
    using System.Windows.Controls;

    using Chat.Controler;
    using Chat.UI.WPF.Controller;
    using System;

    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : UserControl
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = StartWindow.GetMainWindow(this);
            mainWindow.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = this.txtUsername.Text;
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("The username cannot be null or whitespace!",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                var mainWindow = StartWindow.GetMainWindow(this);
                mainWindow.chatRoom.Visibility = Visibility.Visible;
                mainWindow.logIn.Visibility = Visibility.Hidden;

                ChatControler.Controller.LoggedUser.Username = username;
                ChatControler.Controller.UserLoggedTime = DateTime.Now;
            }
        }
    }
}
