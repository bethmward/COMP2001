/* A stored procedure for the deletion of a user's details. */

CREATE PROCEDURE deleteUser (@ID AS INT) AS
BEGIN
    BEGIN TRANSACTION
        BEGIN TRY
            DELETE dbo.ENDUSER
            WHERE dbo.ENDUSER.userID = @ID;

            IF @@TRANCOUNT > 0 COMMIT;
        END TRY
        BEGIN CATCH 
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
        END CATCH;
END;