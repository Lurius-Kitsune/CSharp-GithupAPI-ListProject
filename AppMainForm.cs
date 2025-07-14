using ProjectList.Github;
using ProjectList.Singleton;
using ProjectList.Widget.Buttons;
using System;
using System.Diagnostics;

namespace ProjectList
{
    public partial class AppMainForm : Form
    {
        GithubApi githubApi;
        private bool isAuthCancelled = false;

        public bool IsAuthCancelled { get => isAuthCancelled; set => isAuthCancelled = value; }

        private AppMainForm()
        {
            InitializeComponent();
            Load += OnFormLoad;
            githubApi = GithubApi.Instance;
        }

        private void OnFormLoad(object? _sender, EventArgs _e)
        {
            connectionButton.UpdateButtonStyle();
            connectionCode.Text = "";
            cancelAuthButton.Click += (_sender, _e) =>
            {
                IsAuthCancelled = true;
                connectionCode.Text = "Connexion annulée";
                cancelAuthButton.Visible = false;
            };
            cancelAuthButton.Visible = false;
            tabControl1.SelectedIndexChanged += (_sender, _e) =>
            {
                if (tabControl1.SelectedTab == tabPage2)
                {
                    // If the user is not connected, we disable the tab
                    if (!githubApi.IsAccessTokenPresent())
                    {
                        tabControl1.SelectedIndex = 0;
                        MessageBox.Show("Vous devez être connecté pour accéder à cette page.", "Connexion requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        tabPage2.Enabled = true;
                        RefreshRepositoryList(_sender, _e);
                    }
                }
            };

            githubApi.OnUserInfoReady += GithubApi_OnUserInfoReady;
            githubApi.OnUserDisconnect += (sender, e) =>
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => UpdateUserInfoUI(githubApi.UserInfo)));
                }
                else
                {
                    UpdateUserInfoUI(githubApi.UserInfo);
                }
            };
            githubApi.OnDeviceCodeReceived += (_sender, _deviceCode) =>
            {
                Invoke(new Action(() => connectionCode.Text = "Code de connexion : " + _deviceCode + ", Veuillez l'écrire sur le navigateur qui c'est ouvert"));
            };
            githubApi.OnTokenReceived += (_sender, _token) =>
            {
                Invoke(new Action(() =>
                {
                    connectionCode.Text = "";
                    tabControl1.Enabled = true;
                    cancelAuthButton.Visible = false;
                }));
            };
            GithubApi_OnUserInfoReady(this, githubApi.UserInfo);
        }

        public AppMainForm(GithubApi _githubApi) : this()
        {
            this.githubApi = _githubApi;
            if (!DataManager.Instance.IsAccessTokenPresent())
            {
                textBox1.Text = "Aucun accessToken";
                textBox1.ReadOnly = true;
                return;
            }

            textBox1.Text = _githubApi.AccessToken;
        }

        private void GithubApi_OnUserInfoReady(object? _sender, GithubUser _user)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => GithubApi_OnUserInfoReady(_sender, _user)));
            }
            else
            {
                UpdateUserInfoUI(_user);
                githubApi.UserInfo.OnRepositoriesFetched += OnRepositoryFetched;
            }
        }

        private void UpdateUserInfoUI(GithubUser _user)
        {
            textBox1.Text = githubApi.AccessToken;
            pictureBox1.Image = _user.AvatarImage == null ? pictureBox1.InitialImage : _user.AvatarImage;
            usernameInfo.Text = _user.UserName == null ? "" : _user.UserName;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
        }
        private void connectionButton_Click(object sender, EventArgs e)
        {
            if (connectionButton.IsConnected) return;
            IsAuthCancelled = false;
            //tabControl1.Enabled = false;
            connectionCode.Text = "Connexion en cours...";
            tabPage2.Enabled = false;
            cancelAuthButton.Visible = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object _sender, EventArgs _e)
        {
            RefreshRepositoryList(_sender, _e);
        }
    }
}
