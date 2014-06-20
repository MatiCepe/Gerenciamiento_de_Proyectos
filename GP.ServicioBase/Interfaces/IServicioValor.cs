using System.Collections.Generic;
using System.ServiceModel;
using GP.ServicioBase.DataContracts;

namespace GP.ServicioBase.Interfaces
{
    [ServiceContract]
    public interface IServicioValor
    {
        [OperationContract]
        void Save(ValorDataContract entity);

        [OperationContract]
        void Edit(ValorDataContract entity);

        [OperationContract]
        void Enable(ValorDataContract entity);

        [OperationContract]
        void Disable(ValorDataContract entity);

        [OperationContract]
        ValorDataContract ObtainId(int id);

        [OperationContract]
        IList<ValorDataContract> ObtainAll();
    }
}
