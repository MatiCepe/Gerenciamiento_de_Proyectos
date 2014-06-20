using System.Runtime.Serialization;

namespace GP.ServicioBase.DataContracts
{
    [DataContract]
    public class ValorDataContract
    {
        [DataMember]
        public int ValorId { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public short Influencia { get; set; }

        [DataMember]
        public int Deshabilitado { get; set; }
    }
}
