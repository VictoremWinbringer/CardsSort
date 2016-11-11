
SELECT ProductId, COUNT(*) as firstPurchaseCount
FROM(
  SELECT ProductId, CustomerId, DateCreated, 
    MIN(DateCreated) OVER(PARTITION BY   CustomerId) as minDate
  FROM Sales
)as T
WHERE DateCreated = minDate
GROUP BY ProductId
