/* -- rollback
USE [master];
GO
ALTER DATABASE Accounts SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE Accounts;
GO
*/

--USE [master];
--GO
--CREATE DATABASE Accounts;
--GO
--DROP TABLE dbo.Contacts;
--DROP TABLE dbo.Accounts;
--DROP TABLE dbo.Roles;
--DROP TABLE dbo.OrganisationalUnits;

USE Accounts;
GO


CREATE TABLE dbo.Roles (
  RoleId INT IDENTITY NOT NULL PRIMARY KEY,
  [Name] VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE dbo.OrganisationalUnits (
  OrganisationalUnitId INT IDENTITY NOT NULL PRIMARY KEY,
  [Name] VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE dbo.Accounts (
  AccountId INT IDENTITY NOT NULL PRIMARY KEY,
  OrganisationalUnitId INT NOT NULL REFERENCES dbo.OrganisationalUnits (OrganisationalUnitId),
  [Name] VARCHAR(100) NOT NULL,
  [InvoiceMedium] VARCHAR(10) NOT NULL,
);

CREATE TABLE dbo.Contacts (
  ContactId INT IDENTITY NOT NULL PRIMARY KEY,
  AccountId INT NOT NULL REFERENCES dbo.Accounts (AccountId),
  FirstName VARCHAR(200) NOT NULL,
  LastName VARCHAR(200) NOT NULL,
  PhoneNumber VARCHAR(15) NULL,
  MobileNumber VARCHAR(15) NULL,
  EmailAddress VARCHAR(250) NOT NULL,
  RoleId INT NOT NULL REFERENCES dbo.Roles (RoleId)
);


SET IDENTITY_INSERT dbo.Roles ON;
INSERT INTO dbo.Roles
  (RoleId, [Name])
VALUES
  (1, 'Billing'),
  (2, 'Technical');
SET IDENTITY_INSERT dbo.Roles OFF; 

SET IDENTITY_INSERT dbo.OrganisationalUnits ON;
INSERT INTO dbo.OrganisationalUnits
  (OrganisationalUnitId, [Name])
VALUES
  (1, 'Business'),
  (2, 'Consumer'),
  (3, 'Wholesale');
SET IDENTITY_INSERT dbo.OrganisationalUnits OFF;

SET IDENTITY_INSERT dbo.Accounts ON;
INSERT INTO dbo.Accounts
  (Accountid, OrganisationalUnitId, [Name], InvoiceMedium)
VALUES
( 1, 2, 'Apple Inc.', 'Email');
SET IDENTITY_INSERT dbo.Accounts OFF;


INSERT INTO dbo.Contacts
  (AccountId, FirstName, LastName, PhoneNumber, MobileNumber, EmailAddress, RoleId)
VALUES
  (1, 'Steve', 'Jobs', NULL, NULL, 'steve.jobs@apple.com', 1);


