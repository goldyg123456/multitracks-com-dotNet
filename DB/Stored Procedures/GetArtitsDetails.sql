CREATE PROCEDURE [dbo].[GetArtistDetails]
    @artistId int = 0
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Fetch artist details
        SELECT artistID, title, biography, imageURL, heroURL
        FROM Artist
        WHERE artistId = @artistId;

        -- Fetch albums for the artist
        SELECT albumID, al.title as albumTitle, [year], al.imageURL, ar.title AS artistName
        FROM Album al
        INNER JOIN Artist ar ON al.artistID = ar.artistID
        WHERE al.artistID = @artistId;

        -- Fetch songs for the artist
        SELECT songID, s.title, bpm, timeSignature, imageURL, a.title AS album
        FROM Song s
        INNER JOIN Album a ON a.albumID = s.albumID
        WHERE s.artistID = @artistId;

    END TRY
    BEGIN CATCH
        -- Handle errors
        SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;