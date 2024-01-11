using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace GraphProblemsWF
{
    public partial class Form1 : Form
    {
        private readonly int _nodeSize = Screen.PrimaryScreen.Bounds.Width / 60;
        private int _vertexIdx;
        private Vertex _highlightedVertex;
        private Vertex _selectedVertex;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (var edge in Graph._edges)
            {
                Point p1 = edge.V1.Point;
                Point p2 = edge.V2.Point;

                g.DrawLine(new Pen(Color.Black), p1, p2);

                int x = (p1.X + p2.X) / 2;
                int y = (p1.Y + p2.Y) / 2;

                g.DrawString(
                    edge.Weight.ToString(), new Font("Arial", 10),
                    new SolidBrush(Color.Black),
                    x, y);
            }

            if (_highlightedVertex != null)
            {
                g.FillRectangle(
                    new SolidBrush(Color.Yellow),
                    _highlightedVertex.Point.X - _nodeSize / 2, _highlightedVertex.Point.Y - _nodeSize / 2,
                    _nodeSize, _nodeSize
                );
            }

            if (_selectedVertex != null)
            {
                g.FillRectangle(
                    new SolidBrush(Color.Red),
                    _selectedVertex.Point.X - _nodeSize / 2, _selectedVertex.Point.Y - _nodeSize / 2,
                    _nodeSize, _nodeSize
                );
            }

            foreach (var v in Graph._vertices)
            {
                g.FillEllipse(new SolidBrush(v.Color),
                    v.Point.X - _nodeSize / 2, v.Point.Y - _nodeSize / 2,
                    _nodeSize, _nodeSize);

                g.DrawEllipse(new Pen(new SolidBrush(Color.Black)),
                    v.Point.X - _nodeSize / 2, v.Point.Y - _nodeSize / 2,
                    _nodeSize, _nodeSize);
                g.DrawString(
                    v.Index.ToString(), new Font("Arial", 10),
                    new SolidBrush(Color.Black),
                    v.Point.X - _nodeSize / 2 + 5, v.Point.Y - _nodeSize / 2 + 5);
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (_highlightedVertex != null)
            {
                if (_selectedVertex != null)
                {
                    Graph._edges.Add(new Edge()
                    {
                        V1 = _highlightedVertex,
                        V2 = _selectedVertex
                    });
                    _selectedVertex = null;
                    return;
                }

                _selectedVertex = _highlightedVertex;
                return;
            }

            _selectedVertex = null;

            MouseEventArgs me = (MouseEventArgs)e;
            Graph._vertices.Add(new Vertex()
            {
                Index = _vertexIdx++,
                Point = me.Location
            });
            Invalidate();
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            foreach (var v in Graph._vertices)
            {
                int x1 = v.Point.X - _nodeSize;
                int y1 = v.Point.Y - _nodeSize;
                int x2 = v.Point.X + _nodeSize;
                int y2 = v.Point.Y + _nodeSize;

                if (x1 <= x && x2 >= x &&
                    y1 <= y && y2 >= y)
                {
                    _highlightedVertex = v;
                    break;
                }
                else
                {
                    _highlightedVertex = null;
                }
            }

            Invalidate();
        }
        
        private void dfsButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string s in Graph.DFS().Split('\n'))
            {
                listBox1.Items.Add(s);
            }
        }

        private void bfsButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string s in Graph.BFS().Split('\n'))
            {
                listBox1.Items.Add(s);
            }
        }
    }
}