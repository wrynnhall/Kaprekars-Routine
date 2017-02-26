using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KaprekarNumberApp;
using KaprekarNumbers;


namespace KaprekarNumberApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                int answer = KaprekarsConstant.kaprekarsRoutine((int)numberInput.Value);
                lblAnswer.Text = answer.ToString();
            }
            catch(InvalidOperationException)     
            {
                
              
                MessageBox.Show("Read the rules then try again", "INVALID INPUT");
            }
            
        }

        
    }
}
