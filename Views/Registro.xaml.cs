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
        
        // Validar si el monto inicial es válido
        if (double.TryParse(txtMontoInicial.Text, out double montoInicial))
        {
            if (montoInicial > 0 && montoInicial < MaxMontoInicial)
            {
                // Cálculo: (costo - montoInicial) / 4 + 4% de 1500
                pagoTotalConIva = ((MaxMontoInicial * 4) / 100) + MaxMontoInicial;
                double pagoMensual = ((pagoTotalConIva - montoInicial) / 4);
                txtPagoMensual.Text = pagoMensual.ToString("F2");
                
            }
            else
            {
                txtPagoMensual.Text = "Monto no válido";
            }
        }
        else
        {
            txtPagoMensual.Text = "Ingrese un valor numérico";
        }
    }

    private void btnVerResumen_Clicked(object sender, EventArgs e)
    {

        int edad = 0;
        // Verificar si el país ha sido seleccionado
        if (pickerListPais.SelectedIndex < 0)
        {
            DisplayAlert("Error", "Por favor, seleccione un país.", "OK");
            return; // Detener la ejecución si no se selecciona un país
        }

        // Verificar si la ciudad ha sido seleccionada
        if (pickerListCiudad.SelectedIndex < 0)
        {
            DisplayAlert("Error", "Por favor, seleccione una ciudad.", "OK");
            return; // Detener la ejecución si no se selecciona una ciudad
        }

        // Verificar que el nombre no esté vacío
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            DisplayAlert("Error", "Por favor, ingrese su nombre.", "OK");
            return; // Detener la ejecución si el nombre está vacío
        }

        // Verificar que el apellido no esté vacío
        if (string.IsNullOrWhiteSpace(txtApellido.Text))
        {
            DisplayAlert("Error", "Por favor, ingrese su apellido.", "OK");
            return; // Detener la ejecución si el apellido está vacío
        }

        // Verificar que la edad sea un número válido y mayor que 0
        if (!int.TryParse(txtEdad.Text, out edad) || edad <= 0)
        {
            DisplayAlert("Error", "Por favor, ingrese una edad válida mayor a 0.", "OK");
            return; // Detener la ejecución si la edad no es válida
        }

        string nombrePais, nombreCiudad, nombre, apellido;
        nombrePais = pickerListPais.Items[pickerListPais.SelectedIndex];
        nombreCiudad = pickerListCiudad.Items[pickerListCiudad.SelectedIndex];
        nombre = txtNombre.Text;
        apellido = txtApellido.Text;

        Navigation.PushAsync(new Resumen(usuarioSesion,nombrePais, nombreCiudad, nombre, apellido, edad, dFechas.Date.ToString("dd/MM/yyyy"), Convert.ToDouble(txtMontoInicial.Text), Convert.ToDouble(txtPagoMensual.Text), Convert.ToDouble(pagoTotalConIva)));


    }
}