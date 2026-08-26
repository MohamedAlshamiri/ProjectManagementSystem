<div align="center">

# Project Management System

### نظام متكامل لإدارة المشاريع والمهام

واجهة إدارية عصرية مبنية باتجاه **RTL/LTR**، مع دعم كامل للعربية والإنجليزية، وإدارة المشاريع والمهام من خلال REST API متصل بقاعدة بيانات SQL Server.

<p>
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8">
  <img src="https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="ASP.NET Core 8">
  <img src="https://img.shields.io/badge/Angular-21-DD0031?style=for-the-badge&logo=angular&logoColor=white" alt="Angular 21">
  <img src="https://img.shields.io/badge/TypeScript-5.9-3178C6?style=for-the-badge&logo=typescript&logoColor=white" alt="TypeScript">
  <img src="https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" alt="SQL Server">
  <img src="https://img.shields.io/badge/EF%20Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="Entity Framework Core">
  <img src="https://img.shields.io/badge/NG--ZORRO-21.3.2-1677FF?style=for-the-badge" alt="NG-ZORRO">
</p>

</div>

---

## 📌 نظرة عامة

**Project Management System** هو تطبيق Full-Stack لإدارة المشاريع والمهام، صُمم بفصل واضح بين الواجهة الأمامية والـ API وقاعدة البيانات.

يقدم النظام مساحة عمل إدارية تشمل:

- لوحة تحكم تعرض مؤشرات المشاريع والمهام وحالة الإنجاز.
- إدارة المشاريع بالكامل: إنشاء، تعديل، حذف، بحث وتصفية حسب الحالة.
- إدارة المهام بالكامل: إنشاء، تعديل، حذف، بحث، تصفية، ترتيب وترقيم صفحات.
- ربط المهام بالمشاريع.
- إدارة حالات المشاريع وحالات المهام وأولويات المهام.
- دعم العربية والإنجليزية مع تبديل اتجاه الصفحة تلقائياً بين **RTL / LTR**.
- واجهة Responsive تعمل على أحجام الشاشات المختلفة.
- حالات تحميل وأخطاء اتصال بالـ API مع إمكانية إعادة المحاولة.
- Swagger / OpenAPI لاختبار الـ REST API أثناء التطوير.

---

## 🧱 بنية النظام

| الطبقة | التقنية | المسؤولية |
|---|---|---|
| **Frontend** | Angular 21 + NG-ZORRO | الواجهة والتفاعل وإدارة الحالة والعرض |
| **Backend** | ASP.NET Core 8 Web API | REST API وقواعد العمل |
| **Services** | Service Layer | تنفيذ عمليات المشاريع والمهام |
| **Repositories** | Repository Pattern | الوصول إلى البيانات |
| **Data Access** | Entity Framework Core 8 | التعامل مع قاعدة البيانات |
| **Database** | SQL Server / LocalDB | تخزين المشاريع والمهام والـ Lookups |

### تدفق البيانات

```text
Angular UI
   │
   │ HTTP / JSON
   ▼
ASP.NET Core Web API
   │
   ├── Controllers
   │
   ├── Services
   │
   ├── Repositories
   │
   ▼
Entity Framework Core
   │
   ▼
SQL Server / LocalDB
```

---

## ✨ الوظائف الحالية

### 📊 Dashboard

- إجمالي المشاريع.
- إجمالي المهام.
- المشاريع المكتملة.
- المهام المكتملة.
- عرض أحدث المشاريع.
- عرض أحدث المهام.
- روابط مباشرة إلى صفحات المشاريع والمهام.
- حالة اتصال API مع زر Retry عند حدوث خطأ.

### 📁 Projects

إدارة المشاريع من خلال:

- إنشاء مشروع.
- تعديل مشروع.
- حذف مشروع مع تأكيد.
- البحث بالاسم والوصف.
- التصفية حسب حالة المشروع.
- تحديد تاريخ البداية والنهاية.
- التحقق من صحة البيانات.
- منع جعل تاريخ النهاية قبل تاريخ البداية.
- عرض حالات المشروع.
- حالات فارغة واضحة عند عدم وجود بيانات.

### ✅ Tasks

إدارة المهام من خلال:

- إنشاء مهمة.
- تعديل مهمة.
- حذف مهمة مع تأكيد.
- ربط المهمة بمشروع.
- تحديد الحالة.
- تحديد الأولوية.
- تحديد تاريخ الاستحقاق.
- البحث عن المهام.
- التصفية حسب الحالة.
- التصفية حسب المشروع.
- الترتيب حسب العنوان أو الأولوية أو تاريخ الاستحقاق.
- ترتيب تصاعدي / تنازلي.
- Pagination من جهة الـ API.
- إظهار المهام المتأخرة بصرياً عندما تكون غير مكتملة.

### 🌐 العربية والإنجليزية

- English / العربية.
- تبديل اللغة من الواجهة.
- حفظ اللغة المختارة في `localStorage`.
- تبديل اتجاه الصفحة تلقائياً:
  - English → `LTR`
  - العربية → `RTL`
- تبديل Locale الخاص بـ NG-ZORRO.
- ملفات ترجمة مستقلة:
  - `assets/i18n/en.json`
  - `assets/i18n/ar.json`

### ⚙️ Settings

صفحة إعدادات مخصصة حالياً لتغيير لغة التطبيق واتجاه الواجهة، مع عرض ملخص لبنية النظام.

---

## 🛠️ التقنيات والمكتبات

### Backend

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core 8**
- **SQL Server / LocalDB**
- **AutoMapper**
- **Repository Pattern**
- **Service Layer**
- **Swagger / OpenAPI**
- Global Exception Middleware
- CORS

### Frontend

- **Angular 21**
- **TypeScript 5.9**
- **NG-ZORRO 21**
- **RxJS**
- **ngx-translate 18**
- Angular Signals
- Standalone Components
- `OnPush` Change Detection
- Reactive Forms
- Responsive CSS

---

## 📂 Repository Structure

```text
ProjectManagementSystem/
│
├── Backend/
│   ├── ProjectManagement.slnx
│   │
│   └── ProjectManagement/
│       ├── Controllers/
│       │   ├── ProjectsController.cs
│       │   └── TasksController.cs
│       │
│       ├── Data/
│       │   ├── ApplicationDbContext.cs
│       │   └── DatabaseInitializer.cs
│       │
│       ├── DTOs/
│       │   ├── Projects/
│       │   └── Tasks/
│       │
│       ├── Entities/
│       │   ├── Project.cs
│       │   ├── ProjectStatus.cs
│       │   ├── TaskItem.cs
│       │   ├── TaskStatus.cs
│       │   └── TaskPriority.cs
│       │
│       ├── Extensions/
│       ├── Mapping/
│       ├── Middleware/
│       ├── Repositories/
│       │   ├── Interfaces/
│       │   └── Implementations/
│       │
│       ├── Services/
│       │   ├── Interfaces/
│       │   └── Implementations/
│       │
│       ├── Program.cs
│       ├── appsettings.json
│       └── ProjectManagement.csproj
│
├── Frontend/
│   └── project-management-ui/
│       ├── public/
│       ├── src/
│       │   └── app/
│       │       ├── core/
│       │       ├── features/
│       │       │   ├── dashboard/
│       │       │   ├── projects/
│       │       │   ├── tasks/
│       │       │   └── settings/
│       │       ├── layout/
│       │       │   ├── header/
│       │       │   ├── sidebar/
│       │       │   ├── main-layout/
│       │       │   └── footer/
│       │       └── shared/
│       │
│       ├── angular.json
│       ├── package.json
│       └── tsconfig*.json
│
├── FIXES_AND_RUNBOOK.md
├── IMPLEMENTATION_NOTES.md
├── .gitignore
└── README.md
```

> ملفات `node_modules`, `bin`, `obj`, `dist`, `.angular` وملفات بيئة التطوير المحلية مستبعدة من Git بواسطة `.gitignore`.

---

## 🔌 REST API

Base URL أثناء التطوير:

```text
https://localhost:7116/api
```

### Projects

| Method | Endpoint | الوظيفة |
|---|---|---|
| `GET` | `/api/projects` | جلب جميع المشاريع |
| `GET` | `/api/projects/{id}` | جلب مشروع محدد |
| `POST` | `/api/projects` | إنشاء مشروع |
| `PUT` | `/api/projects/{id}` | تعديل مشروع |
| `DELETE` | `/api/projects/{id}` | حذف مشروع |

### Tasks

| Method | Endpoint | الوظيفة |
|---|---|---|
| `GET` | `/api/tasks` | جلب المهام مع البحث والتصفية والترتيب والـ Pagination |
| `GET` | `/api/tasks/{id}` | جلب مهمة محددة |
| `GET` | `/api/tasks/project/{projectId}` | جلب مهام مشروع |
| `POST` | `/api/tasks` | إنشاء مهمة |
| `PUT` | `/api/tasks/{id}` | تعديل مهمة |
| `DELETE` | `/api/tasks/{id}` | حذف مهمة |

### Task Query Parameters

يدعم endpoint المهام:

```text
statusId
projectId
search
sortBy
sortOrder
pageNumber
pageSize
```

ويتم تقييد `pageSize` في الـ API إلى حد أقصى قدره `100`.

---

## 🗄️ قاعدة البيانات

يستخدم المشروع SQL Server / LocalDB من خلال Entity Framework Core.

الإعداد الافتراضي الموجود في `appsettings.json` هو:

```text
Server=(localdb)\v11.0;
Database=ProjectManagement;
Trusted_Connection=True;
TrustServerCertificate=True;
```

عند التشغيل في بيئة Development يقوم النظام تلقائياً بـ:

1. إنشاء قاعدة البيانات عند الحاجة.
2. إنشاء جداول النظام.
3. إضافة حالات المشاريع إذا كانت فارغة.
4. إضافة حالات المهام إذا كانت فارغة.
5. إضافة أولويات المهام إذا كانت فارغة.

ولا يقوم الـ initializer باستبدال بيانات المشاريع أو المهام الموجودة.

### Lookup Data

**Project Statuses**

- Planning / قيد التخطيط
- In Progress / قيد التنفيذ
- Completed / مكتمل

**Task Statuses**

- To Do / جديدة
- In Progress / قيد التنفيذ
- Completed / مكتملة

**Task Priorities**

- Low / منخفضة
- Medium / متوسطة
- High / عالية

---

## 🚀 التشغيل المحلي

### المتطلبات

قبل التشغيل تأكد من وجود:

- Visual Studio مع دعم ASP.NET Core / .NET 8.
- .NET 8 SDK.
- SQL Server LocalDB.
- Node.js و npm.
- Visual Studio Code.
- Angular CLI أو إمكانية تشغيل `npx ng`.

---

### 1. تشغيل Backend

افتح:

```text
Backend/ProjectManagement/ProjectManagement.csproj
```

في Visual Studio.

ثم:

```text
Build → Build Solution
```

يجب أن تكون النتيجة:

```text
0 Error(s)
0 Warning(s)
```

ثم شغّل المشروع باستخدام HTTPS.

العنوان المتوقع:

```text
https://localhost:7116
```

ويمكن اختبار Swagger من:

```text
https://localhost:7116/swagger
```

إذا طلب المتصفح الثقة في شهادة ASP.NET Core Development Certificate، وافق عليها في بيئة التطوير المحلية.

---

### 2. تشغيل Frontend

افتح Visual Studio Code داخل:

```text
Frontend/project-management-ui
```

ثم:

```bash
npm install
```

وبعدها:

```bash
npx ng serve
```

أو:

```bash
npm start
```

ثم افتح:

```text
http://localhost:4200
```

### ترتيب التشغيل الموصى به

```text
1. SQL Server / LocalDB
        ↓
2. ASP.NET Core Backend
        ↓
3. Swagger verification
        ↓
4. Angular Frontend
        ↓
5. http://localhost:4200
```

---

## 🧪 الاختبار الوظيفي

بعد تشغيل النظام، يوصى بالاختبار بهذا الترتيب:

```text
Dashboard
   ↓
Projects
   ↓
Create Project
   ↓
Edit Project
   ↓
Search / Filter Projects
   ↓
Tasks
   ↓
Create Task
   ↓
Edit Task
   ↓
Search / Filter Tasks
   ↓
Sorting
   ↓
Pagination
   ↓
Delete + Confirmation
   ↓
English / Arabic
   ↓
RTL / LTR
```

---

## 🔐 CORS

الـ Backend يسمح أثناء التطوير بالطلبات القادمة من:

```text
http://localhost:4200
https://localhost:4200
http://127.0.0.1:4200
https://127.0.0.1:4200
```

إذا ظهر خطأ اتصال من Angular:

1. تأكد من تشغيل Backend.
2. افتح Swagger.
3. تأكد من قبول شهادة HTTPS المحلية.
4. تأكد أن Angular يعمل على المنفذ `4200`.
5. أعد تشغيل Angular إذا تم تغيير إعدادات الـ API.

---

## 🧭 مسارات الواجهة

| Route | الصفحة |
|---|---|
| `/` | تحويل تلقائي إلى Dashboard |
| `/dashboard` | لوحة التحكم |
| `/projects` | إدارة المشاريع |
| `/tasks` | إدارة المهام |
| `/settings` | إعدادات اللغة والنظام |

---

## 🧩 ملاحظات مهمة

- التطبيق يبدأ بدون مشاريع ومهام، لذلك ظهور العدادات بقيمة `0` والقوائم الفارغة في أول تشغيل أمر طبيعي.
- بيانات الحالات والأولويات يتم تهيئتها تلقائياً في Development.
- لا يتم تضمين الملفات الناتجة عن البناء أو حزم npm في المستودع.
- لا يجب رفع الأسرار أو ملفات البيئة المحلية إلى GitHub.
- ملف `.gitignore` الموجود في جذر المشروع يستبعد ملفات IDE و.NET وAngular/Node وملفات البيئة المحلية.

---

## 📚 وثائق المشروع الداخلية

يحتوي المستودع أيضاً على:

- `FIXES_AND_RUNBOOK.md` — سجل الإصلاحات وخطوات التشغيل واستكشاف الأخطاء.
- `IMPLEMENTATION_NOTES.md` — ملاحظات التنفيذ والتغييرات التقنية التي تم تطبيقها.

---

## 👨‍💻 Project

**Project Management System**

Full-Stack application for organizing projects and tasks through a modern Angular interface and an ASP.NET Core Web API backed by SQL Server.

---

<div align="center">

**Built with Angular + ASP.NET Core + Entity Framework Core + SQL Server**

</div>
