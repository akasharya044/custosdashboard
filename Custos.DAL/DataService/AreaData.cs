﻿using AutoMapper;
using custos.Models;
using Custos.DAL.Unitofworks;

namespace Custos.DAL.DataService
{
	public class AreaData : IAreaData
	{

		readonly IUnitOfWorks _uow;
		readonly IMapper _mapper;

		public AreaData(IUnitOfWorks uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
		}



		//      public async Task<Response> GetArea(int categoryId, int SubcategoryId)
		//      {
		//          Response response = new Response();
		//          try
		//          {
		//              var data = await _uow.area.GetAllAsync(x => x.category_c == categoryId && x.subcategory_c == SubcategoryId);
		//              var dtodata = _mapper.Map<List<AreaDTO>>(data);
		//              if (data != null && data.Count() > 0)
		//              {
		//                  response.Status = "Success";
		//                  response.Message = "Data Fetch Successfully";
		//                  response.Data = dtodata;
		//              }
		//              else
		//              {
		//                  response.Status = "Success";
		//                  response.Message = "No Record Found!!";
		//                  response.Data = data;
		//              }
		//          }
		//          catch (Exception ex)
		//          {
		//              response.Status = "Failed";
		//              var errormessage = await _uow.AddException(ex);
		//              response.Message = errormessage;
		//          }
		//          return response;

		//      }

		public async Task<Response> GetAreas(int categoryid, int subcategoryid)
		{
			Response response = new Response();
			try
			{
				var data = await _uow.area.GetAllAsync(x => x.CategoryId == categoryid && x.SubCategoryId == subcategoryid);
				var catdata = await _uow.categories.GetFirstOrDefaultAsync(x => x.Id == categoryid);
				var subcatdata = await _uow.subCategories.GetFirstOrDefaultAsync(x => x.Id == subcategoryid);
				var dtodata = _mapper.Map<List<AreaDTO>>(data);
				dtodata.ForEach (x =>
				{
					x.category = _mapper.Map<CategoriesDto>(catdata);
					x.subcategory = _mapper.Map<SubCategoriesDto>(subcatdata);
				}) ;
				if (data != null && data.Count() > 0)
				{
					response.Status = "success";
					response.Message = "data fetch successfully";
					response.Data = dtodata;
				}
				else
				{
					response.Status = "success";
					response.Message = "no record found!!";
					response.Data = data;
				}
			}
			catch (Exception ex)
			{
				response.Status = "failed";
				var errormessage = await _uow.AddException(ex);
				response.Message = errormessage;
			}
			return response;

		}

		//public async Task<Response> GetAreaAll()
		//{
		//	Response response = new Response();
		//	try
		//	{
		//		var data = await _uow.area.GetAllAsync();
		//		var dtodata = _mapper.Map<List<AreaDTO>>(data);
		//		if (data != null && data.Count() > 0)
		//		{
		//			response.Status = "Success";
		//			response.Message = "Data Fetch Successfully";
		//			response.Data = dtodata;
		//		}
		//		else
		//		{
		//			response.Status = "Success";
		//			response.Message = "No Record Found!!";
		//			response.Data = data;
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		response.Status = "Failed";
		//		var errormessage = await _uow.AddException(ex);
		//		response.Message = errormessage;
		//	}
		//	return response;

		//}
		//public async Task<Response> AddArea(List<AreaDTO> data)
		//      {
		//          Response response = new Response(); 
		//          try
		//          {
		//              var mappeddata = _mapper.Map<List<Areas>>(data);
		//              var newdata = mappeddata.Where(x => x.Id == 0).ToList();
		//              var exisingdata = mappeddata.Where(x => x.Id > 0).ToList();
		//              if(newdata !=null && newdata.Count() > 0)
		//              {
		//                  _uow.area.AddRange(newdata);
		//              }
		//              if(exisingdata !=null && exisingdata.Count() > 0)
		//              {
		//                  _uow.area.UpdateRange(exisingdata);
		//              }
		//              await _uow.SaveAsync();
		//              response.Status = "Success";
		//              response.Message = "Data Saved";
		//              response.Data = mappeddata;
		//          }
		//          catch (Exception ex)
		//          {
		//              response.Status = "failed";
		//              var error = await _uow.AddException(ex);
		//              response.Message = error;
		//          }

		//          return response;
		//      }
		//  }
	}
}



