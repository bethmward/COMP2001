/* A stored procedure to check that both the inputs, email and password, exist within the database under the same userID.
If they do, the login is validated and the session is inserted into the USERSESSION table. If not, the login remains invalid. */

CREATE PROCEDURE validateUser (@Email AS VARCHAR(1000), @Password AS VARCHAR(25)) AS
BEGIN
    BEGIN TRANSACTION
        DECLARE @Validated BIT = 0;
        BEGIN TRY
            SELECT dbo.ENDUSER.userID, dbo.ENDUSER.user_email, dbo.USERPASSWORD.password_new
            FROM dbo.ENDUSER
            INNER JOIN dbo.USERPASSWORD
            ON dbo.ENDUSER.userID = dbo.USERPASSWORD.UserId
            WHERE dbo.ENDUSER.user_email = @Email AND dbo.USERPASSWORD.password_new = @Password

            SET @Validated = 1;

            INSERT INTO dbo.USERSESSION (userID, session_date, session_status)
            VALUES ((SELECT dbo.ENDUSER.userID FROM dbo.ENDUSER WHERE dbo.ENDUSER.user_email = @Email), GETDATE(), 1);

            IF @@TRANCOUNT > 0 COMMIT;
        END TRY
        BEGIN CATCH 
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
        END CATCH;
    RETURN @Validated;
END;