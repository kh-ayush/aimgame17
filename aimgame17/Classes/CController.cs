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
        }
}
