using Blog.BAL.CustomExcption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BAL.Helper
{
    public class HeaderReader
    {
        public static bool CheckPermission(string PermissionId, string PermissionType = "User", int requireLevel = 0)
        {
            bool IsPresent = RolesInfo.RolesSet.TryGetValue(PermissionId,out string RoleName);
            if(IsPresent)
            {
                if ((RoleName == "SuperAdmin") || (RoleName == PermissionType) || (PermissionType == "User" && RoleName == "Admin"))
                {
                    // TODO
                    // Create A Enum FOr PermissionType
                    // Keep the Role Based Auth Later on We can introduced the permission based Auth.
                    return true;
                }
                throw new ForbiddenException("You do net have Enough Permission, Please Contact Admin");
            }
            throw new ForbiddenException("This Role does not Exits ,please Contact Admin");
        }
    }
}
// Outh
// OAuth