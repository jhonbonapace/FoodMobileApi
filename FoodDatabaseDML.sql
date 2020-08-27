
CREATE DATABASE FoodDatabase;
USE FoodDatabase;

CREATE TABLE `User` (
  `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Name` VARCHAR(250) NOT NULL,
  `Email` VARCHAR(100) NOT NULL,
  `Identity` VARCHAR(14),
  `Telephone` VARCHAR(20),
  `BirthDate` DATETIME(6),
  `Gender` CHAR(1),
  `Thumbnail` BLOB,
  `UserType` INT NOT NULL,
  `FailedAttempts` INT NOT NULL,
  `PasswordHash` VARCHAR(200) NOT NULL,
  `PasswordSalt` VARCHAR(200) NOT NULL,
  `CreateDate` DATETIME DEFAULT current_timestamp,
  `UpdateDate` DATETIME,
  `Deleted` BIT DEFAULT 0,
  `IP` VARCHAR(45)
  );
  
  CREATE TABLE `Country` (
  `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Name` VARCHAR(200) NOT NULL,
  `Name_PT` VARCHAR(200),
  `Initials` VARCHAR(10),
  `Bacen` VARCHAR(20)
);

CREATE TABLE `State` (
  `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Name` VARCHAR(200) NOT NULL,
  `IdCountry` INT NOT NULL REFERENCES `Country` (Id),
  `IBGECode` VARCHAR(10),
  `Initials` CHAR(2),
  `NumberCode` VARCHAR(10)
);

CREATE TABLE `City` (
  `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Name` VARCHAR(200) NOT NULL,
  `IdState` INT NOT NULL REFERENCES `State` (Id),
  `IBGECode` VARCHAR(10)
);

  CREATE TABLE `Address` (
  `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Street` VARCHAR(250),
  `Number` VARCHAR(10),
  `District` VARCHAR(250),
  `Complement` VARCHAR(250),
  `ZipCode` VARCHAR(10),
  `Latitude` double,
  `Longitude` double,
  `IdCountry` INT REFERENCES `Country` (Id),
  `IdState` INT REFERENCES `State` (Id),
  `IdCity` INT REFERENCES `City` (Id)
);

 CREATE TABLE `Facility` (
  `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Description` VARCHAR(100) NOT NULL,
  `Code` INT NOT NULL
  );
  
  CREATE TABLE `PaymentMethod` (
  `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Description` VARCHAR(100) NOT NULL,
  `Code` INT NOT NULL
  );
  
  CREATE TABLE `Tags` (
  `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Description` VARCHAR(100) NOT NULL,
  `Code` INT NOT NULL
  );

  CREATE TABLE `Customer` (
  `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Name` VARCHAR(250) NOT NULL,
  `Description` VARCHAR(1000),
  `BookingNote` VARCHAR(300),
  `Specialty` VARCHAR(300),
  `Thumbnail` BLOB,
  `ReservationMaxPartySize` INT,
  `ReservationMinPartySize` INT,
  `IdUser` INT NOT NULL REFERENCES `user` (Id),
  `IdAddress` INT REFERENCES `address` (Id),
  `IdNacionalitySpecialty` INT REFERENCES `Country` (Id),
  `LastUpdate` DATETIME
  );
  
  CREATE TABLE `CustomerFacilities`(
   `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
   `IdFacility` INT NOT NULL REFERENCES `Facility` (Id),
   `IdCustomer` INT NOT NULL REFERENCES `Customer` (Id),
   `IsActive` BIT DEFAULT 0 NOT NULL,
   `Description` VARCHAR(200)
  );
  
   CREATE TABLE `CustomerPaymentMethods`(
   `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
   `IdPaymentMethod` INT NOT NULL REFERENCES `PaymentMethod` (Id),
   `IdCustomer` INT NOT NULL REFERENCES `Customer` (Id)
  );
  
  CREATE TABLE `CustomerTags`(
   `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
   `IdTags` INT NOT NULL REFERENCES `Tags` (Id),
   `IdCustomer` INT NOT NULL REFERENCES `Customer` (Id)
  );
  CREATE TABLE `Contacts`(
   `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
   `IdCustomer` INT NOT NULL REFERENCES `Customer` (Id),
   `ContactyType` INT NOT NULL,
   `Description` VARCHAR(500) NOT NULL
  );
  
   CREATE TABLE `ProductCategory`(
   `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
   `IdCustomer` INT NOT NULL REFERENCES `Customer` (Id),
   `Name` VARCHAR(100) NOT NULL,
   `Description` VARCHAR(500) NOT NULL,
   `IsExcluded` BIT DEFAULT 0
  );
  
   CREATE TABLE `Product`(
   `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
   `Name` VARCHAR(100) NOT NULL,
   `Description` VARCHAR(500) NOT NULL,
   `Price` DECIMAL(10,2),
   `IsPriceless` BIT,
   `IdProductCategory` INT NOT NULL REFERENCES `ProductCategory` (Id),
   `ImagePath` VARCHAR(500),
   `Deleted` BIT DEFAULT 0
  );
  
  CREATE TABLE `CustomerProfilePictures`(
   `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
   `Name` VARCHAR(100) NOT NULL,
   `Size` DECIMAL,
   `ImagePath` VARCHAR(500) NOT NULL,
   `IdCustomer` INT NOT NULL REFERENCES `Customer` (Id)
  );
  
  CREATE TABLE `UserCommentaries` (
  `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Rating` DECIMAL(10,2),
  `Text` longtext,
  `Date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `IdCustomer` INT NOT NULL REFERENCES `Customer` (Id),
  `IdUser` INT NOT NULL REFERENCES `User` (Id)
  );
  
  CREATE TABLE `CustomerWorkDays`(
   `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
   `WeekDay` INT NOT NULL,
   `TimeOpen` TIMESTAMP,
   `TimeClose` TIMESTAMP,
   `IdCustomer` INT NOT NULL REFERENCES `Customer` (Id)
  );
  
  CREATE TABLE `CustomerWorkDaysTimeOff`(
   `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
   `TimeStart` TIMESTAMP,
   `TimeEnd` TIMESTAMP,
   `IdCustomerWorkDays` INT NOT NULL REFERENCES `CustomerWorkDays` (Id)
  );
  
  CREATE TABLE `Booking`(
   `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
   `ReservationCode` VARCHAR(50) NOT NULL,
   `Date` DATE NOT NULL,
   `GuestQuantity` INT DEFAULT 1,
   `Deleted` BIT DEFAULT 0,
   `Request` VARCHAR(200),
   `CreatedOn` datetime NOT NULL DEFAULT current_timestamp,
   `IdCustomer` INT NOT NULL REFERENCES `Customer` (Id),
   `IdUser` INT NOT NULL REFERENCES `User` (Id),
   `IdComment` INT REFERENCES `UserCommentaries` (Id)
  );
  
  
  CREATE TABLE `UserFavoriteCustomers`(
   `IdCustomer` INT NOT NULL REFERENCES `Customer` (Id),
   `IdUser` INT NOT NULL REFERENCES `User` (Id)
  );