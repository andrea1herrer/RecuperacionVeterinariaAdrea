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
    [Activity(Label = "Usuarios")]

    public class Usuarios : Activity
    {
        EditText txtCedula;
        EditText txtNombre;
        EditText txtEdad;
        EditText txtRol;
        EditText txtPassword;
        EditText txtComPassword;

        Button btnRegistrar;
        Button btnIrInicio;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CrearUsuarios);

            txtCedula = FindViewById<EditText>(Resource.Id.txtCedula);
            txtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
            txtEdad = FindViewById<EditText>(Resource.Id.txtEdad);
            txtRol = FindViewById<EditText>(Resource.Id.txtRol);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            txtComPassword = FindViewById<EditText>(Resource.Id.txtComPassword);

            btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrar);
            btnIrInicio = FindViewById<Button>(Resource.Id.btnIrInicio);

            btnRegistrar.Click += BtnCrearUsuario_Click;
            btnIrInicio.Click += BtnIrInicio_Click;
        }

        private void BtnIrInicio_Click(object sender, EventArgs e)
        {
            var bienvenido = new Intent(this, typeof(Bienvenido));
            StartActivity(bienvenido);
            Finish();

        }
        private void BtnCrearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text.Trim()) && !string.IsNullOrEmpty(txtCedula.Text.Trim())
                        && !string.IsNullOrEmpty(txtRol.Text.Trim()) && !string.IsNullOrEmpty(txtEdad.Text.Trim())
                            && !string.IsNullOrEmpty(txtPassword.Text.Trim()) && !string.IsNullOrEmpty(txtComPassword.Text.Trim()))
                {
                    if (txtPassword.Text.Trim().Equals(txtComPassword.Text.Trim())){
                       int num = new Conectar().Guardar(new Login()
                        {
                            Usuario = txtCedula.Text.Trim(),
                            Nombres = txtNombre.Text.Trim(),
                            edad =  int.Parse( txtEdad.Text.Trim()),
                            Rol = txtRol.Text.Trim(),
                            Password = txtPassword.Text.Trim()

                        },null,null,null,null) ; 
                        if(num >0 )
                        {
                            Toast.MakeText(this, "Registro guardado con !Exito¡", ToastLength.Long).Show();
                            txtCedula.Text = "";
                            txtNombre.Text = "";
                            txtEdad.Text = "";
                            txtRol.Text = "";
                            txtPassword.Text = "";
                            txtComPassword.Text = "";
                            Intent Index = new Intent(this, typeof(MainActivity));
                            StartActivity(Index);
                        }
                        else
                        {
                            Toast.MakeText(this, "Ocurrio un error no se pudo Guardar", ToastLength.Long).Show();
                        }
                    }
                    else
                    {
                        Toast.MakeText(this, "Las contraseñas NO coinciden", ToastLength.Long).Show();
                    }
                    
                    
                }
                else
                {
                    Toast.MakeText(this, "Rellene los campos requeridos, son obligatorios", ToastLength.Long).Show();
                }

            }
            catch (System.Exception ex)
            {
                
                Toast.MakeText(this,  ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}