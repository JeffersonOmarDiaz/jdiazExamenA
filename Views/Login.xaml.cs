using Windows.System;

namespace jdiazExamenA.Views;

public partial class Login : ContentPage
{
    string[,] matrixUsuarios = new string[2, 2] { { "estudiante", "moviles" }, { "uisrael", "2024" } };
    public Login()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        string usuario = txtUsusario.Text;
        string password = txtPassword.Text;

        bool loginSuccessful = false;

        // Verificar la matriz de usuarios y contraseñas
        for (int i = 0; i < 2; i++)
        {
            if (matrixUsuarios[i, 0] == usuario && matrixUsuarios[i, 1] == password)
            {
                loginSuccessful = true;
                break;
            }
        }

        if (loginSuccessful)
        {
            // Si el login es exitoso, navegar a la siguiente ventana y enviar el nombre de usuario
            Navigation.PushAsync(new Registro(txtUsusario.Text));
        }
        else
        {
            // Mostrar mensaje de error
            DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
        }
    }
}