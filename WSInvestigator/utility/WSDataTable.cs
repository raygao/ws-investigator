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
using System.Text;
using System.Data;
using com.plumtree.openfoundation.util;

namespace wssearch
{
    class WSDataTable : DataTable
    {
        public WSDataTable()
        {
        }

        public void CreateDataSource()
        {
            // Create a table to store data for the DropDownList control.            
            // Define the columns of the table.
            Columns.Add(new DataColumn("name", typeof(string)));
            Columns.Add(new DataColumn("description", typeof(string)));
            Columns.Add(new DataColumn("state", typeof(bool)));
            Columns.Add(new DataColumn("oid", typeof(int)));
            Columns.Add(new DataColumn("ownerID", typeof(int)));
            Columns.Add(new DataColumn("Admin Folder Path", typeof(string)));
            Columns.Add(new DataColumn("remoteServerID", typeof(int)));
            Columns.Add(new DataColumn("relativeURL", typeof(string)));
            Columns.Add(new DataColumn("fullURL", typeof(string)));
            Columns.Add(new DataColumn("providerCLSID", typeof(string)));
            Columns.Add(new DataColumn("createdDate", typeof(XPDateTime)));
            Columns.Add(new DataColumn("modifiedDate", typeof(XPDateTime)));
            Columns.Add(new DataColumn("propertybag_keys", typeof(string)));
        }

        /// <summary>
        /// ceating individual rows
        /// </summary>
        /// <returns>a data row object</returns>
        public DataRow CreateRow(string name, string description, bool state, int oid, int ownerID,
            string adminFolderPath, int remoteServerID, string relativeURL, string fullURL,
            string providerCLSID, XPDateTime createdDate, XPDateTime modifiedDate, string propertybag_keys)
        {
            // Create a DataRow using the DataTable defined in the 
            // CreateDataSource method.
            DataRow dr = this.NewRow();
            dr[0] = name;
            dr[1] = description;
            dr[2] = state;
            dr[3] = oid;
            dr[4] = ownerID;
            dr[5] = adminFolderPath;
            dr[6] = remoteServerID;
            dr[7] = relativeURL;
            dr[8] = fullURL;
            dr[9] = providerCLSID;
            dr[10] = createdDate;
            dr[11] = modifiedDate;
            dr[12] = propertybag_keys;
            return dr;
        }

        public void addEntry(string name, string description, bool state, int oid, int ownerID,
            string adminFolderPath, int remoteServerID, string relativeURL, string fullURL,
            string providerCLSID, XPDateTime createdDate, XPDateTime modifiedDate, string propertybag_keys)
        {
            this.Rows.Add(CreateRow(name, description, state, oid, ownerID, 
                adminFolderPath, remoteServerID, relativeURL, fullURL,
                providerCLSID, createdDate, modifiedDate, propertybag_keys));
        }

    }
}
