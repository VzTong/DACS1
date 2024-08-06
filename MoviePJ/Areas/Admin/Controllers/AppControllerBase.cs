using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Filters;
using MoviePJ.WebConfig.Consts;
using AspNetCoreHero.ToastNotification.Abstractions;
using MoviePJ.Controllers;
using MoviePJ.Entities;
using Microsoft.AspNetCore.Authorization;

namespace MoviePJ.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AppControllerBase : Controller
    {
        protected readonly IHttpContextAccessor _httpContext;
        public readonly INotyfService _notyf;
        protected readonly MoviePJ_DBContext _db;

        protected const string AREA_NAME = "Admin";
        protected const int DEFAULT_PAGE_SIZE = 20;
        protected const string EXCEPTION_ERR_MESG = "An error occurred during data processing (500)";
        protected const string MODEL_STATE_INVALID_MESG = "Invalid data, please check again";
        protected const string PAGE_NOT_FOUND_MESG = "Page not found";

        protected readonly object ROUTE_FOR_AREA = new
        {
            area = AREA_NAME
        };

        protected int CurrentUserId { get => Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); }
        protected string CurrentUsername { get => HttpContext.User.Identity.Name; }
        protected string Referer { get => Request.Headers["Referer"].ToString(); }

        protected int? CurrentUserID()
        {
            var nameIdentifier = _httpContext.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier);
            if (nameIdentifier != null)
            {
                return Convert.ToInt32(nameIdentifier.Value);
            }
            return null;
        }


        public AppControllerBase(MoviePJ_DBContext db)
        {
            _db = db;
        }

        protected RedirectToActionResult HomePage() => RedirectToAction("Index", "Home", new { area = "Admin" });

        /// <summary>
        /// Gán thông báo lỗi để hiển thị lên view
        /// </summary>
        /// <param name="mesg">Thông báo lỗi</param>
        /// <param name="modelStateIsInvalid">Đặt là true khi lỗi validate dữ liệu</param>
        protected void SetErrorMesg(string mesg, bool modelStateIsInvalid = false)
        {
            TempData["Err"] = mesg;
            if (modelStateIsInvalid)
            {
                // hiển thị tin nhắn lỗi ở file log
                var invalidMesg = string.Join("\n", ModelState.Values
                                                .SelectMany(v => v.Errors)
                                                .Select(e => e.ErrorMessage));
                _notyf.Error($"Model state is invalid: {invalidMesg}");
            }
        }

        protected void SetSuccessMesg(string mesg) => TempData["Success"] = mesg;

        protected void LogException(Exception ex)
        {
            _notyf.Error($"{ex}");
            SetErrorMesg(EXCEPTION_ERR_MESG);
        }

        protected byte[] HashHMACSHA512WithKey(string pwd, byte[] key)
        {
            HMACSHA512 hmac = new(key);
            var pwdByte = Encoding.UTF8.GetBytes(pwd);
            return hmac.ComputeHash(pwdByte);
        }

        protected HashResult HashHMACSHA512(string pwd)
        {
            var hashResult = new HashResult();
            HMACSHA512 hmac = new();
            var pwdByte = Encoding.UTF8.GetBytes(pwd);
            hashResult.Value = hmac.ComputeHash(pwdByte);
            hashResult.Key = hmac.Key;
            return hashResult;
        }
        /// <summary>
        /// Check role khách hàng khi đăng nhập bằng trang đăng nhập của admin
        /// </summary>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var roleId = Convert.ToInt32(filterContext.HttpContext.User.Claims.SingleOrDefault(c => c.Type.Contains(AppClaimTypes.RoleId))?.Value);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                return;
            }
            if (roleId == AppConst.ROLE_CUSTOMER_ID)
            {
                filterContext.Result = new RedirectResult("/");
                return;
            }
        }
    }
}