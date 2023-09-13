using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         public void clearText() 
        {
            textBoxAge.Clear();
            textBoxFamily.Clear();
            textBoxName.Clear();
            textBoxName.Focus();
        }
        private void buttonRegiester_Click(object sender, EventArgs e)
        {
            if(b == false)
            {
                
                human human = new human() { name = textBoxName.Text, family = textBoxFamily.Text, age = Convert.ToInt32(textBoxAge.Text) };
                bool b = human.register(human);
                if (b)
                {
                    MessageBox.Show("done");
                    clearText();
                }
                else
                {
                    MessageBox.Show("کاربر تکراری است");
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = db1.Humans.ToList();
            }
            else
            {
                human human = new human() { name = textBoxName.Text, family = textBoxFamily.Text, age = Convert.ToInt32(textBoxAge.Text) };

                human.update(human, id);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.readAll();
                clearText();

                b = false;
                buttonRegiester.Text = "Regiester";
            }
        }

           
        public db db1 = new db();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = db1.Humans.ToList();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {  
            human human = new human();

            if(textBoxSearch.Text == "")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.readAll();
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.readByName(textBoxSearch.Text);

            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            human human = new human();
            
            


            if (id != 0)
            {
                DialogResult = MessageBox.Show("Are you sure?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    human.delete(id);
                    id = 0;

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = human.readAll();
                }
            }
        }

        public int id = 0;
        public bool b = false;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            b = true;
            buttonRegiester.Text = "Update";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            human human = new human();  
            human=  human.readbyid(id); 
            textBoxName.Text = human.name;
            textBoxFamily.Text = human.family;
            textBoxAge.Text = human.age.ToString();
        }
    }
} 
