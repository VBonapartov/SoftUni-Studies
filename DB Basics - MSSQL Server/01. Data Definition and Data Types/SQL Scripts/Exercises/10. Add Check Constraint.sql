/* 10. Add Check Constraint */
USE [Minions]
GO

ALTER TABLE Users
ADD CONSTRAINT CH_Password CHECK(LEN(Password) >= 5)
GO