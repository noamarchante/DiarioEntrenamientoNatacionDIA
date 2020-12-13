// Charts for WinForms (c) 2017 MIT License <baltasarq@gmail.com>

namespace Proyecto2.View.Graficos
{
    using System.Linq;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System;
    /// <summary>
    /// Draws a simple chart.
    /// Note that Mono's implementation of WinForms Chart is incomplete.
    /// </summary>
    public class Chart : PictureBox
    {
        public enum ChartType { Lines, Bars };

        public Chart(int width, int height)
        {

            this.values = new List<int>();
            this.values2 = new List<int>();
            this.values3 = new List<double>();
            this.values4 = new List<double>();
            this.Width = width;
            this.Height = height;
            this.FrameWidth = 50;
            this.Type = ChartType.Lines;
            this.AxisPen = new Pen(Color.Black) { Width = 2 };
            this.DataPen = new Pen(Color.DarkBlue) { Width = 2 };
            this.DataPen2 = new Pen(Color.DarkGreen) { Width = 2 };
            this.DataFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LegendFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LegendPen2 = new Pen(Color.DarkGreen);
            this.LegendPen = new Pen(Color.DarkBlue);
            this.LegendPen3 = new Pen(Color.Black);


            this.Build();
        }

        /// <summary>
        /// Redraws the chart
        /// </summary>
        public void Draw()
        {
            this.grf.Clear(Color.White);
            this.grf.DrawRectangle(
                            new Pen(this.BackColor),
                            new Rectangle(0, 0, this.Width, this.Height));
            this.DrawAxis();
            this.DrawData();
            this.DrawData2();
            this.DrawLegends();
        }
        public void Draw2()
        {
            this.grf.Clear(Color.White);
            this.grf.DrawRectangle(
                new Pen(this.BackColor),
                new Rectangle(0, 0, this.Width, this.Height));
            this.DrawAxis();

            this.DrawData3();
            this.DrawLegends();
        }
        public void Draw3()
        {
            this.grf.Clear(Color.White);
            this.grf.DrawRectangle(
                new Pen(this.BackColor),
                new Rectangle(0, 0, this.Width, this.Height));
            this.DrawAxis();

            this.DrawData3();
            this.DrawData4();
            this.DrawLegends();
        }

        private void DrawLegends()
        {

            StringFormat verticalDrawFmt = new StringFormat
            {
                FormatFlags = StringFormatFlags.DirectionVertical
            };

            int legendXWidth = (int)this.grf.MeasureString(
                                                        this.LegendX[0],
                                                        this.LegendFont).Width;

            int legendYHeight = (int)this.grf.MeasureString(
                                                        this.LegendY,
                                                        this.LegendFont,
                                                        new Size(this.Width,
                                                                  this.Height),
                                                       verticalDrawFmt).Height;
            int i = 0;

            foreach (var posicion in posicionval)
            {
                this.grf.DrawString(
                           LegendX[i],
                           this.LegendFont,
                           this.LegendPen3.Brush,
                           new Point(posicion.X,
                               this.FramedEndPosition.Y + 10), verticalDrawFmt);

                i++;
            }
            this.grf.DrawString(
                    this.LegendY,
                    this.LegendFont,
                    this.LegendPen.Brush,
                    new Point(
                        (this.FramedOrgPosition.X - (this.FrameWidth / 2)) + posicionval[11].X + 7,
                        ((this.Height - legendYHeight) / 2) - 60));

            this.grf.DrawString(
                    this.LegendY2,
                    this.LegendFont,
                    this.LegendPen2.Brush,
                    new Point(
                        (this.FramedOrgPosition.X - (this.FrameWidth / 2)) + posicionval[11].X + 7,
                        ((this.Height - legendYHeight) / 2) - 40));
        }

        void DrawData()
        {

            int numValues = this.values.Count;
            var p = this.DataOrgPosition;
            int xGap = this.GraphWidth / (numValues + 1);
            int baseLine = this.DataOrgPosition.Y;

            posicionval = new List<Point>();

            this.NormalizeData();
            for (int i = 0; i < numValues; ++i)
            {
                string tag = this.values[i].ToString();
                int tagWidth = (int)this.grf.MeasureString(
                                                        tag,
                                                        this.DataFont).Width;
                var nextPoint = new Point(
                    p.X + xGap, baseLine - this.normalizedData[i]
                );

                if (this.Type == ChartType.Bars)
                {
                    p = new Point(nextPoint.X, baseLine);

                }

                posicionval.Add(p);
                this.grf.DrawLine(this.DataPen, p, nextPoint);
                this.grf.DrawString(tag,
                                     this.DataFont,
                                     this.DataPen.Brush,
                                     new Point(nextPoint.X - tagWidth,
                                                nextPoint.Y));
                p = nextPoint;

            }
        }

        void DrawData2()
        {
            int numValues = this.values2.Count;
            var p = this.DataOrgPosition2;
            int xGap = this.GraphWidth / (numValues + 1);
            int baseLine = this.DataOrgPosition2.Y;


            this.NormalizeData2();
            for (int i = 0; i < numValues; ++i)
            {
                string tag = this.values2[i].ToString();
                int tagWidth = (int)this.grf.MeasureString(
                                                        tag,
                                                        this.DataFont).Width;
                var nextPoint = new Point(
                    p.X + xGap, baseLine - this.normalizedData2[i]
                );

                if (this.Type == ChartType.Bars)
                {
                    p = new Point(nextPoint.X, baseLine);
                }

                this.grf.DrawLine(this.DataPen2, p, nextPoint);
                this.grf.DrawString(tag,
                                     this.DataFont,
                                     this.DataPen2.Brush,
                                     new Point(nextPoint.X - tagWidth,
                                                nextPoint.Y));
                p = nextPoint;
            }
        }
        void DrawData3()
        {

            int numValues = this.values3.Count;
            var p = this.DataOrgPosition;
            int xGap = this.GraphWidth / (numValues + 1);
            int baseLine = this.DataOrgPosition.Y;

            posicionval = new List<Point>();

            this.NormalizeData3();
            for (int i = 0; i < numValues; ++i)
            {
                string tag = this.values3[i].ToString();
                int tagWidth = (int)this.grf.MeasureString(
                    tag,
                    this.DataFont).Width;
                var nextPoint = new Point(
                    p.X + xGap, baseLine - (int)this.normalizedData3[i]
                );

                if (this.Type == ChartType.Bars)
                {
                    p = new Point(nextPoint.X, baseLine);

                }

                posicionval.Add(p);
                this.grf.DrawLine(this.DataPen, p, nextPoint);
                this.grf.DrawString(tag,
                    this.DataFont,
                    this.DataPen.Brush,
                    new Point(nextPoint.X - tagWidth,
                        nextPoint.Y));
                p = nextPoint;

            }
        }
        void DrawData4()
        {

            int numValues = this.values4.Count;
            var p = this.DataOrgPosition;
            int xGap = this.GraphWidth / (numValues + 1);
            int baseLine = this.DataOrgPosition.Y;

            posicionval = new List<Point>();

            this.NormalizeData4();
            for (int i = 0; i < numValues; ++i)
            {
                string tag = this.values4[i].ToString();
                int tagWidth = (int)this.grf.MeasureString(
                    tag,
                    this.DataFont).Width;
                var nextPoint = new Point(
                    p.X + xGap, baseLine - (int)this.normalizedData4[i]
                );

                if (this.Type == ChartType.Bars)
                {
                    p = new Point(nextPoint.X, baseLine);

                }

                posicionval.Add(p);
                this.grf.DrawLine(this.DataPen2, p, nextPoint);
                this.grf.DrawString(tag,
                    this.DataFont,
                    this.DataPen2.Brush,
                    new Point(nextPoint.X - tagWidth,
                        nextPoint.Y));
                p = nextPoint;

            }
        }


        void DrawAxis()
        {

            // Y axis
            this.grf.DrawLine(this.AxisPen,
                               this.FramedOrgPosition,
                               new Point(
                                        this.FramedOrgPosition.X,
                                        this.FramedEndPosition.Y));

            // X axis
            this.grf.DrawLine(this.AxisPen,
                               new Point(
                                        this.FramedOrgPosition.X,
                                        this.FramedEndPosition.Y),
                               this.FramedEndPosition);
        }

        void Build()
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.Image = bmp;
            this.grf = Graphics.FromImage(bmp);
        }

        void NormalizeData()
        {
            int maxHeight = this.DataOrgPosition.Y - this.FrameWidth;
            int maxValue = this.values.Max();
            if (maxValue == 0)
            {
                maxValue = 1;
            }
            this.normalizedData = this.values.ToArray();

            for (int i = 0; i < this.normalizedData.Length; ++i)
            {
                this.normalizedData[i] =
                                    (this.values[i] * maxHeight) / maxValue;
            }

            return;
        }

        void NormalizeData2()
        {

            int maxHeight = this.DataOrgPosition.Y - this.FrameWidth;
            int maxValue2 = this.values2.Max();
            int maxValue1 = this.values.Max();
            int maxValue = 1;
            if (maxValue1 > maxValue2)
            {
                maxValue = maxValue1;
            }
            else if (maxValue2 > maxValue1)
            {
                maxValue = maxValue2;
            }
            else
            {
                maxValue = maxValue1;
            }
            if (maxValue == 0)
            {
                maxValue = 1;
            }
            this.normalizedData2 = this.values2.ToArray();

            for (int i = 0; i < this.normalizedData2.Length; ++i)
            {
                this.normalizedData2[i] =
                                    (this.values2[i] * maxHeight) / maxValue;
            }

            return;
        }
        void NormalizeData3()
        {
            int maxHeight = this.DataOrgPosition.Y - this.FrameWidth;
            double maxValue = this.values3.Max();

            if (maxValue == 0)
            {
                maxValue = 1;
            }
            this.normalizedData3 = this.values3.ToArray();

            for (int i = 0; i < this.normalizedData3.Length; ++i)
            {
                this.normalizedData3[i] =
                    (this.values3[i] * maxHeight) / maxValue;
            }

            return;
        }
        void NormalizeData4()
        {
            int maxHeight = this.DataOrgPosition.Y - this.FrameWidth;
            double maxValue = this.values4.Max();

            if (maxValue == 0)
            {
                maxValue = 1;
            }
            this.normalizedData4 = this.values4.ToArray();

            for (int i = 0; i < this.normalizedData4.Length; ++i)
            {
                this.normalizedData3[i] =
                    (this.values4[i] * maxHeight) / maxValue;
            }

            return;
        }

        /// <summary>
        /// Gets or sets the values used as data.
        /// </summary>
        /// <value>The values.</value>
        public IEnumerable<int> Values
        {
            get
            {
                return this.values.ToArray();
            }
            set
            {
                this.values.Clear();
                this.values.AddRange(value);

            }
        }

        public IEnumerable<int> Values2
        {
            get
            {
                return this.values2.ToArray();
            }
            set
            {
                this.values2.Clear();
                this.values2.AddRange(value);

            }
        }
        public IEnumerable<double> Values3
        {
            get
            {
                return this.values3.ToArray();
            }
            set
            {
                this.values3.Clear();
                this.values3.AddRange(value);

            }
        }
        public IEnumerable<double> Values4
        {
            get
            {
                return this.values4.ToArray();
            }
            set
            {
                this.values4.Clear();
                this.values4.AddRange(value);

            }
        }



        /// <summary>
        /// Gets the framed origin.
        /// </summary>
        /// <value>The origin <see cref="Point"/>.</value>
        public Point DataOrgPosition
        {
            get
            {
                int margin = (int)(this.AxisPen.Width * 2);

                return new Point(
                    this.FramedOrgPosition.X + margin,
                    this.FramedEndPosition.Y - margin);

            }
        }

        public Point DataOrgPosition2
        {
            get
            {
                int margin = (int)(this.AxisPen.Width * 2);

                return new Point(
                    this.FramedOrgPosition.X + margin,
                    this.FramedEndPosition.Y - margin);
            }
        }

        /// <summary>
        /// Gets or sets the width of the frame around the chart.
        /// </summary>
        /// <value>The width of the frame.</value>
        public int FrameWidth
        {
            get; set;
        }

        /// <summary>
        /// Gets the framed origin.
        /// </summary>
        /// <value>The origin <see cref="Point"/>.</value>
        public Point FramedOrgPosition
        {
            get
            {
                return new Point(this.FrameWidth, this.FrameWidth);
            }
        }

        /// <summary>
        /// Gets the framed end.
        /// </summary>
        /// <value>The end <see cref="Point"/>.</value>
        public Point FramedEndPosition
        {
            get
            {
                return new Point(this.Width - this.FrameWidth,
                                  this.Height - this.FrameWidth);
            }
        }

        /// <summary>
        /// Gets the width of the graph.
        /// </summary>
        /// <value>The width of the graph.</value>
        public int GraphWidth
        {
            get
            {
                return this.Width - (this.FrameWidth * 2);
            }
        }

        /// <summary>
        /// Gets or sets the pen used to draw the axis.
        /// </summary>
        /// <value>The axis <see cref="Pen"/>.</value>
        public Pen AxisPen
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets the pen used to draw the data.
        /// </summary>
        /// <value>The data <see cref="Pen"/>.</value>
        public Pen DataPen
        {
            get; set;
        }

        public Pen DataPen2
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the data font.
        /// </summary>
        /// <value>The data <see cref="Font"/>.</value>
        public Font DataFont
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the legend for the x axis.
        /// </summary>
        /// <value>The legend for axis x.</value>
        public List<string> LegendX
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the legend for the y axis.
        /// </summary>
        /// <value>The legend for axis y.</value>
        public string LegendY
        {
            get; set;
        }
        public string LegendY2
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the font for legends.
        /// </summary>
        /// <value>The <see cref="Font"/> for legends.</value>
        public Font LegendFont
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the pen for legends.
        /// </summary>
        /// <value>The <see cref="Pen"/> for legends.</value>
        public Pen LegendPen
        {
            get; set;
        }

        public Pen LegendPen2
        {
            get; set;
        }
        public Pen LegendPen3
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the type of the chart.
        /// </summary>
        /// <value>The <see cref="ChartType"/>.</value>
        public ChartType Type
        {
            get; set;
        }

        Graphics grf;
        List<int> values;
        List<int> values2;
        List<double> values3;
        List<double> values4;
        int[] normalizedData;
        int[] normalizedData2;
        double[] normalizedData3;
        double[] normalizedData4;
        List<Point> posicionval = new List<Point>();
    }
}
