﻿using DbLayer.Data;
using DbLayer.Helpers;
using DbLayer.Interfaces.Finance;
using DbLayer.Models;
using DbLayer.Models.Finance;
using DbLayer.Models.Patient;
using DbLayer.Models.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DbLayer.Repositories.Finance
{
	public class StatementRepository : BaseRepository, IStatementRepository
	{
		private readonly IMSDbContext _context;

		public StatementRepository(IMSDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Load statement list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Statement>> ListAsync()
		{
			return await MakeStatements(_context.Statements);
		}

		/// <summary>
		/// Load statement list for patient uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<List<Statement>> ListAsync(string id)
		{
			return await MakeStatements(_context.Statements.Where(x => x.PatientUuid == id));
		}

		/// <summary>
		/// Get statement details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Statement> DetailsAsync(int id)
		{
			var result = _context.Statements.Where(x => x.StatementId == id);

			return (await MakeStatements(result)).FirstOrDefault();
		}

		/// <summary>
		/// Add statement to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Statement model)
		{
			try
			{

				await _context.AddAsync(model);
				await _context.SaveChangesAsync();
			}
			catch (SqlException sqlEx)
			{
				return sqlEx.Message;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

			return null;
		}

		/// <summary>
		/// Update statement record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Statement model)
		{
			try
			{
				var exist = await _context.Statements.FindAsync(model.StatementId);

				if (exist == null)
					return NotFound;

				exist.StatementId = model.StatementId;
				exist.PatientUuid = model.PatientUuid;
				exist.StatusId    = model.StatusId;
				exist.Description = model.Description;
				exist.TotalCost   = model.TotalCost;
				exist.UpdatedById = model.UpdatedById;
				exist.UpdatedDate = model.UpdatedDate;

				await _context.SaveChangesAsync();
			}
			catch (SqlException sqlEx)
			{
				return sqlEx.Message;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

			return null;
		}

		/// <summary>
		/// Delete statement record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			try
			{
				var exist = await _context.Statements.FindAsync(id);

				if (exist == null)
					return NotFound;

				_context.Statements.Remove(exist);

				await _context.SaveChangesAsync();
			}
			catch (SqlException sqlEx)
			{
				return sqlEx.Message;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

			return null;
		}

		/// <summary>
		/// Calculate statement total from statement item by given id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="onSave"></param>
		/// <returns></returns>
		public async Task<string> CalculateStatementsTotal(int id)
		{
			try
			{
				// Ensure the connection is open before executing the command
				var connection = _context.Database.GetDbConnection();

				if (connection.State != System.Data.ConnectionState.Open)
				{
					await connection.OpenAsync(); 
				}

				// Execute the stored procedure
				await _context.Database.ExecuteSqlRawAsync("EXEC [dbo].[SP_UPDATE_STATEMENT_TOTAL] @StatementId",
														   new SqlParameter("StatementId", id));

				return null;
			}
			catch (SqlException sqlEx)
			{
				return sqlEx.Message;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}


		/// <summary>
		/// Load statement status list
		/// </summary>
		/// <returns></returns>
		public async Task<List<OsStatus>> ListStatusAsync()
		{
			return await _context.OsStatuss.ToListAsync();
		}

		/// <summary>
		/// Make List of statement with aditional datas
		/// </summary>
		/// <param name="found"></param>
		/// <returns></returns>
		private async Task<List<Statement>> MakeStatements(IQueryable<Statement> found)
		{
			try
			{
				var result = await found.Include(x => x.AddedBy)
									.Include(x => x.UpdatedBy)
									.Include(x => x.Patient)
									.Include(x => x.OsStatus)
									.Include(x => x.Items)
									.AsNoTracking()
									.ToListAsync();
				if (!result.Any())
					return new List<Statement>();

				AddAuditNames(result);
				return result;
			}
			catch(Exception ex)
			{
				return  new List<Statement>();
			}
		}


		/// <summary>
		/// Not found message
		/// </summary>
		private string NotFound => "The statement not found.";
	}
}
