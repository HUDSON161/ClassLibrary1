CREATE DATABASE SimpleDb --������� ���� ������
USE SimpleDb

CREATE TABLE Categories --������� ������� � ���������� �����������
(
	Id int NOT NULL IDENTITY PRIMARY KEY, --��������� ����
	CategoryName nvarchar(50) NOT NULL --��� ���������
);


CREATE TABLE Products --������� ������� � ����������
(
	Id int NOT NULL IDENTITY PRIMARY KEY, --��������� ����
	ProductName nvarchar(50) NOT NULL, --��� ��������
	CategoryId int NULL --��� ����� � �������� ���������
	CONSTRAINT C1 FOREIGN KEY (CategoryId) REFERENCES Categories (Id)  --������� ����� 1 �� ������ � �������� ���������
);

INSERT INTO Categories
(CategoryName)
VALUES
    (N'�� ��������'),
	(N'�����������'),
	(N'�������� �������'),
	(N'������������ �������'),
	(N'������ ��� ����'),
	(N'�������������� �������')

INSERT INTO Products
(ProductName,CategoryId)
VALUES
    (N'IPhone 666',2),
	(N'IPhone 666',5),
	(N'����',3),
	(N'������� � �����',4),
	(N'������� � �����',6),
	(N'�����',1),
	(N'�������� ������',1)

SELECT p.ProductName AS N'������������',c.CategoryName AS N'���������' FROM Products p JOIN Categories c
ON p.CategoryId = c.Id --��� ������ �� ��������� ���� ���