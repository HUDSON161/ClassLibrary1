using System;
using Xunit;
using ClassLibrary1;

namespace ClassLibrary1.Test
{
    public class TestTriangle
    {
        [Fact]
        public void Triangle_Constructor_IncorrectTriangle()//обязательно нужно проверить конструктор ( если ввести некорректные стороны то такой треугольник
                                                            //не должен создаваться и должен выплюнуть исключение )
        {
            //arrange
            double a0 = 2.0;
            double b0 = 3.0;
            double c0 = 7.5;//специально сделаем третью сторону больше суммы двух других чтобы вызвать исключение

            //action
            Action testCode = () => { Triangle TestTriangle = new Triangle(a0, b0, c0); };

            //assert
            var ex = Record.Exception(testCode);
            Assert.NotNull(ex);
        }

        [Fact]
        public void Triangle_Constructor_CorrectTriangle()//обязательно нужно проверить конструктор ( теперь введем корректный треугольник, при создании не должно вылезти исключение )
        {
            //arrange
            double a0 = 2.0;
            double b0 = 3.0;
            double c0 = 4.5;//специально сделаем третью сторону меньше суммы двух других, что должно обеспечить корректное создание экземпляра

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
        public void Triangle_IsARectangularTriangleMethodMain()//проверяем основной метод определяющий прямоугольность треугольника
        {
            //arrange
            double a0 = 2.0;
            double b0 = 3.0;
            double c0 = 3.606;
            bool ExpectedResult = true;

            //act
            Triangle TestTriangle = new Triangle(a0, b0, c0);
            bool calculated = TestTriangle.IsARectangularTriangleMain();

            //Assert
            Assert.Equal(ExpectedResult, calculated);
        }

        [Fact]
        public void Triangle_IsARectangularTriangleMethodAlternative()//проверяем альтернативный метод определяющий прямоугольность треугольника
        {
            //arrange
            double a0 = 2.0;
            double b0 = 3.0;
            double c0 = 3.606;
            bool ExpectedResult = true;

            //act
            Triangle TestTriangle = new Triangle(a0, b0, c0);
            bool calculated = TestTriangle.IsARectangularTriangleAlternative();

            //Assert
            Assert.Equal(ExpectedResult, calculated);
        }
    }
}
