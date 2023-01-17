SELECT Ticket.*, 
	FirstName,
	LastName,
	Gender,
	Address,
	DateOfBirth,
	Email
FROM Ticket
LEFT JOIN Client ON Ticket.ClientId=Client.ClientId;
