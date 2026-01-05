CREATE TABLE [Matings] 
(   [ID] COUNTER,
   [Code] TEXT(5),
   [Rating] INTEGER,
   [RatingPerf] INTEGER,
   [RatingBloodLine] INTEGER,
   [RatingCustom] INTEGER,
   [StsSystem] TEXT(1),
   [StsMating] TEXT(1),
   [StsCurrent] TEXT(1),
   [StsCustom] TEXT(1),
   [SireYr] SMALLINT,
   [SireMark] TEXT(12),
   [SireRingNo] TEXT(8),
   [DamYr] SMALLINT,
   [DamMark] TEXT(12),
   [DamRingNo] TEXT(8),
   [Notes] MEMO 

)
