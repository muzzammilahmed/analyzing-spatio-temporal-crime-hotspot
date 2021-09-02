//MBHBARLAS ©2018
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using System.Diagnostics;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using Subgurim.Controles.GoogleChartIconMaker;
using System.IO;

namespace FYP
{
    public partial class mainform : Form
    {
        GMapOverlay markers = new GMapOverlay("markers");
        OracleConnection con = null;





        public mainform()
        {
            InitializeComponent();
            this.setConnection();

            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;

           // WindowState = FormWindowState.Maximized;


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
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            materialTabControl1.SelectedIndex = 0;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            materialTabControl1.SelectedIndex = 1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;

            materialTabControl1.SelectedIndex = 2;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button4.Height;
            SidePanel.Top = button4.Top;

            materialTabControl1.SelectedIndex = 6;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button5.Height;
            SidePanel.Top = button5.Top;

            materialTabControl1.SelectedIndex = 3;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button6.Height;
            SidePanel.Top = button6.Top;

            materialTabControl1.SelectedIndex = 5;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button7.Height;
            SidePanel.Top = button7.Top;

            materialTabControl1.SelectedIndex = 4;


        }

        private void button13_Click(object sender, EventArgs e)
        {

            DialogResult dr = MetroFramework.MetroMessageBox.Show(this, "\n\n Are You Sure You Want To Exit?", "Message!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
           
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button15.Height;
            SidePanel.Top = button15.Top;

            materialTabControl1.SelectedIndex = 7;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void mainform_Load(object sender, EventArgs e)
        {
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;

            map.MinZoom = 5;
            map.MaxZoom = 100;
            map.Zoom = 1;





            updateDataGridaccused_address_t();
            updateDataGridaccused_T();
            updateDataGridaccused_Taccused_alias_t();
            updateDataGridaccused_Taccused_contact_t();
            updateDataGridaccused_Tcase_t();
            updateDataGridaccused_Tfir_t();
            updateDataGridINVESTIGATION_OFFICER_T();
            updateDataGridP();
            updateDataGridVictim();
            


















        }

        private void button18_Click(object sender, EventArgs e)
        {

            try
            {
                double lng = Convert.ToDouble(bunifuMetroTextbox1.Text);
                double lat = Convert.ToDouble(bunifuMetroTextbox2.Text);



                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.purple_dot);
                markers.Markers.Add(marker);
                map.Overlays.Add(markers);
            }
            catch (Exception ex) { }


        }

        private void map_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                double lat = map.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = map.FromLocalToLatLng(e.X, e.Y).Lng;


                bunifuMetroTextbox1.Text = lng.ToString();
                bunifuMetroTextbox2.Text = lat.ToString();






            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            int count = 0;

            string c = "0", d = "0", crime = "0";


            try
            {

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "select LONGITUDE,LATITUDE,CRIME from crime where rownum<100";


                OracleDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    count++;

                    c = reader1[0].ToString();

                    d = reader1[1].ToString();

                    crime = reader1[2].ToString();







                    if (crime == "FELONIES")
                    {


                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(c), Convert.ToDouble(d)), GMarkerGoogleType.red_pushpin);
















                        markers.Markers.Add(marker);
                        map.Overlays.Add(markers);


                    }

                    else if (crime == "MISDEMEANORS")
                    {


                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(c), Convert.ToDouble(d)), GMarkerGoogleType.green_pushpin);
                        markers.Markers.Add(marker);
                        map.Overlays.Add(markers);


                    }



                 

                    else
                    {

                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(c), Convert.ToDouble(d)), GMarkerGoogleType.white_small);
                        markers.Markers.Add(marker);
                        map.Overlays.Add(markers);

                    }






                }







            }
            catch (Exception ee) { MessageBox.Show(ee.ToString()); }


        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button16.Height;
            SidePanel.Top = button16.Top;
            materialTabControl1.SelectedIndex = 8;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button19.Height;
            SidePanel.Top = button19.Top;
            materialTabControl1.SelectedIndex = 9;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button20.Height;
            SidePanel.Top = button20.Top;
            materialTabControl1.SelectedIndex = 10;
        }

        private void button12_Click(object sender, EventArgs e)
        {



        }

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

        }

        private void button21_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void button23_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button24.Height;
            SidePanel.Top = button24.Top;
            materialTabControl1.SelectedIndex = 11;

        }




        private void button25_Click(object sender, EventArgs e)
        {




            if (comboBox1.SelectedIndex == 0)
            {




                groupBox1.Text = "TOTAL CRIME";



                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }

                lblperc.Text = "100%";

                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='January'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        lbljan.Text = reader1[0].ToString();

                    }



                       chart1.Series["month"].Points.AddXY("Jan", Convert.ToInt32(lbljan.Text));
                   

                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }












                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='February'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        lblfeb.Text = reader1[0].ToString();

                    }



                  chart1.Series["month"].Points.AddXY("Feb", Convert.ToInt32(lblfeb.Text));


                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }




                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='March'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblmar.Text = reader1[0].ToString();


                    }



                    chart1.Series["month"].Points.AddXY("March", Convert.ToInt32(lblmar.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }





                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='April'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblapr.Text = reader1[0].ToString();



                    }


                                      chart1.Series["month"].Points.AddXY("April", Convert.ToInt32(lblapr.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }














                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='May'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                      lblmay.Text = reader1[0].ToString();


                    }


        
                    chart1.Series["month"].Points.AddXY("May", Convert.ToInt32(lblmay.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }
















                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='June'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lbljune.Text= reader1[0].ToString();


                    }


               
                    chart1.Series["month"].Points.AddXY("June", Convert.ToInt32(lbljune.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }











                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='July'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lbljuly.Text = reader1[0].ToString();


                    }

                    
                    chart1.Series["month"].Points.AddXY("July", Convert.ToInt32(lbljuly.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }









                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='August'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblaug.Text = reader1[0].ToString();


                    }


                    chart1.Series["month"].Points.AddXY("Aug", Convert.ToInt32(lblaug.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }








                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='September'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                       lblsep.Text = reader1[0].ToString();


                    }


                chart1.Series["month"].Points.AddXY("Sep", Convert.ToInt32(lblsep.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }










                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='October'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                    lbloct.Text = reader1[0].ToString();


                    }


           
                chart1.Series["month"].Points.AddXY("Oct", Convert.ToInt32(lbloct.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }








                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='November'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                    lblnov.Text = reader1[0].ToString();


                    }


                   chart1.Series["month"].Points.AddXY("Nov", Convert.ToInt32(lblnov.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }









                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='December'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                      lbldec.Text = reader1[0].ToString();


                    }



                    chart1.Series["month"].Points.AddXY("Dec", Convert.ToInt32(lbldec.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }


            }




























            else if (comboBox1.SelectedIndex == 1)
            {

                groupBox1.Text = "TOTAL MISDEMEANORS";

                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
            

            try
            {

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "select round((select count(crime) from crime where crime='MISDEMEANORS')/(select count(crime) from crime)*100,2 )from crime WHERE ROWNUM<2 group by (crime)";
                // cmd.CommandText = "select count(i_id) from issue_oltp ";

                OracleDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {

                    lblperc.Text = reader1[0].ToString();
       

                }


             



            }
            catch (Exception ee) { MessageBox.Show(ee.ToString()); }









                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='January' and crime='MISDEMEANORS'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lbljan.Text = reader1[0].ToString();


                    }

                    
                    chart1.Series["month"].Points.AddXY("Jan", Convert.ToInt32(lbljan.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }












                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='February' and crime='MISDEMEANORS'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblfeb.Text = reader1[0].ToString();


                    }
                    
                    chart1.Series["month"].Points.AddXY("Feb", Convert.ToInt32(lblfeb.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }




                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='March' and crime='MISDEMEANORS'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblmar.Text = reader1[0].ToString();


                    }
                    chart1.Series["month"].Points.AddXY("March", Convert.ToInt32(lblmar.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }





                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='April' and crime='MISDEMEANORS'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblapr.Text = reader1[0].ToString();


                    }
                    
                    chart1.Series["month"].Points.AddXY("April", Convert.ToInt32(lblapr.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }














                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='May' and crime='MISDEMEANORS'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblmay.Text = reader1[0].ToString();


                    }

                    
                    chart1.Series["month"].Points.AddXY("May", Convert.ToInt32(lblmay.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }
















                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='June' and crime='MISDEMEANORS'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lbljune.Text = reader1[0].ToString();


                    }

                    
                    chart1.Series["month"].Points.AddXY("June", Convert.ToInt32(lbljune.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }











                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='July' and crime='MISDEMEANORS'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lbljuly.Text = reader1[0].ToString();


                    }

                    
                    chart1.Series["month"].Points.AddXY("July", Convert.ToInt32(lbljuly.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }









                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='August' and crime='MISDEMEANORS'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblaug.Text = reader1[0].ToString();


                    }

                    
                    chart1.Series["month"].Points.AddXY("Aug", Convert.ToInt32(lblaug.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }








                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='September' and crime='MISDEMEANORS'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblsep.Text = reader1[0].ToString();


                    }

                    
                    chart1.Series["month"].Points.AddXY("Sep", Convert.ToInt32(lblsep.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }










                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='October' and crime='MISDEMEANORS'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lbloct.Text = reader1[0].ToString();


                    }


                   
                    chart1.Series["month"].Points.AddXY("Oct", Convert.ToInt32(lbloct.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }








                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='November' and crime='MISDEMEANORS'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblnov.Text = reader1[0].ToString();


                    }
                    
                    chart1.Series["month"].Points.AddXY("Nov", Convert.ToInt32(lblnov.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }









                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='December' and crime='MISDEMEANORS'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lbldec.Text = reader1[0].ToString();


                    }


                    chart1.Series["month"].Points.AddXY("Dec", Convert.ToInt32(lbldec.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }


            }











































            else if (comboBox1.SelectedIndex == 2)
            {
                groupBox1.Text = "TOTAL FELONIES";

                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }


                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select round((select count(crime) from crime where crime='FELONIES')/(select count(crime) from crime)*100,2) from crime WHERE ROWNUM<2 group by (crime)";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblperc.Text = reader1[0].ToString();


                    }

                    

                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }




         








                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='January' and crime='FELONIES'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lbljan.Text = reader1[0].ToString();


                    }
                    
                    chart1.Series["month"].Points.AddXY("Jan", Convert.ToInt32(lbljan.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }












                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='February' and crime='FELONIES'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblfeb.Text = reader1[0].ToString();


                    }
                    
                    chart1.Series["month"].Points.AddXY("Feb", Convert.ToInt32(lblfeb.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }




                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='March' and crime='FELONIES'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblmar.Text = reader1[0].ToString();


                    }

                    
                    chart1.Series["month"].Points.AddXY("March", Convert.ToInt32(lblmar.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }





                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='April' and crime='FELONIES'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblapr.Text = reader1[0].ToString();


                    }
                    
                    chart1.Series["month"].Points.AddXY("April", Convert.ToInt32(lblapr.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }














                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='May' and crime='FELONIES'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblmar.Text = reader1[0].ToString();


                    }

                    
                    chart1.Series["month"].Points.AddXY("May", Convert.ToInt32(lblmar.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }
















                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='June' and crime='FELONIES'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lbljune.Text = reader1[0].ToString();


                    }
                    
                    chart1.Series["month"].Points.AddXY("June", Convert.ToInt32(lbljune.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }











                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='July' and crime='FELONIES'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lbljuly.Text = reader1[0].ToString();


                    }

                    
                    chart1.Series["month"].Points.AddXY("July", Convert.ToInt32(lbljuly.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }









                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='August' and crime='FELONIES'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblaug.Text = reader1[0].ToString();


                    }
                    
                    chart1.Series["month"].Points.AddXY("Aug", Convert.ToInt32(lblaug.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }








                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='September' and crime='FELONIES'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblsep.Text = reader1[0].ToString();


                    }
                    
                    chart1.Series["month"].Points.AddXY("Sep", Convert.ToInt32(lblsep.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }










                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='October' and crime='FELONIES'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lbloct.Text = reader1[0].ToString();


                    }

                    
                    chart1.Series["month"].Points.AddXY("Oct", Convert.ToInt32(lbloct.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }








                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='November' and crime='FELONIES'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblnov.Text = reader1[0].ToString();


                    }

                    
                    chart1.Series["month"].Points.AddXY("Nov", Convert.ToInt32(lblnov.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }









                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(month) from crime where month='December' and crime='FELONIES'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lbldec.Text = reader1[0].ToString();


                    }

                    
                    chart1.Series["month"].Points.AddXY("Dec", Convert.ToInt32(lbldec.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }


            }

































        }


        private void updateDataGridVictim()
        {

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from victim_t";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bunifuCustomDataGrid1.DataSource = dt.DefaultView;
            dr.Close();
        }




        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {

                OracleCommand cmdd = new OracleCommand();
                cmdd.Connection = con;
                cmdd.CommandText = " insert into victim_t (v_nic,name,address,father_name,contact) values ('" + victim_cnic.Text + "','" + victim_name.Text + "','" + victim_address.Text + "','" + victim_father_name.Text + "','" + victim_contact.Text + "' ) ";

                cmdd.ExecuteNonQuery();
                this.updateDataGridVictim();


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

            MessageBox.Show("Record Added Succesfully!");
        }



        private void updateDataGridP()
        {

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from petitioner_t";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bunifuCustomDataGrid2.DataSource = dt.DefaultView;
            dr.Close();
        }





        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            try
            {

                OracleCommand cmdd = new OracleCommand();
                cmdd.Connection = con;
                cmdd.CommandText = " insert into  petitioner_t (p_nic,name,address,father_name,contact) values ('" + p_cnic.Text + "','" + p_name.Text + "','" + p_address.Text + "','" + p_father_name.Text + "','" + p_contact.Text + "' ) ";

                cmdd.ExecuteNonQuery();
                this.updateDataGridP();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }




        private void updateDataGridINVESTIGATION_OFFICER_T()
        {

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from INVESTIGATION_OFFICER_T";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bunifuCustomDataGrid7.DataSource = dt.DefaultView;
            dr.Close();
        }






        private void bunifuThinButton219_Click(object sender, EventArgs e)
        {
            try
            {

                OracleCommand cmdd = new OracleCommand();
                cmdd.Connection = con;
                cmdd.CommandText = " insert into  INVESTIGATION_OFFICER_T (officer_id,name,rank) values ('" + officer_id.Text + "','" + officer_name.Text + "','" + officer_rank.Text + "' ) ";

                cmdd.ExecuteNonQuery();
                this.updateDataGridINVESTIGATION_OFFICER_T();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }


        private void updateDataGridaccused_T()
        {

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from accused_T";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bunifuCustomDataGrid3.DataSource = dt.DefaultView;
            dr.Close();
        }






        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            try
            {

                OracleCommand cmdd = new OracleCommand();
                cmdd.Connection = con;
                cmdd.CommandText = " insert into  accused_T (accused_id,name,father_name,status,age,gender,nic,email) values ('" + a_id.Text + "','" + a_name.Text + "','" + a_father.Text + "','" + a_status.Text + "','" + a_Age.Text + "','" + a_gender.Text + "','" + a_cnic.Text + "','" + a_email.Text + "' ) ";

                cmdd.ExecuteNonQuery();
                this.updateDataGridaccused_T();


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }



        private void updateDataGridaccused_Tcase_t()
        {

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from case_t";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bunifuCustomDataGrid8.DataSource = dt.DefaultView;
            dr.Close();
        }






        private void bunifuThinButton222_Click(object sender, EventArgs e)
        {
            try
            {

                OracleCommand cmdd = new OracleCommand();
                cmdd.Connection = con;
                cmdd.CommandText = " insert into  case_t (case_id,case_status,case_detail,section_of_law,fir_id,officer_id) values ('" + c_id.Text + "','" + c_status.Text + "','" + c_detail.Text + "','" + c_section.Text + "','" + c_fir_id.Text + "','" + c_officer_id.Text + "') ";

                cmdd.ExecuteNonQuery();
                this.updateDataGridaccused_Tcase_t();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }





        private void updateDataGridaccused_Tfir_t()
        {

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from fir_t";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bunifuCustomDataGrid9.DataSource = dt.DefaultView;
            dr.Close();
        }











        private void bunifuThinButton225_Click(object sender, EventArgs e)
        {
            try
            {

                OracleCommand cmdd = new OracleCommand();
                cmdd.Connection = con;
                cmdd.CommandText = " insert into  fir_t (fir_id,incident_date,incident_time,incident_place,incident_longitude,incident_latitude,time_lodged,date_lodged,p_nic,v_nic,accused_id,crime) values (" + fir_id.Text + ",'" + inc_date.Text + "',to_timestamp( '" + inc_time.Text + "', 'MM/DD/YYYY HH:MI AM'),'" + inc_place.Text + "','" + fir_long.Text + "','" + fir_lat.Text + "',to_timestamp( '" + fir_time_lodg.Text + "', 'MM/DD/YYYY HH:MI AM'),'" + fir_date.Text + "','" + fir_pet_cnic.Text + "','" + fir_victim_cnic.Text + "','" + fir_accused_id.Text + "','" + crime.Text + "') ";

                cmdd.ExecuteNonQuery();
                this.updateDataGridaccused_Tfir_t();


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }






        private void updateDataGridaccused_Taccused_contact_t()
        {

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from accused_contact_t";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bunifuCustomDataGrid4.DataSource = dt.DefaultView;
            dr.Close();
        }









        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            try
            {

                OracleCommand cmdd = new OracleCommand();
                cmdd.Connection = con;
                cmdd.CommandText = " insert into  accused_contact_t (accused_id,phone_no) values (" + Acc_id.Text + "," + acc_phone.Text + ") ";

                cmdd.ExecuteNonQuery();
                this.updateDataGridaccused_Taccused_contact_t();


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }





        private void updateDataGridaccused_Taccused_alias_t()
        {

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from accused_alias_t";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bunifuCustomDataGrid5.DataSource = dt.DefaultView;
            dr.Close();
        }











        private void bunifuThinButton213_Click(object sender, EventArgs e)
        {
            try
            {

                OracleCommand cmdd = new OracleCommand();
                cmdd.Connection = con;
                cmdd.CommandText = " insert into  accused_alias_t (accused_id,alias) values (" + acc_id_alias.Text + ",'" + alias.Text + "') ";

                cmdd.ExecuteNonQuery();
                this.updateDataGridaccused_Taccused_alias_t();


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }




        private void updateDataGridaccused_address_t()
        {

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from accused_address_t";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bunifuCustomDataGrid6.DataSource = dt.DefaultView;
            dr.Close();
        }
















        private void bunifuThinButton216_Click(object sender, EventArgs e)
        {
            try
            {

                OracleCommand cmdd = new OracleCommand();
                cmdd.Connection = con;
                cmdd.CommandText = " insert into  accused_address_t (accused_id,address) values (" + acc_addres_id.Text + ",'" + acc_address.Text + "') ";

                cmdd.ExecuteNonQuery();
                this.updateDataGridaccused_address_t();


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }




        public void test()
        {

            try
            {
                Process p = new Process(); // create process (i.e., the python program

                p.StartInfo.FileName = @"C:\Users\Babar Barlas\AppData\Local\Programs\Python\Python37-32\python.exe";
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false; // make sure we can read the output from stdout
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                p.StartInfo.Arguments = "app.py"; // start the python program with two parameters
                p.Start(); // start the process (the python program)


                p.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception Raise",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }






        private void button26_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button26.Height;
            SidePanel.Top = button26.Top;
            materialTabControl1.SelectedIndex = 12;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            //test();
            textBox1.Text = "Analyzing";
            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(100);
                textBox1.Text += ". ";

            }
            System.Threading.Thread.Sleep(1000);

            textBox1.Text += File.ReadAllText("abc.txt");





        }
        

        private void map_Load(object sender, EventArgs e)
        {


        }

        private void button29_Click(object sender, EventArgs e)
        {













        }

        private void button30_Click(object sender, EventArgs e)
        {



            if (comboBox3.SelectedIndex == 0)
            {




                groupBox2.Text = "TOTAL";

                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }


                lblperc.Text = "100%";









                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where time='SlotOne'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        one.Text = reader1[0].ToString();


                    }


              chart2.Series["time"].Points.AddXY("SlotOne", Convert.ToInt32(one.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }












                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where time='SlotTwo'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                               two.Text = reader1[0].ToString();


                    }


                    //      two.Text = feb.ToString();
                     chart2.Series["time"].Points.AddXY("SlotTwo", Convert.ToInt32(two.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }




                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where time='SlotThree'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                                 three.Text = reader1[0].ToString();


                    }

                    //
                    //      three.Text = mar.ToString();
                      chart2.Series["time"].Points.AddXY("SlotThree", Convert.ToInt32(three.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }





                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where time='SlotFour'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                                four.Text = reader1[0].ToString();


                    }
                    
                    chart2.Series["time"].Points.AddXY("SlotFour", Convert.ToInt32(four.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }














                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where time='SlotFive'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                                 five.Text = reader1[0].ToString();


                    }
                    
                     chart2.Series["time"].Points.AddXY("SlotFive", Convert.ToInt32(five.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }
















                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where time='SlotSix'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                                   six.Text = reader1[0].ToString();


                    }


                    //      six.Text = june.ToString();
                      chart2.Series["time"].Points.AddXY("Six", Convert.ToInt32(six.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }











                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where time='SlotSeven'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                                    seven.Text = reader1[0].ToString();


                    }


                    //      seven.Text = july.ToString();
                           chart2.Series["time"].Points.AddXY("SlotSeven", Convert.ToInt32(seven.Text));
                    //


                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }









                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where time='SlotEight'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                          eight.Text = reader1[0].ToString();


                    }


                    //  eight.Text = aug.ToString();
                       chart2.Series["time"].Points.AddXY("SlotEight", Convert.ToInt32(eight.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }





            }




























            else if (comboBox3.SelectedIndex == 1)
            {

                groupBox1.Text = "TOTAL MISDEMEANORS";

                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }





                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select round((select count(crime) from crime where crime='MISDEMEANORS')/(select count(crime) from crime)*100,2 )from crime WHERE ROWNUM<2 group by (crime)";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblperc.Text = reader1[0].ToString();


                    }






                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }









                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='MISDEMEANORS' and time='SlotOne'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                            one.Text = reader1[0].ToString();


                    }


                    //  one.Text = jan.ToString();
                     chart2.Series["time"].Points.AddXY("SlotOne", Convert.ToInt32(one.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }












                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='MISDEMEANORS' and time='SlotTwo'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                             two.Text = reader1[0].ToString();


                    }


                    //   two.Text = feb.ToString();
                        chart2.Series["time"].Points.AddXY("SlotTwo", Convert.ToInt32(two.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }




                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='MISDEMEANORS' and time='SlotThree'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                                three.Text = reader1[0].ToString();


                    }


                    //    three.Text = mar.ToString();
                        chart2.Series["time"].Points.AddXY("SlotThree", Convert.ToInt32(three.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }





                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='MISDEMEANORS' and time='SlotFour'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        //     four.Text = reader1[0].ToString();


                    }


                    //   four.Text = apr.ToString();
                        chart2.Series["time"].Points.AddXY("SlotFour", Convert.ToInt32(four.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }














                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='MISDEMEANORS' and time='SlotFive'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                               five.Text = reader1[0].ToString();


                    }


                    //   five.Text = may.ToString();
                         chart2.Series["time"].Points.AddXY("SlotFive", Convert.ToInt32(five.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }
















                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='MISDEMEANORS' and time='SlotSix'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                                 six.Text = reader1[0].ToString();


                    }


                    //    six.Text = june.ToString();
                         chart2.Series["time"].Points.AddXY("Six", Convert.ToInt32(six.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }











                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='MISDEMEANORS' and time='SlotSeven'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                                 seven.Text = reader1[0].ToString();


                    }


                    //    seven.Text = july.ToString();
                       chart2.Series["time"].Points.AddXY("SlotSeven", Convert.ToInt32(seven.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }









                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='MISDEMEANORS' and time='SlotEight'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                              eight.Text = reader1[0].ToString();


                    }


                    //   eight.Text = aug.ToString();
                       chart2.Series["time"].Points.AddXY("SlotEight", Convert.ToInt32(eight.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }





            }











































            else if (comboBox3.SelectedIndex == 2)
            {
                groupBox1.Text = "TOTAL FELONIES";

                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }





                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select round((select count(crime) from crime where crime='FELONIES')/(select count(crime) from crime)*100,2 )from crime WHERE ROWNUM<2 group by (crime)";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        lblperc.Text = reader1[0].ToString();


                    }






                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }









                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='FELONIES' and time='SlotOne'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                                one.Text = reader1[0].ToString();


                    }


                    //  one.Text = jan.ToString();
                        chart2.Series["time"].Points.AddXY("SlotOne", Convert.ToInt32(one.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }












                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='FELONIES' and time='SlotTwo'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                              two.Text = reader1[0].ToString();


                    }


                    //     two.Text = feb.ToString();
                         chart2.Series["time"].Points.AddXY("SlotTwo", Convert.ToInt32(two.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }




                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='FELONIES' and time='SlotThree'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                               three.Text = reader1[0].ToString();


                    }


                    //   three.Text = mar.ToString();
                         chart2.Series["time"].Points.AddXY("SlotThree", Convert.ToInt32(three.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }





                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='FELONIES' and time='SlotFour'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                        four.Text = reader1[0].ToString();


                    }


                //    four.Text = apr.ToString();
                    chart2.Series["time"].Points.AddXY("SlotFour", Convert.ToInt32(four.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }














                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='FELONIES' and time='SlotFive'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                             five.Text = reader1[0].ToString();


                    }


                    //  five.Text = may.ToString();
                       chart2.Series["time"].Points.AddXY("SlotFive", Convert.ToInt32(five.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }
















                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='FELONIES' and time='SlotSix'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                          six.Text = reader1[0].ToString();


                    }


                    //        six.Text = june.ToString();
                          chart2.Series["time"].Points.AddXY("Six", Convert.ToInt32(six.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }











                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='FELONIES' and time='SlotSeven'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                               seven.Text = reader1[0].ToString();


                    }


                    //      seven.Text = july.ToString();
                       chart2.Series["time"].Points.AddXY("SlotSeven", Convert.ToInt32(seven.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }









                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(time) from crime where crime='FELONIES' and time='SlotEight'";
                    // cmd.CommandText = "select count(i_id) from issue_oltp ";

                    OracleDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {

                            eight.Text = reader1[0].ToString();


                    }


                    //       eight.Text = aug.ToString();
                           chart2.Series["time"].Points.AddXY("SlotEight", Convert.ToInt32(eight.Text));



                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }






                

          

        }





















    }

        private void label29_Click(object sender, EventArgs e)
        {

        }
    }
}
