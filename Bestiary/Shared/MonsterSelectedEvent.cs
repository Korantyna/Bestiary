using Prism.Events;

namespace Bestiary.Shared
{
    public sealed class MonsterSelectedEvent<BestiaryReference> : PubSubEvent<BestiaryReference?> { }
}