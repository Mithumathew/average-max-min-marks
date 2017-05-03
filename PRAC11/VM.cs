using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PRAC11
{
    class VM : INotifyPropertyChanged
    {
        //Variables
        int sectionsize1 = 12;
        int sectionsize2 = 8;
        int sectionsize3 = 10;
        const int NOOFSECTIONS = 3;
        //Properties
        private int[] scorelist1;
        public int[] Scorelist1
        { get { return scorelist1; }
        set { scorelist1 = value;  OnPropertyChanged(); }
        }
        private int[] scorelist2;
        public int[] Scorelist2
        {
            get { return scorelist2; }
            set { scorelist2 = value; OnPropertyChanged(); }
        }
        private int[] scorelist3;
        public int[] Scorelist3
        {
            get { return scorelist3; }
            set { scorelist3 = value; OnPropertyChanged(); }
        }
        private string totalavg;
        public string TotalAverage
        { get { return totalavg; }
        set { totalavg = value;OnPropertyChanged(); }
        }
        private string avgsecscore;
        public string AvgSecscore
        {
            get { return avgsecscore; }
            set { avgsecscore = value; OnPropertyChanged(); }
        }
        private string minscore;
        public string Minscore
        {
            get { return minscore; }
            set { minscore = value; OnPropertyChanged(); }
        }
        private string maxscore;
        public string Maxscore
        {
            get { return maxscore; }
            set { maxscore = value; OnPropertyChanged(); }
        }

       public void Filereader()
        {  //Reading the files in an array into the listbox
            int[][] Sectionarray = new int[3][];

            StreamReader sr1 = new StreamReader("Section1.txt");
            StreamReader sr2 = new StreamReader("Section2.txt");
            StreamReader sr3 = new StreamReader("Section3.txt");

            Sectionarray[0] = new int[sectionsize1];
            Sectionarray[1] = new int[sectionsize2] ;
            Sectionarray[2] = new int[sectionsize3];

            for(int i=0;i<sectionsize1;i++)
            {
                Sectionarray[0][i] = int.Parse(sr1.ReadLine());
            }
            for (int i = 0; i < sectionsize2; i++)
            {
                Sectionarray[1][i] = int.Parse(sr2.ReadLine());
            }
            for (int i = 0; i < sectionsize3; i++)
            {
                Sectionarray[2][i] = int.Parse(sr3.ReadLine());
            }
            scorelist1 = Sectionarray[0];
            scorelist2 = Sectionarray[1];
            scorelist3 = Sectionarray[2];

        }

        public void Minimum()
        {
            int minsec1 = scorelist1.Min();
            int minsec2 = scorelist2.Min();
            int minsec3 = scorelist3.Min();
            int minsections = Math.Min(minsec1, Math.Min(minsec2, minsec3));
            minscore = Sectionfinder(minsec1, minsec2, minsec3, minsections);
        }
        public void Maximum()
        {
            int maxsec1 = scorelist1.Max();
            int maxsec2 = scorelist2.Max();
            int maxsec3 = scorelist3.Max();
            int maxsections = Math.Max(maxsec1, Math.Max(maxsec2, maxsec3));
            maxscore = Sectionfinder(maxsec1, maxsec2, maxsec3, maxsections);
        }
        public string Sectionfinder(int section1,int section2,int section3,int value)
        {
            string secresult = "";

            if(section1==value)
            {
                secresult += "Section1: ";
            }
            if (section2 == value)
            {
                secresult += "Section2: ";
            }
            if(section3==value)
            {
                secresult += "Section3: ";
            }
            return secresult + value;
        }

        public void Averagescore()
        {
            avgsecscore ="section 1: "+ scorelist1.Average().ToString("n2") + "section 2 :"+scorelist2.Average().ToString("n2") + "section3:"+ scorelist3.Average().ToString("n2");
        }
 
        public void Totalsectionscore()
        {
            totalavg = ((scorelist1.Average() + scorelist2.Average() + scorelist3.Average()) / NOOFSECTIONS).ToString("n2");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            // make sure only to call this if the value actually changes

            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
