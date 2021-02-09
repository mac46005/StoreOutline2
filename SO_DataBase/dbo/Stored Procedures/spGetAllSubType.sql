CREATE PROCEDURE [dbo].[spGetAllSubType]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id,SubTypeName,GeneralType_Id
	FROM dbo.SubType
END
