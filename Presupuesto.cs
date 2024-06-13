using System;
using conexion;
using consultas;
using ipresupuesto;

namespace presupuesto{
    public class Presupuesto : iPresupuesto
    {
        Conexion conexion = new Conexion();
        Consultas consultas = new Consultas();
        decimal presupuestos = 0;

    public List<decimal> mostrarPresupuestos(){
        List<decimal> presupuestos = new List<decimal>();

        for (int i = 1; i <= 11; i++){
            decimal presupuesto = consultas.ObtenerPresupuesto(i, conexion.crearConexion());
            presupuestos.Add(presupuesto);
    }

    return presupuestos;
    }


        public string agregarPresupuesto(int id,decimal dinero)
        {
            
            string bandera = "";
            presupuestos = consultas.ObtenerPresupuesto(id,conexion.crearConexion());
            if(dinero<=0){
               
                bandera = "Una disculpa se puede ingresar numeros negativos";

            }else{

                presupuestos += dinero;
                if(consultas.ActualizarDinero(id,presupuestos,conexion.crearConexion()))
                    bandera = "Se actualizo el presupuesto";
                else
                    bandera = "No se pudo actualizar el presupuesto";

            }
            return bandera;
        }

         public string quitarPresupuesto(int id,decimal monto)
        {
            string bandera = "";
            presupuestos = consultas.ObtenerPresupuesto(id,conexion.crearConexion());
            if(monto>presupuestos){
                bandera = "No puedes sacar ya que solo queda este total $" + presupuestos;
            }else{
                presupuestos -= monto;
                if(consultas.ActualizarDinero(id,presupuestos,conexion.crearConexion()))
                    bandera = "Se actualizo correctamente";
                else
                    bandera = "Hubo un error al actualizarlo";
            }
            return bandera;
        }

        public bool alcancePresupuesto(int id, decimal monto)
        {
            presupuestos = consultas.ObtenerPresupuesto(id,conexion.crearConexion());
            bool bandera = false;
            if(presupuestos >= monto)
                bandera = true;
            else
                bandera = false;
            return bandera;
        }

               
    }
}