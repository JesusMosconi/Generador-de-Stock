using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialC_1V2_BA
{
    public class Producto
    {
        private string nombre;
        private string precio;
        private string cantidad;
        private string total;


        public string Nombre { get => nombre; set => nombre = value; }
        public string Precio { get => precio; set => precio = value; }
        public string Cantidad { get => cantidad; set => cantidad = value; }
        public string Total { get => total; set => total = value; }



        public void Agregar(string Anombre, string Aprecio, string Acantidad, string Atotal)
        {
            Nombre = Anombre;
            Precio = Aprecio;
            Cantidad = Acantidad;
            Total = Atotal;
           
        }

       

    }
}
