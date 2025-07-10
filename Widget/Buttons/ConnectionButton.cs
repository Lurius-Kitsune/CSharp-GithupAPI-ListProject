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
            isConnected = DataManager.Instance.IsAccessTokenPresent();
            this.Click += ConnectionButton_Click;
            GithubApi.Instance.OnUserDisconnect += UpdateButtonStyle;
            GithubApi.Instance.OnUserInfoReady += (_sender, _user) => UpdateButtonStyle();

            UpdateButtonStyle();
        }


        private void ConnectionButton_Click(object? _sender, EventArgs _e)
        {
            if(DesignMode) return;
            if (isConnected)
            {
                GithubApi.Instance.DisconnectUser();
            }
            else
            {
                GithubApi.Instance.InitOAuthConnexion();
            }
            isConnected = !isConnected;
            // Le reste se feras en event
        }

        private void UpdateButtonStyle(object? _sender = null, EventArgs? _args = null)
        {
            if (DesignMode) return;
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
