USE master;
GO

CREATE DATABASE School;
GO

USE School;
GO

-- Create the Departments table
CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    HeadInstructorId INT UNIQUE
);
GO

-- Create the Instructors table
CREATE TABLE Instructors (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    SupervisorId INT,
    DepartmentId INT,
    FOREIGN KEY (SupervisorId) REFERENCES Instructors(Id), -- Recursive relationship
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id) -- One-to-Many relationship
);
GO

-- Create the Tracks table
CREATE TABLE Tracks (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    DepartmentId INT,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id) -- One-to-Many relationship
);
GO

-- Create the Students table
CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    TrackId INT,
    FOREIGN KEY (TrackId) REFERENCES Tracks(Id) -- One-to-Many relationship
);
GO

-- Create the Courses table
CREATE TABLE Courses (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(100) NOT NULL,
    CreditHours INT NOT NULL
);
GO

-- Create the TrackCourses junction table for Many-to-Many relationship
CREATE TABLE TrackCourses (
    TrackId INT,
    CourseId INT,
    PRIMARY KEY (TrackId, CourseId),
    FOREIGN KEY (TrackId) REFERENCES Tracks(Id), -- Many-to-Many relationship
    FOREIGN KEY (CourseId) REFERENCES Courses(Id) -- Many-to-Many relationship
);
GO

-- Add the foreign key constraint for HeadInstructorId in Departments table
ALTER TABLE Departments
ADD CONSTRAINT FK_Departments_HeadInstructorId
FOREIGN KEY (HeadInstructorId) REFERENCES Instructors(Id); -- One-to-One relationship
GO