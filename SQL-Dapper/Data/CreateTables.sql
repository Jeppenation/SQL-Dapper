DROP TABLE IF EXISTS Customers;
DROP TABLE IF EXISTS Adresses;
DROP TABLE IF EXISTS Addresses;

CREATE TABLE Addresses 
(
 	Id int NOT NULL identity primary key,
	StreetName nvarchar(50) NOT NULL,
	PostalCode varchar(6) NOT NULL,
	City nvarchar(50) NOT NULL,
);


CREATE TABLE Customers (
	Id int NOT NULL identity primary key,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	Email nvarchar(50) NOT NULL unique,
	PhoneNumber varchar(10) NULL,
	AdressId int NOT NULL references Addresses(Id),
);