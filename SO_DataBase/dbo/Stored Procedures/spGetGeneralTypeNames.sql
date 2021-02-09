CREATE PROCEDURE [dbo].[spGetGeneralTypeNames]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TypeName
	FROM dbo.GeneralType
END
