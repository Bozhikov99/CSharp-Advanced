using System.Linq;

namespace Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public string Dial(string number)
        {
            if (number.Any(x => !char.IsDigit(x)))
            {
                return "Invalid number!";
            }
            return $"Dialing... {number}";
        }
    }
}
