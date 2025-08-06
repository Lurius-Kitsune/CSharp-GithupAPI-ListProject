using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GithubApiDLL;
using GithubApiDLL.Data;

namespace ProjectListApp.ViewModels
{
    public class VMUserConnexion : INotifyPropertyChanged
    {

        public VMUserConnexion()
        {
            GithubApi.Instance.OnUserInfoReady += (sender, e) =>
            {
                GithubUser = e;
            };

        }



        private GithubUser githubUser = GithubApi.Instance.UserInfo;
        public GithubUser GithubUser
        {
            get => GithubApi.Instance.UserInfo;
            set { githubUser = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
