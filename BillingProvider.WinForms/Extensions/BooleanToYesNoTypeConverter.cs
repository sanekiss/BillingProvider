using System;
using System.ComponentModel;
using System.Globalization;

namespace BillingProvider.WinForms.Extensions
{
    class BooleanToYesNoTypeConverter : BooleanConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
            Type destType) =>
            (bool) value ? "Да" : "Нет";

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
            (string) value == "Да";
    }
}