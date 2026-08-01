Create Database mycalculator;
use mycalculator;
CREATE TABLE Addition (
    AdditionID INT PRIMARY KEY IDENTITY(1,1),
    Operand1 DECIMAL(18, 2) NOT NULL,
    Operand2 DECIMAL(18, 2) NOT NULL,
    Result DECIMAL(18, 2) NOT NULL,
);
CREATE TABLE Subtraction (
    SubtractionID INT PRIMARY KEY IDENTITY(1,1),
    Operand1 DECIMAL(18, 2) NOT NULL,
    Operand2 DECIMAL(18, 2) NOT NULL,
    Result DECIMAL(18, 2) NOT NULL,
);

CREATE TABLE Multiplication (
    MultiplicationID INT PRIMARY KEY IDENTITY(1,1),
    Operand1 DECIMAL(18, 2) NOT NULL,
    Operand2 DECIMAL(18, 2) NOT NULL,
    Result DECIMAL(18, 2) NOT NULL,
);

CREATE TABLE Division (
    DivID INT PRIMARY KEY IDENTITY(1,1),
    Operand1 DECIMAL(18, 2) NOT NULL,
    Operand2 DECIMAL(18, 2) NOT NULL,
    Result DECIMAL(18, 2) NOT NULL,
   
);
CREATE TABLE SquareRoot (
    SqrtID INT PRIMARY KEY IDENTITY(1,1),
    Operand DECIMAL(18, 2) NOT NULL,
    Result DECIMAL(18, 2) NOT NULL,
    
);

CREATE TABLE Sqr (
    SqrID INT PRIMARY KEY IDENTITY(1,1),
    Operand DECIMAL(18, 2) NOT NULL,
    Result DECIMAL(18, 2) NOT NULL,
    
);



select *from Sqr;
select *from SquareRoot;
select *from Division;
select *from Multiplication;
select *from Subtraction;
select *from Addition;


insert into Addition (Operand1 , Operand2 , Result) values ('1' , '2' , '3');
insert into Subtraction (Operand1 , Operand2 , Result) values ('4' , '2' , '2');

update Addition set Operand1 = 4 , Result = 4 + Operand2  where AdditionID = 3;
delete from SquareRoot where SqrtID = 2;