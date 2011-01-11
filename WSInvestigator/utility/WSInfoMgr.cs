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
    class WSInfoMgr : InfoMgr
    {
        private IPTSession ptSession;

        public WSInfoMgr(IPTSession _ptSession)
        {
            this.ptSession = _ptSession;
        }

        public string getAllWebServicesInfoAsString()
        {
            String result = "";

            DataView wsDV = new DataView(getAllWebServicesInfo());
            wsDV.Sort = "name asc";

            //show result
            result += "I found this number of results = " + wsDV.Count + "\n";
            for (int i = 0; i < wsDV.Count; i++)
            {

                string createdDate = wsDV[i]["createdDate"].ToString();

                string modifiedDate = wsDV[i]["modifiedDate"].ToString();
                string[] _modD = modifiedDate.Split('/');   

                String tmp = "name: " + wsDV [i] ["name"].ToString()
                    + ", description: " + wsDV[i]["description"].ToString()
                    + ", enabled: " + bool.Parse(wsDV[i]["state"].ToString())
                    + ", object id: " + int.Parse(wsDV[i]["oid"].ToString())  
                    + ", owner id: " + int.Parse(wsDV[i]["ownerID"].ToString())
                    + ", admin Folder ID: " + int.Parse(wsDV[i]["adminFolderID"].ToString()) 
                    + ", remote server ID: " + int.Parse(wsDV[i]["remoteServerID"].ToString())  
                    + ", relative URL: " + wsDV[i]["relativeURL"].ToString()  
                    + ", full URL: " + wsDV[i]["fullURL"].ToString()  
                    + ", provider CLSID: " + wsDV[i]["providerCLSID"].ToString()
                    + ", created date: " + createdDate
                    +", modified date: " + modifiedDate
                    + "\n\n";
                result += tmp;
            }
            return result;
        }

        public WSDataTable getAllWebServicesInfo()
        {
            //return all webservices, regards of the enabled/disabled status
            return this.getAllWebServicesInfo(false);
        }

        public WSDataTable getAllWebServicesInfo(bool status)
        {
            IPTObjectManager webserviceMgr;

            //get a webservices Object Manager.
            webserviceMgr = ptSession.GetWebServices();

            //build filter as required
            Object[][] objQueryFilter = new Object[3][];
            for (int i = 0; i < 3; i++)
            {
                objQueryFilter[i] = new Object[1];
            }

            //Build the query filters
            if (status)
            {
                //search for Status of the Web Services, enabled or disabled.
                objQueryFilter[0][0] = PT_PROPIDS.PT_PROPID_WEBSERVICE_ENABLED;
                objQueryFilter[1][0] = PT_FILTEROPS.PT_FILTEROP_EQ;
                //Enabled WS has value of 1, and Disabled WS has value 0;
                objQueryFilter[2][0] = 1; //true
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
                webserviceMgr.Query(PT_PROPIDS.PT_PROPID_OBJECTID | PT_PROPIDS.PT_PROPID_NAME, -1, PT_PROPIDS.PT_PROPID_OBJECTID, 0, -1, objQueryFilter);
            
            WSDataTable wstab = new WSDataTable();
            wstab.CreateDataSource();

            for (int i = 0; i < results.RowCount(); i++)
            {
                int objectId = results.ItemAsInt(i, PT_PROPIDS.PT_PROPID_OBJECTID);
                IPTWebService webservice = (IPTWebService)webserviceMgr.Open(objectId, false);

                string name = webservice.GetName() != null ? webservice.GetName() : "";
                int remoteServerID = webservice.GetRemoteServerID();
                
                String description = webservice.GetDescription() != "" ? webservice.GetDescription() : "" ;
                //This solves the problem with return in the WS description box.
                // and carriage return (CR) -> \r
                // and line feed (LF)  -> \n
                if ((description != null) && !(description.Equals("")))
                    description = description.Replace("\r\n", " --linefeed-- ");

                bool state = webservice.GetEnabled();
                int adminFolderID = webservice.GetAdminFolderID();
                string adminPath = (new MiscUtil().GetAdminFolderPath(ptSession, adminFolderID));
                XPDateTime createdDate = webservice.GetCreated();
                XPDateTime modifiedDate = webservice.GetLastModified();
                int oid = webservice.GetObjectID();
                int ownerID = webservice.GetOwnerID();
                string providerCLSID = webservice.GetProviderCLSID() != null ? webservice.GetProviderCLSID() : "none";

                IXPPropertyBag ixp = webservice.GetProviderInfo();

                // get all the available property bag objects for this class. used for test code.
                IXPEnumerator iee = ixp.GetEnumerator();
                string propertybag_keys = "";
                while (iee.MoveNext() != false)
                    propertybag_keys += iee.GetCurrent() + ", ";
                // com.plumtree.server.PlumtreeExtensibility.PT_PROPBAG_HTTPGADGET_URL = "PTC_HTTPGADGET_URL"
                // see DotNet version documentation.

                //get relative url                
                String relativeURL = ixp.ReadAsString(PlumtreeExtensibility.PT_PROPBAG_HTTPGADGET_URL);
                //create full url
                String fullURL = getRemoteServerURL(remoteServerID) + relativeURL;

                wstab.addEntry(name, description, state, oid, ownerID, adminPath, remoteServerID,
                    relativeURL, fullURL, providerCLSID, createdDate, modifiedDate, propertybag_keys);
            }
            return wstab;
        }

        public String getRemoteServerURL(int _serverOID)
        {
            String baseurl = "";
            if (_serverOID != 0)
            {
                //IPTGadgetContentServer is now called as the portlet Remote server.
                IPTObjectManager iserverMgr = ptSession.GetGadgetContentServers();
                IPTGadgetContentServer iserver = (IPTGadgetContentServer)iserverMgr.Open(_serverOID, false);
                baseurl = iserver.GetURL();
            }
            else
                baseurl = "Intrinsic Web Service";
            return baseurl;
        }

    }
}
