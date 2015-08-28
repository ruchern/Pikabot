using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Net;
using System.Threading;

namespace Pikabot4
{
    public partial class frmPikabot : Form
    {
        PictureBox[] imgMiceCaughtBG = new PictureBox[5];
        PictureBox[] imgMiceCaught = new PictureBox[5];
        List<clsCatch> catchList = new List<clsCatch>();

        clsAccount userAccount;
        private System.Windows.Forms.Timer hornTimer;
        bool isPaused = false;
        bool saveAccountsEnabled = false;
        List<string> accountsSaved = new List<string>();
        string selectedAbout = "news";

        public frmPikabot()
        {
            InitializeComponent();
        }

        #region UIEventHandlers
        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.Image = Properties.Resources.btnLogin;
        }

        private void btnLogin_MouseDown(object sender, MouseEventArgs e)
        {
            btnLogin.Image = Properties.Resources.btnLoginHover;
        }

        private void btnLogin_MouseUp(object sender, MouseEventArgs e)
        {
            btnLogin.Image = Properties.Resources.btnLogin;
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            if (imgTopPointer.Left != 38)
                btnHome.Image = Properties.Resources.btnHome;
        }

        private void btnHome_MouseDown(object sender, MouseEventArgs e)
        {
            btnHome.Image = Properties.Resources.btnHomeHover;
        }

        private void btnInfo_MouseLeave(object sender, EventArgs e)
        {
            if (imgTopPointer.Left != 88)
                btnInfo.Image = Properties.Resources.btnInfo;
        }

        private void btnInfo_MouseDown(object sender, MouseEventArgs e)
        {
            btnInfo.Image = Properties.Resources.btnInfoHover;
        }

        private void btnLog_MouseLeave(object sender, EventArgs e)
        {
            if (imgTopPointer.Left != 130)
                btnLog.Image = Properties.Resources.btnLog;
        }

        private void btnLog_MouseDown(object sender, MouseEventArgs e)
        {
            btnLog.Image = Properties.Resources.btnLogHover;
        }

        private void btnAbout_MouseDown(object sender, MouseEventArgs e)
        {
            btnAbout.Image = Properties.Resources.btnAboutHover;
        }

        private void btnAbout_MouseLeave(object sender, EventArgs e)
        {
            if (imgTopPointer.Left != 303)
                btnLog.Image = Properties.Resources.btnLog;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            imgTopPointer.Left = 38;
            imgTopPointer.Top = 25;
            pnlHome.Show();
            pnlInfo.Hide();
            pnlLog.Hide();
            pnlAbout.Hide();
            btnHome.Image = Properties.Resources.btnHomeHover;
            btnInfo.Image = Properties.Resources.btnInfo;
            btnLog.Image = Properties.Resources.btnLog;
            btnAbout.Image = Properties.Resources.btnAbout;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            imgTopPointer.Left = 88;
            imgTopPointer.Top = 25;
            pnlHome.Hide();
            pnlInfo.Show();
            pnlLog.Hide();
            pnlAbout.Hide();
            btnHome.Image = Properties.Resources.btnHome;
            btnInfo.Image = Properties.Resources.btnInfoHover;
            btnLog.Image = Properties.Resources.btnLog;
            btnAbout.Image = Properties.Resources.btnAbout;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            imgTopPointer.Left = 130;
            imgTopPointer.Top = 25;
            pnlHome.Hide();
            pnlInfo.Hide();
            pnlLog.Show();
            pnlAbout.Hide();
            btnHome.Image = Properties.Resources.btnHome;
            btnInfo.Image = Properties.Resources.btnInfo;
            btnLog.Image = Properties.Resources.btnLogHover;
            btnAbout.Image = Properties.Resources.btnAbout;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            imgTopPointer.Left = 303;
            imgTopPointer.Top = 25;
            pnlHome.Hide();
            pnlInfo.Hide();
            pnlLog.Hide();
            pnlAbout.Show();
            btnHome.Image = Properties.Resources.btnHome;
            btnInfo.Image = Properties.Resources.btnInfo;
            btnLog.Image = Properties.Resources.btnLog;
            btnAbout.Image = Properties.Resources.btnAboutHover;
        }

        private void btnSyncData_MouseEnter(object sender, EventArgs e)
        {
            btnSyncData.Image = Properties.Resources.btnSyncDataHover;
        }

        private void btnSyncData_MouseLeave(object sender, EventArgs e)
        {
            btnSyncData.Image = Properties.Resources.btnSyncData;
        }

        private void btnSyncData_MouseDown(object sender, MouseEventArgs e)
        {
            btnSyncData.Image = Properties.Resources.btnSyncData;
        }

        private void btnSyncData_MouseUp(object sender, MouseEventArgs e)
        {
            btnSyncData.Image = Properties.Resources.btnSyncDataHover;
        }

        private void btnPauseBot_MouseEnter(object sender, EventArgs e)
        {
            if (isPaused)
            {
                btnPauseBot.Image = Properties.Resources.btnResumeBotHover;
            }
            else
            {
                btnPauseBot.Image = Properties.Resources.btnPauseBotHover;
            }
        }

        private void btnPauseBot_MouseLeave(object sender, EventArgs e)
        {
            if (isPaused)
                btnPauseBot.Image = Properties.Resources.btnResumeBot;
            else
                btnPauseBot.Image = Properties.Resources.btnPauseBot;
        }

        private void btnPauseBot_MouseDown(object sender, MouseEventArgs e)
        {
            btnPauseBot.Image = Properties.Resources.btnPauseBot;
        }

        private void btnPauseBot_MouseUp(object sender, MouseEventArgs e)
        {
            btnPauseBot.Image = Properties.Resources.btnPauseBotHover;
        }

        private void imgMiceCaught0_Click(object Sender, EventArgs e)
        {
            imgLogArrow.Left = 43;
            if (!userAccount.DHasKR)
                refreshCatchData();
        }

        private void imgMiceCaught1_Click(object Sender, EventArgs e)
        {
            imgLogArrow.Left = 103;
            if (!userAccount.DHasKR)
                refreshCatchData();
        }

        private void imgMiceCaught2_Click(object Sender, EventArgs e)
        {
            imgLogArrow.Left = 163;
            if (!userAccount.DHasKR)
                refreshCatchData();
        }

        private void imgMiceCaught3_Click(object Sender, EventArgs e)
        {
            imgLogArrow.Left = 223;
            if (!userAccount.DHasKR)
                refreshCatchData();
        }

        private void imgMiceCaught4_Click(object Sender, EventArgs e)
        {
            imgLogArrow.Left = 283;
            if (!userAccount.DHasKR)
                refreshCatchData();
        }

        private void btnKRSubmit_MouseDown(object sender, MouseEventArgs e)
        {
            btnKRSubmit.Image = Properties.Resources.imgKRSubmitClicked;
        }

        private void btnKRSubmit_MouseUp(object sender, MouseEventArgs e)
        {
            btnKRSubmit.Image = Properties.Resources.imgKRSubmit;
        }

        private void btnResyncDataKRTemp_MouseDown(object sender, MouseEventArgs e)
        {
            btnResyncDataKRTemp.Image = Properties.Resources.btnResyncDataKRTempClick;
        }

        private void btnResyncDataKRTemp_MouseUp(object sender, MouseEventArgs e)
        {
            btnResyncDataKRTemp.Image = Properties.Resources.btnResyncDataKRTemp;
        }

        private void btnAccounts_MouseDown(object sender, MouseEventArgs e)
        {
            btnAccounts.Image = Properties.Resources.btnAccountsClick;
        }

        private void btnAccounts_MouseUp(object sender, MouseEventArgs e)
        {
            btnAccounts.Image = Properties.Resources.btnAccounts;
        }

        private void btnAccountsSave_MouseDown(object sender, MouseEventArgs e)
        {
            btnAccountsSave.Image = Properties.Resources.btnAccountsSaveClick;
        }

        private void btnAccountsSave_MouseUp(object sender, MouseEventArgs e)
        {
            btnAccountsSave.Image = Properties.Resources.btnAccountsSave;
        }
        
        private void btnAnnOK_Click(object sender, EventArgs e)
        {
            pnlAnnouncement.Hide();
        }

        private void btnAnnOK_MouseDown(object sender, MouseEventArgs e)
        {
            btnAnnOK.Image = Properties.Resources.btnOKClick;
        }

        private void btnAnnOK_MouseUp(object sender, MouseEventArgs e)
        {
            btnAnnOK.Image = Properties.Resources.btnOK;
        }
        #endregion

        private void frmPikabot_Load(object sender, EventArgs e)
        {
            this.Width = 356;
            this.Height = 228;
            pnlVerticalBG.Hide();

            Version vrs = new Version(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            this.Text += " v" + vrs.ToString();
            lblPikabotAbout.Text += vrs.ToString();

            loadSavedAccounts();

            pnlAccounts.Top = 0;
            pnlAccounts.Left = 0;

            pnlHome.Parent = pnlMainUI;
            pnlHome.Left = 0;
            pnlHome.Top = 33;

            pnlInfo.Parent = pnlMainUI;
            pnlInfo.Left = 0;
            pnlInfo.Top = 33;

            pnlLog.Parent = pnlMainUI;
            pnlLog.Left = 0;
            pnlLog.Top = 33;

            pnlAbout.Parent = pnlMainUI;
            pnlAbout.Left = 0;
            pnlAbout.Top = 33;

            pnlLogin.Show();
            pnlMainUI.Hide();
            pnlKingsReward.Hide();
            pnlAccounts.Hide();
            pnlHome.Show();
            pnlInfo.Hide();
            pnlLog.Hide();
            pnlAbout.Hide();
            pnlAnnouncement.Hide();

            pnlMainUI.Top = 0;
            pnlMainUI.Left = 0;
            pnlKingsReward.Top = 0;
            pnlKingsReward.Left = 0;
            pnlAnnouncement.Top = 0;
            pnlAnnouncement.Left = 0;

            btnHome.Image = Properties.Resources.btnHomeHover;

            for (int i = 0; i < 5; i++)
            {
                imgMiceCaughtBG[i] = new PictureBox();
                imgMiceCaughtBG[i].Parent = pnlLog;
                imgMiceCaughtBG[i].Width = 56;
                imgMiceCaughtBG[i].Height = 56;
                imgMiceCaughtBG[i].Top = 94;
                imgMiceCaughtBG[i].Left = 27 + i * 60;
                imgMiceCaughtBG[i].Image = Properties.Resources.imgLogCatchHolder;
                imgMiceCaughtBG[i].BringToFront();

                imgMiceCaught[i] = new PictureBox();
                imgMiceCaught[i].Parent = pnlLog;
                imgMiceCaught[i].Width = 48;
                imgMiceCaught[i].Height = 48;
                imgMiceCaught[i].SizeMode = PictureBoxSizeMode.CenterImage;
                imgMiceCaught[i].Top = 98;
                imgMiceCaught[i].Left = 31 + i * 60;
                imgMiceCaught[i].BringToFront();
            }

            imgMiceCaught[0].Click += new System.EventHandler(this.imgMiceCaught0_Click);
            imgMiceCaught[1].Click += new System.EventHandler(this.imgMiceCaught1_Click);
            imgMiceCaught[2].Click += new System.EventHandler(this.imgMiceCaught2_Click);
            imgMiceCaught[3].Click += new System.EventHandler(this.imgMiceCaught3_Click);
            imgMiceCaught[4].Click += new System.EventHandler(this.imgMiceCaught4_Click);            
        }

        private void txtUsername_GotFocus(object sender, EventArgs e)
        {
            pnlAccountsList.Visible = true;
        }

        private void txtUsername_LostFocus(object sender, EventArgs e)
        {
            pnlAccountsList.Visible = false;
        }

        private void frmPikabot_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(clsFunctions.krHTMPath))
            {
                File.Delete(clsFunctions.krHTMPath);
            }
        }

        private bool getIsAuthenticatedUser(string username)
        {
            List<string> users;

            try
            {
                users = clsFunctions.getWebDocumentByLine(clsFunctions.authorizedUserList);
                for (int i = 0; i < users.Count; i++)
                {
                    if (clsFunctions.CalculateSHA1(username, Encoding.UTF8).ToLower().Equals(users[i].Trim().ToLower()))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                txtLoginStatus.Text = "Connecting to alternative server.";
                clsFunctions.writeLog("[ERROR] - getIsAuthenticatedUser() [Initial Data Source]", ex.ToString(), txtUsername.Text);
                try
                {
                    users = clsFunctions.getWebDocumentByLine(clsFunctions.authorizedUserListAlt);
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (clsFunctions.CalculateSHA1(username, Encoding.UTF8).ToLower().Equals(users[i].Trim().ToLower()))
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    txtLoginStatus.Text = "Error connecting to authentication servers.";
                    clsFunctions.writeLog("[ERROR] - getIsAuthenticatedUser() [Secondary Data Source]", ex.ToString(), txtUsername.Text);
                }
            }

            return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginFn();
        }

        private void enterPressed(Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (userAccount == null)
                    loginFn();
            }
        }

        private void loginFn()
        {
            btnLogin.Image = Properties.Resources.btnLoginHover;
            btnLogin.Refresh();
            txtLoginStatus.ForeColor = Color.FromArgb(158, 158, 158);
            txtLoginStatus.Text = "Checking account authenticity.";
            txtLoginStatus.Refresh();
                       
            if (txtUsername.Text.Trim().Equals(""))
            {
                txtLoginStatus.Text = "Username Required!";
                txtLoginStatus.ForeColor = Color.Orange;
                btnLogin.Image = Properties.Resources.btnLogin;
                txtUsername.Focus();
            }
            else if (!getIsAuthenticatedUser(txtUsername.Text.Trim().ToLower()))
            {
                if (!txtLoginStatus.Text.Equals("Error connecting to authentication server."))
                {
                    txtLoginStatus.Text = "You are not an authorized user.";
                }
                txtLoginStatus.ForeColor = Color.Orange;
                txtUsername.Focus();
            }
            else if (txtPassword.Text.Trim().Equals(""))
            {
                txtLoginStatus.Text = "Password Required!";
                txtLoginStatus.ForeColor = Color.Orange;
                btnLogin.Image = Properties.Resources.btnLogin;
                txtPassword.Focus();
            }
            else
            {
                try
                {
                    bool isLogin = false;
                    isLogin = clsFunctions.login(txtUsername.Text, txtPassword.Text, txtLoginStatus);

                    if (isLogin)
                    {
                        userAccount = new clsAccount(txtUsername.Text, txtPassword.Text);
                        loadInfo();
                        loadTimer();
                        loadCatches();

                        if (userAccount.DHasKR)
                        {
                            txtTimerMin.Text = "K";
                            txtTimerSec.Text = "R";
                            txtTimerMin.ForeColor = Color.FromArgb(60, 180, 255);
                            txtTimerSec.ForeColor = Color.FromArgb(60, 180, 255);

                            loadKR();
                            hornTimer.Stop();
                        }
                        else
                        {
                            refreshCatchData();
                        }
                        pnlLogin.Hide();
                        pnlMainUI.Show();

                        btnLogin.Image = Properties.Resources.btnLogin;
                        txtLoginStatus.Text = "";
                        txtStatus.Text = "";
                    }
                    else
                    {
                        txtLoginStatus.Text = "Invalid Facebook credentials. Please relogin.";
                        txtLoginStatus.ForeColor = Color.Orange;
                        txtUsername.Focus();
                    }
                }
                catch (Exception ex)
                {
                    txtStatus.Text = "Login Error. Retrying.";
                    txtLoginStatus.Text = "Login Error. Retrying.";
                    clsFunctions.writeLog("[ERROR] - loginFn()", ex.ToString(), txtUsername.Text);
                    loginFn();
                }
            }
        }

        private void loadInfo()
        {
            txtHomeUserID.Text = userAccount.Username;

            string data = clsFunctions.HTMLData;
            string manip = "nothing here";
            string process = "";

            if (clsFunctions.HTMLData.Contains("<title>MouseHunt on Facebook | Welcome to MouseHunt!</title>"))
            {
                process = "Not logged in";
                txtStatus.Text = "Relogging in.";
                txtStatus.Refresh();

                bool loggedIn = clsFunctions.login(userAccount.Username, userAccount.Password, txtStatus);

                while (!loggedIn)
                {
                    loggedIn = clsFunctions.login(userAccount.Username, userAccount.Password, txtStatus);
                }
            }
            else if (clsFunctions.HTMLData.Contains("The Tiny Mouse's little legs were too slow to fetch your data."))
            {
                process = "Time out";
                txtStatus.Text = "MouseHunt timed out.";
                refreshBot();
                return;
            }
            else if (clsFunctions.HTMLData.Contains("Uh oh! A Glitchpaw mouse sabotaged our code!"))
            {
                process = "Time out";
                txtStatus.Text = "MouseHunt timed out.";
                refreshBot();
                return;
            }
            else if (clsFunctions.HTMLData.Contains("MouseHunt will return shortly."))
            {
                process = "Maintenance";
                txtStatus.Text = "Down for Maintenance";
                hornTimer.Stop();
                txtTimerMin.Text = "--";
                txtTimerSec.Text = "--";
                return;
            }
            else
            {
                try
                {
                    manip = data.Substring(data.IndexOf("bait_name"), (data.IndexOf("unique_hash") - data.IndexOf("bait_name")));

                    #region King's Reward
                    process = "[INFO] King's Reward";
                    userAccount.DHasKR = bool.Parse(manip.Substring(manip.IndexOf("has_puzzle") + 13, (manip.IndexOf("is_online") - 3) - (manip.IndexOf("has_puzzle") + 13)));
                    #endregion

                    #region Cheese
                    process = "[INFO] Cheese";
                    userAccount.DCheese = manip.Substring(manip.IndexOf("bait_name") + 14, (manip.IndexOf("bait_ped_icon") - 5) - (manip.IndexOf("bait_name") + 14));
                    switch (userAccount.DCheese)
                    {
                        case "Gauntlet Cheese Tier 2":
                            userAccount.DCheese = "Gauntlet T2";
                            break;
                        case "Radioactive Blue Cheese":
                            userAccount.DCheese = "Radioactive Blue";
                            break;
                    }
                    txtHomeCheese.Text = userAccount.DCheese;
                    txtCheese.Text = userAccount.DCheese;
                    #endregion

                    #region Cheese Quantity
                    process = "[INFO] Cheese Quantity";
                    int cheeseQuantity;
                    bool cheeseSuccess = int.TryParse(manip.Substring(manip.IndexOf("bait_quantity") + 16, (manip.IndexOf("weapon_item_id") - 3) - (manip.IndexOf("bait_quantity") + 16)), out cheeseQuantity);
                    if (cheeseSuccess == false)
                    {
                        cheeseQuantity = int.Parse(manip.Substring(manip.IndexOf("bait_quantity") + 18, (manip.IndexOf("weapon_item_id") - 5) - (manip.IndexOf("bait_quantity") + 18)));
                    }
                    userAccount.DCheeseQuantity = cheeseQuantity;

                    if (userAccount.DCheese.Equals("null") && userAccount.DCheeseQuantity == 0)
                    {
                        txtHomeCheese.Text = "No Cheese";
                        txtHomeCheese.ForeColor = Color.Red;
                        txtCheese.Text = "No Cheese";
                        txtCheese.ForeColor = Color.Red;
                    }
                    else if(userAccount.DCheeseQuantity < 10)
                    {
                        txtHomeCheese.Text += " [" + userAccount.DCheeseQuantity.ToString() + "]";
                        txtHomeCheese.ForeColor = Color.FromArgb(255, 153, 0);
                        txtCheese.Text += " [" + userAccount.DCheeseQuantity.ToString() + "]";
                        txtCheese.ForeColor = Color.FromArgb(102, 102, 102);
                    }
                    else
                    {
                        txtHomeCheese.Text += " [" + userAccount.DCheeseQuantity.ToString() + "]";
                        txtHomeCheese.ForeColor = Color.FromArgb(102, 102, 102);
                        txtCheese.Text += " [" + userAccount.DCheeseQuantity.ToString() + "]";
                        txtCheese.ForeColor = Color.FromArgb(102, 102, 102);
                    }
                    #endregion

                    #region Location
                    process = "[INFO] Location";
                    userAccount.DLocation = manip.Substring(manip.IndexOf("location") + 13, (manip.IndexOf("location_header") - 5) - (manip.IndexOf("location") + 13));
                    txtHomeLocation.Text = userAccount.DLocation;
                    txtLocation.Text = userAccount.DLocation;

                    #region Seasonal Garden
                    if (txtLocation.Text.Equals("Seasonal Garden"))
                    {
                        pnlVerticalBG.Show();
                        double currentAmplifier = Double.Parse(manip.Substring(manip.IndexOf("zzt_amplifier") + 16, (manip.IndexOf("zzt_max_amplifier") - 3) - (manip.IndexOf("zzt_amplifier") + 16)));
                        double maxAmplifier = Double.Parse(manip.Substring(manip.IndexOf("zzt_max_amplifier") + 20, (manip.IndexOf("user_id") - 4) - (manip.IndexOf("zzt_max_amplifier") + 20)));

                        pnlVerticalAmount.Height = Convert.ToInt32((currentAmplifier / maxAmplifier) * 60.0);
                        pnlVerticalAmount.Top = Convert.ToInt32(60.0 - pnlVerticalAmount.Height);

                        imgSeason.Show();
                        string season = manip.Substring(manip.IndexOf("season") + 11, (manip.IndexOf("zzt_amplifier") - 5) - (manip.IndexOf("season") + 11));
                        if (season.Equals("sg"))
                            imgSeason.Image = Properties.Resources.ico_spring;
                        else if (season.Equals("sr"))
                            imgSeason.Image = Properties.Resources.ico_summer;
                        else if (season.Equals("fl"))
                            imgSeason.Image = Properties.Resources.ico_fall;
                        else
                            imgSeason.Image = Properties.Resources.ico_winter;
                    }
                    else
                    {
                        pnlVerticalBG.Hide();
                        imgSeason.Hide();
                    }
                    #endregion
                    #endregion

                    #region Gender
                    process = "[INFO] Gender";
                    userAccount.DGender = manip.Substring(manip.IndexOf("gender") + 11, (manip.Length - 5) - (manip.IndexOf("gender") + 11));
                    #endregion

                    #region Title
                    process = "[INFO] Title";
                    userAccount.DRank = manip.Substring(manip.IndexOf("title_name") + 15, (manip.IndexOf("title_percentage") - 5) - (manip.IndexOf("title_name") + 15));

                    if (userAccount.DRank.Contains("Novice"))
                        imgTitle.Image = Properties.Resources.imgInfoNovice;
                    else if (userAccount.DRank.Contains("Recruit"))
                        imgTitle.Image = Properties.Resources.imgInfoRecruit;
                    else if (userAccount.DRank.Contains("Apprentice"))
                        imgTitle.Image = Properties.Resources.imgInfoApprentice;
                    else if (userAccount.DRank.Contains("Initiate"))
                        imgTitle.Image = Properties.Resources.imgInfoInitiate;
                    else if (userAccount.DRank.Contains("Journeyman"))
                        imgTitle.Image = Properties.Resources.imgInfoJourneyman;
                    else if (userAccount.DRank.Contains("Master"))
                        imgTitle.Image = Properties.Resources.imgInfoMaster;
                    else if (userAccount.DRank.Contains("Grandmaster"))
                        imgTitle.Image = Properties.Resources.imgInfoGrandMaster;
                    else if (userAccount.DRank.Contains("Legendary"))
                        imgTitle.Image = Properties.Resources.imgInfoLegendary;
                    else if (userAccount.DRank.Contains("Hero"))
                        imgTitle.Image = Properties.Resources.imgInfoHero;
                    else if (userAccount.DRank.Contains("Knight"))
                        imgTitle.Image = Properties.Resources.imgInfoKnight;
                    else if (userAccount.DRank.Contains("Lord") || userAccount.DRank.Contains("Lady"))
                    {
                        if (userAccount.DGender.Equals("male"))
                            imgTitle.Image = Properties.Resources.imgInfoLord;
                        else if (userAccount.DGender.Equals("female"))
                            imgTitle.Image = Properties.Resources.imgInfoLady;
                        else
                            imgTitle.Image = Properties.Resources.imgInfoLordLady;
                    }
                    else if (userAccount.DRank.Contains("Baron") || userAccount.DRank.Contains("Baroness"))
                    {
                        if (userAccount.DGender.Equals("male"))
                            imgTitle.Image = Properties.Resources.imgInfoBaron;
                        else if (userAccount.DGender.Equals("female"))
                            imgTitle.Image = Properties.Resources.imgInfoBaroness;
                        else
                            imgTitle.Image = Properties.Resources.imgInfoBaron;
                    }
                    else if (userAccount.DRank.Contains("Count") || userAccount.DRank.Contains("Countess"))
                    {
                        if (userAccount.DGender.Equals("male"))
                            imgTitle.Image = Properties.Resources.imgInfoCount;
                        else if (userAccount.DGender.Equals("female"))
                            imgTitle.Image = Properties.Resources.imgInfoCountess;
                        else
                            imgTitle.Image = Properties.Resources.imgInfoCount;
                    }
                    else
                        imgTitle.Image = null;
                    
                    #endregion

                    #region Weapon
                    process = "[INFO] Weapon";
                    userAccount.DWeapon = manip.Substring(manip.IndexOf("weapon_name") + 16, (manip.IndexOf("base_item_id") - 5) - (manip.IndexOf("weapon_name") + 16));
                    switch (userAccount.DWeapon)
                    {
                        case "Arcane Capturing Rod Of Never Yielding Mystery":
                            userAccount.DWeapon = "ACRONYM";
                            break;
                    }
                    txtWeapon.Text = userAccount.DWeapon;
                    #endregion

                    #region Base
                    process = "[INFO] Base";
                    userAccount.DBase = manip.Substring(manip.IndexOf("base_name") + 14, (manip.IndexOf("trinket_item_id") - 5) - (manip.IndexOf("base_name") + 14));
                    txtBase.Text = userAccount.DBase;
                    #endregion

                    #region Gold
                    process = "[INFO] Gold";

                    String tempGold = ",";
                    tempGold += "\\";
                    tempGold += "\"";
                    tempGold += "gold";
                    tempGold += "\\";
                    tempGold += "\"";
                    tempGold += ":";

                    String tempPoints = ",";
                    tempPoints += "\\";
                    tempPoints += "\"";
                    tempPoints += "points";
                    tempPoints += "\\";
                    tempPoints += "\"";
                    tempPoints += ":";

                    userAccount.DGold = manip.Substring(manip.IndexOf(tempGold) + 10, (manip.IndexOf(tempPoints)) - (manip.IndexOf(tempGold) + 10));
                    txtGold.Text = clsFunctions.formatNumericString(userAccount.DGold);
                    #endregion

                    #region Points
                    process = "[INFO] Points";

                    tempPoints = ",";
                    tempPoints += "\\";
                    tempPoints += "\"";
                    tempPoints += "points";
                    tempPoints += "\\";
                    tempPoints += "\"";
                    tempPoints += ":";

                    userAccount.DPoints = manip.Substring(manip.IndexOf(tempPoints) + 12, (manip.IndexOf("guru_points") - 3) - (manip.IndexOf(tempPoints) + 12));
                    txtPoints.Text = clsFunctions.formatNumericString(userAccount.DPoints);
                    #endregion

                    #region EXP
                    process = "[INFO] EXP";

                    userAccount.DPercentage = double.Parse(manip.Substring(manip.IndexOf("title_percentage") + 19, (manip.IndexOf("access_granted") - 3) - (manip.IndexOf("title_percentage") + 19)));
                    txtPercentage.Text = userAccount.DPercentage.ToString() + "%";
                    imgProgressBar.Width = System.Convert.ToInt32((userAccount.DPercentage / 100) * 250);
                    imgTitle.Left = imgProgressBar.Width + 17;
                    #endregion

                    #region Has Golden Shield?
                    process = "[INFO] Has Golden Shield?";
                    userAccount.DIsDonor = bool.Parse(manip.Substring(manip.IndexOf("has_shield") + 13, (manip.IndexOf("shield_expiry") - 3) - (manip.IndexOf("has_shield") + 13)));
                    #endregion

                    #region Shield Expiry
                    process = "[INFO] Shield Expiry";
                    userAccount.DGSExpiryDate = manip.Substring(manip.IndexOf("shield_expiry") + 18, (manip.IndexOf("viewing_atts") - 5) - (manip.IndexOf("shield_expiry") + 18));

                    if (userAccount.DGSExpiryDate.Equals("0000-00-00"))
                    {
                        txtDonor.Text = "Never";
                        txtDonor.ForeColor = Color.FromArgb(158, 158, 158);
                    }
                    else if (userAccount.DIsDonor)
                    {
                        txtDonor.Text = userAccount.DGSExpiryDate;
                        txtDonor.ForeColor = Color.FromArgb(102, 102, 102);
                    }
                    else
                    {
                        txtDonor.Text = userAccount.DGSExpiryDate;
                        txtDonor.ForeColor = Color.FromArgb(158, 158, 158);
                    }
                    #endregion

                    #region HornTime
                    process = "[INFO] HornTime";
                    userAccount.DHornTime = int.Parse(manip.Substring(manip.IndexOf("next_activeturn_seconds") + 26, (manip.IndexOf("has_puzzle") - 3) - (manip.IndexOf("next_activeturn_seconds") + 26)));
                    #endregion

                    #region [About] News
                    process = "[INFO] News";
                    if (selectedAbout.Equals("news"))
                        webAbout.Url = new Uri(clsFunctions.newsURL);
                    else
                        webAbout.Url = new Uri(clsFunctions.talkURL);
                    #endregion
                }
                catch (Exception ex)
                {
                    clsFunctions.writeLog("[ERROR] - loadInfo(): " + process, ex.ToString(), txtUsername.Text);
                    //MessageBox.Show("An error has occurred while loading your account information. Please send events.log found in your Pikabot folder to dev.pikabot@gmail.com. Pikabot will now exit to protect your account.", "Pikabot has hit an error");
                    //Application.Exit();
                }
            }
        }

        private void loadCatches()
        {
            if (clsFunctions.HTMLData.Contains("<h1>Claim Your Reward!</h1>"))
            {
                loadKR();
            }
            else
            {
                try
                {
                    catchList.Clear();

                    string manip = clsFunctions.HTMLData.Substring(clsFunctions.HTMLData.IndexOf("journalContainer"), clsFunctions.HTMLData.IndexOf(@"http://apps.facebook.com/mousehunt/journal.php") - clsFunctions.HTMLData.IndexOf("journalContainer"));

                    for (int i = 0; i < 5; i++)
                    {
                        string block = manip.Substring(manip.IndexOf(" class=\"entry"), manip.IndexOf("<div style=\"clear: both;\"></div>") - manip.IndexOf(" class=\"entry"));
                        catchList.Add(new clsCatch(block));

                        catchList[i].parseData();
                        imgMiceCaught[i].Image = clsFunctions.checkMouseImage(catchList[i].mouseImage);

                        manip = manip.Substring(manip.IndexOf("<div style=\"clear: both;\"></div>") + 38);
                    }

                    imgLastCatchPic.Image = imgMiceCaught[0].Image;
                }
                catch (Exception ex)
                {
                    refreshBot();
                    clsFunctions.writeLog("[ERROR] - loadCatches()", ex.ToString(), txtUsername.Text);
                    return;
                }
            }
        }

        private void loadTimer()
        {
            hornTimer = new System.Windows.Forms.Timer();
            hornTimer.Interval = 1000; 
            hornTimer.Tick += new EventHandler(HornTimer_Tick);

            hornTimer.Start();
        }

        private void HornTimer_Tick(object sender, EventArgs e)
        {
            if (userAccount.DHornTime == 0)
            {
                hornTimer.Stop();
                soundTheHorn();
                loadCatches();

                txtStatus.Text = "Refreshing information.";
                txtStatus.Refresh();

                loadInfo();

                if (!userAccount.DHasKR)
                    refreshCatchData();
                
                if (userAccount.DCheeseQuantity == 0)
                    txtStatus.Text = "Out of cheese.";
                else
                {
                    txtStatus.Clear();

                    if (userAccount.DHasKR)
                    {
                        txtTimerMin.Text = "K";
                        txtTimerSec.Text = "R";
                        txtTimerMin.ForeColor = Color.FromArgb(60, 180, 255);
                        txtTimerSec.ForeColor = Color.FromArgb(60, 180, 255);

                        loadKR();
                    }
                    else
                    {
                        hornTimer.Start();
                    }
                }
            }
            else
            {
                userAccount.DHornTime -= 1;

                if ((userAccount.DHornTime % 60) >= 10)
                {
                    txtTimerMin.Text = (userAccount.DHornTime / 60).ToString();
                    txtTimerSec.Text = (userAccount.DHornTime % 60).ToString();
                }
                else
                {
                    txtTimerMin.Text = (userAccount.DHornTime / 60).ToString();
                    txtTimerSec.Text = "0" + (userAccount.DHornTime % 60).ToString();
                }

                txtTimerMin.ForeColor = Color.White;
                txtTimerSec.ForeColor = Color.White;

                imgTimeBar.Width = System.Convert.ToInt32((((900.0 - userAccount.DHornTime) / 900.0) * 300));
            }
        }

        private void soundTheHorn()
        {
            if (userAccount.DHasKR)
            {
                txtTimerMin.Text = "K";
                txtTimerSec.Text = "R";
                txtTimerMin.ForeColor = Color.FromArgb(60, 180, 255);
                txtTimerSec.ForeColor = Color.FromArgb(60, 180, 255);
            }
            else if (userAccount.DCheeseQuantity == 0)
            {
                txtStatus.Text = "Out of cheese.";
            }
            else
            {
                Random rndDelay = new Random();
                int delayTime = rndDelay.Next(1, 10);
                txtStatus.Text = delayTime.ToString() + "s delay time.";
                txtStatus.Refresh();

                for (int i = 0; i < delayTime; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    Application.DoEvents();
                }

                txtStatus.Text = "Sounding the horn.";
                clsFunctions.HTMLData = getHTTPDocSource("http://apps.facebook.com/mousehunt/turn.php");

                if (clsFunctions.HTMLData.Contains("<title>MouseHunt on Facebook | Welcome to MouseHunt!</title>"))
                {
                    txtStatus.Text = "Relogging in.";
                    txtStatus.Refresh();

                    bool loggedIn = clsFunctions.login(userAccount.Username, userAccount.Password, txtStatus);

                    while (!loggedIn)
                    {
                        loggedIn = clsFunctions.login(userAccount.Username, userAccount.Password, txtStatus);
                    }

                    soundTheHorn();
                }
                else if (clsFunctions.HTMLData.Contains("The Tiny Mouse's little legs were too slow to fetch your data."))
                {
                    txtStatus.Text = "MouseHunt timed out.";
                    soundTheHorn();
                }
                else if (clsFunctions.HTMLData.Contains("MouseHunt will return shortly."))
                {
                    txtStatus.Text = "Down for Maintenance";
                    hornTimer.Stop();
                    txtTimerMin.Text = "--";
                    txtTimerSec.Text = "--";
                }
            }
        }

        private string getHTTPDocSource(string url)
        {
            clsWeb web;

            web = new clsWeb(url);
            web.Cookie = clsFunctions.cCookie;
            web.@ref = "http://apps.facebook.com/mousehunt/";
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(web.GetUrl));
            thread.Priority = System.Threading.ThreadPriority.Highest;
            thread.Start();
            do
            {
                Application.DoEvents();
            }
            while (thread.IsAlive);

            return web.sData;
        }

        private void loadKR()
        {
            pnlKingsReward.Show();
            pnlKingsReward.BringToFront();

            txtKRuserID.Text = userAccount.Username;
            txtKRTime.Text = clsFunctions.getCurrentTime();

            try
            {
                string KRImage = clsFunctions.HTMLData.Substring(clsFunctions.HTMLData.IndexOf(@"http://www.mousehuntgame.com/puzzleimage.php?t="), (clsFunctions.HTMLData.IndexOf("Claim Your Reward!") - 72) - (clsFunctions.HTMLData.IndexOf(@"http://www.mousehuntgame.com/puzzleimage.php?t=")));
                string loadKRSource = "<html><head><title>KR Test</title></head><body><img alt=\"Kings Reward\" src=\"" + KRImage + "\" /><embed src=\"KRAlert.mid\" hidden=true autostart=true loop=1></body></html>";
                clsFunctions.krHTMPath = Application.StartupPath.ToString() + @"\kr_" + userAccount.Shortusername + ".htm";

                FileStream fsKR = null;
                if (File.Exists(clsFunctions.krHTMPath))
                {
                    File.Delete(clsFunctions.krHTMPath);
                }
                using (fsKR = File.Create(clsFunctions.krHTMPath))
                { }

                StreamWriter krWriter = new StreamWriter(clsFunctions.krHTMPath);
                krWriter.Write(loadKRSource);
                krWriter.Close();

                webKR.Url = new Uri(clsFunctions.krHTMPath);
            }
            catch (Exception ex)
            {
                //refreshBot();
                clsFunctions.writeLog("[ERROR] - loadKR()", ex.ToString(), txtUsername.Text);
            }
        }

        private void btnPauseBot_Click(object sender, EventArgs e)
        {
            if (isPaused)
            {
                refreshBot();
                txtTimerMin.ForeColor = Color.White;
                txtTimerSec.ForeColor = Color.White;
            }
            else
            {
                hornTimer.Stop();
                txtTimerMin.ForeColor = Color.Gold;
                txtTimerSec.ForeColor = Color.Gold;
            }
            isPaused = !isPaused;
        }

        private void btnKRSubmit_Click(object sender, EventArgs e)
        {
            
        }

        private void refreshCatchData()
        {
            try
            {
                txtInfoCatchTime.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].catchTime;
                txtHomeMouseTime.Text = txtInfoCatchTime.Text;

                if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("catchsuccess"))
                {
                    txtMouseName.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].mouseName;
                    txtWeight.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].mouseWeight;
                    txtPointsGoldWeight.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].mousePoints + " Points | " + catchList[getSelectedCatchItem(imgLogArrow.Left)].mouseGold + " Gold";
                    txtLoot.Text = "";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("catchuccessloot"))
                {
                    txtMouseName.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].mouseName;
                    txtWeight.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].mouseWeight;
                    txtPointsGoldWeight.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].mousePoints + " Points | " + catchList[getSelectedCatchItem(imgLogArrow.Left)].mouseGold + " Gold";
                    txtLoot.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].mouseLoot;

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("catchfailuredamage"))
                {
                    txtMouseName.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].mouseName;
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].mousePillage;
                    txtLoot.Text = "";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("catchfailure"))
                {
                    txtMouseName.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].mouseName;
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = "Failed to catch.";
                    txtLoot.Text = "";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("attractionfailurestale"))
                {
                    txtMouseName.Text = "No Mouse Attracted";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = "Cheese went stale.";
                    txtLoot.Text = "Replaced cheese.";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("attractionfailure"))
                {
                    txtMouseName.Text = "No Mouse Attracted";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = "";
                    txtLoot.Text = "";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("captchasolved"))
                {
                    txtMouseName.Text = "Answered King's Reward";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = "Claimed " + catchList[getSelectedCatchItem(imgLogArrow.Left)].rewardContents;
                    txtLoot.Text = "";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("itemtransaction"))
                {
                    txtMouseName.Text = "Item Transaction";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].transactionAction + catchList[getSelectedCatchItem(imgLogArrow.Left)].itemTransacted;
                    txtLoot.Text = "for " + catchList[getSelectedCatchItem(imgLogArrow.Left)].goldTransacted + " gold";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("supplytransferitem"))
                {
                    txtMouseName.Text = "Item Transfer";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].transactionAction + catchList[getSelectedCatchItem(imgLogArrow.Left)].itemTransacted;
                    if (catchList[getSelectedCatchItem(imgLogArrow.Left)].transactionAction.Equals("Sent "))
                        txtLoot.Text = "to " + catchList[getSelectedCatchItem(imgLogArrow.Left)].hunterTransacted;
                    else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].transactionAction.Equals("Received "))
                        txtLoot.Text = "from " + catchList[getSelectedCatchItem(imgLogArrow.Left)].hunterTransacted;

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("supplytransfergold"))
                {
                    txtMouseName.Text = "Gold Transfer";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].transactionAction + catchList[getSelectedCatchItem(imgLogArrow.Left)].goldTransacted;
                    if (catchList[getSelectedCatchItem(imgLogArrow.Left)].transactionAction.Equals("Sent "))
                        txtLoot.Text = "to " + catchList[getSelectedCatchItem(imgLogArrow.Left)].hunterTransacted;
                    else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].transactionAction.Equals("Received "))
                        txtLoot.Text = "from " + catchList[getSelectedCatchItem(imgLogArrow.Left)].hunterTransacted;

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("travel"))
                {
                    txtMouseName.Text = "Location Changed";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].toLocationTravelled;
                    txtLoot.Text = "Used " + catchList[getSelectedCatchItem(imgLogArrow.Left)].goldUsedTravelled + " Gold";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("marketplacepurchase"))
                {
                    txtMouseName.Text = "Marketplace Transaction";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = "Purchased " + catchList[getSelectedCatchItem(imgLogArrow.Left)].itemTransacted;
                    txtLoot.Text = "For " + catchList[getSelectedCatchItem(imgLogArrow.Left)].goldTransacted + " Gold";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("marketplacesale"))
                {
                    txtMouseName.Text = "Marketplace Transaction";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = "Sold " + catchList[getSelectedCatchItem(imgLogArrow.Left)].itemTransacted;
                    txtLoot.Text = "For " + catchList[getSelectedCatchItem(imgLogArrow.Left)].goldTransacted + " Gold each";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("potionuse"))
                {
                    txtMouseName.Text = "Cheese Crafting [Potion]";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].cheeseCrafted;
                    txtLoot.Text = "From " + catchList[getSelectedCatchItem(imgLogArrow.Left)].potionsUsed + " and " + catchList[getSelectedCatchItem(imgLogArrow.Left)].cheeseUsed + ", costing " + catchList[getSelectedCatchItem(imgLogArrow.Left)].goldSpent;

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("craft"))
                {
                    txtMouseName.Text = "Cheese Crafting [Items]";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = catchList[getSelectedCatchItem(imgLogArrow.Left)].cheeseCrafted;
                    txtLoot.Text = "";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("titlechange"))
                {
                    txtMouseName.Text = "Title Advancement";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = "Advanced to " + catchList[getSelectedCatchItem(imgLogArrow.Left)].titleReceived;
                    txtLoot.Text = "";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("badge"))
                {
                    txtMouseName.Text = "Achievement Badge";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = "Obtained " + catchList[getSelectedCatchItem(imgLogArrow.Left)].badgeReceived;
                    txtLoot.Text = "Caught " + catchList[getSelectedCatchItem(imgLogArrow.Left)].numOfMiceForBadge + " " + catchList[getSelectedCatchItem(imgLogArrow.Left)].mouseName + " mice";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("misc") && catchList[getSelectedCatchItem(imgLogArrow.Left)].toLocationTravelled.Equals("Jungle Of Dread"))
                {
                    txtMouseName.Text = "Strong Currents!";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = "Flushed to " + catchList[getSelectedCatchItem(imgLogArrow.Left)].toLocationTravelled;
                    txtLoot.Text = "By a Riptide mouse!";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else if (catchList[getSelectedCatchItem(imgLogArrow.Left)].resultType.Equals("drawballotpurchase"))
                {
                    txtMouseName.Text = "Purchased Ballots";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = "Purchased " + catchList[getSelectedCatchItem(imgLogArrow.Left)].ballotsPurchased + " ballots.";
                    txtLoot.Text = "Hope to win 500 SB+ in Daily Draw.";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
                else
                {
                    txtMouseName.Text = "";
                    txtWeight.Text = "";
                    txtPointsGoldWeight.Text = "";
                    txtLoot.Text = "";

                    if (getSelectedCatchItem(imgLogArrow.Left) == 0)
                    {
                        txtHomeMouseName.Text = txtMouseName.Text;
                        txtHomeMouseWeight.Text = txtWeight.Text;
                        txtHomeMouseDetails.Text = txtPointsGoldWeight.Text;
                        txtHomeMouseLoot.Text = txtLoot.Text;
                    }
                }
            }
            catch
            {
                txtStatus.Text = "Problem loading catches.";
            }
        }

        private int getSelectedCatchItem(int arrowLocation)
        {
            int catchNum;

            if (arrowLocation == 43)
                catchNum = 0;
            else if (arrowLocation == 103)
                catchNum = 1;
            else if (arrowLocation == 163)
                catchNum = 2;
            else if (arrowLocation == 223)
                catchNum = 3;
            else
                catchNum = 4;

            return catchNum;
        }

        private void refreshBot()
        {
            bool isLogin = false;
            isLogin = clsFunctions.login(userAccount.Username, userAccount.Password, txtStatus);

            if (isLogin)
            {
                txtStatus.Text = "Loading information.";
                txtStatus.Refresh();
                loadInfo();
                hornTimer.Start();
                txtStatus.Text = "Loading log information.";
                loadCatches();

                if (userAccount.DHasKR)
                {
                    txtTimerMin.Text = "K";
                    txtTimerSec.Text = "R";
                    txtTimerMin.ForeColor = Color.FromArgb(60, 180, 255);
                    txtTimerSec.ForeColor = Color.FromArgb(60, 180, 255);

                    loadKR();
                    hornTimer.Stop();
                }
                else
                {
                    refreshCatchData();
                }

                txtStatus.Text = "";
            }
            else
            {
                txtStatus.Text = "Error Logging In.";
            }
        }

        private void btnSyncData_Click(object sender, EventArgs e)
        {
            hornTimer.Stop();
            refreshBot();
        }

        private void btnResyncDataKRTemp_Click(object sender, EventArgs e)
        {
            pnlKingsReward.Hide();
            string loadKRSource = "<html></html>";
            try
            {
                StreamWriter krWriter = new StreamWriter(clsFunctions.krHTMPath);
                krWriter.Write(loadKRSource);
                krWriter.Close();
                webKR.Refresh();
            }
            catch (Exception ex)
            {
                clsFunctions.writeLog("[ERROR] - btnResyncDataKRTemp_Click()", ex.ToString(), txtUsername.Text);
            }
            refreshBot();
        }

        private void btnAboutNews_Click(object sender, EventArgs e)
        {
            selectedAbout = "news";
            btnAboutNews.Image = Properties.Resources.btnAboutNewsClick;
            btnAboutTalk.Image = Properties.Resources.btnAboutTalk;
            webAbout.Url = new Uri(clsFunctions.newsURL);
        }

        private void btnAboutTalk_Click(object sender, EventArgs e)
        {
            selectedAbout = "talk";
            btnAboutNews.Image = Properties.Resources.btnAboutNews;
            btnAboutTalk.Image = Properties.Resources.btnAboutTalkClick;
            webAbout.Url = new Uri(clsFunctions.talkURL);
        }

        private bool checkSavedAccounts()
        {
            accountsSaved = clsFunctions.readArrayFromFile(Application.StartupPath + @"\accountslist.dat");

            if (accountsSaved.Count == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void loadSavedAccounts()
        {
            saveAccountsEnabled = checkSavedAccounts();

            if (saveAccountsEnabled)
            {
                pnlAccountsList.Visible = true;
                this.txtUsername.GotFocus += new EventHandler(txtUsername_GotFocus);
                this.txtUsername.LostFocus += new EventHandler(txtUsername_LostFocus);

                rabOnOff.Image = Properties.Resources.rabOn;

                lstSavedUsers.DataSource = accountsSaved;

                txtAccountsList.Text = clsFunctions.readFromFile(Application.StartupPath + @"\accountslist.dat");

                if (accountsSaved.Count < 6)
                {
                    pnlAccountsList.Height = 13 * (accountsSaved.Count - 1) + 16;
                    lstSavedUsers.Height = 13 * (accountsSaved.Count - 1);
                    imgSavedUsersPnlBG.Height = 13 * (accountsSaved.Count - 1);
                    imgUsernamesTab.Top = 13 * (accountsSaved.Count - 1);
                }
                else
                {
                    pnlAccountsList.Height = 81;
                    lstSavedUsers.Height = 65;
                    imgSavedUsersPnlBG.Height = 65;
                    imgUsernamesTab.Top = 65;
                }
            }
            else
            {
                pnlAccountsList.Visible = false;
                this.txtUsername.GotFocus -= new EventHandler(txtUsername_GotFocus);
                this.txtUsername.LostFocus -= new EventHandler(txtUsername_LostFocus);
                rabOnOff.Image = Properties.Resources.rabOff;
                lstSavedUsers.DataSource = accountsSaved;
            }
        }

        private void lstSavedUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUsername.Text = lstSavedUsers.SelectedItem.ToString();
            txtPassword.Focus();
            pnlAccountsList.Visible = false;
        }

        private void btnAccountsSave_Click(object sender, EventArgs e)
        {
            saveAccountsList();
            pnlAccounts.Visible = false;
        }

        private void saveAccountsList()
        {
            if (txtAccountsList.Text.Trim().Equals(""))
            {
                rabOnOff.Image = Properties.Resources.rabOff;
            }
            else
            {
                rabOnOff.Image = Properties.Resources.rabOn;
            }

            try
            {
                txtAccountsStatus.Text = "Saving file.";
                bool writeSuccess = clsFunctions.writeToFile(txtAccountsList.Text, Application.StartupPath + @"\accountslist.dat");

                if (writeSuccess)
                    txtAccountsStatus.Text = "Save successful.";
                else
                    txtAccountsStatus.Text = "Error saving accounts list.";
            }
            catch (Exception ex)
            {
                txtAccountsStatus.Text = "Error saving accounts list.";
                clsFunctions.writeLog("[ERROR] - saveAccountsList()", ex.ToString(), txtUsername.Text);
            }

            loadSavedAccounts();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            pnlAccounts.Show();
        }

        private void frmPikabot_Shown(object sender, EventArgs e)
        {
            Thread tAnn;
            tAnn = new Thread(new ThreadStart(processAnnouncement));
            tAnn.Start();
            do
            {
                Application.DoEvents();
            } while (tAnn.IsAlive);

            if (!clsFunctions.announcement.Equals(""))
            {
                pnlAnnouncement.Show();
                txtAnnouncementContents.Text = clsFunctions.announcement;
            }
        }

        public void processAnnouncement()
        {
            String ann = clsFunctions.getAnnouncement();
            if (!ann.Equals(clsFunctions.readFromFile("announcement.dat")) && !ann.Equals(""))
            {
                //MessageBox.Show(null, ann, "New Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsFunctions.announcement = ann;

                try
                {
                    clsFunctions.writeToFile(ann, "announcement.dat");
                }
                catch
                { }
            }
            else
            {
                clsFunctions.announcement = "";
            }
        }
    }
}
