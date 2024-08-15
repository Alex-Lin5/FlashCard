IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'FlashcardDB')
  BEGIN
    CREATE DATABASE [FlashcardDB]
  END
GO

USE [FlashCardDB]
GO

-- IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TableName' and xtype='U')
DROP TABLE IF EXISTS Flashcard;
CREATE TABLE Flashcard (
    cardId INT NOT NULL,
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
  INSERT INTO Flashcard (question, answer, status) 
  VALUES (@question, @answer, @status);
END
GO

CREATE PROCEDURE uspGetAllCards() AS
BEGIN
  SELECT * FROM Flashcard;
END
GO

INSERT INTO Flashcard(cardId, question, answer, status) VALUES (1, 'What is smallest prime number', '2', 'pass');

-- stored procedure for CRUD
-- API : get,getbyid,post,put,delete
 