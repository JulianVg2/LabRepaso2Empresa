using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRepaso2Empresa
{
    internal class AlquilerInfo
    {
        int nit;
        string nombreCliente;
        string placaVehiculo;
        string marcaVehiculo;
        int modeloVehiculo;
        string colorVehiculo;
        DateTime fechaDevolucion;
        decimal kilometrosrecorridos;
        decimal totalPagar;

        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string PlacaVehiculo { get => placaVehiculo; set => placaVehiculo = value; }
        public string MarcaVehiculo { get => marcaVehiculo; set => marcaVehiculo = value; }
        public int ModeloVehiculo { get => modeloVehiculo; set => modeloVehiculo = value; }
        public string ColorVehiculo { get => colorVehiculo; set => colorVehiculo = value; }
        public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
        public decimal TotalPagar { get => totalPagar; set => totalPagar = value; }
        public decimal Kilometrosrecorridos { get => kilometrosrecorridos; set => kilometrosrecorridos = value; }
        public int Nit { get => nit; set => nit = value; }
    }
}
