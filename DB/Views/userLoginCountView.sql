/* A view that tallies the times a user has logged in. */

CREATE VIEW userLoginCount AS
SELECT COUNT(*) AS loginCount
FROM dbo.USERSESSION
GROUP BY dbo.USERSESSION.userID;