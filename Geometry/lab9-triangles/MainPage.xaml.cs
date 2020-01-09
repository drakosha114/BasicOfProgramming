using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using lab9_triangles.CustomPoint;

namespace lab9_triangles
{
    public sealed partial class MainPage : Page
    {
 
        private ICustomPoint[] _coords;
        private double _scale;


        public SolidColorBrush[] ListOfBorderColors;
        public SolidColorBrush CurrentBorderColor;

        public SolidColorBrush[] ListOfBgColors;
        public SolidColorBrush CurrentBgColor;

        public int[] ListOfScales;
        public int CurrentScale;

        public void Paint_Button_Click(object sender, RoutedEventArgs e) {
            CanvasWrapper.Children.Clear();
            Draw(_coords, CurrentScale);
        }

        public MainPage()
        {
            InitializeComponent();
            Init();
            Draw(_coords, CurrentScale);
        }

        private void Init() {

            InitBorderColorsSelect();
            InitBackgroundColorSelect();
            InitScaleLEvelSelect();

            _coords = InitStartCoordinates();

            _scale = 0.5;
            
            

        }

        private ICustomPoint[] InitStartCoordinates() {

            ICustomPoint[] coords = new ICustomPoint[3];

            coords.SetValue(new CPoint(300, 0), 0);
            coords.SetValue(new CPoint(0, 600), 1);
            coords.SetValue(new CPoint(600, 600), 2);

            return coords;
        }

        private void InitBorderColorsSelect() {

            ListOfBorderColors = new SolidColorBrush[5];

            ListOfBorderColors.SetValue(new SolidColorBrush(Windows.UI.Colors.Black), 0);
            ListOfBorderColors.SetValue(new SolidColorBrush(Windows.UI.Colors.Azure), 1);
            ListOfBorderColors.SetValue(new SolidColorBrush(Windows.UI.Colors.Brown), 2);
            ListOfBorderColors.SetValue(new SolidColorBrush(Windows.UI.Colors.Coral), 3);
            ListOfBorderColors.SetValue(new SolidColorBrush(Windows.UI.Colors.Honeydew), 4);

            CurrentBorderColor = new SolidColorBrush(Windows.UI.Colors.Azure);
        }

        private void InitBackgroundColorSelect() {

            ListOfBgColors = new SolidColorBrush[5];

            ListOfBgColors.SetValue(new SolidColorBrush(Windows.UI.Colors.Black), 0);
            ListOfBgColors.SetValue(new SolidColorBrush(Windows.UI.Colors.Azure), 1);
            ListOfBgColors.SetValue(new SolidColorBrush(Windows.UI.Colors.Brown), 2);
            ListOfBgColors.SetValue(new SolidColorBrush(Windows.UI.Colors.Coral), 3);
            ListOfBgColors.SetValue(new SolidColorBrush(Windows.UI.Colors.Honeydew), 4);

            CurrentBgColor = new SolidColorBrush(Windows.UI.Colors.Brown);
        }

        private void InitScaleLEvelSelect() {

            ListOfScales = new int[7];

            for (int i = 0; i <= 6; i++) {
                ListOfScales.SetValue(i, i);
            }
            
            CurrentScale = 2;
        }
        private void Draw(ICustomPoint[] coordinates, int level) {

            if (level == 0) {
                DrawTriangle(coordinates);
                return;
            }

            level--;

            ICustomPoint[,] innerTrianglesCoords = CalculateInnerTrianglesCoordinates(coordinates, _scale);


            for (var i = 0; i < 3; i++) {

                ICustomPoint[] innerTriangleCoords = new ICustomPoint[3];

                for (var j = 0; j < 3; j++) {
                    innerTriangleCoords.SetValue(innerTrianglesCoords[i, j], j);
                }

                Draw(innerTriangleCoords, level);

            }
        }

        private void DrawTriangle(ICustomPoint[] coordinates) {

            Polyline polyline = new Polyline();

            polyline.Stroke = CurrentBorderColor;
            polyline.Fill = CurrentBgColor;
            polyline.StrokeThickness = 1;

            var points = new PointCollection();

            foreach (ICustomPoint _point in coordinates)
            {

                var x1 = _point.XCoord;
                var y1 = _point.YCoord;

                points.Add(new Point(x1, y1));

            }

            var x = coordinates[0].XCoord;
            var y = coordinates[0].YCoord;  

            points.Add(new Point(x, y));

            polyline.Points = points;

            CanvasWrapper.Children.Add(polyline);
        }

        private ICustomPoint[,] CalculateInnerTrianglesCoordinates(ICustomPoint[] outerTriangleCoords, double scale) {
            ICustomPoint[,] newCoords = new ICustomPoint[outerTriangleCoords.Length, outerTriangleCoords.Length];

            for (var i = 0; i < outerTriangleCoords.Length; i += 1) {

                ICustomPoint current = outerTriangleCoords[i];
                ICustomPoint next = null;
                ICustomPoint prev = null;

                newCoords.SetValue(current, i, 0);

                if (i == 0)
                {
                    next = outerTriangleCoords[i + 1];
                    prev = outerTriangleCoords[i + 2];

                }
                else if (i == outerTriangleCoords.Length - 1)
                {
                    next = outerTriangleCoords[i - 1];
                    prev = outerTriangleCoords[i - 2];
                }
                else {
                    next = outerTriangleCoords[i + 1];
                    prev = outerTriangleCoords[i - 1];
                }

                ICustomPoint nextPointCoords = current.GetPointOnLine(next, scale);
                ICustomPoint prevPointCoords = current.GetPointOnLine(prev, scale);

                newCoords.SetValue(nextPointCoords, i, 1);
                newCoords.SetValue(prevPointCoords, i, 2);
            }

            return newCoords;
        }
    }
}
