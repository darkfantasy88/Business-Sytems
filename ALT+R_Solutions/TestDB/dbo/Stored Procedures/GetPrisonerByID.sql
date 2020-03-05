CREATE PROCEDURE [dbo].[GetPrisonerByID]
	@ID int

AS
begin
set nocount on;
	SELECT * from dbo.PrisonerTbl where ID=@ID;

end