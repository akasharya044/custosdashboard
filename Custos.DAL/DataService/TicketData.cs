using AutoMapper;

using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Newtonsoft.Json.Linq;
using custos.Models;
using Custos.DAL.Unitofworks;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using custos.Models.Tickets;
namespace custos.DAL.DataService
{
	public class TicketData : ITicketData
	{

		readonly IUnitOfWorks _uow;
		readonly IMapper _mapper;


		public TicketData(IUnitOfWorks uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;

		}

		public async Task<Response> GetList()
		{
			Response response = new Response();
			try
			{
				var ticketRecords = _uow.ticketrecord.GetSelectedNoTracking(x => x).ToList();

				var categories = _uow.categories.GetAll().ToList();

				var subcategories = _uow.subCategories.GetAll().ToList();

				var areas = _uow.area.GetAll().ToList();

				var dbdata = ticketRecords
					.Join(categories,
						ticket => ticket.CategoryId,
						category => category.Id,
						(ticket, category) => new { Ticket = ticket, Category = category })
					.Join(subcategories,
						joinResult => joinResult.Ticket.SubCategoryId,
						subcategory => subcategory.Id,
						(joinResult, subcategory) => new { Ticket = joinResult.Ticket, Category = joinResult.Category, SubCategory = subcategory })
					.Join(areas,
						joinResult => joinResult.Ticket.AreaId,
						area => area.Id,
						(joinResult, area) => new TicketRecordDto
						{
							Id = joinResult.Ticket.Id,
							Description = joinResult.Ticket.Description,
							EntityType = joinResult.Ticket.EntityType,
							RequestedByPerson = joinResult.Ticket.RequestedByPerson,
							CategoryName = joinResult.Category.Name,
							SubCategoryName = joinResult.SubCategory.Name,
							AreaName = area.Name,
							SystemId = joinResult.Ticket.SystemId,

							TicketStatus = joinResult.Ticket.TicketStatus == 0 ? "Ticket Generated" :
			   joinResult.Ticket.TicketStatus == 1 ? "Pending" :
			   joinResult.Ticket.TicketStatus == 2 ? "Resolved" :
			   joinResult.Ticket.TicketStatus == 3 ? "Completed" :
			   ""
						})
					.ToList();

				response.Status = "Success";
				response.Message = "Data Sent";
				response.Data = dbdata;
			}
			catch (Exception ex)
			{
				response.Status = "Failed";
				var errorMessage = await _uow.AddException(ex);
				response.Message = errorMessage;
			}
			return response;
		}

		public async Task<Response> GetTicketById(int ticketId)
		{
			Response response = new Response();
			try
			{
				var ticketRecord = await _uow.ticketrecord.GetAllAsync(x => x.Id == ticketId);

				// If ticket record is found
				if (ticketRecord != null && ticketRecord.Any())
				{
					var selectedTicket = ticketRecord.FirstOrDefault();


					var category = await _uow.categories.GetFirstOrDefaultAsync(c => c.Id == selectedTicket.CategoryId);
					var subcategory = await _uow.subCategories.GetFirstOrDefaultAsync(sc => sc.Id == selectedTicket.SubCategoryId);
					var area = await _uow.area.GetFirstOrDefaultAsync(a => a.Id == selectedTicket.AreaId);

					// Map the ticket record to TicketRecordDto
					var ticketRecordDto = new TicketUpdateDto
					{
						Id = selectedTicket.Id,
						Description = selectedTicket.Description,
						RequestedByPerson = selectedTicket.RequestedByPerson,
						CategoryName = category?.Name,
						SubCategoryName = subcategory?.Name,
						AreaName = area?.Name,
						SystemId = selectedTicket.SystemId,
						TicketStatus = selectedTicket.TicketStatus == 0 ? "Ticket Generated" :
			   selectedTicket.TicketStatus == 1 ? "Pending" :
			   selectedTicket.TicketStatus == 2 ? "Resolved" :
			   selectedTicket.TicketStatus == 3 ? "Completed" :
			   ""
					};

					response.Status = "Success";
					response.Message = "Ticket data retrieved successfully";
					response.Data = ticketRecordDto;
				}
				else
				{
					response.Status = "Failed";
					response.Message = "Ticket not found";
				}
			}
			catch (Exception ex)
			{
				response.Status = "Failed";
				response.Message = "An error occurred while retrieving ticket data";
			}
			return response;
		}


		public async Task<Response> AddTicket(TicketDto ticketDto)
		{
			Response response = new Response();
			try
			{

				var mappedData = _mapper.Map<TicketRecord>(ticketDto);
				if (mappedData != null)
				{
					_uow.ticketrecord.Add(mappedData);
					await _uow.SaveAsync();

					response.Status = "Success";
					response.Message = "Data Saved";
					response.Data = mappedData;
				}
				else
				{
					response.Status = "Failed";
					response.Message = "Not Saved";
				}

			}
			catch (Exception ex)
			{
				response.Status = "Failed";
				var errorMessage = await _uow.AddException(ex);
				response.Message = errorMessage;
			}
			return response;
		}
		public async Task<Response> UpdateTicket(TicketUpdateDto updateDto)
		{
			Response response = new Response();
			try
			{
				var existingTicket = await _uow.ticketrecord.GetAsync(updateDto.Id);

				if (existingTicket != null)
				{
					existingTicket.TicketStatus = updateDto.Status;



					_uow.ticketrecord.Update(existingTicket);
					await _uow.SaveAsync();

					response.Status = "Success";
					response.Message = "Ticket record updated successfully";
					response.Data = existingTicket;
				}
				else
				{
					response.Status = "Failed";
					response.Message = "Ticket record not found";
				}
			}
			catch (Exception ex)
			{
				response.Status = "Failed";
				response.Message = "An error occurred while updating the ticket record";
				var errorMessage = await _uow.AddException(ex);
				response.Data = errorMessage;
			}
			return response;
		}




	}
}