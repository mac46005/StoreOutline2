CREATE PROCEDURE [dbo].[spGetSubType_ByGeneralType]
	@genTypeId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT g.Id,g.TypeName,s.Id,s.SubTypeName
	FROM dbo.GeneralType g,dbo.SubType s
	WHERE g.Id = @genTypeId AND s.GeneralType_Id = @genTypeId
END
