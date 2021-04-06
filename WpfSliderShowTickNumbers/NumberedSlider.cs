using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfSliderShowTickNumbers
{
    class NumberedSlider:Slider
    {
        protected override void OnRender(DrawingContext dc)
        {

            Size size = new Size(ActualWidth, ActualHeight);

            int tickCount = (int) ((Maximum - Minimum) / TickFrequency) + 1;
            if ((Maximum - Minimum) % TickFrequency == 0)
                tickCount -= 1;
            var tickFrequencySize = (size.Width * TickFrequency / (Maximum - Minimum));
            var c = this.Ticks;
            int i;
            // Draw each tick text
            for (i = 0; i <= tickCount; i++)
            {
                var text = Convert.ToString(Convert.ToInt32(Minimum + TickFrequency * i), 10);

                var formattedText = new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                    new Typeface("Verdana"), 8, Brushes.Black);
                dc.DrawText(formattedText, new Point(tickFrequencySize * i, 30));

            }
        }
    }
}
