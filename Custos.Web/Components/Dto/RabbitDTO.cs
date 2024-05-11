namespace custos.Web.Components.Dto
{
    public class RabbitDTO
    {

        public string? commandid { get; set; }
        public string? systemid { get; set; }
        public string? processname { get; set; }

        public string? message { get; set; }
        public string? commandarguments { get; set; }

        public int? processid { get; set; }

        public List<string>? systemids { get; set; }
        public string? onlinedownloadpath { get; set; }
    }
}
