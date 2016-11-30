using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Inventory
{
   public class SecureDongle
    {
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-
        [DllImport("SDX.dll")]
        static extern int SDX_Find();
        [DllImport("SDX.dll")]
        static extern int SDX_Open(int mode, Int32 uid, ref Int32 hid);
        [DllImport("SDX.dll")]
        static extern void SDX_Close(int handle);
        [DllImport("SDX.dll")]
        static extern int SDX_Read(int handle, int block_index, byte[] buffer512);
        [DllImport("SDX.dll")]
        static extern int SDX_Write(int handle, int block_index, String buffer512);
        [DllImport("SDX.dll")]
        static extern int SDX_GetVersion(int handle);
        [DllImport("SDX.dll")]
        static extern int SDX_Transform(int handle, int len, byte[] bufferData);
        [DllImport("SDX.dll")]
        static extern int SDX_RSAEncrypt(int handle, int startIndex, String bufferData, ref int len, byte[] key512);
        [DllImport("SDX.dll")]
        static extern int SDX_RSADecrypt(int handle, int startIndex, byte[] bufferData, ref int len, byte[] key512);
        const int HID_MODE = -1;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        int ret = 0;
        Int32 handle = 0;
        Int32 hid = 0;
        Int32 uid = 0;
        String seed, Writebuff, error;
        byte[] key512 = new byte[512];
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=
        #region global Declaration for custom messagebox
        FrmMessage.enumMessageIcon InformationIcon = FrmMessage.enumMessageIcon.Information;
        FrmMessage.enumMessageIcon QuestionIcon = FrmMessage.enumMessageIcon.Question;
        FrmMessage.enumMessageIcon ErrorIcon = FrmMessage.enumMessageIcon.Error;

        FrmMessage.enumMessageButton OkButton = FrmMessage.enumMessageButton.OK;
        FrmMessage.enumMessageButton YesNoButton = FrmMessage.enumMessageButton.YesNo;
        FrmMessage.enumMessageButton OkCancelButton = FrmMessage.enumMessageButton.OKCancel;
        string caption = "Inventory Management";
        #endregion
       public string SecureDongleCheck()
       {
           try
           {
               error = null;
               ret = SDX_Find();
               if (ret < 0)
               {
                   error = String.Format(" Finding SecureDongle X: {0:X}", ret);
                   //Application.Exit();
               }

               if (ret == 0)
               {
                   error = String.Format("No Security Device is connected. Please Connect the Security Device and try again !!!");
                   
                   //Application.Exit();
               }
               else
               {
                   uid = 715400947;
                   ret = SDX_Open(1, uid, ref hid);

                   if (ret < 0)
                   {
                       error = String.Format("Incorrect Security Device is connected. Please Try Again with Correct One !!!");
                              
                       //FrmMessage.Show(error, caption, OkButton, ErrorIcon);
                       //Application.Exit();
                   }
               }

                     

           }
           catch (Exception ex)
           {
              // MessageBox.Show(ex.ToString());
               //Application.Exit();
           }
           finally
           {
                   
           }
           return error; 
       }

    }
}
