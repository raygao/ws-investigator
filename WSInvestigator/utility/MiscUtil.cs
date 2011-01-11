using System;
using System.Collections.Generic;
using System.Text;

using com.plumtree.server.search;
using com.plumtree.server;

namespace wssearch
{
    class MiscUtil
    {
        public string GetAdminFolderPath(IPTSession ptSession, int adminFolderID)
        {
            return  ptSession.GetAdminCatalog().OpenAdminFolder(adminFolderID, false).GetPath();
        }
    }
}
