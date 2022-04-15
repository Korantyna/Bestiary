using System.Windows;

namespace Bestiary.GUI.AttachedProperties
{
    public static class ControlProperties
    {
        public static readonly DependencyProperty WatermarkProperty;

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }
        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }

        static ControlProperties()
        {
            WatermarkProperty = DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(ControlProperties));
        }
    }
}
