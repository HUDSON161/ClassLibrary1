using System;
using Xunit;
using ClassLibrary1;

namespace ClassLibrary1.Test
{
    public class TestCircle
    {
        [Fact]
        public void Circle_ConstructorCorrectRadius()//проверим ввели ли мы положительный радиус ( если да то круг будет создан )
        {
            //arrange
            double Radius = 1.0;//радиус

            //act
            Action testCode = () => { Root TestCircle = new Circle(Radius); };

            //Assert
            var ex = Record.Exception(testCode);
            Assert.Null(ex);
        }

        [Fact]
        public void Circle_ConstructorIncorrectRadius()//( специально введем отрицательное число ) проверим защиту от ошибок
        {
            //arrange
            double Radius = -1.0;//радиус

            //act
            Action testCode = () => { Root TestCircle = new Circle(Radius); };

            //Assert
            var ex = Record.Exception(testCode);
            Assert.NotNull(ex);
        }

        [Fact]
        public void Circle_CalculateArea()//проверяем метод считающий площадь
        {
            //arrange
            double Radius = 3.0;//радиус
            double ExpectedArea = 28.274333;//ожидаемое значение
            int precision = 2;//погрешность, чтобы тест не отвалился

            //act
            Root TestCircle = new Circle(Radius);
            double area = TestCircle.CalculateArea();

            //assert
            Assert.Equal(ExpectedArea, area, precision);
        }
    }
}
