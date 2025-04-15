using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Views;
public partial class VehicleDetails : ContentPage
{

    private string payload = "";

    public VehicleDetails()
    {
        InitializeComponent();
    }

    private void Button_Clicked_Process_Payload(object sender, EventArgs e)
    {
        payload = EditorPayload.Text;
        ProcessPayload();
    }

    private void ProcessPayload()
    {
        string[] tokens = payload.Split("T_", StringSplitOptions.None);

        foreach (string item in tokens)
        {
            string _item = "T_" + item;
            if (_item.Contains(VehicleDetailsTokens.T_TITLE_1))
            {
                // Label to be put at the GUI
                Label _label = CreateTitle1Label(_item);
                ContentBlock.Children.Add(_label);
                // Line below title (congruent with Mercedes Benz style).
                BoxView _line = CreateWhiteLineForTitle1();
                ContentBlock.Children.Add(_line);
                continue;
            }
        }
    }

    private Label CreateTitle1Label(string token)
    {
        string _token = token.Replace(VehicleDetailsTokens.T_TITLE_1, "");
        Label newLabel = new()
        {
            Text = _token,
            FontSize = 24,
            TextColor = Colors.White
        };
        return newLabel;
    }

    private BoxView CreateWhiteLineForTitle1()
    {
        BoxView line = new()
        {
            HeightRequest = 2,
            WidthRequest = 25,
            HorizontalOptions = LayoutOptions.Start,
            Color = Colors.White
        };
        return line;
    }
}
