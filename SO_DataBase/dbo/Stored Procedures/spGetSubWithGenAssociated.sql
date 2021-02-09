CREATE PROCEDURE [dbo].[spGetSubType_ByGeneralType]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT s.Id,s.SubTypeName,g.TypeName
	FROM dbo.SubType s,dbo.GeneralType g
	WHERE s.GeneralType_Id = g.Id
	ORDER BY g.TypeName ASC 
END
