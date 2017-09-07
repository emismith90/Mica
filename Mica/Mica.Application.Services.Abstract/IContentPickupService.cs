using System.Collections.Generic;

namespace Mica.Application.Services.Abstract
{
    public interface IContentPickupService<T>
    {
        IList<T> GetForPickup();
    }
}
