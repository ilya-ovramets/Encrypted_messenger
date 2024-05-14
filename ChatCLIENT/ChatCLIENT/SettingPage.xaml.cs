using ChatCLIENT.Coding_Method;
using System.Net;

namespace ChatCLIENT;

public partial class SettingPage : ContentPage
{
    Dictionary<string, MessageHandler> codingMethod = new Dictionary<string, MessageHandler>();
	
    private void FillDict()
    {
        codingMethod.Add("Permutation Method",new PermutationMethod());
        codingMethod.Add("RSA Method", new RSAMethod());
    }

    private void FirstValue()
    {
        
        foreach (var method in codingMethod)
        {
            if (Configuration.SecondCodingMethod.GetType() == method.Value.GetType())
            {
                CodingPicker.SelectedItem = method.Key;
                break;
            }
        }

    }


    public SettingPage()
	{
		InitializeComponent();
		HostEntry.Text = Configuration.host;
		PortEntry.Text = Configuration.port;
        letterList.Text = Configuration.Language;
        permutNum.Text = Configuration.permutationNumber.ToString();
        FillDict();

        CodingPicker.ItemsSource = codingMethod.Keys.ToList();

        FirstValue();
	}

    private async void ChengHostPort(object sender, EventArgs e)
    {
        string host = HostEntry.Text.Trim();
        string portString = PortEntry.Text.Trim();

        // Перевірка коректності хоста
        if (!ValidateHost(host))
        {
            await DisplayAlert("Wron Host", "Pleace write corect host like 127.0.0.1", "OK");

            return;
        }

        // Перевірка коректності порту
        if (!ValidatePort(portString))
        {
            await DisplayAlert("Wrong Port", "Pleace write corect host like 777", "OK");

            return;
        }

        HostEntry.BackgroundColor = Color.FromHex("#9B9CD5");
        PortEntry.BackgroundColor = Color.FromHex("#9B9CD5");

        // Збереження коректних значень хоста та порту
        Configuration.host = host;
        Configuration.port = portString;

    }

    private bool ValidateHost(string host)
    {
        // Перевірка, чи введений хост є коректною IP-адресою
        if (IPAddress.TryParse(host, out IPAddress ipAddress))
            return true;

        // Перевірка, чи введений хост є коректним доменним ім'ям
        try
        {
            IPAddress[] addresses = Dns.GetHostAddresses(host);
            return addresses.Length > 0;
        }
        catch
        {
            return false;
        }
    }

    private bool ValidatePort(string portString)
    {
        // Перевірка, чи введений порт є коректним числом
        if (!int.TryParse(portString, out int port))
            return false;

        // Перевірка, чи порт знаходиться в допустимому діапазоні
        return port > 0 && port <= 65535;
    }

    private void CodingPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedMethod = CodingPicker.SelectedItem.ToString();
        Configuration.SecondCodingMethod = codingMethod[selectedMethod];
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Configuration.Language = letterList.Text;

        if (!int.TryParse(permutNum.Text, out int num))
        {
            Configuration.permutationNumber = num;
        }
        else
        {
            await DisplayAlert("Exeption num", "Pleace write corect number like 3", "OK");
        }
    }

}