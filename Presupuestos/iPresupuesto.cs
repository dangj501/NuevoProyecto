using System;
using System.ServiceModel;

namespace ipresupuesto{
    [ServiceContract]
    public interface iPresupuesto{
        [OperationContract]
        public List<decimal> mostrarPresupuestos();
        [OperationContract]
        public string agregarPresupuesto(int id,decimal dinero);
        [OperationContract]
        public string quitarPresupuesto(int id,decimal dinero);
        [OperationContract]
        public bool alcancePresupuesto(int id, decimal dinero);
        
    }
}