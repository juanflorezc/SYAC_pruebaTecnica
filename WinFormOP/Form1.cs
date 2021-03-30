using Newtonsoft.Json;
using SYAC_OP.model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormOP
{
    public partial class Form1 : Form
    {
        private List<Producto> productos = new List<Producto>();
        private List<Producto> personListProduct = new List<Producto>();
        private string endpoint = "https://localhost:44312/api/";
        public Form1()
        {
            InitializeComponent();
            setDataList();
        }
        private async void setDataList()
        {
            // Create HttpClient
            var client = new HttpClient { BaseAddress = new Uri(endpoint) };
            var responseMessage = await client.GetAsync("cliente/geName", HttpCompletionOption.ResponseContentRead);
            var resultArray = await responseMessage.Content.ReadAsStringAsync();
            List<string> personList = JsonConvert.DeserializeObject<List<string>>(resultArray);
            clienteSel.DataSource = personList;

            var responseMessageProdcut = await client.GetAsync("producto", HttpCompletionOption.ResponseContentRead);
            var resultArrayProduct = await responseMessageProdcut.Content.ReadAsStringAsync();
            personListProduct = JsonConvert.DeserializeObject<List<Producto>>(resultArrayProduct);
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Valor");
            foreach(var product in personListProduct)
            {
                DataRow row = dt.NewRow();
                row[0] = product.Nombre;
                row[1] = product.ValorUnitario;
                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var producto = personListProduct[e.RowIndex];
            productos.Add(producto);
            double suma = 0;

            foreach(var productoagregado in productos)
            {
                suma += productoagregado.ValorUnitario;
                label8.Text = label8.Text+" "+productoagregado.Nombre;
            }
            string prioridad = "";
            if (suma <= 500)
            {
                prioridad = "Baja";
            }
            else if (suma > 500 && suma <= 1000)
            {
                prioridad = "Media";
            }
            else
            {
                prioridad = "Alta";
            }
            textBox3.Text = prioridad;
            textBox2.Text = suma.ToString();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            OrdenPedido objenviar = new OrdenPedido();
            objenviar.Borrado = false;
            objenviar.ClienteId = 4;
            objenviar.DireccionEntrega = textBox1.Text;
            objenviar.PrioridadId = 7;
            objenviar.ValorTotal = Convert.ToDouble(textBox2.Text);
            foreach(var producto in this.productos)
            {
                OrdenPedidoDetalle ordede = new OrdenPedidoDetalle();
                ordede.Cantidad = 1;
                ordede.CreadoPor = "admin";
                ordede.FechaCreacion = DateTime.Now;
                ordede.ProductoId = producto.ProductoId;
                objenviar.OrdenPedidoDetalles.Add(ordede);
            }
            var client = new HttpClient { BaseAddress = new Uri(endpoint) };
            var myContent = JsonConvert.SerializeObject(objenviar);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseMessage = await client.PostAsync("ordenPedido", byteContent);
            MessageBox.Show("Orden creada satisfactoriamente");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            this.productos = new List<Producto>();
            var responseMessageProdcut = await client.GetAsync("ordenPedido", HttpCompletionOption.ResponseContentRead);
            var resultArrayProduct = await responseMessageProdcut.Content.ReadAsStringAsync();
            List<OrdenPedido> ordenPedidos = JsonConvert.DeserializeObject<List<OrdenPedido>>(resultArrayProduct);
            DataTable dt = new DataTable();
            dt.Columns.Add("Dirección de entrega");
            dt.Columns.Add("Valor Total");
            foreach (var ordenes in ordenPedidos)
            {
                DataRow row = dt.NewRow();
                row[0] = ordenes.DireccionEntrega;
                row[1] = ordenes.ValorTotal;
                dt.Rows.Add(row);
            }
            dataGridView2.DataSource = dt;
        }
    }
}
