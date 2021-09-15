using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace RunningMatch
{
    public partial class Form1 : Form
    {
        int rohaniDistance, ahmadinejadDistance, jahangiriDistance, ghalibafDistance, hashemitabaDistance;
        bool sentinel = false;

        static Thread[] Person = new Thread[5];

        SoundPlayer gunSound;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbLine1.SendToBack();
            pbLine2.SendToBack();
            pbLine3.SendToBack();
            pbLine4.SendToBack();
            pbLine5.SendToBack();

            rohaniDistance = pbRohani.Location.X;
            ahmadinejadDistance = pbRohani.Location.X;
            jahangiriDistance = pbRohani.Location.X;
            ghalibafDistance = pbRohani.Location.X;
            hashemitabaDistance = pbRohani.Location.X;
            
            cmbRohani.Items.Add("Highest");
            cmbRohani.Items.Add("AboveNormal");
            cmbRohani.Items.Add("Normal");
            cmbRohani.Items.Add("BelowNormal");
            cmbRohani.Items.Add("Lowest");

            cmbAhmadinejad.Items.Add("Highest");
            cmbAhmadinejad.Items.Add("AboveNormal");
            cmbAhmadinejad.Items.Add("Normal");
            cmbAhmadinejad.Items.Add("BelowNormal");
            cmbAhmadinejad.Items.Add("Lowest");

            cmbJahangiri.Items.Add("Highest");
            cmbJahangiri.Items.Add("AboveNormal");
            cmbJahangiri.Items.Add("Normal");
            cmbJahangiri.Items.Add("BelowNormal");
            cmbJahangiri.Items.Add("Lowest");

            cmbGhalibaf.Items.Add("Highest");
            cmbGhalibaf.Items.Add("AboveNormal");
            cmbGhalibaf.Items.Add("Normal");
            cmbGhalibaf.Items.Add("BelowNormal");
            cmbGhalibaf.Items.Add("Lowest");

            cmbHashemitaba.Items.Add("Highest");
            cmbHashemitaba.Items.Add("AboveNormal");
            cmbHashemitaba.Items.Add("Normal");
            cmbHashemitaba.Items.Add("BelowNormal");
            cmbHashemitaba.Items.Add("Lowest");
        }

        private void pbStartGun_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            
            Person[0] = new Thread(new ThreadStart(Rohani));
            Person[1] = new Thread(new ThreadStart(Ahmadinejad));
            Person[2] = new Thread(new ThreadStart(Jahangiri));
            Person[3] = new Thread(new ThreadStart(Ghalibaf));
            Person[4] = new Thread(new ThreadStart(Hashemitaba));

            for (int i = 4; i >= 0; i--)
            {
                Person[i].Start();
            }

            SpecifyPriority();
        }

        private void Rohani()
        {
            Distance(ref rohaniDistance, pbRohani.Location.Y, 0, pbRohani, Person[0]);
        }

        private void Ahmadinejad()
        {
            Distance(ref ahmadinejadDistance, pbAhmadinejad.Location.Y, 1, pbAhmadinejad, Person[1]);
        }

        private void Jahangiri()
        {
            Distance(ref jahangiriDistance, pbJahangiri.Location.Y, 2, pbJahangiri, Person[2]);
        }
        
        private void Ghalibaf()
        {
            Distance(ref ghalibafDistance, pbGhalibaf.Location.Y, 3, pbGhalibaf, Person[3]);
        }

        private void Hashemitaba()
        {
            Distance(ref hashemitabaDistance, pbHashemitaba.Location.Y, 4, pbHashemitaba, Person[4]);
        }

        private void Distance(ref int XLocation, int YLocation, int personID, PictureBox pb, Thread terminatedThread)
        {
            while (XLocation <= pbEndLine.Location.X - 58.5)
            {
                ExactSleep(3000000);

                if (sentinel == true)
                {
                    terminatedThread.Abort();
                }

                XLocation += 1;

                pb.Location = new Point(XLocation, YLocation);

                if (XLocation >= pbEndLine.Location.X - 58.5)
                {
                    sentinel = true;

                    MessageBox.Show((personID + 1).ToString() + " is winner!");
                }
            }
        }

        private void ExactSleep(int waitTime)
        {
            for(int i = 0; i <= waitTime; i++)
            {
                i = i;
            }
        }

        private void SpecifyPriority()
        {
            switch(cmbRohani.Text)
            {
                case "Highest":
                    Person[0].Priority = ThreadPriority.Highest;
                    break;
                case "AboveNormal":
                    Person[0].Priority = ThreadPriority.AboveNormal;
                    break;
                case "Normal":
                    Person[0].Priority = ThreadPriority.Normal;
                    break;
                case "BelowNormal":
                    Person[0].Priority = ThreadPriority.BelowNormal;
                    break;
                case "Lowest":
                    Person[0].Priority = ThreadPriority.Lowest;
                    break;
            }

            switch (cmbAhmadinejad.Text)
            {
                case "Highest":
                    Person[1].Priority = ThreadPriority.Highest;
                    break;
                case "AboveNormal":
                    Person[1].Priority = ThreadPriority.AboveNormal;
                    break;
                case "Normal":
                    Person[1].Priority = ThreadPriority.Normal;
                    break;
                case "BelowNormal":
                    Person[1].Priority = ThreadPriority.BelowNormal;
                    break;
                case "Lowest":
                    Person[1].Priority = ThreadPriority.Lowest;
                    break;
            }

            switch (cmbJahangiri.Text)
            {
                case "Highest":
                    Person[2].Priority = ThreadPriority.Highest;
                    break;
                case "AboveNormal":
                    Person[2].Priority = ThreadPriority.AboveNormal;
                    break;
                case "Normal":
                    Person[2].Priority = ThreadPriority.Normal;
                    break;
                case "BelowNormal":
                    Person[2].Priority = ThreadPriority.BelowNormal;
                    break;
                case "Lowest":
                    Person[2].Priority = ThreadPriority.Lowest;
                    break;
            }

            switch (cmbGhalibaf.Text)
            {
                case "Highest":
                    Person[3].Priority = ThreadPriority.Highest;
                    break;
                case "AboveNormal":
                    Person[3].Priority = ThreadPriority.AboveNormal;
                    break;
                case "Normal":
                    Person[3].Priority = ThreadPriority.Normal;
                    break;
                case "BelowNormal":
                    Person[3].Priority = ThreadPriority.BelowNormal;
                    break;
                case "Lowest":
                    Person[3].Priority = ThreadPriority.Lowest;
                    break;
            }

            switch (cmbHashemitaba.Text)
            {
                case "Highest":
                    Person[4].Priority = ThreadPriority.Highest;
                    break;
                case "AboveNormal":
                    Person[4].Priority = ThreadPriority.AboveNormal;
                    break;
                case "Normal":
                    Person[4].Priority = ThreadPriority.Normal;
                    break;
                case "BelowNormal":
                    Person[4].Priority = ThreadPriority.BelowNormal;
                    break;
                case "Lowest":
                    Person[4].Priority = ThreadPriority.Lowest;
                    break;
            }
        }
    }
}