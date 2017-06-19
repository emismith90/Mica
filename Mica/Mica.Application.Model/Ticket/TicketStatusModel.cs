using Mica.Application.Models;

namespace Mica.Application.Models.Ticket
{
    public class TicketStatusModel : ModelBase<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Order { get; set; }
    }
}
