# MySchoolAPI - ASP.NET Core MVC + Web API Project

📌 **Project Overview**  
MySchoolAPI is a teacher management system built using **ASP.NET Core MVC and Web API**.  
It supports key **CRUD operations**, including reading, deleting, and updating teacher information.  
The system integrates both **HTML web views** and **JSON API endpoints**, making it accessible via browser and terminal.

---

## Project Structure

```
/MySchoolAPI
│── /Controllers
│   ├── TeacherController.cs        # MVC Controller (List, Show, Edit)
│   ├── TeacherApiController.cs     # Web API Controller (JSON responses)
│
│── /Models
│   ├── Teacher.cs                  # Data model for teachers
│   ├── SchoolDbContext.cs          # EF Core DbContext
│   ├── SchoolDbAccess.cs           # Manual MySQL data access
│
│── /Views
│   └── /Teacher
│       ├── List.cshtml             # Lists all teachers
│       ├── Show.cshtml             # Displays one teacher
│       ├── Edit.cshtml             # Edit teacher info with validation
│
│── README.md                       # Project documentation
```

---

## API Usage (Tested with curl)

### Get All Teachers

```bash
curl http://localhost:5270/api/TeacherApi
```

### Get One Teacher

```bash
curl http://localhost:5270/api/TeacherApi/1
```

### Update Teacher

```bash
curl -X PUT http://localhost:5270/api/TeacherApi/1 \
-H "Content-Type: application/json" \
-d '{
  "TeacherId": 1,
  "TeacherFname": "Ellie",
  "TeacherLname": "D",
  "EmployeeNumber": "T1001",
  "HireDate": "2022-01-01",
  "Salary": 65000
}'
```

---
