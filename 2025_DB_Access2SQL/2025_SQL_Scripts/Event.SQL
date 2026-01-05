CREATE TABLE [Event] 
(   [EventID] COUNTER,
   [EventDesc] TEXT(72),
   [EventDate] DATETIME,
   [DrugID] INTEGER,
   [DateFrom] DATETIME,
   [DateTo] DATETIME,
   [DosageRate] TEXT(72),
   [Notes] TEXT(144),
   [NoteID] INTEGER,
   [EventStatus] TEXT(1),
   [EventType] TEXT(18),
   [System] TEXT(1),
   [DateCreate] DATETIME 

)
