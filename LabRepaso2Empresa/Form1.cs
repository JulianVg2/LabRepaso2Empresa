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
       
        List<alquileres> alquileres = new List<alquileres>();

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
            if (clientes.Count == 0)
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
        }
        public void MostrarClientes()
        {
            datagridViewClientes.DataSource = null;
            datagridViewClientes.DataSource = clientes;
            datagridViewClientes.Refresh();
                

        }

        public void LeerAlquileres()
        {
            string fileName = "Alquiler.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                alquileres alquiler = new alquileres();
                alquiler.Nit = int.Parse(reader.ReadLine());
                alquiler.Placa = reader.ReadLine();
                alquiler.FechaAlquiler = DateTime.Parse(reader.ReadLine());
                alquiler.FechaDevolucion = DateTime.Parse(reader.ReadLine());
                alquiler.Kilometrosrecorridos = decimal.Parse(reader.ReadLine());

                alquileres.Add(alquiler);
            }
            reader.Close();


        }

 

        public void CargarAlquileres()
        {
            List<AlquilerInfo> alquileresInfo = new List<AlquilerInfo>();


            if(alquileresInfo.Count == 0)
            {
                foreach (alquileres alquiler in alquileres)
                {
                    Clientes cliente = clientes.FirstOrDefault(c => c.Nit == alquiler.Nit);
                    if (cliente != null)
                    {

                        Vehiculo vehiculo = vehiculos.FirstOrDefault(v => v.Placa == alquiler.Placa);
                        if (vehiculo != null)
                        {

                            // Calcular el total a pagar
                            decimal totalPagar = alquiler.Kilometrosrecorridos * vehiculo.PrecioKm;

                            AlquilerInfo reporte = new AlquilerInfo
                            {
                                Nombre = cliente.Nombre,
                                Placa = vehiculo.Placa,
                                Modelo = vehiculo.Modelo,
                                Marca = vehiculo.Marca,
                                Color = vehiculo.Color,
                                PrecioKm = vehiculo.PrecioKm,
                                Fechadevolucion = alquiler.FechaDevolucion,
                                Totalpagar = totalPagar,
                            };
                            alquileresInfo.Add(reporte);
                        }
                    }
                }


                dataGridViewDatos.DataSource = null;
                dataGridViewDatos.DataSource = alquileresInfo;
                dataGridViewDatos.Refresh();



            }

            
           
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
            
            LeerAlquileres();
            CargarAlquileres();
            
        }



        public void calcularalquilermayor()
        {
            decimal maxKilometros = 0;
            foreach (var alquiler in alquileres)
            {
                if (alquiler.Kilometrosrecorridos > maxKilometros)
                {
                    maxKilometros = alquiler.Kilometrosrecorridos;
                }
            }

            // Muestra solo el valor de los kilómetros recorridos en label7
            label7.Text = "Kilómetros recorridos del alquiler máximo: " + maxKilometros.ToString();


            // Muestra solo el valor de los kilómetros recorridos en label7
            label7.Text = "Kilómetros recorridos del alquiler máximo: " + maxKilometros.ToString();

        }

        private void btnMostrarAlquiler_Click(object sender, EventArgs e)
        {
            calcularalquilermayor();
        }


    }
}
