using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MasterMechLib.MasterMechUtil;

namespace MasterMechLib
{
    public class Customer
    {
        [Display(Name = "Customer Number")]
       // [Required(ErrorMessage ="Item Number Not Given")]
        public int? mnCustNo { get; set; }
        [Display(Name ="First Name")]
        [StringLength(50)]
        [Required(ErrorMessage ="First Name Not Given")]
        public string msCustFName { get; set; }
        [Display(Name ="Last Name")]
        [StringLength(50)]
        [Required(ErrorMessage ="Last Name Not Given")]
        public string msCustLName { get; set; }
        [Display(Name ="Mobile Number")]
        [StringLength(14)]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string msCustMobNo { get; set; }
        [Display(Name ="Email ID")]
        [StringLength(50)]
        [Required(ErrorMessage = "Email ID Not Given")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        
        public string msCustEmail { get; set; }
        [Display(Name ="Status")]
        [StringLength(10)]
        [Required(ErrorMessage ="Stauts Not Choosen")]
        public string msCustSts { get; set; }
        [Display(Name ="Type")]
        [Required(ErrorMessage ="Type Not Chosen")]
        public string msCustType { get; set; }
        [Display(Name ="Street Address")]
        public string msCustStAddr { get; set; }
        [Display(Name ="Area Address")]
        public string msCustArAddr { get; set; }
        [Display(Name ="City")]
        public string msCustCity { get; set; }
        [Display(Name ="Sate")]
        public string msCustState { get; set; }
        [Display(Name ="Pincode")]
        public string msCustPinCode { get; set; }
        [Display(Name ="Country")]
        public string msCustCountry { get; set; }
        [Display(Name ="GST NO")]
        [Required(ErrorMessage ="Not Valid")]
        public string msCustGSTNo { get; set; }
        [Display(Name ="Last Visit")]
        public DateTime? mdCustlLastVisit { get; set; }
        [Display(Name ="Remarks")]
        public string msCustRemarks { get; set; }
        [Display(Name ="Created")]
        public DateTime? mdCreated { get; set; }
        [Display(Name ="CreatedBy")]
        public string msCreatedBy { get; set; }
        [Display(Name ="Modified")]
        public DateTime? mdModified { get; set; }
        [Display(Name ="ModifiedBy")]
        public string msModifiedBy { get; set; }
        [Display(Name ="Deleted")]
        public char mcDeleted { get; set; }
        [Display(Name ="Deleted On")]
        public DateTime? mdDeletedOn { get; set; }
        [Display(Name ="Deleted By")]
        public string msDeletedBy { get; set; }


        public Customer()
        {
             
        }

        public Customer(string isCustFName,string  isCustLName,string isCustMobNo,string isCustEmail,
            string isCustSts,string icCustType)
        {
            msCustFName = isCustFName;
            msCustLName = isCustLName;
            msCustMobNo = isCustMobNo;
            msCustEmail = isCustEmail;
            msCustSts = isCustSts;
            msCustType = icCustType;

        }

        public static string Constr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MasterMech;Data Source=MASOOD\\SQLEXPRESSMSD";

        //public Customer(int inCustNo,string isCustFName, string isCustLName, string isCustMobNo, string isCustEmail, string isCustSts, 
        //    string iSCustType,string isCustStAddr,string isCustArAddr,string isCustCity,string  isCustState,
        //    string isCustPinCode,string isCustCountry, string isCustGSTNo, DateTime idCustlLastVisit, string isCustRemarks)
        //{
        //    mnCustNo = inCustNo;
        //    msCustFName = isCustFName;
        //    msCustLName = isCustLName;
        //    msCustMobNo = isCustMobNo;
        //    msCustEmail = isCustEmail;
        //    msCustSts = isCustSts;
        //    msCustType = iSCustType;
            
        //    msCustStAddr = isCustStAddr;
        //    msCustArAddr = isCustArAddr;
        //    msCustCity = isCustCity;
        //    msCustState = isCustState;
        //    msCustPinCode = isCustPinCode;
        //    mdCustlLastVisit = idCustlLastVisit;
        //    msCustCountry = isCustCountry;
        //    msCustGSTNo = isCustGSTNo;
        //    msCustRemarks = isCustRemarks;

        //}

        public Customer(string isCustFName, string isCustLName, string isCustMobNo, string isCustEmail, string isCustSts,
          string iSCustType, string isCustStAddr, string isCustArAddr, string isCustCity, string isCustState,
          string isCustPinCode, DateTime idCustlLastVisit, string isCustCountry, string isCustGSTNo, string isCustRemarks, DateTime idCreated,
          string isCreatedBy, DateTime idModified, string isModifiedBy)
        {
            msCustFName = isCustFName;
            msCustLName = isCustLName;
            msCustMobNo = isCustMobNo;
            msCustEmail = isCustEmail;
            msCustSts = isCustSts;
            msCustType = iSCustType;

            msCustStAddr = isCustStAddr;
            msCustArAddr = isCustArAddr;
            msCustCity = isCustCity;
            msCustState = isCustState;
            msCustPinCode = isCustPinCode;
            mdCustlLastVisit = idCustlLastVisit;
            msCustCountry = isCustCountry;
            msCustGSTNo = isCustGSTNo;
            msCustRemarks = isCustRemarks;
            mdCreated = idCreated;
            msCreatedBy = isCreatedBy;
            mdModified = idModified;
            msModifiedBy = isModifiedBy;
        }


        public void ComboBoxAdd(List<String> lObjCustSts,List<string> lObjCstType)
        {
            lObjCustSts.Add("ACTIVE");
            lObjCustSts.Add("PASSIVE");
            lObjCustSts.Add("BLOCKED");
            lObjCstType.Add("IND");
            lObjCstType.Add("BUS");
        }

        // Customer Load In Web MVC
        public bool LoadCust(string isConstr,int inCustNo)
        {
            try
            {
                using (SqlConnection lObjCustCnn = new SqlConnection(isConstr))
                {
                    string lsqQryLoad = "Select CustNo,CustFName,CustLName,CustMobNo," +
                        "CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity,CustState," +
                        "CustPinCode,CustCountry,CustGSTNo,CustlLastVisit,CustRemarks,Created," +
                        "CreatedBy,Modified,ModifiedBy,Deleted,DeletedOn,DeletedBy From Customer Where Deleted='N' And CustNo=@CustNo";

                    SqlCommand lObjCstCmd = new SqlCommand(lsqQryLoad, lObjCustCnn);
                    lObjCstCmd.CommandType = CommandType.Text;
                    lObjCustCnn.Open();

                    lObjCstCmd.Parameters.AddWithValue("@CustNo", SqlDbType.VarChar).Value = inCustNo;

                    using (SqlDataReader lObRe = lObjCstCmd.ExecuteReader())
                    {
                        if (lObRe.HasRows)
                        {
                            while (lObRe.Read())
                            {
                                mnCustNo = Convert.ToInt32(lObRe["CustNo"]);
                                msCustFName = lObRe["CustFName"].ToString();
                                msCustLName = lObRe["CustLName"].ToString();
                                msCustMobNo = lObRe["CustMobNo"].ToString();
                                msCustEmail = lObRe["CustEmail"].ToString();
                                msCustSts = lObRe["CustSts"].ToString();
                                msCustType = lObRe["CustType"].ToString();
                                msCustStAddr = DBNull.Value.Equals(lObRe["CustStAddr"]) ? null : lObRe["CustStAddr"].ToString();
                                msCustArAddr = DBNull.Value.Equals(lObRe["CustArAddr"]) ? null : lObRe["CustArAddr"].ToString();
                                msCustCity = DBNull.Value.Equals(lObRe["CustCity"]) ? null : lObRe["CustCity"].ToString();
                                msCustState = DBNull.Value.Equals(lObRe["CustState"]) ? null : lObRe["CustState"].ToString();
                                msCustPinCode = DBNull.Value.Equals(lObRe["CustPinCode"]) ? null : lObRe["CustPinCode"].ToString();
                                msCustCountry = DBNull.Value.Equals(lObRe["CustCountry"]) ? null : lObRe["CustCountry"].ToString();
                                msCustGSTNo = DBNull.Value.Equals(lObRe["CustGSTNo"]) ? null : lObRe["CustGSTNo"].ToString();
                                mdCustlLastVisit = Convert.ToDateTime(DBNull.Value.Equals(lObRe["CustlLastVisit"]) ? null : lObRe["CustlLastVisit"]);
                                msCustRemarks = DBNull.Value.Equals(lObRe["CustRemarks"]) ? null : lObRe["CustRemarks"].ToString();
                                mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObRe["Created"]) ? null : lObRe["Created"]);
                                msCreatedBy = DBNull.Value.Equals(lObRe["CreatedBy"]) ? null : lObRe["CreatedBy"].ToString();

                                //  mdModified = Convert.ToDateTime(DBNull.Value.Equals(lObRe["Modified"]) ? null : lObRe["Modified"]);

                                if (lObRe["Modified"].Equals(DBNull.Value))
                                {
                                    mdModified = null;
                                }
                                else
                                {
                                    mdModified = Convert.ToDateTime(lObRe["Modified"]);
                                }

                                msModifiedBy = DBNull.Value.Equals(lObRe["ModifiedBy"]) ? null : lObRe["ModifiedBy"].ToString();
                                mcDeleted = Convert.ToChar(DBNull.Value.Equals(lObRe["Deleted"]) ? null : lObRe["Deleted"]);

                                if (lObRe["DeletedOn"].Equals(DBNull.Value))
                                {
                                    mdDeletedOn = null;
                                }
                                else
                                {
                                    mdDeletedOn = Convert.ToDateTime(lObRe["DeletedOn"]);
                                }
                               // mdDeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObRe["DeletedOn"]) ? null : lObRe["DeletedOn"]);
                                msDeletedBy = DBNull.Value.Equals(lObRe["DeletedBy"]) ? null : lObRe["DeletedBy"].ToString();
                            }
                            lObRe.Close();
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool LoadCustomer(string isConstr,string inMobile)
        {
            try
            {
                using (SqlConnection lObjCustCnn = new SqlConnection(isConstr))
                {
                    string lsqQryLoad = "Select CustNo,CustFName,CustLName,CustMobNo," +
                        "CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity,CustState," +
                        "CustPinCode,CustCountry,CustGSTNo,CustlLastVisit,CustRemarks,Created," +
                        "CreatedBy,Modified,ModifiedBy,Deleted,DeletedOn,DeletedBy From Customer Where Deleted='N' And CustMobNo=@CustMobNo";
                
                    SqlCommand lObjCstCmd = new SqlCommand(lsqQryLoad,lObjCustCnn);
                    lObjCstCmd.CommandType = CommandType.Text;
                    lObjCustCnn.Open();

                    lObjCstCmd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = inMobile;

                    using (SqlDataReader lObRe = lObjCstCmd.ExecuteReader())
                    {
                        if(lObRe.HasRows)
                        {
                            while(lObRe.Read())
                            {
                                mnCustNo = Convert.ToInt32(lObRe["CustNo"]);
                                msCustFName = lObRe["CustFName"].ToString();
                                msCustLName = lObRe["CustLName"].ToString();
                                msCustMobNo = lObRe["CustMobNo"].ToString();
                                msCustEmail = lObRe["CustEmail"].ToString();
                                msCustSts = lObRe["CustSts"].ToString();
                                msCustType = lObRe["CustType"].ToString();
                                msCustStAddr = DBNull.Value.Equals(lObRe["CustStAddr"])? null : lObRe["CustStAddr"].ToString();
                                msCustArAddr = DBNull.Value.Equals(lObRe["CustArAddr"])? null : lObRe["CustArAddr"].ToString();
                                msCustCity = DBNull.Value.Equals(lObRe["CustCity"]) ? null : lObRe["CustCity"].ToString();
                                msCustState = DBNull.Value.Equals(lObRe["CustState"]) ? null : lObRe["CustState"].ToString();
                                msCustPinCode = DBNull.Value.Equals(lObRe["CustPinCode"])? null : lObRe["CustPinCode"].ToString();
                                msCustCountry = DBNull.Value.Equals(lObRe["CustCountry"]) ? null : lObRe["CustCountry"].ToString();
                                msCustGSTNo = DBNull.Value.Equals(lObRe["CustGSTNo"]) ? null : lObRe["CustGSTNo"].ToString();
                                mdCustlLastVisit = Convert.ToDateTime(DBNull.Value.Equals(lObRe["CustlLastVisit"])?null : lObRe["CustlLastVisit"]);
                                msCustRemarks = DBNull.Value.Equals(lObRe["CustRemarks"]) ? null : lObRe["CustRemarks"].ToString();
                                mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObRe["Created"]) ? null : lObRe["Created"]);
                                msCreatedBy = DBNull.Value.Equals(lObRe["CreatedBy"]) ? null : lObRe["CreatedBy"].ToString();

                              //  mdModified = Convert.ToDateTime(DBNull.Value.Equals(lObRe["Modified"]) ? null : lObRe["Modified"]);

                                if (lObRe["Modified"].Equals(DBNull.Value))
                                {
                                    mdModified = null;
                                }
                                else
                                {
                                    mdModified = Convert.ToDateTime(lObRe["Modified"]);
                                }

                                msModifiedBy = DBNull.Value.Equals(lObRe["ModifiedBy"]) ? null : lObRe["ModifiedBy"].ToString();
                                mcDeleted = Convert.ToChar(DBNull.Value.Equals(lObRe["Deleted"]) ? null : lObRe["Deleted"]);
                                mdDeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObRe["DeletedOn"]) ? null : lObRe["DeletedOn"]);
                                msDeletedBy = DBNull.Value.Equals(lObRe["DeletedBy"]) ? null : lObRe["DeletedBy"].ToString();
                            }
                            lObRe.Close();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SaveData(string isConstr,bool ibMode,string UserID)
        {
            String lsSavQry = " ";
            try
            {
                using (SqlConnection lObjSveCn = new SqlConnection(isConstr))
                {
                    if (ibMode == true)
                    {
                     lsSavQry = "Insert Into Customer (CustFName,CustLName,CustMobNo,CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity," +
                        "CustState,CustPinCode,CustCountry,CustGSTNo,CustlLastVisit,CustRemarks,Created,CreatedBy,Deleted)Values(@CustFName,@CustLName,@CustMobNo," +
                        "@CustEmail,@CustSts,@CustType,@CustStAddr,@CustArAddr," +
                        "@CustCity,@CustState,@CustPinCode,@CustCountry,@CustGSTNo," +
                        "@CustlLastVisit,@CustRemarks,@Created,@CreatedBy,'N')";
                    }
                    else 
                    {
                     lsSavQry = "Update Customer Set CustFName=@CustFName,CustLName=@CustLName,CustMobNo=@CustMobNo," +
                        "CustEmail=@CustEmail,CustSts=@CustSts,CustType=@CustType,CustStAddr=@CustStAddr,CustArAddr=@CustArAddr," +
                        "CustCity=@CustCity,CustState=@CustState,CustPinCode=@CustPinCode,CustCountry=@CustCountry,CustGSTNo=@CustGSTNo," +
                        "CustlLastVisit=@CustlLastVisit,CustRemarks=@CustRemarks,Modified=@Modified,ModifiedBy=@ModifiedBy Where CustNo=@CustNo AND Deleted='N'";
                    }
                    
                   
                    SqlCommand lObjCmdSave = new SqlCommand(lsSavQry,lObjSveCn);
                    lObjCmdSave.CommandType = CommandType.Text;
                    lObjSveCn.Open();

                    
                    lObjCmdSave.Parameters.AddWithValue("@CustFName",SqlDbType.VarChar).Value = msCustFName;
                    lObjCmdSave.Parameters.AddWithValue("@CustLName",SqlDbType.VarChar).Value = msCustLName;
                    lObjCmdSave.Parameters.AddWithValue("@CustMobNo",SqlDbType.VarChar).Value = msCustMobNo;
                    lObjCmdSave.Parameters.AddWithValue("@CustEmail",SqlDbType.VarChar).Value = msCustEmail;
                    lObjCmdSave.Parameters.AddWithValue("@CustSts",SqlDbType.VarChar).Value = msCustSts;
                    lObjCmdSave.Parameters.AddWithValue("@CustType",SqlDbType.VarChar).Value = msCustType;
                    lObjCmdSave.Parameters.AddWithValue("@CustStAddr",SqlDbType.VarChar).Value = (object)msCustStAddr??DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustArAddr",SqlDbType.VarChar).Value = (object)msCustArAddr??DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustCity",SqlDbType.VarChar).Value = (object)msCustCity??DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustState",SqlDbType.VarChar).Value = (object)msCustState??DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustPinCode",SqlDbType.VarChar).Value = (object)msCustPinCode??DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustCountry",SqlDbType.VarChar).Value = (object)msCustCountry??DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustGSTNo",SqlDbType.VarChar).Value = (object)msCustGSTNo??DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustlLastVisit",SqlDbType.DateTime).Value = DateTime.Now;
                    lObjCmdSave.Parameters.AddWithValue("@CustRemarks",SqlDbType.VarChar).Value = (object)msCustRemarks??DBNull.Value;

                    if(ibMode == true)
                    {
                        lObjCmdSave.Parameters.AddWithValue("@CustNo", SqlDbType.Int).Value = (object)mnCustNo ?? DBNull.Value;
                        lObjCmdSave.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = (object)UserID ?? DBNull.Value;
                        lObjCmdSave.Parameters.AddWithValue("@Created", SqlDbType.DateTime).Value = DateTime.Now;
                    }
                    else
                    {
                        lObjCmdSave.Parameters.AddWithValue("@CustNo", SqlDbType.Int).Value = mnCustNo;
                        lObjCmdSave.Parameters.AddWithValue("@Modified", SqlDbType.DateTime).Value = DateTime.Now;
                        lObjCmdSave.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = (object)UserID ?? DBNull.Value;
                    }
                    
                    lObjCmdSave.ExecuteNonQuery();
                    //lObjSveCn.Close();
                    lsSavQry = " ";
                }
                return true;
            }
            catch
            {
                return false;
            }
            
        }


        public bool Save()
        {
            String lsSavQry = " ";
            try
            {
                using (SqlConnection lObjSveCn = new SqlConnection(Constr))
                {
                   lsSavQry = "Insert Into Customer (CustFName,CustLName,CustMobNo,CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity," +
                       "CustState,CustPinCode,CustCountry,CustGSTNo,CustlLastVisit,CustRemarks,Created,CreatedBy,Deleted)OUTPUT INSERTED.CustNo Values(@CustFName,@CustLName,@CustMobNo," +
                       "@CustEmail,@CustSts,@CustType,@CustStAddr,@CustArAddr," +
                       "@CustCity,@CustState,@CustPinCode,@CustCountry,@CustGSTNo," +
                       "@CustlLastVisit,@CustRemarks,@Created,@CreatedBy,'N')";

                    SqlCommand lObjCmdSave = new SqlCommand(lsSavQry,lObjSveCn);
                    lObjCmdSave.CommandType = CommandType.Text;
                    lObjSveCn.Open();

                    
                    lObjCmdSave.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = msCustFName;
                    lObjCmdSave.Parameters.AddWithValue("@CustLName", SqlDbType.VarChar).Value = msCustLName;
                    lObjCmdSave.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = msCustMobNo;
                    lObjCmdSave.Parameters.AddWithValue("@CustEmail", SqlDbType.VarChar).Value = msCustEmail;
                    lObjCmdSave.Parameters.AddWithValue("@CustSts", SqlDbType.VarChar).Value = msCustSts;
                    lObjCmdSave.Parameters.AddWithValue("@CustType", SqlDbType.Char).Value = msCustType;
                    lObjCmdSave.Parameters.AddWithValue("@CustStAddr", SqlDbType.VarChar).Value = (object)msCustStAddr ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustArAddr", SqlDbType.VarChar).Value = (object)msCustArAddr ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustCity", SqlDbType.VarChar).Value = (object)msCustCity ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustState", SqlDbType.VarChar).Value = (object)msCustState ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustPinCode", SqlDbType.Char).Value = (object)msCustPinCode ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustCountry", SqlDbType.VarChar).Value = (object)msCustCountry ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CustGSTNo", SqlDbType.VarChar).Value = (object)msCustGSTNo ?? DBNull.Value;
                //  lObjCmdSave.Parameters.AddWithValue("@CustlLastVisit", SqlDbType.DateTime).Value = (object)lobjDataCst.mdCustlLastVisit ?? DBNull.Value;


                    lObjCmdSave.Parameters.AddWithValue("@CustlLastVisit", SqlDbType.DateTime).Value = DateTime.Now;
                    lObjCmdSave.Parameters.AddWithValue("@CustRemarks", SqlDbType.VarChar).Value = (object)msCustRemarks ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = (object)MasterMechUtil.sUserID ?? DBNull.Value;
                    lObjCmdSave.Parameters.AddWithValue("@Created", SqlDbType.DateTime).Value = DateTime.Now;

                    mnCustNo = (int)lObjCmdSave.ExecuteScalar(); // Note :- Is Equivalent to ExecuteNonQuery();
                    
                   
                    
                    //lObjCmdSave.ExecuteNonQuery();
                    
                    // lObjSveCn.Close();
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
                //return false;
            }
        }

        public bool Save1()
        {
            Invoice lObjInv = new Invoice();
            String lsSavQry = " ";
            try
            {
                using (SqlConnection lObjSveCn = new SqlConnection(Constr))
                {
                    lsSavQry = "Insert Into Customer (CustFName,CustLName,CustMobNo,CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity," +
                        "CustState,CustPinCode,CustCountry,CustGSTNo,CustlLastVisit,CustRemarks,Created,CreatedBy,Deleted)OUTPUT INSERTED.CustNo Values(@CustFName,@CustLName,@CustMobNo," +
                        "@CustEmail,@CustSts,@CustType,@CustStAddr,@CustArAddr," +
                        "@CustCity,@CustState,@CustPinCode,@CustCountry,@CustGSTNo," +
                        "@CustlLastVisit,@CustRemarks,@Created,@CreatedBy,'N')";

                    SqlCommand lObjCmdSave = new SqlCommand(lsSavQry, lObjSveCn);
                    lObjCmdSave.CommandType = CommandType.Text;
                    lObjSveCn.Open();


                    lObjCmdSave.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = lObjInv.msCustFName;
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





        public bool UpdateLastLogin(SqlCommand Cmd)
        {
            using(SqlConnection lObjCoon = new SqlConnection(Constr))
            {
                string lsQryLgnLst = "Update Customer SET CustlLastVisit=@CustlLastVisit Where Deleted='N'";

                SqlCommand lObjCmd = new SqlCommand(lsQryLgnLst, lObjCoon);
                lObjCmd.CommandType = CommandType.Text;

                lObjCmd.Parameters.AddWithValue("CustlLastVisit", SqlDbType.DateTime).Value = DateTime.Now;

                lObjCoon.Open();
                lObjCmd.ExecuteNonQuery();
                lObjCoon.Close();
            }
            return true;
        }

        public bool DeleteRecord(string isConstr,string inMobNo)
        {
            string lsQryDel = " ";
            try
            {
                using(SqlConnection lObjDelCnn = new SqlConnection(isConstr))
                {
                    lsQryDel = "Update Customer SET Deleted='Y' Where CustMobNo=@CustMobNo";

                    SqlCommand lObjCmdDel = new SqlCommand(lsQryDel, lObjDelCnn);
                    lObjCmdDel.CommandType = CommandType.Text;
                    lObjDelCnn.Open();

                    lObjCmdDel.Parameters.AddWithValue("@CustMobNo", SqlDbType.Int).Value = inMobNo;
                    lObjCmdDel.ExecuteNonQuery();
                    lObjDelCnn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        
        //Delete in Web MVC 

        public bool DeleteCust(string isConstr,int  inCustNo)
        {
            string lsQryDel = " ";
            try
            {
                using (SqlConnection lObjDelCnn = new SqlConnection(isConstr))
                {
                    lsQryDel = "Update Customer SET Deleted='Y' Where CustNo=@CustNo";

                    SqlCommand lObjCmdDel = new SqlCommand(lsQryDel, lObjDelCnn);
                    lObjCmdDel.CommandType = CommandType.Text;
                    lObjDelCnn.Open();

                    lObjCmdDel.Parameters.AddWithValue("@CustNo", SqlDbType.Int).Value = inCustNo;
                    lObjCmdDel.ExecuteNonQuery();
                    lObjDelCnn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SearchCustomer(string isConstr,List<Customer> oObjSerchDataList,string isCustMobNo)
        {
            Customer lObjClassCst = new Customer();
            string lsSrchQry = " ";
            try
            {
                using(SqlConnection lObjSrchCn = new SqlConnection(isConstr))
                {
                    lsSrchQry = "Select CustNo,CustFName,CustLName,CustMobNo," +
                        "CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity,CustState,CustPinCode," +
                        "CustCountry,CustGSTNo,CustlLastVisit,CustRemarks,Created,CreatedBy,Modified,ModifiedBy," +
                        "Deleted,DeletedOn,DeletedBy" +
                        " From Customer Where CustMobNo Like @CustMobNo And Deleted='N'";

                    SqlCommand lObbjCmdSrc = new SqlCommand(lsSrchQry,lObjSrchCn);
                    lObbjCmdSrc.CommandType = CommandType.Text;
                    lObjSrchCn.Open();

                    lObbjCmdSrc.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = '%'+isCustMobNo+'%';

                    using (SqlDataReader lObjRead = lObbjCmdSrc.ExecuteReader())
                    {
                        if(lObjRead.HasRows)
                        {
                            while(lObjRead.Read())
                            {
                                mnCustNo = Convert.ToInt32(lObjRead["CustNo"]);
                                msCustFName = lObjRead["CustFName"].ToString();
                                msCustLName = lObjRead["CustLName"].ToString();
                                msCustMobNo = lObjRead["CustMobNo"].ToString();
                                msCustEmail = lObjRead["CustEmail"].ToString();
                                msCustSts = lObjRead["CustSts"].ToString();
                                msCustType = lObjRead["CustType"].ToString();
                                msCustStAddr = DBNull.Value.Equals(lObjRead["CustStAddr"]) ? null : lObjRead["CustStAddr"].ToString();
                                msCustArAddr = DBNull.Value.Equals(lObjRead["CustArAddr"]) ? null : lObjRead["CustArAddr"] .ToString();
                                msCustCity = DBNull.Value.Equals(lObjRead["CustCity"]) ? null : lObjRead["CustCity"].ToString();
                                msCustState =   DBNull.Value.Equals(lObjRead["CustState"]) ? null : lObjRead["CustState"].ToString();
                                msCustPinCode = DBNull.Value.Equals(lObjRead["CustPinCode"]) ? null : lObjRead["CustPinCode"].ToString();
                                msCustCountry = DBNull.Value.Equals(lObjRead["CustCountry"]) ? null : lObjRead["CustCountry"].ToString();
                                msCustGSTNo = DBNull.Value.Equals(lObjRead["CustGSTNo"]) ? null : lObjRead["CustGSTNo"].ToString();
                                mdCustlLastVisit = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["CustlLastVisit"]) ? null : lObjRead["CustlLastVisit"]);
                                msCustRemarks = DBNull.Value.Equals(lObjRead["CustRemarks"]) ? null : lObjRead["CustRemarks"].ToString();
                                mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Created"]) ? null : lObjRead["Created"]);
                                msCreatedBy = DBNull.Value.Equals(lObjRead["CreatedBy"]) ? null : lObjRead["CreatedBy"].ToString();
                                mdModified = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Modified"]) ? null : lObjRead["Modified"]);
                                //if ((lObjRead["Modified"] == null))
                                //    mdModified = null;
                                //else
                                //    mdModified = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Modified"]));

                                msModifiedBy = DBNull.Value.Equals(lObjRead["ModifiedBy"]) ? null : lObjRead["ModifiedBy"].ToString();
                                mcDeleted = Convert.ToChar( DBNull.Value.Equals(lObjRead["Deleted"]) ? null : lObjRead["Deleted"]);
                                mdDeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["DeletedOn"]) ? null : lObjRead["DeletedOn"]);
                                msDeletedBy = DBNull.Value.Equals(lObjRead["DeletedBy"]) ? null : lObjRead["DeletedBy"].ToString();


                                Customer lObjCst = new Customer(msCustFName, msCustLName, msCustMobNo, msCustEmail, msCustSts,
                                    msCustType, msCustStAddr, msCustArAddr, msCustCity, msCustState, msCustPinCode,Convert.ToDateTime(mdCustlLastVisit),
                                    msCustCountry, msCustGSTNo, msCustRemarks,Convert.ToDateTime(mdCreated), msCreatedBy, Convert.ToDateTime(mdModified), msModifiedBy);
                                lObjCst.mnCustNo = mnCustNo;


                                oObjSerchDataList.Add(lObjCst);

                            }
                            lObjSrchCn.Close();
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

        public bool AdvanceSearch(string isConstr, List<Customer> oObjAdvncList,string isFNmae,string isLName,string isCity)
        {
           // Customer lObjAdvSrch = new Customer();
            string lsSrchQry = " ";
            try
            {
                using (SqlConnection lObjSrch = new SqlConnection(isConstr))
                {
                        lsSrchQry = "Select CustNo,CustFName,CustLName,CustMobNo," +
                      "CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity,CustState,CustPinCode," +
                      "CustCountry,CustGSTNo,CustlLastVisit,CustRemarks,Created,CreatedBy,Modified,ModifiedBy," +
                      "Deleted,DeletedOn,DeletedBy" +
                      " From Customer Where CustFName  Like  @CustFName  AND   CustLName Like @CustLName And  CustCity Like @CustCity ";

                
                    
                    SqlCommand lObbjCmdSrc = new SqlCommand(lsSrchQry, lObjSrch);
                    lObbjCmdSrc.CommandType = CommandType.Text;
                    lObjSrch.Open();


                    lObbjCmdSrc.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = '%'+isFNmae+'%';
                    lObbjCmdSrc.Parameters.AddWithValue("@CustLName",SqlDbType.VarChar).Value = '%'+isLName+'%';
                    lObbjCmdSrc.Parameters.AddWithValue("@CustCity", SqlDbType.VarChar).Value = '%'+isCity+'%';

                    using (SqlDataReader lObjR = lObbjCmdSrc.ExecuteReader())
                    {
                        if (lObjR.HasRows)
                        {
                            while (lObjR.Read())
                            {
                                mnCustNo = Convert.ToInt32(lObjR["CustNo"]);
                                msCustFName = lObjR["CustFName"].ToString();
                                msCustLName = lObjR["CustLName"].ToString();
                                msCustMobNo = lObjR["CustMobNo"].ToString();
                                msCustEmail = lObjR["CustEmail"].ToString();
                                msCustSts = lObjR["CustSts"].ToString();
                                msCustType = lObjR["CustType"].ToString();
                                msCustStAddr = DBNull.Value.Equals(lObjR["CustStAddr"]) ? null : lObjR["CustStAddr"].ToString();
                                msCustArAddr = DBNull.Value.Equals(lObjR["CustArAddr"]) ? null : lObjR["CustArAddr"].ToString();
                                msCustCity = DBNull.Value.Equals(lObjR["CustCity"]) ? null : lObjR["CustCity"].ToString();
                                msCustState = DBNull.Value.Equals(lObjR["CustState"]) ? null : lObjR["CustState"].ToString();
                                msCustPinCode = DBNull.Value.Equals(lObjR["CustPinCode"]) ? null : lObjR["CustPinCode"].ToString();
                                msCustCountry = DBNull.Value.Equals(lObjR["CustCountry"]) ? null : lObjR["CustCountry"].ToString();
                                msCustGSTNo = DBNull.Value.Equals(lObjR["CustGSTNo"]) ? null : lObjR["CustGSTNo"].ToString();
                                mdCustlLastVisit = Convert.ToDateTime(DBNull.Value.Equals(lObjR["CustlLastVisit"]) ? null : lObjR["CustlLastVisit"]);
                                msCustRemarks = DBNull.Value.Equals(lObjR["CustRemarks"]) ? null : lObjR["CustRemarks"].ToString();
                                mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObjR["Created"]) ? null : lObjR["Created"]);
                                msCreatedBy = DBNull.Value.Equals(lObjR["CreatedBy"]) ? null : lObjR["CreatedBy"].ToString();
                                mdModified = Convert.ToDateTime(DBNull.Value.Equals(lObjR["Modified"]) ? null : lObjR["Modified"]);
                                msModifiedBy = DBNull.Value.Equals(lObjR["ModifiedBy"]) ? null : lObjR["ModifiedBy"].ToString();
                                mcDeleted = Convert.ToChar(DBNull.Value.Equals(lObjR["Deleted"]) ? null : lObjR["Deleted"]);
                                mdDeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObjR["DeletedOn"]) ? null : lObjR["DeletedOn"]);
                                msDeletedBy = DBNull.Value.Equals(lObjR["DeletedBy"]) ? null : lObjR["DeletedBy"].ToString();


                                Customer lObjAdvSrch1 = new Customer(msCustFName, msCustLName, msCustMobNo, msCustEmail, msCustSts,
                                    msCustType, msCustStAddr, msCustArAddr, msCustCity, msCustState, msCustPinCode,Convert.ToDateTime(mdCustlLastVisit),
                                    msCustCountry, msCustGSTNo, msCustRemarks, Convert.ToDateTime(mdCreated), msCreatedBy, Convert.ToDateTime(mdModified), msModifiedBy);
                                lObjAdvSrch1.mnCustNo = mnCustNo;


                                oObjAdvncList.Add(lObjAdvSrch1);
                            }
                        }
                        lObjSrch.Close();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public List<Customer> SearchCust(string isConstr)
        {
            List<Customer> oObjSerchDataList = new List<Customer>();
            Customer lObjClassCst = new Customer();
            string lsSrchQry = " ";
            try
            {
                using (SqlConnection lObjSrchCn = new SqlConnection(isConstr))
                {
                    lsSrchQry = "Select CustNo,CustFName,CustLName,CustMobNo," +
                        "CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity,CustState,CustPinCode," +
                        "CustCountry,CustGSTNo,CustlLastVisit,CustRemarks,Created,CreatedBy,Modified,ModifiedBy," +
                        "Deleted,DeletedOn,DeletedBy" +
                        " From Customer ";

                    SqlCommand lObbjCmdSrc = new SqlCommand(lsSrchQry, lObjSrchCn);
                    lObbjCmdSrc.CommandType = CommandType.Text;
                    lObjSrchCn.Open();

                  //  lObbjCmdSrc.Parameters.AddWithValue("@CustNo", SqlDbType.Int).Value = CustNo;

                    using (SqlDataReader lObjRead = lObbjCmdSrc.ExecuteReader())
                    {
                        if (lObjRead.HasRows)
                        {
                            while (lObjRead.Read())
                            {
                                mnCustNo = Convert.ToInt32(lObjRead["CustNo"]);
                                msCustFName = lObjRead["CustFName"].ToString();
                                msCustLName = lObjRead["CustLName"].ToString();
                                msCustMobNo = lObjRead["CustMobNo"].ToString();
                                msCustEmail = lObjRead["CustEmail"].ToString();
                                msCustSts = lObjRead["CustSts"].ToString();
                                msCustType = lObjRead["CustType"].ToString();
                                msCustStAddr = DBNull.Value.Equals(lObjRead["CustStAddr"]) ? null : lObjRead["CustStAddr"].ToString();
                                msCustArAddr = DBNull.Value.Equals(lObjRead["CustArAddr"]) ? null : lObjRead["CustArAddr"].ToString();
                                msCustCity = DBNull.Value.Equals(lObjRead["CustCity"]) ? null : lObjRead["CustCity"].ToString();
                                msCustState = DBNull.Value.Equals(lObjRead["CustState"]) ? null : lObjRead["CustState"].ToString();
                                msCustPinCode = DBNull.Value.Equals(lObjRead["CustPinCode"]) ? null : lObjRead["CustPinCode"].ToString();
                                msCustCountry = DBNull.Value.Equals(lObjRead["CustCountry"]) ? null : lObjRead["CustCountry"].ToString();
                                msCustGSTNo = DBNull.Value.Equals(lObjRead["CustGSTNo"]) ? null : lObjRead["CustGSTNo"].ToString();
                                mdCustlLastVisit = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["CustlLastVisit"]) ? null : lObjRead["CustlLastVisit"]);
                                msCustRemarks = DBNull.Value.Equals(lObjRead["CustRemarks"]) ? null : lObjRead["CustRemarks"].ToString();
                                mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Created"]) ? null : lObjRead["Created"]);
                                msCreatedBy = DBNull.Value.Equals(lObjRead["CreatedBy"]) ? null : lObjRead["CreatedBy"].ToString();
                                mdModified = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Modified"]) ? null : lObjRead["Modified"]);
                                //if ((lObjRead["Modified"] == null))
                                //    mdModified = null;
                                //else
                                //    mdModified = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["Modified"]));

                                msModifiedBy = DBNull.Value.Equals(lObjRead["ModifiedBy"]) ? null : lObjRead["ModifiedBy"].ToString();
                                mcDeleted = Convert.ToChar(DBNull.Value.Equals(lObjRead["Deleted"]) ? null : lObjRead["Deleted"]);
                                mdDeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObjRead["DeletedOn"]) ? null : lObjRead["DeletedOn"]);
                                msDeletedBy = DBNull.Value.Equals(lObjRead["DeletedBy"]) ? null : lObjRead["DeletedBy"].ToString();


                                Customer lObjCst = new Customer(msCustFName, msCustLName, msCustMobNo, msCustEmail, msCustSts,
                                    msCustType, msCustStAddr, msCustArAddr, msCustCity, msCustState, msCustPinCode, Convert.ToDateTime(mdCustlLastVisit),
                                    msCustCountry, msCustGSTNo, msCustRemarks, Convert.ToDateTime(mdCreated), msCreatedBy, Convert.ToDateTime(mdModified), msModifiedBy);
                                lObjCst.mnCustNo = mnCustNo;


                                oObjSerchDataList.Add(lObjCst);

                            }
                            lObjSrchCn.Close();
                        }
                    }
                }
                return oObjSerchDataList;
            }
            catch
            {
                return oObjSerchDataList;
            }
        }
    }
}
