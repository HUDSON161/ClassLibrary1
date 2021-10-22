CREATE DATABASE ProductsCategories--�������� ��
GO

USE ProductsCategories--������������ �� ���
GO

CREATE TABLE Product--����� ������ ��� ��������
(
    Id int NOT NULL IDENTITY PRIMARY KEY,
    [Name] nvarchar(30) NOT NULL UNIQUE, -- ������������ �������� ( ������������� ����� ���������� ��������� �� ���� )
	[Description] nvarchar(30) NULL, --�������������� ���� ���� ����� �������� ��������
);
GO

CREATE TABLE Category--����� ������ ��� ��������� ���������
(
    Id int NOT NULL IDENTITY PRIMARY KEY,
    [Name] nvarchar(30) NOT NULL UNIQUE,--������������ ��������� ( ������������� ����� ���������� ��������� �� ���� )
);
GO

CREATE TABLE ProductCategory--����� ������ ��� ��������� ���� ���������
(
    Id int NOT NULL IDENTITY PRIMARY KEY,
    ProductName nvarchar(30) NULL CONSTRAINT OneToManyConnectionProduct FOREIGN KEY REFERENCES Product([Name]) , --����� ���� �� ������ (������� ����� ���� ������ �� ������ ���� ���������)
	CategoryName nvarchar(30) NOT NULL CONSTRAINT OneToManyConnectionCategory FOREIGN KEY REFERENCES Category([Name]) , --����� ���� �� ������ (����� ����� ���� ������ �� ��������������)
	CONSTRAINT UniquePair UNIQUE(ProductName,CategoryName) , -- ( �� ������ ���� ���������� ��� �������-���������, ����� ��� ����� �������� � ������� ��� ��������������� ������������� ���������� ������������ )
);  --����� ��� ������� ����� ������� ����� Id ��� ���� �� ����������, �� � ����� ������ �������� ������� ��� ����� ����������� ������ ( �� ���� ������ �������� ��������� ������� ����� ���� �� ��� ��� �������� )
    --�� � � ����� ������ ���������� � ������� ������ ��� ������������ ����� ����� ( ���� ��������� ����� ����� ������� )
GO


INSERT INTO Product--������� ������� ���������
([Name],[Description])
VALUES
(N'������',N'������������ �����'),
(N'�����',N'����������� �����������'),
(N'������',NULL),
(N'����� "����� � ���"','��� �������')
GO

INSERT INTO Category--�������� ���� ������������� �����������
([Name])
VALUES
(N'������ ��� ����'),
(N'�����������'),
(N'���������� ������'),
(N'��������������� ������')
GO

INSERT INTO ProductCategory--�������� ������ �����������
(ProductName,CategoryName)
VALUES
(N'������',N'������ ��� ����'),
(N'�����',N'�����������'),--� ������ ����� ��� ��������� (1)
(N'�����',N'���������� ������'), --(2)
(N'����� "����� � ���"',N'��������������� ������')
GO


SELECT P.[Name] AS N'�������',PC.CategoryName AS N'���� �� ��������� ��������' FROM Product P LEFT OUTER JOIN ProductCategory PC -- ��� ������ ��� ��������� ���� ��� �������-��������� � ��������� ��� ���������
ON P.[Name] = PC.[ProductName]
GO