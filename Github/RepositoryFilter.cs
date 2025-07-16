using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum RepositoryType
{
    Public,
    Private,
    All,
}

enum RepositoryAffiliation
{
    Owner,
    Collaborator,
    OrganizationMember,
    All,
}

enum RepositorySort
{
    Created,
    Updated,
    Pushed,
    FullName,
}

namespace ProjectList.Github
{
    class RepositoryFilter
    {

        public RepositoryType RepositoryType { get; set; } = RepositoryType.All;
        public bool IsForked { get; set; } = false;
        public bool IsArchived { get; set; } = false;
        public RepositoryAffiliation RepositoryAffiliation { get; set; } = RepositoryAffiliation.All;
        public RepositorySort RepositorySort { get; set; } = RepositorySort.FullName;

        public RepositoryFilter() { }

        public override string ToString()
        {
            string _req = string.Empty;
            if (RepositoryType != RepositoryType.All)
            {
                _req += $"type={RepositoryType.ToString().ToLower()}&";
            }
            if (RepositoryAffiliation != RepositoryAffiliation.All)
            {
                _req += $"affiliation={RepositoryAffiliation.ToString().ToLower()}&";
            }
            if (RepositorySort != RepositorySort.FullName)
            {
                _req += $"sort={RepositorySort.ToString().ToLower()}&";
            }
            if (_req.EndsWith("&"))
            {
                _req = _req.Remove(_req.Length - 1); // Remove the trailing '&'
            }
            return _req.Length > 0 ? _req : string.Empty;
        }
    }
}
