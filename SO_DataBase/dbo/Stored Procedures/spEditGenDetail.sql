CREATE PROCEDURE [dbo].[spEditGenDetail]
	@id int,
	@brand_Id int,
	@gen_Id int,
	@sub_Id int
AS
BEGIN
	SET  NOCOUNT ON;

	UPDATE GeneralDetails
	SET Brand_Id = @brand_Id,GeneralType_Id = @gen_Id,SubType_Id = @sub_Id
	WHERE Id = @id;
END
