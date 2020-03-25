using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public enum YesNo
    {
        Yes = 1,
        No = 0
    }

    public enum RecordType
    {
        Temporal = 1,
        NoTemporal = 2
    }
    public enum RecordStatus
    {
        Grabado = 0,
        Modificado = 1,
        Agregado = 2,
        EliminadoLogico = 3
    }

    public enum StateQuotation
    {
        Seguimiento = 1,
        Aceptada = 2,
        Descartada = 3,
        Potencial = 4
    }

    public enum CalendarStatus
    {
        NoIniciado =1,
        EnEvaluacion=2,
        Culminado=3
    }

    public enum ServiceStatus
    {
        PorIniciar=1,
        Iniciado=2,
        Culminado=3,
        Incompleto=4,
        Cancelado=5
    }

    public enum ServiceComponentStatus
    {
        PorIniciar = 1       
    }

    public enum Mood
    {
        Normal=1,
        Enojado=2,
        Mango=3
    }
    
}
