using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
	public class Rectangle2 : Shape
	{
		#region Constructor

		public Rectangle2(RectangleF rect) : base(rect)
		{

		}

		public Rectangle2(RectangleShape rectangle) : base(rectangle)
		{
		}

		#endregion

		/// <summary>
		/// Проверка за принадлежност на точка point към правоъгълника.
		/// В случая на правоъгълник този метод може да не бъде пренаписван, защото
		/// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
		/// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
		/// елемента в този случай).
		/// </summary>
		public override bool Contains(PointF point)
		{
			
			if (base.Contains(point))
				return true;
			else
				return false;
		}

		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);

			grfx.FillRectangle(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			grfx.DrawRectangle(Pens.Black, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			grfx.DrawLine(Pens.Black, Location.X, Location.Y, (Location.X + Width/2), (Location.Y + Height / 2));
			grfx.DrawLine(Pens.Black, Location.X, Location.Y + Height, (Location.X + Width/2), (Location.Y + Height / 2));
			grfx.DrawLine(Pens.Black, Location.X + Width/2, Location.Y + Height/2, (Location.X + Width), (Location.Y + Height / 2));
		}
	}
}
