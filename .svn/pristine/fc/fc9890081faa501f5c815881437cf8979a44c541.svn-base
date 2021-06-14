using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
	public class TriangleleShape : Shape
	{
		#region Constructor

		public TriangleleShape(RectangleF rect) : base(rect)
		{

		}

		public TriangleleShape(RectangleShape rectangle) : base(rectangle)
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
				// Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
				// В случая на правоъгълник - директно връщаме true
				return true;
			else
				// Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
				return false;
		}

		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);
			Point[] MyPoint = { new Point((int)Rectangle.X, (int)Rectangle.Y), new Point((int)Rectangle.Y, (int)Rectangle.X), new Point((int)Rectangle.Y, (int)Rectangle.Y) };
			grfx.FillPolygon(new SolidBrush(FillColor), MyPoint);
			grfx.DrawPolygon(Pens.Black, MyPoint);

		}
	}
}
