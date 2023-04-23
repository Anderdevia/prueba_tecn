using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServPaci
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPacientesService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPacientesService
    {
        [OperationContract]
         bool AgregarPaciente(PacientesContract pacientesContract);

        [OperationContract]
        bool Actualizar(PacientesContract pacientesContract);

        [OperationContract]
        bool Eliminar(string numero);

        [OperationContract]
        List<PacientesContract> MostrarRegistro();
    }

    [DataContract]
    public class PacientesContract
    {
        public string Tipo_documento { get; set; }
        public int Numero_documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public string Estado_afiliacion { get; set; }
    }
}
