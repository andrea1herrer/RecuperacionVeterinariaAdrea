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

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Path = System.IO.Path;
using Java.Security;
using Java.Util;

namespace Veterinaria
{

    public class Conectar
    {
        static object locker = new object();
        SQLiteConnection conexion;
        public Conectar() //Esto es un constructor
        {
            conexion = ConectarBD();
            conexion.CreateTable<Login>();
            conexion.CreateTable<Mascotas>();
            conexion.CreateTable<Historia_clinica>();
            conexion.CreateTable<Orden>();
            conexion.CreateTable<Venta>();
        }

        public SQLite.SQLiteConnection ConectarBD()
        {
            SQLiteConnection conexionBaseDatos;
            string nombreArchivo = "veterinariaAndrea.db3";
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string completaRuta = Path.Combine(ruta, nombreArchivo);
            conexionBaseDatos = new SQLiteConnection(completaRuta);
            return conexionBaseDatos;
        }

        public Login SelecionarUno(string NombreUsuario, string ClaveUsuario)
        {
            lock (locker)
            {
                return conexion.Table<Login>().FirstOrDefault(x => x.Usuario == NombreUsuario && x.Password == ClaveUsuario);
            }
        }

        public int Guardar(Login registro,Mascotas mascota,
                            Historia_clinica historia,Orden orden,Venta venta) 
        {
            int aux = 0;
            if(registro != null)
            {
                aux= conexion.Insert(registro);

            }else if(mascota != null)
            {
                aux = conexion.Insert(mascota);

            }
            else if (historia != null)
            {
                if (historia.Idh == 0)
                {
                    aux = conexion.Insert(historia);
                }
                else
                {
                    aux = conexion.Update(historia);
                }
                

            }
            else if (orden != null)
            {
                aux = conexion.Insert(orden);

            }
            else if (venta != null)
            {
                aux = conexion.Insert(venta);

            }
            lock (locker)
            {
                return aux;
                
            }
        }

        public Mascotas BuscarMascota(string IdPropietarioMascota)
        {
            lock (locker)
            {
                return conexion.Table<Mascotas>().FirstOrDefault(x => x.Cedula_Amo == IdPropietarioMascota);
            }
        }

        public Historia_clinica BuscarHistoria(int IdHistoria)
        {
            lock (locker)
            {
                return conexion.Table<Historia_clinica>().FirstOrDefault(x => x.Idh == IdHistoria);
            }
        }

        public Venta BuscarVenta(int IdVenta)
        {
            lock (locker)
            {
                return conexion.Table<Venta>().FirstOrDefault(x => x.Idf == IdVenta);
            }
        }
    }

    
    //[Activity(Label = "Conexion")]
    //public class Conexion : Activity
    //{
    //    protected override void OnCreate(Bundle savedInstanceState)
    //    {
    //        base.OnCreate(savedInstanceState);

    //        // Create your application here
    //    }
    //}
}