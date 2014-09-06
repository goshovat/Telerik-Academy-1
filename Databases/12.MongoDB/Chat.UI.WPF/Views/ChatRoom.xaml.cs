namespace Chat.UI.WPF.Views
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    using Chat.Controler;
    using System.Collections.Generic;
    using Chat.Models;

    /// <summary>
    /// Interaction logic for ChatRoom.xaml
    /// </summary>
    public partial class ChatRoom : UserControl
    {
        private int lastMessageNumber = 0;
        private bool showAllPosts = true;
        private bool changedState = false;

        public ChatRoom()
        {
            InitializeComponent();
            StarRefreshing();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var messageText = this.txtMessage.Text;

            if (string.IsNullOrWhiteSpace(messageText))
            {
                MessageBox.Show("The message cannot be null or whitespace!",
                   "Error",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error);
            }
            else
            {
                ChatControler.Controller.InsertMessage(messageText);

                this.txtMessage.Text = string.Empty;

                this.lbMessages.Items.Clear();
                FillMessages();
            }
        }

        private void FillMessages()
        {
            var messages = GetMessage();

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
            var messages = GetMessage();
            
            if ((messages.Count != lastMessageNumber) || this.changedState)
            {
                this.lbMessages.Items.Clear();
                FillMessages();
                this.changedState = false;
            }
        }

        private List<Message> GetMessage()
        {
            List<Message> messages;

            if (showAllPosts)
            {
                messages = ChatControler.Controller.GetAllMessages();
            }
            else
            {
                messages = ChatControler.Controller.GetAllMessagesSinceUserLogged();
            }

            return messages;
        }

        private void btnAllPosts_Click(object sender, RoutedEventArgs e)
        {
            this.showAllPosts = true;
        }

        private void btnSinceLogged_Click(object sender, RoutedEventArgs e)
        {
            this.showAllPosts = false;
        }

        private void dbPostFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var stateBefore = this.showAllPosts;
            this.showAllPosts = this.dbPostFilter.SelectedIndex == 0 ? true : false;
            var stateAfter = this.showAllPosts;

            this.changedState = stateBefore ^ stateAfter;
         }
    }
}
