using MasterMechLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MasterMechWeb.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Customer lObjCust = new Customer();
            List<Customer> lObjCustomerList = lObjCust.SearchCust(MasterMechUtil.Constr);
            return View(lObjCustomerList);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {

            Customer lObjCst = new Customer();
            if(lObjCst.LoadCust(MasterMechUtil.Constr,id))
            return View(lObjCst);
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Customer was Deleted");
                return View(lObjCst);
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<SelectListItem> lObjStatus = new List<SelectListItem>();
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Active",
                    Value = "ACTIVE"
                });
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Passive",
                    Value = "PASSIVE"
                });
            List<SelectListItem> lObjType = new List<SelectListItem>();
            lObjType.Add(
                new SelectListItem
                {
                    Text = "Individual",
                    Value = "IND"
                });
            lObjType.Add(
                new SelectListItem
                {
                    Text = "Bussiness",
                    Value = "BUS"
                });
            this.ViewBag.CustType = new SelectList(lObjType, "Value", "Text");
            this.ViewBag.CustStatus = new SelectList(lObjStatus, "Value", "Text");
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer lObjCst)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<SelectListItem> lObjStatus = new List<SelectListItem>();
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Active",
                    Value = "ACTIVE"
                });
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Passive",
                    Value = "PASSIVE"
                });
            List<SelectListItem> lObjType = new List<SelectListItem>();
            lObjType.Add(
                new SelectListItem
                {
                    Text = "Individual",
                    Value = "IND"
                });
            lObjType.Add(
                new SelectListItem
                {
                    Text = "Bussiness",
                    Value = "BUS"
                });
            this.ViewBag.CustType = new SelectList(lObjType, "Value", "Text");
            this.ViewBag.CustStatus = new SelectList(lObjStatus, "Value", "Text");
            try
            {
                if(lObjCst.SaveData(MasterMechUtil.Constr,true,MasterMechUtil.sUserID))
                         return RedirectToAction("Index");

                else
                {
                    ModelState.AddModelError("", "Unable to Save  Customer Data");
                    return View(lObjCst);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            List<SelectListItem> lObjStatus = new List<SelectListItem>();
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Active",
                    Value = "ACTIVE"
                });
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Passive",
                    Value = "PASSIVE"
                });
            List<SelectListItem> lObjType = new List<SelectListItem>();
            lObjType.Add(
                new SelectListItem
                {
                    Text = "Individual",
                    Value = "IND"
                });
            lObjType.Add(
                new SelectListItem
                {
                    Text = "Bussiness",
                    Value = "BUS"
                });
            this.ViewBag.CustType = new SelectList(lObjType, "Value", "Text");
            this.ViewBag.CustStatus = new SelectList(lObjStatus, "Value", "Text");
            Customer iObjCustmr = new Customer();
            if(iObjCustmr.LoadCust(MasterMechUtil.Constr, id))
            return View(iObjCustmr);
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Customer Doesn't Exists");
                return View(iObjCustmr);
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer iObjCustomerData)
        {
            List<SelectListItem> lObjStatus = new List<SelectListItem>();
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Active",
                    Value = "ACTIVE"
                });
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Passive",
                    Value = "PASSIVE"
                });
            List<SelectListItem> lObjType = new List<SelectListItem>();
            lObjType.Add(
                new SelectListItem
                {
                    Text = "Individual",
                    Value = "IND"
                });
            lObjType.Add(
                new SelectListItem
                {
                    Text = "Bussiness",
                    Value = "BUS"
                });
            this.ViewBag.CustType = new SelectList(lObjType, "Value", "Text");
            this.ViewBag.CustStatus = new SelectList(lObjStatus, "Value", "Text");
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                if(iObjCustomerData.SaveData(MasterMechUtil.Constr,false,MasterMechUtil.sUserID))
                    return RedirectToAction("Index");

                else
                {
                    ModelState.AddModelError("", "Unable to Upadate Customer");
                    return View(iObjCustomerData);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }


            Customer iObjCustomer = new Customer();
            if (iObjCustomer.LoadCust(MasterMechUtil.Constr, id))
                return View(iObjCustomer);
           
            else
            {
                ModelState.AddModelError("", "Customer Already Deleted");
                return View(iObjCustomer);
            }

        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer iObjCust)
        {
            //if (Session["UserID"] == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            iObjCust.LoadCust(MasterMechUtil.Constr, id);
            try
            {
                if (iObjCust.DeleteCust(MasterMechUtil.Constr, id))

                // TODO: Add delete logic here

                return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("", "Unable to Delete Customer");
                    return View(iObjCust);
                }
            }
            catch
            {
                return View();
            }
        }

        public JsonResult Select(int id)
        {

            Customer oObjCustData = new Customer();
            Invoice lObjInv = new Invoice();

            try
            {
                if (oObjCustData.LoadCust(MasterMechUtil.Constr, id))
                {
                    return Json(oObjCustData, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public JsonResult CustomersData(int inCustNo)
        {
            Customer lObjCustomerDtl = new Customer();

            // Call your SearchCustomer method to retrieve data
            //string id = "1111";
            if (lObjCustomerDtl.LoadCust(MasterMechUtil.Constr, inCustNo))
            {
                return Json(lObjCustomerDtl, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null); // Return an empty result or handle the error appropriately
            }
        }

        public ActionResult SearchCustomerName(string isCustMobNo)
        {
            Customer lObjCustomer = new Customer();
            List<Customer> mObjCustomer = new List<Customer>();
            lObjCustomer.SearchCustomer(MasterMechUtil.Constr, mObjCustomer, isCustMobNo);
            if (mObjCustomer.Count == 0)
                ModelState.AddModelError("", " " + "No Such Customer Found");
            else
                ModelState.AddModelError("", mObjCustomer.Count.ToString() + " " + "Customers Found.");

            ViewBag.SearchMobNo = isCustMobNo;
            return View("Index", mObjCustomer);
        }
    }
}
