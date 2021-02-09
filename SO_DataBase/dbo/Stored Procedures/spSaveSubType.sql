CREATE PROCEDURE [dbo].[spSaveSubType]
	@subTypeName nvarchar(50),
	@generalType_Id int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.SubType(SubTypeName,GeneralType_Id)
	VALUES(@subTypeName,@generalType_Id);
END
