using System;
using System.Collections.Generic;

namespace Bestiary.DataAccess
{
    sealed class APIBestiaryRootObject
    {
        private readonly BestiaryReference[] _references;

        public APIBestiaryRootObject(BestiaryReference[] results)
        {
            _references = results ?? throw new ArgumentNullException(nameof(results));
        }

        public IReadOnlyList<BestiaryReference> ToReadOnlyList()
        {
            return _references;
        }
    }
}