using Bestiary.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bestiary.DataAccess
{
    public interface IBestiary
    {
        Task<Monster?> FirstOrDefaultAsync(BestiaryReference bestiaryReference);
        Task<IReadOnlyList<BestiaryReference>> GetBestiaryReferencesAsync();
    }
}