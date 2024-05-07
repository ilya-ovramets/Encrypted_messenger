using ChatCLIENT.Coding_Method;
using ChatCLIENT.DAL;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ChatCLIENT
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        ObservableCollection<string> messages = new ObservableCollection<string>();
        string newMessage;

        WebSocketClient client = new WebSocketClient();

        MessageHandler handler = null;

        public event PropertyChangedEventHandler PropertyChanged;

        private bool conectionFlag = false;

        public ObservableCollection<string> Messages
        {
            get { return messages; }
            set
            {
                messages = value;
                OnPropertyChanged();
            }
        }

        public string NewMessage
        {
            get { return newMessage; }
            set
            {
                newMessage = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            handler = new MessageHandler();
            
        }

        private async Task Conect()
        {
            client = new WebSocketClient();
            await client.ConnectAsync(Configuration.host, int.Parse(Configuration.port));

        }
        private async Task Disconect()
        {
            
            await client.CloseAsync();

        }


        void ChangeCodingButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CodingPage());
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void OnSendClicked(object sender, EventArgs e)
        {
            SendMessage();
        }

        void OnMessageEntryCompleted(object sender, EventArgs e)
        {
            SendMessage();
        }

        async void SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(NewMessage))
            {
                Messages.Add(NewMessage);
                AddMessageToStack(NewMessage);
                await client.SendMessageAsync(handler.ShanonAlgCode(NewMessage));

                NewMessage = string.Empty;
            }
        }
        void AddMessageToStack(string message)
        {
            var frame = new Frame
            {
                Content = new Label
                {
                    Text = message,
                    FontSize = 18,
                    FontFamily = "Times New Roman",
                    TextColor = Color.FromHex("#FFFFFF"),
                    Padding = 10,

                },
                BackgroundColor = Color.FromHex("#6b00e9"),
                Padding = 2,
                Margin = new Thickness(0, 0, 0, 5),
                CornerRadius = 10,
                HorizontalOptions = LayoutOptions.End,

            };

            MessagesStack.Children.Add(frame);
            MessagesScrollView.ScrollToAsync(frame, ScrollToPosition.End, true); // Автоматична прокрутка до нового повідомлення
        }

        private void Button_Conect(object sender, EventArgs e)
        {
            if(conectionFlag == false)
            {
                Conect();
                Conect_B.Background = Color.FromRgb(0, 255, 0);
                Conect_B.Text = "Coneted";
                conectionFlag = true;
            }
            else
            {
                Disconect();
                Conect_B.Background = Color.FromRgb(255, 0, 0);
                Conect_B.Text = "Disconected";
                conectionFlag = false;
            }

        }




        private void SettingButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingPage());
               
        }
    }
}
