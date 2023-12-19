using ML;
using System.ServiceModel;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlumnoService" in both code and config file together.
    [ServiceContract]
    public interface IAlumnoService
    {
        [OperationContract]
        Result Add(Alumno alumno);

        [OperationContract]
        Result Update(Alumno alumno);

        [OperationContract]
        Result Delete(Alumno alumno);

        [OperationContract]
        [ServiceKnownType(typeof(Alumno))]
        Result GetById(int IdAlumno);

        [OperationContract]
        [ServiceKnownType(typeof(Alumno))]
        Result GetAll();
    }
}
