using System;
using System.Collections.Generic;
using System.Text;

using com.plumtree.server;

namespace wssearch
{
    /// <summary>
    /// Factory class for getting XXXInfoMgr class, e.g. WSInfoMgr, PortletInfoMgr, etc.
    /// </summary>
    class InfoMgrFactory
    {
        //private constructor, Factory pattern
        private InfoMgrFactory()
        {
        }

        public static InfoMgr getMgr(String type, IPTSession iptsession)
        {
            if (type.Equals(Constants.WEBSERVICES))  {
                return (InfoMgr) (new WSInfoMgr(iptsession));
            }
            else if (type.Equals(Constants.PORTLET))  {
                return (InfoMgr) (new PortletInfoMgr(iptsession));
            }
            else if (type.Equals(Constants.COMMUNITY))
            {
                return (InfoMgr) (new CommunityInfoMgr(iptsession));
            }            
            else if (type.Equals(Constants.COMMUNITYPAGE))
            {
                return (InfoMgr) (new CommunityPageInfoMgr(iptsession));
            }

            //default to at least return a webservices manager.
            else {
                return (InfoMgr)(new WSInfoMgr(iptsession));
            }


        }

    }
}
