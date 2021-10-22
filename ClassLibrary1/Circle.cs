using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Circle:Root//наследуемся
    {
        private double Radius;//радиус
        public Circle(double Radius)//параметрический конструктор
        {
            if (Radius > 0)//понятно что радиус всегда положителен
            {
                this.Radius = Radius;
            }
            else throw new NotImplementedException();//не дадим ввести некорректные значения
        }
        public override double CalculateArea() { return Math.PI * Math.Pow(Radius, 2.0); }//вычислим площадь круга
    }
}
