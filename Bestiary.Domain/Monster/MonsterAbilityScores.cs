using System;

namespace Bestiary.Domain
{
    public sealed class MonsterAbilityScores : IAbilityScores
    {
        public int Charisma { get; set; }
        public int Constitution { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Wisdom { get; set; }


        public MonsterAbilityScores(int charisma, int constitution, int dexterity, int intelligence, int strength, int wisdom)
        {
            if (charisma < 1 || charisma > 30) { throw new ArgumentOutOfRangeException(nameof(charisma)); }
            if (constitution < 1 || constitution > 30) { throw new ArgumentOutOfRangeException(nameof(constitution)); }
            if (dexterity < 1 || dexterity > 28) { throw new ArgumentOutOfRangeException(nameof(dexterity)); }
            if (intelligence < 1 || intelligence > 25) { throw new ArgumentOutOfRangeException(nameof(intelligence)); }
            if (strength < 1 || strength > 30) { throw new ArgumentOutOfRangeException(nameof(strength)); }
            if (wisdom < 1 || wisdom > 25) { throw new ArgumentOutOfRangeException(nameof(wisdom)); }

            Charisma = charisma;
            Constitution = constitution;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Strength = strength;
            Wisdom = wisdom;
        }
    }
}