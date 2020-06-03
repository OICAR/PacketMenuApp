use master
go

create database OICAR
go

use OICAR
go

create table Address
(
	IDAddress int primary key IDENTITY(1, 1) NOT NULL,
	Country nvarchar(50) NULL,
	City nvarchar(50) NULL,
	PinCode nvarchar(50) NULL,
	Street nvarchar(50) NULL,
	Number nvarchar(50) NULL,

)
go

create table Alergy
(
	IDAlergy int primary key IDENTITY(1, 1) NOT NULL,
	Egg bit NOT NULL,
	Peanut bit NOT NULL,
	Shellfish bit NOT NULL,
	Soy bit NOT NULL,
	Fish bit NOT NULL,
	Sesame bit NOT NULL,

)
go

create table EatingHabits
(
	IDEatingHabits int primary key IDENTITY(1, 1) NOT NULL,
	Vegan bit NOT NULL,
	Vegetarian bit NOT NULL,
	AlergyID int foreign key references Alergy(IDAlergy) NOT NULL,
	LactoseIntolerant bit NOT NULL,
	CrohnsDisease bit NOT NULL,	
	CeliacDisease bit NOT NULL,	

)
go


create table Customer
(
	IDCustomer int primary key IDENTITY(1, 1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	Surname nvarchar(50) NOT NULL,
	EatingHabitsID int foreign key references EatingHabits(IDEatingHabits) NULL,
	AddressID int foreign key references Address(IDAddress) NULL

)
go

create table Caterer
(
	IDCaterer int primary key IDENTITY(1, 1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	OIB nvarchar(15) NOT NULL,
)
go

create table Meal 
(
	IDMeal int primary key IDENTITY(1, 1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	Amount int NOT NULL,
	Ingredients nvarchar(200) NOT NULL,
	EatingHabitsID int foreign key references EatingHabits(IDEatingHabits) NULL,

)
go

create table Beverage
(
	IDBeverage int primary key IDENTITY(1, 1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	EatingHabitsID int foreign key references EatingHabits(IDEatingHabits) NULL
)
go

create table Menu
(
	IDMenu int primary key IDENTITY(1, 1) NOT NULL,	
	Name nvarchar(50)
)
go

create table MenuMeal
(
	IDMenuMeal int primary key IDENTITY(1, 1) NOT NULL,	
	Price money NOT NULL,
	MealID int foreign key references Meal(IDMeal) NOT NULL,
	MenuID int foreign key references Menu(IDMenu) NOT NULL
)
go

create table MenuBeverage
(
	IDMenuBeverage int primary key IDENTITY(1, 1) NOT NULL,	
	Price money NOT NULL,
	BeverageID int foreign key references Beverage(IDBeverage) NOT NULL,
	MenuID int foreign key references Menu(IDMenu) NOT NULL
)
go


create table Restaurant
(
	IDRestaurant int primary key IDENTITY(1, 1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	AddressID int foreign key references Address(IDAddress) NOT NULL,
	CatererID int foreign key references Caterer(IDCaterer) NOT NULL,
	Rating float NULL,
	MenuID int foreign key references Menu(IDMenu) NOT NULL	
)
go

create table Caffe
(
	IDCaffe int primary key IDENTITY(1, 1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	AddressID int foreign key references Address(IDAddress) NOT NULL,
	CatererID int foreign key references Caterer(IDCaterer) NOT NULL,
	Rating float NULL,
	MenuID int foreign key references Menu(IDMenu) NOT NULL
)
go

-------------------------------------STORED PROCEDURES
---------------------------------------------CUSTOMER

---AddCustomer
create proc AddCustomer
		@Name nvarchar(50),
		@Surname nvarchar(50),
		@Vegan bit,
		@Vegetarian bit, 
		@LactoseIntolerant bit, 
		@CrohnsDisease bit, 
		@CeliacDisease bit, 
		@Egg bit, 
		@Peanut bit, 
		@Shellfish bit, 
		@Soy bit, 
		@Fish bit, 
		@Sesame bit, 
		@Country nvarchar(50), 
		@City nvarchar(50), 
		@PinCode nvarchar(50), 
		@Street nvarchar(50), 
		@Number nvarchar(50) 
as
INSERT INTO Address (Country, City, PinCode, Street, Number) VALUES (@Country, @City, @PinCode, @Street, @Number)
DECLARE @AddressID int
SET @AddressID=SCOPE_IDENTITY()
INSERT INTO Alergy (Egg, Peanut, Shellfish, Soy, Fish, Sesame) VALUES (@Egg, @Peanut, @Shellfish, @Soy, @Fish, @Sesame)
DECLARE @AlergyID int
SET @AlergyID=SCOPE_IDENTITY()
INSERT INTO EatingHabits (Vegan, Vegetarian, AlergyID, LactoseIntolerant, CrohnsDisease, CeliacDisease) VALUES (@Vegan, @Vegetarian, @AlergyID, @LactoseIntolerant, @CrohnsDisease, @CeliacDisease)
DECLARE @EatingHabitsID int
SET @EatingHabitsID=SCOPE_IDENTITY()
INSERT INTO Customer (Name, Surname, EatingHabitsID, AddressID) VALUES (@Name, @Surname, @EatingHabitsID, @AddressID)
go

---DeleteCustomer
CREATE PROC DeleteCustomer
	@id int
AS
DECLARE @EatingHabitsID int
SELECT @EatingHabitsID=C.EatingHabitsID FROM Customer AS C
WHERE C.IDCustomer=@id

DECLARE @AddressID int
SELECT @AddressID=C.AddressID FROM Customer AS C
WHERE C.IDCustomer=@id

DECLARE @AlergyID int
SELECT @AlergyID=E.AlergyID FROM EatingHabits AS E
WHERE E.IDEatingHabits=@EatingHabitsID

DELETE FROM Address WHERE IDAddress=@AddressID
DELETE FROM Alergy WHERE IDAlergy=@AlergyID
DELETE FROM EatingHabits WHERE IDEatingHabits=@EatingHabitsID
DELETE FROM Customer WHERE IDCustomer=@id
GO

---UpdateCustomer
create proc UpdateCustomer
		@Id int,
		@Name nvarchar(50),
		@Surname nvarchar(50),
		@Vegan bit,
		@Vegetarian bit, 
		@LactoseIntolerant bit, 
		@CrohnsDisease bit, 
		@CeliacDisease bit, 
		@Egg bit, 
		@Peanut bit, 
		@Shellfish bit, 
		@Soy bit, 
		@Fish bit, 
		@Sesame bit, 
		@Country nvarchar(50), 
		@City nvarchar(50), 
		@PinCode nvarchar(50), 
		@Street nvarchar(50), 
		@Number nvarchar(50) 
as
DECLARE @AddressID int
SELECT @AddressID=C.AddressID FROM Customer as c WHERE C.IDCustomer=@Id
UPDATE Address SET Country=@Country, City=@City, PinCode=@PinCode, Street=@Street, Number=@Number WHERE IDAddress=@AddressID

DECLARE @EatingHabitsID int
SELECT @EatingHabitsID=C.EatingHabitsID FROM Customer as c WHERE C.IDCustomer=@Id
UPDATE EatingHabits SET Vegan=@Vegan, Vegetarian=@Vegetarian, LactoseIntolerant=@LactoseIntolerant, CrohnsDisease=@CrohnsDisease, CeliacDisease=@CeliacDisease WHERE IDEatingHabits=@EatingHabitsID

DECLARE @AlergyID int
SELECT @AlergyID=AlergyID FROM EatingHabits as e WHERE e.IDEatingHabits=@EatingHabitsID
UPDATE Alergy SET Egg=@Egg, Peanut=@Peanut, Shellfish=@Shellfish, Soy=@Soy, Fish=@Fish, Sesame=@Sesame WHERE IDAlergy=@AlergyID

UPDATE Customer SET Name=@Name, Surname=@Surname WHERE IDCustomer=@Id
go

---GetCustomer
create proc GetCustomer
	@id int
as
select c.IDCustomer, c.Name, c.Surname, a.Country, a.IDAddress, a.City, a.Pincode, a.Street, a.Number, 
	e.IDEatingHabits, e.CeliacDisease, e.CrohnsDisease, e.LactoseIntolerant, e.Vegan, e.Vegetarian, 
	al.IDAlergy ,al.Egg, al.Fish, al.Peanut, al.Sesame, al.Shellfish, al.Soy
from customer as c
inner join address as a on a.idaddress=c.addressid
inner join eatinghabits as e on e.ideatinghabits=c.eatinghabitsid
inner join alergy as al on al.idalergy=e.alergyid
where IDCustomer=@id
go


---GetAllCustomer
create proc GetAllCustomer
as
select c.IDCustomer, c.Name, c.Surname, 
	e.IDEatingHabits, e.Vegan, e.Vegetarian, e.CeliacDisease, e.CrohnsDisease, e.LactoseIntolerant,
	al.IDAlergy, al.Egg, al.Fish, al.Peanut, al.Sesame, al.Shellfish, al.Soy,
	a.IDAddress, a.Country, a.City, a.Pincode, a.Street, a.Number
from customer as c
inner join address as a on a.idaddress=c.addressid
inner join eatinghabits as e on e.ideatinghabits=c.eatinghabitsid
inner join alergy as al on al.idalergy=e.alergyid
go


---------------------------------------------CATERER

---AddCaterer
create proc AddCaterer
		@Name nvarchar(50),
		@OIB nvarchar(15)
as
INSERT INTO Caterer (Name, OIB) VALUES (@Name, @OIB)
go

---DeleteCaterer
CREATE PROC DeleteCaterer
	@id int
AS
DELETE FROM Caterer WHERE IDCaterer=@id
go
---UpdateCaterer
CREATE proc UpdateCaterer
		@Id int,
		@Name nvarchar(50),
		@OIB nvarchar(50)
as
UPDATE Caterer SET Name=@Name, OIB=@OIB WHERE IDCaterer=@Id
go

---GetCaterer
create proc GetCaterer
	@id int
as
select c.IDCaterer, c.Name, c.OIB 
from Caterer as c
where IDCaterer=@id
go
---GetAllCaterer
create proc GetAllCaterer
as
select c.IDCaterer, c.Name, c.OIB 
from Caterer as c
go

---------------------------------------------MEAL


---AddMeal
create proc AddMeal
		@Name nvarchar(50),
		@Amount int,
		@Ingredients nvarchar(200),
		@Vegan bit,
		@Vegetarian bit, 
		@LactoseIntolerant bit, 
		@CrohnsDisease bit, 
		@CeliacDisease bit, 
		@Egg bit, 
		@Peanut bit, 
		@Shellfish bit, 
		@Soy bit, 
		@Fish bit, 
		@Sesame bit
as
INSERT INTO Alergy (Egg, Peanut, Shellfish, Soy, Fish, Sesame) VALUES (@Egg, @Peanut, @Shellfish, @Soy, @Fish, @Sesame)
DECLARE @AlergyID int
SET @AlergyID=SCOPE_IDENTITY()
INSERT INTO EatingHabits (Vegan, Vegetarian, AlergyID, LactoseIntolerant, CrohnsDisease, CeliacDisease) VALUES (@Vegan, @Vegetarian, @AlergyID, @LactoseIntolerant, @CrohnsDisease, @CeliacDisease)
DECLARE @EatingHabitsID int
SET @EatingHabitsID=SCOPE_IDENTITY()
INSERT INTO Meal (Name, Amount, Ingredients, EatingHabitsID) VALUES (@Name, @Amount, @Ingredients, @EatingHabitsID)
go

---DeleteMeal
CREATE PROC DeleteMeal
	@id int
AS
DECLARE @EatingHabitsID int
SELECT @EatingHabitsID=M.EatingHabitsID FROM Meal AS M
WHERE M.IDMeal=@id

DECLARE @AlergyID int
SELECT @AlergyID=E.AlergyID FROM EatingHabits AS E
WHERE E.IDEatingHabits=@EatingHabitsID

DELETE FROM Alergy WHERE IDAlergy=@AlergyID
DELETE FROM EatingHabits WHERE IDEatingHabits=@EatingHabitsID
DELETE FROM Meal WHERE IDMeal=@id
GO

---UpdateMeal
CREATE proc UpdateMeal
		@Id int,
		@Name nvarchar(50),
		@Amount int,
		@Ingredients nvarchar(200),
		@Vegan bit,
		@Vegetarian bit, 
		@LactoseIntolerant bit, 
		@CrohnsDisease bit, 
		@CeliacDisease bit, 
		@Egg bit, 
		@Peanut bit, 
		@Shellfish bit, 
		@Soy bit, 
		@Fish bit, 
		@Sesame bit
as
DECLARE @EatingHabitsID int
SELECT @EatingHabitsID=m.EatingHabitsID FROM Meal as m WHERE m.EatingHabitsID =@Id
UPDATE EatingHabits SET Vegan=@Vegan, Vegetarian=@Vegetarian, LactoseIntolerant=@LactoseIntolerant, CrohnsDisease=@CrohnsDisease, CeliacDisease=@CeliacDisease

DECLARE @AlergyID int
SELECT @AlergyID=AlergyID FROM EatingHabits as e WHERE e.IDEatingHabits=@EatingHabitsID
UPDATE Alergy SET Egg=@Egg, Peanut=@Peanut, Shellfish=@Shellfish, Soy=@Soy, Fish=@Fish, Sesame=@Sesame WHERE IDAlergy=@AlergyID

UPDATE Meal SET Name=@Name, Amount=@Amount, Ingredients=@Ingredients, EatingHabitsID=@EatingHabitsID WHERE IDMeal=@Id
go



---GetMeal
create proc GetMeal
	@id int
as
select m.IDMeal, m.Name, m.Amount, m.Ingredients, 
	e.IDEatingHabits, e.CeliacDisease, e.CrohnsDisease, e.LactoseIntolerant, e.Vegan, e.Vegetarian, 
	al.IDAlergy ,al.Egg, al.Fish, al.Peanut, al.Sesame, al.Shellfish, al.Soy
from Meal as m
inner join eatinghabits as e on e.ideatinghabits=m.eatinghabitsid
inner join alergy as al on al.idalergy=e.alergyid
where IDMeal=@id
go
---GetAllMeal
create proc GetAllMeal
as
select m.IDMeal, m.Name, m.Amount, m.Ingredients, 
	e.IDEatingHabits, e.CeliacDisease, e.CrohnsDisease, e.LactoseIntolerant, e.Vegan, e.Vegetarian, 
	al.IDAlergy ,al.Egg, al.Fish, al.Peanut, al.Sesame, al.Shellfish, al.Soy
from Meal as m
inner join eatinghabits as e on e.ideatinghabits=m.eatinghabitsid
inner join alergy as al on al.idalergy=e.alergyid
go
---------------------------------------------BEVERAGE

---AddBeverage
create proc AddBeverage
		@Name nvarchar(50),
		@Vegan bit,
		@Vegetarian bit, 
		@LactoseIntolerant bit, 
		@CrohnsDisease bit, 
		@CeliacDisease bit, 
		@Egg bit, 
		@Peanut bit, 
		@Shellfish bit, 
		@Soy bit, 
		@Fish bit, 
		@Sesame bit
as
INSERT INTO Alergy (Egg, Peanut, Shellfish, Soy, Fish, Sesame) VALUES (@Egg, @Peanut, @Shellfish, @Soy, @Fish, @Sesame)
DECLARE @AlergyID int
SET @AlergyID=SCOPE_IDENTITY()
INSERT INTO EatingHabits (Vegan, Vegetarian, AlergyID, LactoseIntolerant, CrohnsDisease, CeliacDisease) VALUES (@Vegan, @Vegetarian, @AlergyID, @LactoseIntolerant, @CrohnsDisease, @CeliacDisease)
DECLARE @EatingHabitsID int
SET @EatingHabitsID=SCOPE_IDENTITY()
INSERT INTO Beverage(Name, EatingHabitsID) VALUES (@Name, @EatingHabitsID)
go
---DeleteBeverage
CREATE PROC DeleteBeverage
	@id int
AS
DECLARE @EatingHabitsID int
SELECT @EatingHabitsID=M.EatingHabitsID FROM Meal AS M
WHERE M.IDMeal=@id

DECLARE @AlergyID int
SELECT @AlergyID=E.AlergyID FROM EatingHabits AS E
WHERE E.IDEatingHabits=@EatingHabitsID

DELETE FROM Alergy WHERE IDAlergy=@AlergyID
DELETE FROM EatingHabits WHERE IDEatingHabits=@EatingHabitsID
DELETE FROM Beverage WHERE IDBeverage=@id
GO
---UpdateBeverage
CREATE proc UpdateBeverage
		@Id int,
		@Name nvarchar(50),
		@Vegan bit,
		@Vegetarian bit, 
		@LactoseIntolerant bit, 
		@CrohnsDisease bit, 
		@CeliacDisease bit, 
		@Egg bit, 
		@Peanut bit, 
		@Shellfish bit, 
		@Soy bit, 
		@Fish bit, 
		@Sesame bit
as
DECLARE @EatingHabitsID int
SELECT @EatingHabitsID=m.EatingHabitsID FROM Meal as m WHERE m.EatingHabitsID =@Id
UPDATE EatingHabits SET Vegan=@Vegan, Vegetarian=@Vegetarian, LactoseIntolerant=@LactoseIntolerant, CrohnsDisease=@CrohnsDisease, CeliacDisease=@CeliacDisease

DECLARE @AlergyID int
SELECT @AlergyID=AlergyID FROM EatingHabits as e WHERE e.IDEatingHabits=@EatingHabitsID
UPDATE Alergy SET Egg=@Egg, Peanut=@Peanut, Shellfish=@Shellfish, Soy=@Soy, Fish=@Fish, Sesame=@Sesame WHERE IDAlergy=@AlergyID

UPDATE Beverage SET Name=@Name, EatingHabitsID=@EatingHabitsID WHERE IDBeverage=@Id
go

---GetBeverage
create proc GetBeverage
	@id int
as
select b.IDBeverage, b.Name,
	e.IDEatingHabits, e.CeliacDisease, e.CrohnsDisease, e.LactoseIntolerant, e.Vegan, e.Vegetarian, 
	al.IDAlergy ,al.Egg, al.Fish, al.Peanut, al.Sesame, al.Shellfish, al.Soy
from Beverage as b
inner join eatinghabits as e on e.ideatinghabits=b.eatinghabitsid
inner join alergy as al on al.idalergy=e.alergyid
where IDBeverage=@id
go
---GetAllBeverage
create proc GetAllBeverage
as
select b.IDBeverage, b.Name,
	e.IDEatingHabits, e.CeliacDisease, e.CrohnsDisease, e.LactoseIntolerant, e.Vegan, e.Vegetarian, 
	al.IDAlergy ,al.Egg, al.Fish, al.Peanut, al.Sesame, al.Shellfish, al.Soy
from Beverage as b
inner join eatinghabits as e on e.ideatinghabits=b.eatinghabitsid
inner join alergy as al on al.idalergy=e.alergyid
go

---------------------------------------------MENU
---AddMenu
create proc AddMenu
		@Name nvarchar(50)
as
INSERT INTO Menu (Name) VALUES  (@Name)
go
---DeleteMenu
create proc DeleteMenu
		@id int
as
DELETE FROM Menu WHERE IDMenu=@id
go
---UpdateMenu
CREATE proc UpdateMenu
		@Id int,
		@Name nvarchar(50)
as
UPDATE Menu SET Name=@Name WHERE IDMenu=@Id
go
---GetMenu
create proc GetMenu
		@id int
as
SELECT m.IDMenu, m.Name FROM Menu as m
WHERE IDMenu=@id
go
---GetAllMenu
create proc GetAllMenu
as
SELECT m.IDMenu, m.Name FROM Menu as m
go

---------------------------------------------MENUMEAL
---AddMenuMeal
create proc AddMenuMeal
		@Price money,
		@MealID int,
		@MenuID int
as
INSERT INTO MenuMeal (Price, MealID, MenuID) VALUES  (@Price, @MealID, @MenuID)
go

---DeleteMenuMeal
create proc DeleteMenuMeal
		@id int
as
DELETE FROM MenuMeal WHERE IDMenuMeal=@id
go
---UpdateMenuMeal
CREATE proc UpdateMenuMeal
		@Id int,
		@Price money,
		@MealID int,
		@MenuID int
as
UPDATE MenuMeal SET Price=@Price, MealID=@MealID, MenuID=@MenuID WHERE IDMenuMeal=@Id
go
---GetMenuMeal
create proc GetMenuMeal
		@id int
as
SELECT m.IDMenuMeal, m.Price, m.MealID, m.MenuID FROM MenuMeal as m
WHERE IDMenuMeal=@id
go
---GetAllMenuMeal
create proc GetAllMenuMeal
as
SELECT m.IDMenuMeal, m.Price, m.MealID, m.MenuID FROM MenuMeal as m
go


---------------------------------------------MENUBEVERAGE

---AddMenuBeverage
create proc AddMenuBeverage
		@Price money,
		@BeverageID int,
		@MenuID int
as
INSERT INTO MenuBeverage (Price, BeverageID, MenuID) VALUES (@Price, @BeverageID,  @MenuID)
go
---DeleteMenuBeverage
create proc DeleteMenuBeverage
		@id int
as
DELETE FROM MenuBeverage WHERE IDMenuBeverage=@id
go
---UpdateMenuBeverage
CREATE proc UpdateMenuBeverage
		@Id int,
		@Price money,
		@BeverageID int,
		@MenuID int
as
UPDATE MenuBeverage SET Price=@Price, BeverageID=@BeverageID, MenuID=@MenuID WHERE IDMenuBeverage=@Id
go

---GetMenuBeverage
create proc GetMenuBeverage
		@id int
as
SELECT m.IDMenuBeverage, m.Price, m.BeverageID, m.MenuID FROM MenuBeverage as m
WHERE IDMenuBeverage=@id
go
---GetAllMenuBeverage
create proc GetAllMenuBeverage
as
SELECT m.IDMenuBeverage, m.Price, m.BeverageID, m.MenuID FROM MenuBeverage as m
go
---------------------------------------------RESTAURANT

---AddRestaurant
create proc AddRestaurant
		@Name nvarchar(50),
		@Rating int,
		@Country nvarchar(50), 
		@City nvarchar(50), 
		@PinCode nvarchar(50), 
		@Street nvarchar(50), 
		@Number nvarchar(50),
		@NameCaterer nvarchar(50),
		@OIB nvarchar(15),
		@MenuID int
as
INSERT INTO Address (Country, City, PinCode, Street, Number) VALUES (@Country, @City, @PinCode, @Street, @Number)
DECLARE @AddressID int
SET @AddressID=SCOPE_IDENTITY()

INSERT INTO Caterer (Name, OIB) VALUES (@NameCaterer, @OIB)
DECLARE @CatererID int
SET @CatererID=SCOPE_IDENTITY()

INSERT INTO Restaurant(Name, AddressID, CatererID, Rating, MenuID) values (@Name, @AddressID, @CatererID, @Rating, @MenuID)
go
---DeleteRestaurant
create proc DeleteRestaurant
		@id int
as
DECLARE @AddressID int
SELECT @AddressID=r.AddressID FROM Restaurant AS r
WHERE R.IDRestaurant=@id

DELETE FROM Address WHERE IDAddress=@AddressID
DELETE FROM Restaurant where IDRestaurant=@id
go

---UpdateRestaurant
CREATE proc UpdateRestaurant
		@Id int,
		@Name nvarchar(50),
		@Country nvarchar(50), 
		@City nvarchar(50), 
		@PinCode nvarchar(50), 
		@Street nvarchar(50), 
		@Number nvarchar(50),
		@IDCaterer int,
		@Rating int,
		@MenuID int
as
DECLARE @AddressID int
SELECT @AddressID=r.AddressID FROM Restaurant as r WHERE r.IDRestaurant=@Id
UPDATE Address SET Country=@Country, City=@City, PinCode=@PinCode, Street=@Street, Number=@Number WHERE IDAddress=@AddressID

UPDATE Restaurant SET Name=@Name, CatererID=@IDCaterer, Rating=@Rating, MenuID=@MenuID WHERE IDRestaurant=@Id
go
---GetRestaurant
create proc GetRestaurant
	@id int
as
select r.IDRestaurant, r.Name, r.Rating, r.MenuID,
	a.IDAddress, a.Country, a.City, a.Pincode, a.Street, a.Number,
	c.IDCaterer, c.Name, c.OIB
from Restaurant as r
inner join Address as a on a.IDAddress=r.AddressID
inner join Caterer as c on c.IDCaterer=r.CatererID
where r.IDRestaurant=@id
go
---GetAllRestaurant
create proc GetAllRestaurant
as
select r.IDRestaurant, r.Name, r.Rating, r.MenuID,
	a.IDAddress, a.Country, a.City, a.Pincode, a.Street, a.Number,
	c.IDCaterer, c.Name, c.OIB
from Restaurant as r
inner join Address as a on a.IDAddress=r.AddressID
inner join Caterer as c on c.IDCaterer=r.CatererID
go
---------------------------------------------CAFFE
---AddCaffe
create proc AddCaffe
		@Name nvarchar(50),
		@Rating int,
		@Country nvarchar(50), 
		@City nvarchar(50), 
		@PinCode nvarchar(50), 
		@Street nvarchar(50), 
		@Number nvarchar(50),
		@NameCaterer nvarchar(50),
		@OIB nvarchar(15),
		@MenuID int
as
INSERT INTO Address (Country, City, PinCode, Street, Number) VALUES (@Country, @City, @PinCode, @Street, @Number)
DECLARE @AddressID int
SET @AddressID=SCOPE_IDENTITY()

INSERT INTO Caterer (Name, OIB) VALUES (@NameCaterer, @OIB)
DECLARE @CatererID int
SET @CatererID=SCOPE_IDENTITY()

INSERT INTO Caffe(Name, AddressID, CatererID, Rating, MenuID) values (@Name, @AddressID, @CatererID, @Rating, @MenuID)
go
---DeleteCaffe
CREATE proc DeleteCaffe
		@id int
as
DECLARE @AddressID int
SELECT @AddressID=r.AddressID FROM Caffe AS r
WHERE R.IDCaffe=@id

DELETE FROM Address WHERE IDAddress=@AddressID
DELETE FROM Caffe where IDCaffe=@id
go

---UpdateCaffe
CREATE proc UpdateCaffe
		@Id int,
		@Name nvarchar(50),
		@Country nvarchar(50), 
		@City nvarchar(50), 
		@PinCode nvarchar(50), 
		@Street nvarchar(50), 
		@Number nvarchar(50),
		@IDCaterer int,
		@Rating int,
		@MenuID int		
as
DECLARE @AddressID int
SELECT @AddressID=r.AddressID FROM Restaurant as r WHERE r.IDRestaurant=@Id
UPDATE Address SET Country=@Country, City=@City, PinCode=@PinCode, Street=@Street, Number=@Number WHERE IDAddress=@AddressID

UPDATE Caffe SET Name=@Name, CatererID=@IDCaterer, Rating=@Rating, MenuID=@MenuID WHERE IDCaffe=@Id
go
---GetCaffe
create proc GetCaffe
	@id int
as
select r.IDCaffe, r.Name, r.Rating, r.MenuID,
	a.IDAddress, a.Country, a.City, a.Pincode, a.Street, a.Number,
	c.IDCaterer, c.Name, c.OIB
from Caffe as r
inner join Address as a on a.IDAddress=r.AddressID
inner join Caterer as c on c.IDCaterer=r.CatererID
where r.IDCaffe=@id
go
---GetAllCaffe
create proc GetAllCaffe
as
select r.IDCaffe, r.Name, r.Rating, r.MenuID,
	a.IDAddress, a.Country, a.City, a.Pincode, a.Street, a.Number,
	c.IDCaterer, c.Name, c.OIB
from Caffe as r
inner join Address as a on a.IDAddress=r.AddressID
inner join Caterer as c on c.IDCaterer=r.CatererID
go
