Create DataBase TravelDB;

use TravelDB

select * from UserInfo

Create Table UserInfo(
UserId int Identity (1,1) Primary Key,
FullName varchar(200) Not Null,
Email varchar(100) Not Null,
Password varchar(100) Not Null,
MobileNumber bigint
);


Select * From UserInfo
-- Stored Procedure For User Registration --
Create Procedure spUserRegister
(
@FullName varchar(200),
@Email varchar(100),
@Password varchar(100),
@MobileNumber bigint
)
As
Begin
	Insert UserInfo
	Values (@FullName, @Email, @Password, @MobileNumber)
End;