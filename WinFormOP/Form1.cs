using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormOP
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
            var client = new HttpClient { BaseAddress = new Uri("https://localhost:44312/api/") };

            // Assign default header (Json Serialization)
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApiConstant.JsonHeader));

            // Make an API call and receive HttpResponseMessage
            var responseMessage = await client.GetAsync("cliente/geName", HttpCompletionOption.ResponseContentRead);

            // Convert the HttpResponseMessage to string
            var resultArray = await responseMessage.Content.ReadAsStringAsync();

            // Deserialize the Json string into type using JsonConvert
            List<string> personList = JsonConvert.DeserializeObject<List<string>>(resultArray);
            clienteSel.DataSource = personList;            

        }
    }
}
