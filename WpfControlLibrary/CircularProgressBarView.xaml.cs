using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfControlLibrary
{
    /// <summary>
    /// Interaction logic for CircularProgressBarView.xaml
    /// </summary>
    public partial class CircularProgressBarView : Window
    {
        public CircularProgressBarView()
        {
            InitializeComponent();
        }
        public void ReportProgress(int progress)
        {
            ThirdCircularProgressBar.Percentage = progress;

            if (progress <= 50)
            {
                SecondCircularProgressBar.SegmentColor = Brushes.Green;
            }
            else if (progress > 50 && progress <= 80)
            {
                SecondCircularProgressBar.SegmentColor = Brushes.Yellow;
            }
            else if (progress > 80)
            {
                SecondCircularProgressBar.SegmentColor = Brushes.Red;
            }
        }

        public void TryClose()
        {
            this.Close();
        }

        public void TryShow()
        {
            this.ShowDialog();
        }
    }
}
