using LCSharpMBG7.Code.Logical;
using System.Diagnostics;

namespace LCSharpMBG7.Views;
public partial class VehicleDetails : ContentPage
{
    public VehicleDetails()
    {
        InitializeComponent();
        
        if (State.DevMode == true) return;
        DevTools.Children.Clear();
        ProcessPayload(State.vehicles[State.SelectedVehicleIndex].PageContent);
    }

    private void Button_Clicked_Process_Payload(object sender, EventArgs e)
    {
        ProcessPayload(EditorPayload.Text);
    }

    private void ProcessPayload(string _payload = "T_TITLE_2NO CONTENT PROVIDED")
    {
        string[] tokens = _payload.Split("T_", StringSplitOptions.None);

        Debug.WriteLine("PROCESSING PAYLOAD");

        foreach (string item in tokens)
        {
            string _item = "T_" + item.Replace("\r", "").Replace("\n", "").Replace(VehicleDetailsTokens.T_TS, "");
            if (_item == "T_") continue;
            Debug.Write(_item);

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
            if (_item.Contains(VehicleDetailsTokens.T_TITLE_2))
            {
                Label _label = CreateTitle2Label(_item);
                ContentBlock.Children.Add(_label);
                continue;
            }
            if (_item.Contains(VehicleDetailsTokens.T_TITLE_3))
            {
                Label _label = CreateTitle3Label(_item);
                ContentBlock.Children.Add(_label);
                continue;
            }
            if (_item.Contains(VehicleDetailsTokens.T_IMG))
            {
                Image img = CreateImageElement(_item);
                ContentBlock.Children.Add(img);
                continue;
            }
            if (_item.Contains(VehicleDetailsTokens.T_PP))
            {
                Label _label = CreateParagraph(_item);
                ContentBlock.Children.Add(_label);
                continue;
            }
            if (_item.Contains(VehicleDetailsTokens.T_BR))
            {
                BoxView space = CreateSpace(_item);
                ContentBlock.Children.Add(space);
                continue;
            }
            if (_item.Contains(VehicleDetailsTokens.T_RESERVA))
            {
                Button button = CreateReservaButton(_item);
                ContentBlock.Children.Add(button);
                continue;
            }
            if (_item.Contains(VehicleDetailsTokens.T_WEBVIEW))
            {
                CreateWebView(_item);
                continue;
            }
        }
    }

    private void CreateWebView(string token)
    {
        try
        {
            string[] _tokens = token
                .Replace(VehicleDetailsTokens.T_WEBVIEW, "")
                .Split("__", StringSplitOptions.None);

            if (_tokens == null || _tokens.Length != 2) return;

            var button = new Button
            {
                Text = _tokens[0],
                BorderWidth = 0,
                BackgroundColor = Colors.White,
                TextColor = Colors.Black,
                FontSize = 14,
                CornerRadius = 0,
                Padding = new Thickness(0, 17, 0, 17),
            };
            button.Clicked += (sender, e) =>
            {
                // Sets the URL to WebView.
                webViewElement.Source = _tokens[1];
                // Makes the WebView visible.
                webViewElement.HeightRequest = 500;
                webViewElement.HorizontalOptions = LayoutOptions.Fill;
            };
            ContentBlock.Children.Add(button);
        }
        catch(Exception e)
        {
            Debug.WriteLine(e);
            return;
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
            Color = Colors.White,
            Margin = new Thickness(0, 0, 0, 10)
        };
        return line;
    }

    private Label CreateTitle2Label(string token)
    {
        string _token = token.Replace(VehicleDetailsTokens.T_TITLE_2, "");
        Label newLabel = new()
        {
            Text = _token,
            FontSize = 27,
            TextColor = Colors.White,
            Margin = new Thickness(0, 10, 0, 10)
        };
        return newLabel;
    }
    private Label CreateTitle3Label(string token)
    {
        string _token = token.Replace(VehicleDetailsTokens.T_TITLE_3, "");
        Label newLabel = new()
        {
            Text = _token,
            FontSize = 22,
            TextColor = Colors.White,
            Margin = new Thickness(0, 18, 0, 10)
        };
        return newLabel;
    }

    private Image CreateImageElement(string token)
    {
        string _token = token.Replace(VehicleDetailsTokens.T_IMG, "");
        Image image = new Image
        {
            Source = _token,
            Aspect = Aspect.AspectFit,
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill
        };
        return image;
    }

    private Label CreateParagraph(string token)
    {
        string _token = token.Replace(VehicleDetailsTokens.T_PP, "");
        Label newLabel = new()
        {
            Text = _token,
            FontSize = 17,
            TextColor = Colors.White,
            Margin = new Thickness(0, 8, 0, 8)
        };
        return newLabel;
    }

    private BoxView CreateSpace(string token)
    {
        var spacer = new BoxView
        {
            HeightRequest = 0, // No visible height, just acts as a spacer
            Margin = new Thickness(0, 10, 0, 10),
            Opacity = 0 // Invisible
        };
        return spacer;
    }

    private Button CreateReservaButton(string token)
    {
        string _token = token.Replace(VehicleDetailsTokens.T_RESERVA, "");
        if (string.IsNullOrEmpty(_token)) _token = "Reservar";
        var reservaButton = new Button
        {
            Text = _token,
            BorderWidth = 0,
            BackgroundColor = Color.FromArgb("#007AFF"),
            TextColor = Colors.White,
            FontSize = 15,
            FontAttributes = FontAttributes.Bold,
            CornerRadius = 0,
            Padding = new Thickness(0, 21, 0, 21)
        };
        reservaButton.Clicked += Button_Clicked_Reserva;
        return reservaButton;
    }

    private void Button_Clicked_Clear(object sender, EventArgs e)
    {
        ContentBlock.Children.Clear();
    }

    private async void Button_Clicked_Reserva(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ReservationForm");
    }

    private void Button_Clicked_Process_Prepared_Payload(object sender, EventArgs e)
    {
        /*
        string _payload = @"T_TITLE_1Diseño
T_TITLE_2El primer Clase A en diseño de zaga escalonada.

T_IMGhttps://www.mercedes-benz.cr/documents/17944382/45813184/Galeria_EXTERIOR-1.jpg


T_TITLE_3Diseño exterior


T_PPTecho suavemente descendente. Fascinación claramente en ascenso. Cuando de pequeños dibujábamos un auto, intuitivamente trazábamos un modelo de tres volúmenes. Con el Clase A Sedán puedes volver a soñar con un auto así. Su silueta aúna de forma magistral dinamismo y elegancia intemporal.

T_BR

T_WEBVIEWDescargar manual__https://www.mercedes-benz.cr/documents/17944382/45813184/Cat%C3%A1logo+A+Sed%C3%A1n+%281%29.pdf

T_BR

T_RESERVA

T_BR
T_BR";
*/
        string _payload = @"T_IMGhttps://www.mercedes-benz.cr/documents/17944382/18096827/MBMX-2022-AMG-E-SEDAN-CH-2-1-DR.jpg/1970efa5-ebbf-9439-d652-1330c8dd758b?t=1649275369715___T_BR___T_RESERVA___T_BR___T_TITLE_1Diseño___T_TITLE_2La primera impresión no ofrece una segunda oportunidad.___T_TITLE_3Diseño Exterior___T_PPEs habitual emplear términos como «deportividad» o «dinamismo» en relación con los automóviles deportivos. El modelo 63 S del Clase E de Mercedes-AMG corrobora esa impresión desde el primer momento. Irradia poderío incluso antes de ponerse en marcha. Y su presencia expresiva inspira respeto.___T_IMGhttps://www.mercedes-benz.cr/documents/17944382/18096827/dise%C3%B1o+exterior.jpg___T_IMGhttps://www.mercedes-benz.cr/documents/17944382/18096827/dise%C3%B1o+exterior+2.jpg___T_TITLE_2Parrilla del radiador en diseño específico AMG___T_PPLa llamativa parrilla del radiador específica de AMG, en forma de A, junto con el exclusivo faldón delantero AMG en diseño Jet-Wing con nuevo splitter frontal y entradas de aire modificadas, reflejan a simple vista el carácter audaz y resuelto de este modelo. Todo ello acompañado de los nuevos faros LED, aún más expresivos y sugerentes.___T_RESERVA___T_BR";
        ProcessPayload(_payload);
    }
}
