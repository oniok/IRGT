﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AssetQuota : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string PageFunction = "asset_quota";
        string LANG = cCommon.getLanguage(Request);
        Session["language_" + PageFunction] = LANG;

        if (LANG == cCommon.Language_Thai)
        {
            //================ POPUP ==================================================
            string PageName = "ปริมาณครุภัณฑ์";

            Session["pop_add_" + PageFunction] = "หน้าต่างจัดการ - เพิ่มข้อมูล" + PageName;
            Session["pop_edit_" + PageFunction] = "หน้าต่างจัดการ - แก้ไขข้อมูล" + PageName;
            Session["pop_delete_" + PageFunction] = "คุณแน่ใจหรือไม่ที่จะลบข้อมูล" + PageName + "นี้ ?";
            Session["pop_confirm_" + PageFunction] = "ยืนยันการลบข้อมูล";

            Session["save_button_text"] = "บันทึก";
            Session["close_button_text"] = "ปิดหน้านี้";
            //================ POPUP ERROR ===========================================
            Session[PageFunction + "_ERROR_01"] = "โปรดเลือก ชื่อครุภัณฑ์";
            Session[PageFunction + "_ERROR_02"] = "โปรดเลือก หน่วยงาน";
            Session[PageFunction + "_ERROR_04"] = "โปรดระบุ วันที่เริ่มต้น";
            Session[PageFunction + "_ERROR_05"] = "โปรดระบุ วันที่สิ้นสุด";
            Session[PageFunction + "_ERROR_06"] = "วันที่สิ้นสุดต้องมากกว่าหรือเท่ากับวันที่เริ่มต้น";
            //================ TABLE ==================================================
            Session["HeaderText"] = PageName;
            Session["HeaderTable"] = "ข้อมูล - " + PageName;
            Session["add_button"] = "เพิ่มข้อมูล";
            Session["PageText"] = "หน้าที่";
            Session["PageLast"] = "หน้า";
            Session["PageStart"] = "จำนวนทั้งหมด";
            Session["PageRecord"] = "รายการ";
            //================ Navigate ================================================
            Session["HeaderGroup"] = "ผู้ดูแลระบบ";
            Session["HeaderSubGroup"] = "อื่น ๆ";
            Session["HeaderCurrent"] = PageName;
            //================ Column ==================================================   
            Session[PageFunction + "_ColumnSEQ"] = "ลำดับ";
            Session[PageFunction + "_ColumnEdit"] = "";
            Session[PageFunction + "_Column01"] = "ชื่อครุภัณฑ์";
            Session[PageFunction + "_Column02"] = "หน่วยงาน";
            Session[PageFunction + "_Column03"] = "จำนวนกรอบครุภัณฑ์";
            Session[PageFunction + "_Column04"] = "วันที่เริ่มใช้งาน";
            Session[PageFunction + "_Column05"] = "วันที่สิ้นสุด";
            Session[PageFunction + "_Column06"] = "จำนวนที่มีอยู่";

        }
        else
        {
            //================ POPUP ==================================================
            string PageName = "Asset Quota";
            Session["pop_add_asset_type"] = "window management - New " + PageName;
            Session["pop_edit_asset_type"] = "window management - Edit " + PageName;
            Session["pop_delete_asset_type"] = "Are you sure you want to delete this " + PageName + "?";
            Session["pop_confirm_asset_type"] = "Confirm Delete Data";

            Session["save_button_text"] = "Save";
            Session["close_button_text"] = "Close";
            //================ POPUP ERROR ===========================================
            Session[PageFunction + "_ERROR_01"] = "Please specify Asset";
            Session[PageFunction + "_ERROR_02"] = "Please specify Work Center";
            Session[PageFunction + "_ERROR_04"] = "Please specify Start Date";
            Session[PageFunction + "_ERROR_05"] = "Please specify End Date";
            Session[PageFunction + "_ERROR_06"] = "End Date must be greater than or equal to the start date.";
            //================ TABLE ==================================================
            Session["HeaderText"] = PageName;
            Session["HeaderTable"] = PageName + " Data";
            Session["add_button"] = "New Data";
            Session["PageText"] = "Page";
            Session["PageLast"] = "Page";
            Session["PageStart"] = "Total";
            Session["PageRecord"] = "record";
            //================ Navigate ================================================
            Session["HeaderGroup"] = "Administrator";
            Session["HeaderSubGroup"] = "Asset Master";
            Session["HeaderCurrent"] = PageName;
            //================ Column ==================================================     
            Session[PageFunction + "_ColumnSEQ"] = "No";
            Session[PageFunction + "_ColumnEdit"] = "";
            Session[PageFunction + "_Column01"] = "Asset";
            Session[PageFunction + "_Column02"] = "Work Center";
            Session[PageFunction + "_Column03"] = "Quota Qty";
            Session[PageFunction + "_Column04"] = "Start Date";
            Session[PageFunction + "_Column05"] = "End Date";
            Session[PageFunction + "_Column06"] = "Stock Qty";
        }
    }
}