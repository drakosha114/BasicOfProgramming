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
using lab8_squares.CustomPoint;
using Windows.UI.Xaml.Shapes;

namespace lab8_squares
{

    public sealed partial class MainPage : Page
    {
        private int _numOfSteps;
        private double _scale;
        private CustomPoint.ICustomPoint[] _points;

        public MainPage()
        {
            InitializeComponent();

            _Init();
 
            do {

                _drawSquare();
                _calculateNewCoordinates();
                _numOfSteps--;

            } while (_numOfSteps > 0);
        }

        private void _Init() {

            _numOfSteps = 50;

            _scale = 0.88;

            _points = new ICustomPoint[4] { new CustomPoint.CustomPoint(0, 0), new CustomPoint.CustomPoint(0, 600), new CustomPoint.CustomPoint(600, 600), new CustomPoint.CustomPoint(600, 0) };

        }

        private void _drawSquare() {

            Polyline polyline = new Polyline();
            polyline.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
            polyline.StrokeThickness = 2;

            var points = new PointCollection();

            foreach (ICustomPoint _point in _points) {
                var x1 = _point.XCoord;
                var y1 = _point.YCoord;
                points.Add(new Point(x1, y1));
            }
            var x = _points[0].XCoord;
            var y = _points[0].YCoord;
            points.Add(new Point(x, y));

            polyline.Points = points;

            CanvasWrapper.Children.Add(polyline);
        }

        private void _calculateNewCoordinates() {

            var newPoints = new ICustomPoint[4];

            for (int counter = 0; counter < _points.Length; counter++) {
                var currentPoint = _points[counter];
                var nextPoint = counter == _points.Length - 1 ? _points[0] : _points[counter + 1];
                var newPoint = currentPoint.GetPointOnLine(nextPoint, _scale);

                newPoints.SetValue(newPoint, counter);
            }

            _points = newPoints;
        }
    }
}
