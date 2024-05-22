
using S6.Models;
using System.Collections.Specialized;
using System.Net;

namespace S6.Views;

public partial class vEliminar : ContentPage
{
    private Estudiante _estudiante;

    public vEliminar(Models.Estudiante datos)
	{
		InitializeComponent();
        _estudiante = datos;
        txtCodigo.Text= datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();


         }

    //cambios 
    //no puedo garbar el git

    private async void btnActualizar_Clicked(object sender, EventArgs e)


    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text); 
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            Console.WriteLine("Parametros: codigo={0}, nombre={1}, apellido={2}, edad={3}",
           txtCodigo.Text, txtNombre.Text, txtApellido.Text, txtEdad.Text);

            cliente.UploadValues("http://192.168.100.41:50/moviles/wsestudiantes.php", "PUT", parametros);

            await DisplayAlert("Éxito", "Estudiante actualizado correctamente", "OK");
            await Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", ex.Message, "cerrar");
        }

    }

    private async void btneliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text);

            string url = "http://192.168.100.41:50/moviles/wsestudiantes.php"; 

            cliente.UploadValues(url, "DELETE", parametros);

            await DisplayAlert("Éxito", "Estudiante eliminado correctamente", "OK");
            await Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", ex.Message, "cerrar");
        }
    }
}