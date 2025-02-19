USE School;
GO

-- Insert Departments (Ensure at least 3 departments exist first)
INSERT INTO Departments (Name, HeadInstructorId) VALUES 
('Computer Science', NULL),
('Business Administration', NULL),
('Mechanical Engineering', NULL);
GO

-- Insert Instructors (Initially without setting HeadInstructorId)
INSERT INTO Instructors (Name, Email, DepartmentId) VALUES 
('Dr. Alice Smith', 'alice.smith@university.edu', 1),
('Dr. Bob Johnson', 'bob.johnson@university.edu', 2),
('Dr. Charlie Brown', 'charlie.brown@university.edu', 3);
GO

-- Assign HeadInstructorId (after inserting instructors)
UPDATE Departments SET HeadInstructorId = 1 WHERE Id = 1;
UPDATE Departments SET HeadInstructorId = 2 WHERE Id = 2;
UPDATE Departments SET HeadInstructorId = 3 WHERE Id = 3;
GO

-- Insert Tracks (After Departments exist)
INSERT INTO Tracks (Name, DepartmentId) VALUES 
('Artificial Intelligence', 1),
('Cybersecurity', 1),
('Marketing', 2),
('Finance', 2),
('Robotics', 3),
('Automobile Design', 3);
GO

-- Insert Students (After Tracks exist)
INSERT INTO Students (Name, Email, TrackId) VALUES 
('John Doe', 'john.doe@university.edu', 1),
('Jane Smith', 'jane.smith@university.edu', 2),
('Mike Johnson', 'mike.johnson@university.edu', 3),
('Emily Davis', 'emily.davis@university.edu', 4),
('Robert Wilson', 'robert.wilson@university.edu', 5),
('Sarah Taylor', 'sarah.taylor@university.edu', 6);
GO

-- Insert Courses
INSERT INTO Courses (Title, CreditHours) VALUES 
('Introduction to AI', 3),
('Machine Learning', 4),
('Cybersecurity Principles', 3),
('Digital Marketing', 2),
('Financial Accounting', 3),
('Industrial Robotics', 4),
('Automobile Engineering', 3);
GO

-- Insert CourseTrack (After both Tracks and Courses exist)
INSERT INTO CourseTrack (TracksId, CoursesId) VALUES 
(1, 1),  -- AI -> Introduction to AI
(1, 2),  -- AI -> Machine Learning
(2, 3),  -- Cybersecurity -> Cybersecurity Principles
(3, 4),  -- Marketing -> Digital Marketing
(4, 5),  -- Finance -> Financial Accounting
(5, 6),  -- Robotics -> Industrial Robotics
(6, 7);  -- Automobile Design -> Automobile Engineering
GO
