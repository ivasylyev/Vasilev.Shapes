
SELECT	
			a.strTitle,
			t.strTag

FROM		[dbo].[Articles] a
LEFT JOIN	
(
	SELECT		atp.idfArticle, 
				t.strTag
	FROM		[dbo].[Tags]	t
	INNER JOIN	[dbo].[Articles_Tags_Participation] atp	
	ON			t.idfTag = atp.idfTag
) t
ON			a.idfArticle = t.idfArticle