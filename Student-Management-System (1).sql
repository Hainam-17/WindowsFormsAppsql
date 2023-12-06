CREATE DATABASE StudentManagementASM
go 
USE StudentManagementASM
go

CREATE TABLE Class (
       ClassID int primary key,
	   ClassCode nvarchar(50)
);
CREATE TABLE Student (
       StudentID int primary key,
	   StudentName nvarchar(50),
	   Birthday datetime,
	   ClassID int,
	   Foreign key (ClassID) References Class(ClassID)
);
CREATE TABLE Subject (
       SubjectID int primary key,
	   SubjectName nvarchar(100),
	   SessionCount int check (SessionCount > 0)
);

CREATE TABLE Result (
       SubjectID int not null,
	   StudentID int not null,
	   Mark Float,
	   Primary key (SubjectID, StudentID),
	   Foreign key (SubjectID) References Subject(SubjectID),
	   Foreign key (StudentID) References Student(StudentId)
);

CREATE TABLE Account (
	userName varchar(20) not null,
	pass varchar(20) not null
);

INSERT into Class (ClassID, ClassCode)
Values
      (1, 'C1106KV'),
	  (2, 'C1107KV'),
      (3, 'C1108KV'),
      (4, 'C1109KV'),
      (5, 'C1110KV');


Insert into Student (StudentID, StudentName, Birthday, ClassID)
Values
      (1, 'Pham Tuan Anh', '2003-08-05', 1),
      (2, 'Phan Van Huy', '2002-06-10', 1),
      (3, 'Nguyen Hoang Minh', '2002-08-05', 2),
      (4, 'Tran Tuan Tu', '2003-10-10', 2),
      (5, 'Do Anh Tai', '2002-06-06', 3);


INSERT INTO Subject (SubjectId, SubjectName, SessionCount)
VALUES
    (1, 'C Programming', 22),
    (2, 'Web Design', 18),
    (3, 'Database Management', 23);


INSERT INTO Result (StudentId, SubjectId, Mark)
VALUES
    (1, 1, 8),
    (1, 2, 7),
    (2, 3, 5),
    (3, 2, 6),
    (4, 3, 9),
    (5, 2, 8);
go;

SELECT StudentId AS 'Ma Sinh Vien', StudentName AS 'Ten Sinh Vien', Birthday AS 'Ngay Sinh'
FROM Student
WHERE Birthday BETWEEN '2002-10-10' AND '2003-10-10';

SELECT Class.ClassId, Class.ClassCode, COUNT(Student.StudentId) AS TotalStudent
FROM Class
INNER JOIN Student ON Class.ClassId = Student.ClassId
GROUP BY Class.ClassId, Class.ClassCode;

SELECT Student.StudentId AS 'Ma Sinh Vien', Student.StudentName AS 'Ten Sinh Vien', SUM(Result.Mark) AS TotalMark
FROM Student
LEFT JOIN Result ON Student.StudentId = Result.StudentId
GROUP BY Student.StudentId, Student.StudentName
HAVING SUM(Result.Mark) > 10
ORDER BY TotalMark DESC;

insert into Account values('hainam', 'hainam2004');

