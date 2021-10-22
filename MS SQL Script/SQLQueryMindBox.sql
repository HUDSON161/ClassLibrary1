CREATE DATABASE ProductsCategories--создадим бд
GO

USE ProductsCategories--переключимс€ на нее
GO

CREATE TABLE Product--здесь храним все продукты
(
    Id int NOT NULL IDENTITY PRIMARY KEY,
    [Name] nvarchar(30) NOT NULL UNIQUE, -- наименование продукта ( подстрахуемс€ чтобы одинаковых продуктов не было )
	[Description] nvarchar(30) NULL, --необ€зательное поле если нужно описание продукта
);
GO

CREATE TABLE Category--здесь храним все возможные категории
(
    Id int NOT NULL IDENTITY PRIMARY KEY,
    [Name] nvarchar(30) NOT NULL UNIQUE,--наименование категории ( подстрахуемс€ чтобы одинаковых категорий не было )
);
GO

CREATE TABLE ProductCategory--здесь храним все категории всех продуктов
(
    Id int NOT NULL IDENTITY PRIMARY KEY,
    ProductName nvarchar(30) NULL CONSTRAINT OneToManyConnectionProduct FOREIGN KEY REFERENCES Product([Name]) , --св€зь один ко многим (продукт может быть только из списка всех продуктов)
	CategoryName nvarchar(30) NOT NULL CONSTRAINT OneToManyConnectionCategory FOREIGN KEY REFERENCES Category([Name]) , --св€зь один ко многим (товар может быть только из представленных)
	CONSTRAINT UniquePair UNIQUE(ProductName,CategoryName) , -- ( не должно быть одинаковых пар продукт-категори€, иначе это может привести к ошибкам или нерациональному использованию свободного пространства )
);  --св€зи тут конечно можно сделать через Id это было бы правильнее, но с точки зрени€ итоговой выборки это будет максимально просто ( не вижу смысла городить вложенные запросы когда можн ои без них обойтись )
    --да и с точки зрени€ добавлени€ в таблицу данных это пользователю будет проще ( ведь айдишники можно легко спутать )
GO


INSERT INTO Product--добавим немного продуктов
([Name],[Description])
VALUES
(N'√релка',N'производство китай'),
(N'јйфон',N'бесполезна€ электроника'),
(N'√оршок',NULL),
(N'–оман "¬ойна и мир"','Ћев “олстой')
GO

INSERT INTO Category--заполним базу произвольными категори€ми
([Name])
VALUES
(N'“овары дл€ дома'),
(N'Ёлектроника'),
(N'«арубежные товары'),
(N'ќбразовательные товары')
GO

INSERT INTO ProductCategory--заполним товары категори€ми
(ProductName,CategoryName)
VALUES
(N'√релка',N'“овары дл€ дома'),
(N'јйфон',N'Ёлектроника'),--у айфона будет две категории (1)
(N'јйфон',N'«арубежные товары'), --(2)
(N'–оман "¬ойна и мир"',N'ќбразовательные товары')
GO


SELECT P.[Name] AS N'ѕродукт',PC.CategoryName AS N'ќдна из категорий продукта' FROM Product P LEFT OUTER JOIN ProductCategory PC -- сам запрос дл€ получени€ всех пар продукт-категори€ и продуктов без категорий
ON P.[Name] = PC.[ProductName]
GO