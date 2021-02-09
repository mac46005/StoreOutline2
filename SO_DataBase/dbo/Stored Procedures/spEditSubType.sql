CREATE PROCEDURE [dbo].[EditSubType]
	@id int,
	@subTypeName nvarchar(50),
	@generalType_Id int
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE dbo.SubType
	SET SubTypeName = @subTypeName,GeneralType_Id = @generalType_Id
	WHERE Id = @id
END
