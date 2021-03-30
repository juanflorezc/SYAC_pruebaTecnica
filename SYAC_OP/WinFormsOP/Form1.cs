using Newtonsoft.Json;
using SYAC_OP.model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setClientData();
        }

        private async void setClientData()
        {
            // Create HttpClient
            var client = new HttpClient { BaseAddress = new Uri("http://localhost:8888/") };

            // Assign default header (Json Serialization)
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApiConstant.JsonHeader));

            // Make an API call and receive HttpResponseMessage
            var responseMessage = await client.GetAsync("cliente", HttpCompletionOption.ResponseContentRead);

            // Convert the HttpResponseMessage to string
            var resultArray = await responseMessage.Content.ReadAsStringAsync();

            // Deserialize the Json string into type using JsonConvert
            List<Cliente> personList = JsonConvert.DeserializeObject<List<Cliente>>(resultArray);
            clienteSel.DataSource = personList;

        }

    }
}
