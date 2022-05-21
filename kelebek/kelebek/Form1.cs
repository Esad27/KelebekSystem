using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing.Drawing2D;
using System.Data;
using System.Collections;

namespace kelebek
{
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig {
            AuthSecret = "rqipcgoTW8ajOuxD1oBuZMhU5gDZdiGhCB4PJ5Th",
            BasePath = "https://saben-aaf4f-default-rtdb.europe-west1.firebasedatabase.app/",

        };
        IFirebaseClient client;
        int selectedindex = -1;
        public Form1()
        {
            InitializeComponent();

            /*
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                // MessageBox.Show(e.Message);
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }*/
        }


        JObject siniflar;
        JObject sinifkpst;
        public ArrayList sinifar = new ArrayList();
        public ArrayList aktarim = new ArrayList();
        public ArrayList kayit = new ArrayList();
        public async void refresh()
        {
            FirebaseResponse gelen = await client.GetTaskAsync("siniflar");
            FirebaseResponse gelen2 = await client.GetTaskAsync("salonlar");
            dynamic id = gelen.Body;
            dynamic id2 = gelen2.Body;
            if (id != "\"\"")
            {
                sinifkpst = JObject.Parse(id2);
                siniflar = JObject.Parse(id);
                listBox1.Items.Clear();
                checkedListBox1.Items.Clear();
                foreach (var sinif in siniflar)
                {


                    listBox1.Items.Add(sinif.Key);
                    checkedListBox1.Items.Add(sinif.Key);
                    sinifar.Add(sinif.Key);
                    aktarim.Add(sinif.Key);


                }


            }



            // label4.Text = "Bagli";


            //yapiBindingSource.Find("esad");
            //yapiBindingSource.Find("isim", "esad"); 
            // MessageBox.Show((58).ToString());


            dataGridView1.BackgroundColor = Color.White; dataGridView1.BorderStyle = BorderStyle.None;
            //label5.Text = jsodn["sad"]["fawf"].ToString();


        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            



            // dataGridView1.CurrentRow = null;

            if (client != null)
            {
                refresh();
            };


        }

        private void yapiBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        public async void ekle()
        {
            var eklenen = new Ogrenci { isim = textBox1.Text, soyad = textBox2.Text, sinif = int.Parse(textBox4.Text), sube = textBox5.Text, no = int.Parse(textBox3.Text) };

            SetResponse resp = await client.SetTaskAsync("siniflar/" + int.Parse(textBox4.Text) + "-" + textBox5.Text + "/" + int.Parse(textBox3.Text), eklenen);
            JObject name = JObject.Parse(resp.Body);
            refresh();


        }
        public async void sill()
        {
            DeleteResponse resp = await client.DeleteTaskAsync("siniflar/" + sinif + "-" + sübee + "/" + no);
            JObject silinen = JObject.Parse(resp.Body);
            refresh();
        }
        int no = -1;
        int sinif = -1;
        string sübee = "null";
        private void button1_Click_1(object sender, EventArgs e)
        {

            if (checkBox1.Checked)//ekle
            {
                ekle();


                yapiBindingSource.Add(new yapi() { isim = textBox1.Text, soyad = textBox2.Text, sinif = int.Parse(textBox4.Text), sube = textBox5.Text, no = int.Parse(textBox3.Text) });

            }
            else//düzenle
            {
                sill();
                ekle();
                yapiBindingSource.RemoveAt(dataGridView1.SelectedRows[0].Index);
                yapiBindingSource.Add(new yapi() { isim = textBox1.Text, soyad = textBox2.Text, sinif = int.Parse(textBox4.Text), sube = textBox5.Text, no = int.Parse(textBox3.Text) });
            }





            //MessageBox.Show(dataGridView1.SelectedRows[0].ToString());
            //MessageBox.Show(dataGridView1.Rows[0].Cells[1].Value.ToString());
            //String searchValue = "esad";
            //int rowIndex = -1;
            //for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //{
            //    if ((dataGridView1.Rows[i].Cells[2].Value).ToString().Equals(searchValue))
            //    {
            //        rowIndex = dataGridView1.Rows[i].Index;
            //        MessageBox.Show(rowIndex.ToString());
            //        break;
            //    }

            //}


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            no = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
            sinif = (int)dataGridView1.SelectedRows[0].Cells[3].Value;
            sübee = (string)dataGridView1.SelectedRows[0].Cells[4].Value; ;
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                textBox1.Text = item.Cells[0].Value.ToString();
                textBox2.Text = item.Cells[1].Value.ToString();
                textBox3.Text = item.Cells[2].Value.ToString();
                textBox4.Text = item.Cells[3].Value.ToString();
                textBox5.Text = item.Cells[4].Value.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
            if (checkBox1.Checked)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                button2.Visible = false;
                button1.Text = "Ekle";
            }
            else
            {

                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    textBox1.Text = item.Cells[0].Value.ToString();
                    textBox2.Text = item.Cells[1].Value.ToString();
                    textBox3.Text = item.Cells[2].Value.ToString();
                    textBox4.Text = item.Cells[3].Value.ToString();
                    textBox5.Text = item.Cells[4].Value.ToString();
                }
                button2.Visible = true;
                button1.Text = "Kaydet";
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            //listBox1.SelectedItem;
            yapiBindingSource.Clear();


            for (int i = 0; i < siniflar[listBox1.SelectedItem].Count(); i++)
            {

                foreach (var item in siniflar[listBox1.SelectedItem].ElementAt(i))
                {
                    yapiBindingSource.Add(new yapi() {
                        isim = item["isim"].ToString(),
                        soyad = item["soyad"].ToString(),
                        sinif = int.Parse(item["sinif"].ToString()),
                        sube = item["sube"].ToString(),
                        no = int.Parse(item["no"].ToString())
                    });
                }
            }

            /* foreach (var item in selc)
             {
                 var itemm = item.ElementAt(0);
                 MessageBox.Show(itemm["dwa"].ToString());
                 MessageBox.Show(item["awf"].ToString());
                 //  yapiBindingSource.Add(new yapi() { isim = textBox1.Text, soyad = textBox2.Text, sinif = int.Parse(textBox3.Text), sube = textBox5.Text, no = int.Parse(textBox4.Text) })
             }*/
            //////////////////////////////////////
            textBox8.Text = "";
            textBox6.Text = "";

            textBox7.Text = "";

            string[] sa = listBox1.SelectedItem.ToString().Split("-");
            textBox7.Text = sa[0];
            if (sa.Length == 2)
            {


                textBox8.Text = sa[1];
            }

            if (sinifkpst[listBox1.SelectedItem] != null)
            {


                if (listBox1.SelectedItem.ToString() == sinifkpst[listBox1.SelectedItem].Path.ToString())
                {
                    textBox6.Text = sinifkpst[listBox1.SelectedItem]["deger"].ToString();

                }
                else
                {

                    textBox6.Text = "Null";
                }


            }
            else
            {
                textBox6.Text = "Null";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sill();
            yapiBindingSource.RemoveAt(dataGridView1.SelectedRows[0].Index);

        }
        public async void eklee()
        {
            var dataleyer = new kapasite {
                deger = textBox6.Text

            };

            SetResponse resp = await client.SetTaskAsync("salonlar/" + listBox1.SelectedItem, dataleyer);
            JObject name = JObject.Parse(resp.Body);
            MessageBox.Show(name.ToString());
            refresh();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox6.Text) < 31 && int.Parse(textBox6.Text) > 0)
            {
                eklee();
            }
            else { MessageBox.Show("MAX:40 MIN:1 Olmalidir", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (aktarim.Count != 0)
            {


                Boolean sakus = true;
                foreach (var item in listBox2.Items)
                {
                    if (textBox9.Text == item.ToString())
                    {
                        sakus = false;
                    }

                }
                if (sakus)
                {
                    listBox2.Items.Add(textBox9.Text);
                    label10.Text = listBox2.Items.Count.ToString();
                    listBox2.SelectedIndex = 0;
                    Form2 sakarya = new Form2(this, textBox9.Text);
                    sakarya.ShowDialog();

                }
                else
                {

                    MessageBox.Show("Bu Isimde Sinav Var", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else { MessageBox.Show("SINIF KALMADI", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < kayit.Count; i++)
            {



                string[] antep = kayit[i].ToString().Split(";");
                if (antep[0] == listBox2.SelectedItem.ToString())
                {
                    string[] gazi = antep[1].Split("*");
                    for (int a = 0; a < gazi.Length - 1; a++)
                    {
                        MessageBox.Show("-------");
                        MessageBox.Show(gazi[a]);
                        aktarim.Add(gazi[a]);

                    }
                    MessageBox.Show(i.ToString());
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    kayit.RemoveAt(i);
                    label10.Text = listBox2.Items.Count.ToString();
                    break;

                }

            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
          
        aktarim = sinifar;

    }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            for (int i = 0; i < kayit.Count; i++)
            {



                string[] antep = kayit[i].ToString().Split(";");
                if (antep[0] == listBox2.SelectedItem.ToString())
                {
                    string[] gazi = antep[1].Split("*");
                    for (int a = 0; a < gazi.Length - 1; a++)
                    {
                        checkedListBox1.Items.Add(gazi[a]);

                    }


                    break;

                }

            }
            checkedListBox1.Visible = true;


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        ArrayList karismis = new ArrayList();
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        ArrayList karma = new ArrayList();
        ArrayList artiklar = new ArrayList();
        ArrayList katilanlar = new ArrayList();
        private void button7_Click(object sender, EventArgs e)
        {
            int bol = int.Parse(listBox2.Items.Count.ToString());
            int total = 0;
            int totalsin = 0;
            for (int i = 0; i < kayit.Count; i++)//2kere
            {
                string ogrenciler = "";
                string[] sinavismii = kayit[i].ToString().Split(";");
                string[] siniflarrr = sinavismii[1].Split("*");

                for (int b = 0; b < siniflarrr.Length - 1; b++)//sinif sayisi kadar
                {
                    //MessageBox.Show(siniflar[siniflarrr[a]].Count().ToString());
                    katilanlar.Add(siniflarrr[b]);
                    total += siniflar[siniflarrr[b]].Count();
                    totalsin += 30;


                    for (int c = 0; c < siniflar[siniflarrr[b]].Count(); c++)//ögrenci sayisis kadar
                    {

                        foreach (var item in siniflar[siniflarrr[b]].ElementAt(c))//sinifi
                        {
                            ogrenciler += item["isim"].ToString() + " " + item["soyad"].ToString() + " " + int.Parse(item["no"].ToString()) + " \n " + int.Parse(item["sinif"].ToString()) + "-" + item["sube"].ToString() + "&" + sinavismii[0] + "*";


                        }
                    }
                }
                karma.Add(sinavismii[0] + "/" + ogrenciler);
            }






            Random rd = new Random();
            string aralik = "";
            int bos = 0;
            int kasli = 0;
            ArrayList temiz = new ArrayList();
            
            for (int i = 0; i < karma.Count; i++)
            {
                ArrayList lan = new ArrayList();
                string[] actik = karma[i].ToString().Split("/");
                string[] tekogrenciler = actik[1].ToString().Split("*");
                for (int a = 0; a < tekogrenciler.Length - 1; a++)
                {
                    lan.Add(tekogrenciler[a]);
                }
                for (int c = 0; c < lan.Count % karma.Count; c++)
                {
                    artiklar.Add(lan[c]);
                    lan.RemoveAt(c);
                }
                foreach (var item in lan)
                {
                    temiz.Add(item);
                }
                aralik += bos + "-" + (bos + lan.Count) + "/";
                bos += lan.Count;
            }
            string[] parcalanmis = aralik.Split('/');
            ArrayList kont = new ArrayList();
            for (int ai = 0; ai < temiz.Count / (parcalanmis.Length - 1); ai++)
            {


                for (int i = 0; i < parcalanmis.Length - 1; i++)
                {



                    string[] kivi = parcalanmis[i].ToString().Split("-");


                    int ilk = int.Parse(kivi[0]);
                    int son = int.Parse(kivi[1]);
                sa:
                    int rand_num = rd.Next(ilk, son);
                    if (kasli < 1000)
                    {


                        if (kont.IndexOf(rand_num) != -1)
                        {
                            kasli++;
                            goto sa;

                        }
                        else
                        {
                            kont.Add(rand_num);
                            karismis.Add(temiz[rand_num]);
                        }
                    }


                    /*for (int a = int.Parse(kivi[0]); a < int.Parse(kivi[1]); a++)
                    {

                    }*/

                }
            }
            foreach (var item in katilanlar)
            {
                checkedListBox2.Items.Add(item.ToString());
            }
            label12.Text = (Math.Ceiling(decimal.Parse(karismis.Count.ToString()) / 30).ToString());
            label11.Visible = true;
            label12.Visible = true;
            button9.Visible = true; 
            checkedListBox2.Visible= true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                textBox3.Text = (i + 98).ToString();
                ekle();
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            
            if (checkedListBox2.CheckedItems.Count.ToString()== Math.Ceiling((decimal.Parse(karismis.Count.ToString())+(decimal.Parse(artiklar.Count.ToString() ) * 2))  / 30).ToString())
            {
                foreach (var item in checkedListBox2.CheckedItems)
                {
                    listBox3.Items.Add(item);
                }
                listBox3.Visible = true;
                button10.Visible = true;
            }
            else
            {
                MessageBox.Show(Math.Ceiling(decimal.Parse(karismis.Count.ToString()) / 30).ToString()+" Adet Sinif Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ArrayList bitti=new ArrayList();
            //listBox3.SelectedIndex
            MessageBox.Show(karismis.Count.ToString());
            MessageBox.Show(artiklar.Count.ToString());





            
            for (int i =int.Parse(listBox3.SelectedIndex.ToString())* 30; i < (int.Parse(listBox3.SelectedIndex.ToString()) + 1)*30; i++)
            {
                if (karismis.Count>i)
                {
                    bitti.Add(karismis[i]);
                }
               
               
            }
            for (int i = 0; i < artiklar.Count; i++)
            {
               bitti.Add(artiklar[i]);
                bitti.Add("BOS");
                

            }

            Form3 hadibe = new Form3(this,bitti,listBox3.SelectedItem.ToString());
                hadibe.Show();
        }
    }


}