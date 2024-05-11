using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.Tickets
{
    public class TicketRecordDto
    {
        public int Id { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string? EntityType { get; set; } = string.Empty;
        public string? RequestedByPerson { get; set; } = string.Empty;
        public string? CategoryName { get; set; } 
        public string? SubCategoryName { get; set; } 
        public string? AreaName { get; set; } 
        public bool? TicketGenerated { get; set; } = true; //If not generated reprocess it in handler
        public string? TicketStatus { get; set; } //0 pending,1 ticket generated,2 resolved,3 feedback receied
		public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
        public string? ResolvedDateTime { get; set; } = string.Empty;
        public string? SystemId { get; set; } //New field added 
        public string? AssignedTo { get; set; } = string.Empty;
        public string? FeedBackRemark { get; set; } = string.Empty;
        public string? ExpertAssignee { get; set; } = string.Empty;
        public string? ExpertAssigneeName { get; set; } = string.Empty;
        public string? RequestedByPersonName { get; set; } = string.Empty;
      

    }

    public class TicketDto
    {
		public int Id { get; set; }
		public string? Description { get; set; } = string.Empty;

		public int CategoryId { get; set; } = 0;
		public int SubCategoryId { get; set; } = 0;
		public int AreaId { get; set; } = 0;
        public string RequestedBYPerson { get; set; }
        public string SystemId {  get; set; }
        public string? CategoryName { get; set; }
        public string? SubCategoryName { get; set; }
        public string? AreaName { get; set; }
    }

    public class TicketUpdateDto
    {
		public int Id { get; set; }
		public string? Description { get; set; } = string.Empty;
        public string TicketStatus { get; set; }
		public string? RequestedByPerson { get; set; } = string.Empty;
		public string? SystemId { get; set; }  
		public string? CategoryName { get; set; }
		public string? SubCategoryName { get; set; }
		public string? AreaName { get; set; }
        public int CategoryId { get; set; } = 0;
        public int SubCategoryId { get; set; } = 0;
        public int AreaId { get; set; } = 0;
         public int Status { get; set; }

    }

    public class AutoCompleteDto
    { 
    
    public int value { get; set; }

        public string Name { get; set; }
    
    }

}
