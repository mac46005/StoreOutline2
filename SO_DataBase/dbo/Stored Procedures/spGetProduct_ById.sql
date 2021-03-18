CREATE PROCEDURE [dbo].[spGetProduct_ById]
		@id int
AS
	SELECT *
	FROM Products
	WHERE Id = @id
RETURN 0
