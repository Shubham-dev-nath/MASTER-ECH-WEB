using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MasterMechLib
{
    public  class MasterMechUtil
    {
        public enum OPMode
        {
            New,
            Open,
            Delete,
        }


        public static string sUserID;
        public static string sUserName;
        public static string isMsg;
        public static string mbBussiState = "Jharkhand";
        public static string sArAddr = "Usha Paras Smriti,Sky Residence,Adityapur";
        public static string sGSTNo = "20AAAAA0000A1Z5";
        public static string sCoName = "NapaSoft Excellence n Simplicity";
        public static string sCity = "Jamshedpur";
        public static string sStAddr = "Line-5,Road-12,Block-16";
        public static string sPassrd;
        
       public static string sUserType;

        public static string Constr = "Data Source=LAPTOP-9VC0QBFV\\SQLEXPRESS01;Initial Catalog = MasterMech; Integrated Security = True";
        public static string User = "UserID";


        private static string sFinYear;

        public static bool ShowError(string isMsg)
        {
#if DEBUG   // when Debug is selected an additional information by the programmer can be given else 
            // when Release is selected in it it won't work 
            System.Diagnostics.Debug.WriteLine(isMsg); 
#else
            MessageBox.Show(isMsg);
#endif
            return true;
        }


        public static string sFY
        {
            set
            {
                if (Regex.IsMatch(value, @"^(\d{4})-\d{2}$", RegexOptions.IgnoreCase))
                    sFinYear = value;
                else
                    throw new ArgumentException(string.Format("{0} is not a valid value for", value), "sFY");

            }
            get
            {
                return sFinYear;
            }
        }


        public static string[] FYList()
        {
            string[] lsFYList = new string[10];
            int lnCount = 0;
            int lnCurrYear = DateTime.Now.Year;
            int lnyear = lnCurrYear - 5;


            for(lnCount = 0;lnCount < 10;lnCount++)
                lsFYList[lnCount] = lnyear.ToString() + "-" + (lnyear++ + 1).ToString().Substring(2);

            return lsFYList;
        }


        public static string CurrFY()
        {
            if (DateTime.Now.Month >= 4)
                return (DateTime.Now.Year.ToString() + " - " + (DateTime.Now.Year + 1).ToString().Substring(2));
            else
                return((DateTime.Now.Year-1).ToString() + " - " +DateTime.Now.Year.ToString().Substring(2));
        }


        public static string Encrypt(string encryptString)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }


        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


    }
}
