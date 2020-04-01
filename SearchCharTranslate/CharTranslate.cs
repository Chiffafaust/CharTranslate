using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchCharTranslate
{
    public static partial class CharTranslate
    {
        public static string TranslateKeyboardsChar(string data, out string currentLenguage)
        {
            PrepareTranslate(ref data, out Language language);
            
            switch (language)
            {
                case Language.Cirilyc:
                    {
                        currentLenguage = GetLenguageString(Language.Latin);
                        return toCirilyc(ref data);
                    }
                case Language.Latin:
                    {
                        currentLenguage = GetLenguageString(Language.Cirilyc);
                        return toLatin(ref data);
                    }
                case Language.Unknown:
                default:
                    throw new ArgumentException("Входная строка содержит одновременно латинские и кирилические символы. Невозможно определить способ преобразования.");
            }
        }

        private static string toCirilyc(ref string data)
        {
            var retVal = String.Empty;
            foreach (char ch in data)
            {
                var kvpair = CirilycLatinPair.Where(x => x.Key.Equals(ch)).FirstOrDefault();

                if (kvpair.Equals(default(KeyValuePair<char, char>)))
                    retVal += ch;
                else
                    retVal += kvpair.Value;
            }

            return retVal;
        }

        private static string toLatin(ref string data)
        {
            var retVal = String.Empty;
            foreach (char ch in data)
            {
                var kvpair = CirilycLatinPair.Where(x => x.Value.Equals(ch)).FirstOrDefault();

                if (kvpair.Equals(default(KeyValuePair<char, char>)))
                    retVal += ch;
                else
                    retVal += kvpair.Key;
            }

            return retVal;
        }

        private static void PrepareTranslate(ref string data, out Language curLeng)
        {
            data.Trim();

            if (!data.IsNormalized())
                data.Normalize();

            curLeng = GetLanguage(ref data);
        }
    }
}
