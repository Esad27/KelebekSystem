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
    public partial class Form3 : Form
    {
        ArrayList bitmis=new ArrayList();
        public Form3(Form1 ana,ArrayList veri,string sinif)
        {
            InitializeComponent();
            bitmis = veri;
            this.Text = sinif;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            if (bitmis.Count>=1)
            {
                label11.Text = bitmis[0].ToString();
            }
            if (bitmis.Count >= 2)
            {
                label12.Text = bitmis[1].ToString();
            }
            if (bitmis.Count >= 3)
            {
                label14.Text = bitmis[2].ToString();
            }
            //
            if (bitmis.Count>=4)
            {
                label15.Text = bitmis[3].ToString();
            }
            if (bitmis.Count >= 5)
            {
                label17.Text = bitmis[4].ToString();
            }
            if (bitmis.Count >= 6)
            {
                label18.Text = bitmis[5].ToString();

            }
            //
            if (bitmis.Count >= 7)
            {
                label19.Text = bitmis[6].ToString();

            }
            if (bitmis.Count >= 8)
            {
                label20.Text = bitmis[7].ToString();

            }
            if (bitmis.Count >= 9)
            {
                label22.Text = bitmis[8].ToString();

            }
            //
            if (bitmis.Count >= 10)
            {
                label23.Text = bitmis[9].ToString();


            }
            if (bitmis.Count >= 11)
            {
                label25.Text = bitmis[10].ToString();


            }
            if (bitmis.Count >= 12)
            {
                label26.Text = bitmis[11].ToString();


            }
            //

            if (bitmis.Count >= 13)
            {
                label27.Text = bitmis[12].ToString();



            }
            if (bitmis.Count >= 14)
            {
                label28.Text = bitmis[13].ToString();



            }
            if (bitmis.Count >= 15)
            {
                label30.Text = bitmis[14].ToString();



            }
            if (bitmis.Count >= 16)
            {
                label31.Text = bitmis[15].ToString();


            }
            if (bitmis.Count >= 17)
            {
                label33.Text = bitmis[16].ToString();


            }
            if (bitmis.Count >= 18)
            {
                label34.Text = bitmis[17].ToString();



            }
            //
            if (bitmis.Count >= 19)
            {
                label35.Text = bitmis[18].ToString();



            }
            if (bitmis.Count >= 20)
            {
                label36.Text = bitmis[19].ToString();




            }
            if (bitmis.Count >= 21)
            {
                label38.Text = bitmis[20].ToString();




            }
            if (bitmis.Count >= 22)
            {
                label39.Text = bitmis[21].ToString();


            }
            if (bitmis.Count >= 23)
            {
                label41.Text = bitmis[22].ToString();


            }
            if (bitmis.Count >= 24)
            {
                label42.Text = bitmis[23].ToString();




            }
            //
            if (bitmis.Count >= 25)
            {
                label43.Text = bitmis[24].ToString();




            }
            if (bitmis.Count >= 26)
            {
                label44.Text = bitmis[25].ToString();





            }
            if (bitmis.Count >= 27)
            {
                label46.Text = bitmis[26].ToString();





            }
            if (bitmis.Count >= 28)
            {
                label47.Text = bitmis[27].ToString();



            }
            if (bitmis.Count >= 29)
            {
                label49.Text = bitmis[28].ToString();



            }
            if (bitmis.Count >= 30)
            {
                label50.Text = bitmis[29].ToString();

            }







        }
    }
}
