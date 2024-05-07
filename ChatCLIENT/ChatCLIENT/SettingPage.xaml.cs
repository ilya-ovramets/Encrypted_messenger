using System.Net;

namespace ChatCLIENT;

public partial class SettingPage : ContentPage
{
	public SettingPage()
	{
		InitializeComponent();
		HostEntry.Text = Configuration.host;
		PortEntry.Text = Configuration.port;
	}

    private void ChengHostPort(object sender, EventArgs e)
    {
        string host = HostEntry.Text.Trim();
        string portString = PortEntry.Text.Trim();

        // Перевірка коректності хоста
        if (!ValidateHost(host))
        {
            HostEntry.BackgroundColor = Color.FromHex("#F97971");

            return;
        }

        // Перевірка коректності порту
        if (!ValidatePort(portString))
        {
            PortEntry.BackgroundColor = Color.FromHex("#F97971");

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

}