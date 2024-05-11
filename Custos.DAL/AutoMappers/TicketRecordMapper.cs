using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using custos.Models;
using custos.Models;
using custos.Models.Tickets;

namespace custos.DAL.AutoMappers
{
    public class TicketRecordMapper : Profile
    {
        public TicketRecordMapper()
        {
            CreateMap<TicketRecord, TicketRecordDto>().ReverseMap();
            CreateMap<TicketRecord, TicketDto>().ReverseMap();
            CreateMap<TicketRecord, TicketUpdateDto>().ReverseMap();
        }
    }
}
