namespace aruizT2.Vistas;

public partial class vCalificaciones : ContentPage
{
	public vCalificaciones()
	{
		InitializeComponent();
	}
    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            if (!string.IsNullOrWhiteSpace(entry.Text))
            {
                if (!double.TryParse(entry.Text, out double value) || value < 0.1 || value > 10)
                {
                    // Si el valor no es válido, muestra un mensaje de error y borra el texto
                    DisplayAlert("Error", "Ingrese un valor entre 0.1 y 10", "Aceptar");
                    entry.Text = "";
                }
            }
        }
    }

    private void btnInformacion_Clicked(object sender, EventArgs e)
    {
		if (pkEstudiantes.SelectedIndex==-1)
		{
			DisplayAlert("Alerta", "No escogio un estudiante", "Cerrar");
		}
		else
		{
			String resultado = null;
			String estudiante = pkEstudiantes.Items[pkEstudiantes.SelectedIndex].ToString();
			String fecha = dpFecha.Date.ToString("MM/dd/yyyy");
			double segumiento1=Convert.ToDouble(txtSeguimiento.Text);
            double examen1 = Convert.ToDouble(txtExamen.Text);
            double segumiento2 = Convert.ToDouble(txtSeguimiento2.Text);
            double examen2 = Convert.ToDouble(txtExamen2.Text);
			double calculadosegumiento1 = segumiento1 * 0.3;
            double calculadoexamen1 = examen1 * 0.2;
			double parcial1 = calculadosegumiento1 + calculadoexamen1;
            double calculadosegumiento2 = segumiento2 * 0.3;
            double calculadoexamen2 = examen2 * 0.2;
            double parcial2 = calculadosegumiento2 + calculadoexamen2;
            double notaFinal = parcial1 + parcial2;
			if (notaFinal >=7)
			{
				resultado = "APROBADO";
			}else if (notaFinal >= 5 && notaFinal <=6.9)
			{
                resultado = "COMPLEMENTARIO";
            }else if (notaFinal <5)
			{
                resultado = "REPROBADO";
            }

            DisplayAlert("Alerta", "Estudiante "+estudiante +
				"\nFecha: "+fecha +
                "\nNota Parcial 1: " + parcial1 +
                "\nNota Parcial 2: " + parcial2+
                "\nNota Final: " + notaFinal+
                "\nEstado: " + resultado, 
				"Cerrar");
        }
    }
}