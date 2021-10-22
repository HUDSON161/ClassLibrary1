using System;
using Xunit;
using ClassLibrary1;

namespace ClassLibrary1.Test
{
    public class TestCircle
    {
        [Fact]
        public void Circle_ConstructorCorrectRadius()//�������� ����� �� �� ������������� ������ ( ���� �� �� ���� ����� ������ )
        {
            //arrange
            double Radius = 1.0;//������

            //act
            Action testCode = () => { Root TestCircle = new Circle(Radius); };

            //Assert
            var ex = Record.Exception(testCode);
            Assert.Null(ex);
        }

        [Fact]
        public void Circle_ConstructorIncorrectRadius()//( ���������� ������ ������������� ����� ) �������� ������ �� ������
        {
            //arrange
            double Radius = -1.0;//������

            //act
            Action testCode = () => { Root TestCircle = new Circle(Radius); };

            //Assert
            var ex = Record.Exception(testCode);
            Assert.NotNull(ex);
        }

        [Fact]
        public void Circle_CalculateArea()//��������� ����� ��������� �������
        {
            //arrange
            double Radius = 3.0;//������
            double ExpectedArea = 28.274333;//��������� ��������
            int precision = 2;//�����������, ����� ���� �� ���������

            //act
            Root TestCircle = new Circle(Radius);
            double area = TestCircle.CalculateArea();

            //assert
            Assert.Equal(ExpectedArea, area, precision);
        }
    }
}
