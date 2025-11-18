using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace aimgame17.Classes
{
    public class CController
    {
        private List<CObject> objects;
        private double spawnRate;
        private double time;
        private Random rng;

        private double minLifetime;
        private double maxLifetime;

        private double minSpriteSize;
        private double maxSpriteSize;

        private Size sceneSize;
        private double points;

        public CController(double spawnRate, ulong startTime, Size sceneSize)
        {
            rng = new Random();
            objects = new List<CObject>();
            this.spawnRate = spawnRate;
            time = startTime;
            this.sceneSize = sceneSize;

            points = 0;

            minLifetime = 1;
            maxLifetime = 5;

            minSpriteSize = 10;
            maxSpriteSize = 20;
        }

        public void spawnObject()
        {
            double lifetime = rng.NextDouble() * (maxLifetime - minLifetime) + minLifetime;
            double size = rng.NextDouble() * (maxSpriteSize - minSpriteSize) + minSpriteSize;

            // Случайная позиция
            int x = rng.Next(0, sceneSize.Width - (int)size);
            int y = rng.Next(0, sceneSize.Height - (int)size);

            CObject obj = new CObject(new Point(x, y), size, lifetime);
            objects.Add(obj);
        }
        public void destroyObject(CObject obj)
        {
            objects.Remove(obj);
        }

        public void update(double delta)
        {
            time += delta;
            if (time >= spawnRate)
            {
                spawnObject();
                time = 0;
            }
            for (int i = objects.Count - 1; i >= 0; i--)
            {
                objects[i].Update(delta);

                if (objects[i].Lifetime <= 0)
                {
                    destroyObject(objects[i]);
                }
            }
        }
        public void mouseClick(Point mousePosition)
        {
            for (int i = objects.Count - 1; i >= 0; i--)
            {
                if (objects[i].Contains(mousePosition))
                {
                    points++;
                    destroyObject(objects[i]);
                }
            }
        }
    }
}
