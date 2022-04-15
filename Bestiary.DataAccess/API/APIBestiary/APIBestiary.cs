using Bestiary.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bestiary.DataAccess
{
    public class APIBestiary : APIDataProvider, IBestiary
    {
        private readonly string _url;
        private readonly Dictionary<BestiaryReference, Monster> _bestiaryEntries;

        private IReadOnlyList<BestiaryReference>? _bestiaryReferences;

        public APIBestiary(string url) : base()
        {
            _url = url ?? throw new ArgumentNullException(nameof(url));
            _bestiaryEntries = new Dictionary<BestiaryReference, Monster>();
        }
        public async Task<IReadOnlyList<BestiaryReference>> GetBestiaryReferencesAsync()
        {
            if (_bestiaryReferences == null)
            {
                var bestiaryReferences = await GetFromJsonAsync<APIBestiaryRootObject>(_url);
                _bestiaryReferences = bestiaryReferences.ToReadOnlyList();
                return _bestiaryReferences;
            }
            else
            {
                return await Task.FromResult(_bestiaryReferences);
            }
        }

        public async Task<Monster?> FirstOrDefaultAsync(BestiaryReference bestiaryReference)
        {
            if (_bestiaryEntries.TryGetValue(bestiaryReference, out Monster? monster))
            {
                return await Task.FromResult(monster);
            }
            else
            {
                monster = await GetFromJsonAsync<Monster>(_url + "/" + bestiaryReference.Index);
                _bestiaryEntries.Add(bestiaryReference, monster);
                return monster;
            }
        }
    }
}