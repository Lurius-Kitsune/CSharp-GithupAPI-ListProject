using ProjectList.Singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectList.Widget.Buttons
{
    public class ConnectionButton : Button
    {
        bool isConnected = false;

        public bool IsConnected { get => isConnected; private set => isConnected = value; }

        public ConnectionButton()
        {

        }

        // On FormLoad

        protected override void OnHandleCreated(EventArgs _e)
        {
            base.OnHandleCreated(_e);

            // Empêche d’exécuter plusieurs fois si jamais l’handle est recréé
            if (DesignMode) return;

            this.UseVisualStyleBackColor = false;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            IsConnected = DataManager.Instance.IsAccessTokenPresent();
            this.Click += ConnectionButton_Click;
            GithubApi.Instance.OnUserDisconnect += UpdateButtonStyle;
            GithubApi.Instance.OnTokenReceived += (_sender, _toker) => IsConnected = true;
            GithubApi.Instance.OnUserInfoReady += (_sender, _user) => UpdateButtonStyle();

            UpdateButtonStyle();
        }


        private void ConnectionButton_Click(object? _sender, EventArgs _e)
        {
            if(DesignMode) return;
            if (IsConnected)
            {
                GithubApi.Instance.DisconnectUser();
                IsConnected = DataManager.Instance.IsAccessTokenPresent();
            }
            else
            {
                GithubApi.Instance.InitOAuthConnexion();
            }
        }

        public void UpdateButtonStyle(object? _sender = null, EventArgs? _args = null)
        {
            if (DesignMode) return;
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateButtonStyle()));
                return;
            }

            if (IsConnected)
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
