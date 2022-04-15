using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Bestiary.GUI.Controls
{
    public class ImageControl : ContentControl
    {
        public static readonly DependencyProperty RotationAngleProperty;
        public static readonly DependencyProperty StretchProperty;
        public static readonly DependencyProperty StretchDirectionProperty;

        public double RotationAngle
        {
            get { return (double)GetValue(RotationAngleProperty); }
            set { SetValue(RotationAngleProperty, value); }
        }
        public Stretch Stretch
        {
            get { return (Stretch)GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }
        public StretchDirection StretchDirection
        {
            get { return (StretchDirection)GetValue(StretchDirectionProperty); }
            set { SetValue(StretchDirectionProperty, value); }
        }

        static ImageControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageControl), new FrameworkPropertyMetadata(typeof(ImageControl)));
            IsTabStopProperty.OverrideMetadata(typeof(ImageControl), new FrameworkPropertyMetadata(false));
            RenderTransformOriginProperty.OverrideMetadata(typeof(ImageControl), new FrameworkPropertyMetadata(new Point(0.5, 0.5)));
            StretchProperty = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(ImageControl), new PropertyMetadata(Stretch.Uniform));
            RotationAngleProperty = DependencyProperty.Register("RotationAngle", typeof(double), typeof(ImageControl), new PropertyMetadata(0.0));
            StretchDirectionProperty = DependencyProperty.Register("StretchDirection", typeof(StretchDirection), typeof(ImageControl), new PropertyMetadata(StretchDirection.Both));
        }
    }
}
