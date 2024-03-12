using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRepaso2Empresa
{
    internal class alquileres
    {
        int nit;
        string placa;
        DateTime fechaAlquiler;
        DateTime fechaDevolucion;
        decimal kilometrosrecorridos;

        public string Placa { get => placa; set => placa = value; }
        public DateTime FechaAlquiler { get => fechaAlquiler; set => fechaAlquiler = value; }
        public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
        public decimal Kilometrosrecorridos { get => kilometrosrecorridos; set => kilometrosrecorridos = value; }
        public int Nit { get => nit; set => nit = value; }
    }
}
