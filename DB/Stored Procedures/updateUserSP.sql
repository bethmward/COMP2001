/* A stored procedure to update a user record. */

CREATE PROCEDURE updateUser (@FirstName AS VARCHAR(25), @LastName AS VARCHAR(25), 
    @Email AS VARCHAR(1000), @Password AS VARCHAR(25), @ID AS INT) AS
BEGIN
    BEGIN TRANSACTION
        BEGIN TRY
            IF @FirstName IS NOT NULL 
            UPDATE dbo.ENDUSER 
            SET dbo.ENDUSER.user_fName = @FirstName
            WHERE dbo.ENDUSER.userID = @ID;
            
            IF @LastName IS NOT NULL
            UPDATE dbo.ENDUSER
            SET dbo.ENDUSER.user_lName = @LastName
            WHERE dbo.ENDUSER.userID = @ID;

            IF @Email IS NOT NULL
            UPDATE dbo.ENDUSER
            SET dbo.ENDUSER.user_email = @Email
            WHERE dbo.ENDUSER.userID = @ID;

            IF @Password IS NOT NULL
            UPDATE dbo.USERPASSWORD
            SET dbo.USERPASSWORD.password_new = @Password
            WHERE dbo.USERPASSWORD.userID = @ID;

            IF @@TRANCOUNT > 0 COMMIT;
        END TRY
        BEGIN CATCH 
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
        END CATCH;
END;