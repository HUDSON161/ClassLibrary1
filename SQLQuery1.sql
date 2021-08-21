CREATE DATABASE SimpleDb --создаем базу данных
USE SimpleDb

CREATE TABLE Categories --создаем таблицу с возможными категориями
(
	Id int NOT NULL IDENTITY PRIMARY KEY, --первичный ключ
	CategoryName nvarchar(50) NOT NULL --имя категории
);


CREATE TABLE Products --создаем таблицу с продуктами
(
	Id int NOT NULL IDENTITY PRIMARY KEY, --первичный ключ
	ProductName nvarchar(50) NOT NULL, --имя продукта
	CategoryId int NULL --для связи с таблицей категорий
	CONSTRAINT C1 FOREIGN KEY (CategoryId) REFERENCES Categories (Id)  --создаем связь 1 ко многим с таблицей категорий
);

INSERT INTO Categories
(CategoryName)
VALUES
    (N'Не известно'),
	(N'Электроника'),
	(N'Продукты питания'),
	(N'Газированные напитки'),
	(N'Товары для дома'),
	(N'Сокосодержащие напитки')

INSERT INTO Products
(ProductName,CategoryId)
VALUES
    (N'IPhone 666',2),
	(N'IPhone 666',5),
	(N'Хлеб',3),
	(N'Лимонад с соком',4),
	(N'Лимонад с соком',6),
	(N'Пакет',1),
	(N'Лазерная указка',1)

SELECT p.ProductName AS N'Наименование',c.CategoryName AS N'Категория' FROM Products p JOIN Categories c
ON p.CategoryId = c.Id --сам запрос на получение всех пар