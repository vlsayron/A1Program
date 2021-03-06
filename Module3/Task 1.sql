-- Task 1.1.1
SELECT Orders.OrderID, Orders.ShippedDate, Orders.ShipVia
FROM Orders
WHERE ShippedDate >= '1998-05-06' AND ShipVia >= 2

-- Task 1.1.2
SELECT OrderID, ShippedDate = 
CASE
	WHEN ShippedDate IS NULL then 'Not Shipped'
END
FROM Orders
WHERE ShippedDate IS NULL

-- Task 1.1.3
SELECT OrderID AS [Order Number]  , [Shipped Date] =
CASE
	WHEN ShippedDate IS NULL THEN 'Not Shipped' 
	ELSE CONVERT ( varchar , ShippedDate , 25 ) 
END
FROM Orders
WHERE ShippedDate >= '1998-05-06 00:00:00.000' OR ShippedDate IS NULL -- condition for testing all situations
-- WHERE ShippedDate >= '1998-05-07 00:00:00.000' OR ShippedDate IS NULL -- conditions for task
-- According to the terms of the task, we don't have orders to check all conditions. Because there are no completed orders after 06-05-1998

-- Task 1.2.1
SELECT ContactName AS [Name], Country
FROM Customers
WHERE Country in ('USA', 'Canada')
ORDER BY Country, ContactName 

-- Task 1.2.2
SELECT ContactName AS [Name], Country
FROM Customers
WHERE Country not in ('USA', 'Canada')
ORDER BY ContactName

-- Task 1.2.3
 SELECT DISTINCT Country
 FROM Customers
 ORDER BY Country DESC

-- Task 1.3.1
SELECT DISTINCT OrderID
FROM [Order Details]
WHERE Quantity BETWEEN 3 AND 10

-- Task 1.3.2
SELECT CustomerID, Country
FROM Customers
WHERE Country between 'b%' AND 'h%' 
ORDER BY Country

-- Task 1.3.3
SELECT CustomerID, Country
FROM Customers
WHERE Country LIKE '[b-g]%'

-- Task 1.4.1
SELECT ProductName
FROM Products
WHERE ProductName LIKE '%cho_olate%'
