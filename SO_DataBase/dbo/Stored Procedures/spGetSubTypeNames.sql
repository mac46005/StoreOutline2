CREATE PROCEDURE [dbo].[spGetSubTypeNames]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT SubTypeName
	FROM dbo.SubType
END
