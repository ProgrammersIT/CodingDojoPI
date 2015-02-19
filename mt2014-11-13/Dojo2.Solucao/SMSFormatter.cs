using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo2
{
    public class SMSFormatter
    {
        private Dictionary<String, char> keyMap;

        public static void Main(string[] args) {
        }

        public SMSFormatter()
        {
            keyMap = new Dictionary<string,char>();
            keyMap.Add("ABC", '2');
            keyMap.Add("DEF", '3');
            keyMap.Add("GHI", '4');
            keyMap.Add("JKL", '5');
            keyMap.Add("MNO", '6');
            keyMap.Add("PQRS", '7');
            keyMap.Add("TUV", '8');
            keyMap.Add("WXYZ", '9');
            keyMap.Add(" ", '0');
        }

        private string GetNumericalLetter(char letter)
        {
            var key = keyMap.Keys.FirstOrDefault(k => k.Contains(letter));

            if (key == null) 
                throw new ArgumentException("Not valid entry");

            var number = keyMap[key];

            var numberOfTypings = key.IndexOf(letter) + 1;

            StringBuilder numberLetter = new StringBuilder();

            numberLetter.Append(number, numberOfTypings);
                
            return numberLetter.ToString();
        }

        public string GetNumericalMessage(string message)
        {
            if (message.Length > 255)
                throw new ArgumentException("More than 255 characters.");

            message = message.ToUpper();
            string numericalMessage = "";

            foreach (var letter in message)
            {
                var currentNumericalLetter = GetNumericalLetter(letter);
                var needsUnderscore = numericalMessage.LastOrDefault() == currentNumericalLetter.Last();

                if (needsUnderscore)
                    numericalMessage += "_";

                numericalMessage += currentNumericalLetter;
            }

            return numericalMessage;
        }
    }
}
