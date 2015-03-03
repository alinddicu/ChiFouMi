using System;

namespace ChiFouMi.Perfect
{
    public class InputToCoupTypeConverter
    {
        public CoupType Convert(object input)
        {
            var converterValue = CoupType.None;
            if (input == null)
            {
                return converterValue;
            }

            if (Enum.TryParse<CoupType>(input.ToString(), out converterValue))
            {
                return converterValue;
            }

            return converterValue;
        }
    }
}