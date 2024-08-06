using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;
using MoviePJ.Areas.Admin.ViewModels;
using MoviePJ.WebConfig.Consts;
using MoviePJ.Consts;
using Microsoft.IdentityModel.Tokens;

namespace MoviePJ.Common
{
	public static class AppExtension
	{

		// Tạo số thứ tự từ PagedList
		public static IPagedList<TModel> GenRowIndex<TModel>(this IPagedList<TModel> list) where TModel : ListItemBaseVM
		{
			var pageSize = list.PageSize;
			var currentPage = list.PageNumber;
			for (int i = 0; i < list.Count; i++)
			{
				list[i].RowIndex = (currentPage - 1) * pageSize + i + 1;
			}
			return list;
		}

		public static string GetCurrentActionName(this ViewContext viewContext)
		{
			return viewContext.RouteData.Values["action"].ToString();
		}
		public static string GetCurrentControllerName(this ViewContext viewContext)
		{
			return viewContext.RouteData.Values["controller"].ToString();
		}
		public static bool IsInPermission(this ClaimsPrincipal user, int actionPermission)
		{
			var userPermission = user.FindFirstValue(AppClaimTypes.Permissions);
			if (userPermission.IsNullOrEmpty())
			{
				return false;
			}
			if (actionPermission == AuthConst.NO_PERMISSION)
			{
				return true;
			}
			return userPermission.Contains(actionPermission.ToString());
		}
		/// <summary>
		/// Kiểm tra xem cái date có phải là ngày trước đó của cái date2 không
		/// </summary>
		/// <param name="date"></param>
		/// <param name="date2"></param>
		/// <returns></returns>
		public static bool IsBefore(this DateTime date, DateTime date2)
		{
			if (date < date2)
			{
				return true;
			}
			return false;
		}
		/// <summary>
		/// Kiểm tra xem cái date có phải là ngày sau đó của cái date2 không
		/// </summary>
		/// <param name="date"></param>
		/// <param name="date2"></param>
		/// <returns></returns>
		public static bool IsAfter(this DateTime date, DateTime date2)
		{
			if (date > date2)
			{
				return true;
			}
			return false;
		}
		/// <summary>
		/// Kiểm tra xem cái dd/MM/yyyy của date có giống nhau với dd/MM/yyyy date2 không
		/// </summary>
		/// <param name="date"></param>
		/// <param name="date2"></param>
		/// <returns></returns>
		public static bool IsSameDate(this DateTime date, DateTime date2)
		{
			if (date.Date.Equals(date2.Date))
			{
				return true;
			}
			return false;
		}
		/// <summary>
		/// kiếm tra xem ngày có phải là ngày nằm giữa của 2 ngày khác không
		/// </summary>
		/// <param name="date"></param>
		/// <param name="d1"></param>
		/// <param name="d2"></param>
		/// <returns></returns>
		public static bool IsBetween(this DateTime date, DateTime d1, DateTime d2)
		{
			if (date.IsBefore(d2) && date.IsAfter(d1))
			{
				return true;
			}
			return false;
		}
	}
}
