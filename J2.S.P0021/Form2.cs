using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace J2.S.P0021
{
    public partial class formAdd : Form
    {
        public formAdd()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
             
            if (txtCode.Text == null)
            {
                txtCode.Text = "khong duoc de trong gia tri nay";
            }
            
           
            int credit = 0;
            if (Int32.TryParse(txtCredit.Text,out credit  ))
            {
                if (credit > 33)
                {
                    txtCredit.Text = "so nhap vao be hon 33";
                }
            }
            else
                txtCredit.Text = "vui long nhap so";

            Dictionary<string, List<string>> objData = new Dictionary<string, List<string>>();

            
            var inputName = new List<string>();
            inputName.Add(txtName.Text);

            var inputCode = new List<string>();
            inputCode.Add(txtCode.Text);

            var inputCredit = new List<string>();
            inputCredit.Add(txtCredit.Text);

            //thêm giá trị vào đối tượng trên
            objData.Add("Code", inputCode);
            objData.Add("Name", inputName);
            objData.Add("Credit", inputCredit);

            string json = JsonConvert.SerializeObject(objData);
            string fileName = "Mahesh.json";

           
            if (!File.Exists(fileName))
            {
                using (FileStream fs = File.Create("Mahesh.json"))
                {
                   
                    Byte[] title = new UTF8Encoding(true).GetBytes(json);
                    fs.Write(title, 0, title.Length);
                }
            }
            else
            {
                var jsonData = "";
                using (StreamReader sr = File.OpenText(fileName))
                {

                    Dictionary<string, List<string>> dicData = new Dictionary<string, List<string>>();

                    var test = sr.ReadToEnd();
                    dicData = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(test);


                    var lstName = dicData["Name"];
                    var lstCode = dicData["Code"];
                    var lstCredit = dicData["Credit"];

                    //add dữ liệu mới vào list
                    lstName.Add(txtName.Text);
                    lstCode.Add(txtCode.Text);
                    lstCredit.Add(txtCredit.Text);


                    dicData["Name"] = lstName;
                    dicData["Code"] = lstCode;
                    dicData["Credit"] = lstCredit;


                    jsonData = JsonConvert.SerializeObject(dicData);

                }

                File.Delete(fileName);
               
                using (FileStream fs = File.Create(fileName))
                {
                   
                    Byte[] title = new UTF8Encoding(true).GetBytes(jsonData);
                    fs.Write(title, 0, title.Length);
                }

            }
            
            MessageBox.Show("Hoàn thành");

        }

        private void FormAdd_Load(object sender, EventArgs e)
        {

        }

        private void TbxCode_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtCredit.Text = "";
            txtName.Text = "";
        }

        private void TxtCredit_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
