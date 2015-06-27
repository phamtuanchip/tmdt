using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Entity;
using Bussiness;

namespace WebComputer.Control.Admin
{
    public partial class Left : System.Web.UI.UserControl
    {
        protected Hashtable Lang = new Hashtable();
        protected Entity.Entities objLang = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
  
        #region var SystemManager
        private string strGroupAddnew = "membergroup_addnew";
        private string strGroupList = "membergroup_list";
        private string strUserAddnew = "member_addnew";
        private string strMemberList = "member_list";
        private string strLog = "log_list";
        #endregion var SystemManager

        #region Var ProductManager
        private string strCatProAddnew = "Category_Pro_AddNew";
        private string strCatProList = "Category_Pro_List";
        private string strCatProdEdit = "Category_Pro_Edit";
        //private string strCatProDelete = "Category_Pro_Delete";
        #endregion


        #region Var Order Manger
        private string strCustomer = "Customer_List";
        private string strOrder_List = "Order_List";
        private string strOrder_Edit = "Order_Edit";
        //private string strProvider_debt = "Customer_List";
        #endregion

        #region Var Report Manager
        private string strReport_List = "Report_List";
        private string strReport_Edit = "Report_Edit";

        #endregion

        #region var News Manager
        //private string strNewsManager = "newscat_list,news_addnew,news_list,news_publish,librarycatimage_list,libraryimage_list";
        private string strNewsManager = "newscat_list,news_addnew,news_list,news_publish";
        private string strNewsCatManager = "newscat_list,news_publish";
        private string strNewsAddnew = "news_addnew,news_publish";
        private string strNewsManager_List = "news_list,news_publish";
        //private string strLibraryCatImages = "librarycatimage_list";
        //private string strLibraryImages = "libraryimage_list";
        #endregion var News Manager

        #region var Banner, Logog Manager
        private string strBannerLogoManager = "logocat_list,logo_addnew,logo_list,bannercat_list,banner_addnew,banner_list";
        private string strLogoCat = "logocat_list";
        private string strLogoAddnew = "logo_addnew";
        private string strLogoManager = "logo_list";
        private string strBannerCat = "bannercat_list";
        private string strBannerAddnew = "banner_addnew";
        private string strBannerManager = "banner_list";
        #endregion var Banner, Logo Manager

        #region Var Gallery
        private string strCatGallery = "gallerycat_addnew,gallerycat_list";
        private string strGallery = "gallerycat_list,gallery_edit";
        #endregion

        #region Var Recruit Manager
        private string strRecruit = "recruit_list,recruit_addnew,recruit_edit,recruit_delete";
        //private string strRecruit = "recruit_list";
        #endregion

        #region Var FAQ Manager
        private string strFaq_List = "FAQ_List,FAQ_Delete";
        private string strFaq_Edit = "FAQ_AddNew,Order_Edit";

        #endregion

        #region var Orther Manager
        private string strIntroManager = "document_addnew,document_list,document_publish";
        //private string strIntroCatManager = "document_publish";
        private string strIntroAddnew = "document_addnew,document_publish";
        private string strIntroManager_List = "document_list,document_publish";
        #endregion var News Manager

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objLang.GetLanguage("Left_Manager");
            this.CheckPermissionLeft();
        }
        protected void CheckPermissionLeft()
        {
            #region System Manager
            if (objBusinessLogic.Permission(this.strGroupAddnew) == true)
                this.GroupAddnew_Id.Visible = true;
            else
                this.GroupAddnew_Id.Visible = false;
            if (objBusinessLogic.Permission(this.strGroupList) == true)
                this.GroupList_Id.Visible = true;
            else
                this.GroupList_Id.Visible = false;
            if (objBusinessLogic.Permission(this.strUserAddnew) == true)
                this.UserAddnew_Id.Visible = true;
            else
                this.UserAddnew_Id.Visible = false;
            if (objBusinessLogic.Permission(this.strMemberList) == true)
                this.MemberList_Id.Visible = true;
            else
                this.MemberList_Id.Visible = false;
            if (objBusinessLogic.Permission(this.strLog) == true)
            {
                this.ActionLogAction_Id.Visible = true;
                this.ActionLogLogin_Id.Visible = true;
            }
            else
            {
                this.ActionLogAction_Id.Visible = false;
                this.ActionLogLogin_Id.Visible = false;
            }
            #endregion System Manager

            #region Product Manager
            if (objBusinessLogic.Permission(this.strCatProAddnew) == true)
                this.Cat_Pro_List_Id.Visible = true;
            else
            {
                this.Cat_Pro_List_Id.Visible = false;
                this.ProManager_id.Visible = false;
            }
            if (objBusinessLogic.Permission(this.strCatProList) == true)
                this.Cat_Pro_Group_List.Visible = true;
            else
                this.Cat_Pro_Group_List.Visible = false;
            if (objBusinessLogic.Permission(this.strCatProdEdit) == true)
                this.Pro_List.Visible = true;
            else
                this.Pro_List.Visible = false;
          

            #endregion

            #region Order Manager
            if (objBusinessLogic.Permission(this.strCustomer) == true)
                this.Customer_Id.Visible = true;
            else
            {
                this.Customer_Id.Visible = false;
                this.Order_Manager_id.Visible = false;
            }
            if (objBusinessLogic.Permission(this.strOrder_List) == true)
                this.Order_List.Visible = true;
            else
            {
                this.Order_List.Visible = false;
                this.Order_Manager_id.Visible = false;
            }
            if (objBusinessLogic.Permission(this.strOrder_Edit) == true)
                this.Order_Eidt.Visible = true;
            else
                this.Order_Eidt.Visible = false;

            #endregion

            #region Report Manager
            if (objBusinessLogic.Permission(this.strReport_List) == true)
                this.Report_Product.Visible = true;
            else
            {
                this.Report_Product.Visible = false;
                this.Report_Manager_id.Visible = false;
            }
            if (objBusinessLogic.Permission(this.strReport_Edit) == true)
                this.Report_Order.Visible = true;
            else
                this.Report_Order.Visible = false;
            if (objBusinessLogic.Permission(this.strReport_List) == true)
                this.Report_ProMax.Visible = true;
            else
                this.Report_ProMax.Visible = false;
            if (objBusinessLogic.Permission(this.strReport_Edit) == true)
                this.Report_DateTime.Visible = true;
            else
                this.Report_DateTime.Visible = false;
            #endregion

            #region Recruit Manager
            if (objBusinessLogic.Permission(this.strRecruit) == true)
                this.RecruitManager_Id.Visible = true;
            else
            {
                this.RecruitManager_Id.Visible = false;
                this.OtherManager_Id.Visible = false;
            }
            
            #endregion

            #region News Manager
            if (objBusinessLogic.Permission(this.strNewsManager) == true)
            {
               // this.NewsManager_Id.Visible = true;
                this.NewsManagerSpace_Id.Visible = true;
            }
            else
            {
               this.NewsManagerSpace_Id.Visible = false;
               this.NewsManager_Id.Visible = false;
            }
            if (objBusinessLogic.Permission(this.strNewsCatManager) == true)
                this.NewsCatManager_Id.Visible = true;
            else
                this.NewsCatManager_Id.Visible = false;
            if (objBusinessLogic.Permission(this.strNewsAddnew) == true)
                this.NewsAddnew_Id.Visible = true;
            else
                this.NewsAddnew_Id.Visible = false;
            if (objBusinessLogic.Permission(this.strNewsManager_List) == true)
                this.NewsManager_List_Id.Visible = true;
            else
                this.NewsManager_List_Id.Visible = false;
            //if (objBusinessLogic.Permission(this.strLibraryCatImages) == true)
            //    this.LibraryCatImages_Id.Visible = true;
            //else
            //    this.LibraryCatImages_Id.Visible = false;
            //if (objBusinessLogic.Permission(this.strLibraryImages) == true)
            //    this.LibraryImages_Id.Visible = true;
            //else
            //    this.LibraryImages_Id.Visible = false;
            #endregion News Manager

            #region Banner, Logo Manager
            if (objBusinessLogic.Permission(this.strBannerLogoManager) == true)
            {
                this.BannerLogoManager_Id.Visible = true;
                this.BannerLogoManagerSpace_Id.Visible = true;
            }
            else
            {
                this.BannerLogoManager_Id.Visible = false;
                this.BannerLogoManagerSpace_Id.Visible = false;
            }
            if (objBusinessLogic.Permission(this.strLogoCat) == true)
                this.LogoCat_Id.Visible = true;
            else
                this.LogoCat_Id.Visible = false;
            if (objBusinessLogic.Permission(this.strLogoAddnew) == true)
                this.LogoAddnew_Id.Visible = true;
            else
                this.LogoAddnew_Id.Visible = false;
            if (objBusinessLogic.Permission(this.strLogoManager) == true)
                this.LogoManager_Id.Visible = true;
            else
                this.LogoManager_Id.Visible = false;
            if (objBusinessLogic.Permission(this.strBannerCat) == true)
                this.BannerCat_Id.Visible = true;
            else
                this.BannerCat_Id.Visible = false;
            if (objBusinessLogic.Permission(this.strBannerAddnew) == true)
                this.BannerAddnew_Id.Visible = true;
            else
                this.BannerAddnew_Id.Visible = false;
            if (objBusinessLogic.Permission(this.strBannerManager) == true)
                this.BannerManager_Id.Visible = true;
            else
                this.BannerManager_Id.Visible = false;
            #endregion Banner, Logo Manager

            #region Gallery Manager
            if (objBusinessLogic.Permission(this.strCatGallery) == true)
            {
                this.CatGallery_id.Visible = true;
                this.AddNewCatGallry_id.Visible = true;

            }
            else
            {
                this.CatGallery_id.Visible = false;
                this.AddNewCatGallry_id.Visible = false;
                this.Manager_Gallery_id.Visible = false;
            }
            if (objBusinessLogic.Permission(this.strGallery) == true)
            {
                this.GalleryList_id.Visible = true;
                this.GalleryAdd_id.Visible = true;
            }
            else
            {
                this.GalleryList_id.Visible = false;
                this.GalleryAdd_id.Visible = false;
            }
            #endregion

            #region Introduction Manager
            if (objBusinessLogic.Permission(this.strIntroManager) == true)
            {
                this.DocumentManager.Visible = true;
                //this.Tr2.Visible = true;
            }
            else
            {
                this.DocumentManager.Visible = false;
                //this.Tr2.Visible = false;
            }

            if (objBusinessLogic.Permission(this.strIntroAddnew) == true)
            {
                this.Tr1.Visible = true;
            }
            else
            {
                this.Tr1.Visible = false;
            }
            if (objBusinessLogic.Permission(this.strIntroManager_List) == true)
            {
                this.Tr9.Visible = true;
            }
            else
            {
                this.Tr9.Visible = false;
            }




            #endregion Orther Manager

            #region FAQ Manager
            if (objBusinessLogic.Permission(this.strFaq_List) == true)
            {
                this.FAQs_Manager_List.Visible = true;
            }
            else
            {
                this.FAQs_Manager_List.Visible = false;
                this.FAQs_Manager_id.Visible = false;
            }
             if (objBusinessLogic.Permission(this.strFaq_Edit) == true)
                  this.FAQs_Manager_Edit.Visible = true;
            else
                  this.FAQs_Manager_Edit.Visible = false;
            
            #endregion

        }
    }
}