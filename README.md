# Hotel_Transylvania

App för att administrera rum, reservationer och gäster.

FELHANTERING & SPECTRE
- Guest
[•] Deactivate
[•] Reactivate
[•] Register 
[•] Update
- Room
[•] Deactivate
[•] Reactivate
[•] Register 
[•] Update

- Reservation
[•] Add
[•] Deactivate
[•] Update

## KRAV
[•] (C) Lägg till en ny entitet
[•] (R) Se en list över de befintliga entiteter som finns i databasen
[•] (U) Uppdatera en befintlig entitet
[•] (D) Radera en befintlig entitet
[•] Kommunikationen med databasen skall ske med Entity Framework Core. 
[•] Code First inclusive appsettings.json
[•] Databas i MS-SQL Server.

ROOM
[•] Det skall gå att registrera ett rum och rummets uppgifter skall kunna ändras. 
[•] Applikationen skall hantera ett antal rum. 
[•] Ett rum ska kunna vara enkelrum eller dubbelrum.
[•] För dubbelrum ska det finnas möjlighet till att sätta in extrasängar (1 eller 2 beroende på rummets storlek).

GUEST
[•] Det skall gå att registrera en kund och kundens uppgifter skall kunna ändras. 
[•] Seed minst 4 rum
[•] Seed minst 4 gäster

RESERVATION
[•] Användaren måste välja datum då rummet ska bokas.
[•] Ett rum kan bokas av en kund för en eller flera nätter. 


Redovisning: Totalt finns det 5 saker som ska lämnas in:
1.[•] (G) ER Diagram över din database
2.[-] (VG) Ett dokument som beskriver hur du följt 3NF i dina tabeller
3.[•] (G) En .sql fil med dina SQL Select osv. syntaxer
4.[•] (VG) En .sql fil med dina SQL Join osv. syntaxer
5.[•] (G) En .NET Core console Hotell app
