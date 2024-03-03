using ChatCLIENT.Coding_Method.ShannonFano;

namespace ChatCLIENT;

public partial class CodingPage : ContentPage
{

    private List<Letter> data;
    private char[] UserInput;
    private Dictionary<char, string> letterCodeValues;

    public CodingPage()
	{

		InitializeComponent();
    }

   

    private async void CodingBTN(object sender, EventArgs e)
    {
        statusLB.Text = "Waited";
		string content = editor.Text;

        if(content == null)
        {
            await DisplayAlert("Exeption", "Pleace write some text", "OK");
            return;
        }


        try
        {
            UserInput = content.ToCharArray();
        }
        catch (Exception)
        {
            await DisplayAlert("Exeption", "Pleace write some text", "OK");
            return;
        }
        


        

        SortData userText_1 = new SortData(UserInput);
        data = userText_1.GetData();

        // Find count of all letters and split letters to char array
        // ----------------------------------------------------------------
        char[] AllLetters = new char[data.Count];
        int[] AllCount = new int[data.Count];

        int cnt = 0;
        foreach (var item in data)
        {
            AllLetters[cnt] = item.letter;
            AllCount[cnt] = item.count;
            cnt++;
        }
        // ----------------------------------------------------------------


        // Convert letters to Shannon code and save it like (letter --> code)
        // ----------------------------------------------------------------
        ShannonAlgorithm testData = new ShannonAlgorithm(AllLetters, AllCount);
        letterCodeValues = testData.GetLettersCode();
        // ----------------------------------------------------------------

        Configuration.SetValueLCV(letterCodeValues);

        statusLB.Text = "Complated";


    }
}