using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using System.IO;


namespace FYP
{
    public partial class TextFileGenerator : Form
    {
        OracleConnection con = null;
        public TextFileGenerator()
        {
            this.setConnection();
            InitializeComponent();
        }

        private void setConnection()
        {
            String connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            con = new OracleConnection(connectionString);
            try
            {
                con.Open();
            }
            catch (Exception exp) { }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            using (StreamWriter sw = new StreamWriter("C:\\Users\\Hp Elite Book\\Desktop\\Final Year Project\\Records.txt"))
            {
                try
                {
                    
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "select trim(to_Char(incident_date,'MONTH')),to_char(INCIDENT_DATE,'DD'),incident_time,incident_place,crime from fir_t_wh";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    

                    while (reader1.Read())
                    {
                        
                        int daysInt = 0;
                        string days = "";
                        daysInt = Int32.Parse(reader1[1].ToString());

                        if (daysInt > 0 && daysInt < 11)
                        {
                            days = "FirstTen";

                        }
                        else if (daysInt > 10 && daysInt < 21)
                        {

                            days = "SecondTen";


                        }
                        else { days = "ThirdTen"; }

                        //int timeInt = 0;
                        //string time = "";
                        //timeInt = Int32.Parse(reader1[2].ToString());

                        //if (timeInt > 0 && daysInt < 4)
                        //{
                        //    time = "SlotOne";

                        //}
                        //if (timeInt > 3 && daysInt < 7)
                        //{
                        //    time = "SlotTwo";

                        //}
                        //if (timeInt > 6 && daysInt < 10)
                        //{
                        //    time = "SlotThree";

                        //}
                        //if (timeInt >= 10 && daysInt <= 12)
                        //{
                        //    time = "SlotFour";

                        //}
                        //if (timeInt >= 13 && daysInt <= 15)
                        //{
                        //    time = "SlotFive";

                        //}
                        //if (timeInt >= 16 && daysInt <= 18)
                        //{
                        //    time = "SlotSix";

                        //}
                        //if (timeInt >= 19 && daysInt <= 21)
                        //{
                        //    time = "SlotSeven";

                        //}
                        //if (timeInt >= 22 && daysInt <= 24)
                        //{
                        //    time = "SlotEight";

                        //}

                        textBox1.Text += reader1[0].ToString() + "," + reader1[1].ToString() + "," + reader1[2].ToString() + "," + reader1[3].ToString() + "," + reader1[4].ToString();


                        sw.WriteLine(reader1[0].ToString() + "," + days + "," + reader1[2].ToString() + "," + reader1[3].ToString() + "," + reader1[4].ToString());






                    }



                }
                catch (Exception ex) { }

            }
            MessageBox.Show("done");



        }
    }
}
