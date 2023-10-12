using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;
using System.Reflection.Emit;
using System.Globalization;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterMechLib
{
    public class ItemClass
    {

        // Fields of Item.

        [Display(Name = "Item No")]
      //[Required(ErrorMessage = "Please enter ")]
        public int mnItemNo { get; set; }

        [Display(Name = "Item Desc")]
        [StringLength(50)]
        [Required(ErrorMessage = "Item Description Not Given")]
        public string msItemDesc { get; set; }

        [Display(Name = "Type")]
        [StringLength(10)]
        [Required(ErrorMessage = "Item Type Not Given")]
        public string msItemType { get; set; }

        [Display(Name = "Category")]
        [StringLength(10)]
        [Required(ErrorMessage = "Item Category Not Given")]
        public string msItemCatg { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Item Price Not Given")]
        public double? mnItemPrice { get; set; }

        [Display(Name = "Item UOM")]
        [Required(ErrorMessage = "Item UOM Not Given")]
        public string msItemUOM { get; set; }

        [Display(Name = "Item Status")]
        [StringLength(10)]
        [Required(ErrorMessage = "Item Status Not Given")]
        public string msItemSts { get; set; }

        [Display(Name = "CGST Rate")]
        public double? mnCGSTRate { get; set; }

        [Display(Name = "SGST Rate")]
        public double? mnSGSTRate { get; set; }

        [Display(Name = "IGST Rate")]
        public double? mnIGSTRate { get; set; }

        [Display(Name = "UPCCode")]
        public string msUPCCode { get; set; }

        [Display(Name = "HSNCode")]
        public string msHSNCode { get; set; }

        [Display(Name = "SACCode")]
        public string msSACCode { get; set; }

        [Display(Name = "Quantity Hand")]
        public double? mnQtyHand { get; set; }

        [Display(Name = "ReOrder Level")]
        public double? mnReOrderLvl { get; set; }

        [Display(Name = "ReOrder Quantity")]
        public double? mnReorderQty { get; set; }

        [Display(Name = "No of Parts")]
        public int? mnNoOfParts { get; set; }

        [Display(Name = "Remarks")]
        public string msItemRemarks { get; set; }

        [Display(Name = "Created")]
        public DateTime? mdCreated { get; set; }

        [Display(Name = "Created By")]
        public string msCreatedBy { get; set; }

        [Display(Name = "Modified Time")]
        public DateTime? mdModified { get; set; }

        [Display(Name = "Modified By")]
        public string msModifiedBy { get; set; }

        [Display(Name = "Deleted")]
        public char mcDeleted { get; set; }

        [Display(Name = "Deleted Time")]
        public DateTime? mdDeletedOn { get; set; }

        [Display(Name = "Deleted By")]
        public string msDeletedBy { get; set; }

        // public string Constr;

        public void ComboAddData(List<String> lObjCtgrylst)
        {

            // List<String> lObjCtgrylst = new List<string>();
            lObjCtgrylst.Add("ENGN");
            lObjCtgrylst.Add("BODY");
            lObjCtgrylst.Add("DRIVE");
            lObjCtgrylst.Add("ELECT");
            lObjCtgrylst.Add("FRAME");
            lObjCtgrylst.Add("SUSPN");
            lObjCtgrylst.Add("BRAKE");
        }


        public ItemClass()
        {

        }

        //A Connection String

        public string Constr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MasterMech;Data Source=MASOOD\\SQLEXPRESSMSD";

        //Fields which are required in item is passed in a constructor.

        ItemClass(string isItemDesc, string isItemType, string isItemUOM, string isItemSts)
        {
            this.msItemDesc = isItemDesc;
            this.msItemType = isItemType;
            this.msItemUOM = isItemUOM;
            this.msItemSts = isItemSts;
        }


        //Load the Data from the database based on ItemNo Choosed.

        public bool LoadItem(string isConstr, string inItemDesc)
        {
            using (SqlConnection lObjCon = new SqlConnection(MasterMechUtil.Constr))
            {
                string lsQryLd = "Select ItemNo,ItemDesc,ItemType,ItemCatg,ItemPrice,ItemUOM,ItemSts,CGSTRate," +
                    "SGSTRate,IGSTRate,UPCCode,HSNCode,SACCode,QtyHand,ReOrderLvl,ReorderQty,NoOfParts," +
                    "ItemRemarks,Created,CreatedBy," +
                    "Modified,ModifiedBy,Deleted,DeletedOn,DeletedBy " +
                    "From ItemMaster Where ItemDesc Like @ItemDesc AND Deleted='N'";

                SqlCommand lObjCmd = new SqlCommand(lsQryLd, lObjCon);
                lObjCmd.CommandType = CommandType.Text;

                lObjCmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = "%" + inItemDesc + "%";

                lObjCon.Open();
                using (SqlDataReader lObjRead = lObjCmd.ExecuteReader())
                {
                    if (lObjRead.HasRows)
                    {
                        while (lObjRead.Read())
                        {
                            mnItemNo = Convert.ToInt32(lObjRead["ItemNo"].ToString());
                            msItemDesc = lObjRead["ItemDesc"].ToString();
                            msItemType = lObjRead["ItemType"].ToString();
                            msItemCatg = lObjRead["ItemCatg"].ToString();
                            mnItemPrice = Convert.ToDouble(lObjRead["ItemPrice"]);
                            msItemUOM = lObjRead["ItemUOM"].ToString();
                            msItemSts = lObjRead["ItemSts"].ToString();
                            mnCGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["CGSTRate"].ToString()) ? null : lObjRead["CGSTRate"]);
                            mnSGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["SGSTRate"].ToString()) ? null : lObjRead["SGSTRate"]);
                            mnIGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["IGSTRate"].ToString()) ? null : lObjRead["IGSTRate"]);
                            msUPCCode = DBNull.Value.Equals(lObjRead["UPCCode"]) ? null : lObjRead["UPCCode"].ToString();
                            msHSNCode = DBNull.Value.Equals(lObjRead["HSNCode"]) ? null : lObjRead["HSNCode"].ToString();
                            msSACCode = DBNull.Value.Equals(lObjRead["SACCode"]) ? null : lObjRead["SACCode"].ToString();
                            mnQtyHand = Convert.ToDouble(DBNull.Value.Equals(lObjRead["QtyHand"]) ? null : lObjRead["QtyHand"]);
                            mnReOrderLvl = Convert.ToDouble(DBNull.Value.Equals(lObjRead["ReOrderLvl"]) ? null : lObjRead["ReOrderLvl"]);
                            mnReorderQty = Convert.ToDouble(DBNull.Value.Equals(lObjRead["ReorderQty"]) ? null : lObjRead["ReorderQty"]);
                            mnNoOfParts = Convert.ToInt32(DBNull.Value.Equals(lObjRead["NoOfParts"]) ? null : lObjRead["NoOfParts"]);
                            msItemRemarks = DBNull.Value.Equals(lObjRead["ItemRemarks"]) ? null : lObjRead["ItemRemarks"].ToString();
                            mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Created"]) ? null : lObjRead["Created"].ToString());
                            msCreatedBy = DBNull.Value.Equals(lObjRead["CreatedBy"]) ? null : lObjRead["CreatedBy"].ToString();


                            if (lObjRead["Modified"].Equals(DBNull.Value))
                            {
                                mdModified = null;
                            }
                            else
                            {
                                mdModified = Convert.ToDateTime(lObjRead["Modified"].ToString());
                            }

                            msModifiedBy = DBNull.Value.Equals(lObjRead["ModifiedBy"]) ? null : lObjRead["ModifiedBy"].ToString();
                            mcDeleted = Convert.ToChar(DBNull.Value.Equals(lObjRead["Deleted"]) ? null : lObjRead["Deleted"].ToString());
                            mdDeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["DeletedOn"]) ? null : lObjRead["DeletedOn"].ToString());
                            msDeletedBy = DBNull.Value.Equals(lObjRead["DeletedBy"]) ? null : lObjRead["DeletedBy"].ToString();
                        }
                        lObjCon.Close();
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        //Load Item For Item In Web
        public bool LoadItm(string isConstr, int ItemNo)
        {
            using (SqlConnection lObjCon = new SqlConnection(MasterMechUtil.Constr))
            {
                string lsQryLd = "Select ItemNo,ItemDesc,ItemType,ItemCatg,ItemPrice,ItemUOM,ItemSts,CGSTRate," +
                    "SGSTRate,IGSTRate,UPCCode,HSNCode,SACCode,QtyHand,ReOrderLvl,ReorderQty,NoOfParts," +
                    "ItemRemarks,Created,CreatedBy," +
                    "Modified,ModifiedBy,Deleted,DeletedOn,DeletedBy " +
                    "From ItemMaster Where ItemNo=@ItemNo AND Deleted='N'";

                SqlCommand lObjCmd = new SqlCommand(lsQryLd, lObjCon);
                lObjCmd.CommandType = CommandType.Text;

                lObjCmd.Parameters.AddWithValue("@ItemNo", SqlDbType.Int).Value =  ItemNo;

                lObjCon.Open();
                using (SqlDataReader lObjRead = lObjCmd.ExecuteReader())
                {
                    if (lObjRead.HasRows)
                    {
                        while (lObjRead.Read())
                        {
                            mnItemNo = Convert.ToInt32(lObjRead["ItemNo"].ToString());
                            msItemDesc = lObjRead["ItemDesc"].ToString();
                            msItemType = lObjRead["ItemType"].ToString();
                            msItemCatg = lObjRead["ItemCatg"].ToString();
                            mnItemPrice = Convert.ToDouble(lObjRead["ItemPrice"]);
                            msItemUOM = lObjRead["ItemUOM"].ToString();
                            msItemSts = lObjRead["ItemSts"].ToString();
                            mnCGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["CGSTRate"].ToString()) ? null : lObjRead["CGSTRate"]);
                            mnSGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["SGSTRate"].ToString()) ? null : lObjRead["SGSTRate"]);
                            mnIGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["IGSTRate"].ToString()) ? null : lObjRead["IGSTRate"]);
                            msUPCCode = DBNull.Value.Equals(lObjRead["UPCCode"]) ? null : lObjRead["UPCCode"].ToString();
                            msHSNCode = DBNull.Value.Equals(lObjRead["HSNCode"]) ? null : lObjRead["HSNCode"].ToString();
                            msSACCode = DBNull.Value.Equals(lObjRead["SACCode"]) ? null : lObjRead["SACCode"].ToString();
                            mnQtyHand = Convert.ToDouble(DBNull.Value.Equals(lObjRead["QtyHand"]) ? null : lObjRead["QtyHand"]);
                            mnReOrderLvl = Convert.ToDouble(DBNull.Value.Equals(lObjRead["ReOrderLvl"]) ? null : lObjRead["ReOrderLvl"]);
                            mnReorderQty = Convert.ToDouble(DBNull.Value.Equals(lObjRead["ReorderQty"]) ? null : lObjRead["ReorderQty"]);
                            mnNoOfParts = Convert.ToInt32(DBNull.Value.Equals(lObjRead["NoOfParts"]) ? null : lObjRead["NoOfParts"]);
                            msItemRemarks = DBNull.Value.Equals(lObjRead["ItemRemarks"]) ? null : lObjRead["ItemRemarks"].ToString();
                            mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Created"]) ? null : lObjRead["Created"].ToString());
                            msCreatedBy = DBNull.Value.Equals(lObjRead["CreatedBy"]) ? null : lObjRead["CreatedBy"].ToString();


                            if (lObjRead["Modified"].Equals(DBNull.Value))
                            {
                                mdModified = null;
                            }
                            else
                            {
                                mdModified = Convert.ToDateTime(lObjRead["Modified"].ToString());
                            }

                            msModifiedBy = DBNull.Value.Equals(lObjRead["ModifiedBy"]) ? null : lObjRead["ModifiedBy"].ToString();
                            mcDeleted = Convert.ToChar(DBNull.Value.Equals(lObjRead["Deleted"]) ? null : lObjRead["Deleted"].ToString());
                            mdDeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["DeletedOn"]) ? null : lObjRead["DeletedOn"].ToString());
                            msDeletedBy = DBNull.Value.Equals(lObjRead["DeletedBy"]) ? null : lObjRead["DeletedBy"].ToString();
                        }
                        lObjCon.Close();
                        return true;
                    }
                    else
                        return false;
                }
            }
        }


        //To Insert and Update the items.

        public bool SaveItem(string isConstrr, string UserID, bool ibMode)
        {
            string lsSaveQry = " ";

            // if(ibMode == true)

            if (ibMode == true)
            {
                lsSaveQry = "INSERT Into ItemMaster(ItemDesc,ItemType,ItemCatg," +
                   "ItemPrice,ItemUOM,ItemSts,CGSTRate,SGSTRate,IGSTRate," +
                   "UPCCode,HSNCode,SACCode,QtyHand,ReOrderLvl,ReorderQty," +
                   "NoOfParts,ItemRemarks,Created,CreatedBy," +
                   "Deleted) Values(@ItemDesc,@ItemType,@ItemCatg," +
                   "@ItemPrice,@ItemUOM,@ItemSts,@CGSTRate,@SGSTRate,@IGSTRate," +
                   "@UPCCode,@HSNCode,@SACCode,@QtyHand,@ReOrderLvl,@ReorderQty," +
                   "@NoOfParts,@ItemRemarks,@Created,@CreatedBy," +
                   "'N')";
            }
            else if (ibMode == false)
            {
                lsSaveQry = "Update ItemMaster Set ItemType=@ItemType,ItemCatg=@ItemCatg," +
                    "ItemPrice=@ItemPrice,ItemUOM=@ItemUOM,ItemSts=@ItemSts,CGSTRate=@CGSTRate,SGSTRate=@SGSTRate,IGSTRate=@IGSTRate," +
                    "UPCCode=@UPCCode,HSNCode=@HSNCode,SACCode=@SACCode,QtyHand=@QtyHand,ReOrderLvl=@ReOrderLvl,ReorderQty=@ReorderQty," +
                    "NoOfParts=@NoOfParts,ItemRemarks=@ItemRemarks,Modified=@Modified,ModifiedBy=@ModifiedBy" +
                    " Where ItemDesc=@ItemDesc AND Deleted='N'";
            }


            using (SqlConnection lObjCn = new SqlConnection(Constr))
            {
                SqlCommand lObjSqlCm = new SqlCommand(lsSaveQry, lObjCn);
                lObjSqlCm.CommandType = CommandType.Text;

                lObjSqlCm.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = msItemDesc;
                lObjSqlCm.Parameters.AddWithValue("@ItemType", SqlDbType.VarChar).Value = msItemType;
                lObjSqlCm.Parameters.AddWithValue("@ItemCatg", SqlDbType.VarChar).Value = msItemCatg;
                lObjSqlCm.Parameters.AddWithValue("@ItemPrice", SqlDbType.Float).Value = mnItemPrice;
                lObjSqlCm.Parameters.AddWithValue("@ItemUOM", SqlDbType.VarChar).Value = msItemUOM;
                lObjSqlCm.Parameters.AddWithValue("@ItemSts", SqlDbType.VarChar).Value = msItemSts;
                lObjSqlCm.Parameters.AddWithValue("@CGSTRate", SqlDbType.Float).Value = (object)mnCGSTRate ?? DBNull.Value;
                lObjSqlCm.Parameters.AddWithValue("@SGSTRate", SqlDbType.Float).Value = (object)mnSGSTRate ?? DBNull.Value;
                lObjSqlCm.Parameters.AddWithValue("@IGSTRate", SqlDbType.Float).Value = (object)mnIGSTRate ?? DBNull.Value;
                lObjSqlCm.Parameters.AddWithValue("@UPCCode", SqlDbType.VarChar).Value = (object)msUPCCode ?? DBNull.Value;
                lObjSqlCm.Parameters.AddWithValue("@HSNCode", SqlDbType.VarChar).Value = (object)msHSNCode ?? DBNull.Value;
                lObjSqlCm.Parameters.AddWithValue("@SACCode", SqlDbType.VarChar).Value = (object)msSACCode ?? DBNull.Value;
                lObjSqlCm.Parameters.AddWithValue("@QtyHand", SqlDbType.VarChar).Value = (object)mnQtyHand ?? DBNull.Value;
                lObjSqlCm.Parameters.AddWithValue("@ReOrderLvl", SqlDbType.Float).Value = (object)mnReOrderLvl ?? DBNull.Value;
                lObjSqlCm.Parameters.AddWithValue("@ReorderQty", SqlDbType.Float).Value = (object)mnReorderQty ?? DBNull.Value;
                lObjSqlCm.Parameters.AddWithValue("@NoOfParts", SqlDbType.Float).Value = (object)mnNoOfParts ?? DBNull.Value;
                lObjSqlCm.Parameters.AddWithValue("@ItemRemarks", SqlDbType.VarChar).Value = (object)msItemRemarks ?? DBNull.Value;


                if (ibMode == false)
                {
                    lObjSqlCm.Parameters.AddWithValue("@ItemNo", SqlDbType.Int).Value = mnItemNo;
                    lObjSqlCm.Parameters.AddWithValue("@Modified", SqlDbType.DateTime).Value = DateTime.Now;
                    lObjSqlCm.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = (object)UserID ?? DBNull.Value;

                }
                else
                {
                    lObjSqlCm.Parameters.AddWithValue("@Created", SqlDbType.DateTime).Value = DateTime.Now;
                    lObjSqlCm.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = (object)UserID ?? DBNull.Value;
                }

                lObjCn.Open();
                lObjSqlCm.ExecuteNonQuery();
                lObjCn.Close();
                lsSaveQry = " ";
            }

            return true;
        }


        // To Update the Deleted Column with 'Y' in order to Assume it is Deleted.

        public bool DeleteItem(string isItemDesc, string isConstr)
        {
            using (SqlConnection lObjDelCon = new SqlConnection(isConstr))
            {
                string lsDelQry = "Update ItemMaster Set Deleted='Y',DeletedOn=@DeletedOn,DeletedBy=@DeletedBy  Where  ItemDesc=@ItemDesc AND Deleted='N'";

                SqlCommand lObjDelCmd = new SqlCommand(lsDelQry, lObjDelCon);
                //lObjDelCmd.Connection = lObjDelCon;
                lObjDelCmd.CommandType = CommandType.Text;
                lObjDelCon.Open();


                lObjDelCmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = isItemDesc;
                lObjDelCmd.Parameters.AddWithValue("@DeletedOn", SqlDbType.DateTime).Value = DateTime.Now;
                lObjDelCmd.Parameters.AddWithValue("@DeletedBy", SqlDbType.VarChar).Value = MasterMechUtil.sUserName;

                lObjDelCmd.ExecuteNonQuery();


                return true;
            }
        }

        //Delete from Web Page Of masterMech

        public bool DeleteItm(int inItemNo, string isConstr)
        {
            using (SqlConnection lObjDelCon = new SqlConnection(isConstr))
            {
                string lsDelQry = "Update ItemMaster Set Deleted='Y',DeletedOn=@DeletedOn,DeletedBy=@DeletedBy  Where  ItemNo=@ItemNo AND Deleted='N'";

                SqlCommand lObjDelCmd = new SqlCommand(lsDelQry, lObjDelCon);
                //lObjDelCmd.Connection = lObjDelCon;
                lObjDelCmd.CommandType = CommandType.Text;
                lObjDelCon.Open();


                lObjDelCmd.Parameters.AddWithValue("@ItemNo", SqlDbType.VarChar).Value = inItemNo;
                lObjDelCmd.Parameters.AddWithValue("@DeletedOn", SqlDbType.DateTime).Value = DateTime.Now;
                lObjDelCmd.Parameters.AddWithValue("@DeletedBy", SqlDbType.VarChar).Value = (object)MasterMechUtil.sUserName ?? DBNull.Value;

                lObjDelCmd.ExecuteNonQuery();


                return true;
            }
        }

        // To search items.

        public bool SearchItem(String isItemDesc, List<ItemClass> lObjItemList)
        {
            using (SqlConnection lObjSrhCnn = new SqlConnection(Constr))
            {
                string lsQrySrch = "Select ItemNo,ItemDesc,ItemType,ItemCatg,ItemPrice,ItemUOM," +
                    "ItemSts,CGSTRate,SGSTRate,IGSTRate,UPCCode,HSNCode,SACCode,QtyHand,ReOrderLvl,ReorderQty," +
                    "NoOfParts,ItemRemarks,Created,CreatedBy,Modified,ModifiedBy,Deleted,DeletedOn,DeletedBy" +
                    " From ItemMaster Where  ItemDesc Like '%" + isItemDesc + "%'  AND Deleted='N'";

                SqlCommand lObjCmdSrh = new SqlCommand(lsQrySrch, lObjSrhCnn);
                lObjCmdSrh.CommandType = CommandType.Text;
                lObjSrhCnn.Open();

               // lObjCmdSrh.Parameters.AddWithValue("@ItemDesc", SqlDbType.Int).Value = isItemDesc;


                using (SqlDataReader lObjRead = lObjCmdSrh.ExecuteReader())
                {
                    if (lObjRead.HasRows)
                    {
                        while (lObjRead.Read())
                        {
                            int lnItmNo = Convert.ToInt32(lObjRead["ItemNo"]);
                            string lsitmDsc = lObjRead["ItemDesc"].ToString();
                            string lsItmTyp = lObjRead["ItemType"].ToString();
                            string lsItmCtg = lObjRead["ItemCatg"].ToString();
                            double? lnitmPrc = Convert.ToDouble(lObjRead["ItemPrice"].ToString());
                            string lsItmUOM = lObjRead["ItemUOM"].ToString();
                            string lsItmSts = lObjRead["ItemSts"].ToString();
                            double? lnCGSrate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["CGSTRate"]) ? null : lObjRead["CGSTRate"]);
                            double? lnSGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["SGSTRate"]) ? null : lObjRead["SGSTRate"]);
                            double? lnIGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["IGSTRate"]) ? null : lObjRead["IGSTRate"]);
                            string lsUPCCode = Convert.ToString(DBNull.Value.Equals(lObjRead["UPCCode"]) ? null : lObjRead["UPCCode"]);
                            string lsHSNCode = Convert.ToString(DBNull.Value.Equals(lObjRead["HSNCode"]) ? null : lObjRead["HSNCode"]);
                            string lsSACCode = Convert.ToString(DBNull.Value.Equals(lObjRead["SACCode"]) ? null : lObjRead["SACCode"]);
                            double? lnQtyHand = Convert.ToDouble(DBNull.Value.Equals(lObjRead["QtyHand"]) ? null : lObjRead["QtyHand"]);
                            double? lnReorderLvl = Convert.ToDouble(DBNull.Value.Equals(lObjRead["ReOrderLvl"]) ? null : lObjRead["ReOrderLvl"]);
                            double? lnReorderQty = Convert.ToDouble(DBNull.Value.Equals(lObjRead["ReorderQty"]) ? null : lObjRead["ReorderQty"]);
                            int? lnNoOfParts = Convert.ToInt32(DBNull.Value.Equals(lObjRead["NoOfParts"]) ? null : lObjRead["NoOfParts"]);
                            string lsItemRmks = Convert.ToString(DBNull.Value.Equals(lObjRead["ItemRemarks"]) ? null : lObjRead["ItemRemarks"]);
                            DateTime? ldCreat = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Created"]) ? null : lObjRead["Created"]);
                            string lsCrtdBy = Convert.ToString(DBNull.Value.Equals(lObjRead["CreatedBy"]) ? null : lObjRead["CreatedBy"]);
                            DateTime ldModified = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Modified"]) ? null : lObjRead["Modified"]);
                            string lsModifiedBy = Convert.ToString(DBNull.Value.Equals(lObjRead["ModifiedBy"]) ? null : lObjRead["ModifiedBy"]);
                            char lcDeleted = Convert.ToChar(DBNull.Value.Equals(lObjRead["Deleted"]) ? null : lObjRead["Deleted"]);
                            DateTime ldDeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["DeletedOn"]) ? null : lObjRead["DeletedOn"]);
                            string lsDeletedBy = Convert.ToString(DBNull.Value.Equals(lObjRead["DeletedBy"]) ? null : lObjRead["DeletedBy"]);


                            ItemClass lObjItmData = new ItemClass(lsitmDsc, lsItmTyp, lsItmUOM, lsItmSts);
                            lObjItmData.mnItemNo = lnItmNo;
                            lObjItmData.msItemType = lsItmTyp;
                            lObjItmData.msItemCatg = lsItmCtg;
                            lObjItmData.mnItemPrice = lnitmPrc;
                            lObjItmData.mnCGSTRate = lnCGSrate;
                            lObjItmData.mnSGSTRate = lnSGSTRate;
                            lObjItmData.mnIGSTRate = lnIGSTRate;
                            lObjItmData.msUPCCode = lsUPCCode;
                            lObjItmData.msHSNCode = lsHSNCode;
                            lObjItmData.msSACCode = lsSACCode;
                            lObjItmData.mnQtyHand = lnQtyHand;
                            lObjItmData.mnReOrderLvl = lnReorderLvl;
                            lObjItmData.mnReorderQty = lnReorderQty;
                            lObjItmData.mnNoOfParts = lnNoOfParts;
                            lObjItmData.msItemRemarks = lsItemRmks;
                            lObjItmData.mdCreated = ldCreat;
                            lObjItmData.msCreatedBy = lsCrtdBy;
                            lObjItmData.mdModified = ldModified;
                            lObjItmData.msModifiedBy = lsModifiedBy;
                            lObjItmData.mcDeleted = lcDeleted;
                            lObjItmData.mdDeletedOn = ldDeletedOn;
                            lObjItmData.msDeletedBy = lsDeletedBy;
                            lObjItemList.Add(lObjItmData);


                            //lObjItemList.Add(new ItemClass(msItemDesc, msItemType, msItemCatg,
                            //mnItemPrice, msItemUOM, msItemSts, mnCGSTRate, mnSGSTRate, mnIGSTRate, msUPCCode,
                            //msHSNCode, msSACCode, mnQtyHand, mnReOrderLvl, mnReorderQty, mnNoOfParts,
                            //msItemRemarks, mdCreated, msCreatedBy, mdModified, msModifiedBy, mcDeleted, mdDeletedOn, msDeletedBy));
                        }
                        lObjSrhCnn.Close();
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        public List<ItemClass> ListItem(String Constr)
        {
            List<ItemClass> lObjItemLi = new List<ItemClass>();
            using (SqlConnection lObjSrhCnn = new SqlConnection(Constr))
            {
                string lsQrySrch = "Select ItemNo,ItemDesc,ItemType,ItemCatg,ItemPrice,ItemUOM," +
                    "ItemSts,CGSTRate,SGSTRate,IGSTRate,UPCCode,HSNCode,SACCode,QtyHand,ReOrderLvl,ReorderQty," +
                    "NoOfParts,ItemRemarks,Created,CreatedBy,Modified,ModifiedBy,Deleted,DeletedOn,DeletedBy" +
                    " From ItemMaster";

                SqlCommand lObjCmdSrh = new SqlCommand(lsQrySrch, lObjSrhCnn);
                lObjCmdSrh.CommandType = CommandType.Text;
                lObjSrhCnn.Open();

                //lObjCmdSrh.Parameters.AddWithValue("@ItemDesc", SqlDbType.Int).Value = isItemDesc;


                using (SqlDataReader lObjRead = lObjCmdSrh.ExecuteReader())
                {
                    if (lObjRead.HasRows)
                    {
                        while (lObjRead.Read())
                        {
                            int lnItmNo = Convert.ToInt32(lObjRead["ItemNo"]);
                            string lsitmDsc = lObjRead["ItemDesc"].ToString();
                            string lsItmTyp = lObjRead["ItemType"].ToString();
                            string lsItmCtg = lObjRead["ItemCatg"].ToString();
                            double? lnitmPrc = Convert.ToDouble(lObjRead["ItemPrice"].ToString());
                            string lsItmUOM = lObjRead["ItemUOM"].ToString();
                            string lsItmSts = lObjRead["ItemSts"].ToString();
                            double? lnCGSrate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["CGSTRate"]) ? null : lObjRead["CGSTRate"]);
                            double? lnSGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["SGSTRate"]) ? null : lObjRead["SGSTRate"]);
                            double? lnIGSTRate = Convert.ToDouble(DBNull.Value.Equals(lObjRead["IGSTRate"]) ? null : lObjRead["IGSTRate"]);
                            string lsUPCCode = Convert.ToString(DBNull.Value.Equals(lObjRead["UPCCode"]) ? null : lObjRead["UPCCode"]);
                            string lsHSNCode = Convert.ToString(DBNull.Value.Equals(lObjRead["HSNCode"]) ? null : lObjRead["HSNCode"]);
                            string lsSACCode = Convert.ToString(DBNull.Value.Equals(lObjRead["SACCode"]) ? null : lObjRead["SACCode"]);
                            double? lnQtyHand = Convert.ToDouble(DBNull.Value.Equals(lObjRead["QtyHand"]) ? null : lObjRead["QtyHand"]);
                            double? lnReorderLvl = Convert.ToDouble(DBNull.Value.Equals(lObjRead["ReOrderLvl"]) ? null : lObjRead["ReOrderLvl"]);
                            double? lnReorderQty = Convert.ToDouble(DBNull.Value.Equals(lObjRead["ReorderQty"]) ? null : lObjRead["ReorderQty"]);
                            int? lnNoOfParts = Convert.ToInt32(DBNull.Value.Equals(lObjRead["NoOfParts"]) ? null : lObjRead["NoOfParts"]);
                            string lsItemRmks = Convert.ToString(DBNull.Value.Equals(lObjRead["ItemRemarks"]) ? null : lObjRead["ItemRemarks"]);
                            DateTime? ldCreat = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Created"]) ? null : lObjRead["Created"]);
                            string lsCrtdBy = Convert.ToString(DBNull.Value.Equals(lObjRead["CreatedBy"]) ? null : lObjRead["CreatedBy"]);
                            DateTime ldModified = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Modified"]) ? null : lObjRead["Modified"]);
                            string lsModifiedBy = Convert.ToString(DBNull.Value.Equals(lObjRead["ModifiedBy"]) ? null : lObjRead["ModifiedBy"]);
                            char lcDeleted = Convert.ToChar(DBNull.Value.Equals(lObjRead["Deleted"]) ? null : lObjRead["Deleted"]);
                            DateTime ldDeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["DeletedOn"]) ? null : lObjRead["DeletedOn"]);
                            string lsDeletedBy = Convert.ToString(DBNull.Value.Equals(lObjRead["DeletedBy"]) ? null : lObjRead["DeletedBy"]);


                            ItemClass lObjItmData = new ItemClass(lsitmDsc, lsItmTyp, lsItmUOM, lsItmSts);
                            lObjItmData.mnItemNo = lnItmNo;
                            lObjItmData.msItemType = lsItmTyp;
                            lObjItmData.msItemCatg = lsItmCtg;
                            lObjItmData.mnItemPrice = lnitmPrc;
                            lObjItmData.mnCGSTRate = lnCGSrate;
                            lObjItmData.mnSGSTRate = lnSGSTRate;
                            lObjItmData.mnIGSTRate = lnIGSTRate;
                            lObjItmData.msUPCCode = lsUPCCode;
                            lObjItmData.msHSNCode = lsHSNCode;
                            lObjItmData.msSACCode = lsSACCode;
                            lObjItmData.mnQtyHand = lnQtyHand;
                            lObjItmData.mnReOrderLvl = lnReorderLvl;
                            lObjItmData.mnReorderQty = lnReorderQty;
                            lObjItmData.mnNoOfParts = lnNoOfParts;
                            lObjItmData.msItemRemarks = lsItemRmks;
                            lObjItmData.mdCreated = ldCreat;
                            lObjItmData.msCreatedBy = lsCrtdBy;
                            lObjItmData.mdModified = ldModified;
                            lObjItmData.msModifiedBy = lsModifiedBy;
                            lObjItmData.mcDeleted = lcDeleted;
                            lObjItmData.mdDeletedOn = ldDeletedOn;
                            lObjItmData.msDeletedBy = lsDeletedBy;
                            lObjItemLi.Add(lObjItmData);


                            //lObjItemList.Add(new ItemClass(msItemDesc, msItemType, msItemCatg,
                            //mnItemPrice, msItemUOM, msItemSts, mnCGSTRate, mnSGSTRate, mnIGSTRate, msUPCCode,
                            //msHSNCode, msSACCode, mnQtyHand, mnReOrderLvl, mnReorderQty, mnNoOfParts,
                            //msItemRemarks, mdCreated, msCreatedBy, mdModified, msModifiedBy, mcDeleted, mdDeletedOn, msDeletedBy));
                        }
                        lObjSrhCnn.Close();
                        return lObjItemLi;
                    }
                    else
                        return lObjItemLi;
                }
            }
        }
    }
}
