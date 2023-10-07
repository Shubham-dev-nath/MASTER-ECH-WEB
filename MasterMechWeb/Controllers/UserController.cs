using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MasterMechLib;
using System.Xml.Linq;

namespace MasterMechWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            UserDtl lOjUser = new UserDtl();
            List<UserDtl> lObjUsers = lOjUser.ListUsers(MasterMechUtil.Constr);
            return View(lObjUsers);
        }


        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            UserDtl lObjUser = new UserDtl();
            if(lObjUser.Load(MasterMechUtil.Constr, id))
            lObjUser.msPwd = MasterMechUtil.Decrypt(lObjUser.msPwd);

            else
            {
                ModelState.AddModelError("", "User was Deleted");
                return View(lObjUser);
            }
            return View(lObjUser);
        }


        // GET: User/Create
        public ActionResult Create()
        {
            List<SelectListItem> lObjUserTypes = new List<SelectListItem>();
            lObjUserTypes.Add(
                new SelectListItem
                {
                    Text = "Administrator",
                    Value = "Admin"
                });

            lObjUserTypes.Add(new SelectListItem
            {
                Text = "Regular User",
                Value = "Regular"
            });

            this.ViewBag.UserType = new SelectList(lObjUserTypes, "Value", "Text");
            UserDtl lObjUser = new UserDtl();
            return View(lObjUser);
          //  return View();

        }


        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserDtl iObjUser)
        {
            List<SelectListItem> lObjUserTypes = new List<SelectListItem>();
            lObjUserTypes.Add(
                new SelectListItem
                {
                    Text = "Administrator",
                    Value = "Admin"
                });

            lObjUserTypes.Add(new SelectListItem
            {
                Text = "Regular User",
                Value = "Regular"
            });
           this.ViewBag.UserType = new SelectList(lObjUserTypes, "Text", "Value");
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        iObjUser.msPwd = MasterMechUtil.Encrypt(iObjUser.msPwd);

                        if (iObjUser.Save(MasterMechUtil.Constr, MasterMechUtil.sUserID, true))
                            return View(iObjUser);

                        else
                        {
                            ModelState.AddModelError("", "Unable to create a new User");
                            return View(iObjUser);
                        }
                    }
                    catch
                    {
                        return View(iObjUser);
                    }
                }
               // this.ViewBag.UserTypes = new SelectList(lObjUserTypes, "Value", "Text");
                return View(iObjUser);
            }
            
            catch
            {
                return View();
            }

        }


        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            UserDtl lObjUser = new UserDtl();
            List<SelectListItem> lObjUserTypes = new List<SelectListItem>();
            lObjUserTypes.Add(new SelectListItem
            {
                Text = "Administrator",
                Value = "Admin"
            });

            lObjUserTypes.Add(new SelectListItem
            {
                Text = "Regular User",
                Value = "Regular"
            });
            this.ViewBag.UserType = new SelectList(lObjUserTypes, "Value", "Text");
            if (lObjUser.Load(MasterMechUtil.Constr, id))
                return View(lObjUser);

            else
            {
                ModelState.AddModelError("", "User Doesn't Exists");
                return View(lObjUser);
            }
            //  lObjUser.msPwd = MasterMechUtil.Decrypt(lObjUser.msPwd);
        }

        // POST: User/Edit/5
        [HttpPost]


        public ActionResult Edit(UserDtl iObjUser)
        {
            List<SelectListItem> lObjUserTypes = new List<SelectListItem>();
            lObjUserTypes.Add(new SelectListItem
            {
                Text = "Administrator",
                Value = "Admin"
            });

            lObjUserTypes.Add(new SelectListItem
            {
                Text = "Regular User",
                Value = "Regular"
            });
            this.ViewBag.UserType = new SelectList(lObjUserTypes, "Value", "Text");
            try
            {
                if(iObjUser.Save(MasterMechUtil.Constr, MasterMechUtil.sUserID, false))
                    return View(iObjUser);

                else
                {
                    ModelState.AddModelError("","User Doesn't Exists");
                    return View(iObjUser);
                }
            }
            catch
            {
                return View();
            }
        }
        // GET: User/Delete/5


        public ActionResult Delete(string id)
        {
            UserDtl lObjUser = new UserDtl();
            if(lObjUser.Load(MasterMechUtil.Constr, id))
            return View(lObjUser);

            else
            {
                ModelState.AddModelError("", "User Already Deleted");
                return View(lObjUser);
            }
        }

        // POST: User/Delete/5
        [HttpPost]

        public ActionResult Delete(UserDtl lObjUser,string id)
        {
            lObjUser.Load(MasterMechUtil.Constr,id);
            if(lObjUser.Delete(MasterMechUtil.Constr,id))
            return View(lObjUser);

            else
            {
                ModelState.AddModelError("", "User Already Deleted");
                return View(lObjUser);
            }
        }


        public ActionResult ValidUser(string isUserID)
        {
            bool lbValidUser = false;
            UserDtl lObjUser = new UserDtl();

            lObjUser.msUserID = isUserID;

            lbValidUser = lObjUser.ValidUserID(MasterMechUtil.Constr);

            var lObjData = new
            {
                msValidUser = lbValidUser ? "Y" : "N"
            };
            return Json(lObjData, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SearchUserName(string isUserID)
        {
            UserDtl lObjUser = new UserDtl();
            List<UserDtl> mObjUsers = new List<UserDtl>();
            lObjUser.SearchUser(MasterMechUtil.Constr, isUserID, mObjUsers);
            if (mObjUsers.Count == 0)
                ModelState.AddModelError(""," " + "No Such User Found");
            else
                ModelState.AddModelError("", mObjUsers.Count.ToString() +" " + "Users Found.");

            ViewBag.SearchName = isUserID;
            return View("Index", mObjUsers);
        }


        //public ActionResult Login(UserDtl lObjUser)
        //{
        //      bool lbValidUser = false;
        //  //  UserDtl lObjUser = new UserDtl();

        //  //  lObjUser.msUserID = isUserID;

        //    lbValidUser = lObjUser.ValidLogin(MasterMechUtil.Constr);

        //    var lObjData = new
        //    {
        //        msValidUser = lbValidUser ? "Y" : "N"
        //    };
        //    return Json(lObjData, JsonRequestBehavior.AllowGet);

          //  return View();
        //}

    }
}
