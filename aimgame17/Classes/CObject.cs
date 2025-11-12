using System;
using System.Collections.Generic;
using System.Drawing; 
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace aimgame17.Classes
{
    public class CObject
    {
        private System.Drawing.Point position;
        private System.Drawing.Size size;
        private double lifetime;
        private double pointsValue;
        private Ellipse dobryiSprite;

        public CObject(System.Drawing.Point position, double size, double lifetime)
        {
            this.position = position;
            this.size = new System.Drawing.Size((int)size, (int)size);
            this.lifetime = lifetime;

            dobryiSprite = new Ellipse();

            dobryiSprite.Fill = Brushes.BlueViolet;
            dobryiSprite.StrokeThickness = 2;
            dobryiSprite.Stroke = Brushes.Black;

            dobryiSprite.HorizontalAlignment = HorizontalAlignment.Center;
            dobryiSprite.VerticalAlignment = VerticalAlignment.Center;

            dobryiSprite.Width = this.size.Width;
            dobryiSprite.Height = this.size.Height;
            dobryiSprite.RenderTransform = new TranslateTransform(position.X, position.Y);

            pointsValue = ((1 / this.size.Width) / lifetime) * 1000;
        }

        public bool isMouseOnObject(System.Drawing.Point mousePosition) 
        {
            if (position == mousePosition) return true;
            return false;
        }
        public Ellipse getSprite() { return dobryiSprite; }
        public double getPointsValue() { return pointsValue; }
        public bool updateLifetime(double delta) { return true; }
    }
}
