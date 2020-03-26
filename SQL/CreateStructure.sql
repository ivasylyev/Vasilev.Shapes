

CREATE TABLE [dbo].[Articles] (
	[idfArticle]	int IDENTITY(1,1) NOT NULL,
	[strTitle]		nvarchar(800) NOT NULL,
	[strText]		nvarchar(max) NOT NULL	
 )
GO
CREATE UNIQUE  INDEX [IX__Articles_idfArticle] ON [dbo].[Articles](
	[idfArticle]	ASC
)
INCLUDE(
	[strTitle]
)
GO


CREATE TABLE [dbo].[Tags] (
	[idfTag]		int IDENTITY(1,1) NOT NULL,
	[strTag]		nvarchar(200) NOT NULL	
 )
GO
CREATE UNIQUE  INDEX [IX__Tags_idfTag] ON [dbo].[Tags](
	[idfTag]	 ASC
)
INCLUDE(
	[strTag]
)
GO

CREATE TABLE [dbo].[Articles_Tags_Participation](
	[idfArticles_Tags_Participation]	int IDENTITY(1,1) NOT NULL,
	[idfArticle]						int NOT NULL,
	[idfTag]							int NOT NULL,
) 
GO

CREATE UNIQUE  INDEX [IX__Articles_Tags_Participation_idfArticle_idfTag] ON [dbo].[Articles_Tags_Participation]
(
	[idfTag]		ASC,
	[idfArticle]	ASC

)
GO



--delete from Articles
SET IDENTITY_INSERT [dbo].[Articles] ON
DECLARE @Counter INT 
SET @Counter=1
WHILE ( @Counter <= 100)
BEGIN
    INSERT INTO [dbo].[Articles]
           (idfArticle, strTitle, strText)
    VALUES 
           (@Counter, N'Title' + CONVERT(nvarchar(8), @Counter), N'Some Text ' + CONVERT(nvarchar(8), @Counter))
    SET @Counter  = @Counter  + 1
END
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO

SET IDENTITY_INSERT [dbo].[Tags] ON
DECLARE @Counter INT 
SET @Counter=1
WHILE ( @Counter <= 10)
BEGIN
    INSERT INTO [dbo].[Tags]
           (idfTag, strTag)
    VALUES 
           (@Counter, N'Tag' + CONVERT(nvarchar(8), @Counter))
    SET @Counter  = @Counter  + 1
END
SET IDENTITY_INSERT [dbo].[Tags] OFF

GO

DECLARE @Counter INT 
SET @Counter=1
WHILE ( @Counter <= 50)
BEGIN
    INSERT INTO [dbo].[Articles_Tags_Participation]
           (idfArticle, idfTag)
    VALUES 
           (@Counter, @Counter % 10)
    SET @Counter  = @Counter  + 1
END

SET @Counter=1
WHILE ( @Counter <= 10)
BEGIN
    INSERT INTO [dbo].[Articles_Tags_Participation]
           (idfArticle, idfTag)
    VALUES 
           (@Counter + 1, 10 - @Counter % 10)
    SET @Counter  = @Counter  + 1
END
GO


