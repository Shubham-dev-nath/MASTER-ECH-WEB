using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MasterMechLib;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using System.Deployment.Internal;
using System.CodeDom;

namespace MasterMechWeb.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ItemClass lObjItem = new ItemClass();
            List<ItemClass> lObjListItem = lObjItem.ListItem(MasterMechUtil.Constr);
            return View(lObjListItem);
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            ItemClass lObjDetail = new ItemClass();
            if (lObjDetail.LoadItm(MasterMechUtil.Constr, id))
                return View(lObjDetail);
            else
            {
                ModelState.AddModelError("", "Item was Deleted");
                return View(lObjDetail);
            }
            //return View(lObjDetail);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            List<SelectListItem> lObjListType = new List<SelectListItem>();
            lObjListType.Add(
                new SelectListItem
                {
                    Text = "Item Parts",
                    Value = "PARTS"
                });
            lObjListType.Add(
                new SelectListItem
                {
                    Text = "Item Labour",
                    Value = "LABOUR"
                });
            List<SelectListItem> lObjListCatg = new List<SelectListItem>();
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Engine",
                    Value = "ENGN"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Body",
                    Value = "BODY"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Drive",
                    Value = "DRIVE"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Electrical",
                    Value = "ELECT"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Frame",
                    Value = "FRAME"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Suspension",
                    Value = "SUSPN"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Brake",
                    Value = "BRAKE"
                });
            List<SelectListItem> lObjStatus = new List<SelectListItem>();
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Active",
                    Value = "ACT"
                });
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Suspension",
                    Value = "SUSP"
                });
            this.ViewBag.ItemCatg = new SelectList(lObjListCatg, "Value", "Text");
            this.ViewBag.ItemType = new SelectList(lObjListType, "Value", "Text");
            this.ViewBag.ItemStatus = new SelectList(lObjStatus, "Value", "Text");
            ItemClass lObjUser = new ItemClass();
            return View(lObjUser);
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(ItemClass iObjItem)
        {
            List<SelectListItem> lObjListType = new List<SelectListItem>();
            lObjListType.Add(
                new SelectListItem
                {
                    Text = "Item Parts",
                    Value = "PARTS"
                });

            lObjListType.Add(new SelectListItem
            {
                Text = "Item Labour",
                Value = "LABOUR"
            });
            List<SelectListItem> lObjListCatg = new List<SelectListItem>();
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Engine",
                    Value = "ENGN"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Body",
                    Value = "BODY"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Drive",
                    Value = "DRIVE"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Electrical",
                    Value = "ELECT"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Frame",
                    Value = "FRAME"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Suspension",
                    Value = "SUSPN"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Brake",
                    Value = "BRAKE"
                });
            List<SelectListItem> lObjStatus = new List<SelectListItem>();
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Active",
                    Value = "ACT"
                });
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Suspension",
                    Value = "SUSP"
                });
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        // TODO: Add insert logic here
                        if (iObjItem.SaveItem(MasterMechUtil.Constr, MasterMechUtil.sUserID, true))
                            return View(iObjItem);

                        else
                        {
                            ModelState.AddModelError("", "Unable to Create a New Item");
                            return View(iObjItem);
                        }
                    }
                    catch
                    {
                        return View();
                    }
                }
                this.ViewBag.ItemCatg = new SelectList(lObjListCatg, "Value", "Text");
                this.ViewBag.ItemType = new SelectList(lObjListType, "Value", "Text");
                this.ViewBag.ItemStatus = new SelectList(lObjStatus, "Value", "Text");
                return View(iObjItem);
            }
            catch
            {
                return View();
            }
        }
          
        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            ItemClass lObjItemValues = new ItemClass();
            lObjItemValues.LoadItm(MasterMechUtil.Constr, id);
                List<SelectListItem> lObjListType = new List<SelectListItem>();
                lObjListType.Add(
                    new SelectListItem
                    {
                        Text = "Item Parts",
                        Value = "PARTS"
                    });

                lObjListType.Add(new SelectListItem
                {
                    Text = "Item Labour",
                    Value = "LABOUR"
                });
                List<SelectListItem> lObjListCatg = new List<SelectListItem>();
                lObjListCatg.Add(
                    new SelectListItem
                    {
                        Text = "Engine",
                        Value = "ENGN"
                    });
                lObjListCatg.Add(
                    new SelectListItem
                    {
                        Text = "Body",
                        Value = "BODY"
                    });
                lObjListCatg.Add(
                    new SelectListItem
                    {
                        Text = "Drive",
                        Value = "DRIVE"
                    });
                lObjListCatg.Add(
                    new SelectListItem
                    {
                        Text = "Electrical",
                        Value = "ELECT"
                    });
                lObjListCatg.Add(
                    new SelectListItem
                    {
                        Text = "Frame",
                        Value = "FRAME"
                    });
                lObjListCatg.Add(
                    new SelectListItem
                    {
                        Text = "Suspension",
                        Value = "SUSPN"
                    });
                lObjListCatg.Add(
                    new SelectListItem
                    {
                        Text = "Brake",
                        Value = "BRAKE"
                    });
            List<SelectListItem> lObjListStatus = new List<SelectListItem>();
            lObjListStatus.Add(
                new SelectListItem
                {
                    Text = "Active",
                    Value = "ACT "
                });

            lObjListStatus.Add(new SelectListItem
            {
                Text = "Suspension",
                Value = "SUSP"
            });
            this.ViewBag.ItemCatg = new SelectList(lObjListCatg, "Value", "Text");
                this.ViewBag.ItemType = new SelectList(lObjListType, "Value", "Text");
                this.ViewBag.ItemStatus = new SelectList(lObjListStatus, "Value", "Text");
            if (lObjItemValues.LoadItm(MasterMechUtil.Constr, id))
                return View(lObjItemValues);

            else
            {
                ModelState.AddModelError("", "Item Doesn't Exists");
                return View(lObjItemValues);
            }
            // ItemClass iObjItm = new ItemClass();
           // return View(lObjItemValues);
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(ItemClass iObjItmData)
        {
            List<SelectListItem> lObjListType = new List<SelectListItem>();
            lObjListType.Add(
                new SelectListItem
                {
                    Text = "Item Parts",
                    Value = "PARTS"
                });

            lObjListType.Add(new SelectListItem
            {
                Text = "Item Labour",
                Value = "LABOUR"
            });
            List<SelectListItem> lObjListCatg = new List<SelectListItem>();
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Engine",
                    Value = "ENGN"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Body",
                    Value = "BODY"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Drive",
                    Value = "DRIVE"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Electrical",
                    Value = "ELECT"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Frame",
                    Value = "FRAME"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Suspension",
                    Value = "SUSPN"
                });
            lObjListCatg.Add(
                new SelectListItem
                {
                    Text = "Brake",
                    Value = "BRAKE"
                });
            List<SelectListItem> lObjStatus = new List<SelectListItem>();
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Active",
                    Value = "ACT"
                });
            lObjStatus.Add(
                new SelectListItem
                {
                    Text = "Suspension",
                    Value = "SUSP"
                });
            this.ViewBag.ItemCatg = new SelectList(lObjListCatg, "Value", "Text");
            this.ViewBag.ItemType = new SelectList(lObjListType, "Value", "Text");
            this.ViewBag.ItemStatus = new SelectList(lObjStatus, "Value", "Text");
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (iObjItmData.SaveItem(MasterMechUtil.Constr, MasterMechUtil.sUserID, false))
                            return View(iObjItmData);

                        else
                        {
                            ModelState.AddModelError("", "Unable to Update an Item");
                            return View(iObjItmData);
                        }
                    }
                    catch
                    {
                        return View();
                    }
                }
                return View();
              
                // TODO: Add update logic here
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            ItemClass lObjItemDel = new ItemClass();
            if(lObjItemDel.LoadItm(MasterMechLib.MasterMechUtil.Constr, id))
            return View(lObjItemDel);

            else
            {
                ModelState.AddModelError("", "Item Already Deleted");
                return View(lObjItemDel);
            }
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(ItemClass lObjItemDelete,int id)
        {
            try
            {
                if(lObjItemDelete.DeleteItm(id, MasterMechUtil.Constr))
                    return RedirectToAction("Index");
                // TODO: Add delete logic here

                else
                {
                    ModelState.AddModelError("", "Unable to Delete Item");
                    return View(lObjItemDelete);
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchItemData(string isItemDesc)
        {
            ItemClass lObjItem = new ItemClass();
            List<ItemClass> mObjItemList = new List<ItemClass>();
            lObjItem.SearchItem(isItemDesc, mObjItemList);
            if (mObjItemList.Count == 0)
                ModelState.AddModelError("", " " + "No Such Item Found");
            else
                ModelState.AddModelError("", mObjItemList.Count.ToString() + " " + "Items Found.");

            ViewBag.SearchDesc = isItemDesc;
            return View("Index", mObjItemList);
        }
        //public ActionResult Select(int id)
        //{
        //    ItemClass lObjItem = new ItemClass();
        //    lObjItem.LoadItm(MasterMechUtil.Constr, id);
        //    TempData["Item"] = lObjItem;
        //    TempData["SelectItem"] = "Y";
        //    return RedirectToAction("Create", "Invoice");

        //}


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


        public JsonResult SelectItem(int id)
        {
            ItemClass oObjItemData = new ItemClass();
            Invoice lObjInv = new Invoice();
            try
            {
                if (oObjItemData.LoadItm(MasterMechUtil.Constr, id))
                {
                    return Json(oObjItemData, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
