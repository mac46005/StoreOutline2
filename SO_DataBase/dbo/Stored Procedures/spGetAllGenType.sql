CREATE PROCEDURE [dbo].[spGetAllGenType]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id,TypeName
	FROM dbo.GeneralType;
END
