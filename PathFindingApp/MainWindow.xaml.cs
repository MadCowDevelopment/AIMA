using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Search.Algorithm;
using Search.Framework;
using Search.PathFinding;

using Point = Search.Types.Point;

namespace PathFindingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBlock _startTextBlock;

        private TextBlock _goalTextBlock;

        private List<Polyline> _polyLines;

        private Polyline _currentPolyLine;

        public MainWindow()
        {
            InitializeComponent();

            _startTextBlock = new TextBlock { Text = "S" };
            _goalTextBlock = new TextBlock { Text = "G" };

            Canvas.SetLeft(_startTextBlock, 100);
            Canvas.SetTop(_startTextBlock, 100);
            DrawingCanvas.Children.Add(_startTextBlock);

            Canvas.SetLeft(_goalTextBlock, 800);
            Canvas.SetTop(_goalTextBlock, 600);
            DrawingCanvas.Children.Add(_goalTextBlock);

            _polyLines = new List<Polyline>();
            _currentPolyLine = new Polyline();
            _currentPolyLine.StrokeThickness = 1;
            _currentPolyLine.Stroke = new SolidColorBrush(Colors.Black);
            DrawingCanvas.Children.Add(_currentPolyLine);
            _polyLines.Add(_currentPolyLine);
        }

        private void ButtonStartClick(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonGoalClick(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonRectangleClick(object sender, RoutedEventArgs e)
        {

        }

        private void DrawingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                _currentPolyLine.Points.Add(_currentPolyLine.Points[0]);

                _currentPolyLine = new Polyline();
                _currentPolyLine.StrokeThickness = 1;
                _currentPolyLine.Stroke = new SolidColorBrush(Colors.Black);
                DrawingCanvas.Children.Add(_currentPolyLine);
                _polyLines.Add(_currentPolyLine);
            }
            else
            {
                var point = Mouse.GetPosition(DrawingCanvas);
                var pointRounded = new System.Windows.Point(Math.Round(point.X), Math.Round(point.Y));
                _currentPolyLine.Points.Add(pointRounded);
            }
        }

        private void ButtonSolveClick(object sender, RoutedEventArgs e)
        {
            if (_currentPolyLine.Points.Count >= 2)
            {
                _currentPolyLine.Points.Add(_currentPolyLine.Points[0]);
            }

            var initialState = new PathFindingState(new Search.Types.Point(100, 100));
            var goalState = new PathFindingState(new Search.Types.Point(800, 600));

            var environment = new PathFindingEnvironment();

            foreach (var polyLine in _polyLines)
            {
                var points = polyLine.Points.Select(p => p).Distinct().ToList();
                for (int i = 0; i < points.Count; i++)
                {
                    for (int j = i + 1; j < points.Count; j++)
                    {
                        if (i == j) continue;

                        var pointLine = new PointLine(
                            new Point(points[i].X, points[i].Y),
                            new Point(points[j].X, points[j].Y));

                        environment.PointLines.Add(pointLine);
                    }
                }
            }

            var actionFunction = new PathFindingActionFunction(environment, goalState);
            var resultFunction = new PathFindingResultFunction();
            var goalTest = new PathFindingGoalTest(goalState);
            var stepCost = new PathFindingStepCost();
            var searchAlgorithm = new GraphSearch<PathFindingState, PathFindingAction>();

            var problem = new Problem<PathFindingState, PathFindingAction>(initialState, actionFunction, resultFunction, goalTest, stepCost);

            var solution = searchAlgorithm.Search(problem);

            for (int i = 1; i < solution.Count; i++)
            {
                AddLine(
                    solution[i - 1].State.Point.X,
                    solution[i - 1].State.Point.Y,
                    solution[i].State.Point.X,
                    solution[i].State.Point.Y);
            }
        }

        private void AddLine(double x1, double y1, double x2, double y2)
        {
            Line lineObj = new Line();
            lineObj.Stroke = new SolidColorBrush(Colors.Green);
            lineObj.X1 = x1;
            lineObj.X2 = x2;
            lineObj.Y1 = y1;
            lineObj.Y2 = y2;

            DrawingCanvas.Children.Add(lineObj);
        }
    }
}
