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
using com.plumtree.portalpages.browsing.myportal;

namespace wssearch
{
    class CommunityPageInfoMgr : InfoMgr
    {
        private IPTSession ptSession;

        public CommunityPageInfoMgr(IPTSession _ptSession)
        {
            this.ptSession = _ptSession;
        }

        public CommunityPageDataTable getAllCommunityPagesInfo()
        {
            //return all webservices, regards of the enabled/disabled status
            return this.getAllCommunityPagesInfo(false);
        }

        public CommunityPageDataTable getAllCommunityPagesInfo(bool status)
        {
            IPTObjectManager communityPageMgr;

            //get a communitys Object Manager.
            communityPageMgr = ptSession.GetPages();

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
                communityPageMgr.Query(PT_PROPIDS.PT_PROPID_OBJECTID | PT_PROPIDS.PT_PROPID_NAME, -1, PT_PROPIDS.PT_PROPID_OBJECTID, 0, -1, objQueryFilter);

            CommunityPageDataTable wstab = new CommunityPageDataTable();
            wstab.CreateDataSource();

            for (int i = 0; i < results.RowCount(); i++)
            {
                int objectId = results.ItemAsInt(i, PT_PROPIDS.PT_PROPID_OBJECTID);
                IPTPage communityPage = (IPTPage)communityPageMgr.Open(objectId, false);

                string name = communityPage.GetName() != null ? communityPage.GetName() : "";
                String description = communityPage.GetDescription() != "" ? communityPage.GetDescription() : "";
                //This solves the problem with return in the WS description box.
                // and carriage return (CR) -> \r
                // and line feed (LF)  -> \n
                if ((description != null) && !(description.Equals("")))
                    description = description.Replace("\r\n", " --linefeed-- ");

                int adminFolderID = communityPage.GetAdminFolderID();
                string adminPath = (new MiscUtil().GetAdminFolderPath(ptSession, adminFolderID));
                XPDateTime createdDate = communityPage.GetCreated();
                XPDateTime modifiedDate = communityPage.GetLastModified();
                int oid = communityPage.GetObjectID();
                int ownerID = communityPage.GetOwnerID();

                // Get potlets on this communityPage
                string portlets = "none";
                string plist = "";
                IPTQueryResult _portlets = communityPage.QueryPortlets();
                if (_portlets.RowCount() > 0)
                {
                    for (int j = 0; j < _portlets.RowCount(); j++)
                    {
                        plist += _portlets.ItemAsString(j, PT_PROPIDS.PT_PROPID_NAME) + ", ";
                    }
                    portlets = plist;
                }

                // Get inherited pagetemplate                
                string pagetemplate = "";
                int _pagetemplate = communityPage.GetPageTemplateID();
                IPTQueryResult _result = ptSession.GetPageTemplates().QuerySingleObject(_pagetemplate);
                //some pages do not inherit any page template.
                if (_result.RowCount() > 0) 
                    pagetemplate = _result.ItemAsString(0, PT_PROPIDS.PT_PROPID_NAME);

                wstab.addEntry(name, description, oid, ownerID, adminPath, portlets, pagetemplate,                     
                    createdDate, modifiedDate);
            }
            return wstab;
        }
    }
}
