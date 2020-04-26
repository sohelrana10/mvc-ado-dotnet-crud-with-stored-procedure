CREATE DATABASE TESTDB
USE [TESTDB]
GO

CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [varchar](150) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[City] [varchar](150) NOT NULL,
	[EmailAddress] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

******* Storprocedure for data insert**************
Create proc [dbo].[SaveEmployee]  
@EmployeeName varchar(150),  
@Gender varchar(50),  
@City varchar(150),  
@EmailAddress varchar(50),
@PhoneNumber varchar(50) 
as  
begin  
	Insert Employee(EmployeeName,Gender,City,EmailAddress,PhoneNumber)
		values  
	(@EmployeeName, @Gender,@City,@EmailAddress,@PhoneNumber)  
end

***********Initial Data insert by Storprocedure***********

exec SaveEmployee 'Md.Sohel Rana','Male','Dhaka Bangladesh','sohel99r@gmail.com','+880151-6138841'
exec SaveEmployee 'Masud Rana','Male','Joypurhat Bangladesh','masud@gmail.com','+880173-6138841'
exec SaveEmployee 'Md. Shamim Reza','Male','Bogra Bangladesh','shamim@gmail.com','+880161-6138841'
exec SaveEmployee 'Md.Mominul Islam','Male','Bogra, Bangladesh','mominul@gmail.com','+880181-6138841'
exec SaveEmployee 'Md.Shakil Majumder Rana','Male','Putuakhali, Bangladesh','shakil@gmail.com','+880191-6138841'
exec SaveEmployee 'Most.Nilufar Yesmin','Female','Rajshahi, Bangladesh','nilufar@gmail.com','+880130-6138841'
exec SaveEmployee 'Lovsi Akter','Female','Rangpur, Bangladesh','lovesi@gmail.com','+880172-6138841'

************Storprocedure for all Employee get********************
Create proc [dbo].[getEmployee]
	as
		begin
			select * from Employee
		end

************Storprocedure for Employee Update ********************

Create proc [dbo].[UpdateEmployee]
@Id int,
@EmployeeName varchar(150),
@Gender varchar(50),
@City varchar(150),
@EmailAddress varchar(50),
@PhoneNumber varchar(50)
as
begin
Update Employee Set EmployeeName=@EmployeeName,Gender=@Gender,
City=@City,EmailAddress=@EmailAddress,PhoneNumber=@PhoneNumber Where Id=@Id
end
************Storprocedure for Employee Delete********************
Create proc [dbo].[DeleteEmployee]
@Id int
as
begin
Delete from Employee  Where Id=@Id
end