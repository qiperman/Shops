using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public DataTable table1;
        public Form1()
        {
            InitializeComponent();
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Матвеев В.С.\nГруппа: ИАС-14 \nТема: База данных магазинов","Информация");
        }

        private void shopsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.shopsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myBaseDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myBaseDataSet.Order' table. You can move, or remove it, as needed.
            this.orderTableAdapter.Fill(this.myBaseDataSet.Order);
            // TODO: This line of code loads data into the 'myBaseDataSet.staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.myBaseDataSet.staff);
            // TODO: This line of code loads data into the 'myBaseDataSet.shops' table. You can move, or remove it, as needed.
            this.shopsTableAdapter.Fill(this.myBaseDataSet.shops);

        }

        private void staffDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int id;

        private void shopsDataGridView_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                id = shopsDataGridView.CurrentRow.Index;
                label1.Text = "ID:" + shopsDataGridView.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = shopsDataGridView.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = shopsDataGridView.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = shopsDataGridView.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = shopsDataGridView.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = shopsDataGridView.CurrentRow.Cells[5].Value.ToString();
                groupBox1.Text = shopsDataGridView.CurrentRow.Cells[3].Value.ToString();
            }
            catch { }
        }
        static string fun = "add";
        private void button1_Click(object sender, EventArgs e)
        {
            //Делаем доступными поля
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;

            //Очищаем поля
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            label1.Text = "ID: " + (shopsDataGridView.RowCount+1).ToString();
            label8.Text = "Добавление нового магазина";


            fun = "add"; //переменная функции присваивается значению add- добавление
            id = shopsDataGridView.RowCount; 
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (fun == "add")
            {
                myBaseDataSet.shops.AddshopsRow(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            }

            if (fun == "edt")
            {
                shopsDataGridView.CurrentRow.Cells[1].Value = textBox1.Text;
                shopsDataGridView.CurrentRow.Cells[2].Value = textBox2.Text;
                shopsDataGridView.CurrentRow.Cells[3].Value = textBox3.Text;
                shopsDataGridView.CurrentRow.Cells[4].Value = textBox4.Text;
                shopsDataGridView.CurrentRow.Cells[5].Value = textBox5.Text;
            }
            shopsDataGridView.Rows[id].Selected = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            button4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Делаем доступными для редактирования поля
            button4.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;

            fun = "edt"; // присваиваем перменной функции edt-редактирования
            id = shopsDataGridView.CurrentRow.Index;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                shopsDataGridView.Rows.Remove(shopsDataGridView.CurrentRow);
        
        }
        
        private void staffDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                dateTimePicker1.Enabled = false;
                comboBox1.Enabled = false;
                pictureBox1.Enabled = false;


                id = staffDataGridView.CurrentRow.Index;
                groupBox2.Text = staffDataGridView.CurrentRow.Cells[2].Value.ToString();
                comboBox1.Text = staffDataGridView.CurrentRow.Cells[1].Value.ToString();
                textBox6.Text = staffDataGridView.CurrentRow.Cells[2].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(staffDataGridView.CurrentRow.Cells[3].Value);
                textBox7.Text = staffDataGridView.CurrentRow.Cells[4].Value.ToString();
                textBox8.Text = staffDataGridView.CurrentRow.Cells[5].Value.ToString();
                textBox9.Text = staffDataGridView.CurrentRow.Cells[6].Value.ToString();
                textBox10.Text = staffDataGridView.CurrentRow.Cells[7].Value.ToString();
                label21.Text = "ID: "+staffDataGridView.CurrentRow.Cells[0].Value.ToString();

                if (!(staffDataGridView.CurrentRow.Cells[8].Value is DBNull))
                 {
                byte[] qwe = (byte[])staffDataGridView.CurrentRow.Cells[8].Value;

                MemoryStream ms = new MemoryStream(qwe);
                pictureBox1.Image = Image.FromStream(ms);
                }
                else
                {
                    pictureBox1.Image = null;
                }
               
                DataTable shops = myBaseDataSet.Tables[1];

                IEnumerable<DataRow> query =    from item in shops.AsEnumerable()
                                                where (item[0].ToString() == comboBox1.Text)
                      
                                                select item;
                foreach (DataRow p in query)
                {
                    label8.Text = (p.Field<string>("nameS"));
                }
                label8.Text += " ID: " + staffDataGridView.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }
            

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Делаем все поля доступными
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;
            pictureBox1.Enabled = true;
            label21.Text = "ID: " + (staffDataGridView.RowCount+1).ToString();

            //очищаем поля
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            DateTime date2000 = new DateTime(2000, 01, 01, 0, 0, 0);
            dateTimePicker1.Value = date2000;
            comboBox1.Text = "";
            pictureBox1.Image = null;
            label8.Text = "";


            DataTable shops = myBaseDataSet.Tables[1];
            IEnumerable<DataRow> query = from item in shops.AsEnumerable()
                                         select item;
            foreach (DataRow p in query)
            {
                comboBox1.Items.Add(p.Field<int>("Id").ToString());
            }


            fun = "add";
            id = staffDataGridView.RowCount;
            button5.Enabled = true;
          
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;
            pictureBox1.Enabled = true;

            fun = "edt";
            id = staffDataGridView.CurrentRow.Index;
            button5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (fun == "add")
            { 
                byte[] myArr1;
                if (pictureBox1.Image != null)
                {
                    myArr1 = imageToByteArray(pictureBox1.Image);
                }
                else
                {
                    myArr1 = null;
                }
               
               
                myBaseDataSet.staff.AddstaffRow(Convert.ToInt32(comboBox1.Text), textBox6.Text, dateTimePicker1.Value, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text,myArr1);
            }

            if (fun == "edt")
            {
                staffDataGridView.CurrentRow.Cells[1].Value = comboBox1.Text;
                staffDataGridView.CurrentRow.Cells[2].Value = textBox6.Text;
                staffDataGridView.CurrentRow.Cells[3].Value = dateTimePicker1.Value;
                staffDataGridView.CurrentRow.Cells[4].Value = textBox7.Text;
                staffDataGridView.CurrentRow.Cells[5].Value = textBox8.Text;
                staffDataGridView.CurrentRow.Cells[6].Value = textBox9.Text;
                staffDataGridView.CurrentRow.Cells[7].Value = textBox10.Text;
                if (pictureBox1.Image != null)
                {
                    staffDataGridView.CurrentRow.Cells[8].Value = imageToByteArray(pictureBox1.Image);
                }
            }
           
            staffDataGridView.Rows[id].Selected = true;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox1.Enabled = false;
            pictureBox1.Enabled = false;
            button4.Enabled = false;
           
        }

        private void сохранитьВсеТаблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            this.shopsBindingSource.EndEdit();
            this.orderBindingSource.EndEdit();
            this.staffBindingSource.EndEdit();
            shopsTableAdapter.Update(myBaseDataSet.shops);
            orderTableAdapter.Update(myBaseDataSet.Order);
            staffTableAdapter.Update(myBaseDataSet.staff);
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private void orderDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox11.Enabled = false;
                textBox12.Enabled = false;
                textBox14.Enabled = false;
                comboBox2.Enabled = false;
                checkBox1.Enabled = false;
                pictureBox2.Enabled = false;

                id = orderDataGridView.CurrentRow.Index;
                groupBox3.Text = orderDataGridView.CurrentRow.Cells[2].Value.ToString();
                comboBox1.Text = orderDataGridView.CurrentRow.Cells[1].Value.ToString();
                textBox11.Text = orderDataGridView.CurrentRow.Cells[2].Value.ToString();
                
                textBox12.Text = orderDataGridView.CurrentRow.Cells[3].Value.ToString();
                if (orderDataGridView.CurrentRow.Cells[5].Value.ToString() =="True")
                {
                    label20.Visible = true;
                    textBox14.Visible = true;
                }
                else
                {
                    label20.Visible = false;
                    textBox14.Visible = false;
                }
                textBox14.Text =orderDataGridView.CurrentRow.Cells[4].Value.ToString();

                label7.Text = "ID: " + orderDataGridView.CurrentRow.Cells[0].Value.ToString();

                if (!(orderDataGridView.CurrentRow.Cells[6].Value is DBNull))
                {
                    byte[] qwe = (byte[])staffDataGridView.CurrentRow.Cells[6].Value;

                    MemoryStream ms = new MemoryStream(qwe);
                    pictureBox2.Image = Image.FromStream(ms);
                }
                else
                {
                    pictureBox1.Image = null;
                }

                DataTable shops = myBaseDataSet.Tables[1];

                IEnumerable<DataRow> query = from item in shops.AsEnumerable()
                                             where (item[0].ToString() == comboBox1.Text)

                                             select item;
                foreach (DataRow p in query)
                {
                    label19.Text = (p.Field<string>("nameS"));
                }
                label19.Text += " ID: " + orderDataGridView.CurrentRow.Cells[1].Value.ToString();
                button9.Enabled = false;
            }
            catch { }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox11.Enabled = true;
            textBox12.Enabled =true;
            textBox14.Enabled = true;
            comboBox2.Enabled = true;
            checkBox1.Enabled = true;
            pictureBox2.Enabled = true;
            label21.Text = "ID: " + (orderDataGridView.RowCount + 1).ToString();

            textBox11.Text = "";
            textBox12.Text = "";
            textBox14.Text = "";
            comboBox2.Text = "";
            pictureBox1.Image = null;
            label7.Text = "";

            DataTable shops = myBaseDataSet.Tables[1];
            IEnumerable<DataRow> query = from item in shops.AsEnumerable()
                                         select item;
            foreach (DataRow p in query)
            {
                comboBox2.Items.Add(p.Field<int>("Id").ToString());
            }


            fun = "add";
            id = orderDataGridView.RowCount;
            button9.Enabled = true;
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                staffDataGridView.Rows.Remove(staffDataGridView.CurrentRow);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                orderDataGridView.Rows.Remove(orderDataGridView.CurrentRow);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox11.Enabled = true;
            textBox12.Enabled = true;
            textBox14.Enabled = true;
            comboBox2.Enabled = true;
            checkBox1.Enabled = true;
            pictureBox2.Enabled = true;
            fun = "edt";
            id = orderDataGridView.CurrentRow.Index;
            button9.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (fun == "add")
            {
                byte[] myArr1;
                if (pictureBox2.Image != null)
                {
                     myArr1= imageToByteArray(pictureBox2.Image);
                }
                else
                {
                     myArr1 = null;
                }
                myBaseDataSet.Order.AddOrderRow(Convert.ToInt32(comboBox2.Text), textBox11.Text, Convert.ToInt32(textBox12.Text), Convert.ToInt32(textBox14.Text), myArr1, checkBox1.Checked);
            }

            if (fun == "edt")
            {
                orderDataGridView.CurrentRow.Cells[1].Value = comboBox1.Text;
                orderDataGridView.CurrentRow.Cells[2].Value = textBox11.Text;
                orderDataGridView.CurrentRow.Cells[3].Value = textBox12.Text;
                orderDataGridView.CurrentRow.Cells[4].Value = textBox14.Text;
                orderDataGridView.CurrentRow.Cells[5].Value = checkBox1.Checked;
                if (pictureBox2.Image != null)
                {
                    orderDataGridView.CurrentRow.Cells[6].Value = imageToByteArray(pictureBox2.Image);
                }
            }

            orderDataGridView.Rows[id].Selected = true;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox14.Enabled = false;
            comboBox2.Enabled = false;
            pictureBox2.Enabled = false;
            checkBox1.Enabled = false;
            button9.Enabled = false;
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                      if(checkBox1.Checked == true)     {
                    label20.Visible = true;
                    textBox14.Visible = true;
                }
                else
                {
                    label20.Visible = false;
                    textBox14.Visible = false;
                }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 58) && (e.KeyChar != 8 )&& e.KeyChar != 43 )
                e.Handled = true;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 58) && (e.KeyChar != 8))
                e.Handled = true;
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 58) && (e.KeyChar != 8))
                e.Handled = true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 58) && (e.KeyChar != 8) && e.KeyChar != 43)
                e.Handled = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_MouseClick(object sender, MouseEventArgs e)
        {
            textBox13.Text = "";
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            textBox13.Text = "Поиск...";
        }

        private void textBox15_Click(object sender, EventArgs e)
        {
            textBox15.Text = "";
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            textBox15.Text = "Поиск...";
        }

        private void textBox16_Click(object sender, EventArgs e)
        {
            textBox16.Text = "";
        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            textBox16.Text = "Поиск...";
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if ((textBox16.Text != "") && (textBox16.Text != "Поиск..."))
            {
                var query = from o in this.myBaseDataSet.Order
                            where o.Amount.ToString().Contains(textBox16.Text) || o.Id_order.ToString().Contains(textBox16.Text) || o.Id_shop.ToString().Contains(textBox16.Text) || o.Name_ord.Contains(textBox16.Text) || o.Price.ToString().Contains(textBox16.Text)
                            select o;

                orderBindingSource.DataSource = query.ToList();
            }
            else 
            {
                 var query = from o in this.myBaseDataSet.Order
                             select o;

                 orderBindingSource.DataSource = query.ToList();
                     
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if ((textBox13.Text != "") && (textBox13.Text != "Поиск..."))
            {
                var query = from o in this.myBaseDataSet.shops
                            where o.adress.ToString().Contains(textBox13.Text) || o.city.ToString().Contains(textBox13.Text) || o.email.ToString().Contains(textBox13.Text) || o.id.ToString().Contains(textBox13.Text) || o.nameS.ToString().Contains(textBox13.Text) || o.Phone.ToString().Contains(textBox13.Text)
                            select o;

                shopsBindingSource.DataSource = query.ToList();
            }
            else {
                var query = from o in this.myBaseDataSet.shops
                            select o;

                shopsBindingSource.DataSource = query.ToList();
            }

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

            if ((textBox15.Text != "") && (textBox15.Text != "Поиск..."))
            {
                var query = from o in this.myBaseDataSet.staff
                            where o.Address.ToString().Contains(textBox15.Text) || o.Email.ToString().Contains(textBox15.Text) || o.Fio.ToString().Contains(textBox15.Text) || o.id_shop.ToString().Contains(textBox15.Text) || o.id_staff.ToString().Contains(textBox15.Text) || o.Phone.ToString().Contains(textBox15.Text) || o.Post.ToString().Contains(textBox15.Text)
                            select o;

                staffBindingSource.DataSource = query.ToList();
            }
            else
            { 
            var query = from o in this.myBaseDataSet.staff
                        select o;

            staffBindingSource.DataSource = query.ToList();
            }
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    pictureBox2.Image = Image.FromFile(ofd.FileName);
            }
        }



    }
}
