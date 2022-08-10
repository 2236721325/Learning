using Microsoft.AspNetCore.SignalR.Client;
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

namespace SignalClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string user = Random.Shared.Next().ToString();
        HubConnection connection;
        public MainWindow()
        {

            InitializeComponent();
            connection = new HubConnectionBuilder()
              .WithUrl("https://localhost:7140/ChatHub")
              .Build();

        }

        private async void connectButton_Click(object sender, RoutedEventArgs e)
        {
          
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{user}: {message}";
                    txt.Text += newMessage+ "\r\n";
                });
            });
            try
            {
                await connection.StartAsync();
                txt.Text += "连接已开始\r\n";
            }
            catch (Exception ex)
            {
                txt.Text += ex.Message + "\r\n";
                txt.Text += ex + "\r\n";
            }
        }
        private async void sendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendMessageAsync",
                    user, userText.Text);
            }
            catch (Exception ex)
            {
                txt.Text += ex.Message + "\r\n";
            }
        }
    }
}
