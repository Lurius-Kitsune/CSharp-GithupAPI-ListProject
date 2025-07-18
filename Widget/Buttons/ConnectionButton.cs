﻿using ProjectList.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectList.Widget.Buttons
{
    public class ConnectionButton : Button
    {
        bool isConnected = false;

        public ConnectionButton()
        {
            this.UseVisualStyleBackColor = false;
            isConnected = DataManager.Instance.IsAccessTokenPresent();
            this.Click += ConnectionButton_Click;
            GithubApi.Instance.OnUserDisconnect += UpdateButtonStyle;
            GithubApi.Instance.OnTokenReceived += (_sender, _toker) => isConnected = true;
            GithubApi.Instance.OnUserInfoReady += (_sender, _user) => UpdateButtonStyle();

            UpdateButtonStyle();
        }

        private void ConnectionButton_Click(object? _sender, EventArgs _e)
        {
            if (isConnected)
            {
                GithubApi.Instance.DisconnectUser();
            }
            else
            {
                GithubApi.Instance.InitOAuthConnexion();
            }
            // Le reste se feras en event
        }

        public void UpdateButtonStyle(object? _sender = null, EventArgs? _args = null)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateButtonStyle()));
                return;
            }

            if (isConnected)
            {
                this.Text = "Deconnexion";
                this.BackColor = Color.Green;
            }
            else
            {
                this.Text = "Connecter";
                this.BackColor = Color.Red;
            }
        }
    }
}
