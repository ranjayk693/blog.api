using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BAL.Helper
{
    public static class RolesInfo
    {
        public static Dictionary<string, string> RolesSet = new Dictionary<string, string> {
             { "8DB49539-4FD7-47A9-8C9C-2E1F33214E1B", "User" },
             { "D3ED64FD-7216-4266-82F3-3D94C040B7D4", "Admin" },
             { "228E4FB1-6E5F-47D5-807F-3D2FCFC72413", "SuperAdmin" },
        };
    }
}
