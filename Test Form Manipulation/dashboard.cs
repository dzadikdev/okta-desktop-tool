using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using Okta.Sdk;
using System.DirectoryServices.AccountManagement;
using Okta.Auth.Sdk;
using System.Diagnostics;
using System.Security.Principal;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security;
using System.Net;
using System.Net.Http;
using System.IO;
using Okta.Sdk.Abstractions.Configuration;
using HtmlAgilityPack;
using System.Runtime.Serialization.Formatters.Binary;

namespace Test_Form_Manipulation
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            var client = new OktaClient(
            new Okta.Sdk.Configuration.OktaClientConfiguration
            {
                DisableHttpsCheck = true,
                OktaDomain = "https://" + Properties.Settings.Default.oktatenant + "/",
                Token = Properties.Settings.Default.oktaapitoken,
            });

            string userid = Properties.Settings.Default.oktauserid;
            int appx = 10;
            int appy = 10;
            var apps = await client.Applications.ListApplications(filter: "user.id eq \"" + userid + "\"").ToArray();
            foreach (var app in apps)
            {
                var app1 = app.Settings.App;
                string appname = app.Label;
                var appdict = app1.GetData();
                try
                {

                    bool islocal = Convert.ToBoolean(appdict["optionalField1Value"]);
                    if (islocal)
                    {
                        Button newButton = new Button();
                        newButton.Text = appname;
                        newButton.Location = new Point(appx, appy);
                        newButton.Size = new Size(100, 100);
                        newButton.Click += new EventHandler(this.button1_Click);
                        this.Controls.Add(newButton);
                        appx = appx + 110;
                    }
                }
                catch (Exception ex)
                {
                }
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            var pushbutton = (Button)sender;
            var client = new OktaClient(
            new Okta.Sdk.Configuration.OktaClientConfiguration
            {
                DisableHttpsCheck = true,
                OktaDomain = "https://" + Properties.Settings.Default.oktatenant + "/",
                Token = Properties.Settings.Default.oktaapitoken,
            });

            //string email = Properties.Settings.Default.email;
            //var foundUsers = await client.Users.ListUsers(q: email).ToArray();

            var apps = await client.Applications.ListApplications(q: pushbutton.Text).ToArray();
            LoginInfo newlogin = new LoginInfo();

            foreach (var app in apps)
            {

                if (Properties.Settings.Default.cloudLoginOnly)
                {
                    newlogin = loginWeb(app.Id);
                    this.Focus();

                    if (newlogin.Error != null)
                    {

                        return;
                    }
                }
                else
                {
                    newlogin = loginDB();
                }

                var app1 = app.Settings.App;
                string appname = app.Name;
                var appdict = app1.GetData();
                string apploc = appdict["optionalField2Value"].ToString();
                string appsteps = appdict["optionalField3Value"].ToString();
                string appemail = Properties.Settings.Default.email;
                string appusername = newlogin.Username;
                string apppass = newlogin.Password;

                var authclient = new AuthenticationClient(new OktaClientConfiguration
                {
                    OktaDomain = "https://" + Properties.Settings.Default.oktatenant + "/",
                });


                try
                {
                    var sim = new InputSimulator();
                    Process.Start(apploc);
                    string[] steps = appsteps.Split(',');
                    foreach (string step in steps)
                    {
                        string[] stepis = step.Split('=');
                        switch (stepis[0])
                        {
                            case "sleep":
                                sim.Keyboard.Sleep(Convert.ToInt32(stepis[1]));
                                break;
                            case "text":
                                switch (stepis[1])
                                {
                                    case "username":
                                        sim.Keyboard.TextEntry(appusername);
                                        break;
                                    case "password":
                                        sim.Keyboard.TextEntry(apppass);
                                        break;
                                    case "email":
                                        sim.Keyboard.TextEntry(appemail);
                                        break;
                                }
                                break;
                            case "key":
                                switch (stepis[1])
                                {
                                    case "tab":
                                        sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
                                        break;
                                    case "return":
                                        sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        static LoginInfo loginWeb(string appid)
        {

            try
            {
                //check for existing cookies
                CookieContainer cookieContainer = new CookieContainer();
                LoginInfo linfo = new LoginInfo();
                if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cookies.dat")))
                {
                    var rstr = File.OpenRead(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cookies.dat"));
                    cookieContainer = (CookieContainer)new BinaryFormatter().Deserialize(rstr);
                    rstr.Close();
                }

                //get session from cookie  - can only do this once
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://" + Properties.Settings.Default.oktatenant + "/login/sessionCookieRedirect?token=" + Properties.Settings.Default.oktasession + "&redirectUrl=/");
                request.CookieContainer = cookieContainer;
                WebResponse response = request.GetResponse();
                response.Close();


                //either get username and password or get mfa check
                HttpWebRequest request2 = (HttpWebRequest)HttpWebRequest.Create("https://" + Properties.Settings.Default.oktatenant + "/home/template_sps/" + appid + "/1179?fromHome=true");
                request2.CookieContainer = cookieContainer;
                WebResponse response2 = request2.GetResponse();
                //store cookies
                var bf = new BinaryFormatter();
                var wstr = File.OpenWrite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cookies.dat"));
                bf.Serialize(wstr, cookieContainer);
                wstr.Close();

                string responseFromServer = "";
                using (Stream dataStream = response2.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    responseFromServer = reader.ReadToEnd();
                    reader.Close();
                }
                response2.Close();

                string sPattern = "stateToken = '.+?(?=.)'";
                if (System.Text.RegularExpressions.Regex.IsMatch(responseFromServer, sPattern, System.Text.RegularExpressions.RegexOptions.Multiline))
                {
                    System.Text.RegularExpressions.Match foundToken = System.Text.RegularExpressions.Regex.Match(responseFromServer, sPattern);
                    int start = foundToken.ToString().IndexOf('\'') + 1;
                    int finish = foundToken.ToString().LastIndexOf('\'');
                    string stateToken = foundToken.Value.Substring(start, finish - start);
                    stateToken = System.Text.RegularExpressions.Regex.Unescape(stateToken);
                    Properties.Settings.Default.oktastate = stateToken;



                    string body = "{\"stateToken\": \"" + stateToken + "\"}";
                    HttpWebRequest request4 = (HttpWebRequest)HttpWebRequest.Create("https://" + Properties.Settings.Default.oktatenant + "/api/v1/authn/introspect");
                    request4.CookieContainer = cookieContainer;
                    request4.Method = "POST";
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] byte1 = encoding.GetBytes(body);
                    // Set the content type of the data being posted.
                    request4.ContentType = "application/json";
                    // Set the content length of the string being posted.
                    request4.ContentLength = byte1.Length;
                    var newStream = request4.GetRequestStream();
                    newStream.Write(byte1, 0, byte1.Length);
                    WebResponse response4 = request4.GetResponse();
                    newStream.Close();
                    response4.Close();

                    mfa mfaForm = new mfa();
                    var dialogResult = mfaForm.ShowDialog();
                    mfaForm.Dispose();

                    if (dialogResult == DialogResult.OK)
                    {

                        HttpWebRequest request3 = (HttpWebRequest)HttpWebRequest.Create("https://" + Properties.Settings.Default.oktatenant + "/login/sessionCookieRedirect?checkAccountSetupComplete=true&token=" + stateToken + "&redirectUrl=" + "https://" + Properties.Settings.Default.oktatenant + "/home/template_sps/" + appid + "/1179?fromHome=true");
                        request3.CookieContainer = cookieContainer;
                        WebResponse response3 = request3.GetResponse();
                        using (Stream dataStream = response3.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            responseFromServer = reader.ReadToEnd();
                            reader.Close();
                        }

                        response3.Close();
                        mfaForm.Close();
                        mfaForm.Dispose();
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        linfo.Error = "Do not run";
                        mfaForm.Close();
                        mfaForm.Dispose();
                        return linfo;
                    }

                }

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(responseFromServer);

                var nodes = doc.DocumentNode.DescendantsAndSelf("input");

                if (nodes != null)
                {
                    foreach (var node in nodes)
                    {
                        try
                        {
                            var name = node.Attributes["name"].Value;
                            var value = node.Attributes["value"].Value;

                            if (name == "txtbox-username")
                            {
                                linfo.Username = value;
                            }
                            if (name == "txtbox-password")
                            {
                                linfo.Password = value;
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                return linfo;
            }
            catch (Exception ex)
            {
                string catchex = ex.Message;
                LoginInfo linfo = new LoginInfo();
                linfo.Error = ex.Message;
                return linfo;
            }
        }


        static LoginInfo loginDB()
        {
            LoginInfo linfo = new LoginInfo();

            string userName = Properties.Settings.Default.localusername;
            string connStr = "server=localhost;user=root2;database=scim;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from scim.users where userName='" + userName + "'", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Properties.Settings.Default.email = rdr[6].ToString();
                linfo.Password = rdr[7].ToString();
                linfo.Username = rdr[2].ToString();
            }
            rdr.Close();
            return linfo;
        }


        public class LoginInfo
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Error { get; set; }
            public override string ToString()
            {
                return Username;
            }
        }
    }
}
