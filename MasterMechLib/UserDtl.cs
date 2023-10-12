using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterMechLib
{
    public class UserDtl
    {
        [Display(Name = "Last Login Time")]
        public DateTime? mdLastLoginTime { get; set; }

        [Display(Name = "Last Password Change Time")]
        public DateTime? mdLastPwdChangeTime { get; set; }

        [Display(Name = "Created")]
        public DateTime? mdCreated { get; set; }


        [Display(Name = "User ID")]
        public string msUserID { get; set; }


        
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Correct Password")]
        public string msPwd { get; set; }

        [Display(Name = "User Name")]
        public string msUserName { get; set; }

        
        
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        [StringLength(14)]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
       
        public string msMobNo { get; set; } 

        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email ID")]
        [Required(ErrorMessage = "Email ID Not Given")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string msEmailID { get; set; }

        [Display(Name = "User Type")]
        public string msUserType { get; set; }



        // [DisplayName(Name = "Last Login Time")]



        [Display(Name = "Remarks")]
        public string msRemarks { get; set; }

        [Display(Name = "Created By")]
        public string msCreatedBy { get; set; }

        [Display(Name ="Modified ")]
        public DateTime? mdModified { get; set; }

        [Display(Name = "Modified By")]
        public string msModifiedBy { get; set; }

        [Display(Name = "Deleted")]
        public string msDeleted { get; set; }

        [Display(Name ="Deleted On")]
        public DateTime? mdDeletedOn { get; set; }

        [Display(Name = "Deleted By")]
        public string msDeletedBy { get; set; }


        bool lbValidUser = false;

        public static string Constr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MasterMech;Data Source=MASOOD\\SQLEXPRESSMSD";
        public static string User = "UserID";



        public UserDtl(string isConstr, string isUser)
        {
            Constr = isConstr;
            User = isUser;
        }

        public UserDtl(string isUserID, string isPwd, string isUserName,
            string isMobNo, string isEmailID, string isUserType, DateTime isLastLoginTime,
            DateTime isLastPwdChangeTime, string isRemarks, DateTime isCreated,
            string isCreatedBy, DateTime isModified, string isModifiedBy, string isDeleted, DateTime isDeletedOn, string isDeletedBy)
        {
            msUserID = isUserID;
            msPwd = isPwd;
            msUserName = isUserName;
            msMobNo = isMobNo;
            msEmailID = isEmailID;
            msUserType = isUserType;
            mdLastLoginTime = isLastLoginTime;
            mdLastPwdChangeTime = isLastPwdChangeTime;
            msRemarks = isRemarks;
            mdCreated = isCreated;
            msCreatedBy = isCreatedBy;
            mdModified = isModified;
            msModifiedBy = isModifiedBy;
            msDeleted = isDeleted;
            mdDeletedOn = isDeletedOn;
            msDeletedBy = isDeletedBy;
        }


       public UserDtl()
       {

       }


        public bool ValidUserID(string isConStr)
        {
            int lnUserCount = 0;
            bool lbValidUserID;
            using (SqlConnection lObjConUs = new SqlConnection(isConStr))
            {
                string lsQry = "SELECT COUNT(*) as USERCOUNT FROM UserDtl WHERE UserID = @UserID";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(lsQry))
                    {
                        cmd.Connection = lObjConUs;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = msUserID;

                        lObjConUs.Open();
                        using (SqlDataReader lObjRdr = cmd.ExecuteReader())
                        {
                            if (lObjRdr.HasRows)
                            {
                                while (lObjRdr.Read())
                                {
                                    lnUserCount = (int)lObjRdr["USERCOUNT"];
                                }
                            }
                        }
                        lObjConUs.Close();
                    }
                    if (lnUserCount > 0)
                        lbValidUserID = true;
                    else
                        lbValidUserID = false;
                }
                catch
                {
                    return false;
                }
            }
            return lbValidUserID;
        }

        public bool ValidLogin(string isConStr)
        {
            using (SqlConnection lObjLgCon = new SqlConnection(isConStr))
            {
                string lsQryLog = "SELECT UserType,UserName FROM UserDtl  WHERE UserID = @UserID  AND Pwd = @Pwd";
                try
                {
                    using (SqlCommand lObjCMD = new SqlCommand(lsQryLog))
                    {
                        lObjCMD.Connection = lObjLgCon;
                        lObjCMD.CommandType = CommandType.Text;
                        lObjLgCon.Open();

                        lObjCMD.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = msUserID;
                        lObjCMD.Parameters.AddWithValue("@Pwd", SqlDbType.VarChar).Value = msPwd;

                        using (SqlDataReader lObjRead = lObjCMD.ExecuteReader())
                        {
                            if (lObjRead.HasRows)
                            {
                                while (lObjRead.Read())
                                {
                                    msUserType = lObjRead["UserType"].ToString();
                                    msUserName = lObjRead["UserName"].ToString();
                                    lbValidUser = true;
                                }
                            }
                            else
                                return false;
                        }
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        //Web MVC Login page
        public bool ValidLog(string isConStr,string UserID,string Password)
        {
            using (SqlConnection lObjLgCon = new SqlConnection(isConStr))
            {
                string lsQryLog = "SELECT UserType,UserName FROM UserDtl  WHERE UserID = @UserID  AND Pwd = @Pwd";
                try
                {
                    using (SqlCommand lObjCMD = new SqlCommand(lsQryLog))
                    {
                        lObjCMD.Connection = lObjLgCon;
                        lObjCMD.CommandType = CommandType.Text;
                        lObjLgCon.Open();

                        lObjCMD.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = UserID;
                        lObjCMD.Parameters.AddWithValue("@Pwd", SqlDbType.VarChar).Value = Password;

                        using (SqlDataReader lObjRead = lObjCMD.ExecuteReader())
                        {
                            if (lObjRead.HasRows)
                            {
                                while (lObjRead.Read())
                                {
                                    msUserType = lObjRead["UserType"].ToString();
                                    msUserName = lObjRead["UserName"].ToString();
                                    lbValidUser = true;
                                }
                            }
                            else
                                return false;
                        }
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }


        public bool Load(string isConstr, string isUserID)
        {
            using (SqlConnection lObjConLod = new SqlConnection(isConstr))
            {

                string lsQryLoad = "SELECT UserID,Pwd,UserName,MobNo,EmailID," +
                    "UserType,LastLoginTime,LastPwdChangeTime,Remarks,Created,CreatedBy,Modified,ModifiedBy," +
                    "Deleted,DeletedOn,DeletedBy" +
                    "   FROM UserDtl Where UserID=@UserID  AND Deleted='N'";

                SqlCommand lObjCdLd = new SqlCommand(lsQryLoad);
                lObjCdLd.Connection = lObjConLod;
                lObjConLod.Open();

                lObjCdLd.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = isUserID;
               

                using (SqlDataReader lObjRd = lObjCdLd.ExecuteReader())
                {
                    if (lObjRd.HasRows)
                    {
                        while (lObjRd.Read())
                        {
                            msUserID = lObjRd["UserID"].ToString();
                            msPwd =lObjRd["Pwd"].ToString();
                            msUserName = lObjRd["UserName"].ToString();
                            msMobNo = (DBNull.Value.Equals(lObjRd["MobNo"].ToString()) ? null : lObjRd["MobNo"].ToString());
                            msEmailID = (DBNull.Value.Equals(lObjRd["EmailID"].ToString()) ? null : lObjRd["EmailID"].ToString());
                            msUserType = (DBNull.Value.Equals(lObjRd["UserType"].ToString()) ? null : lObjRd["UserType"].ToString());
                            mdLastLoginTime = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["LastLoginTime"]) ? null : lObjRd["LastLoginTime"]);
                            mdLastPwdChangeTime = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["LastPwdChangeTime"]) ? null : lObjRd["LastPwdChangeTime"]);
                            msRemarks = (DBNull.Value.Equals(lObjRd["Remarks"].ToString()) ? null : lObjRd["Remarks"].ToString());
                            mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["Created"]) ? null : lObjRd["Created"]);
                            msCreatedBy = (DBNull.Value.Equals(lObjRd["CreatedBy"].ToString()) ? null : lObjRd["CreatedBy"].ToString());


                            if (lObjRd["Modified"].Equals(DBNull.Value))
                            {
                                mdModified = null;
                            }
                            else
                            {
                                mdModified = Convert.ToDateTime((lObjRd["Modified"]));
                            }


                            //if (lObRe["Modified"].Equals(DBNull.Value))
                            //    mdModified = null;
                            //else
                            //    mdModified = Convert.ToDateTime(lObRe["Modified"]);

                            msModifiedBy = (DBNull.Value.Equals(lObjRd["ModifiedBy"].ToString()) ? null : lObjRd["ModifiedBy"].ToString());
                            msDeleted = (DBNull.Value.Equals(lObjRd["Deleted"].ToString()) ? null : lObjRd["Deleted"].ToString());
                            mdDeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObjRd["DeletedOn"]) ? null : lObjRd["DeletedOn"]);
                            msDeletedBy = DBNull.Value.Equals(lObjRd["DeletedBy"]) ? "" : lObjRd["DeletedBy"].ToString();
                        }
                    }
                    else
                    return false;
                }
            }
            return true;
        }


        public bool UpdateUserGeneralInfo(string isConstr, string isUserID)
        {
            using (SqlConnection lObjUpd = new SqlConnection(isConstr))
            {
                string lsUpdateQry = "UPDATE  UserDtl SET UserName=@UserName," +
                    "MobNo=@MobNo,EmailID=@EmailID,Modified=@Modified," +
                    "ModifiedBy=@ModifiedBy  Where UserID=@UserID AND Deleted='N'";


                SqlCommand lObjCdUp = new SqlCommand(lsUpdateQry);
                lObjCdUp.Connection = lObjUpd;
                lObjCdUp.CommandType = CommandType.Text;


                lObjCdUp.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = msUserName;
                lObjCdUp.Parameters.AddWithValue("@MobNo", SqlDbType.VarChar).Value = msMobNo;
                lObjCdUp.Parameters.AddWithValue("@EmailID", SqlDbType.VarChar).Value = msEmailID;
                lObjCdUp.Parameters.AddWithValue("@Modified", SqlDbType.DateTime).Value = DateTime.Now;
                lObjCdUp.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = isUserID;
                lObjCdUp.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = isUserID;


                lObjUpd.Open();
                lObjCdUp.ExecuteNonQuery();
                lObjUpd.Close();
                return true;
            }
        }


        public bool UpdateLoginTime(string isConstr, string isUserID)
        {
            using (SqlConnection lObjConTme = new SqlConnection(isConstr))
            {

                string lsQryUdt = "UPDATE UserDtl SET LastLoginTime=@LastLoginTime";       //Where UserID=@UserID";

                SqlCommand lObjCmdUp = new SqlCommand(lsQryUdt);
                lObjCmdUp.Connection = lObjConTme;
                lObjCmdUp.CommandType = CommandType.Text;

                lObjCmdUp.Parameters.AddWithValue("@LastLoginTime", SqlDbType.DateTime).Value = DateTime.Now;

                // lObjCmdUp.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = msUserID;


                lObjConTme.Open();
                lObjCmdUp.ExecuteNonQuery();
                lObjConTme.Close();
            }
            return true;
        }



        public bool UpdatePassword(string isConstr, string isUserID, string isPWD)
        {
            //if (ValidLogin(isConstr) == true)
            //{

            using (SqlConnection lObjPass = new SqlConnection(isConstr))
            {

                string lsQruPawd = "Update UserDtl SET Pwd=@Pwd WHERE UserID=@UserID  AND Deleted='N'";

                SqlCommand lObjCmPwd = new SqlCommand(lsQruPawd);
                lObjCmPwd.Connection = lObjPass;
                lObjCmPwd.CommandType = CommandType.Text;

                lObjCmPwd.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = isUserID;
                lObjCmPwd.Parameters.AddWithValue("@Pwd", SqlDbType.VarChar).Value = isPWD;

                lObjPass.Open();
                lObjCmPwd.ExecuteNonQuery();

                lObjPass.Close();
            }
            return true;
            //}
            //else
            //    return false;
        }



        public bool SearchUser(string isConstr, string isSearchUserID, List<UserDtl> lObjUser)
        {

            using (SqlConnection lObjSrch = new SqlConnection(isConstr))
            {

                //string lsSrchQry = "Select * FROM UserDtl Where  UserID = @UserID";

                string lsSrchQry = "Select UserID,Pwd,UserName,MobNo,EmailID,UserType,LastLoginTime," +
                    "LastPwdChangeTime,Remarks,Created,CreatedBy,Modified," +
                    "ModifiedBy,Deleted,DeletedOn,DeletedBy" +
                    " FROM UserDtl Where  UserID Like '" + isSearchUserID + "%' Order By UserID"; //AND //Deleted='N'";

                SqlCommand lObjCmmd = new SqlCommand(lsSrchQry);
                lObjCmmd.Connection = lObjSrch;
                lObjCmmd.CommandType = CommandType.Text;
                lObjSrch.Open();

                lObjCmmd.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = isSearchUserID;

                using (SqlDataReader lObjReadr = lObjCmmd.ExecuteReader())
                {
                    if (lObjReadr.HasRows)
                    {
                            while (lObjReadr.Read())
                            {
                                msUserID = lObjReadr["UserID"].ToString();
                                msPwd = lObjReadr["Pwd"].ToString();
                                msUserName = lObjReadr["UserName"].ToString();
                                msMobNo = (DBNull.Value.Equals(lObjReadr["MobNo"].ToString()) ? null : lObjReadr["MobNo"].ToString());
                                msEmailID = (DBNull.Value.Equals(lObjReadr["EmailID"].ToString()) ? null : lObjReadr["EmailID"].ToString());
                                msUserType = (DBNull.Value.Equals(lObjReadr["UserType"].ToString()) ? null : lObjReadr["UserType"].ToString());
                                mdLastLoginTime = Convert.ToDateTime(DBNull.Value.Equals(lObjReadr["LastLoginTime"]) ? null : lObjReadr["LastLoginTime"]);
                                mdLastPwdChangeTime = Convert.ToDateTime(DBNull.Value.Equals(lObjReadr["LastPwdChangeTime"]) ? null : lObjReadr["LastPwdChangeTime"]);
                                msRemarks = (DBNull.Value.Equals(lObjReadr["Remarks"].ToString()) ? null : lObjReadr["Remarks"].ToString());
                                mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObjReadr["Created"]) ? null : lObjReadr["Created"]);
                                msCreatedBy = (DBNull.Value.Equals(lObjReadr["CreatedBy"].ToString()) ? null : lObjReadr["CreatedBy"].ToString());
                                mdModified = Convert.ToDateTime(DBNull.Value.Equals(lObjReadr["Modified"]) ? null : lObjReadr["Modified"]);
                                msModifiedBy = (DBNull.Value.Equals(lObjReadr["ModifiedBy"].ToString()) ? null : lObjReadr["ModifiedBy"].ToString());
                                msDeleted = (DBNull.Value.Equals(lObjReadr["Deleted"].ToString()) ? null : lObjReadr["Deleted"].ToString());
                                mdDeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObjReadr["DeletedOn"]) ? null : lObjReadr["DeletedOn"]);
                                msDeletedBy = DBNull.Value.Equals(lObjReadr["DeletedBy"]) ? "" : lObjReadr["DeletedBy"].ToString();

                                lObjUser.Add(new UserDtl(msUserID, msPwd, msUserName, msMobNo, msEmailID, msUserType,
                                   Convert.ToDateTime(mdLastLoginTime), Convert.ToDateTime(mdLastPwdChangeTime), msRemarks, Convert.ToDateTime(mdCreated),
                                    msCreatedBy, Convert.ToDateTime(mdModified), msModifiedBy, msDeleted, Convert.ToDateTime(mdDeletedOn), msDeletedBy));
                            
                            }
                            lObjSrch.Close();
                    }
                    return true;
                }
            }
        }

        public List<UserDtl> ListUsers(string isConstr)
        {
            List<UserDtl> lObjUserD = new List<UserDtl>();


            using (SqlConnection lObjSrch = new SqlConnection(isConstr))
            {

                //string lsSrchQry = "Select * FROM UserDtl Where  UserID = @UserID";

                string lsSrchQry = "Select UserID,Pwd,UserName,MobNo,EmailID,UserType,LastLoginTime," +
                    "LastPwdChangeTime,Remarks,Created,CreatedBy,Modified," +
                    "ModifiedBy,Deleted,DeletedOn,DeletedBy" +
                    " FROM UserDtl";

                SqlCommand lObjCmmd = new SqlCommand(lsSrchQry);
                lObjCmmd.Connection = lObjSrch;
                lObjCmmd.CommandType = CommandType.Text;
                lObjSrch.Open();

              //  lObjCmmd.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = isSearchUserID;

                using (SqlDataReader lObjReadr = lObjCmmd.ExecuteReader())
                {
                    if (lObjReadr.HasRows)
                    {
                        while (lObjReadr.Read())
                        {
                            msUserID = lObjReadr["UserID"].ToString();
                            msPwd = lObjReadr["Pwd"].ToString();
                            msUserName = lObjReadr["UserName"].ToString();
                            msMobNo = (DBNull.Value.Equals(lObjReadr["MobNo"].ToString()) ? null : lObjReadr["MobNo"].ToString());
                            msEmailID = (DBNull.Value.Equals(lObjReadr["EmailID"].ToString()) ? null : lObjReadr["EmailID"].ToString());
                            msUserType = (DBNull.Value.Equals(lObjReadr["UserType"].ToString()) ? null : lObjReadr["UserType"].ToString());
                            mdLastLoginTime = Convert.ToDateTime(DBNull.Value.Equals(lObjReadr["LastLoginTime"]) ? null : lObjReadr["LastLoginTime"]);
                            mdLastPwdChangeTime = Convert.ToDateTime(DBNull.Value.Equals(lObjReadr["LastPwdChangeTime"]) ? null : lObjReadr["LastPwdChangeTime"]);
                            msRemarks = (DBNull.Value.Equals(lObjReadr["Remarks"].ToString()) ? null : lObjReadr["Remarks"].ToString());
                            mdCreated = Convert.ToDateTime(DBNull.Value.Equals(lObjReadr["Created"]) ? null : lObjReadr["Created"]);
                            msCreatedBy = (DBNull.Value.Equals(lObjReadr["CreatedBy"].ToString()) ? null : lObjReadr["CreatedBy"].ToString());
                            mdModified = Convert.ToDateTime(DBNull.Value.Equals(lObjReadr["Modified"]) ? null : lObjReadr["Modified"]);
                            msModifiedBy = (DBNull.Value.Equals(lObjReadr["ModifiedBy"].ToString()) ? null : lObjReadr["ModifiedBy"].ToString());
                            msDeleted = (DBNull.Value.Equals(lObjReadr["Deleted"].ToString()) ? null : lObjReadr["Deleted"].ToString());
                            mdDeletedOn = Convert.ToDateTime(DBNull.Value.Equals(lObjReadr["DeletedOn"]) ? null : lObjReadr["DeletedOn"]);
                            msDeletedBy = DBNull.Value.Equals(lObjReadr["DeletedBy"]) ? "" : lObjReadr["DeletedBy"].ToString();


                            lObjUserD.Add(new UserDtl(msUserID, msPwd, msUserName, msMobNo, msEmailID, msUserType,
                               Convert.ToDateTime(mdLastLoginTime), Convert.ToDateTime(mdLastPwdChangeTime), msRemarks, Convert.ToDateTime(mdCreated),
                                msCreatedBy, Convert.ToDateTime(mdModified), msModifiedBy, msDeleted, Convert.ToDateTime(mdDeletedOn), msDeletedBy));

                        }
                        lObjSrch.Close();
                    }
                    return lObjUserD;
                }
            }
        }




        public bool Delete(string isConStr, string isUserID)
        {
            using (SqlConnection lObjCnnct = new SqlConnection(isConStr))
            {
                string lsQryDel = "Update  UserDtl SET Deleted='Y'  Where UserID=@UserID AND Deleted='N'";


                SqlCommand lObjCmdd = new SqlCommand(lsQryDel);
                lObjCmdd.Connection = lObjCnnct;
                lObjCmdd.CommandType = CommandType.Text;


                lObjCmdd.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = isUserID;
                //lObjCmdd.Parameters.AddWithValue("@DeletedOn", SqlDbType.DateTime).Value = (object)mdDeletedOn ?? DBNull.Value;
               // lObjCmdd.Parameters.AddWithValue("@DeletedBy", SqlDbType.VarChar).Value = (object)msDeletedBy ?? DBNull.Value;


                lObjCnnct.Open();
                lObjCmdd.ExecuteNonQuery();
                lObjCnnct.Close();
            }
            return false;
        }



        public bool Save(string isConStr, string isUserID, bool ibNewMode)
        {
            string lsQrySv = "";

            // UserForm lObjfrm= new UserForm

            using (SqlConnection lObjCnt = new SqlConnection(isConStr))
            {
                // if (ibNewMode.Equals(MasterMechUtil.OPMode.New))

                if (ibNewMode == true)
                {
                    lsQrySv = "Insert Into UserDtl(UserID,Pwd,UserName,MobNo,EmailID," +
                        "UserType,Remarks,Created,Deleted) VALUES(@UserID,@Pwd,@UserName,@MobNo," +
                        "@EmailID,@UserType,@Remarks,@Created,'N')";
                }
                else
                {
                    lsQrySv = "Update UserDtl SET UserName=@UserName," +
                        "MobNo=@MobNo,EmailID=@EmailID,UserType=@UserType," +
                       "Remarks=@Remarks,Modified=@Modified,ModifiedBy=@ModifiedBy  " +
                       " Where UserID=@UserID  AND Deleted='N'";
                }

                using (SqlCommand lObjCmdSv = new SqlCommand(lsQrySv, lObjCnt))
                { 
                    //lObjCmdSv.Connection = lObjCnt;
                    lObjCmdSv.CommandType = CommandType.Text;

                    lObjCmdSv.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = msUserID;
                    lObjCmdSv.Parameters.AddWithValue("@Pwd", SqlDbType.VarChar).Value = msPwd;
                    lObjCmdSv.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = msUserName;
                    lObjCmdSv.Parameters.AddWithValue("@MobNo", SqlDbType.VarChar).Value = (object)msMobNo ?? DBNull.Value;
                    lObjCmdSv.Parameters.AddWithValue("@EmailID", SqlDbType.VarChar).Value = (object)msEmailID ?? DBNull.Value;
                    lObjCmdSv.Parameters.AddWithValue("@UserType", SqlDbType.VarChar).Value = (object)msUserType ?? DBNull.Value;
                    lObjCmdSv.Parameters.AddWithValue("@Remarks", SqlDbType.VarChar).Value = (object)msRemarks ?? DBNull.Value;
                    

                    if (ibNewMode == true)
                    {
                        lObjCmdSv.Parameters.AddWithValue("@Created", SqlDbType.VarChar).Value = (object)DateTime.Now ?? DBNull.Value;
                        lObjCmdSv.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = (object)msCreatedBy ?? DBNull.Value;
                    }
                    else
                    {
                        lObjCmdSv.Parameters.AddWithValue("@Modified", SqlDbType.DateTime).Value = (object)DateTime.Now ?? DBNull.Value;
                        lObjCmdSv.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = (object)msModifiedBy ?? DBNull.Value;
                    }


                        // lObjCmdSv.Parameters.AddWithValue("@LastLoginTime", SqlDbType.DateTime).Value = (object)mdLastLoginTime ?? DBNull.Value;


                        //lObjCmdSv.Parameters.AddWithValue("@LastPwdChangeTime", SqlDbType.DateTime).Value = (object)mdLastPwdChangeTime ?? DBNull.Value;


                        // lObjCmdSv.Parameters.AddWithValue("@LastPwdChangeTime", SqlDbType.DateTime).Value = mdLastPwdChangeTime;


                        //lObjCmdSv.Parameters.AddWithValue("@Remarks", SqlDbType.VarChar).Value = (object)msRemarks ?? DBNull.Value;


                        lObjCnt.Open();
                    lObjCmdSv.ExecuteNonQuery();
                    lObjCnt.Close();
                }
                return true;
            }
        }



    }
}
