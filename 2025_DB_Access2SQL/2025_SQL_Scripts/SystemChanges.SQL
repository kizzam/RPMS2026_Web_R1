CREATE TABLE [SystemChanges] 
(   [SysChgID] COUNTER,
   [SysDBVer] TEXT(12),
   [SysAppVer] TEXT(12),
   [SysDBVerPrev] TEXT(12),
   [SysAppVerPrev] TEXT(12),
   [SysTableName] TEXT(18),
   [SysColName] TEXT(18),
   [SysActivity] TEXT(12),
   [SysFieldType] TEXT(18),
   [Notes] TEXT(72),
   [DateCreate] DATETIME 

)
