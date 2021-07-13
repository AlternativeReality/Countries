using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Countries
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            WebRequest req = WebRequest.Create(@"https://restcountries.eu/rest/v2/name/" + textBox1.Text);

            WebResponse response = req.GetResponse();
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader r = new StreamReader(s))
                {
                    str = r.ReadToEnd();
                }
            }
            response.Close();
            //var weather = JsonConvert.DeserializeObject<Rootobject>(str);
            var data = JsonConvert.DeserializeObject<Country>(str.Substring(1, str.Length - 2));
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = data.name;
            dataGridView1.Rows[0].Cells[1].Value = data.alpha2Code;
            dataGridView1.Rows[0].Cells[2].Value = data.capital;
            dataGridView1.Rows[0].Cells[3].Value = data.area;
            dataGridView1.Rows[0].Cells[4].Value = data.population;
            dataGridView1.Rows[0].Cells[5].Value = data.region;

            //PropertyDescriptorCollection props =
            //TypeDescriptor.GetProperties(typeof(Country));
            //DataTable dt = new DataTable();
            //foreach (PropertyDescriptor p in props)
            //    dt.Columns.Add(p.Name, p.PropertyType);
            //object[] value = new object(props[i].GetValue);
            //dt.Rows.Add();
            ////DataTable dt = new DataTable();
            //DataRow dr = dt.NewRow();
            //dr[]
            //dt.Row.Add();
            //Debug.WriteLine(str);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
