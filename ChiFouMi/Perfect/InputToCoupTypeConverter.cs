using System;

namespace ChiFouMi.Perfect
{
    public class InputToCoupTypeConverter
    {
        public CoupType Convert(object input)
        {
            var convertedValue = CoupType.None;
            if (input == null)
            {
                return convertedValue;
            }

            Enum.TryParse(input.ToString(), out convertedValue);

            return convertedValue;
        }
    }
}