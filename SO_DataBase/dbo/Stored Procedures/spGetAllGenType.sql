CREATE PROCEDURE [dbo].[spGetAllGenType]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TypeName
	FROM dbo.GeneralType;
END
