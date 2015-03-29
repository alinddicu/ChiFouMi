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

            Enum.TryParse(ToTitleCase(input.ToString()), out convertedValue);

            return convertedValue;
        }

        private static string ToTitleCase(string input)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input);
        }
    }
}
