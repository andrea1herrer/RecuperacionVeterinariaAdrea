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
    [Activity(Label = "GenerarFactura")]
    public class GenerarFactura : Activity
    {
        EditText txtIdAve;
        EditText txtNombreAve;
        EditText txtCedulaDueño;
        EditText txtEdadAve;
        EditText txtEspecieAve;
        EditText txtRazaAve;
        EditText txtCaracteristicasAve;
        EditText txtPesoAve;
        

        Button btnRegistrar;
        Button btnConsultar;
        Button btnIrInicio;
        protected override void OnCreate(Bundle savedInstanceState)
        {
          base.OnCreate(savedInstanceState);
          SetContentView(Resource.Layout.Aves);

            txtIdAve = FindViewById<EditText>(Resource.Id.txtIdAve);
            txtNombreAve = FindViewById<EditText>(Resource.Id.txtNombreAve);
            txtCedulaDueño = FindViewById<EditText>(Resource.Id.txtCedulaDueño);
            txtEdadAve = FindViewById<EditText>(Resource.Id.txtEdadAve);
            txtEspecieAve = FindViewById<EditText>(Resource.Id.txtEspecieAve);
            txtRazaAve = FindViewById<EditText>(Resource.Id.txtRazaAve);
            txtCaracteristicasAve = FindViewById<EditText>(Resource.Id.txtCaracteristicasAve);
            txtPesoAve = FindViewById<EditText>(Resource.Id.txtPesoAve);

            btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrar);
            btnConsultar = FindViewById<Button>(Resource.Id.btnConsultar);
            btnIrInicio = FindViewById<Button>(Resource.Id.btnIrInicio);


            btnRegistrar.Click += BtnCrearFactura_Click;
            btnConsultar.Click += BtnConsultarVenta_Click;
            btnIrInicio.Click += BtnIrInicio_Click;

        }

        private void BtnIrInicio_Click(object sender, EventArgs e)
        {
            var bienvenido = new Intent(this, typeof(Bienvenido));
            StartActivity(bienvenido);
            Finish();

        }
        private Boolean ValidarCampos()
        {
            Boolean validar = false;
            if (!string.IsNullOrEmpty(txtPesoAve.Text.Trim()) 
                        && !string.IsNullOrEmpty(txtNombreAve.Text.Trim()) && !string.IsNullOrEmpty(txtCedulaDueño.Text.Trim())
                         && !string.IsNullOrEmpty(txtEdadAve.Text.Trim()) && !string.IsNullOrEmpty(txtEspecieAve.Text.Trim())
                          && !string.IsNullOrEmpty(txtRazaAve.Text.Trim()) && !string.IsNullOrEmpty(txtCaracteristicasAve.Text.Trim()))
            {
                validar = true;
            }

            return validar;

        }

        private void BtnConsultarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                Venta resultado = null;
                if (!String.IsNullOrEmpty(txtIdAve.Text.Trim()))
                {
                    resultado = new Conectar().BuscarVenta(int.Parse(txtIdAve.Text.Trim()));
                    if (resultado != null)
                    {

                        txtNombreAve.Text = resultado.Idm.ToString();
                        txtCedulaDueño.Text = resultado.Idp.ToString();
                        txtEdadAve.Text = resultado.Ido.ToString();
                        txtEspecieAve.Text = resultado.Producto.ToString();
                        txtRazaAve.Text = resultado.Valor.ToString();
                        txtCaracteristicasAve.Text = resultado.Cantidad.ToString();
                        txtPesoAve.Text = resultado.Fecha.ToString();


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

        private void BtnCrearFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {

                    int num = new Conectar().Guardar(null, null,null,null, new Venta()
                    {
                        Idf = 0,
                        Idm = txtNombreAve.Text.Trim(),
                        Idp = txtCedulaDueño.Text.Trim(),
                        Ido = txtEdadAve.Text.Trim(),
                        Producto = txtEspecieAve.Text.Trim(),
                        Valor = txtRazaAve.Text.Trim(),
                        Cantidad = txtCaracteristicasAve.Text.Trim(),
                        Fecha = txtPesoAve.Text.Trim(),
                        

                    });
                    if (num > 0)
                    {
                        Toast.MakeText(this, "Registro guardado con !Exito¡", ToastLength.Long).Show();
                        txtNombreAve.Text = "";
                        txtCedulaDueño.Text = "";
                        txtEdadAve.Text = "";
                        txtEspecieAve.Text = "";
                        txtRazaAve.Text = "";
                        txtCaracteristicasAve.Text = "";
                        txtPesoAve.Text = "";
                        
                        

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
    }
}