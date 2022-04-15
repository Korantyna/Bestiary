namespace Bestiary.DataAccess
{
    public record BestiaryReference(string Name, string Index)
    {

        #region Object Members

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}