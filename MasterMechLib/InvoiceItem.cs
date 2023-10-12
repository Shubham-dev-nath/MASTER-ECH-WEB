using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace MasterMechLib
{
    public class InvoiceItem
    {
        public int? InvoiceItemSNo { get; set; }
        public int? InvoiceSNo { get; set; }
        public int? ItemNo { get; set; }
        public string ItemDesc { get; set; }
        public string ItemType { get; set; }
        public string ItemCatg { get; set; }
        public double? ItemPrice { get; set; }
        public string ItemUOM { get; set; }
        public string ItemSts { get; set; }
        public double? CGSTRate { get; set; }
        public double? SGSTRate { get; set; }
        public double? IGSTRate { get; set; }
        public string UPCCode { get; set; }
        public string HSNCode { get; set; }
        public string SACCode { get; set; }
        public double? Qty { get; set; }
        public double? SGSTAmount { get; set; }
        public double? CGSTAmount { get; set; }
        public double? IGSTAmount { get; set; }
        [Display(Name = "Discount Amt")]
        public double? DiscountAmount { get; set; }
        public double? TotalAmount { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public char? Deleted { get; set; }
        public DateTime DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string UserID { get; set; }
        public string Constr { get; set; }
        InvoiceItem iObjItem { get; set; }

        MasterMechLib.MasterMechUtil.OPMode LineMode;

        public InvoiceItem()
        {

        }

        // Note-Copy Constructor Data Coimng From Invoice Form From Method name InvoiceListData ...
        public InvoiceItem(InvoiceItem iObjItem)
        {
            ItemNo = iObjItem.ItemNo;
            ItemDesc = iObjItem.ItemDesc;
            ItemType = iObjItem.ItemType;
            ItemCatg = iObjItem.ItemCatg;
            ItemPrice = iObjItem.ItemPrice;
            ItemUOM = iObjItem.ItemUOM;
            ItemSts = iObjItem.ItemSts;
            CGSTRate = iObjItem.CGSTRate;
            SGSTRate = iObjItem.SGSTRate;
            IGSTRate = iObjItem.IGSTRate;
            UPCCode = iObjItem.UPCCode;
            SACCode = iObjItem.SACCode;
            HSNCode = iObjItem.HSNCode;
            Qty = iObjItem.Qty;
            SGSTAmount = iObjItem.SGSTAmount;
            IGSTAmount = iObjItem.IGSTAmount;
            CGSTAmount = iObjItem.CGSTAmount;
            DiscountAmount = iObjItem.DiscountAmount;
            TotalAmount = iObjItem.TotalAmount;
            UserID = iObjItem.UserID;
        }


        public InvoiceItem(int inItemNo, string isItemDesc,
              string isItemType, double inItemPrice, string isItemUOM, string isItemSts,
              string isItemCatg, string isUPCCode, string isSACCode, string isHSNCode,
              double inQty, double inSGSTRate, double inSGSTAmount, double inCGSTRate,
              double inCGSTAmount, double inIGSTRate, double inIGSTAmount, double inDiscountAmount,
              double inTotalAmount)
        {

        }

        public bool LoadInvcItem(string isConstr, int inItemNo)
        {
            string lsQryLod;

            try
            {
                using (SqlConnection lObjCon = new SqlConnection(isConstr))
                {
                    lsQryLod = "Select InvoiceItemSNo,InvoiceSNo,ItemNo,ItemDesc,ItemType,ItemCatg,ItemPrice,ItemUOM,ItemSts," +
                        "CGSTRate,SGSTRate,IGSTRate,UPCCode,HSNCode,SACCode,Qty,SGSTAmount,CGSTAmount,IGSTAmount," +
                        "DiscountAmount,TotalAmount,Created,CreatedBy,Modified,ModifiedBy " +
                        "From [InvoiceItem" + MasterMechUtil.sFY + "]  Where  ItemNo=@ItemNo AND Deleted='N'";

                    SqlCommand lObjCmd = new SqlCommand(isConstr, lObjCon);
                    lObjCmd.CommandType = CommandType.Text;

                    lObjCmd.Parameters.AddWithValue("@ItemNo", SqlDbType.Int).Value = inItemNo;
                    lObjCon.Open();


                    using (SqlDataReader lObjRead = lObjCmd.ExecuteReader())
                    {
                        if (lObjRead.HasRows)
                        {
                            while (lObjRead.Read())
                            {
                                InvoiceItemSNo = Convert.ToInt32(lObjRead["InvoiceItemSNo"]);
                                InvoiceSNo = Convert.ToInt32(lObjRead["InvoiceSNo"]);
                                ItemNo = Convert.ToInt32(lObjRead["ItemNo"]);
                                ItemDesc = lObjRead["ItemDesc"].ToString();
                                ItemType = lObjRead["ItemType"].ToString();
                                ItemCatg = lObjRead["ItemCatg"].ToString();
                                ItemPrice = Convert.ToInt32(lObjRead["ItemPrice"]);
                                ItemUOM = lObjRead["ItemUOM"].ToString();
                                ItemSts = lObjRead["ItemSts"].ToString();
                                CGSTRate = Convert.ToInt32(DBNull.Value.Equals(lObjRead["CGSTRate"]) ? null : lObjRead["CGSTRate"]);
                                SGSTRate = Convert.ToInt32(DBNull.Value.Equals(lObjRead["SGSTRate"]) ? null : lObjRead["SGSTRate"]);
                                IGSTRate = Convert.ToInt32(DBNull.Value.Equals(lObjRead["IGSTRate"]) ? null : lObjRead["IGSTRate"]);
                                UPCCode = DBNull.Value.Equals(lObjRead["UPCCode"]) ? null : lObjRead["UPCCode"].ToString();
                                HSNCode = DBNull.Value.Equals(lObjRead["HSNCode"]) ? null : lObjRead["HSNCode"].ToString();
                                SACCode = DBNull.Value.Equals(lObjRead["SACCode"]) ? null : lObjRead["SACCode"].ToString();
                                Qty = Convert.ToInt32(DBNull.Value.Equals(lObjRead["Qty"]) ? null : lObjRead["Qty"]);
                                SGSTAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRead["SGSTAmount"]) ? null : lObjRead["SGSTAmount"]);
                                CGSTAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRead["CGSTAmount"]) ? null : lObjRead["CGSTAmount"]);
                                IGSTAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRead["IGSTAmount"]) ? null : lObjRead["IGSTAmount"]);
                                DiscountAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRead["DiscountAmount"]) ? null : lObjRead["DiscountAmount"]);
                                TotalAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRead["TotalAmount"]) ? null : lObjRead["TotalAmount"]);
                                Created = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Created"]) ? null : lObjRead["Created"]);
                                CreatedBy = DBNull.Value.Equals(lObjRead["CreatedBy"]) ? null : lObjRead["CreatedBy"].ToString();
                                Modified = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Modified"]) ? null : lObjRead["Modified"]);
                                ModifiedBy = DBNull.Value.Equals(lObjRead["ModifiedBy"]) ? null : lObjRead["ModifiedBy"].ToString();
                                Deleted = Convert.ToChar(DBNull.Value.Equals(lObjRead["Deleted"]) ? null : lObjRead["Deleted"]);
                                DeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["DeletedOn"]) ? null : lObjRead["DeletedOn"]);
                                DeletedBy = DBNull.Value.Equals(lObjRead["DeletedBy"]) ? null : lObjRead["DeletedBy"].ToString();
                            }
                        }
                        lObjRead.Close();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }


        public InvoiceItem(string isUserID, string isConstr)
        {
            this.UserID = isUserID;
            this.Constr = isConstr;
        }


        public InvoiceItem(int inInvoiceSNo, int inItemNo, string isItemDesc, string isItemType, string isItemCatg, double inItemPrice,
                           string isItemUOM, string isItemSts, double inCGSTRate, double inSGSTRate, double inIGSTRate, string isUPCCode, string isHSNCode,
                           string isSACCode, double inQty, double inSGSTAmount, double inCGSTAmount, double inIGSTAmount, double inDiscountAmount, double inTotalAmount,
                            DateTime idCreated, string isCreatedBy, DateTime idModified, string isModifiedBy)
        {

        }

        public bool SaveInvcItem(SqlCommand lObjCmmd)
        {
            // InvoiceItemSNo = invItSno;
            string lsDataInput = " ";
            if (InvoiceItemSNo == null)
            {
                try
                {
                    lsDataInput = "INSERT Into [InvoiceItem" + MasterMechUtil.sFY + "] (InvoiceSNo,ItemNo,ItemDesc,ItemType,ItemCatg," +
                        "ItemPrice,ItemUOM,ItemSts,CGSTRate,SGSTRate,IGSTRate,UPCCode,HSNCode,SACCode,Qty,SGSTAmount,CGSTAmount," +
                        "IGSTAmount,DiscountAmount,TotalAmount,Created,CreatedBy,Deleted) Values(@InvoiceSNo,@ItemNo,@ItemDesc,@ItemType," +
                        "@ItemCatg,@ItemPrice,@ItemUOM,@ItemSts,@CGSTRate,@SGSTRate,@IGSTRate,@UPCCode,@HSNCode,@SACCode,@Qty," +
                        "@SGSTAmount,@CGSTAmount,@IGSTAmount,@DiscountAmount,@TotalAmount,@Created,@CreatedBy,'N')";

                    lObjCmmd.CommandText = lsDataInput;
                    lObjCmmd.CommandType = CommandType.Text;

                    lObjCmmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.Int).Value = InvoiceSNo;
                    lObjCmmd.Parameters.AddWithValue("@ItemNo", SqlDbType.Int).Value = ItemNo;
                    lObjCmmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = ItemDesc;
                    lObjCmmd.Parameters.AddWithValue("@ItemType", SqlDbType.VarChar).Value = ItemType;
                    lObjCmmd.Parameters.AddWithValue("@ItemCatg", SqlDbType.VarChar).Value = ItemCatg;
                    lObjCmmd.Parameters.AddWithValue("@ItemPrice", SqlDbType.Float).Value = ItemPrice;
                    lObjCmmd.Parameters.AddWithValue("@ItemUOM", SqlDbType.VarChar).Value = ItemUOM;
                    lObjCmmd.Parameters.AddWithValue("@ItemSts", SqlDbType.VarChar).Value = ItemSts;
                    lObjCmmd.Parameters.AddWithValue("@CGSTRate", SqlDbType.Float).Value = (object)CGSTRate ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@SGSTRate", SqlDbType.Float).Value = (object)SGSTRate ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@IGSTRate", SqlDbType.Float).Value = (object)IGSTRate ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@UPCCode", SqlDbType.VarChar).Value = (object)UPCCode ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@HSNCode", SqlDbType.VarChar).Value = (object)HSNCode ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@SACCode", SqlDbType.VarChar).Value = (object)SACCode ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@Qty", SqlDbType.Float).Value = (object)Qty ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@SGSTAmount", SqlDbType.Float).Value = (object)SGSTAmount ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@CGSTAmount", SqlDbType.Float).Value = (object)CGSTAmount ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@IGSTAmount", SqlDbType.Float).Value = (object)IGSTAmount ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@DiscountAmount", SqlDbType.Float).Value = (object)DiscountAmount ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@TotalAmount", SqlDbType.Float).Value = (object)TotalAmount ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@Created", SqlDbType.DateTime).Value = DateTime.Now;
                    lObjCmmd.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = MasterMechUtil.sUserID;


                    lObjCmmd.ExecuteNonQuery();
                    lObjCmmd.Parameters.Clear();
                }
                catch (SqlException ex)
                {
                    MasterMechUtil.ShowError(ex.Message);
                    return false;
                }

            }
            else if (InvoiceItemSNo != null) // && LineMode == MasterMechUtil.OPMode.Open)
            {
                try
                {
                    lsDataInput = "Update [InvoiceItem" + MasterMechUtil.sFY + "] SET ItemNo=@ItemNo,ItemDesc=@ItemDesc," +
                        "ItemType=@ItemType,ItemCatg=@ItemCatg,ItemPrice=@ItemPrice,ItemUOM=@ItemUOM,ItemSts=@ItemSts,CGSTRate=@CGSTRate," +
                        "SGSTRate=@SGSTRate,IGSTRate=@IGSTRate,UPCCode=UPCCode,HSNCode=@HSNCode,SACCode=@SACCode," +
                        "Qty=@Qty,SGSTAmount=@SGSTAmount,CGSTAmount=@CGSTAmount,IGSTAmount=@IGSTAmount,DiscountAmount=@DiscountAmount," +
                        "TotalAmount=@TotalAmount,Modified=@Modified,ModifiedBy=@ModifiedBy Where Deleted='N' AND InvoiceItemSNo=@InvoiceItemSNo";

                    lObjCmmd.CommandText = lsDataInput;
                    lObjCmmd.CommandType = CommandType.Text;


                    lObjCmmd.Parameters.AddWithValue("@InvoiceItemSNo", SqlDbType.Int).Value = InvoiceItemSNo;
                    lObjCmmd.Parameters.AddWithValue("@ItemNo", SqlDbType.Int).Value = ItemNo;
                    lObjCmmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = ItemDesc;
                    lObjCmmd.Parameters.AddWithValue("@ItemType", SqlDbType.VarChar).Value = ItemType;
                    lObjCmmd.Parameters.AddWithValue("@ItemCatg", SqlDbType.VarChar).Value = ItemCatg;
                    lObjCmmd.Parameters.AddWithValue("@ItemPrice", SqlDbType.Float).Value = ItemPrice;
                    lObjCmmd.Parameters.AddWithValue("@ItemUOM", SqlDbType.VarChar).Value = ItemUOM;
                    lObjCmmd.Parameters.AddWithValue("@ItemSts", SqlDbType.VarChar).Value = ItemSts;
                    lObjCmmd.Parameters.AddWithValue("@CGSTRate", SqlDbType.Float).Value = (object)CGSTRate ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@SGSTRate", SqlDbType.Float).Value = (object)SGSTRate ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@IGSTRate", SqlDbType.Float).Value = (object)IGSTRate ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@UPCCode", SqlDbType.VarChar).Value = (object)UPCCode ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@HSNCode", SqlDbType.VarChar).Value = (object)HSNCode ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@SACCode", SqlDbType.VarChar).Value = (object)SACCode ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@Qty", SqlDbType.Float).Value = (object)Qty ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@SGSTAmount", SqlDbType.Float).Value = (object)SGSTAmount ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@CGSTAmount", SqlDbType.Float).Value = (object)CGSTAmount ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@IGSTAmount", SqlDbType.Float).Value = (object)IGSTAmount ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@DiscountAmount", SqlDbType.Float).Value = (object)DiscountAmount ?? DBNull.Value;
                    lObjCmmd.Parameters.AddWithValue("@TotalAmount", SqlDbType.Float).Value = TotalAmount;
                    lObjCmmd.Parameters.AddWithValue("@Modified", SqlDbType.DateTime).Value = DateTime.Now;
                    lObjCmmd.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = (object)UserID ?? DBNull.Value;

                    lObjCmmd.ExecuteNonQuery();
                    lObjCmmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    // MasterMechUtil.ShowError(ex.Message);
                    return false;
                }

            }
            else if (LineMode == MasterMechLib.MasterMechUtil.OPMode.Delete)
            {
                DeleteInvcItems(lObjCmmd);
            }
            return true;
        }

        public bool DeleteInvcItem()
        {
            try
            {
                using (SqlConnection lObjConnec = new SqlConnection(MasterMechUtil.Constr))
                {
                    string lsDelItem = "Update [InvoiceItem" + MasterMechLib.MasterMechUtil.sFY + "] SET Deleted='Y'," +
                        "DeletedOn=@DeletedOn,DeletedBy=@DeletedBy Where  InvoiceItemSNo=@InvoiceItemSNo";

                    SqlCommand lObjCmmd = new SqlCommand(lsDelItem, lObjConnec);
                    lObjCmmd.CommandType = CommandType.Text;
                    lObjConnec.Open();

                    lObjCmmd.Parameters.AddWithValue("@InvoiceItemSNo", SqlDbType.Int).Value = InvoiceItemSNo;
                    lObjCmmd.Parameters.AddWithValue("@DeletedOn", SqlDbType.DateTime).Value = DateTime.Now;
                    lObjCmmd.Parameters.AddWithValue("@DeletedBy", SqlDbType.VarChar).Value = UserID;


                    lObjCmmd.ExecuteNonQuery();
                    // lObjConnec.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool DeleteInvcItems(SqlCommand lObjCmd)
        {
            try
            {
                using (SqlConnection lObjConnec = new SqlConnection(MasterMechUtil.Constr))
                {
                    string lsDelItem = "Update [InvoiceItem" + MasterMechLib.MasterMechUtil.sFY + "] SET Deleted='Y'," +
                        "DeletedOn=@DeletedOn,DeletedBy=@DeletedBy Where  InvoiceSNo=@InvoiceSNo";

                    SqlCommand lObjCmmd = new SqlCommand(lsDelItem, lObjConnec);
                    lObjCmmd.CommandType = CommandType.Text;

                    lObjCmmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.Int).Value = InvoiceSNo;
                    lObjCmmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.Int).Value = ItemDesc;
                    lObjCmmd.Parameters.AddWithValue("@DeletedOn", SqlDbType.DateTime).Value = DateTime.Now;
                    lObjCmmd.Parameters.AddWithValue("@DeletedBy", SqlDbType.VarChar).Value = MasterMechUtil.sUserID;

                    lObjConnec.Open();
                    lObjCmmd.ExecuteNonQuery();
                    // lObjConnec.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool SearchInvcItem(string ItemDesc)
        {
            try
            {
                using (SqlConnection lObjCtn = new SqlConnection(MasterMechUtil.Constr))
                {
                    string lsSrchItm = "Select InvoiceItemSNo,InvoiceSNo,ItemNo,ItemDesc,ItemType,ItemCatg,ItemPrice," +
                        "ItemUOM,ItemSts,CGSTRate,SGSTRate,IGSTRate,UPCCode,HSNCode,SACCode,Qty,SGSTAmount,CGSTAmount," +
                        "IGSTAmount,DiscountAmount,TotalAmount,Created,CreatedBy,Modified,ModifiedBy From InvoiceItem"
                        + MasterMechUtil.sFY + " Where ItemDesc Like  @ItemDesc";

                    SqlCommand lObjSqlCmd = new SqlCommand(lsSrchItm, lObjCtn);
                    lObjSqlCmd.CommandType = CommandType.Text;
                    lObjCtn.Open();


                    lObjSqlCmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = "%" + ItemDesc + "%";


                    using (SqlDataReader lObjRead = lObjSqlCmd.ExecuteReader())
                    {
                        if (lObjRead.HasRows)
                        {
                            while (lObjRead.Read())
                            {
                                InvoiceItemSNo = Convert.ToInt32(lObjRead["InvoiceItemSNo"]);
                                InvoiceSNo = Convert.ToInt32(lObjRead["InvoiceSNo"]);
                                ItemNo = Convert.ToInt32(lObjRead["ItemNo"]);
                                ItemDesc = lObjRead["ItemDesc"].ToString();
                                ItemType = lObjRead["ItemType"].ToString();
                                ItemCatg = lObjRead["ItemCatg"].ToString();
                                ItemPrice = Convert.ToDouble(lObjRead["ItemPrice"]);
                                ItemUOM = lObjRead["ItemUOM"].ToString();
                                ItemSts = lObjRead["ItemSts"].ToString();
                                CGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["CGSTRate"]) ? null : lObjRead["CGSTRate"]);
                                SGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["SGSTRate"]) ? null : lObjRead["SGSTRate"]);
                                IGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["IGSTRate"]) ? null : lObjRead["IGSTRate"]);
                                UPCCode = DBNull.Value.Equals(lObjRead["UPCCode"]) ? null : lObjRead["UPCCode"].ToString();
                                HSNCode = DBNull.Value.Equals(lObjRead["HSNCode"]) ? null : lObjRead["HSNCode"].ToString();
                                SACCode = DBNull.Value.Equals(lObjRead["SACCode"]) ? null : lObjRead["SACCode"].ToString();
                                Qty = Convert.ToDouble(DBNull.Value.Equals(lObjRead["Qty"]) ? null : lObjRead["Qty"].ToString());
                                SGSTAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRead["SGSTAmount"]) ? null : lObjRead["SGSTAmount"]);
                                CGSTAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRead["CGSTAmount"]) ? null : lObjRead["CGSTAmount"]);
                                IGSTAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRead["IGSTAmount"]) ? null : lObjRead["IGSTAmount"]);
                                DiscountAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRead["DiscountAmount"]) ? null : lObjRead["DiscountAmount"]);
                                TotalAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRead["TotalAmount"]) ? null : lObjRead["TotalAmount"]);
                                Created = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Created"]) ? null : lObjRead["Created"]);
                                CreatedBy = DBNull.Value.Equals(lObjRead["CreatedBy"]) ? null : lObjRead["CreatedBy"].ToString();
                                Modified = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Modified"]) ? null : lObjRead["Modified"]);
                                ModifiedBy = DBNull.Value.Equals(lObjRead["ModifiedBy"]) ? null : lObjRead["ModifiedBy"].ToString();


                                lObjRead.Close();
                            }
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool SrchItem(string InvoiceSNo, List<InvoiceItem> oObjItemSNoSrchList)
        {
            try
            {
                using (SqlConnection lObjCtn = new SqlConnection(MasterMechUtil.Constr))
                {
                    string lsSrchItm = "Select InvoiceItemSNo,InvoiceSNo,ItemNo,ItemDesc,ItemType,ItemCatg,ItemPrice," +
                        "ItemUOM,ItemSts,CGSTRate,SGSTRate,IGSTRate,UPCCode,HSNCode,SACCode,Qty,SGSTAmount,CGSTAmount," +
                        "IGSTAmount,DiscountAmount,TotalAmount,Created,CreatedBy,Modified,ModifiedBy From [InvoiceItem" + MasterMechUtil.sFY +
                        "] Where InvoiceSNo=@InvoiceSNo And Deleted='N'";

                    SqlCommand lObjSqlCmd = new SqlCommand(lsSrchItm, lObjCtn);
                    lObjSqlCmd.CommandType = CommandType.Text;
                    lObjCtn.Open();


                    lObjSqlCmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.VarChar).Value = InvoiceSNo;


                    using (SqlDataReader lObjRead = lObjSqlCmd.ExecuteReader())
                    {
                        if (lObjRead.HasRows)
                        {
                            while (lObjRead.Read())
                            {
                                InvoiceItemSNo = Convert.ToInt32(lObjRead["InvoiceItemSNo"]);
                                InvoiceSNo = lObjRead["InvoiceSNo"].ToString();
                                ItemNo = Convert.ToInt32(lObjRead["ItemNo"]);
                                ItemDesc = lObjRead["ItemDesc"].ToString();
                                ItemType = lObjRead["ItemType"].ToString();
                                ItemCatg = lObjRead["ItemCatg"].ToString();
                                ItemPrice = Convert.ToDouble(lObjRead["ItemPrice"]);
                                ItemUOM = lObjRead["ItemUOM"].ToString();
                                ItemSts = lObjRead["ItemSts"].ToString();
                                CGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["CGSTRate"]) ? null : lObjRead["CGSTRate"]);
                                SGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["SGSTRate"]) ? null : lObjRead["SGSTRate"]);
                                IGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["IGSTRate"]) ? null : lObjRead["IGSTRate"]);
                                UPCCode = DBNull.Value.Equals(lObjRead["UPCCode"]) ? null : lObjRead["UPCCode"].ToString();
                                HSNCode = DBNull.Value.Equals(lObjRead["HSNCode"]) ? null : lObjRead["HSNCode"].ToString();
                                SACCode = DBNull.Value.Equals(lObjRead["SACCode"]) ? null : lObjRead["SACCode"].ToString();
                                Qty = Convert.ToDouble(DBNull.Value.Equals(lObjRead["Qty"]) ? null : lObjRead["Qty"].ToString());
                                SGSTAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRead["SGSTAmount"]) ? null : lObjRead["SGSTAmount"]);
                                CGSTAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRead["CGSTAmount"]) ? null : lObjRead["CGSTAmount"]);
                                IGSTAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRead["IGSTAmount"]) ? null : lObjRead["IGSTAmount"]);
                                DiscountAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRead["DiscountAmount"]) ? null : lObjRead["DiscountAmount"]);
                                TotalAmount = Convert.ToDouble(DBNull.Value.Equals(lObjRead["TotalAmount"]) ? null : lObjRead["TotalAmount"]);
                                Created = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Created"]) ? null : lObjRead["Created"]);
                                CreatedBy = DBNull.Value.Equals(lObjRead["CreatedBy"]) ? null : lObjRead["CreatedBy"].ToString();
                                Modified = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Modified"]) ? null : lObjRead["Modified"]);
                                ModifiedBy = DBNull.Value.Equals(lObjRead["ModifiedBy"]) ? null : lObjRead["ModifiedBy"].ToString();

                                InvoiceItem lObjItemOfInvc = new InvoiceItem();
                                lObjItemOfInvc.InvoiceItemSNo = InvoiceItemSNo;
                                lObjItemOfInvc.InvoiceSNo = Convert.ToInt32(InvoiceSNo);
                                lObjItemOfInvc.ItemNo = ItemNo;
                                lObjItemOfInvc.ItemDesc = ItemDesc;
                                lObjItemOfInvc.ItemType = ItemType;
                                lObjItemOfInvc.ItemCatg = ItemCatg;
                                lObjItemOfInvc.ItemPrice = ItemPrice;
                                lObjItemOfInvc.ItemUOM = ItemUOM;
                                lObjItemOfInvc.ItemSts = ItemSts;
                                lObjItemOfInvc.CGSTRate = CGSTRate;
                                lObjItemOfInvc.SGSTRate = SGSTRate;
                                lObjItemOfInvc.IGSTRate = IGSTRate;
                                lObjItemOfInvc.UPCCode = UPCCode;
                                lObjItemOfInvc.HSNCode = HSNCode;
                                lObjItemOfInvc.SACCode = SACCode;
                                lObjItemOfInvc.Qty = Qty;
                                lObjItemOfInvc.SGSTAmount = SGSTAmount;
                                lObjItemOfInvc.CGSTAmount = CGSTAmount;
                                lObjItemOfInvc.IGSTAmount = IGSTAmount;
                                lObjItemOfInvc.DiscountAmount = DiscountAmount;
                                lObjItemOfInvc.TotalAmount = TotalAmount;
                                oObjItemSNoSrchList.Add(lObjItemOfInvc);


                                // lObjRead.Close();
                            }
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool LodInvItem(int inInvoiceItmSNo)
        {
            string lsQryLod = " ";

            try
            {
                using (SqlConnection lObjCon = new SqlConnection(MasterMechUtil.Constr))
                {
                    lsQryLod = "Select InvoiceItemSNo,InvoiceSNo,ItemNo,ItemDesc,ItemType,ItemCatg,ItemPrice,ItemUOM,ItemSts," +
                        "CGSTRate,SGSTRate,IGSTRate,UPCCode,HSNCode,SACCode,Qty,SGSTAmount,CGSTAmount,IGSTAmount," +
                        "DiscountAmount,TotalAmount,Created,CreatedBy,Modified,ModifiedBy  Where  ItemNo=@ItemNo AND Deleted='N'";

                    SqlCommand lObjCmd = new SqlCommand(lsQryLod, lObjCon);
                    lObjCmd.CommandType = CommandType.Text;

                    lObjCmd.Parameters.AddWithValue("@ItemNo", SqlDbType.Int).Value = inInvoiceItmSNo;
                    lObjCon.Open();


                    using (SqlDataReader lObjRead = lObjCmd.ExecuteReader())
                    {
                        if (lObjRead.HasRows)
                        {
                            while (lObjRead.Read())
                            {
                                InvoiceItemSNo = Convert.ToInt32(lObjRead["InvoiceItemSNo"]);
                                InvoiceSNo = Convert.ToInt32(lObjRead["InvoiceSNo"]);
                                ItemNo = Convert.ToInt32(lObjRead["ItemNo"]);
                                ItemDesc = lObjRead["ItemDesc"].ToString();
                                ItemType = lObjRead["ItemType"].ToString();
                                ItemCatg = lObjRead["ItemCatg"].ToString();
                                ItemPrice = Convert.ToInt32(lObjRead["ItemPrice"]);
                                ItemUOM = lObjRead["ItemUOM"].ToString();
                                ItemSts = lObjRead["ItemSts"].ToString();
                                CGSTRate = Convert.ToInt32(DBNull.Value.Equals(lObjRead["CGSTRate"]) ? null : lObjRead["CGSTRate"]);
                                SGSTRate = Convert.ToInt32(DBNull.Value.Equals(lObjRead["SGSTRate"]) ? null : lObjRead["SGSTRate"]);
                                IGSTRate = Convert.ToInt32(DBNull.Value.Equals(lObjRead["IGSTRate"]) ? null : lObjRead["IGSTRate"]);
                                UPCCode = DBNull.Value.Equals(lObjRead["UPCCode"]) ? null : lObjRead["UPCCode"].ToString();
                                HSNCode = DBNull.Value.Equals(lObjRead["HSNCode"]) ? null : lObjRead["HSNCode"].ToString();
                                SACCode = DBNull.Value.Equals(lObjRead["SACCode"]) ? null : lObjRead["SACCode"].ToString();
                                Qty = Convert.ToInt32(DBNull.Value.Equals(lObjRead["Qty"]) ? null : lObjRead["Qty"]);
                                SGSTAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRead["SGSTAmount"]) ? null : lObjRead["SGSTAmount"]);
                                CGSTAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRead["CGSTAmount"]) ? null : lObjRead["CGSTAmount"]);
                                IGSTAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRead["IGSTAmount"]) ? null : lObjRead["IGSTAmount"]);
                                DiscountAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRead["DiscountAmount"]) ? null : lObjRead["DiscountAmount"]);
                                TotalAmount = Convert.ToInt32(DBNull.Value.Equals(lObjRead["TotalAmount"]) ? null : lObjRead["TotalAmount"]);
                                Created = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Created"]) ? null : lObjRead["Created"]);
                                CreatedBy = DBNull.Value.Equals(lObjRead["CreatedBy"]) ? null : lObjRead["CreatedBy"].ToString();
                                Modified = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Modified"]) ? null : lObjRead["Modified"]);
                                ModifiedBy = DBNull.Value.Equals(lObjRead["ModifiedBy"]) ? null : lObjRead["ModifiedBy"].ToString();
                                Deleted = Convert.ToChar(DBNull.Value.Equals(lObjRead["Deleted"]) ? null : lObjRead["Deleted"]);
                                DeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["DeletedOn"]) ? null : lObjRead["DeletedOn"]);
                                DeletedBy = DBNull.Value.Equals(lObjRead["DeletedBy"]) ? null : lObjRead["DeletedBy"].ToString();

                            }
                        }
                        lObjRead.Close();
                        return true;
                    }

                }
            }
            catch
            {
                return false;
            }
        }



        // For Web Save 

        public bool SaveInvcItm()
        {
            //InvoiceItemSNo = invItSno;

            using (SqlConnection lObjCon = new SqlConnection(MasterMechUtil.Constr))
            {
                lObjCon.Open();

                SqlCommand lObjCmmd = new SqlCommand();
                lObjCmmd.Connection = lObjCon;


                string lsDataInput = " ";
                if (InvoiceItemSNo == null)
                {
                    try
                    {
                        lsDataInput = "INSERT Into [InvoiceItem" + MasterMechUtil.sFY + "] (InvoiceSNo,ItemNo,ItemDesc,ItemType,ItemCatg," +
                            "ItemPrice,ItemUOM,ItemSts,CGSTRate,SGSTRate,IGSTRate,UPCCode,HSNCode,SACCode,Qty,SGSTAmount,CGSTAmount," +
                            "IGSTAmount,DiscountAmount,TotalAmount,Created,CreatedBy,Deleted) Values(@InvoiceSNo,@ItemNo,@ItemDesc,@ItemType," +
                            "@ItemCatg,@ItemPrice,@ItemUOM,@ItemSts,@CGSTRate,@SGSTRate,@IGSTRate,@UPCCode,@HSNCode,@SACCode,@Qty," +
                            "@SGSTAmount,@CGSTAmount,@IGSTAmount,@DiscountAmount,@TotalAmount,@Created,@CreatedBy,'N')";

                        lObjCmmd.CommandText = lsDataInput;
                        lObjCmmd.CommandType = CommandType.Text;

                        lObjCmmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.Int).Value = InvoiceSNo;
                        lObjCmmd.Parameters.AddWithValue("@ItemNo", SqlDbType.Int).Value = ItemNo;
                        lObjCmmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = ItemDesc;
                        lObjCmmd.Parameters.AddWithValue("@ItemType", SqlDbType.VarChar).Value = ItemType;
                        lObjCmmd.Parameters.AddWithValue("@ItemCatg", SqlDbType.VarChar).Value = ItemCatg;
                        lObjCmmd.Parameters.AddWithValue("@ItemPrice", SqlDbType.Float).Value = ItemPrice;
                        lObjCmmd.Parameters.AddWithValue("@ItemUOM", SqlDbType.VarChar).Value = ItemUOM;
                        lObjCmmd.Parameters.AddWithValue("@ItemSts", SqlDbType.VarChar).Value = ItemSts;
                        lObjCmmd.Parameters.AddWithValue("@CGSTRate", SqlDbType.Float).Value = (object)CGSTRate ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@SGSTRate", SqlDbType.Float).Value = (object)SGSTRate ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@IGSTRate", SqlDbType.Float).Value = (object)IGSTRate ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@UPCCode", SqlDbType.VarChar).Value = (object)UPCCode ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@HSNCode", SqlDbType.VarChar).Value = (object)HSNCode ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@SACCode", SqlDbType.VarChar).Value = (object)SACCode ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@Qty", SqlDbType.Float).Value = (object)Qty ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@SGSTAmount", SqlDbType.Float).Value = (object)SGSTAmount ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@CGSTAmount", SqlDbType.Float).Value = (object)CGSTAmount ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@IGSTAmount", SqlDbType.Float).Value = (object)IGSTAmount ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@DiscountAmount", SqlDbType.Float).Value = (object)DiscountAmount ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@TotalAmount", SqlDbType.Float).Value = (object)TotalAmount ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@Created", SqlDbType.DateTime).Value = DateTime.Now;
                        lObjCmmd.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = MasterMechUtil.sUserID;


                        lObjCmmd.ExecuteNonQuery();
                        //lObjCmmd.Parameters.Clear();
                    }
                    catch (SqlException ex)
                    {
                        MasterMechUtil.ShowError(ex.Message);
                        return false;
                    }
                }
                else if (InvoiceItemSNo != null) // && LineMode == MasterMechUtil.OPMode.Open)
                {
                    try
                    {
                        lsDataInput = "Update [InvoiceItem" + MasterMechUtil.sFY + "] SET ItemNo=@ItemNo,ItemDesc=@ItemDesc," +
                            "ItemType=@ItemType,ItemCatg=@ItemCatg,ItemPrice=@ItemPrice,ItemUOM=@ItemUOM,ItemSts=@ItemSts,CGSTRate=@CGSTRate," +
                            "SGSTRate=@SGSTRate,IGSTRate=@IGSTRate,UPCCode=UPCCode,HSNCode=@HSNCode,SACCode=@SACCode," +
                            "Qty=@Qty,SGSTAmount=@SGSTAmount,CGSTAmount=@CGSTAmount,IGSTAmount=@IGSTAmount,DiscountAmount=@DiscountAmount," +
                            "TotalAmount=@TotalAmount,Modified=@Modified,ModifiedBy=@ModifiedBy Where Deleted='N' AND InvoiceItemSNo=@InvoiceItemSNo";

                        lObjCmmd.CommandText = lsDataInput;
                        lObjCmmd.CommandType = CommandType.Text;


                        lObjCmmd.Parameters.AddWithValue("@InvoiceItemSNo", SqlDbType.Int).Value = InvoiceItemSNo;
                        lObjCmmd.Parameters.AddWithValue("@ItemNo", SqlDbType.Int).Value = ItemNo;
                        lObjCmmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = ItemDesc;
                        lObjCmmd.Parameters.AddWithValue("@ItemType", SqlDbType.VarChar).Value = ItemType;
                        lObjCmmd.Parameters.AddWithValue("@ItemCatg", SqlDbType.VarChar).Value = ItemCatg;
                        lObjCmmd.Parameters.AddWithValue("@ItemPrice", SqlDbType.Float).Value = ItemPrice;
                        lObjCmmd.Parameters.AddWithValue("@ItemUOM", SqlDbType.VarChar).Value = ItemUOM;
                        lObjCmmd.Parameters.AddWithValue("@ItemSts", SqlDbType.VarChar).Value = ItemSts;
                        lObjCmmd.Parameters.AddWithValue("@CGSTRate", SqlDbType.Float).Value = (object)CGSTRate ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@SGSTRate", SqlDbType.Float).Value = (object)SGSTRate ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@IGSTRate", SqlDbType.Float).Value = (object)IGSTRate ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@UPCCode", SqlDbType.VarChar).Value = (object)UPCCode ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@HSNCode", SqlDbType.VarChar).Value = (object)HSNCode ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@SACCode", SqlDbType.VarChar).Value = (object)SACCode ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@Qty", SqlDbType.Float).Value = (object)Qty ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@SGSTAmount", SqlDbType.Float).Value = (object)SGSTAmount ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@CGSTAmount", SqlDbType.Float).Value = (object)CGSTAmount ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@IGSTAmount", SqlDbType.Float).Value = (object)IGSTAmount ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@DiscountAmount", SqlDbType.Float).Value = (object)DiscountAmount ?? DBNull.Value;
                        lObjCmmd.Parameters.AddWithValue("@TotalAmount", SqlDbType.Float).Value = TotalAmount;
                        lObjCmmd.Parameters.AddWithValue("@Modified", SqlDbType.DateTime).Value = DateTime.Now;
                        lObjCmmd.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = MasterMechUtil.sUserID;

                        lObjCmmd.ExecuteNonQuery();
                        //lObjCmmd.Parameters.Clear();
                    }
                    catch (Exception ex)
                    {
                        // MasterMechUtil.ShowError(ex.Message);
                        return false;
                    }
                }
                else if (LineMode == MasterMechLib.MasterMechUtil.OPMode.Delete)
                {
                    DeleteInvcItems(lObjCmmd);
                }
                return true;
            }
        }
    }
}

