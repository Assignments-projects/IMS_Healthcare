USE [IMS_DB]
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_PATIENT_TOTAL]    Script Date: 6/28/2025 9:07:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[SP_UPDATE_PATIENT_TOTAL]
    @PatientUuid UNIQUEIDENTIFIER -- The PatientUuid to calculate total cost from the Statements table
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Declare a variable to hold the total cost
        DECLARE @TotalCost DECIMAL(18, 2);
        DECLARE @PatientUuidStr NVARCHAR(36); -- Variable to hold the PatientUuid as a string

        -- Convert the PatientUuid to a string format
        SET @PatientUuidStr = CAST(@PatientUuid AS NVARCHAR(36));

        -- Calculate the sum of TotalCost from Statements for the given PatientUuid
        SELECT @TotalCost = SUM(TotalCost)
        FROM [dbo].[Statements]
        WHERE PatientUuid = @PatientUuid;

        -- If the Patient exists, update their TotalCost
        IF EXISTS (SELECT 1 FROM [dbo].[Patients] WHERE PatientUuid = @PatientUuid)
        BEGIN
            UPDATE [dbo].[Patients]
            SET TotalCost = @TotalCost
            WHERE PatientUuid = @PatientUuid;
        END
        ELSE
        BEGIN
            -- If the Patient doesn't exist, raise an error with the PatientUuid as a string
            RAISERROR('Patient not found with PatientUuid: %s', 16, 1, @PatientUuidStr);
        END
    END TRY
    BEGIN CATCH
        -- If an error occurs, capture the error details
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorNumber INT;
        
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorNumber = ERROR_NUMBER();
        
        -- Log the error or raise an error with a custom message
        RAISERROR('Error occurred while calculating and updating patient total cost: %s, Error Number: %d', 16, 1, @ErrorMessage, @ErrorNumber);
        
        -- Optionally, return a custom error code or message
        RETURN -1; -- Custom error code for failure
    END CATCH
END;
GO
