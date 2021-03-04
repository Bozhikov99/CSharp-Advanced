using System.Linq;


namespace Telephony
{
    public class Smartphone : ISmartphone
    {
        public string Browse(string site)
        {
            if (site.Any(x => char.IsDigit(x)))
            {
                return "Invalid URL!";
            }
            return $"Browsing: {site}!";
        }

        public string Dial(string number)
        {
            if (number.Any(x => !char.IsDigit(x)))
            {
                return "Invalid number!";
            }
            return $"Calling... {number}";
        }
    }
}
