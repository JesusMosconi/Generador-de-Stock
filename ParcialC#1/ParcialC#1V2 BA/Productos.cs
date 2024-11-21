using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialC_1V2_BA
{
    public class Productos
    {    

        public DataTable StockDT = new DataTable();

        public Productos()
        {
            StockDT.TableName = "Stock";
            StockDT.Columns.Add("Producto");
            StockDT.Columns.Add("Precio");
            StockDT.Columns.Add("Cantidad");
            StockDT.Columns.Add("Total");
            LeerXML();
        }

        public void InsertarProducto(Producto Aproducto)
        {
            StockDT.Rows.Add();
            int renglon = StockDT.Rows.Count - 1;
            StockDT.Rows[renglon]["Producto"] = Aproducto.Nombre;
            StockDT.Rows[renglon]["Precio"] = "$" + Aproducto.Precio;
            StockDT.Rows[renglon]["Cantidad"] = Aproducto.Cantidad;
            StockDT.Rows[renglon]["Total"] = "$" + Aproducto.Total;


            StockDT.WriteXml("Productos.xml");
        }

        public void LeerXML()
        {
            if (System.IO.File.Exists("Productos.xml"))
            {
                StockDT.ReadXml("Productos.xml");
            }
        }

        public void ModificarCarrito(Producto Aproducto, int AIndice)
        {
            int indice = AIndice;
            
            StockDT.Rows[indice]["Precio"] = "$" + Aproducto.Precio;
            StockDT.Rows[indice]["Cantidad"] = Aproducto.Cantidad;
            StockDT.Rows[indice]["Total"] = "$" + Aproducto.Total;

        }

    }
}
