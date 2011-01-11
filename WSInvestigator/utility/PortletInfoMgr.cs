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
    class PortletInfoMgr : InfoMgr
    {
        private IPTSession ptSession;

        public PortletInfoMgr(IPTSession _ptSession)
        {
            this.ptSession = _ptSession;
        }

        public PortletDataTable getAllportletsInfo()
        {
            //return all portlets, regards of the enabled/disabled status
            return this.getAllportletsInfo(false);
        }

        public PortletDataTable getAllportletsInfo(bool status)
        {
            IPTObjectManager portletMgr;

            //get a portlets Object Manager.
            portletMgr = ptSession.GetGadgets();

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
                portletMgr.Query(PT_PROPIDS.PT_PROPID_OBJECTID | PT_PROPIDS.PT_PROPID_NAME, -1, PT_PROPIDS.PT_PROPID_OBJECTID, 0, -1, objQueryFilter);

            PortletDataTable portletDataTable = new PortletDataTable();
            portletDataTable.CreateDataSource();

            for (int i = 0; i < results.RowCount(); i++)
            {
                int objectId = results.ItemAsInt(i, PT_PROPIDS.PT_PROPID_OBJECTID);
                IPTGadget portlet = (IPTGadget) portletMgr.Open(objectId, false);

                string name = portlet.GetName() != null ? portlet.GetName() : "";
                int template = portlet.GetGadgetTemplateID();
                
                String description = portlet.GetDescription() != "" ? portlet.GetDescription() : "" ;
                //This solves the problem with return in the WS description box.
                // and carriage return (CR) -> \r
                // and line feed (LF)  -> \n
                if ((description != null) && !(description.Equals("")))
                    description = description.Replace("\r\n", " --linefeed-- ");

                int adminFolderID = portlet.GetAdminFolderID();
                string adminPath = (new MiscUtil().GetAdminFolderPath(ptSession, adminFolderID));
                XPDateTime createdDate = portlet.GetCreated();
                XPDateTime modifiedDate = portlet.GetLastModified();
                int oid = portlet.GetObjectID();
                int ownerID = portlet.GetOwnerID();
                int webserviceID = portlet.GetWebServiceID();
 
                ///portlet alignment means the type of portlet, e.g. narrow, wide, header, footer, canvas, ...
                int _alignment = portlet.GetAlignment();
                string alignment = "";
                switch (_alignment)
                {
                    case 0:
                        alignment = "null";
                        break;
                    case 1:
                        alignment = "narrow";
                        break;
                    case 2:
                        alignment = "wide";
                        break;
                    case 3:
                        alignment = "header";
                        break;
                    case 4:
                        alignment = "footer";
                        break;
                    case 5:
                        alignment = "canvas";
                        break;
                }
 
                IXPPropertyBag ixp = portlet.GetProviderInfo();
                // get all the available property bag objects for this class. used for test code.
                IXPEnumerator iee = ixp.GetEnumerator();
                string propertybag_keys = "";
                while (iee.MoveNext() != false)
                    propertybag_keys += iee.GetCurrent() + ", ";

                portletDataTable.addEntry(name, description, alignment, oid, ownerID, adminPath,
                    webserviceID, createdDate, modifiedDate, propertybag_keys);
            }
            return portletDataTable;
        }

    }
}
