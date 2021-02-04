/* A stored procedure for registering users. */

CREATE PROCEDURE registerUser (@FirstName AS VARCHAR(25), @LastName AS VARCHAR(25), 
    @Email AS VARCHAR(1000), @NewPassword AS VARCHAR(25), @ResponseMessage AS VARCHAR(45) OUTPUT) AS
BEGIN
    BEGIN TRANSACTION
        BEGIN TRY
            INSERT INTO ENDUSER (user_fName, user_lName, user_email)
            VALUES (@FirstName, @LastName, @Email)

            INSERT INTO USERPASSWORD (password_new)
            VALUES (@NewPassword)

            SET @ResponseMessage = 'User registered successfully.'
            IF @@TRANCOUNT > 0 COMMIT;
        END TRY
        BEGIN CATCH 
            SET @ResponseMessage = 'Error: Registration failed.'
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@ResponseMessage, 1, 0);
        END CATCH;
END;

GO