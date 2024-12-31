--1
SELECT
	Id AS [Guest Id],
	FirstName,
	Surname
FROM 
	Guests
WHERE
	IsGuestActive = 1
ORDER BY
	Surname asc;

--2
SELECT
	RoomNumber,
	RoomType,
	RoomSize
FROM
	Rooms
ORDER BY
	RoomSize asc;

--3
SELECT
	g.Id AS [Guest Id],
	FirstName,
	Surname,
	RoomNumber AS [Booked Room],
	CheckinDate,
	CheckoutDate
FROM 
	Guests g
	JOIN GuestReservation gr ON g.Id = gr.GuestsId
	JOIN Reservations r ON gr.ReservationsId = r.Id;

--4
SELECT SUM(NumberOfAdditionalBeds) AS [Extra beds in December]
FROM 
	Reservations
WHERE 
	CheckinDate >= '2024-12-01'
	AND	CheckinDate <= '2024-12-31';

--5
CREATE VIEW HasSantaClausReserved AS
SELECT 
	g.Surname,
	g.FirstName,
	g.Email,
	g.Phone,
	r.RoomNumber,
	r.CheckinDate,
	r.CheckoutDate,
	r.TimeOfReservation

FROM 
	Guests g
	JOIN GuestReservation gr ON g.Id = gr.GuestsId
	JOIN Reservations r ON gr.ReservationsId = r.Id
WHERE 
    EXISTS (
		SELECT 1 
		FROM Reservations r2 
		WHERE r2.Id = gr.ReservationsId AND r2.CheckinDate = '2025-12-24');

-- 6
SELECT *
FROM HasSantaClausReserved
