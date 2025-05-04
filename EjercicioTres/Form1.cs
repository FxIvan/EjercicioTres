using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace EjercicioTres
{
    public partial class Form1 : Form
    {
        List<Espectador> listaEspectador = new List<Espectador>();
        public Form1()
        {
            InitializeComponent();
        }

        private void MostrarLista()
        {
            decimal total = 0;
            lstEspectadores.Items.Clear();
            foreach (var espectador in listaEspectador)
            {
                total += espectador.Monto;
                lstEspectadores.Items.Add(espectador); // .ToString() se llamará automáticamente
            }

            lblTotaRecaudado.Text = total.ToString();
        }

        public void LlenarAleatoriamente()
        {
            var rand = new Random(); // Solo una instancia

            // Grupo 1: 5 a 12 años - $500
            for (int i = 0; i < 5; i++)
            {
                Espectador espectador = new Espectador
                {
                    Nombre = DatosGlobales.Nombres[i],
                    Edad = rand.Next(5, 13), // 5-12 inclusive
                    Monto = 500,
                    IsNew = false
                };
                listaEspectador.Add(espectador);
            }

            // Grupo 2: 13 a 17 años - $700
            for (int i = 5; i < 10; i++)
            {
                Espectador espectador = new Espectador
                {
                    Nombre = DatosGlobales.Nombres[i],
                    Edad = rand.Next(13, 18), // 13-17 inclusive
                    Monto = 700,
                    IsNew = false
                };
                listaEspectador.Add(espectador);
            }

            // Grupo 3: 18 a 59 años - $1000
            for (int i = 10; i < 15; i++)
            {
                Espectador espectador = new Espectador
                {
                    Nombre = DatosGlobales.Nombres[i],
                    Edad = rand.Next(18, 60), // 18-59 inclusive
                    Monto = 1000,
                    IsNew = false
                };
                listaEspectador.Add(espectador);
            }

            // Grupo 4: 60 años - $600
            for (int i = 15; i < 20; i++)
            {
                Espectador espectador = new Espectador
                {
                    Nombre = DatosGlobales.Nombres[i],
                    Edad = rand.Next(60,150),
                    Monto = 600,
                    IsNew = false
                };
                listaEspectador.Add(espectador);
            }

            MostrarLista();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarAleatoriamente();
        }

        private void btnNuevoEspectador_Click(object sender, EventArgs e)
        {
            Espectador espectador = new Espectador
            {
                Nombre = txtNombre.Text,
                Edad = Convert.ToInt32(txtEdad.Text),
                Monto = Convert.ToDecimal(txtMonto.Text),
                IsNew = true
            };
            listaEspectador.Add(espectador);
            MostrarLista();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string curItem = lstEspectadores.SelectedItem.ToString();
            int index = lstEspectadores.FindString(curItem);
            for (int i = 0; i < listaEspectador.Count; i++)
            {
                if (i == index)
                {
                    listaEspectador.RemoveAt(i);
                }
            }
            MostrarLista();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string curItem = lstEspectadores.SelectedItem.ToString();
            int index = lstEspectadores.FindString(curItem);

            if (index >= 0)
            {
                if (txtNombre.Text.Length > 0)
                {
                    listaEspectador[index].Nombre = txtNombre.Text;
                }

                if (txtEdad.Text.Length > 0)
                {
                    listaEspectador[index].Edad = Convert.ToInt32(txtEdad.Text);
                }

                if (txtMonto.Text.Length > 0)
                {
                    listaEspectador[index].Monto = Convert.ToDecimal(txtMonto.Text);
                }
                listaEspectador[index].IsNew = false;
                MostrarLista();
            }
        }

        private void btnAgregarDespues_Click(object sender, EventArgs e)
        {
            string curItem = lstEspectadores.SelectedItem.ToString();
            int index = lstEspectadores.FindString(curItem);
            Espectador nuevoPaciente = new Espectador
            {
                Nombre = txtNombre.Text,
                Edad = Convert.ToInt32(txtEdad.Text),
                Monto = Convert.ToDecimal(txtMonto.Text),
                IsNew = true
            };
            listaEspectador.Insert(index + 1, nuevoPaciente);
            MostrarLista();
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            MostrarLista();
        }
    }
}
