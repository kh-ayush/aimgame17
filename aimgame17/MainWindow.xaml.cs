using aimgame17.Classes;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Shapes;

namespace aimgame17
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private CController controller;

        private double totalTime = 10;
        private double gameTimeLeft;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(16);
            timer.Tick += UpdateGame;

            btnStart.Click += BtnStart_Click;
            GameCanvas.MouseLeftButtonDown += GameCanvas_MouseLeftButtonDown;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            GameCanvas.Children.Clear();

            controller = new CController(
                spawnRate: sldSpeed.Value / 1000.0,
                startTime: 0,
                sceneSize: new System.Drawing.Size((int)GameCanvas.ActualWidth, (int)GameCanvas.ActualHeight)
            );

            gameTimeLeft = totalTime;

            lblScore.Text = "Score: 0";
            lblReady.Text = "Game Started!";

            timer.Start();
        }

        private void GameCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(GameCanvas);
            System.Drawing.Point pt = new System.Drawing.Point((int)pos.X, (int)pos.Y);

            CObject hit = controller.mouseClick(pt);

            if (hit != null)
            {
                GameCanvas.Children.Remove(hit.Sprite);
                lblScore.Text = $"Score: {controller.Points}";
            }
        }

        private void UpdateGame(object sender, EventArgs e)
        {
            double delta = 0.016;
            gameTimeLeft -= delta;

            lblTime.Text = $"Time: {Math.Round(gameTimeLeft, 1)}s";

            if (gameTimeLeft <= 0)
            {
                timer.Stop();
                lblReady.Text = "Finished!";
                lstLog.Items.Add($"Final Score: {controller.Points}");
                GameCanvas.Children.Clear();
                return;
            }

            controller.update(delta);

            GameCanvas.Children.Clear();

            foreach (var obj in controller.Objects)
                GameCanvas.Children.Add(obj.Sprite);
        }
    }
}
