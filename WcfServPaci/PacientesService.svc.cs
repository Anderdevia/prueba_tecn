using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServPaci
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PacientesService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PacientesService.svc o PacientesService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PacientesService : IPacientesService
    {
        public bool Actualizar(PacientesContract pacientesContract)
        {
            bool resultado = false;

            paciente pacient = new paciente()
            {
                tipo_documento =  pacientesContract.Tipo_documento,
                numero_documento = pacientesContract.Numero_documento,
                nombres = pacientesContract.Nombre,
                apellidos = pacientesContract.Apellido,
                correo = pacientesContract.Correo,
                fecha_nacimiento = pacientesContract.Fecha_nacimiento,
                telefono = pacientesContract.Telefono,
                estado_afiliacion = pacientesContract.Estado_afiliacion

            };


            using (prueba_andersonEntities cnn = new prueba_andersonEntities())
            {

                cnn.Entry(pacient).State = EntityState.Modified;
                resultado = cnn.SaveChanges() > 0;

            }
            return resultado;
        }

        public bool AgregarPaciente(PacientesContract pacientesContract)
        {
            bool resultado = false;

            paciente pacient = new paciente()
            {
                tipo_documento = pacientesContract.Tipo_documento,
                numero_documento = pacientesContract.Numero_documento,
                nombres = pacientesContract.Nombre,
                apellidos = pacientesContract.Apellido,
                correo = pacientesContract.Correo,
                fecha_nacimiento = pacientesContract.Fecha_nacimiento,
                telefono = pacientesContract.Telefono,
                estado_afiliacion = pacientesContract.Estado_afiliacion

            };


            using (prueba_andersonEntities cnn = new prueba_andersonEntities())
            {

                cnn.pacientes.Add(pacient);
                resultado = cnn.SaveChanges() > 0;

            }
            return resultado;
        }


        public bool Eliminar(string numero)
        {
            bool resultado = false;
            using (prueba_andersonEntities cadenaConexion = new prueba_andersonEntities())
            {

                paciente pacient = cadenaConexion.pacientes.Find(numero);

                cadenaConexion.pacientes.Remove(pacient);
                resultado = cadenaConexion.SaveChanges() > 0;

            }

            return resultado;
        }

        public List<PacientesContract> MostrarRegistro()
        {
            prueba_andersonEntities cnn = new prueba_andersonEntities();


            return cnn.pacientes.Select(c => new PacientesContract
            {

                Tipo_documento = c.tipo_documento,
                Numero_documento = c.numero_documento,
                Nombre = c.nombres,
                Apellido = c.apellidos,
                Correo = c.correo,
                Fecha_nacimiento = c.fecha_nacimiento,
                Telefono = c.telefono,
                Estado_afiliacion = c.estado_afiliacion
            }).ToList();

            
        }
    }
}
