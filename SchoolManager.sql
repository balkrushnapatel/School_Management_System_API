USE School_Management_System

--There Will Be Total 11 Tables:-
--1.)School Registration
--2.)Admin Registration
--3.)Faculty Registration
--4.)Classes Registration
--5.)Student Registration
--6.)User
--7.)Class Wise Student
--8.)Subject Registration
--9.)Faculty Wise Subject
--10.)Attendance
--11.)TimeTable

-- 1. School Registration
CREATE TABLE Schools (
	SchoolId INT PRIMARY KEY IDENTITY(1,1),
	SchoolName NVARCHAR(100) NOT NULL
);

--1.1 Trust Table
CREATE TABLE Trust (
	TrustId INT PRIMARY KEY IDENTITY(1,1),
	TrustName NVARCHAR(100) NOT NULL,
	TrusteeName NVARCHAR(100) NOT NULL
);

-- 2. Users (Admins, Students, Staff)
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
	Username NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NOT NULL,
    CONSTRAINT CK_UserRoles CHECK (Role IN ('Admin', 'Student', 'Staff'))
);

-- 3. Staff
CREATE TABLE Staff (
    StaffId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
	DOB DATE,
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
	Designation NVARCHAR(100),
    DOJ DATE,
    IsActive BIT DEFAULT 1
);

-- 4. Classes (School)
CREATE TABLE Classes (
    ClassId INT PRIMARY KEY IDENTITY(1,1),
	MasterClassId INT NOT NULL,
    Section NVARCHAR(10),
	FOREIGN KEY (MasterClassId) REFERENCES MasterClasses(MasterClassId)
);

-- 4.1 Master Classes
CREATE TABLE MasterClasses (
    MasterClassId INT PRIMARY KEY IDENTITY(1,1),
    ClassName NVARCHAR(50) NOT NULL  -- E.g., '1st', '2nd', '10th'
);


-- 5. Students
CREATE TABLE Students (
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Gender NVARCHAR(10),
    DOB DATE,
    --ClassId INT,
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    Address NVARCHAR(255),
    IsActive BIT DEFAULT 1,
    CONSTRAINT FK_Students_Classes FOREIGN KEY (ClassId) REFERENCES Classes(ClassId)
);

-- 6. Subjects
CREATE TABLE Subjects (
    SubjectId INT PRIMARY KEY IDENTITY(1,1),
    SubjectName NVARCHAR(100),
    ClassId INT FOREIGN KEY REFERENCES Classes(ClassId)
);

-- 6.1 Subject Class Table
CREATE TABLE ClassSubjects (
    ClassSubjectId INT PRIMARY KEY IDENTITY(1,1),
    ClassId INT NOT NULL,
    SubjectId INT NOT NULL,
    FOREIGN KEY (ClassId) REFERENCES Classes(ClassId),
    FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId)
);


-- 7. Attendance
CREATE TABLE Attendance (
    AttendanceId INT PRIMARY KEY IDENTITY(1,1),
    StudentId INT FOREIGN KEY REFERENCES Students(StudentId),
    Date DATE,
    Status NVARCHAR(10)  -- 'Present', 'Absent'
);

-- 8. TimeTable
CREATE TABLE Timetable (
    TimetableId INT PRIMARY KEY IDENTITY(1,1),
    ClassId INT FOREIGN KEY REFERENCES Classes(ClassId),
    SubjectId INT FOREIGN KEY REFERENCES Subjects(SubjectId),
    StaffId INT FOREIGN KEY REFERENCES Staff(StaffId),
    DayOfWeek NVARCHAR(10),
    Period NVARCHAR(10)
);

