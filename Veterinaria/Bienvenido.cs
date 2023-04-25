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
    [Activity(Label = "Bienvenido")]
    public class Bienvenido : Activity
    {
        
        Toolbar toolbarmenu;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Bienvenido);
            toolbarmenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);

            SetActionBar(toolbarmenu);
            ActionBar.Title = "Menu";

        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.CrearUsuarios:

                    if (MainActivity.Rol.Equals("Administrador"))
                    {
                        Intent crearusuarios = new Intent(this, typeof(Usuarios));
                        StartActivity(crearusuarios);
                        Finish();
                    }
                    else
                    {
                        Toast.MakeText(this, "Acceso Denegado", ToastLength.Long).Show();
                    }
                    break;

                case Resource.Id.HistoriaClinica:

                    if(MainActivity.Rol.Equals("Administrador") | MainActivity.Rol.Equals("medico veterinario"))
                    {
                        Intent historiaclinica = new Intent(this, typeof(HistorialClinica));
                        StartActivity(historiaclinica);
                        Finish();
                    }
                    else
                    {
                        Toast.MakeText(this, "Acceso Denegado", ToastLength.Long).Show();
                    }
                    break;

                case Resource.Id.Mascotas:

                    if (MainActivity.Rol.Equals("Administrador") | MainActivity.Rol.Equals("medico veterinario"))
                    {
                        Intent mascotas = new Intent(this, typeof(Mascota));
                        StartActivity(mascotas);
                        Finish();
                    }
                    else
                    {
                        Toast.MakeText(this, "Acceso Denegado", ToastLength.Long).Show();
                    }
                    break;

                case Resource.Id.GenerarOrdenes:

                    if (MainActivity.Rol.Equals("Administrador") | MainActivity.Rol.Equals("medico veterinario"))
                    {
                        Intent generarordenes = new Intent(this, typeof(GenerarOrden));
                        StartActivity(generarordenes);
                        Finish();
                    }
                    else
                    {
                        Toast.MakeText(this, "Acceso Denegado", ToastLength.Long).Show();
                    }
                    break;

                case Resource.Id.GenerarFacturas:

                    if (MainActivity.Rol.Equals("Administrador") | MainActivity.Rol.Equals("vendedor"))
                    {
                        Intent generarfactura = new Intent(this, typeof(GenerarFactura));
                        StartActivity(generarfactura);
                        Finish();
                    }
                    else
                    {
                        Toast.MakeText(this, "Acceso Denegado", ToastLength.Long).Show();
                    }
                    break;
                
                case Resource.Id.Salir:
                    var index = new Intent(this, typeof(MainActivity));
                    StartActivity(index);
                    Finish();

                    break;
            }
            return base.OnOptionsItemSelected(item);
        }






    }

    
}