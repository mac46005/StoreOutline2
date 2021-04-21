CREATE PROCEDURE [dbo].[spSaveGenDetail]
	@brand_Id int,
	@productClass_Id int,
	@productType_Id int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO GeneralDetails(Brand_Id,Class_Id,[Type_Id])
	VALUES(@brand_Id,@productClass_Id,@productType_Id);
END
