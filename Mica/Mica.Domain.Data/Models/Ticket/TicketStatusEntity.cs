namespace Mica.Domain.Data.Models.Ticket
{
    public class TicketStatusEntity : EntityBase<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Order { get; set; }
    }
}
