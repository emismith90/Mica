using Mica.Domain.Abstract.Repositories.Inventory;
using Mica.Domain.Data.Contexts;
using Mica.Domain.Data.Models.Inventory;

namespace Mica.Domain.EF.Repositories.Inventory
{
    public class MaterialRepository : GenericRepository<MaterialEntity, long>, IMaterialRepository
    {
        public MaterialRepository(MicaContext context) : base(context)
        {
        }

        public override MaterialEntity CreateDefaultObject()
        {
            return new MaterialEntity
            {
                Active = true
            };
        }
    }
}
