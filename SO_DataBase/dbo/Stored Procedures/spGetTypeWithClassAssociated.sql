CREATE PROCEDURE [dbo].[spGetTypeWithClassAssociated]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT t.Id,t.[Type],c.Class AS ClassType
	FROM dbo.ProductType t,dbo.ProductClass c
	WHERE t.Class_Id = c.Id
	ORDER BY c.Class ASC 
END
