using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Veterinaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Veterinaria
{
    [Activity(Label = "Mascota")]

    public class Mascota : Activity
    {
        EditText txtIdPes;
        EditText txtNombrePes;
        EditText txtCedulaDue�o;
        EditText txtEdadPes;
        EditText txtEspeciePes;
        EditText txtRazaPes;
        EditText txtCaracteristicasPes;
        EditText txtPesoPes;

        Button btnRegistrar;
        Button btnConsultar;
        Button btnIrInicio;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Peces);

            txtIdPes = FindViewById<EditText>(Resource.Id.txtIdPes);
            txtNombrePes = FindViewById<EditText>(Resource.Id.txtNombrePes);
            txtCedulaDue�o = FindViewById<EditText>(Resource.Id.txtCedulaDue�o);
            txtEdadPes = FindViewById<EditText>(Resource.Id.txtEdadPes);
            txtEspeciePes = FindViewById<EditText>(Resource.Id.txtEspeciePes);
            txtRazaPes = FindViewById<EditText>(Resource.Id.txtRazaPes);
            txtCaracteristicasPes = FindViewById<EditText>(Resource.Id.txtCaracteristicasPes);
            txtPesoPes = FindViewById<EditText>(Resource.Id.txtPesoPes);

            btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrar);
            btnConsultar = FindViewById<Button>(Resource.Id.btnConsultarPes);
            btnIrInicio = FindViewById<Button>(Resource.Id.btnIrInicio);

            btnRegistrar.Click += BtnCrearMascotas_Click;
            btnConsultar.Click += BtnConsultarMascota_Click;
            btnIrInicio.Click += BtnIrInicio_Click;


        }

        private void BtnIrInicio_Click(object sender, EventArgs e)
        {
            var bienvenido = new Intent(this, typeof(Bienvenido));
            StartActivity(bienvenido);
            Finish();

        }
            private void BtnCrearMascotas_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombrePes.Text.Trim()) && !string.IsNullOrEmpty(txtCedulaDue�o.Text.Trim())
                        && !string.IsNullOrEmpty(txtEdadPes.Text.Trim()) && !string.IsNullOrEmpty(txtEspeciePes.Text.Trim())
                            && !string.IsNullOrEmpty(txtRazaPes.Text.Trim()) && !string.IsNullOrEmpty(txtCaracteristicasPes.Text.Trim()))
                {

                    int num = new Conectar().Guardar(null, new Mascotas()
                    {
                        Nombre_Mascota = txtNombrePes.Text.Trim(),
                        Cedula_Amo = txtCedulaDue�o.Text.Trim(),
                        Edad = txtEdadPes.Text.Trim(),
                        Especie = txtEspeciePes.Text.Trim(),
                        Raza = txtRazaPes.Text.Trim(),
                        Caracteristicas = txtCaracteristicasPes.Text.Trim(),
                        Peso = txtPesoPes.Text.Trim()

                    }, null, null, null); ;
                    if (num > 0)
                    {
                        Toast.MakeText(this, "Registro guardado con !Exito�", ToastLength.Long).Show();
                        txtNombrePes.Text = "";
                        txtCedulaDue�o.Text = "";
                        txtEdadPes.Text = "";
                        txtEspeciePes.Text = "";
                        txtCaracteristicasPes.Text = "";
                        txtPesoPes.Text = "";
                    }
                    else
                    {
                        Toast.MakeText(this, "Ocurrio un error no se pudo Guardar", ToastLength.Long).Show();
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

        private void BtnConsultarMascota_Click(object sender, EventArgs e)
        {
            try
            {
                Mascotas resultado = null;
                if (!String.IsNullOrEmpty(txtCedulaDue�o.Text.Trim()))
                {
                    resultado = new Conectar().BuscarMascota(txtCedulaDue�o.Text.Trim());
                    if (resultado != null)
                    {
                        txtIdPes.Text = resultado.Idm.ToString();
                        txtNombrePes.Text = resultado.Nombre_Mascota.ToString();
                        txtEdadPes.Text = resultado.Edad.ToString();
                        txtEspeciePes.Text = resultado.Especie.ToString();
                        txtRazaPes.Text = resultado.Raza.ToString();
                        txtCaracteristicasPes.Text = resultado.Caracteristicas.ToString();
                        txtPesoPes.Text = resultado.Peso.ToString();

                        Toast.MakeText(this, "Consulta Exitosa", ToastLength.Short).Show();

                    }
                    else
                    {
                        Toast.MakeText(this, "El registro no existe", ToastLength.Short).Show();

                    }
                }
            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

    }
}