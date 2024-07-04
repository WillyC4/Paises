using Paises.Views;

namespace Paises;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    private void btnPersonaje(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Personaje());
    }
}