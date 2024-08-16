IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'FlashCardsDB')
  BEGIN
    CREATE DATABASE [FlashCardsDB]
  END
GO

USE [FlashCardDB]
GO

-- IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TableName' and xtype='U')
DROP TABLE IF EXISTS FlashCards;
CREATE TABLE FlashCards (
    cardId GUID NOT NULL,
    question VARCHAR(255) DEFAULT NULL,
    answer VARCHAR(255) DEFAULT NULL,
    status VARCHAR(255) DEFAULT NULL,
    PRIMARY KEY (cardId)
);
GO

CREATE PROCEDURE uspInsertCard(
  @question NVARCHAR(255) = NULL,
  @answer NVARCHAR(255) = NULL,
  @status NVARCHAR(255) = NULL,
) AS
BEGIN
  INSERT INTO FlashCards (question, answer, status) 
  VALUES (@question, @answer, @status);
END
GO

CREATE PROCEDURE uspGetAllCards() AS
BEGIN
  SELECT * FROM FlashCards;
END
GO

INSERT INTO FlashCards(cardId, question, answer, status) VALUES ("3fa85f64-5717-4562-b3fc-2c963f66afa6", 'What is smallest prime number', '2', 'pass');
INSERT INTO FlashCards(cardId, question, answer, status) VALUES ("b736b3f4-dadd-4c71-82d1-37774e733fc8", 'How many hours in a day', '24', 'fail');
INSERT INTO FlashCards(cardId, question, answer, status) VALUES ("e844faab-32bc-4f9b-9332-b1123a9652f4", 'What is the first month in a year', 'January', 'pass');

-- stored procedure for CRUD
-- API : get,getbyid,post,put,delete
 