# University-Management-System

<h3>🎯This project Api is a University Management System API built using ASP.NET Core. The API provides endpoints to manage various entities in a University environment, such as Students, Courses, Instructors, Departments, and Faculties. It also includes JWT authentication for user registration and login.</h3>

![Image](https://github.com/user-attachments/assets/a60dc2b1-f06c-4aeb-950a-452ffeb68450)

<h2>💥Features</h2>
<ul>
  <li>🔐JWT authentication system for user registration and login.</li>
  <li>🔑Hashed Password Encryption for users.</li>
  <li>CRUD operations for Students, Courses, Teachers, Departments, and Faculties.</li>
  <li>Methods authorized by manager.</li>
  <li>Repository Pattern for stucture and cleaning code with reduce duplication.</li>
  <li>Many-to-many relationship between Students and Courses.</li>
  <li>One-to-many relationships between Department and Students, Faculty and Departments, Department and Students, Department and Courses.</li>
</ul>

<h2>📌Endpoints</h2>


<h3>Auth</h3>
<ul>
  <li><code>Post /api/Auth/Register</code>: register</li>    
  <li><code>Post /api/Auth/Login</code>: login</li>
</ul>


<h3>Student</h3>
<ul>
  <li><code>Get /api/Student</code>: Get List Of Students</li>
  <li><code>Post /api/Student</code>: Add Student</li>
  <li><code>Get /api/Student/Get courses of student/{id}</code>: Get courses name of student with {id}</li>
  <li><code>Get /api/Student/{id}</code>: Get details of student with {id}</li>
  <li><code>Put /api/Student/{id}</code>: Update student with {id}</li>
  <li><code>Post /api/Student/Add Course/{idstudent}/{idcourse}</code>: add course with {idcourse} to student with {idstudent}</li>
  <li><code>Delete /api/Student/Add Course/{idstudent}/{idcourse}</code>: delete course with {idcourse} of student with {idstudent}</li>
</ul>

<h3>Instructor</h3>
<ul>
  <li><code>Get /api/Instructor</code>: Get List Of Instructors</li>
  <li><code>Post /api/Instructor</code>: Add Instructor</li>
  <li><code>Get /api/Instructor/Get course of Instructor/{id}</code>: Get course name of instructor with {id}</li>
  <li><code>Get /api/Instructor/{id}</code>: Get details of instructor with {id}</li>
  <li><code>Put /api/Instructor/{id}</code>: Update instructor with {id}</li>
  <li><code>Delete /api/Instructor/{id}</code>: delete instructor with {id}</li>
</ul>

<h3>Faculty</h3>
<ul>
  <li><code>Get /api/Faculty</code>: Get List Of faculties</li>
  <li><code>Post /api/Faculty</code>: Add faculty</li>
  <li><code>Get /api/Faculty/GetAllDepartment/{id}</code>: Get All Department of faculty with {id}</li>
  <li><code>Get /api/Faculty/GetAllStudents/{id}</code>: Get All students of faculty with {id}</li>
  <li><code>Get /api/Faculty/GetAllInstructors/{id}</code>: Get All instructors of faculty with {id}</li>
  <li><code>Get /api/Faculty/{id}</code>: get faculty with {id}</li>
  <li><code>Update /api/Faculty/{id}</code>: update faculty with {id}</li>
  <li><code>Delete /api/Faculty/{id}</code>: delete faculty with {id}</li>
</ul>

<h3>Department</h3>
<ul>
  <li><code>Get /api/Department</code>: Get List Of departments</li>
  <li><code>Post /api/Department</code>: Add department</li>
  <li><code>Get /api/Department/GetAllCourses/{id}</code>: Get all courses of Department with {id}</li>
  <li><code>Get /api/Department/GetAllStudents/{id}</code>: Get All students of Department with {id}</li>
  <li><code>Get /api/Department/GetAllInstructors/{id}</code>: Get All instructors of Department with {id}</li>
  <li><code>Get /api/Department/{id}</code>: get Department with {id}</li>
  <li><code>Update /api/Department/{id}</code>: update Department with {id}</li>
  <li><code>Delete /api/Department/{id}</code>: delete Department with {id}</li>
</ul>

<h3>Course</h3>
<ul>
  <li><code>Get /api/Course</code>: Get List Of Courses</li>
  <li><code>Post /api/Course</code>: Add Course</li>
  <li><code>Get /api/Course/{id}</code>: get Course with {id}</li>
  <li><code>Update /api/Course/{id}</code>: update Course with {id}</li>
  <li><code>Delete /api/Course/{id}</code>: delete Course with {id}</li>
</ul>

<h2>🔐Authentication</h2>
This API uses JWT authentication for user registration and login. Users need to register and login to obtain a refresh token, which they will use to access the various entity endpoints.

<h2>🥇Technologies </h2>
<ul>
  <li>ASP.NET Core for building the API.</li>
  <li>AutoMapper for mapping between entity models and DTOs.</li>
  <li>JWT authentication for user security.</li>
  <li>Refresh Token</li>
  <li>Entity Framework Core for database operations.</li>
  <li>SQL Server.</li>
</ul>

<h2>🌹How to Run the Project</h2>
<ol>
  <li>Clone this repository to your local machine.</li>
  <li>Open the project in your preferred IDE.</li>
  <li>Add migration <code>Add-Migration init</code></li>
  <li>Update Data base <code>Update-Database</code></li>
  <li>Run the project</li>
  <li>Finally do not Forget to Login as a manager to access any thing with Email  = HellowIamManager with  password = itspass , to be Authorized to access Methods</li>
</ol>
