IF OBJECT_ID('dbo.USERPASSWORD') IS NOT NULL DROP TABLE dbo.USERPASSWORD;
IF OBJECT_ID('dbo.USERSESSION') IS NOT NULL DROP TABLE dbo.USERSESSION;
IF OBJECT_ID('dbo.ENDUSER') IS NOT NULL DROP TABLE dbo.ENDUSER;
IF OBJECT_ID('dbo.userLoginCount') IS NOT NULL DROP VIEW dbo.userLoginCount;
IF OBJECT_ID('dbo.passwordChange') IS NOT NULL DROP TRIGGER passwordChange;

CREATE TABLE ENDUSER (
userID INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY,
user_fName VARCHAR(25) NOT NULL,
user_lName VARCHAR(25) NOT NULL,
user_email VARCHAR(1000) NOT NULL
);

CREATE TABLE USERPASSWORD (
passwordID INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY,
userID INTEGER NOT NULL,
password_old VARCHAR(25),
password_new VARCHAR(25) NOT NULL,
password_dateChanged DATETIME NOT NULL,
CONSTRAINT fk1_password FOREIGN KEY (userID) REFERENCES dbo.ENDUSER(userID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE USERSESSION (
sessionID INTEGER NOT NULL IDENTITY (1,1) PRIMARY KEY,
userID INTEGER NOT NULL,
session_date DATETIME NOT NULL,
session_status BIT,
session_token VARCHAR(128),
CONSTRAINT fk1_session FOREIGN KEY (userID) REFERENCES dbo.ENDUSER(userID) ON UPDATE CASCADE ON DELETE CASCADE
);