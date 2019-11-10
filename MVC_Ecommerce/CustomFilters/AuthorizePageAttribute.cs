﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Ecommerce.CustomFilters
{
    public class AuthorizePageAttribute: AuthorizeAttribute
    {
        private readonly string _roleID;

        public AuthorizePageAttribute( int paramRole)
        {
            _roleID = paramRole.ToString();
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            int roleID = Convert.ToInt32(_roleID);
            /*Create permission string based on the requested controller 
              name and action name in the format 'controllername-action'*/
            string requiredPermission = String.Format("{0}_{1}",
                   filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                   filterContext.ActionDescriptor.ActionName);



            /*Create an instance of our custom user authorisation object passing requesting 
              user's 'Windows Username' into constructor*/
           string user = filterContext.RequestContext
                                                   .HttpContext.User.Identity.Name;

            bool isPersmission = false;

            if (HttpContext.Current.Session["SESSION_USER_ID"] == null)
            {
                var context = filterContext.HttpContext;
                string redirectTo = "~/Account/Login";
                if (!string.IsNullOrEmpty(context.Request.RawUrl))
                {
                    redirectTo = string.Format("~/Account/Login?ReturnUrl={0}",
                        HttpUtility.UrlEncode(context.Request.RawUrl));
                }
                filterContext.Controller.ViewBag.ShowPopup = true;
                filterContext.Controller.ViewBag.IsSuccess = false;
                filterContext.Controller.ViewBag.Message = "There was no activity since last 30 minutes. Your session is expired.";
                filterContext.Result = new RedirectToRouteResult(
                                          new RouteValueDictionary {
                                                { "action", "Login" },
                                                { "controller", "Account" } });
            }
    
            //if(HttpContext.Current.Session["SESSION_ADMIN"].ToString() == )
            //{

            //}

            else if (HttpContext.Current.Session["SESSION_ROLE_ID"].ToString() != _roleID || 
                HttpContext.Current.Session["SESSION_ROLE_ID"].ToString() != "1")
            {
                isPersmission = false;
            }
            else if (HttpContext.Current.Session["SESSION_ADMIN"].ToString() != _roleID)
            {

                isPersmission = false;
               
            }


            if(!isPersmission)
            {
                filterContext.Result = new RedirectToRouteResult(
                                            new RouteValueDictionary {
                                                { "action", "UnAuthorizedUser" },
                                                { "controller", "Account" } });
            }

        }
    }
}