
SELECT ProductId, COUNT(*) as CountFirstPurchase
FROM(
  SELECT ProductId, CustomerId, DateCreated, 
    MIN(DateCreated) OVER(PARTITION BY   CustomerId) as MinDate
  FROM Sales
)as T
WHERE DateCreated = MinDate
GROUP BY ProductId
ORDER BY COUNT(*) 
