CREATE PROCEDURE [dbo].[spSaveGenType]
	@typeName NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.GeneralType(TypeName)
	VALUES(@typeName)
END
