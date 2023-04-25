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
    [Activity(Label = "HistorialClinica")]
    public class HistorialClinica : Activity
    {
        EditText txtIdOrden;
        EditText txtFecha;
        EditText txtNombreMedico;
        EditText txtMotivoConsulta;
        EditText txtSintomas;
        EditText txtProcedimiento;
        EditText txtMedicamento;
        EditText txtDosisMedicamento;
        EditText txtHistorial;
        EditText txtAlergiaMedicamento;
        EditText txtDetalleProcedimiento;

        Button btnRegistrar;
        Button btnBuscar;
        Button btnActualizar;
        Button btnIrInicio;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HistoriaClinica);

            txtIdOrden = FindViewById<EditText>(Resource.Id.txtIdOrden);
            txtFecha = FindViewById<EditText>(Resource.Id.txtFecha);
            txtNombreMedico = FindViewById<EditText>(Resource.Id.txtNombreMedico);
            txtMotivoConsulta =  FindViewById<EditText>(Resource.Id.txtMotivoConsulta);
            txtSintomas = FindViewById<EditText>(Resource.Id.txtSintomas);
            txtProcedimiento = FindViewById<EditText>(Resource.Id.txtProcedimiento);
            txtMedicamento = FindViewById<EditText>(Resource.Id.txtMedicamento);
            txtDosisMedicamento= FindViewById<EditText>(Resource.Id.txtDosisMedicamento);
            txtHistorial = FindViewById<EditText>(Resource.Id.txtHistorial);
            txtAlergiaMedicamento = FindViewById<EditText>(Resource.Id.txtAlergiaMedicamento);
            txtDetalleProcedimiento = FindViewById<EditText>(Resource.Id.txtDetalleProcedimiento);

            btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrar);
            btnBuscar = FindViewById<Button>(Resource.Id.btnBuscar);
            btnActualizar = FindViewById<Button>(Resource.Id.btnActualizar);
            btnIrInicio = FindViewById<Button>(Resource.Id.btnIrInicio);

            btnRegistrar.Click += BtnCrearHistoria_Click;
            btnBuscar.Click += BtnConsultarHistoria_Click;
            btnActualizar.Click += BtnActualizarHistoria_Click;
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
            if (!string.IsNullOrEmpty(txtFecha.Text.Trim()) && !string.IsNullOrEmpty(txtNombreMedico.Text.Trim())
                        && !string.IsNullOrEmpty(txtMotivoConsulta.Text.Trim()) && !string.IsNullOrEmpty(txtSintomas.Text.Trim())
                         && !string.IsNullOrEmpty(txtProcedimiento.Text.Trim()) && !string.IsNullOrEmpty(txtMedicamento.Text.Trim())
                          && !string.IsNullOrEmpty(txtDosisMedicamento.Text.Trim()) && !string.IsNullOrEmpty(txtHistorial.Text.Trim())
                           && !string.IsNullOrEmpty(txtAlergiaMedicamento.Text.Trim()) && !string.IsNullOrEmpty(txtDetalleProcedimiento.Text.Trim()))
            {
                validar = true;
            }

            return validar;
            
        }

        private void BtnConsultarHistoria_Click(object sender, EventArgs e)
        {
            try
            {
                Historia_clinica resultado = null;
                if (!String.IsNullOrEmpty(txtIdOrden.Text.Trim()))
                {
                    resultado = new Conectar().BuscarHistoria(int.Parse(txtIdOrden.Text.Trim()));
                    if (resultado != null)
                    {
                        txtIdOrden.Text = resultado.Idh.ToString();
                        txtNombreMedico.Text = resultado.Medico.ToString();
                        txtFecha.Text = resultado.Fecha.ToString();
                        txtMotivoConsulta.Text = resultado.Motivo.ToString();
                        txtSintomas.Text = resultado.Sintomas.ToString();
                        txtDetalleProcedimiento.Text = resultado.Diagnostico.ToString();
                        txtMedicamento.Text = resultado.Medicamento.ToString();
                        txtProcedimiento.Text = resultado.Procedimiento.ToString();
                        txtDosisMedicamento.Text = resultado.Dosis.ToString();
                        txtHistorial.Text = resultado.HistorialVacunacion.ToString();
                        txtAlergiaMedicamento.Text = resultado.Alergia.ToString();

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
        private void BtnCrearHistoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    
                    int num = new Conectar().Guardar(null,null,new Historia_clinica()
                    {
                        Idh=0,
                        Medico= txtNombreMedico.Text.Trim(),
                        Fecha = txtFecha.Text.Trim(),
                        Motivo = txtMotivoConsulta.Text.Trim(),
                        Sintomas = txtSintomas.Text.Trim(),
                        Diagnostico = txtDetalleProcedimiento.Text.Trim(),
                        Medicamento = txtMedicamento.Text.Trim(),
                        Procedimiento = txtProcedimiento.Text.Trim(),
                        Dosis = txtDosisMedicamento.Text.Trim(),
                        HistorialVacunacion = txtHistorial.Text.Trim(),
                        Alergia = txtAlergiaMedicamento.Text.Trim(),

                    }, null, null);
                    if (num > 0)
                    {
                        Toast.MakeText(this, "Registro guardado con !Exito¡", ToastLength.Long).Show();
                        txtNombreMedico.Text = "";
                        txtFecha.Text = "";
                        txtMotivoConsulta.Text = "";
                        txtSintomas.Text = "";
                        txtDetalleProcedimiento.Text = "";
                        txtProcedimiento.Text = "";
                        txtDosisMedicamento.Text = "";
                        txtHistorial.Text = "";
                        txtAlergiaMedicamento.Text= "";
                        txtMedicamento.Text = "";

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

        private void BtnActualizarHistoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    if (!String.IsNullOrEmpty(txtIdOrden.Text.Trim()))
                    {
                        int num = new Conectar().Guardar(null, null, new Historia_clinica()
                        {
                            Idh = int.Parse(txtIdOrden.Text.Trim()),
                            Medico = txtNombreMedico.Text.Trim(),
                            Fecha = txtFecha.Text.Trim(),
                            Motivo = txtMotivoConsulta.Text.Trim(),
                            Sintomas = txtSintomas.Text.Trim(),
                            Diagnostico = txtDetalleProcedimiento.Text.Trim(),
                            Medicamento = txtMedicamento.Text.Trim(),
                            Procedimiento = txtProcedimiento.Text.Trim(),
                            Dosis = txtDosisMedicamento.Text.Trim(),
                            HistorialVacunacion = txtHistorial.Text.Trim(),
                            Alergia = txtAlergiaMedicamento.Text.Trim(),

                        }, null, null);
                        if (num > 0)
                        {
                            Toast.MakeText(this, "Registro Actualizado  con !Exito¡", ToastLength.Long).Show();
                            txtNombreMedico.Text = "";
                            txtFecha.Text = "";
                            txtMotivoConsulta.Text = "";
                            txtSintomas.Text = "";
                            txtDetalleProcedimiento.Text = "";
                            txtProcedimiento.Text = "";
                            txtDosisMedicamento.Text = "";
                            txtHistorial.Text = "";
                            txtAlergiaMedicamento.Text = "";
                            txtMedicamento.Text = "";

                        }
                        else
                        {
                            Toast.MakeText(this, "Ocurrio un error no se pudo Guardar", ToastLength.Long).Show();
                        }
                    }
                    else
                    {
                        Toast.MakeText(this, "Rellene el campo ID ORDEN", ToastLength.Long).Show();
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