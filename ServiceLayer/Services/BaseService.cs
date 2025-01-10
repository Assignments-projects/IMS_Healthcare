using DbLayer.Helper;
using DbLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
	public class BaseService
	{
		/// <summary>
		/// Add audit details on add new record
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <param name="user"></param>
		protected void AddAudit<T>(T obj, ICurrentUser user) where T : IAuditCurrent
		{
			if (obj == null || user == null) return;

			obj.AddedById   = user.UserId;
			obj.UpdatedById = user.UserId;
			obj.AddedDate   = DateTime.Now;
			obj.UpdatedDate = DateTime.Now;
		}

		/// <summary>
		/// Add audit details on update new record
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <param name="user"></param>
		protected void UpdateAudit<T>(T obj, ICurrentUser user) where T : IAuditCurrent
		{
			if (obj == null || user == null) return;

			obj.UpdatedById = user.UserId;
			obj.UpdatedDate = DateTime.Now;
		}
	}
}
