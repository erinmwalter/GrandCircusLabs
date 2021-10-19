using System;
using System.Collections.Generic;
using System.Text;

namespace CircleApp
{
    class Circle
    {
        //user enters radius and the circumference and area point to radius reference and auto update. 
        public double Radius { get; set; }
        public double Circumference  => (Radius * 2 * Math.PI);
        public double Area => (Radius * Radius * Math.PI);

        public Circle(double Radius)
        {
            this.Radius = Radius;
        }

        //custom ToString display block for the cicle object
        public override string ToString()
        {
            return $"Radius: {Math.Round(Radius, 2)} Circumference: {Math.Round(Circumference, 2)} Area: {Math.Round(Area, 2)}";
        }
    }
}
