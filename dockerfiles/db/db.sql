if db_id('meetup_guider') is null
	CREATE DATABASE [meetup_guider]
GO

USE [meetup_guider]
GO

CREATE TABLE [dbo].[RSVPGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [bigint] NOT NULL,
	[Country] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Lon] [real] NOT NULL,
	[Lat] [real] NOT NULL,
	[RsvpId] [int] NOT NULL,
	[Event] [nvarchar](max) NULL,
	[EventId] [nvarchar](max) NULL,
	[Mtime] [bigint] NOT NULL,
 CONSTRAINT [PK_RSVPGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[GroupTopics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[UrlKey] [nvarchar](max) NULL,
	[TopicName] [nvarchar](max) NULL,
 CONSTRAINT [PK_GroupTopics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[GroupTopics]  WITH CHECK ADD  CONSTRAINT [FK_Group_Topics] FOREIGN KEY([GroupId])
REFERENCES [dbo].[RSVPGroups] ([Id])
GO

ALTER TABLE [dbo].[GroupTopics] CHECK CONSTRAINT [FK_Group_Topics]
GO

-- create a view for cities stat
CREATE VIEW RSVPCities AS

SELECT 
b.Id
, b.GroupId
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


Go

-- CREATE VIEW FOR COUNTRY TRENDING TOPICS

CREATE VIEW CountryTopics AS

SELECT 
d.Id
, c.Country
, c.City
, c.Lat
, c.Lon
, d.TopicName
, d.TopicCount


FROM RSVPGroups AS c

LEFT JOIN  

	(SELECT a.Id, a.GroupId, a.TopicName, b.TopicCount


		FROM

			( SELECT  * FROM    (SELECT *, ROW_NUMBER() OVER (PARTITION BY TopicName  ORDER BY ID) AS RowNumber FROM GroupTopics) AS a WHERE a.RowNumber = 1 ) AS a

		LEFT JOIN

			(SELECT COUNT(*) AS TopicCount, TopicName FROM GroupTopics GROUP BY TopicName ) AS b

	ON a.TopicName = b.TopicName) AS d

ON c.Id = d.GroupId WHERE d.TopicName != ''