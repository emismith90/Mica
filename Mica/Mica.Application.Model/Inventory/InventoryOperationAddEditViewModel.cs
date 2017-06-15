using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Mica.Application.Models.Inventory
{
    public class InventoryOperationAddEditViewModel 
    {
        public InventoryOperationModel Model { get; set; }

        public IList<SelectListItem> Materials { get; set; }
    }
}
