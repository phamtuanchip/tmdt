﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Entity;
using Bussiness;

namespace WebComputer.Admin
{
    public partial class ActionLog_Login : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Entity.Entities objEntities = new Entity.Entities();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "log_list";
        private string strUsername = string.Empty;
        private string strIP = string.Empty;
        private string strFromDate = string.Empty;
        private string strToDate = string.Empty;
        public string strLogin_Delete = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("ActionLog_Manager");
            this.strLogin_Delete = Lang["delete"].ToString();
            this.ActionLoginSearch.Text = Lang["Search"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.GetActionLogin();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void GetActionLogin()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_ActionLogin", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@UserName", strUsername);
            comm.Parameters.AddWithValue("@Ip", strIP);
            comm.Parameters.AddWithValue("@FromDate", strFromDate);
            comm.Parameters.AddWithValue("@ToDate", strToDate);
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dts);
            this.GV_ActionLogin.DataSource = dts;
            this.GV_ActionLogin.DataBind();
            dts.Clear();
            adt.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected void GV_ActionLogin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_ActionLogin.PageIndex = e.NewPageIndex;
            GetActionLogin();
        }
        protected void ActionLoginSearch_Click(object sender, EventArgs e)
        {
            this.strUsername = objEntities.SafeString(this.txtUserName.Text);
            this.strIP = objEntities.SafeString(this.txtIP.Text);
            if (Request.Form["FromDate"] != null && Request.Form["FromDate"].ToString() != "")
            {
                this.strFromDate = objEntities.SafeString(Request.Form["FromDate"].ToString());
            }
            if (Request.Form["ToDate"] != null && Request.Form["ToDate"].ToString() != "")
            {
                this.strToDate = objEntities.SafeString(Request.Form["ToDate"].ToString());
            }
            this.GetActionLogin();
        }
    }
}
