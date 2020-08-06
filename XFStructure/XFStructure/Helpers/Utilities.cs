using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamvvm;
using XFStructure.ViewModels;

namespace XFStructure.Helpers
{
    class Utilities : BasePageViewModel
    {
        public static string FormatPhoneNumber(string phoneNumberToBeFormatted)
        {
            string number = new String(phoneNumberToBeFormatted.Where(Char.IsDigit).ToArray());
            if (number.StartsWith("0092"))
            {
                number = number.Substring(2);
            }
            else if (number.StartsWith("0"))
            {
                number = number.Substring(1, number.Length - 1);
                number = "92" + number;
            }
            return number;
        }
    }
}
