///////////////////////////////////////////////////////////////////////////////////
/// Author:     Raymond Gao
/// Contact:    rgao@bea.com 
/// Date:       May 21, 2007
/// This mini app lists all "web services" installed in an ALUI app. 
/// This app is compiled with G6 MP1 server libraries.
/// This is an open-source project, no warranty or license available.
/// If you would like to participate in this project, 
/// please contact Ray Gao at mailto:rgao@bea.com or mailto:raygao2000@yahoo.com 
//////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Collections;

using com.plumtree.server.search;
using com.plumtree.server;

using com.plumtree.openkernel.factory;
using com.plumtree.xpshared.config;
using com.plumtree.openkernel;
using com.plumtree.openkernel.util;
using com.plumtree.openkernel.config;
using com.plumtree.server.search.ptapps;
using com.plumtree.openfoundation.util;

namespace wssearch
{
    class CommunityInfoMgr : InfoMgr
    {
        private IPTSession ptSession;

        public CommunityInfoMgr(IPTSession _ptSession)
        {
            this.ptSession = _ptSession;
        }


        public CommunityDataTable getAllCommunityInfo()
        {
            //return all communitys, regards of the enabled/disabled status
            return this.getAllCommunityInfo(false);
        }

        public CommunityDataTable getAllCommunityInfo(bool status)
        {
            IPTObjectManager communityMgr;

            //get a communitys Object Manager.
            communityMgr = ptSession.GetCommunities();

            //build filter as required
            Object[][] objQueryFilter = new Object[3][];
            for (int i = 0; i < 3; i++)
            {
                objQueryFilter[i] = new Object[1];
            }

            //Build the query filters
            if (status)
            {
                //do nothing
                ////search for Status of the Web Services, enabled or disabled.
                //objQueryFilter[0][0] = PT_PROPIDS.PT_PROPID_GADGET_GADGETTYPE;
                //objQueryFilter[1][0] = PT_FILTEROPS.PT_FILTEROP_EQ;
                ////Enabled WS has value of 1, and Disabled WS has value 0;
                //objQueryFilter[2][0] = 1; //true
            }
            else
            {
                //search against a specific string in the WS name. In the following case, all ws. 
                objQueryFilter[0][0] = PT_PROPIDS.PT_PROPID_NAME;
                objQueryFilter[1][0] = PT_FILTEROPS.PT_FILTEROP_CONTAINS;
                objQueryFilter[2][0] = "*";
            }
            //do query
            IPTQueryResult results =
                communityMgr.Query(PT_PROPIDS.PT_PROPID_OBJECTID | PT_PROPIDS.PT_PROPID_NAME, -1, PT_PROPIDS.PT_PROPID_OBJECTID, 0, -1, objQueryFilter);

            CommunityDataTable wstab = new CommunityDataTable();
            wstab.CreateDataSource();

            for (int i = 0; i < results.RowCount(); i++)
            {
                int objectId = results.ItemAsInt(i, PT_PROPIDS.PT_PROPID_OBJECTID);
                IPTCommunity community = (IPTCommunity)communityMgr.Open(objectId, false);

                string name = community.GetName() != null ? i + ", " + community.GetName() : ""; //with row number
                //string name = community.GetName() != null ? community.GetName() : "";  //without row number
                String description = community.GetDescription() != "" ? community.GetDescription() : "";
                //This solves the problem with return in the WS description box.
                // and carriage return (CR) -> \r
                // and line feed (LF)  -> \n
                if ((description != null) && !(description.Equals("")))
                    description = description.Replace("\r\n", " --linefeed-- ");

                int adminFolderID = community.GetAdminFolderID();
                string adminPath = (new MiscUtil().GetAdminFolderPath(ptSession, adminFolderID));
                XPDateTime createdDate = community.GetCreated();
                XPDateTime modifiedDate = community.GetLastModified();
                int oid = community.GetObjectID();
                int ownerID = community.GetOwnerID();
                string footer = this.getPortletName(community.GetFooterID());
                string header = this.getPortletName(community.GetHeaderID());

                // Get users in a communityPage
                string users = "none";
                string ulist = "";
                IPTQueryResult _users = community.QueryMembers(PT_CLASSIDS.PT_USER_ID);
                if (_users.RowCount() > 0)
                {
                    for (int j = 0; j < _users.RowCount(); j++)
                    {
                        ulist += _users.ItemAsString(j, PT_PROPIDS.PT_PROPID_NAME) + ", ";
                    }
                    users = ulist;
                }

                // Get groups in a communityPage
                string groups = "";
                string glist = "";
                IPTQueryResult _groups = community.QueryMembers(PT_CLASSIDS.PT_USERGROUP_ID);
                if (_groups.RowCount() > 0)
                {
                    for (int j = 0; j < _groups.RowCount(); j++)
                    {
                        glist += _groups.ItemAsString(j, PT_PROPIDS.PT_PROPID_NAME) + ", ";
                    }
                    groups = glist;
                }

                // Get pages in a communityPage
                string pages = "";
                string plist = "";
                IPTQueryResult _pages = community.QueryPages(0);
                if (_pages.RowCount() > 0)
                {
                    for (int j = 0; j < _pages.RowCount(); j++)
                    {
                        plist += _pages.ItemAsString(j, PT_PROPIDS.PT_PROPID_NAME) + ", ";
                    }
                    pages = plist;
                }

                // Get subcommunities
                string subcommunities = "";
                string subcommunitiesList = "";
                IPTQueryResult _subcommunities = community.QuerySubcommunities();
                if (_subcommunities.RowCount() > 0)
                {
                    for (int j = 0; j < _subcommunities.RowCount(); j++)
                    {
                        subcommunitiesList += _subcommunities.ItemAsString(j, PT_PROPIDS.PT_PROPID_NAME) + ", ";
                    }
                    subcommunities = subcommunitiesList;
                }

                wstab.addEntry(name, description, oid, footer, header, ownerID, adminPath, users,
                    pages, groups, subcommunities, createdDate, modifiedDate);
            }
            return wstab;
        }

        public string getPortletName(int oid)
        {
            String name = "";
            if ((oid != null) && (oid != 0))
            {
                //IPTGadgetContentServer is now called as the portlet Remote server.
                IPTObjectManager iMgr = ptSession.GetGadgets();
                IPTGadget iobj = (IPTGadget)iMgr.Open(oid, false);
                name = iobj.GetName();
            }
            else
                name = "none";
            return name;
        }

        public string getUsers()
        {
            string users = "";

            return users;
        }
    }
}
