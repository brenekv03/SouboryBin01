using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SouboryBin01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader(@"..\..\CelaCisla.txt");
            while(!streamReader.EndOfStream)
            {
                listBox1.Items.Add(streamReader.ReadLine());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"..\..\CelaCisla.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter br =new BinaryWriter(fs);
            StreamReader streamReader = new StreamReader(@"..\..\CelaCisla.txt");
            while(!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                br.Write(line);
            }
            fs.Close();
            streamReader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"..\..\CelaCisla.dat",FileMode.Open, FileAccess.Read);
            BinaryReader br =new BinaryReader(fs);
            while(fs.Position<fs.Length)
            {
                int cislo = br.ReadInt32();
                listBox2.Items.Add(cislo);
            }
            fs.Close();
        }
    }
}
