using GithubApiDLL;
using GithubApiDLL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectListApp
{
    public class GithubUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        GithubApi? githubApi;
        public
        GithubApi? GithubUser { get => githubApi;
            set 
            {
                githubApi = value;
                OnPropertyChanged(nameof(GithubUser));
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

    }
}
