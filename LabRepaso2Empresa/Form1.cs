using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabRepaso2Empresa
{
    public partial class Form1 : Form
    {
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Clientes> clientes = new List<Clientes>();
        List<AlquilerInfo> alquileresInfo = new List<AlquilerInfo>();

        public Form1()
        {
            InitializeComponent();
        }



        public void GuardarVehiculos()
        {
            using (FileStream stream = new FileStream("Vehiculos.txt", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    foreach (Vehiculo vehiculoss in vehiculos)
                    {
                        writer.WriteLine(vehiculoss.Placa);
                        writer.WriteLine(vehiculoss.Marca);
                        writer.WriteLine(vehiculoss.Modelo);
                        writer.WriteLine(vehiculoss.Color);
                        writer.WriteLine(vehiculoss.PrecioKm);
                    }
                    writer.Close();
                }
            }

        }

        public void MostrarVehiculos()
        {
            datagridViewVehiculos.DataSource = null;
            datagridViewVehiculos.DataSource = vehiculos;
            datagridViewVehiculos.Refresh();

        }
        public void limpieza()
        {
            txtPlaca.Clear();
            txtMarca.Clear();
            txtColor.Clear();
            txtModelo.Clear();
            txtprecio.Clear();

            txtPlaca.Focus();


        }
        public void CargarClientes()
        {
            string fileName = "Clientes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1) 
            {
                Clientes clientess = new Clientes();
                clientess.Nit = int.Parse(reader.ReadLine());
                clientess.Nombre = reader.ReadLine();
                clientess.Direccion = reader.ReadLine();

                clientes.Add(clientess);

            }
            reader.Close();


        }
        public void MostrarClientes()
        {
            datagridViewClientes.DataSource = null;
            datagridViewClientes.DataSource = clientes;
            datagridViewClientes.Refresh();
                

        }

        public void CargarAlquileres()
        {
            string fileName = "Alquiler.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                AlquilerInfo alquiler = new AlquilerInfo();
                alquiler.NombreCliente = reader.ReadLine();
                alquiler.Nit = int.Parse(reader.ReadLine()); 
                alquiler.PlacaVehiculo = reader.ReadLine();
                alquiler.MarcaVehiculo = reader.ReadLine();
                alquiler.ModeloVehiculo = int.Parse(reader.ReadLine());
                alquiler.ColorVehiculo = reader.ReadLine();
                alquiler.Kilometrosrecorridos = decimal.Parse(reader.ReadLine());
                alquiler.FechaDevolucion = DateTime.Parse(reader.ReadLine());
                alquiler.Kilometrosrecorridos = decimal.Parse(reader.ReadLine());

                // Busca el cliente con el NIT correspondiente
                Clientes cliente = clientes.FirstOrDefault(c => c.Nit == alquiler.Nit);
                // Busca el vehículo con la placa correspondiente
                Vehiculo vehiculo = vehiculos.FirstOrDefault(v => v.Placa == alquiler.PlacaVehiculo);

                if (cliente != null && vehiculo != null)
                {
                    // Total a pagar
                    decimal totalPagar = alquiler.Kilometrosrecorridos * vehiculo.PrecioKm;

                    // Crea un objeto AlquilerInfo con la información requerida
                    AlquilerInfo alquilerInfo = new AlquilerInfo
                    {
                        NombreCliente = cliente.Nombre,
                        PlacaVehiculo = vehiculo.Placa,
                        MarcaVehiculo = vehiculo.Marca,
                        ModeloVehiculo = vehiculo.Modelo,
                        ColorVehiculo = vehiculo.Color,
                        FechaDevolucion = alquiler.FechaDevolucion,
                        TotalPagar = totalPagar
                    };

                    // Agrega el objeto AlquilerInfo a la lista de alquileres para mostrar
                    alquileresInfo.Add(alquilerInfo);
                }
            }
            reader.Close();
        }
        public void MostrarAlquileresInfo()
        {
            dataGridViewDatos.DataSource = null;
            dataGridViewDatos.DataSource = alquileresInfo;
            dataGridViewDatos.Refresh();
        }



        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo();
            txtPlaca.Focus();
            vehiculo.Placa = txtPlaca.Text;
            vehiculo.Marca = txtMarca.Text;
            vehiculo.Modelo = int.Parse(txtModelo.Text);
            vehiculo.Color = txtColor.Text;
            vehiculo.PrecioKm = decimal.Parse(txtprecio.Text);

            vehiculos.Add(vehiculo);
            GuardarVehiculos();
            MostrarVehiculos();
            CargarClientes();
            MostrarClientes();
            limpieza();
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            CargarAlquileres();
            MostrarAlquileresInfo();
        }
    }
}
