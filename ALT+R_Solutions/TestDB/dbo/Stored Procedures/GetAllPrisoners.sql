CREATE PROCEDURE [dbo].[GetAllPrisoners]

AS
begin
set nocount on;
	SELECT * from dbo.PrisonerTbl;
end;
