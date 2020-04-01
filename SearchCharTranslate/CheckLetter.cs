namespace SearchCharTranslate
{
    public static partial class CharTranslate
    {
        private static bool IsCirilycUnicodeLetter(char ch)
        {
            switch (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch))
            {
                case System.Globalization.UnicodeCategory.UppercaseLetter:
                    {
                        int num = ch;
                        return (num >= 1040 && num <= 1071) || num == 1025; //А..Я
                    }
                case System.Globalization.UnicodeCategory.LowercaseLetter:
                    {
                        int num = ch;
                        return (num >= 1072 && num <= 1103) || num == 1105; //а..я
                    }
                default:
                    return false;
            }
        }

        private static bool IsLatinUnicodeLetter(char ch)
        {
            switch (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch))
            {
                case System.Globalization.UnicodeCategory.UppercaseLetter:
                    {
                        int num = ch;
                        return num >= 60 && num <= 90; //A..Z
                    }
                case System.Globalization.UnicodeCategory.LowercaseLetter:
                    {
                        int num = ch;
                        return num >= 97 && num <= 122; //a..z
                    }
                default:
                    return false;
            }
        }
    }
}
