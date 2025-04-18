# MySchoolAPI - ASP.NET Core Web API & MVC

📌 **Details**  
This project is a teachers management system based on  **ASP.NET Core MVC and Web API** achieving **CRUD** 's read, delete and update function  

---
## 📑 Project Structure
/MySchoolAPI
│── /Controllers
│   ├── TeacherController.cs        # MVC Controller (Views: List, Show, Edit)
│   ├── TeacherApiController.cs     # API Controller (Returns JSON)
│── /Models
│   ├── Teacher.cs                  # Teacher Data Model
│   ├── SchoolDbContext.cs          # EF Core DbContext
│   ├── SchoolDbAccess.cs           # Manual DB access using MySQL
│── /Views
│   └── /Teacher
│       ├── List.cshtml              # Displays all teachers
│       ├── Show.cshtml              # Displays a single teacher
│       ├── Edit.cshtml              # Edit form with validation
│── README.md                        # Project Documentation




