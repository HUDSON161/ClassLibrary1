using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class Root//корневой абстрактный класс коорый будет использоваться как ссылка для взаимодействия
    {
        public abstract double CalculateArea();//шаблон метода для вычисления площади
    }
}