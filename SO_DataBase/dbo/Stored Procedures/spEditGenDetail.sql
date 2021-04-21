CREATE PROCEDURE [dbo].[spEditGenDetail]
	@id int,
	@brand_Id int,
	@class_Id int,
	@type_Id int
AS
BEGIN
	SET  NOCOUNT ON;

	UPDATE GeneralDetails
	SET Brand_Id = @brand_Id, Class_Id = @class_Id, Type_Id = @type_Id
	WHERE Id = @id;
END
