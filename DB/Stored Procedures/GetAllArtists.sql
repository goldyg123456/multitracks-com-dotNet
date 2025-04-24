CREATE PROCEDURE [dbo].[GetAllArtists]
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Fetch artist details
        SELECT artistID, title, imageURL
        FROM Artist

    END TRY
    BEGIN CATCH
        -- Handle errors
        SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;