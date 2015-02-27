/*
   2015年2月20日15:08:21
   用户: sa
   服务器: WANGJI-PC
   数据库: ttx
   应用程序: 
*/

/* 为了防止任何可能出现的数据丢失问题，您应该先仔细检查此脚本，然后再在数据库设计器的上下文之外运行此脚本。*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE VUserNP SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE VKfzBjDate
	(
	ID int NOT NULL IDENTITY (1, 1),
	userID int NOT NULL,
	kfzName nvarchar(20) NOT NULL,
	note text NOT NULL,
	datetime datetime NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE VKfzBjDate ADD CONSTRAINT
	PK_VKfzBjDate PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.VKfzBjDate ADD CONSTRAINT
	FK_VKfzBjDate_VUserNP FOREIGN KEY
	(
	userID
	) REFERENCES VUserNP
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE VKfzBjDate SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
