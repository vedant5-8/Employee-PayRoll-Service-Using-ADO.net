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

DROP FUNCTION IF EXISTS dbo.CalculateTaxablePay;

DROP FUNCTION IF EXISTS dbo.CalculateIncomeTax;

DROP PROCEDURE IF EXISTS AlterEmployeePayroll;