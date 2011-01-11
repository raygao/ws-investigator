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
    class CommunityDataTable : DataTable
    {
        public CommunityDataTable()
        {
        }
        ///IPTCommunityInfo object
        ///GetName(), GetFooterID(), GetHeaderID(), GetObjectID(),
        ///GetMandatoryTabOrder(), GetPages(), GetParentCommunity()
        /// GetPeerCommunities(), QueryPrefs()
        ///GetOwnerInfo(),  GetMembers(), GetSubCommunities(),
        public void CreateDataSource()
        {
            // Create a table to store data for the DropDownList control.            
            // Define the columns of the table.
            Columns.Add(new DataColumn("name", typeof(string)));
            Columns.Add(new DataColumn("description", typeof(string)));
            Columns.Add(new DataColumn("objectID", typeof(int)));
            Columns.Add(new DataColumn("footer", typeof(string)));
            Columns.Add(new DataColumn("header", typeof(string)));
            Columns.Add(new DataColumn("ownerID", typeof(int)));
            Columns.Add(new DataColumn("Admin Folder Path", typeof(string)));
            Columns.Add(new DataColumn("users", typeof(string)));
            Columns.Add(new DataColumn("pages", typeof(string)));
            Columns.Add(new DataColumn("groups", typeof(string)));
            Columns.Add(new DataColumn("subcommunities", typeof(string)));
            Columns.Add(new DataColumn("createdDate", typeof(XPDateTime)));
            Columns.Add(new DataColumn("modifiedDate", typeof(XPDateTime)));
        }

        /// <summary>
        /// ceating individual rows
        /// </summary>
        /// <returns>a data row object</returns>
        public DataRow CreateRow(string name, string description, int objectID, string footer, string header,
            int ownerID, int adminFolderPath, string users, string pages, string groups,
            string subcommunities, XPDateTime createdDate, XPDateTime modifiedDate)
        {
            // Create a DataRow using the DataTable defined in the 
            // CreateDataSource method.
            DataRow dr = this.NewRow();
            dr[0] = name;
            dr[1] = description;
            dr[2] = objectID;
            dr[3] = footer;
            dr[4] = header;
            dr[5] = ownerID;
            dr[6] = adminFolderPath;
            dr[7] = pages;
            dr[8] = users;            
            dr[9] = groups;
            dr[10] = subcommunities;
            dr[11] = createdDate;
            dr[12] = modifiedDate;
            return dr;
        }

        public void addEntry(string name, string description, int objectID, string footer, string header,
            int ownerID, string adminFolderPath, string users, string pages, string groups,
            string subcommunities, XPDateTime createdDate, XPDateTime modifiedDate)
        {
            this.Rows.Add(name, description, objectID, footer, header, ownerID, adminFolderPath, users, pages, 
                groups, subcommunities, createdDate, modifiedDate);
        }

    }
}
