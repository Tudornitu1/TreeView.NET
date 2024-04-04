using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form2 : Form
    {
        ErrorProvider errorProvider;

        internal Tractor tractor;

        public Form2()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider.SetError(textBox1, "Name is required");
                return;
            }
            if (textBox2.Text == "")
            {
                errorProvider.SetError(textBox2, "Model is required");
                return;
            }
            if (textBox4.Text == "")
            {
                errorProvider.SetError(textBox3, "Color is required");
                return;
            }
            if (!int.TryParse(textBox3.Text, out int year) || year > 2024)
            {
                errorProvider.SetError(textBox4, "Year is not good");
                return;
            }

            tractor = new Tractor(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            DialogResult = DialogResult.OK;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
