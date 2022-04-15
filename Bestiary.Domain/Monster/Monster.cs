using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Bestiary.Domain
{
    public class Monster
    {
        public string Name { get; }
        public string? Description { get; set; }
        public string Type { get; }
        public string? Subtype { get; }

        public IAbilityScores AbilityScores { get; }

        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }

        public int XP { get; set; }


        public Monster(string name, string? description, string type, string? subtype, MonsterAbilityScores abilityScores, int armorClass, int hitPoints, int xp)
        {
            if (name == null) { throw new ArgumentNullException(nameof(name)); }
            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException($"The argument {name} cannot be empty or whitespace.") : name;

            Description = description;

            if (type == null) { throw new ArgumentNullException(nameof(type)); }
            Type = string.IsNullOrWhiteSpace(type) ? throw new ArgumentException($"The argument {type} cannot be empty or whitespace.") : type;

            Subtype = subtype;

            AbilityScores = abilityScores ?? throw new ArgumentNullException(nameof(abilityScores));

            ArmorClass = armorClass >= 5 ? armorClass : throw new ArgumentOutOfRangeException($"The argument {armorClass} must be higher or equal to 5.");

            HitPoints = hitPoints >= 1 ? hitPoints : throw new ArgumentOutOfRangeException($"The argument {hitPoints} must be higher or equal to 1.");

            XP = xp >= 0 ? xp : throw new ArgumentOutOfRangeException($"The argument {xp} must be higher or equal to 0.");
        }

        [JsonConstructor]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "JsonConstructor")]
        private Monster(string name, string? desc, string type, string? subtype, int charisma, int constitution, int dexterity, int intelligence, int strength, int wisdom, int armor_class, int hit_points, int xp) 
            : this (name, desc, type, subtype, new MonsterAbilityScores(charisma, constitution, dexterity, intelligence, strength, wisdom), armor_class, hit_points, xp) { }


        #region Object Members

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}