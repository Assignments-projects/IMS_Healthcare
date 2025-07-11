USE [IMS_DB]
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_STATEMENT_TOTAL]    Script Date: 6/28/2025 9:07:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UPDATE_STATEMENT_TOTAL]
    @StatementId INT -- The StatementId to calculate and update the total cost in the Statements table
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Declare a variable to hold the total cost
        DECLARE @TotalCost DECIMAL(18, 2);

        -- Calculate the sum of TotalCost from StatementItems for the given StatementId
        SELECT @TotalCost = SUM(TotalCost)
        FROM [dbo].[StatementItems]
        WHERE StatementId = @StatementId;

        -- If the Statement exists, update its TotalCost
        IF EXISTS (SELECT 1 FROM [dbo].[Statements] WHERE StatementId = @StatementId)
        BEGIN
            UPDATE [dbo].[Statements]
            SET TotalCost = @TotalCost
            WHERE StatementId = @StatementId;
        END
        ELSE
        BEGIN
            -- If the Statement doesn't exist, raise an error
            RAISERROR('Statement not found with StatementId: %d', 16, 1, @StatementId);
        END
    END TRY
    BEGIN CATCH
        -- If an error occurs, capture the error details
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorNumber INT;
        
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorNumber = ERROR_NUMBER();
        
        -- Log the error or raise an error with a custom message
        RAISERROR('Error occurred while calculating and updating statement total cost: %s, Error Number: %d', 16, 1, @ErrorMessage, @ErrorNumber);
        
        -- Optionally, return a custom error code or message
        RETURN -1; -- Custom error code for failure
    END CATCH
END;
GO
