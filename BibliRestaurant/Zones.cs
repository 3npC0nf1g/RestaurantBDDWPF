using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace BibliRestaurant
{
    public enum Zones
    {
        Entrée,
        Térasse,
        [Description("Près Des Toilettes")]
        PrèsDesToillettes,
        Mezzanine,
        [Description("Près Du Bar")]
        PrèsDuBar,
        [Description("Près De La Sortie")]
        PrèsDeLaSortie
    }
    public enum TypePlat
    {
        Africain,
        Européen,
        Asiatique,
        Américain,
        Variété
    }
    public enum Décor
    {
        Africain,
        Européen,
        Asiatique,
        Américain,
        Variété
    }
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue) =>
            enumValue.GetType()
                    .GetMember(enumValue.ToString())
                    .First()
                    .GetCustomAttribute<DescriptionAttribute>()?
                    .Description
                    ?? enumValue.ToString();
    }
}
