-- Task 2.1.1 
SELECT SUM((UnitPrice - (UnitPrice * Discount)) * Quantity) AS Totals
FROM [Order Details]

-- Task 2.1.2 
SELECT (COUNT(*) - COUNT(ShippedDate)) AS [Not Shipped Yet]
FROM Orders

-- Task 2.1.3 
SELECT COUNT(DISTINCT CustomerID) AS [Customers who made orders]
FROM Orders

-- Task 2.2.1 
SELECT YEAR(OrderDate) AS [Year], COUNT(YEAR(OrderDate)) AS [Total]
FROM Orders
GROUP BY YEAR(OrderDate) 
ORDER BY YEAR(OrderDate) ASC

SELECT COUNT(OrderDate) AS [Total Orders]
FROM Orders

-- Task 2.2.2 
SELECT CONCAT (Employees.LastName + ' ', Employees.FirstName) AS [Seller], COUNT(OrderDate) AS [Amount]
FROM Orders
INNER JOIN Employees
ON Orders.EmployeeID = Employees.EmployeeID
GROUP BY Employees.LastName, Employees.FirstName, Orders.EmployeeID
ORDER BY [Amount] DESC

-- Task 2.2.3
SELECT Employees.FirstName + ' ' + Employees.LastName AS [Seller], Orders.CustomerID, COUNT(Orders.OrderID) AS [Count]
FROM Orders
INNER JOIN Employees
ON Orders.EmployeeID = Employees.EmployeeID AND YEAR(Orders.OrderDate) = 1998
GROUP BY Employees.FirstName, Employees.LastName, Orders.CustomerID

-- Task 2.2.4
SELECT Customers.ContactName, Employees.FirstName + ' ' + Employees.LastName AS [Seller]
FROM Customers, Employees
WHERE Customers.City = Employees.City

-- Task 2.2.5
SELECT Customers.City, P.[Customers count], Customers.ContactName AS [Customer name]
FROM
	(SELECT City, COUNT(*) AS [Customers count] FROM Customers
	GROUP BY City
	HAVING COUNT(*) > 1) AS P
JOIN Customers ON P.City = Customers.City

-- Task 2.2.6
SELECT  E.FirstName + ' ' + E.LastName AS Employee, M.FirstName + ' ' + M.LastName AS Manager
FROM Employees E
LEFT JOIN Employees M
ON E.ReportsTo = M.EmployeeID

-- Task 2.3.1 
SELECT emp.FirstName + ' ' + emp.LastName AS [Name], reg.RegionDescription as [Region]
from Employees as emp
INNER JOIN Region as reg
ON LEFT(emp.Region, 1) = LEFT(reg.RegionDescription, 1)
--Not sure if the condition is correct or that I understood it correctly.
--I assumed that the Region row in the Employees table is short for RegionDescription. 
--And the first letter of the region will be the same for all regions

-- Task 2.3.2 
SELECT Customers.CompanyName AS [Customer Name], COUNT(Orders.OrderID) AS [Count of orders]
FROM Customers
LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.CompanyName
ORDER BY [Count of orders]

-- Task 2.4.1
SELECT CompanyName
FROM Suppliers
WHERE Suppliers.SupplierID IN (SELECT SupplierID FROM Products WHERE UnitsInStock = 0)

-- Task 2.4.2
SELECT emp.FirstName, COUNT(ord.OrderID) AS [Number of Orders]
FROM Employees AS emp
INNER JOIN Orders AS ord
ON ord.EmployeeID = emp.EmployeeID
GROUP BY emp.FirstName
HAVING COUNT(ord.OrderID) IN (SELECT COUNT(ord.OrderID) FROM Orders WHERE COUNT(ord.OrderID) > 150)

-- Task 2.4.3
SELECT Customers.CustomerID, Customers.ContactName 
FROM Orders RIGHT JOIN Customers on orders.CustomerID = Customers.CustomerID
WHERE NOT EXISTS(SELECT * FROM Customers WHERE Customers.CustomerID= Orders.CustomerID)
