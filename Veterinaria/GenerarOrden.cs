using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Veterinaria
{
    [Activity(Label = "GenerarOrden")]
    public class GenerarOrden : Activity
    {
        EditText txtIdMascota;
        EditText txtCedulaDueño;
        EditText txtCedulaVeterinario;
        EditText txtMedicamento;
        EditText txtFecha;

        Button btnRegistrar;
        Button btnIrInicio;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GenerarOrden);

            txtIdMascota = FindViewById<EditText>(Resource.Id.txtIdMascota);
            txtCedulaDueño = FindViewById<EditText>(Resource.Id.txtCedulaDueño);
            txtCedulaVeterinario = FindViewById<EditText>(Resource.Id.txtCedulaVeterinario);
            txtMedicamento = FindViewById<EditText>(Resource.Id.txtCeduVeterinario);
            txtFecha= FindViewById<EditText>(Resource.Id.txtFecha);

            btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrar);
            btnIrInicio = FindViewById<Button>(Resource.Id.btnIrInicio);

            btnRegistrar.Click += BtnCrearOrden_Click;
            btnIrInicio.Click += BtnIrInicio_Click;
        }

        private void BtnIrInicio_Click(object sender, EventArgs e)
        {
            var bienvenido = new Intent(this, typeof(Bienvenido));
            StartActivity(bienvenido);
            Finish();

        }
        private void BtnCrearOrden_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtIdMascota.Text.Trim()) && !string.IsNullOrEmpty(txtCedulaDueño.Text.Trim())
                        && !string.IsNullOrEmpty(txtCedulaVeterinario.Text.Trim()) && !string.IsNullOrEmpty(txtMedicamento.Text.Trim())
                            && !string.IsNullOrEmpty(txtFecha.Text.Trim()) )
                {
                    
                        int num = new Conectar().Guardar(null,null,null,new Orden()
                        {
                            Idm = txtIdMascota.Text.Trim(),
                            Idp = txtCedulaDueño.Text.Trim(),
                            Idv = txtCedulaVeterinario.Text.Trim(),
                            Medicamento= txtMedicamento.Text.Trim(),
                            Fecha = txtFecha.Text.Trim()

                        },null);
                        if (num > 0)
                        {
                            Toast.MakeText(this, "Registro guardado con !Exito¡", ToastLength.Long).Show();
                            txtIdMascota.Text = "";
                            txtCedulaDueño.Text = "";
                            txtCedulaVeterinario.Text = "";
                            txtMedicamento.Text = "";
                            txtFecha.Text = "";
                            
                            
                        }
                        
                    }
                else
                {
                    Toast.MakeText(this, "Rellene los campos requeridos, son obligatorios", ToastLength.Long).Show();
                }

            }
            catch (System.Exception ex)
            {

                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}