using System;
using System.Data;
using System.Web.Security;
using umbraco.BusinessLogic;
using umbraco.DataLayer;
using umbraco.BasePages;
using Umbraco.Core.IO;
using umbraco.cms.businesslogic.member;

namespace umbraco
{
    public class DataTypeTasks : interfaces.ITaskReturnUrl
    {

        private string _alias;
        private int _parentID;
        private int _typeID;
        private int _userID;

        public int UserId
        {
            set { _userID = value; }
        }
        public int TypeID
        {
            set { _typeID = value; }
            get { return _typeID; }
        }


        public string Alias
        {
            set { _alias = value; }
            get { return _alias; }
        }

        public int ParentID
        {
            set { _parentID = value; }
            get { return _parentID; }
        }

        public bool Save()
        {

            int id = cms.businesslogic.datatype.DataTypeDefinition.MakeNew(BusinessLogic.User.GetUser(_userID), Alias).Id;
            m_returnUrl = string.Format("developer/datatypes/editDataType.aspx?id={0}", id);
            return true;
        }

        public bool Delete()
        {
            cms.businesslogic.datatype.DataTypeDefinition.GetDataTypeDefinition(ParentID).delete();
            return true;
        }

        public DataTypeTasks()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region ITaskReturnUrl Members
        private string m_returnUrl = "";
        public string ReturnUrl
        {
            get { return m_returnUrl; }
        }

        #endregion

    }
}
