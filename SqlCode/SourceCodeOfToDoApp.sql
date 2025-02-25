use ToDoDataBase
go

USE ToDoDataBase;
GO

CREATE TABLE TTask (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(250) NOT NULL,
    Description VARCHAR(250) NULL,
    IsCompleted BIT DEFAULT 0, -- 1 for completed, 0 for not completed
    Notes VARCHAR(250) NULL,
    CreatedAt DATETIME DEFAULT GETUTCDATE(),
    DeletedAt DATETIME NULL
);

INSERT INTO TTask (Title, Description, IsCompleted, Notes)
VALUES 
    ('Finalizare raport lunar', 'Redactarea și verificarea raportului financiar pe luna curentă', 0, 'Prioritate ridicată'),
    ('Actualizare site web', 'Modificare conținut și corectarea erorilor de afișare', 1, 'Finalizat pe 20 februarie'),
    ('Planificare ședință echipă', 'Organizarea unei întâlniri pentru alinierea obiectivelor trimestriale', 0, 'Necesită confirmarea participanților');

SELECT* from TTask;


-- CREATE TABLE TTags (
--     Id INT PRIMARY KEY IDENTITY(1,1),
--     Name VARCHAR(100) UNIQUE NOT NULL
-- );

-- CREATE TABLE TTaskTags (
--     TaskId INT NOT NULL,
--     TagId INT NOT NULL,
--     PRIMARY KEY (TaskId, TagId),
--     FOREIGN KEY (TaskId) REFERENCES TTask(Id) ON DELETE CASCADE,
--     FOREIGN KEY (TagId) REFERENCES TTags(Id) ON DELETE CASCADE
-- );


