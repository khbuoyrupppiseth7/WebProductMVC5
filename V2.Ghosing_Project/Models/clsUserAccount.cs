using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace V2.Ghosing_Project.Models
{
    public class clsUserAccount
    {
        public string _UserID { get; set; }
        public string _UserName { get; set; }
        public string _UserPWD { get; set; }
        public string _UserStatus { get; set; }
    }

    //public class clsWorkCompleted
    //{
    //    public string _WorkID { get; set; }
    //    public string _WorkName { get; set; }

    //    public DataSet mydata()
    //    {

    //        DBAccess db_connect = new DBAccess();
    //        DataSet ds_movies = new DataSet();
    //        ds_movies = db_connect.ExecuteDataSet("SELECT [ID] " +
    //                                        " ,[Title] " +
    //                                        " ,[ReleaseDate] " +
    //                                        " ,[Genre] " +
    //                                        " ,[Price] " +
    //                                        " FROM [Movies]");

    //        return ds_movies;
    //    }  
    //}
    public class clsCustomer
    {
        public string _CustomerID { get; set; }
        public string _Name { get; set; }
        public string _idType { get; set; }
        public string _icpassportNo { get; set; }
        public string _Nationality { get; set; }
        public string _Gender { get; set; }
        public string _Birthdate { get; set; }
        public string _MaritalStatus { get; set; }
        public string _Address { get; set; }
        public string _ZipCode { get; set; }
        public string _PostalCode { get; set; }
        public string _POBox { get; set; }
        public string _City { get; set; }
        public string _Country { get; set; }
        public string _Tel1 { get; set; }
        public string _Tel2 { get; set; }
        public string _Fax { get; set; }
        public string _Mobile { get; set; }
        public string _eMail { get; set; }
        public string _autono { get; set; }
    }
    
     
}