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
        public ActionResult Edit_UserAccount(string param1, string param2){
            getUserAcc._UserID =  param1;
            getUserAcc._UserName = param2;
            
            ViewBag.UserID = getUserAcc._UserID;
            ViewBag.UserName = getUserAcc._UserName;
            return View();
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

        public ActionResult Testing()
        {
            return View();
        }
    }
}