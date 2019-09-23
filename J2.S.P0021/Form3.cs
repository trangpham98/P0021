using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.IO;

namespace J2.S.P0021
{
    public partial class SearchCourse : Form
    {
        public SearchCourse()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            //string json = JsonConvert.SerializeObject(objData);
            string fileName = @"C:\Users\Trang\source\repos\J2.S.P0021.demo\J2.S.P0021\bin\Debug\Mahesh.json";

            using (StreamReader sr = new StreamReader(fileName))
            {
                string json = sr.ReadToEnd();
                var obj = jss.Deserialize<dynamic>(json);

                string xuatName = "";
                string xuatCredit = "";

                for (int i = 0; i < obj["Name"].Length; i++)
                {
                    if (tbxCode.Text == obj["Code"][i])
                    {
                        xuatName = obj["Name"][i];
                        xuatCredit = obj["Credit"][i];
                        txtCredit.Text = xuatCredit;
                        txtName.Text = xuatName;
                    }
                    else
                    {
                        tbxCode.Text = "Not found code";
                    }

                }
                
            }
        }

            private void TbxCode_TextChanged(object sender, EventArgs e)
        {
            

            

        }

        private void SearchCourse_Load(object sender, EventArgs e)
        {

        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
