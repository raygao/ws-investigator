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
    class PortletDataTable : DataTable
    {
        public PortletDataTable()
        {
        }

        public void CreateDataSource()
        {
            // Create a table to store data for the DropDownList control.            
            // Define the columns of the table.
            Columns.Add(new DataColumn("name", typeof(string)));
            Columns.Add(new DataColumn("description", typeof(string)));
            Columns.Add(new DataColumn("alignment", typeof(string)));
            Columns.Add(new DataColumn("oid", typeof(int)));
            Columns.Add(new DataColumn("ownerID", typeof(int)));
            Columns.Add(new DataColumn("Admin Folder Path", typeof(string)));
            Columns.Add(new DataColumn("webserviceID", typeof(int)));
            Columns.Add(new DataColumn("createdDate", typeof(XPDateTime)));
            Columns.Add(new DataColumn("modifiedDate", typeof(XPDateTime)));
            Columns.Add(new DataColumn("propertybag_keys", typeof(string)));
        }

        /// <summary>
        /// ceating individual rows
        /// </summary>
        /// <returns>a data row object</returns>
        public DataRow CreateRow(string name, string description, string alignment, int oid, int ownerID,
            string  adminFolderPath, int webserviceID, XPDateTime createdDate, XPDateTime modifiedDate, string propertybag_keys)
        {
            // Create a DataRow using the DataTable defined in the 
            // CreateDataSource method.
            DataRow dr = this.NewRow();
            dr[0] = name;
            dr[1] = description;
            dr[2] = alignment;
            dr[3] = oid;
            dr[4] = ownerID;
            dr[5] = adminFolderPath;
            dr[6] = webserviceID;
            dr[7] = createdDate;
            dr[8] = modifiedDate;
            dr[9] = propertybag_keys;
            return dr;
        }

        public void addEntry(string name, string description, string alignment, int oid, int ownerID,
            string adminFolderPath, int webserviceID, XPDateTime createdDate,
            XPDateTime modifiedDate, string propertybag_keys)
        {
            this.Rows.Add(CreateRow(name, description, alignment, oid, ownerID,
                adminFolderPath, webserviceID, createdDate, modifiedDate, propertybag_keys));
        }

    }
}
