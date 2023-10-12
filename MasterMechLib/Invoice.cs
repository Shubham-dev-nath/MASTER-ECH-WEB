using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Diagnostics;

namespace MasterMechLib
{
    public class Invoice
    {
        [Display(Name = "Invoice Number ")]
        public String InvoiceSNo { get; set; }

        [Display(Name = "Invoice No ")]
        public int? mnInvoiceSNo { get; set; }
        [Display(Name = "Invoice Date")]
        public DateTime mdInvoiceDate { get; set; }
        [Display(Name = "InVoice Status ")]
        public string msInvoiceSts { get; set; }
        [Display(Name = "Customer Number ")]
        public int? mnCustNo { get; set; }
        [Display(Name = "Customer First Name")]
        public string msCustFName { get; set; }
        [Display(Name = "Customer Last Name")]
        public string msCustLName { get; set; }
        [Display(Name = "Customer Mobile Number")]
        public string msCustMobNo { get; set; }
        [Display(Name = "Customer EmailID")]
        public string msCustEmail { get; set; }
        [Display(Name ="Customer Status")]
        public string msCustSts { get; set; }
        [Display(Name = "Customer Type")]
        public string msCustType { get; set; }
        [Display(Name = "Customer Street Address")]
        public string msCustStAddr { get; set; }
        [Display(Name = "Customer Area Address")]
        public string msCustArAddr { get; set; }
        [Display(Name ="City")]
        public string msCustCity { get; set; }
        [Display(Name = "State")]
        public string msCustState { get; set; }
        [Display(Name = "PinCode")]
        public string msCustPinCode { get; set; }
        [Display(Name = "Country")]
        public string msCustCountry { get; set; }
        [Display(Name = "GSTNo")]
        public string msCustGSTNo { get; set; }
        [Display(Name = "Last Visit")]
        public DateTime? mdCustlLastVisit { get; set; }
        [Display(Name = "Customer Remarks")]
        public string msCustRemarks { get; set; }
        [Display(Name = "Vehicle RegNo")]
        public string msVehicleRegNo { get; set; }
        [Display(Name = "Vehicle Model")]
        public string msVehicleModel { get; set; }
        [Display(Name = "Chassis No")]
        public string msChassisNo { get; set; }
        [Display(Name = "Engine No")]
        public string msEngineNo { get; set; }
        public Customer mObjCustData { get; set; }
        [Display(Name = "Mileage")]
        public int? mnMileage { get; set; }
        [Display(Name = "Service Type")]
        public string msServiceType { get; set; }
        [Display(Name = "Service Associate Name")]
        public string msServiceAssoName { get; set; }
        [Display(Name = "Service Ass Mobile No")]
        public string msServiceAssoMobNo { get; set; }
        [Display(Name = "Parts Total")]
        public double mnPartsTotal { get; set; }
        [Display(Name = "Labour Total")]
        public double mnLabourTotal { get; set; }
        [Display(Name = "Parts CGST Total")]
        public double mnPartsCGSTTotal { get; set; }
        [Display(Name = "Labour CGST Total")]
        public double mnLabourCGSTTotal { get; set; }
        [Display(Name = "Parts SGST Total")]
        public double mnPartsSGSTTotal { get; set; }
        [Display(Name = "Labour SGST Total")]
        public double mnLabourSGSTTotal { get; set; }
        [Display(Name = "Parts IGST Total")]
        public double mnPartsIGSTTotal { get; set; }
        [Display(Name = "Labour IGST Total")]
        public double mnLabourIGSTTotal { get; set; }
        [Display(Name = "Total SGST")]
        public double mnTotalSGST { get; set; }
        [Display(Name = "Total CGST")]
        public double mnTotalCGST { get; set; }
        [Display(Name = "Total IGST")]
        public double mnTotalIGST { get; set; }
        [Display(Name = "Total Tax")]
        public double mnTotalTax { get; set; }
        [Display(Name = "Total Amount")]
        public double mnTotalAmount { get; set; }
        [Display(Name = "Grand Total")]
        public double mnGrandTotal { get; set; }
        [Display(Name = "Discount Amount")]
        public double mnDiscountAmount { get; set; }
        [Display(Name = "Invoice Total")]
        public double mnInvoiceTotal { get; set; }
        [Display(Name = "Invoice Remarks")]
        public string msInvoiceRemarks { get; set; }
        [Display(Name = "Created")]
        public DateTime? mdCreated { get; set; }
        [Display(Name = "Created By")]
        public string msCreatedBy { get; set; }
        [Display(Name = "Modified")]
        public DateTime? mdModified { get; set; }
        [Display(Name = "Modified By")]
        public string msModifiedBy { get; set; }
        [Display(Name = "Deleted")]
        public char? mcDeleted { get; set; }
        [Display(Name = "Deleted ON")]
        public DateTime? mdDeletedOn { get; set; }
        [Display(Name = "Deleted By")]
        public string msDeletedBy { get; set; }
        [Display(Name = "Gross Amount")]
        public string mnGrossAmount { get; set; }
        public List<InvoiceItem> lObjInvoiceList { get; set; }

        //InvoiceItem lObjInvoiceItm = new InvoiceItem() { get; set; };
        public string Constr { get; set; }
        public string UserID { get; set; }
        public List<Customer> lObjListCust { get; set; }
        public InvoiceItem iObjItem { get; set; }

        public int ? mnRow { get; set; }

        // public ItemClass lObjItem { get; set; }

        //public int? ItemNo { get; set; }
        //public string ItemDesc { get; set; }
        //public string ItemType { get; set; }
        //public string ItemCatg { get; set; }
        //public double? ItemPrice { get; set; }
        //public string ItemUOM { get; set; }
        //public string ItemSts { get; set; }
        //public double? CGSTRate { get; set; }
        //public double? SGSTRate { get; set; }
        //public double? IGSTRate { get; set; }
        //public string UPCCode { get; set; }
        //public string HSNCode { get; set; }
        //public string SACCode { get; set; }
        //public double? Qty { get; set; }
        //public double? SGSTAmount { get; set; }
        //public double? CGSTAmount { get; set; }
        //public double? IGSTAmount { get; set; }
        //public double? DiscountAmount { get; set; }
        //public double? TotalAmount { get; set; }

        //Note-Customer Object was needed to be created to call the customer properties whereas i have created the lsit which was not 
        // not required and customer fields are created........!!

        public Invoice()
        {
            mObjCustData = new Customer();
            lObjInvoiceList = new List<InvoiceItem>();
        }

        //public Invoice(int inCustNo)
        //{
        //    mnCustNo = inCustNo;
        //}

        // public static string Constr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MasterMech;Data Source=MASOOD\\SQLEXPRESSMSD";

        public Invoice(string isConstr, string isUserID)
        {
            this.Constr = isConstr;
            this.UserID = isUserID;
            this.mObjCustData = new Customer();
            this.lObjInvoiceList = new List<InvoiceItem>();
        }

        public Invoice(string inCustNo, string isCustFName, string isCustLName, string isCustMobNo, string isCustEmail, string isCustSts,
            string isCustType, string isCustStAddr, string isCustArAddr, string isCustCity, string isCustState, string isCustPinCode,
            string isCustCountry, string isCustGSTNo, string idCustlLastVisit, string isCustRemarks)
        {
            mnCustNo = Convert.ToInt32(inCustNo);
            msCustFName = isCustFName;
            msCustLName = isCustLName;
            msCustMobNo = isCustMobNo;
            msCustEmail = isCustEmail;
            msCustSts = isCustSts;
            msCustType = isCustType;
            msCustStAddr = isCustStAddr;
            msCustArAddr = isCustArAddr;
            msCustCity = isCustCity;
            msCustState = isCustState;
            msCustPinCode = isCustPinCode;
            msCustCountry = isCustCountry;
            msCustGSTNo = isCustGSTNo;
            mdCustlLastVisit = Convert.ToDateTime(idCustlLastVisit);
            msCustRemarks = isCustRemarks;
        }

        public Invoice(int? inInvoiceSNo, DateTime idInvoiceDate, string isInvoiceSts,
            int? inCustNo, string isCustFName, string isCustLName, string isCustMobNo, string isCustEmail,
            string isCustSts, string isCustType, string isCustStAddr, string isCustArAddr, string isCustCity,
            string isCustState, string isCustPinCode, string isCustCountry, string isCustGSTNo, DateTime? idCustlLastVisit,
            string isCustRemarks, string isVehicleRegNo, string isVehicleModel, string isChassisNo, string isEngineNo,
             int? inMileage, string isServiceType, string isServiceAssoName, string isServiceAssoMobNo,
            double inPartsTotal, double inLabourTotal, double inPartsCGSTTotal, double inLabourCGSTTotal, double inPartsSGSTTotal,
            double inLabourSGSTTotal, double inPartsIGSTTotal, double inLabourIGSTTotal, double inTotalSGST, double inTotalCGST,
            double inTotalIGST, double inTotalTax, double inTotalAmount, double inGrandTotal, double inDiscountAmount,
            double inInvoiceTotal, string isInvoiceRemarks, DateTime idCreated, string isCreatedBy, DateTime idModified,
            string isModifiedBy)
        {
            this.mnInvoiceSNo = inInvoiceSNo;
            this.mdInvoiceDate = idInvoiceDate;
            this.msInvoiceSts = isInvoiceSts;
            this.mnCustNo = inCustNo;
            this.msCustFName = isCustFName;
            this.msCustLName = isCustLName;
            this.msCustMobNo = isCustMobNo;
            this.msCustEmail = isCustEmail;
            this.msCustSts = isCustSts;
            this.msCustType = isCustType;
            this.msCustStAddr = isCustStAddr;
            this.msCustArAddr = isCustArAddr;
            this.msCustCity = isCustCity;
            this.msCustState = isCustState;
            this.msCustPinCode = isCustPinCode;
            this.msCustCountry = isCustCountry;
            this.msCustGSTNo = isCustGSTNo;
            this.mdCustlLastVisit = idCustlLastVisit;
            this.msCustRemarks = isCustRemarks;
            this.msVehicleRegNo = isVehicleRegNo;
            this.msVehicleModel = isVehicleModel;
            this.msChassisNo = isChassisNo;
            this.msEngineNo = isEngineNo;

            this.mnMileage = inMileage;
            this.msServiceType = isServiceType;
            this.msServiceAssoName = isServiceAssoName;
            this.msServiceAssoMobNo = isServiceAssoMobNo;
            this.mnPartsTotal = inPartsTotal;
            this.mnLabourTotal = inLabourTotal;
            this.mnPartsCGSTTotal = inPartsCGSTTotal;
            this.mnLabourCGSTTotal = inLabourCGSTTotal;
            this.mnPartsSGSTTotal = inPartsSGSTTotal;
            this.mnLabourSGSTTotal = inLabourSGSTTotal;
            this.mnPartsIGSTTotal = inPartsIGSTTotal;
            this.mnLabourIGSTTotal = inLabourIGSTTotal;
            this.mnTotalSGST = inTotalSGST;
            this.mnTotalCGST = inTotalCGST;
            this.mnTotalIGST = inTotalIGST;
            this.mnTotalTax = inTotalTax;
            this.mnTotalAmount = inTotalAmount;
            this.mnGrandTotal = inGrandTotal;
            this.mnDiscountAmount = inDiscountAmount;
            this.mnInvoiceTotal = inInvoiceTotal;
            this.msInvoiceRemarks = isInvoiceRemarks;
            this.mdCreated = idCreated;
            this.msCreatedBy = isCreatedBy;
            this.mdModified = idModified;
            this.msModifiedBy = isModifiedBy;
        }

        public void ComboBoxAdd(List<string> lObjInvcSts, List<string> lObjInvcType, List<string> lObjInvcSrvc)
        {
            lObjInvcSts.Add("ACTIVE");
            lObjInvcSts.Add("PASSIVE");
            lObjInvcSts.Add("BLOCKED");
            lObjInvcType.Add("IND");
            lObjInvcType.Add("BUS");
            lObjInvcSrvc.Add("Annual Service");
            lObjInvcSrvc.Add("Accident Repair");
            lObjInvcSrvc.Add("Normal Repair");
        }


        public bool LoadInvoice(string Constr, string isMobile)
        {
            string lsQryLdInvc = " ";
            try
            {
                using (SqlConnection lObjConne = new SqlConnection(Constr))
                {
                    lsQryLdInvc = "SELECT InvoiceSNo,InvoiceDate,InvoiceSts,CustNo,CustFName,CustLName,CustMobNo," +
                        "CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity,CustState,CustPinCode,CustCountry," +
                        "CustGSTNo,CustlLastVisit,CustRemarks,VehicleRegNo,VehicleModel,ChassisNo,EngineNo,Mileage," +
                        "ServiceType,ServiceAssoName,ServiceAssoMobNo,PartsTotal,LabourTotal,PartsCGSTTotal,LabourCGSTTotal," +
                        "PartsSGSTTotal,LabourSGSTTotal,PartsIGSTTotal,LabourIGSTTotal,TotalSGST,TotalCGST,TotalIGST," +
                        "TotalTax,TotalAmount,GrandTotal,DiscountAmount,InvoiceTotal,InvoiceRemarks,Created,CreatedBy,Modified," +
                        "ModifiedBy From  [Invoice"+ MasterMechUtil.sFY + "] Where InvoiceSNo=@SNo  And Deleted = 'N'";
                     
                    SqlCommand lObjCmd = new SqlCommand(lsQryLdInvc, lObjConne);
                    lObjCmd.CommandType = CommandType.Text;
                    lObjCmd.Parameters.AddWithValue("@SNo", SqlDbType.Int).Value = mnInvoiceSNo;
                    lObjConne.Open();


                    using (SqlDataReader lObjRd = lObjCmd.ExecuteReader())
                    {
                        if (lObjRd.HasRows)
                        {
                            while (lObjRd.Read())
                            {
                                mnInvoiceSNo = Convert.ToInt32(lObjRd["InvoiceSNo"]);
                                mdInvoiceDate = Convert.ToDateTime(lObjRd["InvoiceDate"]);
                                msInvoiceSts = lObjRd["InvoiceSts"].ToString();
                                mnCustNo = Convert.ToInt32(lObjRd["CustNo"]);
                                msCustFName = lObjRd["CustFName"].ToString();
                                msCustLName = lObjRd["CustLName"].ToString();
                                msCustMobNo = lObjRd["CustMobNo"].ToString();
                                msCustEmail = lObjRd["CustEmail"].ToString();
                                msCustSts = lObjRd["CustSts"].ToString();
                                msCustType = DBNull.Value.Equals(lObjRd["CustType"]) ? null : lObjRd["CustType"].ToString();
                                msCustStAddr = DBNull.Value.Equals(lObjRd["CustStAddr"]) ? null : lObjRd["CustStAddr"].ToString();
                                msCustArAddr = DBNull.Value.Equals(lObjRd["CustArAddr"]) ? null : lObjRd["CustArAddr"].ToString();
                                msCustCity = DBNull.Value.Equals(lObjRd["CustCity"]) ? null : lObjRd["CustCity"].ToString();
                                msCustState = DBNull.Value.Equals(lObjRd["CustState"]) ? null : lObjRd["CustState"].ToString();
                                msCustPinCode = lObjRd["CustPinCode"].ToString();
                                msCustCountry = DBNull.Value.Equals(lObjRd["CustCountry"]) ? null : lObjRd["CustCountry"].ToString();
                                msCustGSTNo = DBNull.Value.Equals(lObjRd["CustGSTNo"]) ? null : lObjRd["CustGSTNo"].ToString();
                                mdCustlLastVisit = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["CustlLastVisit"]) ? null : lObjRd["CustlLastVisit"]);
                                msCustRemarks = DBNull.Value.Equals(lObjRd["CustRemarks"]) ? null : lObjRd["CustRemarks"].ToString();
                                msVehicleRegNo = DBNull.Value.Equals(lObjRd["VehicleRegNo"]) ? null : lObjRd["VehicleRegNo"].ToString();
                                msVehicleModel = DBNull.Value.Equals(lObjRd["VehicleModel"]) ? null : lObjRd["VehicleModel"].ToString();
                                msChassisNo = DBNull.Value.Equals(lObjRd["ChassisNo"]) ? null : lObjRd["ChassisNo"].ToString();
                                msEngineNo = DBNull.Value.Equals(lObjRd["EngineNo"]) ? null : lObjRd["EngineNo"].ToString();
                                mnMileage = Convert.ToInt32(DBNull.Value.Equals(lObjRd["Mileage"]) ? null : lObjRd["Mileage"]);
                                msServiceType = DBNull.Value.Equals(lObjRd["ServiceType"]) ? null : lObjRd["ServiceType"].ToString();
                                msServiceAssoName = DBNull.Value.Equals(lObjRd["ServiceAssoName"]) ? null : lObjRd["ServiceAssoName"].ToString();
                                msServiceAssoMobNo = DBNull.Value.Equals(lObjRd["ServiceAssoMobNo"]) ? null : lObjRd["ServiceAssoMobNo"].ToString();
                                mnPartsTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsTotal"]) ? null : lObjRd["PartsTotal"]);
                                mnLabourTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourTotal"]) ? null : lObjRd["LabourTotal"]);
                                mnPartsCGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsCGSTTotal"]) ? null : lObjRd["PartsCGSTTotal"]);
                                mnLabourCGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourCGSTTotal"]) ? null : lObjRd["LabourCGSTTotal"]);
                                mnPartsSGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsSGSTTotal"]) ? null : lObjRd["PartsSGSTTotal"]);
                                mnLabourSGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourSGSTTotal"]) ? null : lObjRd["LabourSGSTTotal"]);
                                mnPartsIGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsIGSTTotal"]) ? null : lObjRd["PartsIGSTTotal"]);
                                mnLabourIGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourIGSTTotal"]) ? null : lObjRd["LabourIGSTTotal"]);
                                mnTotalSGST = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalSGST"]) ? null : lObjRd["TotalSGST"]);
                                mnTotalCGST = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalCGST"]) ? null : lObjRd["TotalCGST"]);
                                mnTotalIGST = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalIGST"]) ? null : lObjRd["TotalIGST"]);
                                mnTotalTax = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalTax"]) ? null : lObjRd["TotalTax"]);
                                mnTotalAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalAmount"]) ? null : lObjRd["TotalAmount"]);
                                mnGrandTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["GrandTotal"]) ? null : lObjRd["GrandTotal"]);
                                mnDiscountAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRd["DiscountAmount"]) ? null : lObjRd["DiscountAmount"]);
                                mnInvoiceTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["InvoiceTotal"]) ? null : lObjRd["InvoiceTotal"]);
                                msInvoiceRemarks = DBNull.Value.Equals(lObjRd["InvoiceRemarks"]) ? null : lObjRd["InvoiceRemarks"].ToString();
                                mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["Created"]) ? null : lObjRd["Created"]);
                                msCreatedBy = DBNull.Value.Equals(lObjRd["CreatedBy"]) ? null : lObjRd["CreatedBy"].ToString();
                                mdModified = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["Modified"]) ? null : lObjRd["Modified"]);
                                msModifiedBy = DBNull.Value.Equals(lObjRd["ModifiedBy"]) ? null : lObjRd["ModifiedBy"].ToString();
                            }
                        }
                    }
                }
               
            }
            catch (SqlException ex)
            {
                return false;
            }
             InvoiceItem lObjItemInvc = new InvoiceItem();
             lObjItemInvc.SrchItem(mnInvoiceSNo.ToString(), lObjInvoiceList);
            return true;
        }


        // Delete the Invoice with the Invoice SerialNumber;

        public bool DeleteInvoice(string Constr)
        {

            string lsQryDel = " ";

            using (SqlConnection lObjCnn = new SqlConnection(Constr))
            {
                SqlCommand lObjdelCmd = new SqlCommand();
                lObjdelCmd.Connection = lObjCnn;
                
                lObjCnn.Open();

                SqlTransaction lObjTrans;
                lObjTrans = lObjCnn.BeginTransaction("InvoiceTransaction");
                lObjdelCmd.Transaction = lObjTrans;

                try
                {
                    lsQryDel = "Update [Invoice" + MasterMechUtil.sFY + "] Set Deleted='Y',DeletedOn=@DeletedOn," +
                        "DeletedBy=@DeletedBy,InvoiceSts='DELETED' Where InvoiceSNo=@InvoiceSNo";

                    lObjdelCmd.CommandText = lsQryDel;
                    lObjdelCmd.CommandType = CommandType.Text;
                    lObjdelCmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.Int).Value = InvoiceSNo;
                    lObjdelCmd.Parameters.AddWithValue("@DeletedOn", SqlDbType.DateTime).Value = DateTime.Now;
                    lObjdelCmd.Parameters.AddWithValue("@DeletedBy", SqlDbType.VarChar).Value = UserID;

                    lObjdelCmd.ExecuteNonQuery();

                    foreach (InvoiceItem ItemList in lObjInvoiceList) // Getting individual InvoiceItem or Line Item in InvoiceItems List and saving the Details in DB InvoiceItem Table
                    {
                        if (!ItemList.DeleteInvcItems(lObjdelCmd)) // if Unsuccesful delete invoice item or Line item,Transaction is Rollback and return to form
                        {
                            lObjTrans.Rollback();
                            lObjCnn.Close();
                            return false;
                        }
                        lObjTrans.Commit();
                        lObjCnn.Close();
                        return true;
                    }
                    //After successful deletion of Invoice Item in the respective table,transaction is commited to db.
                    
                }
                catch (SqlException ex)
                {
                    lObjTrans.Rollback();
                    lObjCnn.Close();
                    return false;
                }
                lObjTrans.Commit();
                lObjCnn.Close();
                return true;
            }
        }


        public bool DeleteInv(string Constr)
        {

            string lsQryDel = " ";

            using (SqlConnection lObjCnn = new SqlConnection(Constr))
            {
                SqlCommand lObjdelCmd = new SqlCommand();
                lObjdelCmd.Connection = lObjCnn;

                lObjCnn.Open();

                SqlTransaction lObjTrans;
                lObjTrans = lObjCnn.BeginTransaction("InvoiceTransaction");
                lObjdelCmd.Transaction = lObjTrans;

                try
                {
                    lsQryDel = "Update [Invoice" + MasterMechUtil.sFY + "] Set Deleted='Y',DeletedOn=@DeletedOn," +
                        "DeletedBy=@DeletedBy,InvoiceSts='DELETED' Where InvoiceSNo=@InvoiceSNo";

                    lObjdelCmd.CommandText = lsQryDel;
                    lObjdelCmd.CommandType = CommandType.Text;
                    lObjdelCmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.Int).Value = mnInvoiceSNo;
                    lObjdelCmd.Parameters.AddWithValue("@DeletedOn", SqlDbType.DateTime).Value = DateTime.Now;
                    lObjdelCmd.Parameters.AddWithValue("@DeletedBy", SqlDbType.VarChar).Value = MasterMechUtil.sUserID;

                    lObjdelCmd.ExecuteNonQuery();

                    foreach (InvoiceItem ItemList in lObjInvoiceList) // Getting individual InvoiceItem or Line Item in InvoiceItems List and saving the Details in DB InvoiceItem Table
                    {
                        if (!ItemList.DeleteInvcItems(lObjdelCmd)) // if Unsuccesful delete invoice item or Line item,Transaction is Rollback and return to form
                        {
                            lObjTrans.Rollback();
                            lObjCnn.Close();
                            return false;
                        }
                        lObjTrans.Commit();
                        lObjCnn.Close();
                        return true;
                    }
                    //After successful deletion of Invoice Item in the respective table,transaction is commited to db.

                }
                catch (SqlException ex)
                {
                    lObjTrans.Rollback();
                    lObjCnn.Close();
                    return false;
                }
                lObjTrans.Commit();
                lObjCnn.Close();
                return true;
            }
        }




        //Search the Invoice with the help of the Mobile Number

        public bool SearchInvoiceMobile(string isConstr, List<Invoice> oObjSerchInvc, string inMobNo)
        {
            string lsSrchMob = " ";
            try
            {
                using (SqlConnection lObjCnnnec = new SqlConnection(isConstr))
                {
                    lsSrchMob = "Select InvoiceSNo,InvoiceDate,InvoiceSts,CustNo,CustFName,CustLName,CustMobNo," +
                        "CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity,CustState,CustPinCode,CustCountry," +
                        "CustGSTNo,CustlLastVisit,CustRemarks,VehicleRegNo,VehicleModel,ChassisNo,EngineNo,Mileage," +
                        "ServiceType,ServiceAssoName,ServiceAssoMobNo,PartsTotal,LabourTotal,PartsCGSTTotal,LabourCGSTTotal," +
                        "PartsSGSTTotal,LabourSGSTTotal,PartsIGSTTotal,LabourIGSTTotal,TotalSGST,TotalCGST,TotalIGST," +
                        "TotalTax,TotalAmount,GrandTotal,DiscountAmount,InvoiceTotal,InvoiceRemarks,Created,CreatedBy,Modified,ModifiedBy" +
                        " From [Invoice" + MasterMechUtil.sFY + "]  Where CustMobNo Like @CustMobNo And Deleted='N'";

                    SqlCommand lObjcoomnd = new SqlCommand(lsSrchMob, lObjCnnnec);
                    lObjcoomnd.CommandType = CommandType.Text;
                    lObjCnnnec.Open();


                    lObjcoomnd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = "%" + inMobNo + "%";


                    using (SqlDataReader lObjRd = lObjcoomnd.ExecuteReader())
                    {
                        if (lObjRd.HasRows)
                        {
                            while (lObjRd.Read())
                            {
                                mnInvoiceSNo = Convert.ToInt32(lObjRd["InvoiceSNo"]);
                                mdInvoiceDate = Convert.ToDateTime(lObjRd["InvoiceDate"]);
                                msInvoiceSts = lObjRd["InvoiceSts"].ToString();
                                mnCustNo = Convert.ToInt32(lObjRd["CustNo"]);
                                msCustFName = lObjRd["CustFName"].ToString();
                                msCustLName = lObjRd["CustLName"].ToString();
                                msCustMobNo = lObjRd["CustMobNo"].ToString();
                                msCustEmail = lObjRd["CustEmail"].ToString();
                                msCustSts = lObjRd["CustSts"].ToString();
                                msCustType = DBNull.Value.Equals(lObjRd["CustType"]) ? null : lObjRd["CustType"].ToString();
                                msCustStAddr = DBNull.Value.Equals(lObjRd["CustStAddr"]) ? null : lObjRd["CustStAddr"].ToString();
                                msCustArAddr = DBNull.Value.Equals(lObjRd["CustArAddr"]) ? null : lObjRd["CustArAddr"].ToString();
                                msCustCity = DBNull.Value.Equals(lObjRd["CustCity"]) ? null : lObjRd["CustCity"].ToString();
                                msCustState = DBNull.Value.Equals(lObjRd["CustState"]) ? null : lObjRd["CustState"].ToString();
                                msCustPinCode = lObjRd["CustPinCode"].ToString();
                                msCustCountry = DBNull.Value.Equals(lObjRd["CustCountry"]) ? null : lObjRd["CustCountry"].ToString();
                                msCustGSTNo = DBNull.Value.Equals(lObjRd["CustGSTNo"]) ? null : lObjRd["CustGSTNo"].ToString();
                                mdCustlLastVisit = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["CustlLastVisit"]) ? null : lObjRd["CustlLastVisit"]);
                                msCustRemarks = DBNull.Value.Equals(lObjRd["CustRemarks"]) ? null : lObjRd["CustRemarks"].ToString();
                                msVehicleRegNo = DBNull.Value.Equals(lObjRd["VehicleRegNo"]) ? null : lObjRd["VehicleRegNo"].ToString();
                                msVehicleModel = DBNull.Value.Equals(lObjRd["VehicleModel"]) ? null : lObjRd["VehicleModel"].ToString();
                                msChassisNo = DBNull.Value.Equals(lObjRd["ChassisNo"]) ? null : lObjRd["ChassisNo"].ToString();
                                msEngineNo = DBNull.Value.Equals(lObjRd["EngineNo"]) ? null : lObjRd["EngineNo"].ToString();
                                mnMileage = Convert.ToInt32(DBNull.Value.Equals(lObjRd["Mileage"]) ? null : lObjRd["Mileage"]);
                                msServiceType = DBNull.Value.Equals(lObjRd["ServiceType"]) ? null : lObjRd["ServiceType"].ToString();
                                msServiceAssoName = DBNull.Value.Equals(lObjRd["ServiceAssoName"]) ? null : lObjRd["ServiceAssoName"].ToString();
                                msServiceAssoMobNo = DBNull.Value.Equals(lObjRd["ServiceAssoMobNo"]) ? null : lObjRd["ServiceAssoMobNo"].ToString();
                                mnPartsTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsTotal"]) ? null : lObjRd["PartsTotal"]);
                                mnLabourTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourTotal"]) ? null : lObjRd["LabourTotal"]);
                                mnPartsCGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["PartsCGSTTotal"]) ? null : lObjRd["PartsCGSTTotal"]);
                                mnLabourCGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["LabourCGSTTotal"]) ? null : lObjRd["LabourCGSTTotal"]);
                                mnPartsSGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["PartsSGSTTotal"]) ? null : lObjRd["PartsSGSTTotal"]);
                                mnLabourSGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["LabourSGSTTotal"]) ? null : lObjRd["LabourSGSTTotal"]);
                                mnPartsIGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["PartsIGSTTotal"]) ? null : lObjRd["PartsIGSTTotal"]);
                                mnLabourIGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["LabourIGSTTotal"]) ? null : lObjRd["LabourIGSTTotal"]);
                                mnTotalSGST = Convert.ToInt32(DBNull.Value.Equals(lObjRd["TotalSGST"]) ? null : lObjRd["TotalSGST"]);
                                mnTotalCGST = Convert.ToInt32(DBNull.Value.Equals(lObjRd["TotalCGST"]) ? null : lObjRd["TotalCGST"]);
                                mnTotalIGST = Convert.ToInt32(DBNull.Value.Equals(lObjRd["TotalIGST"]) ? null : lObjRd["TotalIGST"]);
                                mnTotalTax = Convert.ToInt32(DBNull.Value.Equals(lObjRd["TotalTax"]) ? null : lObjRd["TotalTax"]);
                                mnTotalAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRd["TotalAmount"]) ? null : lObjRd["TotalAmount"]);
                                mnGrandTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["GrandTotal"]) ? null : lObjRd["GrandTotal"]);
                                mnDiscountAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRd["DiscountAmount"]) ? null : lObjRd["DiscountAmount"]);
                                mnInvoiceTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["InvoiceTotal"]) ? null : lObjRd["InvoiceTotal"]);
                                msInvoiceRemarks = DBNull.Value.Equals(lObjRd["InvoiceRemarks"]) ? null : lObjRd["InvoiceRemarks"].ToString();
                                mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["Created"]) ? null : lObjRd["Created"]);
                                msCreatedBy = DBNull.Value.Equals(lObjRd["CreatedBy"]) ? null : lObjRd["CreatedBy"].ToString();

                                if (lObjRd["Modified"] == DBNull.Value)
                                    mdModified = null;
                                else
                                    mdModified = Convert.ToDateTime(lObjRd["Modified"]);



                                msModifiedBy = DBNull.Value.Equals(lObjRd["ModifiedBy"]) ? null : lObjRd["ModifiedBy"].ToString();


                                Invoice lObjDataofInvc = new Invoice(mnInvoiceSNo, mdInvoiceDate, msInvoiceSts, mnCustNo, msCustFName, msCustLName,
                                   msCustMobNo, msCustEmail, msCustSts, msCustType, msCustStAddr, msCustArAddr, msCustCity, msCustState, msCustPinCode,
                                   msCustCountry, msCustGSTNo, mdCustlLastVisit, msCustRemarks, msVehicleRegNo, msVehicleModel, msChassisNo, msEngineNo,
                                   mnMileage, msServiceType, msServiceAssoName, msServiceAssoMobNo, mnPartsTotal, mnLabourTotal, mnPartsCGSTTotal,
                                   mnLabourCGSTTotal, mnPartsSGSTTotal, mnLabourSGSTTotal, mnPartsIGSTTotal, mnLabourIGSTTotal,
                                   mnTotalSGST, mnTotalCGST, mnTotalIGST, mnTotalTax, mnTotalAmount, mnGrandTotal, mnDiscountAmount,
                                   mnInvoiceTotal, msInvoiceRemarks, Convert.ToDateTime(mdCreated), msCreatedBy, Convert.ToDateTime(mdModified), msModifiedBy);

                                oObjSerchInvc.Add(lObjDataofInvc);

                               // lObjRd.Close();
                            }
                        }
                    }
                    lObjCnnnec.Close();
                }
               
            }
            catch (SqlException ex)
            {
                MasterMechUtil.ShowError(ex.Message);
                return false;
            }
            return true;
        }


        //Web Search MVC
        public List<Invoice>  ListInvoice(string isConstr)
        {
            List<Invoice> oObjListInvoice = new List<Invoice>();
            string lsSrchMob = " ";
            try
            {
                using (SqlConnection lObjCnnnec = new SqlConnection(isConstr))
                {
                    lsSrchMob = "Select InvoiceSNo,InvoiceDate,InvoiceSts,CustNo,CustFName,CustLName,CustMobNo," +
                        "CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity,CustState,CustPinCode,CustCountry," +
                        "CustGSTNo,CustlLastVisit,CustRemarks,VehicleRegNo,VehicleModel,ChassisNo,EngineNo,Mileage," +
                        "ServiceType,ServiceAssoName,ServiceAssoMobNo,PartsTotal,LabourTotal,PartsCGSTTotal,LabourCGSTTotal," +
                        "PartsSGSTTotal,LabourSGSTTotal,PartsIGSTTotal,LabourIGSTTotal,TotalSGST,TotalCGST,TotalIGST," +
                        "TotalTax,TotalAmount,GrandTotal,DiscountAmount,InvoiceTotal,InvoiceRemarks,Created,CreatedBy,Modified,ModifiedBy" +
                        " From [Invoice2023-24]";

                    SqlCommand lObjcoomnd = new SqlCommand(lsSrchMob, lObjCnnnec);
                    lObjcoomnd.CommandType = CommandType.Text;
                    lObjCnnnec.Open();


                   // lObjcoomnd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = "%" + inMobNo + "%";


                    using (SqlDataReader lObjRd = lObjcoomnd.ExecuteReader())
                    {
                        if (lObjRd.HasRows)
                        {
                            while (lObjRd.Read())
                            {
                                mnInvoiceSNo = Convert.ToInt32(lObjRd["InvoiceSNo"]);
                                mdInvoiceDate = Convert.ToDateTime(lObjRd["InvoiceDate"]);
                                msInvoiceSts = lObjRd["InvoiceSts"].ToString();
                                mnCustNo = Convert.ToInt32(lObjRd["CustNo"]);
                                msCustFName = lObjRd["CustFName"].ToString();
                                msCustLName = lObjRd["CustLName"].ToString();
                                msCustMobNo = lObjRd["CustMobNo"].ToString();
                                msCustEmail = lObjRd["CustEmail"].ToString();
                                msCustSts = lObjRd["CustSts"].ToString();
                                msCustType = DBNull.Value.Equals(lObjRd["CustType"]) ? null : lObjRd["CustType"].ToString();
                                msCustStAddr = DBNull.Value.Equals(lObjRd["CustStAddr"]) ? null : lObjRd["CustStAddr"].ToString();
                                msCustArAddr = DBNull.Value.Equals(lObjRd["CustArAddr"]) ? null : lObjRd["CustArAddr"].ToString();
                                msCustCity = DBNull.Value.Equals(lObjRd["CustCity"]) ? null : lObjRd["CustCity"].ToString();
                                msCustState = DBNull.Value.Equals(lObjRd["CustState"]) ? null : lObjRd["CustState"].ToString();
                                msCustPinCode = lObjRd["CustPinCode"].ToString();
                                msCustCountry = DBNull.Value.Equals(lObjRd["CustCountry"]) ? null : lObjRd["CustCountry"].ToString();
                                msCustGSTNo = DBNull.Value.Equals(lObjRd["CustGSTNo"]) ? null : lObjRd["CustGSTNo"].ToString();
                                mdCustlLastVisit = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["CustlLastVisit"]) ? null : lObjRd["CustlLastVisit"]);
                                msCustRemarks = DBNull.Value.Equals(lObjRd["CustRemarks"]) ? null : lObjRd["CustRemarks"].ToString();
                                msVehicleRegNo = DBNull.Value.Equals(lObjRd["VehicleRegNo"]) ? null : lObjRd["VehicleRegNo"].ToString();
                                msVehicleModel = DBNull.Value.Equals(lObjRd["VehicleModel"]) ? null : lObjRd["VehicleModel"].ToString();
                                msChassisNo = DBNull.Value.Equals(lObjRd["ChassisNo"]) ? null : lObjRd["ChassisNo"].ToString();
                                msEngineNo = DBNull.Value.Equals(lObjRd["EngineNo"]) ? null : lObjRd["EngineNo"].ToString();
                                mnMileage = Convert.ToInt32(DBNull.Value.Equals(lObjRd["Mileage"]) ? null : lObjRd["Mileage"]);
                                msServiceType = DBNull.Value.Equals(lObjRd["ServiceType"]) ? null : lObjRd["ServiceType"].ToString();
                                msServiceAssoName = DBNull.Value.Equals(lObjRd["ServiceAssoName"]) ? null : lObjRd["ServiceAssoName"].ToString();
                                msServiceAssoMobNo = DBNull.Value.Equals(lObjRd["ServiceAssoMobNo"]) ? null : lObjRd["ServiceAssoMobNo"].ToString();
                                mnPartsTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsTotal"]) ? null : lObjRd["PartsTotal"]);
                                mnLabourTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourTotal"]) ? null : lObjRd["LabourTotal"]);
                                mnPartsCGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["PartsCGSTTotal"]) ? null : lObjRd["PartsCGSTTotal"]);
                                mnLabourCGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["LabourCGSTTotal"]) ? null : lObjRd["LabourCGSTTotal"]);
                                mnPartsSGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["PartsSGSTTotal"]) ? null : lObjRd["PartsSGSTTotal"]);
                                mnLabourSGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["LabourSGSTTotal"]) ? null : lObjRd["LabourSGSTTotal"]);
                                mnPartsIGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["PartsIGSTTotal"]) ? null : lObjRd["PartsIGSTTotal"]);
                                mnLabourIGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["LabourIGSTTotal"]) ? null : lObjRd["LabourIGSTTotal"]);
                                mnTotalSGST = Convert.ToInt32(DBNull.Value.Equals(lObjRd["TotalSGST"]) ? null : lObjRd["TotalSGST"]);
                                mnTotalCGST = Convert.ToInt32(DBNull.Value.Equals(lObjRd["TotalCGST"]) ? null : lObjRd["TotalCGST"]);
                                mnTotalIGST = Convert.ToInt32(DBNull.Value.Equals(lObjRd["TotalIGST"]) ? null : lObjRd["TotalIGST"]);
                                mnTotalTax = Convert.ToInt32(DBNull.Value.Equals(lObjRd["TotalTax"]) ? null : lObjRd["TotalTax"]);
                                mnTotalAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRd["TotalAmount"]) ? null : lObjRd["TotalAmount"]);
                                mnGrandTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["GrandTotal"]) ? null : lObjRd["GrandTotal"]);
                                mnDiscountAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRd["DiscountAmount"]) ? null : lObjRd["DiscountAmount"]);
                                mnInvoiceTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRd["InvoiceTotal"]) ? null : lObjRd["InvoiceTotal"]);
                                msInvoiceRemarks = DBNull.Value.Equals(lObjRd["InvoiceRemarks"]) ? null : lObjRd["InvoiceRemarks"].ToString();
                                mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["Created"]) ? null : lObjRd["Created"]);
                                msCreatedBy = DBNull.Value.Equals(lObjRd["CreatedBy"]) ? null : lObjRd["CreatedBy"].ToString();

                                if (lObjRd["Modified"] == DBNull.Value)
                                    mdModified = null;
                                else
                                    mdModified = Convert.ToDateTime(lObjRd["Modified"]);



                                msModifiedBy = DBNull.Value.Equals(lObjRd["ModifiedBy"]) ? null : lObjRd["ModifiedBy"].ToString();


                                Invoice lObjDataofInvc = new Invoice(mnInvoiceSNo, mdInvoiceDate, msInvoiceSts, mnCustNo, msCustFName, msCustLName,
                                   msCustMobNo, msCustEmail, msCustSts, msCustType, msCustStAddr, msCustArAddr, msCustCity, msCustState, msCustPinCode,
                                   msCustCountry, msCustGSTNo, mdCustlLastVisit, msCustRemarks, msVehicleRegNo, msVehicleModel, msChassisNo, msEngineNo,
                                   mnMileage, msServiceType, msServiceAssoName, msServiceAssoMobNo, mnPartsTotal, mnLabourTotal, mnPartsCGSTTotal,
                                   mnLabourCGSTTotal, mnPartsSGSTTotal, mnLabourSGSTTotal, mnPartsIGSTTotal, mnLabourIGSTTotal,
                                   mnTotalSGST, mnTotalCGST, mnTotalIGST, mnTotalTax, mnTotalAmount, mnGrandTotal, mnDiscountAmount,
                                   mnInvoiceTotal, msInvoiceRemarks, Convert.ToDateTime(mdCreated), msCreatedBy, Convert.ToDateTime(mdModified), msModifiedBy);

                                oObjListInvoice.Add(lObjDataofInvc);

                                // lObjRd.Close();
                            }
                        }
                    }
                    lObjCnnnec.Close();
                }

            }
            catch (SqlException ex)
            {
                MasterMechUtil.ShowError(ex.Message);
                
            }
            return oObjListInvoice;
        }


        public bool InvoiceSerchRegNo(string VehicleRegNo)
        {
            string lsRegNoSrch = " ";


            try
            {
                using (SqlConnection lObjCnec = new SqlConnection(Constr))
                {
                    lsRegNoSrch = "Select InvoiceSNo,InvoiceDate,InvoiceSts,CustNo,CustFName,CustLName,CustMobNo," +
                        "CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity,CustState,CustPinCode,CustCountry," +
                        "CustGSTNo,CustlLastVisit,CustRemarks,,VehicleRegNo,VehicleModel,ChassisNo,EngineNo,Mileage," +
                        "ServiceType,ServiceAssoName,ServiceAssoMobNo,PartsTotal,LabourTotal,PartsCGSTTotal,LabourCGSTTotal," +
                        "PartsSGSTTotal,LabourSGSTTotal,PartsIGSTTotal,LabourIGSTTotal,TotalSGST,TotalCGST,TotalIGST," +
                        "TotalTax,TotalAmount,GrandTotal,DiscountAmount,InvoiceTotal,InvoiceRemarks  From [Invoice" + MasterMechLib.MasterMechUtil.sFY + "] Where VehicleRegNo=@VehicleRegNo";

                    SqlCommand lObjCoMd = new SqlCommand(lsRegNoSrch, lObjCnec);
                    lObjCoMd.CommandType = CommandType.Text;
                    lObjCnec.Open();


                    lObjCoMd.Parameters.AddWithValue("@VehicleRegNo", SqlDbType.VarChar).Value = "%" + VehicleRegNo + "%";

                    using (SqlDataReader lObjRRD = lObjCoMd.ExecuteReader())
                    {
                        if (lObjRRD.HasRows)
                        {
                            while (lObjRRD.Read())
                            {
                                mnInvoiceSNo = Convert.ToInt32(lObjRRD["InvoiceSNo"]);
                                mdInvoiceDate = Convert.ToDateTime(lObjRRD["InvoiceDate"]);
                                msInvoiceSts = lObjRRD["InvoiceSts"].ToString();
                                mnCustNo = Convert.ToInt32(lObjRRD["CustNo"]);
                                msCustFName = lObjRRD["CustFName"].ToString();
                                msCustLName = lObjRRD["CustLName"].ToString();
                                msCustMobNo = lObjRRD["CustMobNo"].ToString();
                                msCustEmail = lObjRRD["CustEmail"].ToString();
                                msCustSts = lObjRRD["CustSts"].ToString();
                                msCustType = DBNull.Value.Equals(lObjRRD["CustType"]) ? null : lObjRRD["CustType"].ToString();
                                msCustStAddr = DBNull.Value.Equals(lObjRRD["CustStAddr"]) ? null : lObjRRD["CustStAddr"].ToString();
                                msCustArAddr = DBNull.Value.Equals(lObjRRD["CustArAddr"]) ? null : lObjRRD["CustArAddr"].ToString();
                                msCustCity = DBNull.Value.Equals(lObjRRD["CustCity"]) ? null : lObjRRD["CustCity"].ToString();
                                msCustState = DBNull.Value.Equals(lObjRRD["CustState"]) ? null : lObjRRD["CustState"].ToString();
                                msCustPinCode = lObjRRD["CustPinCode"].ToString();
                                msCustCountry = DBNull.Value.Equals(lObjRRD["CustCountry"]) ? null : lObjRRD["CustCountry"].ToString();
                                msCustGSTNo = DBNull.Value.Equals(lObjRRD["CustGSTNo"]) ? null : lObjRRD["CustGSTNo"].ToString();
                                mdCustlLastVisit = Convert.ToDateTime(DBNull.Value.Equals(lObjRRD["CustlLastVisit"]) ? null : lObjRRD["CustlLastVisit"]);
                                msCustRemarks = DBNull.Value.Equals(lObjRRD["CustRemarks"]) ? null : lObjRRD["CustRemarks"].ToString();

                                msVehicleRegNo = DBNull.Value.Equals(lObjRRD["VehicleRegNo"]) ? null : lObjRRD["VehicleRegNo"].ToString();
                                msVehicleModel = DBNull.Value.Equals(lObjRRD["VehicleModel"]) ? null : lObjRRD["VehicleModel"].ToString();
                                msChassisNo = DBNull.Value.Equals(lObjRRD["ChassisNo"]) ? null : lObjRRD["ChassisNo"].ToString();
                                msEngineNo = DBNull.Value.Equals(lObjRRD["EngineNo"]) ? null : lObjRRD["EngineNo"].ToString();
                                mnMileage = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["Mileage"]) ? null : lObjRRD["Mileage"]);
                                msServiceType = DBNull.Value.Equals(lObjRRD["ServiceType"]) ? null : lObjRRD["ServiceType"].ToString();
                                msServiceAssoName = DBNull.Value.Equals(lObjRRD["ServiceAssoName"]) ? null : lObjRRD["ServiceAssoName"].ToString();
                                msServiceAssoMobNo = DBNull.Value.Equals(lObjRRD["ServiceAssoMobNo"]) ? null : lObjRRD["ServiceAssoMobNo"].ToString();
                                mnPartsTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRRD["PartsTotal"]) ? null : lObjRRD["PartsTotal"]);
                                mnLabourTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRRD["LabourTotal"]) ? null : lObjRRD["LabourTotal"]);
                                mnPartsCGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["PartsCGSTTotal"]) ? null : lObjRRD["PartsCGSTTotal"]);
                                mnLabourCGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["LabourCGSTTotal"]) ? null : lObjRRD["LabourCGSTTotal"]);
                                mnPartsSGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["PartsSGSTTotal"]) ? null : lObjRRD["PartsSGSTTotal"]);
                                mnLabourSGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["LabourSGSTTotal"]) ? null : lObjRRD["LabourSGSTTotal"]);
                                mnPartsIGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["PartsIGSTTotal"]) ? null : lObjRRD["PartsIGSTTotal"]);
                                mnLabourIGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["LabourIGSTTotal"]) ? null : lObjRRD["LabourIGSTTotal"]);
                                mnTotalSGST = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["TotalSGST"]) ? null : lObjRRD["TotalSGST"]);
                                mnTotalCGST = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["TotalCGST"]) ? null : lObjRRD["TotalCGST"]);
                                mnTotalIGST = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["TotalIGST"]) ? null : lObjRRD["TotalIGST"]);
                                mnTotalTax = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["TotalTax"]) ? null : lObjRRD["TotalTax"]);
                                mnTotalAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["TotalAmount"]) ? null : lObjRRD["TotalAmount"]);
                                mnGrandTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["GrandTotal"]) ? null : lObjRRD["GrandTotal"]);
                                mnDiscountAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["DiscountAmount"]) ? null : lObjRRD["DiscountAmount"]);
                                mnInvoiceTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["InvoiceTotal"]) ? null : lObjRRD["InvoiceTotal"]);
                                msInvoiceRemarks = lObjRRD["InvoiceRemarks"].ToString();


                                lObjRRD.Close();
                            }
                        }
                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }


        public bool AdvanceSearch(string Constr,List<Invoice> oObjInviceList,string inMobileNum,string isCity,string inRegNo)
        {
            string lsRegNoSrch = " ";

            try
            {
                using (SqlConnection lObjCnec = new SqlConnection(Constr))
                {
                    lsRegNoSrch = "Select InvoiceSNo,InvoiceDate,InvoiceSts,CustNo,CustFName,CustLName,CustMobNo," +
                        "CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity,CustState,CustPinCode,CustCountry," +
                        "CustGSTNo,CustlLastVisit,CustRemarks,,VehicleRegNo,VehicleModel,ChassisNo,EngineNo,Mileage," +
                        "ServiceType,ServiceAssoName,ServiceAssoMobNo,PartsTotal,LabourTotal,PartsCGSTTotal,LabourCGSTTotal," +
                        "PartsSGSTTotal,LabourSGSTTotal,PartsIGSTTotal,LabourIGSTTotal,TotalSGST,TotalCGST,TotalIGST," +
                        "TotalTax,TotalAmount,GrandTotal,DiscountAmount,InvoiceTotal,InvoiceRemarks  From [Invoice" + MasterMechLib.MasterMechUtil.sFY + "] Where" +
                        " CustMobNo  Like  @CustMobNo  AND   CustCity Like @CustCity And  VehicleRegNo Like @VehicleRegNo";

                    SqlCommand lObjCoMd = new SqlCommand(lsRegNoSrch, lObjCnec);
                    lObjCoMd.CommandType = CommandType.Text;
                    lObjCnec.Open();


                   lObjCoMd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = "%" + inMobileNum + "%";
                   lObjCoMd.Parameters.AddWithValue("@CustCity", SqlDbType.VarChar).Value = "%" + isCity + "%";
                   lObjCoMd.Parameters.AddWithValue("@VehicleRegNo", SqlDbType.VarChar).Value = "%" +inRegNo+ "%";

                    using (SqlDataReader lObjRRD = lObjCoMd.ExecuteReader())
                    {
                        if (lObjRRD.HasRows)
                        {
                            while (lObjRRD.Read())
                            {
                                mnInvoiceSNo = Convert.ToInt32(lObjRRD["InvoiceSNo"]);
                                mdInvoiceDate = Convert.ToDateTime(lObjRRD["InvoiceDate"]);
                                msInvoiceSts = lObjRRD["InvoiceSts"].ToString();
                                mnCustNo = Convert.ToInt32(lObjRRD["CustNo"]);
                                msCustFName = lObjRRD["CustFName"].ToString();
                                msCustLName = lObjRRD["CustLName"].ToString();
                                msCustMobNo = lObjRRD["CustMobNo"].ToString();
                                msCustEmail = lObjRRD["CustEmail"].ToString();
                                msCustSts = lObjRRD["CustSts"].ToString();
                                msCustType = DBNull.Value.Equals(lObjRRD["CustType"]) ? null : lObjRRD["CustType"].ToString();
                                msCustStAddr = DBNull.Value.Equals(lObjRRD["CustStAddr"]) ? null : lObjRRD["CustStAddr"].ToString();
                                msCustArAddr = DBNull.Value.Equals(lObjRRD["CustArAddr"]) ? null : lObjRRD["CustArAddr"].ToString();
                                msCustCity = DBNull.Value.Equals(lObjRRD["CustCity"]) ? null : lObjRRD["CustCity"].ToString();
                                msCustState = DBNull.Value.Equals(lObjRRD["CustState"]) ? null : lObjRRD["CustState"].ToString();
                                msCustPinCode = lObjRRD["CustPinCode"].ToString();
                                msCustCountry = DBNull.Value.Equals(lObjRRD["CustCountry"]) ? null : lObjRRD["CustCountry"].ToString();
                                msCustGSTNo = DBNull.Value.Equals(lObjRRD["CustGSTNo"]) ? null : lObjRRD["CustGSTNo"].ToString();
                                mdCustlLastVisit = Convert.ToDateTime(DBNull.Value.Equals(lObjRRD["CustlLastVisit"]) ? null : lObjRRD["CustlLastVisit"]);
                                msCustRemarks = DBNull.Value.Equals(lObjRRD["CustRemarks"]) ? null : lObjRRD["CustRemarks"].ToString();

                                msVehicleRegNo = DBNull.Value.Equals(lObjRRD["VehicleRegNo"]) ? null : lObjRRD["VehicleRegNo"].ToString();
                                msVehicleModel = DBNull.Value.Equals(lObjRRD["VehicleModel"]) ? null : lObjRRD["VehicleModel"].ToString();
                                msChassisNo = DBNull.Value.Equals(lObjRRD["ChassisNo"]) ? null : lObjRRD["ChassisNo"].ToString();
                                msEngineNo = DBNull.Value.Equals(lObjRRD["EngineNo"]) ? null : lObjRRD["EngineNo"].ToString();
                                mnMileage = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["Mileage"]) ? null : lObjRRD["Mileage"]);
                                msServiceType = DBNull.Value.Equals(lObjRRD["ServiceType"]) ? null : lObjRRD["ServiceType"].ToString();
                                msServiceAssoName = DBNull.Value.Equals(lObjRRD["ServiceAssoName"]) ? null : lObjRRD["ServiceAssoName"].ToString();
                                msServiceAssoMobNo = DBNull.Value.Equals(lObjRRD["ServiceAssoMobNo"]) ? null : lObjRRD["ServiceAssoMobNo"].ToString();
                                mnPartsTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRRD["PartsTotal"]) ? null : lObjRRD["PartsTotal"]);
                                mnLabourTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRRD["LabourTotal"]) ? null : lObjRRD["LabourTotal"]);
                                mnPartsCGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["PartsCGSTTotal"]) ? null : lObjRRD["PartsCGSTTotal"]);
                                mnLabourCGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["LabourCGSTTotal"]) ? null : lObjRRD["LabourCGSTTotal"]);
                                mnPartsSGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["PartsSGSTTotal"]) ? null : lObjRRD["PartsSGSTTotal"]);
                                mnLabourSGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["LabourSGSTTotal"]) ? null : lObjRRD["LabourSGSTTotal"]);
                                mnPartsIGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["PartsIGSTTotal"]) ? null : lObjRRD["PartsIGSTTotal"]);
                                mnLabourIGSTTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["LabourIGSTTotal"]) ? null : lObjRRD["LabourIGSTTotal"]);
                                mnTotalSGST = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["TotalSGST"]) ? null : lObjRRD["TotalSGST"]);
                                mnTotalCGST = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["TotalCGST"]) ? null : lObjRRD["TotalCGST"]);
                                mnTotalIGST = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["TotalIGST"]) ? null : lObjRRD["TotalIGST"]);
                                mnTotalTax = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["TotalTax"]) ? null : lObjRRD["TotalTax"]);
                                mnTotalAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["TotalAmount"]) ? null : lObjRRD["TotalAmount"]);
                                mnGrandTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["GrandTotal"]) ? null : lObjRRD["GrandTotal"]);
                                mnDiscountAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["DiscountAmount"]) ? null : lObjRRD["DiscountAmount"]);
                                mnInvoiceTotal = Convert.ToInt32(DBNull.Value.Equals(lObjRRD["InvoiceTotal"]) ? null : lObjRRD["InvoiceTotal"]);
                                msInvoiceRemarks = lObjRRD["InvoiceRemarks"].ToString();

                                Invoice lObjDataofInvc = new Invoice(mnInvoiceSNo, mdInvoiceDate, msInvoiceSts, mnCustNo, msCustFName, msCustLName,
                                msCustMobNo, msCustEmail, msCustSts, msCustType, msCustStAddr, msCustArAddr, msCustCity, msCustState, msCustPinCode,
                                msCustCountry, msCustGSTNo, mdCustlLastVisit, msCustRemarks, msVehicleRegNo, msVehicleModel, msChassisNo, msEngineNo,
                                mnMileage, msServiceType, msServiceAssoName, msServiceAssoMobNo, mnPartsTotal, mnLabourTotal, mnPartsCGSTTotal,
                                mnLabourCGSTTotal, mnPartsSGSTTotal, mnLabourSGSTTotal, mnPartsIGSTTotal, mnLabourIGSTTotal,
                                mnTotalSGST, mnTotalCGST, mnTotalIGST, mnTotalTax, mnTotalAmount, mnGrandTotal, mnDiscountAmount,
                                mnInvoiceTotal, msInvoiceRemarks, Convert.ToDateTime(mdCreated), msCreatedBy, Convert.ToDateTime(mdModified), msModifiedBy);

                                oObjInviceList.Add(lObjDataofInvc);

                                lObjRRD.Close();
                            }
                        }
                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
        // Desktop Save

        public bool Save()
        {
            string lsQryInput = " ";

            using (SqlConnection lObjCon = new SqlConnection(MasterMechUtil.Constr))
            {
            lObjCon.Open();
            
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = lObjCon;


                SqlTransaction lObjTransc;
                lObjTransc = lObjCon.BeginTransaction("InvoiceTransction");
                Cmd.Transaction = lObjTransc;


                if (mObjCustData.mnCustNo == null)
                {
                    if (!mObjCustData.Save())
                    {
                        lObjTransc.Rollback();
                        lObjCon.Close();
                        return false;
                    }
                }
                else
                {
                    if (!mObjCustData.UpdateLastLogin(Cmd))
                    {
                        lObjTransc.Rollback();
                        lObjCon.Close();
                        return false;
                    }
                }

                if (mnInvoiceSNo == null)
                {
                    try
                    {
                        lsQryInput = "Insert Into [Invoice" + MasterMechUtil.sFY + "]" +
                        "(InvoiceDate,InvoiceSts,CustNo,CustFName," +
                        "CustLName,CustMobNo,CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity," +
                        "CustState,CustPinCode,CustCountry,CustGSTNo,CustlLastVisit,CustRemarks,VehicleRegNo," +
                        "VehicleModel,ChassisNo,EngineNo,Mileage,ServiceType,ServiceAssoName,ServiceAssoMobNo," +
                        "PartsTotal,LabourTotal,PartsCGSTTotal,LabourCGSTTotal,PartsSGSTTotal,LabourSGSTTotal," +
                        "PartsIGSTTotal,LabourIGSTTotal,TotalSGST,TotalCGST,TotalIGST,TotalTax,TotalAmount," +
                        "GrandTotal,DiscountAmount,InvoiceTotal,InvoiceRemarks,Created,CreatedBy,Deleted)OUTPUT INSERTED.InvoiceSNo" +
                        " VALUES(@InvoiceDate,@InvoiceSts,@CustNo,@CustFName,@CustLName,@CustMobNo,@CustEmail," +
                        "@CustSts,@CustType,@CustStAddr,@CustArAddr,@CustCity,@CustState,@CustPinCode,@CustCountry,@CustGSTNo," +
                        "@CustlLastVisit,@CustRemarks,@VehicleRegNo,@VehicleModel,@ChassisNo,@EngineNo,@Mileage,@ServiceType," +
                        "@ServiceAssoName,@ServiceAssoMobNo,@PartsTotal,@LabourTotal,@PartsCGSTTotal,@LabourCGSTTotal," +
                        "@PartsSGSTTotal,@LabourSGSTTotal,@PartsIGSTTotal,@LabourIGSTTotal,@TotalSGST,@TotalCGST,@TotalIGST,@TotalTax," +
                        "@TotalAmount,@GrandTotal,@DiscountAmount,@InvoiceTotal,@InvoiceRemarks,@Created," +
                        "@CreatedBy,'N')";


                        Cmd.CommandText = lsQryInput;
                        Cmd.CommandType = CommandType.Text;


                        //Cmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.Int).Value = mnInvoiceSNo;
                        Cmd.Parameters.AddWithValue("@InvoiceDate", SqlDbType.DateTime).Value = DateTime.Now;
                        Cmd.Parameters.AddWithValue("@InvoiceSts", SqlDbType.VarChar).Value = "SAVED";
                        Cmd.Parameters.AddWithValue("@CustNo", SqlDbType.Int).Value = mObjCustData.mnCustNo;
                        Cmd.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = mObjCustData.msCustFName;
                        Cmd.Parameters.AddWithValue("@CustLName", SqlDbType.VarChar).Value = mObjCustData.msCustLName;
                        Cmd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = mObjCustData.msCustMobNo;
                        Cmd.Parameters.AddWithValue("@CustEmail", SqlDbType.VarChar).Value = mObjCustData.msCustEmail;
                        Cmd.Parameters.AddWithValue("@CustSts", SqlDbType.VarChar).Value = mObjCustData.msCustSts;
                        Cmd.Parameters.AddWithValue("@CustType", SqlDbType.VarChar).Value = (object)mObjCustData.msCustType ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustStAddr", SqlDbType.VarChar).Value = (object)mObjCustData.msCustStAddr ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustArAddr", SqlDbType.VarChar).Value = (object)mObjCustData.msCustArAddr ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustCity", SqlDbType.VarChar).Value = (object)mObjCustData.msCustCity ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustState", SqlDbType.VarChar).Value = (object)mObjCustData.msCustState ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustPinCode", SqlDbType.VarChar).Value = (object)mObjCustData.msCustPinCode ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustCountry", SqlDbType.VarChar).Value = (object)mObjCustData.msCustCountry ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustGSTNo", SqlDbType.VarChar).Value = (object)mObjCustData.msCustGSTNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustlLastVisit", SqlDbType.DateTime).Value = DateTime.Now;
                        Cmd.Parameters.AddWithValue("@CustRemarks", SqlDbType.VarChar).Value = (object)mObjCustData.msCustRemarks ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@VehicleRegNo", SqlDbType.VarChar).Value = (object)msVehicleRegNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@VehicleModel", SqlDbType.VarChar).Value = (object)msVehicleModel ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ChassisNo", SqlDbType.VarChar).Value = (object)msChassisNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@EngineNo", SqlDbType.VarChar).Value = (object)msEngineNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@Mileage", SqlDbType.Int).Value = (object)mnMileage ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ServiceType", SqlDbType.VarChar).Value = (object)msServiceType ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ServiceAssoName", SqlDbType.VarChar).Value = (object)msServiceAssoName ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ServiceAssoMobNo", SqlDbType.VarChar).Value = (object)msServiceAssoMobNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsTotal", SqlDbType.Float).Value = (object)mnPartsTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourTotal", SqlDbType.Float).Value = (object)mnLabourTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsCGSTTotal", SqlDbType.Float).Value = (object)mnPartsCGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourCGSTTotal", SqlDbType.Float).Value = (object)mnLabourCGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsSGSTTotal", SqlDbType.Float).Value = (object)mnPartsSGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourSGSTTotal", SqlDbType.Float).Value = (object)mnLabourSGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsIGSTTotal", SqlDbType.Float).Value = (object)mnPartsIGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourIGSTTotal", SqlDbType.Float).Value = (object)mnLabourIGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalSGST", SqlDbType.Float).Value = (object)mnTotalSGST ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalCGST", SqlDbType.Float).Value = (object)mnTotalCGST ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalIGST", SqlDbType.Float).Value = (object)mnTotalIGST ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalTax", SqlDbType.Float).Value = (object)mnTotalTax ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalAmount", SqlDbType.Float).Value = (object)mnTotalAmount ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@GrandTotal", SqlDbType.Float).Value = (object)mnGrandTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@DiscountAmount", SqlDbType.Float).Value = (object)mnDiscountAmount ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@InvoiceTotal", SqlDbType.Float).Value = (object)mnInvoiceTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@InvoiceRemarks", SqlDbType.VarChar).Value = (object)msInvoiceRemarks ?? DBNull.Value;


                        Cmd.Parameters.AddWithValue("@Created", SqlDbType.DateTime).Value = DateTime.Now;
                        Cmd.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = MasterMechUtil.sUserID;

                        InvoiceSNo = (String)Cmd.ExecuteScalar();  // Getting InvoiceSNo to Update in line Items
                        Cmd.Parameters.Clear();


                        foreach (InvoiceItem lObjItem in lObjInvoiceList)
                        {
                            lObjItem.InvoiceSNo = (int)mnInvoiceSNo;
                            if (!lObjItem.SaveInvcItem(Cmd))
                            {
                                lObjTransc.Rollback();
                                lObjCon.Close();
                                return false;
                            }
                        }
                        lObjTransc.Commit();
                        lObjCon.Close();
                    }
                    catch (SqlException ex)
                    {
                        MasterMechUtil.ShowError(ex.Message);
                        lObjTransc.Rollback();
                        lObjCon.Close();
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        lsQryInput = "Update  [Invoice" + MasterMechUtil.sFY + "]  SET CustNo=@CustNo,CustFName=@CustFName,CustLName=@CustLName," +
                            "CustMobNo=@CustMobNo,CustEmail=@CustEmail,CustSts=@CustSts,CustType=@CustType,CustStAddr=@CustStAddr," +
                            "CustArAddr=@CustArAddr,CustCity=@CustCity,CustState=@CustState,CustPinCode=@CustPinCode,CustCountry=@CustCountry," +
                            "CustGSTNo=@CustGSTNo,CustlLastVisit=@CustlLastVisit,CustRemarks=@CustRemarks,VehicleRegNo=@VehicleRegNo,VehicleModel=@VehicleModel," +
                            "ChassisNo=@ChassisNo,EngineNo=@EngineNo,Mileage=@Mileage,ServiceType=@ServiceType,ServiceAssoName=@ServiceAssoName," +
                            "ServiceAssoMobNo=@ServiceAssoMobNo,PartsTotal=@PartsTotal,LabourTotal=@LabourTotal,PartsCGSTTotal=@PartsCGSTTotal," +
                            "LabourCGSTTotal=@LabourCGSTTotal,PartsSGSTTotal=@PartsSGSTTotal,LabourSGSTTotal=@LabourSGSTTotal,PartsIGSTTotal=@PartsIGSTTotal," +
                            "LabourIGSTTotal=@LabourIGSTTotal,TotalSGST=@TotalSGST,TotalCGST=@TotalCGST,TotalIGST=@TotalIGST," +
                            "TotalTax=@TotalTax,TotalAmount=@TotalAmount,GrandTotal=@GrandTotal,DiscountAmount=@DiscountAmount," +
                            "InvoiceTotal=@InvoiceTotal,InvoiceRemarks=@InvoiceRemarks,Modified=@Modified,ModifiedBy=@ModifiedBy" +
                            "Where InvoiceSNo=@InvoiceSNo";


                        Cmd.CommandText = lsQryInput;
                        Cmd.CommandType = CommandType.Text;


                       // Cmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.Int).Value = mnInvoiceSNo;
                        Cmd.Parameters.AddWithValue("@CustNo", SqlDbType.Int).Value = mObjCustData.mnCustNo;
                        Cmd.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = mObjCustData.msCustFName;
                        Cmd.Parameters.AddWithValue("@CustLName", SqlDbType.VarChar).Value = mObjCustData.msCustLName;
                        Cmd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = mObjCustData.msCustMobNo;
                        Cmd.Parameters.AddWithValue("@CustEmail", SqlDbType.VarChar).Value = mObjCustData.msCustEmail;
                        Cmd.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = mObjCustData.msCustFName;
                        Cmd.Parameters.AddWithValue("@CustLName", SqlDbType.VarChar).Value = mObjCustData.msCustLName;
                        Cmd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = mObjCustData.msCustMobNo;
                        Cmd.Parameters.AddWithValue("@CustEmail", SqlDbType.VarChar).Value = mObjCustData.msCustEmail;
                        Cmd.Parameters.AddWithValue("@CustSts", SqlDbType.VarChar).Value = mObjCustData.msCustSts;
                        Cmd.Parameters.AddWithValue("@CustType", SqlDbType.VarChar).Value = (object)mObjCustData.msCustType ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustStAddr", SqlDbType.VarChar).Value = (object)mObjCustData.msCustStAddr ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustArAddr", SqlDbType.VarChar).Value = (object)mObjCustData.msCustArAddr ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustCity", SqlDbType.VarChar).Value = (object)mObjCustData.msCustCity ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustState", SqlDbType.VarChar).Value = (object)mObjCustData.msCustState ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustPinCode", SqlDbType.VarChar).Value = (object)mObjCustData.msCustPinCode ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustCountry", SqlDbType.VarChar).Value = (object)mObjCustData.msCustCountry ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustGSTNo", SqlDbType.VarChar).Value = (object)mObjCustData.msCustGSTNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustlLastVisit", SqlDbType.DateTime).Value = (object)mObjCustData.mdCustlLastVisit ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustRemarks", SqlDbType.VarChar).Value = (object)mObjCustData.msCustRemarks ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@VehicleRegNo", SqlDbType.VarChar).Value = (object)msVehicleRegNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@VehicleModel", SqlDbType.VarChar).Value = (object)msVehicleModel ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ChassisNo", SqlDbType.VarChar).Value = (object)msChassisNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@EngineNo", SqlDbType.VarChar).Value = (object)msEngineNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@Mileage", SqlDbType.Int).Value = (object)mnMileage ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ServiceType", SqlDbType.VarChar).Value = (object)msServiceType ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ServiceAssoName", SqlDbType.VarChar).Value = (object)msServiceAssoName ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ServiceAssoMobNo", SqlDbType.VarChar).Value = (object)msServiceAssoMobNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsTotal", SqlDbType.Float).Value = (object)mnPartsTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourTotal", SqlDbType.Float).Value = (object)mnLabourTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsCGSTTotal", SqlDbType.Float).Value = (object)mnPartsCGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourCGSTTotal", SqlDbType.Float).Value = (object)mnLabourCGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsSGSTTotal", SqlDbType.Float).Value = (object)mnPartsSGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourSGSTTotal", SqlDbType.Float).Value = (object)mnLabourSGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsIGSTTotal", SqlDbType.Float).Value = (object)mnPartsIGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourIGSTTotal", SqlDbType.Float).Value = (object)mnLabourIGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalSGST", SqlDbType.Float).Value = (object)mnTotalSGST ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalCGST", SqlDbType.Float).Value = (object)mnTotalCGST ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalIGST", SqlDbType.Float).Value = (object)mnTotalIGST ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalTax", SqlDbType.Float).Value = (object)mnTotalTax ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalAmount", SqlDbType.Float).Value = (object)mnTotalAmount ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@GrandTotal", SqlDbType.Float).Value = (object)mnGrandTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@DiscountAmount", SqlDbType.Float).Value = (object)mnDiscountAmount ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@InvoiceTotal", SqlDbType.Float).Value = (object)mnInvoiceTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@InvoiceRemarks", SqlDbType.VarChar).Value = (object)msInvoiceRemarks ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@Modified", SqlDbType.DateTime).Value = DateTime.Now;
                        Cmd.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = UserID;

                        Cmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.Int).Value = InvoiceSNo;
                        Cmd.Parameters.Clear();


                        foreach (InvoiceItem lObjItm in lObjInvoiceList)
                        {
                            lObjItm.InvoiceSNo = mnInvoiceSNo;
                            if (!lObjItm.SaveInvcItem(Cmd))
                            {
                                lObjTransc.Rollback();
                                lObjCon.Close();
                                return false;
                            }
                        }
                        lObjTransc.Commit();
                        lObjCon.Close();
                    }
                    catch (Exception ex)
                    {
                        // MasterMechUtil.ShowError(ex.Message);
                        return false;
                    }
                }
                return true;
            }
        }


        // Web Save Invoice
        public bool SaveInv()
        {
            //Invoice lObjIn = new Invoice();
            string lsQryInput = " ";

            using (SqlConnection lObjCon = new SqlConnection(MasterMechUtil.Constr))
            {
                lObjCon.Open();

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = lObjCon;

                SqlTransaction lObjTransc;
                lObjTransc = lObjCon.BeginTransaction("InvoiceTransction");
                Cmd.Transaction = lObjTransc;

                if (mnCustNo == null)
                {
                    if (!mObjCustData.Save())
                    {
                        lObjTransc.Rollback();
                        lObjCon.Close();
                        return false;
                    }
                }
                else
                {
                    if (!mObjCustData.UpdateLastLogin(Cmd))
                    {
                        lObjTransc.Rollback();
                        lObjCon.Close();
                        return false;
                    }
                }

                if (mnInvoiceSNo == null)
                {
                    try
                    {
                        lsQryInput = "Insert Into [Invoice" + MasterMechUtil.sFY + "]" +
                        "(InvoiceDate,InvoiceSts,CustNo,CustFName," +
                        "CustLName,CustMobNo,CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity," +
                        "CustState,CustPinCode,CustCountry,CustGSTNo,CustlLastVisit,CustRemarks,VehicleRegNo," +
                        "VehicleModel,ChassisNo,EngineNo,Mileage,ServiceType,ServiceAssoName,ServiceAssoMobNo," +
                        "PartsTotal,LabourTotal,PartsCGSTTotal,LabourCGSTTotal,PartsSGSTTotal,LabourSGSTTotal," +
                        "PartsIGSTTotal,LabourIGSTTotal,TotalSGST,TotalCGST,TotalIGST,TotalTax,TotalAmount," +
                        "GrandTotal,DiscountAmount,InvoiceTotal,InvoiceRemarks,Created,CreatedBy,Deleted)OUTPUT INSERTED.InvoiceSNo" +
                        " VALUES(@InvoiceDate,@InvoiceSts,@CustNo,@CustFName,@CustLName,@CustMobNo,@CustEmail," +
                        "@CustSts,@CustType,@CustStAddr,@CustArAddr,@CustCity,@CustState,@CustPinCode,@CustCountry,@CustGSTNo," +
                        "@CustlLastVisit,@CustRemarks,@VehicleRegNo,@VehicleModel,@ChassisNo,@EngineNo,@Mileage,@ServiceType," +
                        "@ServiceAssoName,@ServiceAssoMobNo,@PartsTotal,@LabourTotal,@PartsCGSTTotal,@LabourCGSTTotal," +
                        "@PartsSGSTTotal,@LabourSGSTTotal,@PartsIGSTTotal,@LabourIGSTTotal,@TotalSGST,@TotalCGST,@TotalIGST,@TotalTax," +
                        "@TotalAmount,@GrandTotal,@DiscountAmount,@InvoiceTotal,@InvoiceRemarks,@Created," +
                        "@CreatedBy,'N')";


                        Cmd.CommandText = lsQryInput;
                        Cmd.CommandType = CommandType.Text;


                        //Cmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.Int).Value = mnInvoiceSNo;
                        Cmd.Parameters.AddWithValue("@InvoiceDate", SqlDbType.DateTime).Value = DateTime.Now;
                        Cmd.Parameters.AddWithValue("@InvoiceSts", SqlDbType.VarChar).Value = "SAVED";
                        Cmd.Parameters.AddWithValue("@CustNo", SqlDbType.Int).Value = mObjCustData.mnCustNo;
                        Cmd.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = mObjCustData.msCustFName;
                        Cmd.Parameters.AddWithValue("@CustLName", SqlDbType.VarChar).Value = mObjCustData.msCustLName;
                        Cmd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = mObjCustData.msCustMobNo;
                        Cmd.Parameters.AddWithValue("@CustEmail", SqlDbType.VarChar).Value = mObjCustData.msCustEmail;
                        Cmd.Parameters.AddWithValue("@CustSts", SqlDbType.VarChar).Value = mObjCustData.msCustSts;
                        Cmd.Parameters.AddWithValue("@CustType", SqlDbType.VarChar).Value = (object)mObjCustData.msCustType ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustStAddr", SqlDbType.VarChar).Value = (object)mObjCustData.msCustStAddr ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustArAddr", SqlDbType.VarChar).Value = (object)mObjCustData.msCustArAddr ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustCity", SqlDbType.VarChar).Value = (object)mObjCustData.msCustCity ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustState", SqlDbType.VarChar).Value = (object)mObjCustData.msCustState ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustPinCode", SqlDbType.VarChar).Value = (object)mObjCustData.msCustPinCode ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustCountry", SqlDbType.VarChar).Value = (object)mObjCustData.msCustCountry ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustGSTNo", SqlDbType.VarChar).Value = (object)mObjCustData.msCustGSTNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@CustlLastVisit", SqlDbType.DateTime).Value = DateTime.Now;
                        Cmd.Parameters.AddWithValue("@CustRemarks", SqlDbType.VarChar).Value = (object)mObjCustData.msCustRemarks ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@VehicleRegNo", SqlDbType.VarChar).Value = (object)msVehicleRegNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@VehicleModel", SqlDbType.VarChar).Value = (object)msVehicleModel ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ChassisNo", SqlDbType.VarChar).Value = (object)msChassisNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@EngineNo", SqlDbType.VarChar).Value = (object)msEngineNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@Mileage", SqlDbType.Int).Value = (object)mnMileage ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ServiceType", SqlDbType.VarChar).Value = (object)msServiceType ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ServiceAssoName", SqlDbType.VarChar).Value = (object)msServiceAssoName ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ServiceAssoMobNo", SqlDbType.VarChar).Value = (object)msServiceAssoMobNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsTotal", SqlDbType.Float).Value = (object)mnPartsTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourTotal", SqlDbType.Float).Value = (object)mnLabourTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsCGSTTotal", SqlDbType.Float).Value = (object)mnPartsCGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourCGSTTotal", SqlDbType.Float).Value = (object)mnLabourCGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsSGSTTotal", SqlDbType.Float).Value = (object)mnPartsSGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourSGSTTotal", SqlDbType.Float).Value = (object)mnLabourSGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsIGSTTotal", SqlDbType.Float).Value = (object)mnPartsIGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourIGSTTotal", SqlDbType.Float).Value = (object)mnLabourIGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalSGST", SqlDbType.Float).Value = (object)mnTotalSGST ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalCGST", SqlDbType.Float).Value = (object)mnTotalCGST ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalIGST", SqlDbType.Float).Value = (object)mnTotalIGST ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalTax", SqlDbType.Float).Value = (object)mnTotalTax ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalAmount", SqlDbType.Float).Value = (object)mnTotalAmount ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@GrandTotal", SqlDbType.Float).Value = (object)mnGrandTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@DiscountAmount", SqlDbType.Float).Value = (object)mnDiscountAmount ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@InvoiceTotal", SqlDbType.Float).Value = (object)mnInvoiceTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@InvoiceRemarks", SqlDbType.VarChar).Value = (object)msInvoiceRemarks ?? DBNull.Value;

                        Cmd.Parameters.AddWithValue("@Created", SqlDbType.DateTime).Value = DateTime.Now;
                        Cmd.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = MasterMechUtil.sUserID;

                        mnInvoiceSNo = (int)Cmd.ExecuteScalar();  // Getting InvoiceSNo to Update in line Items
                        Cmd.Parameters.Clear();

                        foreach (InvoiceItem lObjItem in lObjInvoiceList)
                        {
                            lObjItem.Constr = MasterMechUtil.Constr;
                            lObjItem.UserID = MasterMechUtil.sUserID;
                            lObjItem.InvoiceSNo = (int)mnInvoiceSNo;
                            if (!lObjItem.SaveInvcItm())
                            {
                                lObjTransc.Rollback();
                                lObjCon.Close();
                                return false;
                            }
                        }
                        lObjTransc.Commit();
                        lObjCon.Close();
                    }
                    catch (SqlException ex)
                    {
                        MasterMechUtil.ShowError(ex.Message);
                        lObjTransc.Rollback();
                        lObjCon.Close();
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        lsQryInput = "Update  [Invoice" + MasterMechUtil.sFY + "]  SET  VehicleRegNo=@VehicleRegNo, VehicleModel=@VehicleModel," +
                            "ChassisNo=@ChassisNo, EngineNo=@EngineNo, Mileage=@Mileage, ServiceType=@ServiceType, ServiceAssoName=@ServiceAssoName," +
                            "ServiceAssoMobNo=@ServiceAssoMobNo, PartsTotal=@PartsTotal, LabourTotal=@LabourTotal, PartsCGSTTotal=@PartsCGSTTotal," +
                            "LabourCGSTTotal=@LabourCGSTTotal, PartsSGSTTotal=@PartsSGSTTotal, LabourSGSTTotal=@LabourSGSTTotal, PartsIGSTTotal=@PartsIGSTTotal," +
                            "LabourIGSTTotal=@LabourIGSTTotal, TotalSGST=@TotalSGST, TotalCGST=@TotalCGST,TotalIGST=@TotalIGST," +
                            "TotalTax=@TotalTax, TotalAmount=@TotalAmount, GrandTotal=@GrandTotal, DiscountAmount=@DiscountAmount," +
                            "InvoiceTotal=@InvoiceTotal, InvoiceRemarks=@InvoiceRemarks, Modified=@Modified,ModifiedBy=@ModifiedBy " +
                            "Where InvoiceSNo=@InvoiceSNo";


                        var sds = Cmd.CommandText = lsQryInput;
                        Cmd.CommandType = CommandType.Text;


                       //Cmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.Int).Value = mnInvoiceSNo;
                        
                        Cmd.Parameters.AddWithValue("@VehicleRegNo", SqlDbType.VarChar).Value = (object)msVehicleRegNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@VehicleModel", SqlDbType.VarChar).Value = (object)msVehicleModel ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ChassisNo", SqlDbType.VarChar).Value = (object)msChassisNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@EngineNo", SqlDbType.VarChar).Value = (object)msEngineNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@Mileage", SqlDbType.Int).Value = (object)mnMileage ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ServiceType", SqlDbType.VarChar).Value = (object)msServiceType ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ServiceAssoName", SqlDbType.VarChar).Value = (object)msServiceAssoName ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@ServiceAssoMobNo", SqlDbType.VarChar).Value = (object)msServiceAssoMobNo ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsTotal", SqlDbType.Float).Value = (object)mnPartsTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourTotal", SqlDbType.Float).Value = (object)mnLabourTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsCGSTTotal", SqlDbType.Float).Value = (object)mnPartsCGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourCGSTTotal", SqlDbType.Float).Value = (object)mnLabourCGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsSGSTTotal", SqlDbType.Float).Value = (object)mnPartsSGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourSGSTTotal", SqlDbType.Float).Value = (object)mnLabourSGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@PartsIGSTTotal", SqlDbType.Float).Value = (object)mnPartsIGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@LabourIGSTTotal", SqlDbType.Float).Value = (object)mnLabourIGSTTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalSGST", SqlDbType.Float).Value = (object)mnTotalSGST ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalCGST", SqlDbType.Float).Value = (object)mnTotalCGST ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalIGST", SqlDbType.Float).Value = (object)mnTotalIGST ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalTax", SqlDbType.Float).Value = (object)mnTotalTax ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@TotalAmount", SqlDbType.Float).Value = (object)mnTotalAmount ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@GrandTotal", SqlDbType.Float).Value = (object)mnGrandTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@DiscountAmount", SqlDbType.Float).Value = (object)mnDiscountAmount ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@InvoiceTotal", SqlDbType.Float).Value = (object)mnInvoiceTotal ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@InvoiceRemarks", SqlDbType.VarChar).Value = (object)msInvoiceRemarks ?? DBNull.Value;
                        Cmd.Parameters.AddWithValue("@Modified", SqlDbType.DateTime).Value = DateTime.Now;
                        Cmd.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = MasterMechUtil.sUserID;

                        Cmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.Int).Value = mnInvoiceSNo;

                        Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();


                        foreach (InvoiceItem lObjItm in lObjInvoiceList)
                        {
                            lObjItm.InvoiceSNo = mnInvoiceSNo;
                            if (!lObjItm.SaveInvcItm())
                            {
                                lObjTransc.Rollback();
                                lObjCon.Close();
                                return false;
                            }
                        }
                        lObjTransc.Commit();
                        lObjCon.Close();
                    }
                    catch (Exception ex)
                    {
                        // MasterMechUtil.ShowError(ex.Message);
                        return false;
                    }
                }
                return true;
            }
        }


        public bool LoadInvc(int inInvoiceNo)
        {

            string lsQryLdInvc = " ";
            try
            {
                using (SqlConnection lObjConne = new SqlConnection(Constr))
                {
                    lsQryLdInvc = "SELECT InvoiceSNo,InvoiceDate,InvoiceSts,CustNo,CustFName,CustLName,CustMobNo," +
                        "CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity,CustState,CustPinCode,CustCountry," +
                        "CustGSTNo,CustlLastVisit,CustRemarks,VehicleRegNo,VehicleModel,ChassisNo,EngineNo,Mileage," +
                        "ServiceType,ServiceAssoName,ServiceAssoMobNo,PartsTotal,LabourTotal,PartsCGSTTotal,LabourCGSTTotal," +
                        "PartsSGSTTotal,LabourSGSTTotal,PartsIGSTTotal,LabourIGSTTotal,TotalSGST,TotalCGST,TotalIGST," +
                        "TotalTax,TotalAmount,GrandTotal,DiscountAmount,InvoiceTotal,InvoiceRemarks,Created,CreatedBy,Modified," +
                        "ModifiedBy From  [Invoice" + MasterMechUtil.sFY + "] Where InvoiceSNo=@SNo  And Deleted = 'N'";

                    SqlCommand lObjCmd = new SqlCommand(lsQryLdInvc, lObjConne);
                    lObjCmd.CommandType = CommandType.Text;
                    lObjCmd.Parameters.AddWithValue("@SNo", SqlDbType.Int).Value = inInvoiceNo;
                    lObjConne.Open();


                    using (SqlDataReader lObjRd = lObjCmd.ExecuteReader())
                    {
                        if (lObjRd.HasRows)
                        {
                            while (lObjRd.Read())
                            {
                                //InvoiceSNo = Convert.ToString(lObjRd["InnvoiceNo"]);
                                mnInvoiceSNo = Convert.ToInt32(lObjRd["InvoiceSNo"]);
                                mdInvoiceDate = Convert.ToDateTime(lObjRd["InvoiceDate"]);
                                msInvoiceSts = lObjRd["InvoiceSts"].ToString();
                                mnCustNo = Convert.ToInt32(lObjRd["CustNo"]);
                                msCustFName = lObjRd["CustFName"].ToString();
                                msCustLName = lObjRd["CustLName"].ToString();
                                msCustMobNo = lObjRd["CustMobNo"].ToString();
                                msCustEmail = lObjRd["CustEmail"].ToString();
                                msCustSts = lObjRd["CustSts"].ToString();
                                msCustType = DBNull.Value.Equals(lObjRd["CustType"]) ? null : lObjRd["CustType"].ToString();
                                msCustStAddr = DBNull.Value.Equals(lObjRd["CustStAddr"]) ? null : lObjRd["CustStAddr"].ToString();
                                msCustArAddr = DBNull.Value.Equals(lObjRd["CustArAddr"]) ? null : lObjRd["CustArAddr"].ToString();
                                msCustCity = DBNull.Value.Equals(lObjRd["CustCity"]) ? null : lObjRd["CustCity"].ToString();
                                msCustState = DBNull.Value.Equals(lObjRd["CustState"]) ? null : lObjRd["CustState"].ToString();
                                msCustPinCode = lObjRd["CustPinCode"].ToString();
                                msCustCountry = DBNull.Value.Equals(lObjRd["CustCountry"]) ? null : lObjRd["CustCountry"].ToString();
                                msCustGSTNo = DBNull.Value.Equals(lObjRd["CustGSTNo"]) ? null : lObjRd["CustGSTNo"].ToString();
                                mdCustlLastVisit = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["CustlLastVisit"]) ? null : lObjRd["CustlLastVisit"]);
                                msCustRemarks = DBNull.Value.Equals(lObjRd["CustRemarks"]) ? null : lObjRd["CustRemarks"].ToString();
                                msVehicleRegNo = DBNull.Value.Equals(lObjRd["VehicleRegNo"]) ? null : lObjRd["VehicleRegNo"].ToString();
                                msVehicleModel = DBNull.Value.Equals(lObjRd["VehicleModel"]) ? null : lObjRd["VehicleModel"].ToString();
                                msChassisNo = DBNull.Value.Equals(lObjRd["ChassisNo"]) ? null : lObjRd["ChassisNo"].ToString();
                                msEngineNo = DBNull.Value.Equals(lObjRd["EngineNo"]) ? null : lObjRd["EngineNo"].ToString();
                                mnMileage = Convert.ToInt32(DBNull.Value.Equals(lObjRd["Mileage"]) ? null : lObjRd["Mileage"]);
                                msServiceType = DBNull.Value.Equals(lObjRd["ServiceType"]) ? null : lObjRd["ServiceType"].ToString();
                                msServiceAssoName = DBNull.Value.Equals(lObjRd["ServiceAssoName"]) ? null : lObjRd["ServiceAssoName"].ToString();
                                msServiceAssoMobNo = DBNull.Value.Equals(lObjRd["ServiceAssoMobNo"]) ? null : lObjRd["ServiceAssoMobNo"].ToString();
                                mnPartsTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsTotal"]) ? null : lObjRd["PartsTotal"]);
                                mnLabourTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourTotal"]) ? null : lObjRd["LabourTotal"]);
                                mnPartsCGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsCGSTTotal"]) ? null : lObjRd["PartsCGSTTotal"]);
                                mnLabourCGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourCGSTTotal"]) ? null : lObjRd["LabourCGSTTotal"]);
                                mnPartsSGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsSGSTTotal"]) ? null : lObjRd["PartsSGSTTotal"]);
                                mnLabourSGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourSGSTTotal"]) ? null : lObjRd["LabourSGSTTotal"]);
                                mnPartsIGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsIGSTTotal"]) ? null : lObjRd["PartsIGSTTotal"]);
                                mnLabourIGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourIGSTTotal"]) ? null : lObjRd["LabourIGSTTotal"]);
                                mnTotalSGST = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalSGST"]) ? null : lObjRd["TotalSGST"]);
                                mnTotalCGST = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalCGST"]) ? null : lObjRd["TotalCGST"]);
                                mnTotalIGST = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalIGST"]) ? null : lObjRd["TotalIGST"]);
                                mnTotalTax = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalTax"]) ? null : lObjRd["TotalTax"]);
                                mnTotalAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalAmount"]) ? null : lObjRd["TotalAmount"]);
                                mnGrandTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["GrandTotal"]) ? null : lObjRd["GrandTotal"]);
                                mnDiscountAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRd["DiscountAmount"]) ? null : lObjRd["DiscountAmount"]);
                                mnInvoiceTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["InvoiceTotal"]) ? null : lObjRd["InvoiceTotal"]);
                                msInvoiceRemarks = DBNull.Value.Equals(lObjRd["InvoiceRemarks"]) ? null : lObjRd["InvoiceRemarks"].ToString();
                                mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["Created"]) ? null : lObjRd["Created"]);
                                msCreatedBy = DBNull.Value.Equals(lObjRd["CreatedBy"]) ? null : lObjRd["CreatedBy"].ToString();
                                mdModified = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["Modified"]) ? null : lObjRd["Modified"]);
                                msModifiedBy = DBNull.Value.Equals(lObjRd["ModifiedBy"]) ? null : lObjRd["ModifiedBy"].ToString();

                            }
                        }
                        else
                            return false;
                    }
                }

            }
            catch (SqlException ex)
            {
                return false;
            }
            InvoiceItem lObjItemInvc = new InvoiceItem();
            lObjItemInvc.SrchItem(mnInvoiceSNo.ToString(), lObjInvoiceList);
            return true;
        }


        public bool Save2()
        {
            Invoice lObjInv = new Invoice();
            String lsSavQry = " ";
            try
            {
                using (SqlConnection lObjSveCn = new SqlConnection(MasterMechUtil.Constr))
                {
                    lsSavQry = "Insert Into Customer (CustFName,CustLName,CustMobNo,CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity," +
                        "CustState,CustPinCode,CustCountry,CustGSTNo,CustlLastVisit,CustRemarks,Created,CreatedBy,Deleted)OUTPUT INSERTED.CustNo Values(@CustFName,@CustLName,@CustMobNo," +
                        "@CustEmail,@CustSts,@CustType,@CustStAddr,@CustArAddr," +
                        "@CustCity,@CustState,@CustPinCode,@CustCountry,@CustGSTNo," +
                        "@CustlLastVisit,@CustRemarks,@Created,@CreatedBy,'N')";

                    SqlCommand lObjCmdSave = new SqlCommand(lsSavQry, lObjSveCn);
                    lObjCmdSave.CommandType = CommandType.Text;
                    lObjSveCn.Open();


                    lObjCmdSave.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = msCustFName;
                    lObjCmdSave.Parameters.AddWithValue("@CustLName", SqlDbType.VarChar).Value = lObjInv.msCustLName;
                    lObjCmdSave.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = lObjInv.msCustMobNo;
                    lObjCmdSave.Parameters.AddWithValue("@CustEmail", SqlDbType.VarChar).Value = lObjInv.msCustEmail;
                    lObjCmdSave.Parameters.AddWithValue("@CustSts", SqlDbType.VarChar).Value = lObjInv.msCustSts;
                    lObjCmdSave.Parameters.AddWithValue("@CustType", SqlDbType.Char).Value = lObjInv.msCustType;
                    lObjCmdSave.Parameters.AddWithValue("@CustStAddr", SqlDbType.VarChar).Value = (object)lObjInv.msCustStAddr ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustArAddr", SqlDbType.VarChar).Value = (object)msCustArAddr ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustCity", SqlDbType.VarChar).Value = (object)lObjInv.msCustCity ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustState", SqlDbType.VarChar).Value = (object)lObjInv.msCustState ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustPinCode", SqlDbType.Char).Value = (object)lObjInv.msCustPinCode ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustCountry", SqlDbType.VarChar).Value = (object)lObjInv.msCustCountry ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustGSTNo", SqlDbType.VarChar).Value = (object)lObjInv.msCustGSTNo ?? DBNull.Value;
                    //  lObjCmdSave.Parameters.AddWithValue("@CustlLastVisit", SqlDbType.DateTime).Value = (object)lobjDataCst.mdCustlLastVisit ?? DBNull.Value;


                    lObjCmdSave.Parameters.AddWithValue("@CustlLastVisit", SqlDbType.DateTime).Value = DateTime.Now;
                    lObjCmdSave.Parameters.AddWithValue("@CustRemarks", SqlDbType.VarChar).Value = (object)lObjInv.msCustRemarks ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = (object)MasterMechUtil.sUserID ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@Created", SqlDbType.DateTime).Value = DateTime.Now;

                    mnCustNo = (int)lObjCmdSave.ExecuteScalar(); // Note :- Is Equivalent to ExecuteNonQuery();



                    //lObjCmdSave.ExecuteNonQuery();

                    // lObjSveCn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


        public bool LoadInvcData(int inInvoiceNo)
        {

            string lsQryLdInvc = " ";
            try
            {
                using (SqlConnection lObjConne = new SqlConnection(MasterMechUtil.Constr))
                {
                    lsQryLdInvc = "SELECT InnvoiceNo,InvoiceSNo,InvoiceDate,InvoiceSts,CustNo,CustFName,CustLName,CustMobNo," +
                        "CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity,CustState,CustPinCode,CustCountry," +
                        "CustGSTNo,CustlLastVisit,CustRemarks,VehicleRegNo,VehicleModel,ChassisNo,EngineNo,Mileage," +
                        "ServiceType,ServiceAssoName,ServiceAssoMobNo,PartsTotal,LabourTotal,PartsCGSTTotal,LabourCGSTTotal," +
                        "PartsSGSTTotal,LabourSGSTTotal,PartsIGSTTotal,LabourIGSTTotal,TotalSGST,TotalCGST,TotalIGST," +
                        "TotalTax,TotalAmount,GrandTotal,DiscountAmount,InvoiceTotal,InvoiceRemarks,Created,CreatedBy,Modified," +
                        "ModifiedBy From  [Invoice" + MasterMechUtil.sFY + "] Where InvoiceSNo=@SNo  And Deleted = 'N'";

                    SqlCommand lObjCmd = new SqlCommand(lsQryLdInvc, lObjConne);
                    lObjCmd.CommandType = CommandType.Text;
                    lObjCmd.Parameters.AddWithValue("@SNo", SqlDbType.Int).Value = inInvoiceNo;
                    lObjConne.Open();


                    using (SqlDataReader lObjRd = lObjCmd.ExecuteReader())
                    {
                        if (lObjRd.HasRows)
                        {
                            while (lObjRd.Read())
                            {
                                InvoiceSNo = Convert.ToString(lObjRd["InnvoiceNo"]);
                                mnInvoiceSNo = Convert.ToInt32(lObjRd["InvoiceSNo"]);
                                mdInvoiceDate = Convert.ToDateTime(lObjRd["InvoiceDate"]);
                                msInvoiceSts = lObjRd["InvoiceSts"].ToString();
                                mnCustNo = Convert.ToInt32(lObjRd["CustNo"]);
                                msCustFName = lObjRd["CustFName"].ToString();
                                msCustLName = lObjRd["CustLName"].ToString();
                                msCustMobNo = lObjRd["CustMobNo"].ToString();
                                msCustEmail = lObjRd["CustEmail"].ToString();
                                msCustSts = lObjRd["CustSts"].ToString();
                                msCustType = DBNull.Value.Equals(lObjRd["CustType"]) ? null : lObjRd["CustType"].ToString();
                                msCustStAddr = DBNull.Value.Equals(lObjRd["CustStAddr"]) ? null : lObjRd["CustStAddr"].ToString();
                                msCustArAddr = DBNull.Value.Equals(lObjRd["CustArAddr"]) ? null : lObjRd["CustArAddr"].ToString();
                                msCustCity = DBNull.Value.Equals(lObjRd["CustCity"]) ? null : lObjRd["CustCity"].ToString();
                                msCustState = DBNull.Value.Equals(lObjRd["CustState"]) ? null : lObjRd["CustState"].ToString();
                                msCustPinCode = lObjRd["CustPinCode"].ToString();
                                msCustCountry = DBNull.Value.Equals(lObjRd["CustCountry"]) ? null : lObjRd["CustCountry"].ToString();
                                msCustGSTNo = DBNull.Value.Equals(lObjRd["CustGSTNo"]) ? null : lObjRd["CustGSTNo"].ToString();
                                mdCustlLastVisit = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["CustlLastVisit"]) ? null : lObjRd["CustlLastVisit"]);
                                msCustRemarks = DBNull.Value.Equals(lObjRd["CustRemarks"]) ? null : lObjRd["CustRemarks"].ToString();
                                msVehicleRegNo = DBNull.Value.Equals(lObjRd["VehicleRegNo"]) ? null : lObjRd["VehicleRegNo"].ToString();
                                msVehicleModel = DBNull.Value.Equals(lObjRd["VehicleModel"]) ? null : lObjRd["VehicleModel"].ToString();
                                msChassisNo = DBNull.Value.Equals(lObjRd["ChassisNo"]) ? null : lObjRd["ChassisNo"].ToString();
                                msEngineNo = DBNull.Value.Equals(lObjRd["EngineNo"]) ? null : lObjRd["EngineNo"].ToString();
                                mnMileage = Convert.ToInt32(DBNull.Value.Equals(lObjRd["Mileage"]) ? null : lObjRd["Mileage"]);
                                msServiceType = DBNull.Value.Equals(lObjRd["ServiceType"]) ? null : lObjRd["ServiceType"].ToString();
                                msServiceAssoName = DBNull.Value.Equals(lObjRd["ServiceAssoName"]) ? null : lObjRd["ServiceAssoName"].ToString();
                                msServiceAssoMobNo = DBNull.Value.Equals(lObjRd["ServiceAssoMobNo"]) ? null : lObjRd["ServiceAssoMobNo"].ToString();
                                mnPartsTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsTotal"]) ? null : lObjRd["PartsTotal"]);
                                mnLabourTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourTotal"]) ? null : lObjRd["LabourTotal"]);
                                mnPartsCGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsCGSTTotal"]) ? null : lObjRd["PartsCGSTTotal"]);
                                mnLabourCGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourCGSTTotal"]) ? null : lObjRd["LabourCGSTTotal"]);
                                mnPartsSGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsSGSTTotal"]) ? null : lObjRd["PartsSGSTTotal"]);
                                mnLabourSGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourSGSTTotal"]) ? null : lObjRd["LabourSGSTTotal"]);
                                mnPartsIGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["PartsIGSTTotal"]) ? null : lObjRd["PartsIGSTTotal"]);
                                mnLabourIGSTTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["LabourIGSTTotal"]) ? null : lObjRd["LabourIGSTTotal"]);
                                mnTotalSGST = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalSGST"]) ? null : lObjRd["TotalSGST"]);
                                mnTotalCGST = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalCGST"]) ? null : lObjRd["TotalCGST"]);
                                mnTotalIGST = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalIGST"]) ? null : lObjRd["TotalIGST"]);
                                mnTotalTax = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalTax"]) ? null : lObjRd["TotalTax"]);
                                mnTotalAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRd["TotalAmount"]) ? null : lObjRd["TotalAmount"]);
                                mnGrandTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["GrandTotal"]) ? null : lObjRd["GrandTotal"]);
                                mnDiscountAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRd["DiscountAmount"]) ? null : lObjRd["DiscountAmount"]);
                                mnInvoiceTotal = Convert.ToDouble(DBNull.Value.Equals(lObjRd["InvoiceTotal"]) ? null : lObjRd["InvoiceTotal"]);
                                msInvoiceRemarks = DBNull.Value.Equals(lObjRd["InvoiceRemarks"]) ? null : lObjRd["InvoiceRemarks"].ToString();
                                mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["Created"]) ? null : lObjRd["Created"]);
                                msCreatedBy = DBNull.Value.Equals(lObjRd["CreatedBy"]) ? null : lObjRd["CreatedBy"].ToString();
                                mdModified = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["Modified"]) ? null : lObjRd["Modified"]);
                                msModifiedBy = DBNull.Value.Equals(lObjRd["ModifiedBy"]) ? null : lObjRd["ModifiedBy"].ToString();
                            }
                        }
                        else
                            return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
            InvoiceItem lObjItemInvc = new InvoiceItem();
            lObjItemInvc.SrchItem(mnInvoiceSNo.ToString(), lObjInvoiceList);
            return true;
        }


    }
}






