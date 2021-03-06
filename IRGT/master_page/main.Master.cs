﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace IRGT.master_page
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserCode = cCommon.getUserName(Session);
            if (UserCode == "")
            {
                Response.Redirect("../page/login.html");
                return;
            }

            labUserLogin.Text = UserCode;

            XmlDocument xmlMenu = new XmlDocument();
            xmlMenu.Load(Server.MapPath("../config/Menu.xml"));

            string MenuText = "Menu";
            string PageID = Request.QueryString["PageID"];
            if (PageID == null) PageID = "XXXXXXXXXXXXXXXX";
            if (PageID == "") PageID = "XXXXXXXXXXXXXXXX";


            string LANG = cCommon.getLanguage(Request);


            if (LANG == cCommon.Language_Thai)
            {
                Session["text_placeholder"] = "โปรดระบุ";
                Session["search_placeholder"] = "ทั้งหมด";
                Session["text_search"] = "ค้นหา";
            }
            else
            {
                Session["text_placeholder"] = "please specify";
                Session["search_placeholder"] = "All";
                Session["text_search"] = "Search";
            }



            string SMenu = "";
            XmlNodeList listMenu = xmlMenu.SelectNodes("//Menus/Menu");
            for (int i = 0; i < listMenu.Count; i++)
            {
                string ID = listMenu[i].Attributes["ID"].Value;
                string Name = listMenu[i].Attributes["Name"].Value;
                string TextTH = listMenu[i].Attributes["TextTH"].Value;
                string TextEN = listMenu[i].Attributes["TextEN"].Value;
                string Text = "";
                if (LANG.Trim().ToUpper() == cCommon.Language_Thai)
                {
                    MenuText = "เมนูระบบ";
                    Text = TextTH;
                }
                else
                {
                    MenuText = "Menu";
                    Text = TextEN;
                }

                string li_class = "";

                if (PageID == ID)
                    li_class = "active";
                if (PageID.Substring(0, ID.Length) == ID)
                    li_class += " open";

                XmlNodeList listSubMenu = listMenu[i].SelectNodes("./Menu");
                string Url = "";
                if (listSubMenu.Count == 0)
                    Url = listSubMenu[i].Attributes["Url"].Value + "?PageID=" + ID + "&lang=" + LANG;

                SMenu += "<li class='" + li_class + "'>";
                if (listSubMenu.Count > 0)
                    SMenu += "<a href='" + Url + "' class='dropdown-toggle'>";
                else
                    SMenu += "<a href='" + Url + "'>";

                SMenu += "<i class='menu-icon fa fa-cog'></i>";
                SMenu += "<span class='menu-text'>" + Text + "</span>";
                if (listSubMenu.Count > 0)
                    SMenu += "<b class='arrow fa fa-angle-down'></b>";
                SMenu += "</a>";
                if (listSubMenu.Count > 0)
                {
                    SMenu += "<b class='arrow'></b>";
                    SMenu += "<ul class='submenu'>";
                    for (int j = 0; j < listSubMenu.Count; j++)
                    {
                        string subID = listSubMenu[j].Attributes["ID"].Value;
                        string subName = listSubMenu[j].Attributes["Name"].Value;
                        string subTextTH = listSubMenu[j].Attributes["TextTH"].Value;
                        string subTextEN = listSubMenu[j].Attributes["TextEN"].Value;
                        string subText = "";
                        if (LANG.Trim().ToUpper() == "TH")
                            subText = subTextTH;
                        else
                            subText = subTextEN;


                        li_class = "";
                        if (PageID == ID + "-" + subID)
                            li_class = "active";
                        if (PageID.Substring(0, (ID + "-" + subID).Length) == ID + "-" + subID)
                            li_class += " open";


                        XmlNodeList listSubSubMenu = listSubMenu[j].SelectNodes("./Menu");
                        string subUrl = "";
                        if (listSubSubMenu.Count == 0)
                            subUrl = listSubSubMenu[j].Attributes["Url"].Value + "?PageID=" + ID + "-" + subID + "&lang=" + LANG;

                        SMenu += "<li class='" + li_class + "'>";
                        if (listSubSubMenu.Count > 0)
                            SMenu += "<a href='" + subUrl + "' class='dropdown-toggle'>";
                        else
                            SMenu += "<a href='" + subUrl + "'>";

                        SMenu += "<i class='menu-icon fa fa-caret-right'></i>";
                        SMenu += subText;
                        if (listSubSubMenu.Count > 0)
                            SMenu += "<b class='arrow fa fa-angle-down'></b>";
                        SMenu += "</a>";
                        if (listSubSubMenu.Count > 0)
                        {
                            SMenu += "<b class='arrow'></b>";
                            SMenu += "<ul class='submenu'>";


                            for (int k = 0; k < listSubSubMenu.Count; k++)
                            {
                                string sub_subID = listSubSubMenu[k].Attributes["ID"].Value;
                                string sub_subName = listSubSubMenu[k].Attributes["Name"].Value;
                                string sub_subTextTH = listSubSubMenu[k].Attributes["TextTH"].Value;
                                string sub_subTextEN = listSubSubMenu[k].Attributes["TextEN"].Value;
                                string sub_subUrl = listSubSubMenu[k].Attributes["Url"].Value + "?PageID=" + ID + "-" + subID + "-" + sub_subID + "&lang=" + LANG;
                                string sub_subText = "";
                                if (LANG.Trim().ToUpper() == "TH")
                                    sub_subText = sub_subTextTH;
                                else
                                    sub_subText = sub_subTextEN;

                                li_class = "";
                                if (PageID == ID + "-" + subID + "-" + sub_subID)
                                    li_class = "active open";

                                SMenu += "<li class='" + li_class + "'>";
                                SMenu += "<a href='" + sub_subUrl + "'>";
                                SMenu += "<i class='menu-icon fa fa-caret-right'></i>";
                                SMenu += sub_subText;
                                SMenu += "</a>";
                                SMenu += "<b class='arrow'></b>";
                                SMenu += "</li>";

                            }
                            SMenu += "</ul>";

                        }

                        SMenu += "</li>";
                    }
                    SMenu += "</ul>";
                }


                SMenu += "</li>";
            }




            labMenu.Text = @"<ul class='nav nav-list'>
                <li class='green'>
					<a href='#'>
						<i class='menu-icon fa fa-list'></i>
						<span class='menu-text'>" + MenuText + @"</span>
					</a>						
				</li>
				" + SMenu + "</ul>";
        }
    }
}