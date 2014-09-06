namespace Chat.UI.WPF.Views
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    using Chat.Controler;

    /// <summary>
    /// Interaction logic for ChatRoom.xaml
    /// </summary>
    public partial class ChatRoom : UserControl
    {
        private int lastMessageNumber = 0;

        public ChatRoom()
        {
            InitializeComponent();
            StarRefreshing();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var messageText = this.txtMessage.Text;

            ChatControler.Controller.InsertMessage(messageText);

            this.txtMessage.Text = string.Empty;

            this.lbMessages.Items.Clear();
            FillMessages();
        }

        private void FillMessages()
        {
            var messages = ChatControler.Controller.GetAllMessages();
            var usernamePattern = "Username: {0}";
            var messagePattern = "Message: {0}";
            var datePattern = "Date: {0}";

            foreach (var message in messages)
            {
                var stackPanel = new StackPanel();
                var textBlockUsername = new TextBlock();
                textBlockUsername.Text = string.Format(usernamePattern, message.User.Username);
                textBlockUsername.TextWrapping = TextWrapping.Wrap;
                textBlockUsername.FontWeight = FontWeights.Bold;
                stackPanel.Children.Add(textBlockUsername);

                var textBlockMessage = new TextBlock();
                textBlockMessage.Text = string.Format(messagePattern, message.Text);
                textBlockMessage.TextWrapping = TextWrapping.Wrap;
                stackPanel.Children.Add(textBlockMessage);

                var textBlockDate = new TextBlock();
                textBlockDate.Text = string.Format(datePattern, message.Date);
                textBlockDate.TextWrapping = TextWrapping.Wrap;
                stackPanel.Children.Add(textBlockDate);

                this.lbMessages.Items.Add(stackPanel);
            }

            lastMessageNumber = this.lbMessages.Items.Count;
            this.lbMessages.SelectedIndex = this.lbMessages.Items.Count - 1;
            this.lbMessages.ScrollIntoView(this.lbMessages.SelectedItem);
        }

        private void StarRefreshing()
        {

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(OnTimedEvent);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            var messages = ChatControler.Controller.GetAllMessages();
            if (messages.Count != lastMessageNumber)
            {
                this.lbMessages.Items.Clear();
                FillMessages();
            }
        }
    }
}
