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


## 📚 API Documentation Example

### 🔸 Get All Teachers

**Endpoint:** `GET /api/TeacherApi`

**Description:** Returns a list of all teachers in the database.

**Returns:** JSON array of teacher objects.

---

### 🔸 Get Teacher by ID

**Endpoint:** `GET /api/TeacherApi/{id}`

**Parameters:**
- `id`: Teacher ID (integer)

**Returns:**
- `200 OK`: Teacher object if found
- `404 Not Found`: If teacher with given ID doesn't exist


