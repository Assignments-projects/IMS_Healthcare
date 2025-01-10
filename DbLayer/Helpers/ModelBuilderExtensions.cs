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
				.WithOne()
				.HasForeignKey<TEntity>(i => i.AddedById)
				.HasPrincipalKey<User>(u => u.UserUuid);

			// Similarly, configure UpdatedBy if needed
			builder.Entity<TEntity>()
				.HasOne(i => i.UpdatedBy) // Same relationship, but for UpdatedById
				.WithOne()
				.HasForeignKey<TEntity>(i => i.UpdatedById)
				.HasPrincipalKey<User>(u => u.UserUuid);
		}
	}
}
