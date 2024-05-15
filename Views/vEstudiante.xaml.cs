
using Newtonsoft.Json;
using S6.Models;
using System.Collections.ObjectModel;

namespace S6.Views;

public partial class vEstudiante : ContentPage
{
	private const string url = "http://192.168.100.41:50/moviles/wsestudiantes.php";
	private readonly HttpClient cliente =new HttpClient();
	
	private ObservableCollection<Estudiante> est;
	public vEstudiante()
	{
		InitializeComponent();
		ObtenerDatos();

    }

	public async void ObtenerDatos ()
    {

        var content = await cliente.GetStringAsync(url);
        List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);

        // Definir las columnas
        tabEst.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        tabEst.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        tabEst.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        tabEst.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

        // Agregar los elementos a la cuadrícula
        int rowIndex = 0;
        foreach (var estudiante in mostrarEst)
        {
            tabEst.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            var labelCodigo = new Label { Text = estudiante.codigo };
            tabEst.Children.Add(labelCodigo);
            Grid.SetRow(labelCodigo, rowIndex);
            Grid.SetColumn(labelCodigo, 0);

            var labelNombre = new Label { Text = estudiante.nombre };
            tabEst.Children.Add(labelNombre);
            Grid.SetRow(labelNombre, rowIndex);
            Grid.SetColumn(labelNombre, 1);

            var labelApellido = new Label { Text = estudiante.apellido };
            tabEst.Children.Add(labelApellido);
            Grid.SetRow(labelApellido, rowIndex);
            Grid.SetColumn(labelApellido, 2);


            var labelEdad = new Label { Text = estudiante.edad };
            tabEst.Children.Add(labelEdad);
            Grid.SetRow(labelEdad, rowIndex);
            Grid.SetColumn(labelEdad, 3);

            rowIndex++;
        }
    }
    

}