USE EmployeePayrollService;

Select * from EmployeePayroll;

CREATE FUNCTION dbo.CalculateDeduction(@Salary decimal(10,2))
RETURNS decimal(10,2)
AS
BEGIN
    DECLARE @Deduction decimal(10,2) = @Salary * 0.2;
    RETURN @Deduction;
END

CREATE FUNCTION dbo.CalculateTaxablePay(@Salary decimal(10,2))
RETURNS decimal(10,2)
AS
BEGIN
    DECLARE @Deduction decimal(10,2) = dbo.CalculateDeduction(@Salary);
    DECLARE @TaxablePay decimal(10,2) = @Salary - @Deduction;
    RETURN @TaxablePay;
END

CREATE FUNCTION dbo.CalculateIncomeTax(@Salary decimal(10,2))
RETURNS decimal(10,2)
AS
BEGIN
    DECLARE @TaxablePay decimal(10,2) = dbo.CalculateTaxablePay(@Salary);
    DECLARE @IncomeTax decimal(10,2) = @TaxablePay * 0.1;
    RETURN @IncomeTax;
END

CREATE FUNCTION dbo.CalculateNetPay(@Salary decimal(10,2))
RETURNS decimal(10,2)
AS
BEGIN
    DECLARE @IncomeTax decimal(10,2) = dbo.CalculateIncomeTax(@Salary);
    DECLARE @NetPay decimal(10,2) = @Salary - @IncomeTax;
    RETURN @NetPay;
END

ALTER PROCEDURE AlterEmployeePayroll
AS
BEGIN
    ALTER TABLE EmployeePayroll
    ADD Deduction AS dbo.CalculateDeduction(Salary),
        Taxable_Pay AS dbo.CalculateTaxablePay(Salary),
        Income_Tax AS dbo.CalculateIncomeTax(Salary),
        Net_Pay AS dbo.CalculateNetPay(Salary);
END

CREATE PROCEDURE CreateDepartmentTable
AS
BEGIN
    CREATE TABLE Department (
        Dept_ID INT IDENTITY(1,1) PRIMARY KEY,
        Dept_Name NVARCHAR(255) NOT NULL UNIQUE
    );
END

CREATE PROCEDURE AlterEmployeePayrollWithDeptID
AS
BEGIN
    ALTER TABLE EmployeePayroll
    ADD Dept_ID INT;

    ALTER TABLE EmployeePayroll
    ADD CONSTRAINT FK_Dept_ID FOREIGN KEY (Dept_ID) REFERENCES Department(Dept_ID);
END

select * from Department;

