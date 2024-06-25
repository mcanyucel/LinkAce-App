using LinkAce_Mobile.Models;
using System.Globalization;

namespace LinkAce_Mobile.Converters
{
    class TagsToStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is List<LinkAceTag> tags)
            {
                return string.Join(", ", tags.Select(t => t.Name));
            }
            else
            {
                return string.Empty;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("This converter cannot convert back");
        }
    }
}
