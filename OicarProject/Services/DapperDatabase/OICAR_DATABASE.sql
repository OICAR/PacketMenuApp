USE [master]
GO
/****** Object:  Database [OICAR]    Script Date: 19/06/2020 17:25:03 ******/
CREATE DATABASE [OICAR]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OICAR', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OICAR.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OICAR_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OICAR_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OICAR] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OICAR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OICAR] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OICAR] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OICAR] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OICAR] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OICAR] SET ARITHABORT OFF 
GO
ALTER DATABASE [OICAR] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OICAR] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OICAR] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OICAR] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OICAR] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OICAR] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OICAR] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OICAR] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OICAR] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OICAR] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OICAR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OICAR] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OICAR] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OICAR] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OICAR] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OICAR] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OICAR] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OICAR] SET RECOVERY FULL 
GO
ALTER DATABASE [OICAR] SET  MULTI_USER 
GO
ALTER DATABASE [OICAR] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OICAR] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OICAR] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OICAR] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OICAR] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'OICAR', N'ON'
GO
ALTER DATABASE [OICAR] SET QUERY_STORE = OFF
GO
USE [OICAR]
GO
/****** Object:  UserDefinedTableType [dbo].[BasicCDT]    Script Date: 19/06/2020 17:25:03 ******/
CREATE TYPE [dbo].[BasicCDT] AS TABLE(
	[EatingHabit] [nvarchar](50) NULL,
	[CategoryName] [nvarchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[EatingHabbit]    Script Date: 19/06/2020 17:25:03 ******/
CREATE TYPE [dbo].[EatingHabbit] AS TABLE(
	[EatingHabit] [nvarchar](50) NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[IDHabits]    Script Date: 19/06/2020 17:25:03 ******/
CREATE TYPE [dbo].[IDHabits] AS TABLE(
	[ID] [int] NULL
)
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 19/06/2020 17:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[IDCustomer] [int] NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Gender] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomersHabit]    Script Date: 19/06/2020 17:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomersHabit](
	[EatingHabitID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EatingHabitID] ASC,
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EatingHabit]    Script Date: 19/06/2020 17:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EatingHabit](
	[IDEatingHabit] [int] IDENTITY(1,1) NOT NULL,
	[EatingHabit] [nvarchar](50) NOT NULL,
	[EatingHabitCategoryID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDEatingHabit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_UniqueHabbit] UNIQUE NONCLUSTERED 
(
	[EatingHabit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EatingHabitCategory]    Script Date: 19/06/2020 17:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EatingHabitCategory](
	[IDEatingHabitCategory] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDEatingHabitCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CustomersHabit]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([IDCustomer])
GO
ALTER TABLE [dbo].[CustomersHabit]  WITH CHECK ADD FOREIGN KEY([EatingHabitID])
REFERENCES [dbo].[EatingHabit] ([IDEatingHabit])
GO
ALTER TABLE [dbo].[EatingHabit]  WITH CHECK ADD FOREIGN KEY([EatingHabitCategoryID])
REFERENCES [dbo].[EatingHabitCategory] ([IDEatingHabitCategory])
GO
/****** Object:  StoredProcedure [dbo].[AddCustomer]    Script Date: 19/06/2020 17:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---AddCustomer
CREATE proc [dbo].[AddCustomer]
		@ID int,
		@FullName nvarchar(50)
as

INSERT INTO Customer (FullName,IDCustomer) VALUES (@FullName,@ID)

GO
/****** Object:  StoredProcedure [dbo].[AddCustomer2]    Script Date: 19/06/2020 17:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddCustomer2]
AS
    DECLARE @Ids AS TABLE (Id int);
    DECLARE @Vals BasicCDT;
    INSERT INTO @Vals ([EatingHabit], [CategoryName]) VALUES ('vegan','Eating habit'), ('gluten','Dislike'), ('pizza','Eating habit');

    INSERT INTO @Ids
    EXEC AddHabbits @Vals;

    -- should return three rows with the values 1, 2 and 3.    
    SELECT *
    FROM @Ids;

GO
/****** Object:  StoredProcedure [dbo].[AddCustomertest]    Script Date: 19/06/2020 17:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AddCustomertest]
		@customerHabbits BasicCDT readonly,	
		@Customer nvarchar(50),
		@Gender varchar(10)

as


--declare @CTest nvarchar(50)
--declare @CGender varchar(10)
--declare @CcustomerHabbits as BasicCDT 

--set @CTest ='Nikola'

--set @CGender ='M'

--insert into @CcustomerHabbits values ('Pizza','Favorite Food'),('Burgers','Favorite Food')

INSERT INTO Customer ([IDCustomer],FullName,[Gender]) VALUES (15,@Customer,@Gender)

--Declare @iD int=SCOPE_IDENTITY();

--INSERT INTO Customer ([IDCustomer],FullName,[Gender]) VALUES (14,@CTest,@CGender)


 exec sp_GetIDForHabits  @customerHabbits, 15
GO
/****** Object:  StoredProcedure [dbo].[AddHabbits]    Script Date: 19/06/2020 17:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddHabbits] 
@Values dbo.BasicCDT READONLY
AS

declare @UniqueEatingHabits as BasicCDT

insert into @UniqueEatingHabits
exec GetUnique @Values



    INSERT   INTO EatingHabit([EatingHabit], [EatingHabitCategoryID])
    --OUTPUT INSERTED.IDEatingHabit
   select a.EatingHabit, EatingHabitCategory.IDEatingHabitCategory from EatingHabitCategory 
	inner join @UniqueEatingHabits as a on EatingHabitCategory.CategoryName=a.CategoryName 
GO
/****** Object:  StoredProcedure [dbo].[GetUnique]    Script Date: 19/06/2020 17:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetUnique]
@Values dbo.BasicCDT READONLY
as


SELECT EatingHabit ,CategoryName
FROM   @Values l 
WHERE  NOT EXISTS (
   SELECT  *
   FROM   EatingHabit
   WHERE  EatingHabit = l.EatingHabit
   );
GO
/****** Object:  StoredProcedure [dbo].[sp_GetIDForHabits]    Script Date: 19/06/2020 17:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_GetIDForHabits]
	@Vals dbo.BasicCDT READONLY,
	@IDCustomer int
AS
BEGIN

DECLARE @HabitsIds AS TABLE (IdHabit int);

--INSERT INTO @HabitsIds
 EXEC AddHabbits @Vals;

 insert into @HabitsIds
 select IDEatingHabit from EatingHabit
 inner join @Vals as s on s.EatingHabit=EatingHabit.EatingHabit;

 --select * from @HabitsIds


---//CTE//
	
	With CTE_CustomerHabit	(IdHabit,idCustomer)
as
(
select IdHabit,@IDCustomer from @HabitsIds

)


insert into CustomersHabit select * from CTE_CustomerHabit


--    DECLARE @HabitsIds AS TABLE (IdHabit int);
--	Declare @CustomersHabitVals AS TABLE (IdHabbit int,IdCustomer int);
--	declare @idCustomer  AS TABLE (IdCustomer int);
	

--	insert into @HabitsIds values(1),(2)

--	  --INSERT INTO @HabitsIds
--   -- EXEC AddHabbits @Vals;

--	DECLARE @cnt INT = 0;
--	DECLARE @times int

--	SELECT @times = COUNT(*)
--FROM @HabitsIds

--WHILE @cnt < @times
--BEGIN
--   insert into @idCustomer values(1)

--   SET @cnt = @cnt + 1;
--END;



----select A.IdCustomer,B.IdHabit 
----from(
----    SELECT IdCustomer,row_number() over (order by IdCustomer) as row_num
----    FROM @idCustomer)A
----join
----    (SELECT IdHabit,row_number() over (order by IdHabit) as row_num
----    FROM @HabitsIds)B
----on  A.row_num=B.row_num





----select * from @idCustomer

-- insert into @CustomersHabitVals select B.IdHabit,A.IdCustomer 
--from(
--    SELECT IdCustomer,row_number() over (order by IdCustomer) as row_num
--    FROM @idCustomer)A
--join
--    (SELECT IdHabit,row_number() over (order by IdHabit) as row_num
--    FROM @HabitsIds)B
--on  A.row_num=B.row_num

-- --select * from @CustomersHabitVals

-- insert into CustomersHabit select * from @CustomersHabitVals


--    -- should return three rows with the values 1, 2 and 3.    
  
  END

GO
/****** Object:  StoredProcedure [dbo].[stp_TestOutputClauseInsert]    Script Date: 19/06/2020 17:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_TestOutputClauseInsert]
(@Values dbo.BasicCDT READONLY)
AS
  INSERT INTO EatingHabit([EatingHabit], [EatingHabitCategoryID])
    OUTPUT INSERTED.IDEatingHabit
    SELECT EatingHabit,(select IDEatingHabitCategory from EatingHabitCategory where CategoryName=CategoryName)
    FROM @Values;

GO
/****** Object:  StoredProcedure [dbo].[temp]    Script Date: 19/06/2020 17:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[temp]

as
Declare @table as TAble (name nvarchar(50))

insert into @table values('nista'),('nista2');


SELECT EatingHabit.IDEatingHabit
FROM EatingHabit
INNER JOIN @table as t ON EatingHabit.EatingHabit=t.name;

select * from EatingHabit where EatingHabit.EatingHabit =(select * from @table)
GO
/****** Object:  StoredProcedure [dbo].[TestOne]    Script Date: 19/06/2020 17:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[TestOne] 

@HabbitList dbo.EatingHabbit READONLY
AS
BEGIN
insert into EatingHabits([EatingHabit])select
[EatingHabit] from @HabbitList;

END
GO
USE [master]
GO
ALTER DATABASE [OICAR] SET  READ_WRITE 
GO
