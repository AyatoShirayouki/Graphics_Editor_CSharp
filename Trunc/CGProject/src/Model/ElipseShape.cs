using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Draw.src.Model
{
    class ElipseShape : Shape
    {
		#region Constructor

		public ElipseShape(RectangleF rect) : base(rect)
		{

		}

		public ElipseShape(RectangleShape rectangle) : base(rectangle)
		{

		}

		#endregion

		public override bool Contains(PointF point)
		{
			float centerX = this.Location.X + (this.Width / 2);
			float centerY = this.Location.Y + (this.Height / 2);
			if (((Math.Pow((point.X - centerX), 2) / Math.Pow(this.Width / 2, 2)) + (Math.Pow((point.Y - centerY), 2) /
				Math.Pow(this.Height / 2, 2))) <= 1)
				return true;
			else
				return false;
		}

		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);

			grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			grfx.DrawEllipse(Pens.Black, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

		}

	}
}
