using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace J2.S.P0021
{
    public partial class ListCourse : Form
    {
        public ListCourse()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            
        }

        private void TxtList_TextChanged(object sender, EventArgs e)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            //string json = JsonConvert.SerializeObject(objData);
            string fileName = @"C:\Users\Trang\source\repos\J2.S.P0021.demo\J2.S.P0021\bin\Debug\Mahesh.json";

            using (StreamReader sr = new StreamReader(fileName))
            {
                string json = sr.ReadToEnd();
                var obj = jss.Deserialize<dynamic>(json);

                string xuat = "";


                for (int i = 0; i < obj["Name"].Length; i++)
                {
                    xuat = obj["Code"][i] + "|" + obj["Name"][i] + "|" + obj["Credit"][i];

                }
                txtList.Text = xuat;

            }
        }
    }
}
