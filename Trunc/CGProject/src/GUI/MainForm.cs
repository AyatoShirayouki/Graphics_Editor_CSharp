using Draw.src.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}
		
		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle();
			
			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";
			
			viewPort.Invalidate();
		}

		void DrawEllipseSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomEllipse();

			statusBar.Items[0].Text = "Последно действие: Рисуване на elipsa";

			viewPort.Invalidate();
		}

		void DrawSquareSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomSquare();

			statusBar.Items[0].Text = "Последно действие: Рисуване на kvadrat";

			viewPort.Invalidate();
		}

		void DrawCircleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomCircle();

			statusBar.Items[0].Text = "Последно действие: Рисуване на krug";

			viewPort.Invalidate();
		}

		void DrawTriangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomTriangle();

			statusBar.Items[0].Text = "Последно действие: Рисуване на triugulnik";

			viewPort.Invalidate();
		}

		void DrawRectangle2SpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle2();

			statusBar.Items[0].Text = "Последно действие: Рисуване на triugulnik";

			viewPort.Invalidate();
		}

		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>
		void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (toolStripButton1.Checked) {
				dialogProcessor.Selection = dialogProcessor.ContainsPoint(e.Location);
				if (dialogProcessor.Selection != null) {
					statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
					dialogProcessor.IsDragging = true;
					dialogProcessor.LastLocation = e.Location;
					viewPort.Invalidate();
                    if (dialogProcessor.shape == "Draw.RectangleShape")
                    {
						ShapeDataLabel.Text = dialogProcessor.shape.Substring(5);
					}
                    else
                    {
						ShapeDataLabel.Text = dialogProcessor.shape.Substring(15);
					}
					
					ColorDataLabel.Text = dialogProcessor.color.ToString().Substring(5);
					shapeIdLabel.Text = dialogProcessor.shapeId;
				}
			}
		}

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режм на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

		Brush PaintBrush = new SolidBrush(Color.FromName("Red"));
		Pen p1 = new Pen(Color.FromName("Red"));

		private void button5_Click(object sender, EventArgs e)
        {
			ColorDialog cd = new ColorDialog();
			cd.Color = Color.FromName("Red"); //the Default color we are going to draw with
			if (cd.ShowDialog() == DialogResult.OK)
			{
				PaintBrush = new SolidBrush(cd.Color);
				p1 = new Pen(cd.Color);
				button5.BackColor = cd.Color;

				dialogProcessor.color = cd.Color;
			}
		}

        private void details_Click(object sender, EventArgs e)
        {
			Status status = new Status();
			status.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ShapeDataLabel.Text == "CircleShape")
            {
				dialogProcessor.AddRandomCircle();

				statusBar.Items[0].Text = "Последно действие: Kopirane na krug";

				viewPort.Invalidate();
			}
            else if (ShapeDataLabel.Text == "RectangleShape")
            {
				dialogProcessor.AddRandomRectangle();

				statusBar.Items[0].Text = "Последно действие: Kopirane na pravougulnik";

				viewPort.Invalidate();
			}
			else if (ShapeDataLabel.Text == "ElipseShape")
			{
				dialogProcessor.AddRandomEllipse();

				statusBar.Items[0].Text = "Последно действие: Kopirane na Elipsa";

				viewPort.Invalidate();
			}
			else if (ShapeDataLabel.Text == "SquareShape")
			{
				dialogProcessor.AddRandomSquare();

				statusBar.Items[0].Text = "Последно действие: Kopirane na Kvadrat";

				viewPort.Invalidate();
			}
			else if (ShapeDataLabel.Text == "TriangleleShape")
			{
				dialogProcessor.AddRandomTriangle();

				statusBar.Items[0].Text = "Последно действие: Kopirane na Triugulnik";

				viewPort.Invalidate();
			}
		}

        private void button7_Click(object sender, EventArgs e)
        {
            if (shapeIdLabel.Text != "-")
            {
				dialogProcessor.Delete(int.Parse(shapeIdLabel.Text));
			}
        }
    }
}
