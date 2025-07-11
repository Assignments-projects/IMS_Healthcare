USE [IMS_DB]
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_USERS_FROM_ASPNETUSER]    Script Date: 6/28/2025 9:07:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_DELETE_USERS_FROM_ASPNETUSER]
    @UserId UNIQUEIDENTIFIER -- The UserId to delete from the Users table
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Delete from Users table based on the AspNetUsers table
        DELETE FROM [dbo].[Users]
        WHERE [UserUuid] = @UserId;

    END TRY
    BEGIN CATCH
        -- If an error occurs, capture the error details
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorNumber INT;
        
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorNumber = ERROR_NUMBER();
        
        -- You can log the error or raise an error with a custom message
        RAISERROR('Error occurred while deleting user: %s, Error Number: %d', 16, 1, @ErrorMessage, @ErrorNumber);
        
        -- Optionally, you can return a custom error code or message
        RETURN -1; -- Custom error code
    END CATCH
END;
GO
