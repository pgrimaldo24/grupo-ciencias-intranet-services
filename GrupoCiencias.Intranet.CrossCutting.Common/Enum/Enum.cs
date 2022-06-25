using System.ComponentModel;

namespace GrupoCiencias.Intranet.CrossCutting.Common.Enum
{
    public enum EstadoEstudianteSolicitud
    {
        [Description("Estudiante Pendiente")]
        Pendiente = 1,
        [Description("Estudiante Aprobado")]
        Aprobado = 2
    }

    public enum EstadoEstudianteMatriculado
    {
        [Description("Estudiante Matriculado")]
        Activo = 1, 
    }
}
