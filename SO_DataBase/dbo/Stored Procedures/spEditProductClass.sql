CREATE PROCEDURE [dbo].[spEditProductClass]
	@id int,
	@class NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.ProductClass
	SET Class = @class
	WHERE Id = @id
END
