using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRepaso2Empresa
{
    internal class AlquilerInfo
    {
        string nombre;
        string placa;
        int modelo;
        string marca;
        string color;
        decimal precioKm;
        DateTime fechadevolucion;
        decimal totalpagar;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Placa { get => placa; set => placa = value; }
        public int Modelo { get => modelo; set => modelo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Color { get => color; set => color = value; }
        public decimal PrecioKm { get => precioKm; set => precioKm = value; }
        public DateTime Fechadevolucion { get => fechadevolucion; set => fechadevolucion = value; }
        public decimal Totalpagar { get => totalpagar; set => totalpagar = value; }
    }
}
