using MasterMechLib;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MasterMechWeb.Controllers
{
  
    public class InvoiceController : Controller
    {
        static List<InvoiceItem> lObjDelInvoiceItemsList = new List<InvoiceItem>();
        // GET: Invoice
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Invoice lObjInvoice = new Invoice();
            List<Invoice> lObjListInvoice = lObjInvoice.ListInvoice(MasterMechUtil.Constr);
            return View(lObjListInvoice);
        }

        // GET: Invoice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            Invoice lObjInvoice = new Invoice();
            //dynamic mymodel = new ExpandoObject();
            //mymodel.Invoice = Create();
            //mymodel.Item = SelectListItem();
            //return View(mymodel);
            List<SelectListItem> lObjCustType = new List<SelectListItem>();
            lObjCustType.Add(
                new SelectListItem
                {
                    Text = "Individual",
                    Value= "IND"
                });
            lObjCustType.Add(
                new SelectListItem
                {
                    Text = "Bussiness",
                    Value = "BUS"
                });
            List<SelectListItem> lObjCustStatus = new List<SelectListItem>();
            lObjCustStatus.Add(
                new SelectListItem
                {
                    Text = "Active",
                    Value = "ACTIVE"
                });
            lObjCustStatus.Add(
                new SelectListItem
                {
                    Text = "Passive",
                    Value = "PASSIVE"
                });
            lObjCustStatus.Add(
                new SelectListItem
                {
                    Text = "Blocked",
                    Value = "BLOCKED"
                });
            List<SelectListItem> lObjServiceType = new List<SelectListItem>();
            lObjServiceType.Add(
                new SelectListItem
                {
                    Text = "Annual Servicing",
                    Value = "Annual Service"

                });
            lObjServiceType.Add(
                new SelectListItem
                {
                    Text = "Accident Repairing",
                    Value = "Accident Repair"
                });
            lObjServiceType.Add(
                new SelectListItem
                {
                    Text = "Normal Repairing",
                    Value = "Normal Repair"
                });
            this.ViewBag.CustType = new SelectList(lObjCustType, "Value", "Text");
            this.ViewBag.CustStatus = new SelectList(lObjCustStatus, "Value", "Text");
            this.ViewBag.ServiceType = new SelectList(lObjServiceType, "Value", "text");
            //Invoice lObjInv = TempData["InvoiceData"] as Invoice;
            return View(lObjInvoice);
            //ItemClass lObjInvcItm = TempData["Item"] as ItemClass;
            //  ItemClass lObjItem = TempData["Item"] as ItemClass;
        }

        // POST: Invoice/Create
        [HttpPost]
        public ActionResult Create(Invoice iObjInvc, string isAction)
        {
            Invoice lObjInvc = new Invoice();
            List<SelectListItem> lObjCustType = new List<SelectListItem>();
            lObjCustType.Add(
                new SelectListItem
                {
                    Text = "Individual",
                    Value = "IND"
                });
            lObjCustType.Add(
                new SelectListItem
                {
                    Text = "Bussiness",
                    Value = "BUS"
                });
            List<SelectListItem> lObjCustStatus = new List<SelectListItem>();
            lObjCustStatus.Add(
                new SelectListItem
                {
                    Text = "Active",
                    Value = "ACTIVE"
                });
            lObjCustStatus.Add(
                new SelectListItem
                {
                    Text = "Passive",
                    Value = "PASSIVE"
                });
            lObjCustStatus.Add(
                new SelectListItem
                {
                    Text = "Blocked",
                    Value = "BLOCKED"
                });
            List<SelectListItem> lObjServiceType = new List<SelectListItem>();
            lObjServiceType.Add(
                new SelectListItem
                {
                    Text = "Annual Servicing",
                    Value = "Annual Service"

                });
            lObjServiceType.Add(
                new SelectListItem
                {
                    Text = "Accident Repairing",
                    Value = "Accident Repair"
                });
            lObjServiceType.Add(
                new SelectListItem
                {
                    Text = "Normal Repairing",
                    Value = "Normal Repair"
                });
            this.ViewBag.CustType = new SelectList(lObjCustType, "Value", "Text");
            this.ViewBag.CustStatus = new SelectList(lObjCustStatus, "Value", "Text");
            this.ViewBag.ServiceType = new SelectList(lObjServiceType, "Value", "text");

            switch (isAction)
            {
                case "AddLine": iObjInvc.lObjInvoiceList.Add(iObjInvc.iObjItem);
                                return View(iObjInvc);
                case "Cancel":  iObjInvc.lObjInvoiceList.Remove(iObjInvc.iObjItem);
                                return View(iObjInvc);
                case "Delete":  int delItem = Convert.ToInt32(iObjInvc.mnRow);
                                iObjInvc.lObjInvoiceList.RemoveAt(delItem);
                                ModelState.Clear();
                                return View(iObjInvc);
                case "Update":  int UpdtItm = Convert.ToInt32(iObjInvc.mnRow);
                                iObjInvc.lObjInvoiceList[UpdtItm] = iObjInvc.iObjItem;
                                //iObjInvc.lObjInvoiceList.Add(iObjInvc.iObjItem);
                                ModelState.Clear();
                                return View(iObjInvc);
                case "Save":    
                                try
                                {
                                    if (ModelState.IsValid)
                                    {
                                        iObjInvc.Constr = MasterMechUtil.Constr;
                                        iObjInvc.UserID = MasterMechUtil.sUserID;

                                        iObjInvc.SaveInv();
                                        ModelState.Clear();
                                        return View(iObjInvc);
                                    }
                                    else
                                    {
                                        return View(iObjInvc);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                                //return View();
                    default:    return View();
            }
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(int id)
        {
            Invoice lObjIvc = new Invoice();
            lObjIvc.LoadInvcData(id);
            //int? InnvNum = lObjIvc.mnInvoiceSNo;
            //Session["Innvoice"] = InnvNum;
            List<SelectListItem> lObjCustType = new List<SelectListItem>();
            lObjCustType.Add(
                new SelectListItem
                {
                    Text = "Individual",
                    Value = "IND"
                });
            lObjCustType.Add(
                new SelectListItem
                {
                    Text = "Bussiness",
                    Value = "BUS"
                });
            List<SelectListItem> lObjCustStatus = new List<SelectListItem>();
            lObjCustStatus.Add(
                new SelectListItem
                {
                    Text = "Active",
                    Value = "ACTIVE"
                });
            lObjCustStatus.Add(
                new SelectListItem
                {
                    Text = "Passive",
                    Value = "PASSIVE"
                });
            lObjCustStatus.Add(
                new SelectListItem
                {
                    Text = "Blocked",
                    Value = "BLOCKED"
                });
            List<SelectListItem> lObjServiceType = new List<SelectListItem>();
            lObjServiceType.Add(
                new SelectListItem
                {
                    Text = "Annual Servicing",
                    Value = "Annual Service"

                });
            lObjServiceType.Add(
                new SelectListItem
                {
                    Text = "Accident Repairing",
                    Value = "Accident Repair"
                });
            lObjServiceType.Add(
                new SelectListItem
                {
                    Text = "Normal Repairing",
                    Value = "Normal Repair"
                });
            this.ViewBag.CustType = new SelectList(lObjCustType, "Value", "Text");
            this.ViewBag.CustStatus = new SelectList(lObjCustStatus, "Value", "Text");
            this.ViewBag.ServiceType = new SelectList(lObjServiceType, "Value", "text");

            if (lObjIvc.LoadInvcData(id))
                return View(lObjIvc);

            else
            {
                ModelState.AddModelError("", "Invoice Doesn't Exists");
                return View(lObjIvc);
            }

            //return View(lObjIvc);

        }

        // POST: Invoice/Edit/5
        [HttpPost]

        public ActionResult Edit(string isAction, Invoice lObjInvc,int id)
        {
            //Invoice lObjInv = new Invoice();
            //lObjInvc.LoadInvcData(id);
            //if (lObjInvc.LoadInvcData(id))
            //    return View(lObjInvc);

            //else
            //{
            //    ModelState.AddModelError("", "Invoice Doesn't Exists");
            //    return View(lObjInvc);
            //}

            List<SelectListItem> lObjServiceType = new List<SelectListItem>();
            lObjServiceType.Add(
                new SelectListItem
                {
                    Text = "Annual Servicing",
                    Value = "Annual Service"

                });
            lObjServiceType.Add(
                new SelectListItem
                {
                    Text = "Accident Repairing",
                    Value = "Accident Repair"
                });
            lObjServiceType.Add(
                new SelectListItem
                {
                    Text = "Normal Repairing",
                    Value = "Normal Repair"
                });
          
            
            this.ViewBag.ServiceType = new SelectList(lObjServiceType, "Value", "text");
                      switch (isAction)
                        {
                        case "AddLine":
                                        lObjInvc.lObjInvoiceList.Add(lObjInvc.iObjItem);
                                        lObjInvc.iObjItem = new InvoiceItem();
                                        ModelState.Clear();
                                        return View(lObjInvc);
                        case "Delete":
                                        int delIndex = Convert.ToInt32(lObjInvc.mnRow);
                                        if (lObjInvc.lObjInvoiceList[delIndex].InvoiceItemSNo != null)
                                        {
                                            lObjDelInvoiceItemsList.Add(lObjInvc.lObjInvoiceList[delIndex]);
                                        }
                                        lObjInvc.lObjInvoiceList.RemoveAt(delIndex);
                                         lObjInvc.iObjItem = new InvoiceItem();
                                         ModelState.Clear();
                                         return View(lObjInvc);
                        case "Update":
                                        int editIndex = Convert.ToInt32(lObjInvc.mnRow);
                                        lObjInvc.lObjInvoiceList[editIndex].Qty = lObjInvc.iObjItem.Qty;
                                        lObjInvc.lObjInvoiceList[editIndex].DiscountAmount = lObjInvc.iObjItem.DiscountAmount;
                                        lObjInvc.lObjInvoiceList[editIndex].CGSTAmount = lObjInvc.iObjItem.CGSTAmount;
                                        lObjInvc.lObjInvoiceList[editIndex].SGSTAmount = lObjInvc.iObjItem.SGSTAmount;
                                        lObjInvc.lObjInvoiceList[editIndex].IGSTAmount = lObjInvc.iObjItem.IGSTAmount;
                                        lObjInvc.lObjInvoiceList[editIndex].TotalAmount = lObjInvc.iObjItem.TotalAmount;
                                        lObjInvc.iObjItem = new InvoiceItem();
                                        ModelState.Clear();
                                        return View(lObjInvc);
                        case "Cancel":
                                         lObjInvc.lObjInvoiceList.Remove(lObjInvc.iObjItem);
                                         return View(lObjInvc);
                        case "Save":
                                         lObjInvc.iObjItem.Constr = MasterMechUtil.Constr;
                                         lObjInvc.iObjItem.UserID = MasterMechUtil.sUserID;
                                         int lsDelCount = lObjDelInvoiceItemsList.Count;
                                        if (lObjInvc.SaveInv())
                                        {
                                            for (int j = 0; j < lsDelCount; j++)
                                            {
                                                InvoiceItem lineItem = lObjDelInvoiceItemsList[j];
                                                lineItem.DeleteInvcItem();
                                            }
                                            lObjDelInvoiceItemsList.Clear();
                                            return RedirectToAction("Index");
                                        }
                                        else
                                        {
                                            ModelState.AddModelError("", "User Doesn't Exists");
                                            //return View(iObjUser);
                                            return RedirectToAction("Main", "Home");
                                        }
                                    default: return View();
                      }
        }


        // GET: Invoice/Delete/5
        public ActionResult Delete(int id)
        {
            Invoice lObjInvDel = new Invoice();
            if (lObjInvDel.LoadInvcData(id))
                return View(lObjInvDel);

            else
            {
                ModelState.AddModelError("","Invoice Already Deleted");
                return View(lObjInvDel);
            }
        }

        // POST: Invoice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Invoice lObjDelInvoice)
        {
            try
            {
                lObjDelInvoice.LoadInvcData(id);
                if (lObjDelInvoice.DeleteInv(MasterMechUtil.Constr))
                    return View(lObjDelInvoice);

                else
                {
                    ModelState.AddModelError("", "User Already Deleted");
                    return View(lObjDelInvoice);
                }
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public JsonResult FilterCustomers(string searchMobileNo)
        {
            List<Customer> lObjcustomerDetailsLst = new List<Customer>();
            Customer lObjCustomerDtl = new Customer();

            // Call your SearchCustomer method to retrieve data
            string id = "1111";
            if (lObjCustomerDtl.SearchCustomer(MasterMechUtil.Constr, lObjcustomerDetailsLst, searchMobileNo))
            {
                return Json(lObjcustomerDetailsLst, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null); // Return an empty result or handle the error appropriately
            }
        }
        [HttpGet]
        public JsonResult FilterItem(string searchItemDesc)
        {
            List<ItemClass> lObjItemsDtlList = new List<ItemClass>();
            ItemClass lObjItemsDtl = new ItemClass();

            if (lObjItemsDtl.SearchItem(searchItemDesc, lObjItemsDtlList))
            {
                return Json(lObjItemsDtlList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null); // Return an empty result or handle the error appropriately
            }
        }

    }
}
