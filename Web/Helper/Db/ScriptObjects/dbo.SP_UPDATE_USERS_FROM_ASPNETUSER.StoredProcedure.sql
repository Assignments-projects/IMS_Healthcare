USE [IMS_DB]
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_USERS_FROM_ASPNETUSER]    Script Date: 6/28/2025 9:07:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UPDATE_USERS_FROM_ASPNETUSER]
    @UserId UNIQUEIDENTIFIER -- The UserId that you want to update
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Update the Users table based on the changes in the AspNetUsers table
        UPDATE [dbo].[Users]
        SET 
            [FirstName] = ANU.[FirstName],
            [LastName] = ANU.[LastName],
            [Address] = ANU.[Address],
            [PhoneNo] = ANU.[PhoneNo],
            [IsApproved] = ANU.[IsApproved],
            [UserName] = ANU.[UserName],
            [NormalizedUserName] = ANU.[NormalizedUserName],
            [Email] = ANU.[Email],
            [NormalizedEmail] = ANU.[NormalizedEmail],
            [EmailConfirmed] = ANU.[EmailConfirmed],
            [LockoutEnd] = ANU.[LockoutEnd],
            [LockoutEnabled] = ANU.[LockoutEnabled],
            [AccessFailedCount] = ANU.[AccessFailedCount],
            [ProfilePicPath] = ANU.[ProfilePicPath],
            [UpdatedDate] = GETDATE()
        FROM [dbo].[Users] U
        INNER JOIN [dbo].[AspNetUsers] ANU ON U.[UserUuid] = ANU.[Id]
        WHERE ANU.[Id] = @UserId;

    END TRY
    BEGIN CATCH
        -- If an error occurs, capture the error details
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorNumber INT;
        
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorNumber = ERROR_NUMBER();
        
        -- You can log the error or raise an error with a custom message
        RAISERROR('Error occurred while updating user: %s, Error Number: %d', 16, 1, @ErrorMessage, @ErrorNumber);
        
        -- Optionally, you can return a custom error code or message
        RETURN -1; -- Custom error code
    END CATCH
END;
GO
