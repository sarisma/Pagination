USE [database]
GO
/****** Object:  StoredProcedure [dbo].[sproc_user_detail]    Script Date: 12/1/2022 10:59:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sproc_user_detail] @flag CHAR(10)
,@PageNumber INT= NULL
,@startRowIndex INT = null
,@maximumRows INT = null
AS
SET NOCOUNT ON 
BEGIN 
	DECLARE @sql VARCHAR(max)
	--DECLARE @RowsOfPage AS INT
	--DECLARE @MaxTablePage  AS FLOAT
	--SET @RowsOfPage=100
	If @flag ='list' --Get List
	BEGIN
		SET @sql='	select tud.full_name, tud.user_name,tud.user_email,tud.user_mobile_no from tbl_user_detail as tud '
		
		SET @sql = @sql + ' order by 1 desc' ;
		print(@sql)
		EXEC(@sql)
	END
	If @flag='paging'--pagination
	
		BEGIN
			     SELECT user_id,user_name, full_name, user_email, user_mobile_no,RowRank
					FROM
					   (
						   SELECT  user_id,user_name, full_name, user_email, user_mobile_no,
             
								  ROW_NUMBER() OVER (ORDER BY user_id) AS RowRank
							FROM tbl_user_detail
						) AS RecordsWithRowNumbers
					WHERE RowRank >= @startRowIndex AND RowRank < (@startRowIndex + @maximumRows)
					
		END

	If @flag= 'tot' --Total Records
		BEGIN
			select count(user_id)  as TotalRecords from tbl_user_detail
		End

	IF @flag ='p'
		BEGIN
			
             --SELECT @MaxTablePage = COUNT(*) FROM tbl_user_detail
             --SET @MaxTablePage = CEILING(@MaxTablePage/@RowsOfPage)
             SELECT  user_name,full_name,user_email,user_mobile_no FROM tbl_user_detail
             Order by user_id
             --OFFSET (@PageNumber-1)*@maximumRows ROWS
			 OFFSET @PageNumber ROWS
             FETCH NEXT @maximumRows ROWS ONLY
		END
END
