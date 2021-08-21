using System;
using Xunit;
using ClassLibrary1;

namespace ClassLibrary1.Test
{
    public class TestTriangle
    {
        [Fact]
        public void Triangle_Constructor_Exception()/*проверяем конструктор
        я не буду здесь кучу тестов для этого конструктора делать, ограничусь одним, но по хорошему
        // тут еще тесты нужны с разными значениями
        */
        {
            //arrange
            double a0 = 2.0;
            double b0 = 3.0;
            double c0 = 7.5;

            //action
            Action testCode = () => { Triangle TestTriangle = new Triangle(a0, b0, c0); };

            //assert
            var ex = Record.Exception(testCode);
            Assert.Null(ex);
        }

        [Fact]
        public void Triangle_CalculateArea()//проверяем метод считающий площадь
        {
            //arrange
            double a0 = 3.0;
            double b0 = 4.0;
            double c0 = 5.0;
            double ExpectedArea = 6.0;//ожидаемое значение
            int precision = 2;//погрешность, чтобы тест не отвалился

            //act
            Root TestTriangle = new Triangle(a0, b0, c0);
            double area = TestTriangle.CalculateArea();

            //assert
            Assert.Equal(ExpectedArea, area, precision);
        }

        [Fact]
        public void Triangle_IsARectangularTriangle()//проверяем метод определяющий вид прямоугольника
        {
            //arrange
            double a0 = 2.0;
            double b0 = 3.0;
            double c0 = 3.606;
            bool ExpectedResult = true;

            //act
            Triangle TestTriangle = new Triangle(a0, b0, c0);
            bool calculated = TestTriangle.IsARectangularTriangle();

            //Assert
            Assert.Equal(ExpectedResult, calculated);
        }
    }
}
