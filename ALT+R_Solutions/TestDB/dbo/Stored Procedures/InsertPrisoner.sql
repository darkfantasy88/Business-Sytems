CREATE PROCEDURE [dbo].[InsertPrisoner]
	@ID int,@FNAME nvarchar(150),@LNAME nvarchar(150)

AS
begin
set nocount on;
	insert into dbo.PrisonerTbl values(@ID,@FNAME,@LNAME);

end