using ProjectList.Github;
using ProjectList.Singleton;
using System;
using System.Diagnostics;

namespace ProjectList
{
    public partial class Form1 : Form
    {
        GithubApi githubApi;

        private Form1()
        {
            InitializeComponent();
            Load += OnFormLoad;
        }

        private void OnFormLoad(object? _sender, EventArgs _e)
        {
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
            UpdateUserInfoUI(githubApi.UserInfo);
        }

        public Form1(GithubApi _githubApi) : this()
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
                Invoke(new Action(() => UpdateUserInfoUI(_user)));
            }
            else
            {
                UpdateUserInfoUI(_user);
            }
        }

        private void UpdateUserInfoUI(GithubUser _user)
        {
            textBox1.Text = githubApi.AccessToken;
            pictureBox1.Image = _user.AvatarImage == null ? pictureBox1.InitialImage : _user.AvatarImage;
            usernameInfo.Text = _user.UserName == null ? "" : _user.UserName;
        }

    }
}
