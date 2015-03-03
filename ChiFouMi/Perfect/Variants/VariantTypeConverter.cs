namespace ChiFouMi.Perfect.Variants
{
    using System;

    public class VariantTypeConverter
    {
        public VariantType Convert(object input)
        {
            var convertedValue = VariantType.Common;
            if (input == null)
            {
                return convertedValue;
            }

            if (Enum.TryParse(ToTitleCase(input), out convertedValue))
            {
                return convertedValue;
            }

            return convertedValue;
        }

        private static string ToTitleCase(object input)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input.ToString());
        }
    }
}
