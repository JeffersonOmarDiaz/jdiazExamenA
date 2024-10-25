namespace jdiazExamenA.Views;

public partial class Registro : ContentPage
{
    public string usuarioSesion = "";
    double MaxMontoInicial = 1500;
    double pagoTotalConIva = 0;
    public Registro(string _usuarioSesion)
	{
        usuarioSesion = _usuarioSesion;
        InitializeComponent();
        lblUsuarioConectado.Text = $"Usuario Conectado: {_usuarioSesion}";
	}

    private void txtMontoInicial_TextChanged(object sender, TextChangedEventArgs e)
    {
        lblUsuarioConectado.Text = $"Usuario Conectado: {usuarioSesion}";
        
        // Validar si el monto inicial es v�lido
        if (double.TryParse(txtMontoInicial.Text, out double montoInicial))
        {
            if (montoInicial > 0 && montoInicial < MaxMontoInicial)
            {
                // C�lculo: (costo - montoInicial) / 4 + 4% de 1500
                pagoTotalConIva = ((MaxMontoInicial * 4) / 100) + MaxMontoInicial;
                double pagoMensual = ((pagoTotalConIva - montoInicial) / 4);
                txtPagoMensual.Text = pagoMensual.ToString("F2");
                
            }
            else
            {
                txtPagoMensual.Text = "Monto no v�lido";
            }
        }
        else
        {
            txtPagoMensual.Text = "Ingrese un valor num�rico";
        }
    }

    private void btnVerResumen_Clicked(object sender, EventArgs e)
    {

        int edad = 0;
        // Verificar si el pa�s ha sido seleccionado
        if (pickerListPais.SelectedIndex < 0)
        {
            DisplayAlert("Error", "Por favor, seleccione un pa�s.", "OK");
            return; // Detener la ejecuci�n si no se selecciona un pa�s
        }

        // Verificar si la ciudad ha sido seleccionada
        if (pickerListCiudad.SelectedIndex < 0)
        {
            DisplayAlert("Error", "Por favor, seleccione una ciudad.", "OK");
            return; // Detener la ejecuci�n si no se selecciona una ciudad
        }

        // Verificar que el nombre no est� vac�o
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            DisplayAlert("Error", "Por favor, ingrese su nombre.", "OK");
            return; // Detener la ejecuci�n si el nombre est� vac�o
        }

        // Verificar que el apellido no est� vac�o
        if (string.IsNullOrWhiteSpace(txtApellido.Text))
        {
            DisplayAlert("Error", "Por favor, ingrese su apellido.", "OK");
            return; // Detener la ejecuci�n si el apellido est� vac�o
        }

        // Verificar que la edad sea un n�mero v�lido y mayor que 0
        if (!int.TryParse(txtEdad.Text, out edad) || edad <= 0)
        {
            DisplayAlert("Error", "Por favor, ingrese una edad v�lida mayor a 0.", "OK");
            return; // Detener la ejecuci�n si la edad no es v�lida
        }

        string nombrePais, nombreCiudad, nombre, apellido;
        nombrePais = pickerListPais.Items[pickerListPais.SelectedIndex];
        nombreCiudad = pickerListCiudad.Items[pickerListCiudad.SelectedIndex];
        nombre = txtNombre.Text;
        apellido = txtApellido.Text;

        Navigation.PushAsync(new Resumen(usuarioSesion,nombrePais, nombreCiudad, nombre, apellido, edad, dFechas.Date.ToString("dd/MM/yyyy"), Convert.ToDouble(txtMontoInicial.Text), Convert.ToDouble(txtPagoMensual.Text), Convert.ToDouble(pagoTotalConIva)));


    }
}