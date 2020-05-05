using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Okta.Auth.Sdk;
using Okta.Sdk;
using Okta.Sdk.Abstractions.Configuration;

namespace Test_Form_Manipulation
{
    public partial class mfa : Form
    {
        public mfa()
        {
            InitializeComponent();

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

        private void mfalist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem sitem = (ComboboxItem)mfalist.SelectedItem;
            try
            {
                if (sitem.Text == "SMS")
                {
                    mfalist.Enabled = false;
                    smspanel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                string test = ex.Message;
            }
        }

        private async void submitSMS_Click(object sender, EventArgs e)
        {
            try
            {

                var client = new AuthenticationClient(new OktaClientConfiguration
                {
                    OktaDomain = "https://" + Properties.Settings.Default.oktatenant,
                });

                var verifyFactorOptions = new VerifySmsFactorOptions()
                {
                    StateToken = Properties.Settings.Default.oktastate,
                    FactorId = Properties.Settings.Default.oktafactorid,
                    PassCode = smsTextbox.Text,
                };

                var authResponse = await client.VerifyFactorAsync(verifyFactorOptions);

                Properties.Settings.Default.oktastate = authResponse.StateToken;
                Properties.Settings.Default.oktasession = authResponse.SessionToken;
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void mfa_Load(object sender, EventArgs e)
        {
            var client = new OktaClient(
                               new Okta.Sdk.Configuration.OktaClientConfiguration
                               {
                                   DisableHttpsCheck = true,
                                   OktaDomain = "https://" + Properties.Settings.Default.oktatenant + "/",
                                   Token = Properties.Settings.Default.oktaapitoken,
                               });

            var factors = await client.UserFactors.ListFactors(Properties.Settings.Default.oktauserid).ToArray();
            foreach (var factor in factors)
            {
                string nfactor = factor.FactorType;
                switch (nfactor)
                {
                    case "push":
                        ComboboxItem item = new ComboboxItem();
                        item.Text = "Okta Verify";
                        item.Value = factor.Id;
                        mfalist.Items.Add(item);
                        break;

                    case "token:software:totp":
                        ComboboxItem item2 = new ComboboxItem();
                        item2.Text = "OTP";
                        item2.Value = factor.Id;
                        mfalist.Items.Add(item2);
                        break;
                    case "sms":
                        ComboboxItem item3 = new ComboboxItem();
                        item3.Text = "SMS";
                        item3.Value = factor.Id;
                        mfalist.Items.Add(item3);
                        break;
                }
            }
        }



        private async void smsSend_Click(object sender, EventArgs e)
        {
            ComboboxItem sitem = (ComboboxItem)mfalist.SelectedItem;
            try
            {
                if (sitem.Text == "SMS")
                {
                    Properties.Settings.Default.oktafactorid = sitem.Value.ToString();

                    var client = new AuthenticationClient(new OktaClientConfiguration
                    {
                        OktaDomain = "https://" + Properties.Settings.Default.oktatenant,
                    });

                    var verifyFactorOptions = new VerifySmsFactorOptions()
                    {
                        StateToken = Properties.Settings.Default.oktastate,
                        FactorId = sitem.Value.ToString(),
                        PassCode = "",
                    };

                    var authResponse = await client.VerifyFactorAsync(verifyFactorOptions);
                    smssent.Visible = true;
                    submitSMS.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                string smserror = ex.Message;
                MessageBox.Show(smserror);
            }
        }

        static async Task<string> PostURI(Uri u, HttpContent c)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.PostAsync(u, c);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
            }
            return response;
        }

        private void smsTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submitSMS.PerformClick();
            }

        }
    }
}
