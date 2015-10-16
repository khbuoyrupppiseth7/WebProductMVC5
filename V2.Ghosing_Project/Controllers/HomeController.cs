using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using V2.Ghosing_Project.Models;

namespace V2.Ghosing_Project.Controllers
{
    public class HomeController : Controller
    {
        DBAccess _dbConnect = new DBAccess();
        DataSet _ds = new DataSet();
        clsUserAccount getUserAcc = new clsUserAccount();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Action_Success()
        {
            return View();
        }

        public ActionResult Grid_UserAccount()
        {
            List<clsUserAccount> lmd = new List<clsUserAccount>();  // creating list of model.

            _ds = _dbConnect.ExecuteDataSet("SELECT UserID, UserName, UserPWD, UserStatus FROM [dbo].[PS_UserACC];");
            string _isReStatus;

            foreach (DataRow dr in _ds.Tables[0].Rows) // loop for adding add from dataset to list<modeldata>
            {
                Int16 _getStatus = Convert.ToInt16(dr["UserStatus"]);
                if(_getStatus == 1)
                {
                    _isReStatus = "Active";
                }
                else
                {
                    _isReStatus = "Suspend";
                }
                lmd.Add(new clsUserAccount
                {
                    
                    _UserID = dr["UserID"].ToString(),
                    _UserName = dr["UserName"].ToString(),
                    _UserPWD = dr["UserPWD"].ToString(),
                    _UserStatus = _isReStatus.ToString(),

                    //ID = dr["ID"].ToString(), // adding data from dataset row in to list<modeldata>
                    //Title = dr["Title"].ToString(),
                    //ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]),
                    //Genre = dr["Genre"].ToString(),
                    //// Description = Convert.ToDateTime(dr["ProductDate"]),
                    //// ProductGrade = Convert.ToChar (dr["ProductGrade"]),
                    //// Price = (float) Convert.ToDouble(dr["Price"])
                    //Price = Convert.ToDouble(dr["Price"]),
                    //isAction = "Delect"
                });
            }
            return View(lmd);

        }
        public ActionResult Edit_UserAccount( string param1, string param2, string param3){
            getUserAcc._UserID =  param1;
            getUserAcc._UserName = param2;
            getUserAcc._UserStatus = param3;
            
            ViewBag.UserID = getUserAcc._UserID;
            ViewBag.UserName = getUserAcc._UserName;

            if (param3 == "Active")
            {
                ViewBag.UserStatus = "@checked = true";
            }
            else if (param3 == "Suspend")
            {
                ViewBag.UserStatus = "@checked = true";
            }
            //return Content("<script language='javascript' type='text/javascript'>alert('Cannot Successfully'); window.location.href = 'Account : " + param1 + "','Home';</script>");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_UserAccount(clsUserAccount u)
        {
            string _status = u._UserStatus;
            int _sta = 0;
            if (_status == "true")
            {
                _sta = 1;
            }

            int _Update = _dbConnect.ExecuteNonQuery("UPDATE PS_UserACC SET UserName = '" + u._UserName + "', UserStatus = "+ _sta +" WHERE UserID = '" + u._UserID + "'");

            if (_Update == 1)
            {
               // return Content("<script language='javascript' type='text/javascript'>alert('"+u._UserStatus+"');</script>");
                return Content("<script language='javascript' type='text/javascript'>alert('Successfully'); window.location.href = 'Grid_UserAccount','Home';</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Cannot Successfully" + u._UserID + "'); window.location.href = 'Grid_UserAccount','Home';</script>");
            }

           // return Content("<script language='javascript' type='text/javascript'>alert('Cannot Successfully: "+ u._UserID +"'); window.location.href = 'Grid_UserAccount','Home';</script>");
        }
        public ActionResult Delete_UserAccount(string param1) 
        {
            int Del_UserAcc = _dbConnect.ExecuteNonQuery("DELETE FROM [PS_UserACC] WHERE UserID = '" + param1 + "' AND  UserName != 'admin'");
            if (Del_UserAcc == 1)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Delete Successfully'); window.location.href = 'Grid_UserAccount','Home';</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You cannot delete this User.'); window.location.href = 'Grid_UserAccount','Home';</script>");
            }
            //return RedirectToAction("Grid_UserAccount","Home");
        }

        public ActionResult Grid_Customer()
        {
            List<clsCustomer> lmd = new List<clsCustomer>();  // creating list of model.
            DataSet _dsCustomer = new DataSet();
            _dsCustomer = _dbConnect.ExecuteDataSet("SELECT CustomerID, Name, idType, icpassportNo, Nationality, Gender, Birthdate, MaritalStatus, Address, " +
                                            " ZipCode, PostalCode, POBox, City, Country, Tel1, Tel2, Fax, Mobile, eMail, autono " +
                                            " FROM [dbo].[PS_Customers]; ");

            foreach (DataRow dr in _dsCustomer.Tables[0].Rows) // loop for adding add from dataset to list<modeldata>
            {
                lmd.Add(new clsCustomer
                {
                    _CustomerID = dr["CustomerID"].ToString(),
                    _Name = dr["Name"].ToString(),
                    _idType = dr["idType"].ToString(),
                    _icpassportNo = dr["idType"].ToString(),
                    _Nationality = dr["idType"].ToString(),
                    _Gender = dr["idType"].ToString(),
                    _Birthdate = dr["idType"].ToString(),
                    _MaritalStatus = dr["idType"].ToString(),
                    _Address = dr["idType"].ToString(),
                    _ZipCode = dr["idType"].ToString(),
                    _PostalCode = dr["idType"].ToString(),
                    _POBox = dr["idType"].ToString(),
                    _City = dr["idType"].ToString(),
                    _Country = dr["idType"].ToString(),
                    _Tel1 = dr["idType"].ToString(),
                    _Tel2 = dr["idType"].ToString(),
                    _Fax = dr["idType"].ToString(),
                    _Mobile = dr["idType"].ToString(),
                    _eMail = dr["idType"].ToString(),
                    //_autono = Convert.ToInt32(dr["autono"]),

                   
                });
            }
            return View(lmd);

        }

        public ActionResult Customer_New()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Customer_New(clsCustomer c)
        {
            int _InsertCustomer = _dbConnect.ExecuteNonQuery("INSERT INTO [PS_Customers]" +
                                    " ([CustomerID]" +
                                    ",[Name]" +
                                    ",[idType]" +
                                    ",[icpassportNo]" +
                                    ",[Nationality]" +
                                    ",[Gender]" +
                                    ",[Birthdate]" +
                                    ",[MaritalStatus]" +
                                    ",[Address]" +
                                    ",[ZipCode]" +
                                    ",[PostalCode]" +
                                    ",[POBox]" +
                                    ",[City]" +
                                    ",[Country]" +
                                    ",[Tel1]" +
                                    ",[Tel2]" +
                                    ",[Fax]" +
                                    ",[Mobile]" +
                                    ",[eMail]" +
                                    ",[autono])" +
                                    " VALUES(" +
                                    " '" + _dbConnect.AutoID() + "' " +
                                    " ,N'" + c._Name + "' " +
                                    " ,N'" + c._idType + "' " +
                                    " ,N'" + c._icpassportNo + "' " +
                                    " ,N'" + c._Nationality + "' " +
                                    " ,N'" + c._Gender + "' " +
                                    " ,N'" + DateTime.ParseExact(c._Birthdate, "yyyy-MM-dd", null) + "' " +
                                    " ,N'" + c._MaritalStatus + "' " +
                                    " ,N'" + c._Address + " ' " +
                                    " ,N'" + c._ZipCode +"' " +
                                    " ,N'" + c._PostalCode +"' " +
                                    " ,N'" + c._POBox +"' " +
                                    " ,N'" + c._City +"' " +
                                    " ,N'" + c._Country +"' " +
                                    " ,N'" + c._Tel1 +"' " +
                                    " ,N'" + c._Tel2 +"' " +
                                    " ,N'" + c._Fax +"' " +
                                    " ,N'" + c._Mobile +"' " +
                                    " ,N'" + c._eMail +"' " +
                                    " ,N'');");
            if (_InsertCustomer == 1)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Insert Successfully'); window.location.href = 'Grid_Customer','Home';</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('DB is Full'); window.location.href = 'Grid_Customer','Home';</script>");
            }
        }

        public ActionResult Testing()
        {
            return View();
        }
    }
}