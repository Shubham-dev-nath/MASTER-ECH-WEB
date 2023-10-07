using MasterMechLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using static System.Collections.Specialized.BitVector32;

namespace MasterMechWeb.Controllers
{
    public class HomeController : Controller
    {
        string lsPasswrd = " "; 

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

        public ActionResult User()
        {
            return View();
        }

        public ActionResult Login()
        {
            UserDtl lObjUserDtl = new UserDtl();
            lObjUserDtl.msMobNo = "1234567895";
            lObjUserDtl.msEmailID = "user@gmail.com";
            //lObjUserDtl.msUserName = "Temp"; //sending a Value which is hidden in the view as UserName is a required file
            //ViewBag.FYList = MasterMechUtil.FYList();
            ////ViewBag.CurrFY = MasterMechUtil.CurrFY();
            ////lObjUserDtl.msUserID = "NapaSOFT";
            return View(lObjUserDtl);
        }


        [HttpPost]
        public ActionResult Login(UserDtl ilObjUserDtl,string FYear)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    ilObjUserDtl.msPwd = MasterMechUtil.Encrypt(ilObjUserDtl.msPwd);
                    //     string lsConstr = ConfigurationManager.ConnectionStrings["MasterMechDB"].ConnectionString;
                    //     string lsCoState = ConfigurationManager.AppSettings["STATE"].ToString();

                    if (ilObjUserDtl.ValidLogin(MasterMechUtil.Constr))
                    {
                        ViewBag.FinancialYear = MasterMechUtil.FYList();
                        //MasterMechUtil.sPassrd = MasterMechUtil.Decrypt(ilObjUserDtl.msPwd);
                        Session["UserID"] = ilObjUserDtl.msUserID;
                        Session["UserName"] = ilObjUserDtl.msUserName;
                        Session["UserType"] = ilObjUserDtl.msUserType;
                        Session["State"] = MasterMechUtil.mbBussiState;
                        //ViewBag.Msg1 = "Valid";
                        MasterMechUtil.sUserID = ilObjUserDtl.msUserID;
                        MasterMechUtil.sFY = FYear;
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ViewBag.Msg2 = "Invalid";
                        return View();
                        //return RedirectToAction("Login", "Home");
                    }
                }
                //return RedirectToAction("Login", "Home");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Menu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logout(UserDtl lObjUser)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (Session["UserID"] != null)
            {
                Session["UserID"] = null;
                return RedirectToAction("Logout", "Home");
            }
            else
            {
                return View(lObjUser);
            }
        }

        
        public ActionResult PasswordChange(UserDtl lObjPaswdCng,string ChangeMyPassrd)
        {
            //UserDtl lObjPassUpdUsr = new UserDtl();


            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                ChangeMyPassrd = MasterMechUtil.Encrypt(ChangeMyPassrd);
                lObjPaswdCng.UpdatePassword(MasterMechUtil.Constr, MasterMechUtil.sUserID, ChangeMyPassrd);
                return View(lObjPaswdCng);
            }
            catch 
            {
                return View();
            }
            //return View();
        }


        public ActionResult AccountDetails()
        {
            UserDtl oObjDtlId = new UserDtl();
            if (oObjDtlId.Load(MasterMechUtil.Constr, MasterMechUtil.sUserID))
                oObjDtlId.msPwd = MasterMechUtil.Decrypt(oObjDtlId.msPwd);

            else
            {
                ModelState.AddModelError("", "User was Deleted");
                return View(oObjDtlId);
            }
            return View(oObjDtlId);
        }

    }
}