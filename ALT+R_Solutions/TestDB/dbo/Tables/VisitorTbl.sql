CREATE TABLE [dbo].[VisitorTbl]
(
	[VisitorID] INT NOT NULL constraint PK_VisitorTbl PRIMARY KEY,
	[FirstName] nvarchar(150) not null,
	[LastName] nvarchar(150) not null,
	[Gender] nvarchar(7) not null constraint Check_VisitorTbl check([Gender]='Male' or [Gender]='Female'),
	[VisitorType] nvarchar(10) not null,
	[DateOfVisit] datetime2 not null default getutcdate(),
	[MonthlyVisits] int not null default 0,
	[PrisonerID] int not null constraint Vistors_To_Prisoner foreign key ([PrisonerID]) references PrisonerTbl([PrisonerID]) 

)
