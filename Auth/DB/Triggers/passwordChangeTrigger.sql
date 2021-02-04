/* A trigger to store an old password when the new password field is updated, 
as well as to update the datetime at which the update occurred. */

CREATE TRIGGER passwordChange ON dbo.USERPASSWORD 
FOR UPDATE
AS 
BEGIN
    IF UPDATE (password_new)
    BEGIN 
        UPDATE dbo.USERPASSWORD
        SET dbo.USERPASSWORD.password_old = dbo.USERPASSWORD.password_new
        FROM inserted i
        INNER JOIN dbo.USERPASSWORD ON i.passwordID = dbo.USERPASSWORD.passwordID
        AND dbo.USERPASSWORD.password_dateChanged = (SELECT GETDATE())
    END
END; 