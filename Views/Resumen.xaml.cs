using static System.Runtime.InteropServices.JavaScript.JSType;

namespace jdiazExamenA.Views;
public partial class Resumen : ContentPage
{
    

    public Resumen(string usuariosesion, string nombrePais, string nombreCiudad, string nombre, string apellido, int edad, string fecha,
		double montoInicial, double pagoMensual, double pagoTotal)
	{
		InitializeComponent();
		lblApellido.Text = apellido;
		lblCiudad.Text = nombreCiudad;
		lblNombre.Text = nombre;
		lblPais.Text = nombrePais;
		lblEdad.Text = Convert.ToString(edad);
		lblMontoInicial.Text = Convert.ToString(montoInicial);
		lblPagoMensual.Text = Convert.ToString(pagoMensual);
		lblPagoTotal.Text = Convert.ToString(pagoTotal);
		lblFecha.Text = fecha;
		lblUsuarioConectado.Text = $"Usuario Conectado: {usuariosesion}";
    }
}