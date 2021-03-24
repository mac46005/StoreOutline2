CREATE PROCEDURE [dbo].[spSaveGenDetail]
	@brand_Id int,
	@genType_Id int,
	@subType_Id int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO GeneralDetails(Brand_Id,GeneralType_Id,SubType_Id)
	VALUES(@brand_Id,@genType_Id,@subType_Id);
END
