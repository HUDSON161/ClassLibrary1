using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Triangle:Root
    {
        private double a;//сторона 1
        private double b;//сторона 2
        private double c;//сторона 3

        public Triangle(double a, double b, double c)//параметрический конструктор
        {
            try
            {
                if (a + b > c )//по геометрическим соображениям третья сторона не может быть больше суммы первых двух
                {
                    if ( a > 0 && b > 0 && c > 0)//так же все стороны долны быть положительными числами
                    {
                        if (a > b && a - b < c)//по геометрическим соображениям третья сторона не дотянется до вершины
                        {
                            this.a = a;
                            this.b = b;
                            this.c = c;
                        }
                        else if (a < b && b - a < c)//по геометрическим соображениям третья сторона не дотянется до вершины
                        {
                            this.a = a;
                            this.b = b;
                            this.c = c;
                        }
                        else throw new NotImplementedException();//не дадим ввести некорректные значения
                    }
                    else throw new NotImplementedException();//не дадим ввести некорректные значения
                }
                else throw new NotImplementedException();//не дадим ввести некорректные значения
            }
            catch(NotImplementedException ex)
            {
                Console.WriteLine("Такой треугольник не может существовать");
                throw new NotImplementedException();
            }
        }

        public override double CalculateArea()//вычислим площадь по трем сторонам(формула Герона)
        {
            double HalfPerimeter = (a + b + c)/2.0;
            return Math.Sqrt(HalfPerimeter * (HalfPerimeter - a) * (HalfPerimeter - b) * (HalfPerimeter - c));
        }

        private bool MyEqualFunction(double one,double two,double error)//функция-предикат для сравнения двух чисел с заданной погрешностью
        {
            if (one > 0 && two > 0)
            {
                if (Math.Abs(one - two) / (one + two) <= error)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        public bool IsARectangularTriangle()//предикат для проверки треугольника на прямоугольность
        {
            //если катеты существуют, мы найдем их возле одной из вершин
            if (MyEqualFunction(0.5 * a * b,CalculateArea(),1e-2)) return true;//если катеты находятся при первой вершине
            else if (MyEqualFunction(0.5 * b * c, CalculateArea(), 1e-2)) return true;//если катеты находятся при второй вершине
            else if (MyEqualFunction(0.5 * c * a, CalculateArea(), 1e-2)) return true;//если катеты находятся при третьей вершине
            else return false;//если катеты не найдены то треугольник не прямоугольный
        }
    }
}
