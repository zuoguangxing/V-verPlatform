/*
   2014年10月25日15:41:25
   用户: vvercom_wangji
   服务器: db8801.zhuji91.com,1430
   数据库: vvercom_vverdb
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
ALTER TABLE vvercom_wangji.UserNP SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE vvercom_wangji.novel
	(
	ID int NOT NULL IDENTITY (1, 1),
	Date datetime NOT NULL,
	userID int NOT NULL,
	text text NOT NULL,
	title nchar(20) NOT NULL,
	classify nchar(20) NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE vvercom_wangji.novel ADD CONSTRAINT
	PK_novel PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE vvercom_wangji.novel ADD CONSTRAINT
	FK_novel_UserNP FOREIGN KEY
	(
	userID
	) REFERENCES vvercom_wangji.UserNP
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE vvercom_wangji.novel SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
