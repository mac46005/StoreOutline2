CREATE PROCEDURE [dbo].[spEditGenType]
	@id int,
	@typeName NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.GeneralType
	SET TypeName = @typeName
	WHERE Id = @id
END
