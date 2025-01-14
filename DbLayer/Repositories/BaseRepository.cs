using DbLayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Repositories
{
	public class BaseRepository
	{
		/// <summary>
		/// Add audit names on get a record
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		protected void AddAuditNames<T>(T obj) where T : IAuditCurrent
		{
			if (obj == null) return;

			obj.AddedByName   = $"{obj.AddedBy?.FirstName} {obj.AddedBy?.LastName}";
			obj.UpdatedByName = $"{obj.UpdatedBy?.FirstName} {obj.UpdatedBy?.LastName}";
		}

		/// <summary>
		/// Add audit names on get list of records
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		protected void AddAuditNames<T>(List<T> objList) where T : IAuditCurrent
		{
			if (!objList.Any()) return;

			foreach (T obj in objList)
			{
				obj.AddedByName   = $"{obj.AddedBy?.FirstName} {obj.AddedBy?.LastName}";
				obj.UpdatedByName = $"{obj.UpdatedBy?.FirstName} {obj.UpdatedBy?.LastName}";
			}
		}
	}
}
