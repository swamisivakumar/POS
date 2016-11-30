using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Inventory
{
    public class GlobalData
    {
        private static string _ShopName;
        public static string ShopName
        {
            get { return GlobalData._ShopName; }
            set { GlobalData._ShopName = value; }
        }
        private static string _Logo;
        public static string Logo
        {
            get { return GlobalData._Logo; }
            set { GlobalData._Logo = value; }
        }

        private static string _UserID;
        public static string UserID
        {
            get { return GlobalData._UserID; }
            set { GlobalData._UserID = value; }
        }

        private static string _UserName;
        public static string UserName
        {
            get { return GlobalData._UserName; }
            set { GlobalData._UserName = value; }
        }

        private static string _RoleId;
        public static string RoleId
        {
            get { return GlobalData._RoleId; }
            set { GlobalData._RoleId = value; }
        }

        private static string _RoleName;
        public static string RoleName
        {
            get { return GlobalData._RoleName; }
            set { GlobalData._RoleName = value; }
        }


        private static string _phCustId;
        public static string phCustId
        {
            get { return GlobalData._phCustId; }
            set { GlobalData._phCustId = value; }
        }

        private static string _pAreaId;
        public static string PAreaId
        {
            get { return GlobalData._pAreaId; }
            set { GlobalData._pAreaId = value; }
        }

        private static string _pTransactionNo;
        public static string TransactionNo
        {
            get { return GlobalData._pTransactionNo; }
            set { GlobalData._pTransactionNo = value; }
        }
       
        private static string _pCustName;
        public static string PCustName
        {
            get { return GlobalData._pCustName; }
            set { GlobalData._pCustName = value; }
        }

        private static string _pCustAddr;
        public static string PCustAddr
        {
            get { return GlobalData._pCustAddr; }
            set { GlobalData._pCustAddr = value; }
        }

        private static string _pPhoneNo;
        public static string PPhoneNo
        {
            get { return GlobalData._pPhoneNo; }
            set { GlobalData._pPhoneNo = value; }
        }

        private static string _ReportName;

        public static string ReportName
        {
            get { return GlobalData._ReportName; }
            set { GlobalData._ReportName = value; }
        }


        private static byte[] _BarcodeImage;
        public static byte[] BarcodeImage
        {
            get { return GlobalData._BarcodeImage; }
            set { GlobalData._BarcodeImage = value; }
        }

        private static Int32 _NoofBarcode;
        public static Int32 NoofBarcode
        {
            get { return GlobalData._NoofBarcode; }
            set { GlobalData._NoofBarcode = value; }
        }


        private static string _ItemAndPrice;
        public static string ItemAndPrice
        {
            get { return GlobalData._ItemAndPrice; }
            set { GlobalData._ItemAndPrice = value; }
        }

        private static DataTable _Dtpopup;

        public static DataTable Dtpopup
        {
            get { return GlobalData._Dtpopup; }
            set { GlobalData._Dtpopup = value; }
        }


        private static string _ItemIDs;

        public static string ItemIDs
        {
            get { return GlobalData._ItemIDs; }
            set { GlobalData._ItemIDs = value; }
        }

       
        public static string Invoiceno { get; set; }
    }
}
