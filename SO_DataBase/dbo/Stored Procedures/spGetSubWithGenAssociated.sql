CREATE PROCEDURE [dbo].[spGetSubWithGenAssociated]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT s.Id,s.SubTypeName,g.TypeName AS GeneralType
	FROM dbo.SubType s,dbo.GeneralType g
	WHERE s.GeneralType_Id = g.Id
	ORDER BY g.TypeName ASC 
END
