-- create a view for cities stat
CREATE VIEW RSVPCities AS

SELECT 
  b.GroupId
, b.Country
, b.City
, c.CityCount
, b.Lat
, b.Lon
, b.RsvpId
, b.EventId

FROM

	(SELECT  *

		FROM    

			(SELECT *, ROW_NUMBER() OVER (PARTITION BY City ORDER BY ID) AS RowNumber FROM RSVPGroups) AS a

		WHERE   a.RowNumber = 1

	) AS b

LEFT JOIN 

(SELECT COUNT(*) as CityCount, City FROM RSVPGroups GROUP BY City) AS c

ON b.City = c.City;



-- CREATE VIEW FOR COUNTRY TRENDING TOPICS

CREATE VIEW CountryTopics AS

SELECT 

c.Country
, c.City
, c.Lat
, c.Lon
, d.TopicName
, d.TopicCount


FROM RSVPGroups AS c

LEFT JOIN  

	(SELECT a.GroupId, a.TopicName, b.TopicCount


		FROM

			( SELECT  * FROM    (SELECT *, ROW_NUMBER() OVER (PARTITION BY TopicName  ORDER BY ID) AS RowNumber FROM GroupTopics) AS a WHERE a.RowNumber = 1 ) AS a

		LEFT JOIN

			(SELECT COUNT(*) AS TopicCount, TopicName FROM GroupTopics GROUP BY TopicName ) AS b

	ON a.TopicName = b.TopicName) AS d

ON c.Id = d.GroupId WHERE d.TopicName != ''