CREATE TABLE [dbo].[PrisonerTbl]
(
	[PrisonerID] INT NOT NULL constraint PK_PrisonerTBL PRIMARY KEY,
	[FirstName] nvarchar(150) not null,
	[LastName] nvarchar(150) not null
)
