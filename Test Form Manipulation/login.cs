using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Okta.Auth.Sdk;
using Okta.Sdk.Abstractions.Configuration;

namespace Test_Form_Manipulation
{
    public partial class login : Form
    {
        public login()
        {

            InitializeComponent();
            File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cookies.dat"));
            //string userName = "";
            if (!Properties.Settings.Default.cloudLoginOnly)
            {
                //Use windows login and autologin

                //userName = WindowsIdentity.GetCurrent().Name;
                //string toBeSearched = "\\";
                ////userName = "test\\test";
                //int ix = userName.IndexOf(toBeSearched);


                //if (ix != -1)
                //{
                //    userName = userName.Substring(ix + toBeSearched.Length);
                //}
                //Properties.Settings.Default.localusername = userName;
                //this.Hide();
                //var form2 = new Form1();
                //form2.Closed += (s, args) => this.Close();
                //form2.Show();

            }
        }


        public static string PostMessageToURL(string url, string parameters)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Headers[HttpRequestHeader.Accept] = "application/json";
                string HtmlResult = wc.UploadString(url, "POST", parameters);
                return HtmlResult;
            }
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string body = "";
                if (username1.Text == "" || password1.Text == "")
                {
                    MessageBox.Show("Username or Password Cannot be blank", "Login Error");
                    return;
                }
                else
                {
                    body = "{\"username\": \"" + username1.Text + "\",\"password\": \"" + password1.Text + "\"}";
                }

                string response1 = PostMessageToURL("https://" + Properties.Settings.Default.oktatenant + "/api/v1/authn", body);
                JObject rss = JObject.Parse(response1);
                string status = (string)rss["status"];
                Properties.Settings.Default.oktastate = (string)rss["stateToken"];
                Properties.Settings.Default.oktauserid = (string)rss["_embedded"]["user"]["id"];
                if (status == "MFA_REQUIRED")
                {
                    loginpanel.Hide();
                    smspanel.Hide();
                    mfapanel.Show();
                    int mfacount = rss["_embedded"]["factors"].Count();
                    for (int i = 0; i < mfacount; i++)
                    {
                        string nfactor = (string)rss["_embedded"]["factors"][i]["factorType"];
                        switch (nfactor)
                        {
                            //Coming Soon!

                            //case "push":
                            //    ComboboxItem item = new ComboboxItem();
                            //    item.Text = "Okta Verify";
                            //    item.Value = (string)rss["_embedded"]["factors"][i]["id"];
                            //    mfalist.Items.Add(item);
                            //    break;

                            //case "token:software:totp":
                            //    ComboboxItem item2 = new ComboboxItem();
                            //    item2.Text = "OTP";
                            //    item2.Value = (string)rss["_embedded"]["factors"][i]["id"];
                            //    mfalist.Items.Add(item2);
                            //    break;
                            case "sms":
                                ComboboxItem item3 = new ComboboxItem();
                                item3.Text = "SMS";
                                item3.Value = (string)rss["_embedded"]["factors"][i]["id"];
                                mfalist.Items.Add(item3);
                                break;
                        }
                    }
                }
                else
                {

                    Properties.Settings.Default.oktasession = (string)rss["sessionToken"];
                    Properties.Settings.Default.email = username1.Text;
                    this.Hide();
                    var form2 = new Dashboard();
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
            }
            catch (Exception Ex1)
            {
                MessageBox.Show(Ex1.Message, "Login Error");
                return;
            }
        }

        private void mfalist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem sitem = (ComboboxItem)mfalist.SelectedItem;
            try
            {
                if (sitem.Text == "SMS")
                {
                    mfalist.Enabled = false;
                    smspanel.Visible = true;
                    string body = "{\"stateToken\": \"" + Properties.Settings.Default.oktastate + "\"}";
                    string response1 = PostMessageToURL("https://" + Properties.Settings.Default.oktatenant + "/api/v1/authn/factors/" + sitem.Value.ToString() + "/verify", body);
                    JObject rss = JObject.Parse(response1);
                    string status = (string)rss["status"];
                    Properties.Settings.Default.oktastate = (string)rss["stateToken"];
                    Properties.Settings.Default.oktafactorid = sitem.Value.ToString();

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void submitSMS_Click(object sender, EventArgs e)
        {
            try
            {
                string body = "{\"stateToken\": \"" + Properties.Settings.Default.oktastate + "\", \"passCode\":\"" + smsTextbox.Text + "\"}";
                string response1 = PostMessageToURL("https://" + Properties.Settings.Default.oktatenant + "/api/v1/authn/factors/" + Properties.Settings.Default.oktafactorid + "/verify", body);
                JObject rss = JObject.Parse(response1);
                string status = (string)rss["status"];

                if (status == "SUCCESS")
                {
                    Properties.Settings.Default.oktasession = (string)rss["sessionToken"];
                    this.Hide();
                    var form2 = new Dashboard();
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
                else
                {
                    smsError.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void password1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }

        }
    }
}
