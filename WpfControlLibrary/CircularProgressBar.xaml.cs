using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfControlLibrary
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class CircularProgressBar : UserControl
    {
        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
      DependencyProperty.Register("Angle", typeof(double), typeof(CircularProgressBar), new PropertyMetadata(0d, new PropertyChangedCallback(OnPropertyChanged)));

        // Using a DependencyProperty as the backing store for Percentage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PercentageProperty =
      DependencyProperty.Register("Percentage", typeof(double), typeof(CircularProgressBar), new PropertyMetadata(0d, new PropertyChangedCallback(OnPercentageChanged)));

        // Using a DependencyProperty as the backing store for Radius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadiusProperty =
      DependencyProperty.Register("Radius", typeof(int), typeof(CircularProgressBar), new PropertyMetadata(20, new PropertyChangedCallback(OnPropertyChanged)));

        // Using a DependencyProperty as the backing store for SegmentColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SegmentColorProperty =
      DependencyProperty.Register("SegmentColor", typeof(Brush), typeof(CircularProgressBar), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        // Using a DependencyProperty as the backing store for StrokeThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeThicknessProperty =
      DependencyProperty.Register("StrokeThickness", typeof(int), typeof(CircularProgressBar), new PropertyMetadata(40));

        public CircularProgressBar()
        {
            InitializeComponent();
            RenderArc();
        }
        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public double Percentage
        {
            get { return (double)GetValue(PercentageProperty); }
            set { SetValue(PercentageProperty, value); }
        }

        public int Radius
        {
            get { return (int)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public Brush SegmentColor
        {
            get { return (Brush)GetValue(SegmentColorProperty); }
            set { SetValue(SegmentColorProperty, value); }
        }

        public int StrokeThickness
        {
            get { return (int)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public void RenderArc()
        {
            Point startPoint = new Point(Radius, 0);
            Point endPoint = ComputeCartesianCoordinate(Angle, Radius);
            endPoint.X += Radius;
            endPoint.Y += Radius;

            ProgressIndicator.Width = Radius * 2 + StrokeThickness;
            ProgressIndicator.Height = Radius * 2 + StrokeThickness;
            ProgressIndicator.Margin = new Thickness(StrokeThickness, StrokeThickness, 0, 0);

            bool largeArc = Angle > 180.0;

            Size outerArcSize = new Size(Radius, Radius);

            pathFigure.StartPoint = startPoint;

            if (startPoint.X == Math.Round(endPoint.X) && startPoint.Y == Math.Round(endPoint.Y))
                endPoint.X -= 0.01;

            arcSegment.Point = endPoint;
            arcSegment.Size = outerArcSize;
            arcSegment.IsLargeArc = largeArc;
        }

        private static void OnPercentageChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            CircularProgressBar circle = sender as CircularProgressBar;
            circle.Angle = (circle.Percentage * 360) / 100;
        }

        private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            CircularProgressBar circle = sender as CircularProgressBar;
            circle.RenderArc();
        }

        private Point ComputeCartesianCoordinate(double angle, double radius)
        {
            // convert to radians
            double angleRad = (Math.PI / 180.0) * (angle - 90);

            double x = radius * Math.Cos(angleRad);
            double y = radius * Math.Sin(angleRad);

            return new Point(x, y);
        }
    }
}