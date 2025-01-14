using DbLayer.Helper;
using DbLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Helpers
{
	public static class ModelBuilderExtensions
	{
		public static void AddAuditRelationship<TEntity>(this ModelBuilder builder) where TEntity : class, IAuditCurrent
		{
			builder.Entity<TEntity>()
				.HasOne(i => i.AddedBy)
				.WithMany()
				.HasForeignKey(i => i.AddedById)
				.HasPrincipalKey(u => u.UserUuid);

			// Similarly, configure UpdatedBy if needed
			builder.Entity<TEntity>()
				.HasOne(i => i.UpdatedBy) // Same relationship, but for UpdatedById
				.WithMany()
				.HasForeignKey(i => i.UpdatedById)
				.HasPrincipalKey(u => u.UserUuid);
		}
	}
}
