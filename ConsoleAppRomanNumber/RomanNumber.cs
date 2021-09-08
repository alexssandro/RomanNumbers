using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppRomanNumber
{
    /*
    Create a function taking a positive integer as its parameter and returning a string containing the Roman Numeral representation of that integer.

    Modern Roman numerals are written by expressing each digit separately starting with the left most digit and skipping any digit with a value of zero.In Roman numerals 1990 is rendered: 1000=M, 900=CM, 90=XC; resulting in MCMXC. 2008 is written as 2000=MM, 8=VIII; or MMVIII. 1666 uses each Roman symbol in descending order: MDCLXVI.

    Examples:


    Input Output
    1000	"M"
    1990	"MCMXC"
    2008	"MMVIII"
    1666	"MDCLXVI"
    Help:
    
    
    Symbol Value
    I          1
    V          5
    X          10
    L          50
    C          100
    D          500
    M          1,000
    Remember that there can't be more than 3 identical symbols in a row.
    
    More about roman numerals - http://en.wikipedia.org/wiki/Roman_numerals */

    public class RomanNumber
    {
        public static int GetDecimalNumber(string romanNumber)
        {
            string[] unit = GetUnit(romanNumber);
            romanNumber = romanNumber.Replace(unit[1], "");
            string[] ten = GetTen(romanNumber);
            romanNumber = romanNumber.Replace(ten[1], "");
            string[] hundred = GetHundred(romanNumber);
            romanNumber = romanNumber.Replace(hundred[1], "");
            string[] thousand = GetThousand(romanNumber);

            return Convert.ToInt32($"{thousand[0]}{hundred[0]}{ten[0]}{unit[0]}");
        }

        public static string[] GetThousand(string romanNumber)
        {
            char[] romanUnits = { 'M' };

            int position = -1;

            for (int i = romanNumber.Length - 1; i >= 0; i--)
            {
                if (romanUnits.Contains(romanNumber[i]))
                    position = i;
            }

            if (position == -1)
                return new string[] { "0", "0" };

            string unitRomanValue = romanNumber[position..];
            string unitDecimalValue = GetThousandNumber(unitRomanValue);

            return new string[] { unitDecimalValue, unitRomanValue };
        }

        public static string GetThousandNumber(string romanThousand)
        {
            string thousand = "0";
            switch (romanThousand)
            {
                case "M":
                    thousand = "1";
                    break;
                case "MM":
                    thousand = "2";
                    break;
                case "MMM":
                    thousand = "3";
                    break;
            }
            return thousand;
        }

        public static string[] GetHundred(string romanNumber)
        {
            char[] romanUnits = { 'C', 'D' };

            int position = -1;

            for (int i = romanNumber.Length - 1; i >= 0; i--)
            {
                if (romanUnits.Contains(romanNumber[i]))
                    position = i;
            }

            if (position == -1)
                return new string[] { "0", "0" };

            string unitRomanValue = romanNumber[position..];
            string unitDecimalValue = GetHundredNumber(unitRomanValue);

            return new string[] { unitDecimalValue, unitRomanValue };
        }

        public static string GetHundredNumber(string romanHundred)
        {
            string ten = "0";
            switch (romanHundred)
            {
                case "C":
                    ten = "1";
                    break;
                case "CC":
                    ten = "2";
                    break;
                case "CCC":
                    ten = "3";
                    break;
                case "CD":
                    ten = "4";
                    break;
                case "D":
                    ten = "5";
                    break;
                case "DC":
                    ten = "6";
                    break;
                case "DCC":
                    ten = "7";
                    break;
                case "DCCC":
                    ten = "8";
                    break;
                case "CM":
                    ten = "9";
                    break;
            }
            return ten;
        }

        public static string[] GetTen(string romanNumber)
        {
            char[] romanUnits = { 'X', 'L' };

            int position = -1;

            for (int i = romanNumber.Length - 1; i >= 0; i--)
            {
                if (romanUnits.Contains(romanNumber[i]))
                    position = i;
            }

            if (position == -1)
                return new string[] { "0", "0" };

            string unitRomanValue = romanNumber[position..];
            string unitDecimalValue = GetTenNumber(unitRomanValue);

            return new string[] { unitDecimalValue, unitRomanValue };
        }

        public static string GetTenNumber(string romanTen)
        {
            string ten = "0";
            switch (romanTen)
            {
                case "X":
                    ten = "1";
                    break;
                case "XX":
                    ten = "2";
                    break;
                case "XXX":
                    ten = "3";
                    break;
                case "XL":
                    ten = "4";
                    break;
                case "L":
                    ten = "5";
                    break;
                case "LX":
                    ten = "6";
                    break;
                case "LXX":
                    ten = "7";
                    break;
                case "LXXX":
                    ten = "8";
                    break;
                case "XC":
                    ten = "9";
                    break;
            }
            return ten;
        }

        public static string[] GetUnit(string romanNumber)
        {
            char[] romanUnits = { 'I', 'V' };
            int position = -1;

            for (int i = romanNumber.Length - 1; i >= 0; i--)
            {
                if (romanUnits.Contains(romanNumber[i]))
                    position = i;
            }

            if (position == -1)
                return new string[] { "0", "0" };

            string unitRomanValue = romanNumber[position..];
            string unitDecimalNumber = GetUnitNumber(unitRomanValue);

            return new string[] { unitDecimalNumber, unitRomanValue };
        }

        public static string GetUnitNumber(string romanUnit)
        {
            string unit = "0";
            switch (romanUnit)
            {
                case "I":
                    unit = "1";
                    break;
                case "II":
                    unit = "2";
                    break;
                case "III":
                    unit = "3";
                    break;
                case "IV":
                    unit = "4";
                    break;
                case "V":
                    unit = "5";
                    break;
                case "VI":
                    unit = "6";
                    break;
                case "VII":
                    unit = "7";
                    break;
                case "VIII":
                    unit = "8";
                    break;
                case "IX":
                    unit = "9";
                    break;
            }
            return unit;
        }
        public static string GetRomanNumber(int num)
        {
            string numberAsString = num.ToString();
            List<string> romanNumber = new List<string>();

            for (int i = numberAsString.Length - 1; i >= 0; i--)
            {
                if (i == numberAsString.Length - 1)
                {
                    romanNumber.Add(GetUnitValue(numberAsString[i]));
                    continue;
                }
                else if (i == numberAsString.Length - 2)
                {
                    romanNumber.Add(GetDecimalValue(numberAsString[i]));
                    continue;
                }
                else if (i == numberAsString.Length - 3)
                {
                    romanNumber.Add(GetHundredValue(numberAsString[i]));
                    continue;
                }
                else if (i == numberAsString.Length - 4)
                {
                    romanNumber.Add(GetThousandValue(numberAsString[i]));
                    continue;
                }
            }
            romanNumber.Reverse();
            return string.Join("", romanNumber);
        }
        public static string GetThousandValue(char unit)
        {
            string romanThousand = string.Empty;
            switch (unit)
            {
                case '1':
                    romanThousand = "M";
                    break;
                case '2':
                    romanThousand = "MM";
                    break;
                case '3':
                    romanThousand = "MMM";
                    break;
                default:
                    break;
            }

            return romanThousand;
        }
        public static string GetHundredValue(char unit)
        {
            string romanHundred = string.Empty;
            switch (unit)
            {
                case '1':
                    romanHundred = "C";
                    break;
                case '2':
                    romanHundred = "CC";
                    break;
                case '3':
                    romanHundred = "CCC";
                    break;
                case '4':
                    romanHundred = "CD";
                    break;
                case '5':
                    romanHundred = "D";
                    break;
                case '6':
                    romanHundred = "DC";
                    break;
                case '7':
                    romanHundred = "DCC";
                    break;
                case '8':
                    romanHundred = "DCCC";
                    break;
                case '9':
                    romanHundred = "CM";
                    break;
                default:
                    break;
            }

            return romanHundred;
        }
        public static string GetDecimalValue(char unit)
        {
            string romanDecimal = string.Empty;
            switch (unit)
            {
                case '1':
                    romanDecimal = "X";
                    break;
                case '2':
                    romanDecimal = "XX";
                    break;
                case '3':
                    romanDecimal = "XXX";
                    break;
                case '4':
                    romanDecimal = "XL";
                    break;
                case '5':
                    romanDecimal = "L";
                    break;
                case '6':
                    romanDecimal = "LX";
                    break;
                case '7':
                    romanDecimal = "LXX";
                    break;
                case '8':
                    romanDecimal = "LXXX";
                    break;
                case '9':
                    romanDecimal = "XC";
                    break;
                default:
                    break;
            }

            return romanDecimal;
        }
        public static string GetUnitValue(char unit)
        {
            string romanUnit = string.Empty;
            switch (unit)
            {
                case '1':
                    romanUnit = "I";
                    break;
                case '2':
                    romanUnit = "II";
                    break;
                case '3':
                    romanUnit = "III";
                    break;
                case '4':
                    romanUnit = "IV";
                    break;
                case '5':
                    romanUnit = "V";
                    break;
                case '6':
                    romanUnit = "VI";
                    break;
                case '7':
                    romanUnit = "VII";
                    break;
                case '8':
                    romanUnit = "VIII";
                    break;
                case '9':
                    romanUnit = "IX";
                    break;
                default:
                    break;
            }

            return romanUnit;
        }
    }
}
