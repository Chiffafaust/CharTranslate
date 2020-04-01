using System.Linq;

namespace SearchCharTranslate
{
    public static partial class CharTranslate
    {
        private enum Language
        {
            Cirilyc,
            Latin,
            Unknown
        }

        private static string GetLenguageString(Language lang)
        {
            switch (lang)
            {
                case Language.Cirilyc:
                    return "RU";
                case Language.Latin:
                    return "EU";
                case Language.Unknown:
                default:
                    return "Unknown";
            }
        }

        private static Language GetLanguage(ref string data)
        {
            var _isLatin = data.Any(ch => IsLatinUnicodeLetter(ch));
            var _isCirilyc = data.Any(ch => IsCirilycUnicodeLetter(ch));

            if (_isLatin && _isCirilyc)
                return Language.Unknown;
            if (_isCirilyc)
                return Language.Cirilyc;
            if (_isLatin)
                return Language.Latin;

            return Language.Unknown;
        }
    }
}
