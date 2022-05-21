using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace kelebek
{
    public partial class Form2 : Form
    {
        Form1 ana=new Form1();

        string names ;
        string arrayList;
        public Form2(Form1 ankara,string name)
        {
            InitializeComponent();
            ana=ankara;
            names = name;
            arrayList = name+";";
            button1.Text=names+" Sınavına Katılcak Sınıfları kaydet";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {
         
            foreach (var item in ana.aktarim)
            {
                
               checkedListBox1.Items.Add(item);
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count!=0)
            {

            
            foreach (var item in checkedListBox1.CheckedItems)
            {
                ana.aktarim.Remove(item);
                arrayList+=item.ToString()+ "*" ;

            }
            
            ana.kayit.Add(arrayList);
            }
            else { MessageBox.Show("Hicbirsey Secilmedi!", "BILGILENDIRME", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            this.Close();

        }
    }
}
