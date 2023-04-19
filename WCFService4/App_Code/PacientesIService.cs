using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IPacientesIService
{

    [OperationContract]
    int NuevoRegistro(Pacientes pacientes);

    [OperationContract]
    List<Pacientes> MostrarRegistro();

    // TODO: agregue aquí sus operaciones de servicio
}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public class Pacientes
{
    int _Tipo_documento;
    int _Documento;
    string _Nombres;
    string _Apellidos;
    string _Correo;
    int _Telefono;
    DateTime _Fecha_de_nacimiento;
    int _Estado_afiliacion;

    public int Tipo_documento
    {
        get
        {
            return _Tipo_documento;
        }

        set
        {
            _Tipo_documento = value;
        }
    }

    public int Documento
    {
        get
        {
            return _Documento;
        }

        set
        {
            _Documento = value;
        }
    }

    public string Nombres
    {
        get
        {
            return _Nombres;
        }

        set
        {
            _Nombres = value;
        }
    }

    public string Apellidos
    {
        get
        {
            return _Apellidos;
        }

        set
        {
            _Apellidos = value;
        }
    }

    public string Correo
    {
        get
        {
            return _Correo;
        }

        set
        {
            _Correo = value;
        }
    }

    public DateTime Fecha_de_nacimiento
    {
        get
        {
            return _Fecha_de_nacimiento;
        }

        set
        {
            _Fecha_de_nacimiento = value;
        }
    }

    public int Estado_afiliacion
    {
        get
        {
            return _Estado_afiliacion;
        }

        set
        {
            _Estado_afiliacion = value;
        }
    }

    public int Telefono
    {
        get
        {
            return _Telefono;
        }

        set
        {
            _Telefono = value;
        }
    }
}
