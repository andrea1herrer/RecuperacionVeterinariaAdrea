using SQLite;
using Java.Util;

namespace Veterinaria
{
    public class Login
    {
        public Login() { }

        [PrimaryKey]
        [MaxLength(20)]
        public string Usuario { get; set; }

        [MaxLength(20)]
        public string Password { get; set; }

        [MaxLength(20)]
        public string Rol { get; set; }

        [MaxLength(20)]
        public string Nombres { get; set; }

        [MaxLength(5)]
        public int edad { get; set; }
    }

   

    public class Mascotas
    {
        public Mascotas() { }

        [PrimaryKey, AutoIncrement]
        [MaxLength(10)]
        public int Idm { set; get; }

        [MaxLength(30)]
        public string Nombre_Mascota { set; get; }
        
        [MaxLength(30)]
        public string Cedula_Amo { set; get; }

        [MaxLength(3)]
        public string Edad { set; get; }

        [MaxLength(20)]
        public string Especie { set; get; }

        [MaxLength(20)]
        public string Raza { set; get; }

        [MaxLength(100)]
        public string Caracteristicas { set; get; }

        [MaxLength(30)]
        public string Peso { set; get; }

    }

    public class Historia_clinica
    {
        public Historia_clinica() { }

        [PrimaryKey, AutoIncrement]
        [MaxLength(10)]
        public int Idh { set; get; }

        [MaxLength(30)]
        public string Medico { set; get; }

        [MaxLength(30)]
        public string Fecha { set; get; }

        [MaxLength(100)]
        public string Motivo { set; get; }

        [MaxLength(200)]
        public string Sintomas { set; get; }

        [MaxLength(500)]
        public string Diagnostico { set; get; }

        [MaxLength(200)]
        public string Procedimiento { set; get; }

        [MaxLength(100)]
        public string Medicamento { set; get; }

        [MaxLength(100)]
        public string Dosis { set; get; }

        [MaxLength(100)]
        public string HistorialVacunacion { set; get; }

        [MaxLength(100)]
        public string Alergia { set; get; }




    }

    public class Orden
    {
        public Orden() { }

        [PrimaryKey, AutoIncrement]
        [MaxLength(10)]
        public int Ido { set; get; }

        [MaxLength(15)]
        public string Idm { set; get; }

        [MaxLength(15)]
        public string Idp { set; get; } //cedula persona

        [MaxLength(15)]
        public string Idv { set; get; } //cedula veterinario

        [MaxLength(100)]
        public string Medicamento { set; get; }

        [MaxLength(15)]
        public string Fecha { set; get; }



    }

    public class Venta
    {
        public Venta() { }

        [PrimaryKey, AutoIncrement]
        [MaxLength(10)]
        public int Idf { set; get; }// identificador de la venta

        [MaxLength(15)]
        public string Idm { set; get; }// identificador de la mascota

        [MaxLength(15)]
        public string Idp { set; get; }// identificador de dueño mascota

        [MaxLength(15)]
        public string Ido { set; get; }// identificador de orden

        [MaxLength(50)]
        public string Producto { set; get; }

        [MaxLength(50)]
        public string Valor { set; get; }

        [MaxLength(10)]
        public string Cantidad { set; get; }

        [MaxLength(50)]
        public string Fecha { set; get; }

    }
}