using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mica.Application.Services.Abstract
{
    public interface IContentPickupService<T>
    {
        IList<T> GetForPickup();
    }
}
