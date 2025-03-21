# MySchoolAPI - ASP.NET Core Web API & MVC

📌 **Details**  
This project is a teachers management system based on  **ASP.NET Core MVC and Web API** achieving **CRUD** 's read function  

---
## 📑 Project Structure
```bash
/MySchoolAPI
│── /Controllers
│   ├── TeacherController.cs        # MVC Controller (Returns Views)
│   ├── TeacherApiController.cs     # API Controller (Returns JSON)
│── /Models
│   ├── Teacher.cs                  # Teacher Data Model
│   ├── SchoolDbContext.cs          # Database Context
│── /Views
│   ├── /Teacher
│       ├── List.cshtml              # Displays all teachers
│       ├── Show.cshtml              # Displays a single teacher
│── README.md                        # Project Documentation
```
---


## How to Run
```bash
dotnet run
```
---
Once the server is running, access: "http://localhost:5270"
(Replace 5270 with your actual port if different.)
## Testing with cURL
```bash
# Get all teachers
curl -X GET http://localhost:5270/api/TeacherApi
```

# Get a specific teacher (ID = 1)
```bash
curl -X GET http://localhost:5270/api/TeacherApi/1
```
