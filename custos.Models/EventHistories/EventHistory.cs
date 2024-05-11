using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace custos.Models

{
    public class EventHistory
    {
        [Key]
        public int Id { get; set; }
        public string Event {  get; set; }
        public DateTime EventDate { get; set; }
        public string SystemId { get; set; }
    }

    public class EventHistoryDto
    {
        public int Id { get; set; }
        public string Event { get; set; }
        public DateTime EventDate { get; set; }
        public string SystemId { get; set; }
		public int Count { get; set; }


	}

	public class EventHistoryDtoNew
	{
		public int Id { get; set; }
		public string Event { get; set; }
		public DateTime EventDate { get; set; }
		public string SystemId { get; set; }

	}
}
