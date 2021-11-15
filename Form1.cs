using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXFReaderNET;
using DXFReaderNET.Entities;

namespace DXFPatterns
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        internal enum FunctionsEnum
        {
            None,
            ZoomWindow1,
            ZoomWindow2,
            Circle1,
            Circle2,
            Hatch,
        }
        private FunctionsEnum CurrentFunction = FunctionsEnum.None;
        private Vector2 p1 = Vector2.Zero;
        private Vector2 p2 = Vector2.Zero;
        private string m_PatternName = "SOLID";
        private string m_HatchRotation = "0";
        private string m_HatchScale = "1";
        private List<HatchPattern> hatchPatternsCustom = new List<HatchPattern>();
        private List<EntityObject> HatchBoundary = new List<EntityObject>();

        private void newDrawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dxfReaderNETControl1.NewDrawing();
        }

        private void loadDXFFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "DXF";
            openFileDialog1.Filter = "DXF|*.dxf";
            saveFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dxfReaderNETControl1.ReadDXF(openFileDialog1.FileName);

            }
        }

        private void saveDXFFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "dxf";
            saveFileDialog1.Filter = "DXF|*.dxf";
            saveFileDialog1.FileName = "drawing.dxf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dxfReaderNETControl1.WriteDXF(saveFileDialog1.FileName);

            }
        }

        private void loadPATFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "pat";
            openFileDialog1.Filter = "Hatch Pattern definition file|*.pat|All files (*.*)|*.*";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadPAT(openFileDialog1.FileName);

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void zoomExtentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dxfReaderNETControl1.ZoomExtents();
        }

        private void zoomWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFunction = FunctionsEnum.ZoomWindow1;
            toolStripStatusLabel1.Text = "Select start point of the window";
        }

        private void aboutDXFReaderNETComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dxfReaderNETControl1.About();
        }
        private void LoadPAT(string PATfilename)
        {
            dxfReaderNETControl1.NewDrawing();

            hatchPatternsCustom.Clear();
            hatchPatternsCustom = dxfReaderNETControl1.ReadHatchPatternsFromFile(PATfilename);

            int k = 0;
            int j = 0;
            foreach (HatchPattern pattern in hatchPatternsCustom)
            {
                Circle circle = new Circle
                {
                    Radius = 4,
                    Center = new Vector3(j * 10 + 5, k * 11 + 5, 0)
                };
                List<EntityObject> boundary = new List<EntityObject>
                {
                    circle
                };

                double maxSize = 0;
                for (int i = 0; i < pattern.LineDefinitions.Count; i++)
                {
                    for (int l = 0; l < pattern.LineDefinitions[i].DashPattern.Count; l++)
                    {

                        if (pattern.LineDefinitions[i].DashPattern[l] > maxSize)
                        {
                            maxSize = Math.Abs(pattern.LineDefinitions[i].DashPattern[l]);
                        }
                    }


                }


                double scale = 1;
                if (maxSize != 0)
                {
                    scale = 1 / maxSize * 2;
                    if (scale > 3) scale = 3;
                }


                dxfReaderNETControl1.AddHatch(pattern, boundary, null, 0, scale);

                Vector3 textPosition = circle.Center - new Vector3(0, 6, 0); ;
                dxfReaderNETControl1.AddText(pattern.Name.Trim(), textPosition, textPosition, 0.8, 0, TextAlignment.BottomCenter);

                if (pattern.Description.Trim() != "")
                {
                    textPosition -= new Vector3(0, 0.4, 0);
                    dxfReaderNETControl1.AddText(pattern.Description.Trim(), textPosition, textPosition, 0.3, 0, TextAlignment.BottomCenter);
                }
                textPosition -= new Vector3(0, 0.4, 0);
                dxfReaderNETControl1.AddText("Scale: " + scale.ToString("###0.0"), textPosition, textPosition, 0.3, 0, TextAlignment.BottomCenter);
                j++;
                if (j == 8)
                {
                    k++;
                    j = 0;
                }
            }
            dxfReaderNETControl1.Refresh();
            dxfReaderNETControl1.ZoomExtents();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = Screen.PrimaryScreen.Bounds.Width - 40;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 80;
            this.Left = 20;
            this.Top = 20;

            dxfReaderNETControl1.NewDrawing();
            dxfReaderNETControl1.CustomCursor = CustomCursorType.CrossHair;
            toolStripStatusLabel1.Text = "";
            dxfReaderNETControl1.Dock = DockStyle.Fill;

        }

        private void dxfReaderNETControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (CurrentFunction)
                {
                    case FunctionsEnum.ZoomWindow2:

                        CurrentFunction = FunctionsEnum.None;
                        dxfReaderNETControl1.CustomCursor = CustomCursorType.CrossHair;

                        toolStripStatusLabel1.Text = "";
                        dxfReaderNETControl1.ZoomWindow(p1, dxfReaderNETControl1.CurrentWCSpoint);
                        break;
                    case FunctionsEnum.ZoomWindow1:
                        CurrentFunction = FunctionsEnum.ZoomWindow2;
                        toolStripStatusLabel1.Text = "Select end point of the window";
                        p1 = dxfReaderNETControl1.CurrentWCSpoint;
                        break;
                    case FunctionsEnum.Circle2:
                        CurrentFunction = FunctionsEnum.None;
                        dxfReaderNETControl1.CustomCursor = CustomCursorType.CrossHair;
                        toolStripStatusLabel1.Text = "";


                        dxfReaderNETControl1.DrawEntity(dxfReaderNETControl1.AddCircle(new Vector3(p1.X, p1.Y, dxfReaderNETControl1.DXF.CurrentElevation), Vector2.Distance(p1, dxfReaderNETControl1.CurrentWCSpoint), dxfReaderNETControl1.DXF.CurrentColor.Index));

                        break;
                    case FunctionsEnum.Circle1:
                        CurrentFunction = FunctionsEnum.Circle2;
                        toolStripStatusLabel1.Text = "Select radius";
                        p1 = dxfReaderNETControl1.CurrentWCSpoint;
                        break;
                    case FunctionsEnum.Hatch:
                        CurrentFunction = FunctionsEnum.None;
                        dxfReaderNETControl1.CustomCursor = CustomCursorType.CrossHair;
                        EntityObject ent = dxfReaderNETControl1.GetEntity(dxfReaderNETControl1.CurrentWCSpoint);
                        if (ent != null)
                        {
                            if (ent.Type == EntityType.Circle || ent.Type == EntityType.LightWeightPolyline || ent.Type == EntityType.Line || ent.Type == EntityType.Arc || ent.Type == EntityType.Spline || ent.Type == EntityType.Ellipse)
                            {
                                HatchBoundary.Add(ent);

                                dxfReaderNETControl1.DrawEntity(dxfReaderNETControl1.AddHatch(m_PatternName, HatchBoundary, null, double.Parse(m_HatchRotation, System.Globalization.CultureInfo.CurrentCulture), double.Parse(m_HatchScale, System.Globalization.CultureInfo.CurrentCulture), dxfReaderNETControl1.DXF.CurrentColor.Index));

                            }
                        }
                        break;
                }

            }
        }

        private void dxfReaderNETControl1_MouseMove(object sender, MouseEventArgs e)
        {
            switch (CurrentFunction)
            {
                case FunctionsEnum.ZoomWindow2:
                    dxfReaderNETControl1.ShowRubberBandBox(p1, dxfReaderNETControl1.CurrentWCSpoint);
                    break;
                case FunctionsEnum.Circle2:

                    dxfReaderNETControl1.ShowRubberBandCircle(p1, Vector2.Distance(p1, dxfReaderNETControl1.CurrentWCSpoint));
                    toolStripStatusLabel1.Text = "Radius: " + dxfReaderNETControl1.DXF.ToFormattedUnit(Vector2.Distance(p1, dxfReaderNETControl1.CurrentWCSpoint));
                    break;
            }
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Select center point";
            CurrentFunction = FunctionsEnum.Circle1;

        }

        private void hatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HatchSelector hatchSelector = new HatchSelector();
            hatchSelector.TextBoxScale.Text = m_HatchScale;
            hatchSelector.TextBoxRotation.Text = m_HatchRotation;

            hatchSelector.ComboBox1.Items.Clear();

            hatchSelector.ComboBox1.Items.AddRange(new object[] {
            "SOLID",
            "ANGLE",
            "ANSI31",
            "ANSI32",
            "ANSI33",
            "ANSI34",
            "ANSI35",
            "ANSI36",
            "ANSI37",
            "ANSI38",
            "AR-B816",
            "AR-B816C",
            "AR-B88",
            "AR-BRELM",
            "AR-BRSTD",
            "AR-CONC",
            "AR-HBONE",
            "AR-PARQ1",
            "AR-RROOF",
            "AR-RSHKE",
            "AR-SAND",
            "BOX",
            "BRASS",
            "BRICK",
            "BRSTONE",
            "CLAY",
            "CORK",
            "CROSS",
            "DASH",
            "DOLMIT",
            "DOTS",
            "EARTH",
            "ESCHER",
            "FLEX",
            "GRASS",
            "GRATE",
            "GRAVEL",
            "HEX",
            "HONEY",
            "HOUND",
            "INSUL",
            "ACAD_ISO02W100",
            "ACAD_ISO03W100",
            "ACAD_ISO04W100",
            "ACAD_ISO05W100",
            "ACAD_ISO06W100",
            "ACAD_ISO07W100",
            "ACAD_ISO08W100",
            "ACAD_ISO09W100",
            "ACAD_ISO10W100",
            "ACAD_ISO11W100",
            "ACAD_ISO12W100",
            "ACAD_ISO13W100",
            "ACAD_ISO14W100",
            "ACAD_ISO15W100",
            "LINE",
            "MUDST",
            "NET",
            "NET3",
            "PLAST",
            "PLASTI",
            "SACNCR",
            "SQUARE",
            "STARS",
            "STEEL",
            "SWAMP",
            "TRANS",
            "TRIANG",
            "ZIGZAG"});
            if (hatchPatternsCustom != null)
            {
                for (int k = 0; k < hatchPatternsCustom.Count; k++)
                {
                    hatchSelector.ComboBox1.Items.Add(hatchPatternsCustom[k].Name);
                }

            }
            hatchSelector.ComboBox1.SelectedIndex = hatchSelector.ComboBox1.FindString(m_PatternName);


            if (hatchSelector.ShowDialog() == DialogResult.OK)
            {
                m_HatchScale = hatchSelector.TextBoxScale.Text;
                m_HatchRotation = hatchSelector.TextBoxRotation.Text;
                m_PatternName = hatchSelector.ComboBox1.Text;


                HatchBoundary.Clear();


                dxfReaderNETControl1.CustomCursor = CustomCursorType.CrossHairSquare;
                toolStripStatusLabel1.Text = "Select boundary.";
                CurrentFunction = FunctionsEnum.Hatch;
            }
        }
    }
}

