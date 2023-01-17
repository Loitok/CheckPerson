
SELECT TOP(3) 
	(SELECT COUNT(*) FROM Ticket 
		WHERE Client.ClientId = Ticket.ClientId) 
		AS ClientOrders, 
		FirstName,
		LastName,
		Gender,
		DateOfBirth
	FROM Client
	ORDER BY ClientOrders DESC