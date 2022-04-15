using System.Windows;

namespace Bestiary.GUI.AttachedProperties
{
    public static class ViewProperties
    {
        public static readonly DependencyProperty IsBusyProperty;

        public static void SetIsBusy(DependencyObject obj, bool value)
        {
            obj.SetValue(IsBusyProperty, value);
        }
        public static bool GetIsBusy(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsBusyProperty);
        }

        static ViewProperties()
        {
            IsBusyProperty = DependencyProperty.RegisterAttached("IsBusy", typeof(bool), typeof(ViewProperties), new PropertyMetadata(false));
        }
    }
}
