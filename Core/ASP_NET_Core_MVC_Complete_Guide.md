# 🎯 ASP.NET Core MVC — Complete Theory & Interview Guide

---

# PART 1 — INTRODUCTION TO .NET CORE & ASP.NET CORE

## 1.1 What is .NET Core?

.NET Core is a **free, open-source, cross-platform** successor to the original .NET Framework. While the old .NET Framework was Windows-only and tightly coupled to Internet Information Services (IIS), .NET Core was redesigned from the ground up to run on **Windows, Linux, and macOS**.

Key characteristics:
- **Cross-platform** — runs on any OS
- **High performance** — consistently ranks among the fastest web frameworks in TechEmpower benchmarks
- **Modular** — you include only the NuGet packages you need (no bloated runtime)
- **Open-source** — maintained by Microsoft and the community on GitHub
- **Cloud-ready** — designed with Docker and microservices in mind
- **Unified** — starting from .NET 5, Microsoft merged .NET Core and .NET Framework into a single ".NET" platform

### .NET Evolution Timeline

```
.NET Framework 1.0   (2002) — Windows only, IIS only
.NET Framework 4.x   (2010-2019) — Mature but locked to Windows
.NET Core 1.0        (2016) — Cross-platform rewrite begins
.NET Core 2.x        (2017-2018) — Significant API surface added
.NET Core 3.x        (2019) — Desktop apps (WPF/WinForms) added
.NET 5               (2020) — Unified platform, dropped "Core" name
.NET 6 LTS           (2021) — Minimal APIs, hot reload
.NET 7               (2022) — Performance improvements
.NET 8 LTS           (2023) — Current LTS, Native AOT support
.NET 9               (2024) — Latest release
```

## 1.2 What is ASP.NET Core?

ASP.NET Core is the **web framework** built on top of .NET Core. It handles everything related to building web applications:
- HTTP request/response pipeline
- Routing
- Controllers and Views (MVC)
- Web APIs
- Razor Pages
- Minimal APIs
- SignalR (real-time)
- Blazor (component-based UI)

ASP.NET Core is hosted by the **Kestrel** web server (built-in, cross-platform) and can sit behind reverse proxies like IIS, Nginx, or Apache in production.

## 1.3 ASP.NET Core vs ASP.NET Framework (MVC 5)

| Feature | ASP.NET Framework (MVC 5) | ASP.NET Core MVC |
|---------|--------------------------|-----------------|
| Platform | Windows only | Cross-platform |
| Hosting | IIS only | Kestrel, IIS, Nginx, Docker |
| Performance | Moderate | Very high |
| Dependency Injection | 3rd party (Unity, Autofac) | Built-in |
| Configuration | web.config (XML) | appsettings.json + env variables |
| Startup | Global.asax + Startup.cs | Program.cs (unified) |
| Side-by-side versioning | Not supported | Fully supported |
| Open source | Partial | Fully open-source |

---

## 🎤 Interview Questions — Section 1

**Q1: What is the difference between .NET Framework and .NET Core?**

> "The .NET Framework is Microsoft's original runtime, released in 2002, and is Windows-only with tight IIS coupling. .NET Core was released in 2016 as a complete rewrite — cross-platform, open-source, modular, and significantly faster. From .NET 5 onwards, both were unified under the single '.NET' brand. When choosing for new projects, I always recommend .NET 6+ or .NET 8 LTS because of its performance, cross-platform support, and long-term support guarantees."

**Q2: Why is ASP.NET Core preferred over older ASP.NET for new projects?**

> "Several reasons: First, performance — ASP.NET Core is among the fastest web frameworks globally. Second, cross-platform deployment — I can deploy to Linux containers on Azure or AWS, cutting hosting costs. Third, built-in Dependency Injection eliminates the need for third-party DI containers. Fourth, the unified configuration system using appsettings.json and environment variables is much cleaner than web.config. In a project I worked on, moving from MVC 5 to ASP.NET Core 6 reduced response times by roughly 40% with no code logic changes."

**Q3: What is Kestrel and why does it matter?**

> "Kestrel is ASP.NET Core's built-in, cross-platform web server. Unlike the .NET Framework which required IIS, ASP.NET Core apps can run directly on Kestrel, which makes them portable. In production, Kestrel typically sits behind a reverse proxy (IIS on Windows, Nginx on Linux) which handles SSL termination, load balancing, and static files. Understanding this matters because it explains why ASP.NET Core apps can run inside Docker containers without IIS."

---

# PART 2 — THE MVC DESIGN PATTERN (DEEP DIVE)

## 2.1 What is MVC?

MVC (Model-View-Controller) is a **software architectural pattern** that divides an application into three interconnected components. The primary goal is **Separation of Concerns (SoC)** — each component has one clearly defined responsibility.

```
┌─────────────────────────────────────────────────────────┐
│                    USER BROWSER                          │
│                  (sends HTTP Request)                    │
└──────────────────────────┬──────────────────────────────┘
                           │
                           ▼
┌─────────────────────────────────────────────────────────┐
│                    ROUTING ENGINE                        │
│        Determines which Controller.Action() to call      │
└──────────────────────────┬──────────────────────────────┘
                           │
                           ▼
┌──────────────────────────────────────────────────────────┐
│                     CONTROLLER                           │
│  • Receives user input                                   │
│  • Validates input                                       │
│  • Calls business logic (Model/Services)                 │
│  • Selects appropriate View                              │
│  • Passes data to View                                   │
└──────────┬──────────────────────────────┬───────────────┘
           │                              │
           ▼                              ▼
┌──────────────────┐           ┌──────────────────────────┐
│      MODEL       │           │          VIEW             │
│                  │           │                           │
│ • POCO Classes   │           │ • .cshtml Razor files     │
│ • Business Logic │           │ • HTML + C# mixed         │
│ • Data Access    │ ─────────▶│ • Receives Model data     │
│ • Validation     │           │ • Renders final HTML      │
│   Rules          │           │ • No business logic       │
└──────────────────┘           └──────────────────────────┘
                                           │
                                           ▼
                               ┌──────────────────────────┐
                               │      HTTP RESPONSE        │
                               │   (HTML sent to browser)  │
                               └──────────────────────────┘
```

## 2.2 The Model — In Depth

The "Model" in MVC is NOT just a data class. It encompasses:

### Domain Models
Simple POCO (Plain Old CLR Object) classes representing your business entities:
```csharp
public class Student {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime EnrollmentDate { get; set; }
}
```

### ViewModels
Classes created specifically for a View — containing exactly what that View needs, nothing more:
```csharp
// Not the domain model — a ViewModel tailored for the registration view
public class StudentRegistrationViewModel {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public List<SelectListItem> CourseOptions { get; set; }
}
```

### Why ViewModels matter:
- Domain models may have fields you don't want to expose (e.g., password hashes)
- A View may need data from multiple domain models
- Prevents over-posting attacks (mass assignment vulnerabilities)

### Binding Models / Input Models
Specifically for receiving POST data:
```csharp
public class CreateStudentRequest {
    [Required]
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
}
```

## 2.3 The View — In Depth

Views are responsible for **rendering UI** — they should contain zero business logic. A View:
- Is a `.cshtml` file (C# + HTML via Razor syntax)
- Receives data from the Controller via Model, ViewBag, ViewData, or TempData
- Can use Layout pages, Partial Views, and View Components
- Is rendered by the **Razor View Engine**

Key principle: **If a View has an `if` statement that makes a business decision, that logic is in the wrong place.** Views should only have display logic (show/hide based on data state).

## 2.4 The Controller — In Depth

The Controller is the **orchestrator**. It:
- Receives the HTTP request (via Action Methods)
- Extracts input from query strings, route data, form body, headers
- Validates input (using ModelState)
- Calls the appropriate service/repository/model
- Decides which View to return and what data to pass

```csharp
public class StudentController : Controller {

    private readonly IStudentService _studentService;

    // Dependency Injection — service injected via constructor
    public StudentController(IStudentService studentService) {
        _studentService = studentService;
    }

    // GET: /Student/Index
    public IActionResult Index() {
        var students = _studentService.GetAll();   // Call service (Model layer)
        return View(students);                      // Pass to View
    }

    // GET: /Student/Create
    public IActionResult Create() {
        return View();
    }

    // POST: /Student/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateStudentRequest request) {
        if (!ModelState.IsValid) {        // Validate input
            return View(request);         // Return form with errors
        }
        _studentService.Create(request);  // Delegate to service
        TempData["Success"] = "Student created!";
        return RedirectToAction("Index"); // Post-Redirect-Get pattern
    }
}
```

## 2.5 Advantages of MVC

1. **Separation of Concerns** — each layer has one job
2. **Testability** — Controllers can be unit tested without a browser
3. **Parallel Development** — UI team and backend team can work simultaneously
4. **Maintainability** — changing UI doesn't break business logic
5. **Reusability** — Models can be shared across multiple Views

---

## 🎤 Interview Questions — Section 2

**Q1: Explain the MVC pattern. What problem does it solve?**

> "MVC solves the problem of code becoming a tangled mess when UI, data, and logic are mixed together — what's sometimes called 'spaghetti code.' By separating into three layers: Model for data and business rules, View for rendering HTML, and Controller for orchestrating requests — each component has a single, clear responsibility. This makes large teams able to work in parallel; the frontend team owns Views while backend developers own Models and services. It also makes unit testing possible since Controllers can be tested in isolation without spinning up a browser."

**Q2: What is the difference between a Model and a ViewModel?**

> "A Model represents a domain entity — it mirrors your database table or business object. A ViewModel is specifically created for a particular View's needs. For example, a User domain model might have 20 properties including a password hash. If I'm building a profile page that only shows Name and Email, I'd create a UserProfileViewModel with just those two properties. ViewModels also help prevent over-posting attacks — if a user tampers with a form to submit fields not intended to be editable, the ViewModel ensures only the expected fields are bound."

**Q3: Why should Views contain no business logic?**

> "Because it violates separation of concerns and makes the application untestable. If a View decides whether to show a 'Refund' button based on order age and payment status — that's business logic that needs unit tests. Logic in .cshtml files can't easily be unit tested. The Controller or a service should make that decision and pass a simple boolean `ShowRefundButton = true` to the View. The View just renders what it's told. This also means designers can safely modify Views without risking breaking business rules."

**Q4: What is the Post-Redirect-Get (PRG) pattern?**

> "PRG is a web design pattern to prevent duplicate form submissions. After a successful POST request (like saving a form), instead of returning a View directly, you redirect to a GET action. This way, if the user hits F5 (browser refresh), they're refreshing the GET, not resubmitting the POST. In ASP.NET Core, this looks like: after saving data, call `return RedirectToAction('Index')`. I use TempData to pass success messages across this redirect since ViewBag doesn't survive redirects."

---

# PART 3 — PROGRAM.CS AND APPLICATION STARTUP

## 3.1 The Entry Point (ASP.NET Core 6+)

In ASP.NET Core 6+, all configuration lives in `Program.cs`. Before .NET 6, there was a separate `Startup.cs`. Understanding this file is critical.

```csharp
// Program.cs — the complete application bootstrap

var builder = WebApplication.CreateBuilder(args);
// builder = WebApplicationBuilder
// At this stage: configure SERVICES (dependency injection container)

// 1. Register MVC services
builder.Services.AddControllersWithViews();

// 2. Register your own services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// 3. Build the application
var app = builder.Build();
// app = WebApplication
// At this stage: configure MIDDLEWARE PIPELINE

// 4. Configure error handling
if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();   // Detailed error page in dev
} else {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 5. HTTPS redirection
app.UseHttpsRedirection();

// 6. Serve static files from wwwroot
app.UseStaticFiles();

// 7. Routing — must come before Auth
app.UseRouting();

// 8. Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// 9. Map controller routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

## 3.2 The Two Phases: Services vs Middleware

This is the most important conceptual distinction in Program.cs:

| Phase | Object | Purpose |
|-------|--------|---------|
| **Services** | `builder.Services` | Register classes for Dependency Injection |
| **Middleware** | `app.Use...()` | Define how each HTTP request is processed |

**Services** are registered BEFORE `builder.Build()`.
**Middleware** is configured AFTER `builder.Build()`.

## 3.3 What is the Middleware Pipeline?

Middleware is software assembled into a pipeline to handle requests and responses. Each middleware component:
- Receives the HTTP context
- Either handles the request itself OR passes it to the next component
- Can process the response on the way back out

```
Request ──▶ HTTPS Redirection ──▶ Static Files ──▶ Routing ──▶ Auth ──▶ Endpoints
                                                                             │
Response ◀──────────────────────────────────────────────────────────────────┘
```

Think of it like a chain of responsibility pattern. Each `app.Use*()` call adds a link.

**Order matters critically!** `UseAuthentication()` must come before `UseAuthorization()`. `UseRouting()` must come before `UseAuthorization()`. Getting the order wrong causes subtle bugs.

## 3.4 Configuration System

```csharp
// appsettings.json
{
  "ConnectionStrings": {
    "Default": "Server=.;Database=MyApp;Trusted_Connection=true"
  },
  "AppSettings": {
    "MaxPageSize": 50,
    "AllowedHosts": "myapp.com"
  }
}

// appsettings.Development.json — overrides for dev environment
{
  "Logging": {
    "LogLevel": { "Default": "Debug" }
  }
}

// Reading in code
var connectionString = builder.Configuration.GetConnectionString("Default");
var maxPage = builder.Configuration.GetValue<int>("AppSettings:MaxPageSize");
```

Environment variables override appsettings, which enables different configs per deployment (dev/staging/prod) without changing code.

---

## 🎤 Interview Questions — Section 3

**Q1: What is the difference between `builder.Services` and `app.Use*()` in Program.cs?**

> "`builder.Services` is the **service registration** phase — this is where you tell the dependency injection container what classes are available and how they should be instantiated. For example, `AddScoped<IStudentService, StudentService>()` registers a service. `app.Use*()` is the **middleware pipeline** phase — this defines the order in which incoming HTTP requests are processed. The key rule is: services are registered before `builder.Build()`, middleware is configured after. Mixing up the order of middleware registration is a common source of bugs, like putting `UseAuthentication()` after endpoint mapping."

**Q2: What is middleware? Give a real-world analogy.**

> "Middleware is a chain of components, each of which can inspect, modify, or short-circuit an HTTP request/response. A good analogy is airport security — your luggage passes through multiple checkpoints: X-ray, customs, weight check. Each checkpoint can pass it forward or stop it. In ASP.NET Core, a request passes through HTTPS redirect, static file serving, routing, authentication, authorization, and finally hits the controller. The response then travels back through the same chain in reverse. You can also write custom middleware — for example, I've written middleware that adds a correlation ID to every request for distributed tracing."

**Q3: How does ASP.NET Core handle different environments (Development vs Production)?**

> "ASP.NET Core uses the `ASPNETCORE_ENVIRONMENT` environment variable to determine the current environment. The configuration system automatically layers: `appsettings.json` as the base, then `appsettings.{Environment}.json` overrides it, then environment variables override that. In code, you check `app.Environment.IsDevelopment()` to conditionally enable the developer exception page (which shows stack traces). In production, you never want that — instead you use `UseExceptionHandler('/Home/Error')` to show a friendly error page. This means I can have verbose SQL logging in development and silent/alerting-only in production without code changes."

---

# PART 4 — ROUTING (DEEP DIVE)

## 4.1 What is Routing?

Routing is the mechanism that **maps incoming URL paths to Controller Action Methods**. ASP.NET Core has two routing approaches that can be combined.

## 4.2 Conventional Routing

Defined in `Program.cs` using a URL pattern template:

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

Pattern breakdown:
- `{controller=Home}` — Controller name, defaults to "Home"
- `{action=Index}` — Action method name, defaults to "Index"
- `{id?}` — Optional route parameter

URL mapping examples:
```
/                       → HomeController.Index()
/Student                → StudentController.Index()
/Student/Create         → StudentController.Create()
/Student/Edit/5         → StudentController.Edit(id: 5)
/Student/Delete/10      → StudentController.Delete(id: 10)
```

### Multiple Named Routes
```csharp
// Area route — for large apps with sections (Admin, User, etc.)
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

## 4.3 Attribute Routing

More explicit — you decorate Controllers and Actions directly:

```csharp
[Route("api/students")]           // Base route for the controller
public class StudentController : Controller {

    [Route("")]                   // GET api/students
    [HttpGet]
    public IActionResult GetAll() { ... }

    [Route("{id:int}")]           // GET api/students/5
    [HttpGet]
    public IActionResult GetById(int id) { ... }

    [Route("search")]             // GET api/students/search?name=ravi
    [HttpGet]
    public IActionResult Search(string name) { ... }

    [HttpPost]                    // POST api/students
    public IActionResult Create([FromBody] CreateStudentRequest req) { ... }
}
```

### Route Constraints
```csharp
[Route("{id:int}")]           // id must be an integer
[Route("{name:alpha}")]       // name must be alphabetic only
[Route("{id:int:min(1)}")]    // id must be int >= 1
[Route("{date:datetime}")]    // must be a valid datetime
[Route("{id:guid}")]          // must be a GUID
```

## 4.4 How Route Resolution Works

When a request arrives, ASP.NET Core goes through the route table **in order** and picks the first match. This is why order of route registration matters.

```
Request: GET /Student/Edit/5

Step 1: Does it match "areas" route?  → No (no area segment)
Step 2: Does it match "default" route? → Yes!
        controller = "Student"
        action = "Edit"
        id = "5"
Step 3: Find StudentController class
Step 4: Find Edit(int id) method
Step 5: Execute it
```

## 4.5 Action Results — What Can a Controller Return?

| Return Type | Class | When to Use |
|-------------|-------|------------|
| View | `ViewResult` | Return a rendered HTML View |
| Partial View | `PartialViewResult` | AJAX partial page updates |
| JSON | `JsonResult` | Return JSON data |
| Redirect | `RedirectToActionResult` | Redirect after POST |
| File | `FileResult` | Download a file |
| 404 | `NotFoundResult` | Resource not found |
| 200 OK | `OkResult` | Success, no data |
| 400 Bad Request | `BadRequestResult` | Invalid input |
| Status Code | `StatusCodeResult` | Custom HTTP status |

```csharp
// All valid return types from Action Methods:
return View();                                    // 200 + render view
return View("CustomViewName", model);             // Specific view with data
return PartialView("_StudentCard", student);      // Partial view
return Json(new { success = true });              // JSON response
return RedirectToAction("Index");                 // 302 redirect
return RedirectToAction("Edit", new { id = 5 }); // Redirect with params
return NotFound();                                // 404
return BadRequest(ModelState);                    // 400 with errors
return Content("Plain text response");            // Plain text
return File(fileBytes, "application/pdf", "report.pdf"); // Download
```

---

## 🎤 Interview Questions — Section 4

**Q1: What is the difference between Conventional Routing and Attribute Routing?**

> "Conventional routing defines URL patterns in one central place — `Program.cs` — using a template like `{controller}/{action}/{id?}`. It's good for simple, uniform URL structures. Attribute routing decorates each Controller and Action with `[Route]` attributes, giving you precise control over each URL. Attribute routing is my preference for APIs because each endpoint's URL is explicit and visible right where the method is defined — no need to mentally translate between the route table and the code. For web applications with standard CRUD patterns, conventional routing is simpler to manage."

**Q2: What are route constraints and why would you use them?**

> "Route constraints restrict which URL values can match a route parameter. For example, `[Route('{id:int}')]` ensures the `id` segment only matches if it's a valid integer — so `/students/abc` would 404 immediately instead of entering the action and throwing a conversion exception. This provides a cleaner API surface and improves security by preventing unexpected input types from reaching action methods. I use constraints heavily in RESTful APIs — guid constraints for resource IDs, int constraints for pagination parameters."

**Q3: What is `IActionResult` and why does it return that instead of a concrete type?**

> "`IActionResult` is an interface that all action result types implement — `ViewResult`, `JsonResult`, `RedirectResult`, etc. Returning `IActionResult` instead of a concrete type gives your action method flexibility: one code path can return a View, another can redirect, another can return a 404. If you hard-coded the return type as `ViewResult`, you couldn't redirect from that method. It also makes unit testing easier — you can assert against `IActionResult` and then cast to check the specific type."

---

# PART 5 — CONTROLLERS IN DEPTH

## 5.1 Controller Anatomy

```csharp
using Microsoft.AspNetCore.Mvc;

// Convention: Class name must end with "Controller"
// OR inherit from Controller / ControllerBase
public class StudentController : Controller {

    // ─── Constructor Injection ──────────────────────────
    private readonly IStudentRepository _repo;
    private readonly ILogger<StudentController> _logger;

    public StudentController(IStudentRepository repo,
                             ILogger<StudentController> logger) {
        _repo = repo;
        _logger = logger;
    }

    // ─── Action Methods ─────────────────────────────────

    // Responds to GET /Student OR GET /Student/Index
    public IActionResult Index() {
        var students = _repo.GetAll();
        return View(students);
    }

    // Responds to GET /Student/Details/5
    public IActionResult Details(int id) {
        var student = _repo.GetById(id);
        if (student == null) return NotFound();
        return View(student);
    }

    // GET: /Student/Create — show the empty form
    public IActionResult Create() {
        return View();
    }

    // POST: /Student/Create — handle form submission
    [HttpPost]
    [ValidateAntiForgeryToken]   // CSRF protection
    public IActionResult Create(StudentViewModel model) {
        if (!ModelState.IsValid) {
            return View(model);  // Return form with validation errors
        }

        try {
            _repo.Add(model);
            _logger.LogInformation("Student {Name} created", model.Name);
            TempData["SuccessMessage"] = "Student added successfully!";
            return RedirectToAction(nameof(Index));  // PRG Pattern
        }
        catch (Exception ex) {
            _logger.LogError(ex, "Error creating student");
            ModelState.AddModelError("", "An error occurred. Please try again.");
            return View(model);
        }
    }
}
```

## 5.2 HTTP Verb Attributes

```csharp
[HttpGet]     // GET  — retrieve data (default if no attribute)
[HttpPost]    // POST — submit form data, create resource
[HttpPut]     // PUT  — full update (replace entire resource)
[HttpPatch]   // PATCH — partial update
[HttpDelete]  // DELETE — remove resource
```

## 5.3 Parameter Binding Sources

ASP.NET Core can bind action parameters from multiple sources:

```csharp
// From Route: /Student/Edit/5
public IActionResult Edit([FromRoute] int id) { }

// From Query String: /Student/Search?name=ravi&page=2
public IActionResult Search([FromQuery] string name, [FromQuery] int page) { }

// From Form Body (HTML form POST)
public IActionResult Create([FromForm] StudentViewModel model) { }

// From Request Body (JSON API)
public IActionResult Create([FromBody] CreateStudentDto dto) { }

// From HTTP Header
public IActionResult GetWithAuth([FromHeader(Name="Authorization")] string token) { }

// ASP.NET Core figures it out automatically (no attribute needed for simple scenarios)
public IActionResult Edit(int id, StudentViewModel model) { }
// id → from route, model → from form body (inferred)
```

## 5.4 Filters — Cross-Cutting Concerns

Filters run before or after action methods and are used for:

```csharp
// Authorization filter — runs first
[Authorize]
[Authorize(Roles = "Admin")]

// Action filter — runs before and after action
[ValidateAntiForgeryToken]

// Exception filter — catches unhandled exceptions
// Result filter — runs before/after result execution

// Creating custom action filter:
public class LogActionFilter : ActionFilterAttribute {
    public override void OnActionExecuting(ActionExecutingContext context) {
        // Runs BEFORE action method
        Console.WriteLine($"Executing: {context.ActionDescriptor.DisplayName}");
    }

    public override void OnActionExecuted(ActionExecutedContext context) {
        // Runs AFTER action method
        Console.WriteLine("Execution complete");
    }
}

// Apply it:
[LogActionFilter]
public IActionResult Index() { ... }
```

---

## 🎤 Interview Questions — Section 5

**Q1: What is ModelState and how do you use it?**

> "ModelState is a dictionary inside the Controller that tracks the state of model binding and validation. When the framework binds form data to a model, it runs all Data Annotation validators and records any errors in ModelState. `ModelState.IsValid` returns true only when all validations pass. In practice, I always check `if (!ModelState.IsValid)` at the start of POST actions and return the View with the model if validation fails — this redisplays the form with inline error messages. You can also manually add errors with `ModelState.AddModelError('PropertyName', 'Error message')` for custom business rule violations."

**Q2: What is `[ValidateAntiForgeryToken]` and why is it important?**

> "It's CSRF (Cross-Site Request Forgery) protection. Without it, a malicious website could trick a logged-in user into submitting a form to your application unknowingly — because the browser automatically includes session cookies with any request to your domain. ASP.NET Core generates a hidden anti-forgery token in forms via `@Html.AntiForgeryToken()` or automatically with Tag Helpers. The server validates this token on POST. Since the malicious site can't read the token (same-origin policy), the forged request fails. I apply it to all POST, PUT, DELETE actions in web applications."

**Q3: What is the difference between `RedirectToAction` and `RedirectToRoute`?**

> "`RedirectToAction` generates a redirect URL based on Controller and Action names — `RedirectToAction('Index', 'Student')` sends the user to `/Student/Index`. `RedirectToRoute` generates a redirect based on route name — `RedirectToRoute('default', new { controller='Student', action='Index' })`. I prefer `RedirectToAction` because it's more readable and refactor-friendly — if you rename the route pattern, `RedirectToRoute` can break. `RedirectToAction` also compiles cleanly with `nameof()`: `RedirectToAction(nameof(Index))`."

---

# PART 6 — RAZOR VIEW ENGINE (DEEP DIVE)

## 6.1 What is Razor?

Razor is ASP.NET Core's **server-side templating engine** for generating HTML. It allows you to seamlessly mix C# code with HTML markup using the `@` symbol as the transition character.

Razor files have the `.cshtml` extension and are compiled into C# classes at build time (or on first request in development). This compilation means Razor has **full IntelliSense support** and **compile-time error checking**.

## 6.2 Razor Syntax — Complete Reference

```html
@* This is a Razor comment (not sent to browser) *@

@* ── Variables ─────────────────────────────────── *@
@{
    var name = "Ravi";
    var age = 22;
    var isAdmin = true;
    DateTime today = DateTime.Now;
}

@* ── Inline Expressions ─────────────────────────── *@
<p>Name: @name</p>
<p>Today: @today.ToShortDateString()</p>
<p>Upper: @name.ToUpper()</p>

@* ── HTML Encoding (automatic) ──────────────────── *@
@* If name = "<script>alert('xss')</script>", @name is safe *@
<p>@name</p>                    @* HTML-encoded — safe *@
<p>@Html.Raw(name)</p>         @* NOT encoded — dangerous, use sparingly *@

@* ── Conditionals ───────────────────────────────── *@
@if (isAdmin) {
    <span class="badge">Admin</span>
} else if (age >= 18) {
    <span>Adult User</span>
} else {
    <span>Minor</span>
}

@* ── Switch ─────────────────────────────────────── *@
@switch (age) {
    case 18:
        <p>Just 18</p>
        break;
    default:
        <p>Age: @age</p>
        break;
}

@* ── Loops ──────────────────────────────────────── *@
@for (int i = 1; i <= 5; i++) {
    <li>Item @i</li>
}

@foreach (var student in Model) {
    <tr>
        <td>@student.Name</td>
        <td>@student.Email</td>
    </tr>
}

@while (condition) { ... }

@* ── Using Statements ────────────────────────────── *@
@using (Html.BeginForm()) {
    @* form content *@
}
```

## 6.3 Layouts — The Master Page

A Layout is a shared template used across multiple views. It defines the common structure (header, navigation, footer):

```html
@* Views/Shared/_Layout.cshtml *@
<!DOCTYPE html>
<html>
<head>
    <title>@ViewData["Title"] - My App</title>
    <link rel="stylesheet" href="~/css/site.css" />
</head>
<body>
    <header>
        <nav><!-- navigation here --></nav>
    </header>

    <main>
        @RenderBody()      @* ← THIS is where individual views are injected *@
    </main>

    <footer>
        <p>© 2024 My App</p>
    </footer>

    @* Scripts section — views can inject scripts here *@
    @RenderSection("Scripts", required: false)
</body>
</html>
```

```html
@* Views/Home/Index.cshtml *@
@{
    Layout = "_Layout";           // Use _Layout.cshtml
    ViewData["Title"] = "Home";   // Sets the page title in layout
}

<h1>Welcome to the homepage!</h1>

@* Inject scripts into the layout's Scripts section *@
@section Scripts {
    <script src="~/js/home.js"></script>
}
```

### _ViewStart.cshtml

Instead of specifying `Layout = "_Layout"` in every View, you put it in `_ViewStart.cshtml`:
```csharp
@* Views/_ViewStart.cshtml — applies to all views in this folder *@
@{
    Layout = "_Layout";
}
```

### _ViewImports.cshtml

For shared `@using` statements and Tag Helper imports:
```csharp
@* Views/_ViewImports.cshtml *@
@using MyApp.Models
@using MyApp.ViewModels
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

## 6.4 Partial Views

Partial Views are reusable View components — think of them like includes or sub-templates:

```html
@* Views/Shared/_StudentCard.cshtml *@
@model Student

<div class="card">
    <h3>@Model.Name</h3>
    <p>@Model.Email</p>
</div>
```

```html
@* Using in a parent view *@

@* Method 1: Html helper *@
@Html.Partial("_StudentCard", student)

@* Method 2: Async (preferred) *@
@await Html.PartialAsync("_StudentCard", student)

@* Method 3: Tag Helper (most modern) *@
<partial name="_StudentCard" model="student" />
```

## 6.5 View Components (Advanced Partial Views)

View Components are like mini-controllers + views. Use them when the partial needs its own logic (e.g., fetching data from DB):

```csharp
// ViewComponents/RecentStudentsViewComponent.cs
public class RecentStudentsViewComponent : ViewComponent {
    private readonly IStudentRepository _repo;

    public RecentStudentsViewComponent(IStudentRepository repo) {
        _repo = repo;
    }

    public async Task<IViewComponentResult> InvokeAsync(int count) {
        var students = await _repo.GetRecentAsync(count);
        return View(students);  // Renders Views/Shared/Components/RecentStudents/Default.cshtml
    }
}

// In any view:
@await Component.InvokeAsync("RecentStudents", new { count = 5 })
// Or with Tag Helper:
<vc:recent-students count="5"></vc:recent-students>
```

---

## 🎤 Interview Questions — Section 6

**Q1: What is the difference between `_Layout.cshtml`, `_ViewStart.cshtml`, and `_ViewImports.cshtml`?**

> "They serve three distinct purposes. `_Layout.cshtml` is the master template — it defines the outer HTML structure (head, nav, footer) and uses `@RenderBody()` to inject each View's content. `_ViewStart.cshtml` runs before every View in its folder hierarchy and is typically used to set the `Layout` property so you don't repeat `@{ Layout = '_Layout'; }` in every View. `_ViewImports.cshtml` provides shared namespace imports and Tag Helper registrations — instead of adding `@using MyApp.Models` to every View, you put it once in `_ViewImports.cshtml`. Together, they eliminate boilerplate repetition."

**Q2: What is the difference between a Partial View and a View Component?**

> "A Partial View is a simple reusable View fragment — it receives data from the parent view and renders HTML. It cannot fetch its own data. A View Component is a more powerful abstraction that has its own 'mini-controller' class which can have constructor-injected services, fetch data from a database, and then render a view. Use Partial Views for simple display reuse; use View Components when the component needs independent data access — for example, a sidebar showing 'Recent Posts' that needs a DB query regardless of which page is hosting it."

**Q3: What is `@Html.Raw()` and when is it dangerous?**

> "`@Html.Raw()` outputs a string directly to the HTML without encoding it. Normally, `@variable` HTML-encodes the output — so `<script>alert('xss')</script>` becomes `&lt;script&gt;...&lt;/script&gt;` which is safe text. With `@Html.Raw()`, that script would actually execute. You should only use `@Html.Raw()` when you have HTML that you've generated yourself and trust completely — for example, a rich-text editor's output that you've already sanitized server-side using a library like HtmlSanitizer. Using it on user input is a direct XSS vulnerability."

---

# PART 7 — DATA PASSING (MASTER REFERENCE)

## 7.1 Four Mechanisms — When to Use What

### Mechanism 1: Strongly-Typed Model (Best Practice)

This is the recommended, default approach for passing data to Views.

**Controller:**
```csharp
public IActionResult Index() {
    var model = new StudentListViewModel {
        Students = _repo.GetAll(),
        TotalCount = _repo.Count(),
        PageNumber = 1
    };
    return View(model);
}
```

**View:**
```html
@model StudentListViewModel

<h2>Students (@Model.TotalCount total)</h2>
@foreach (var s in Model.Students) {
    <p>@s.Name</p>
}
```

**Why it's the best:**
- IntelliSense support in View
- Compile-time error checking
- Refactoring tools work correctly
- Self-documenting

### Mechanism 2: ViewBag (Dynamic, Loose)

ViewBag uses C#'s `dynamic` keyword — no compile-time type checking.

```csharp
// Controller
ViewBag.Title = "Student List";
ViewBag.Count = 42;
ViewBag.IsLoggedIn = true;
ViewBag.Categories = new List<string> { "Math", "Science" };
```

```html
@* View — no @model directive needed *@
<h1>@ViewBag.Title</h1>
<p>Total: @ViewBag.Count</p>

@* Requires cast for complex types *@
@foreach (var cat in (List<string>)ViewBag.Categories) {
    <li>@cat</li>
}
```

**Pitfalls:**
- If you typo `ViewBag.Titl` in the view, it returns null silently at runtime
- No IntelliSense
- Can't be unit tested easily

### Mechanism 3: ViewData (Dictionary)

ViewData is a `ViewDataDictionary` — similar to ViewBag but dictionary syntax:

```csharp
// Controller
ViewData["Title"] = "Student List";
ViewData["Count"] = 42;
```

```html
@* View *@
<h1>@ViewData["Title"]</h1>

@* Requires explicit cast *@
<p>Count: @((int)ViewData["Count"])</p>
```

**Note:** ViewBag is just a dynamic wrapper over ViewData. They share the same underlying dictionary — `ViewBag.Title` and `ViewData["Title"]` access the same value.

### Mechanism 4: TempData (Cross-Request Persistence)

TempData survives **one redirect** — it's stored in the session and cleared after being read.

```csharp
// Controller — POST action
[HttpPost]
public IActionResult Create(StudentViewModel model) {
    _repo.Add(model);
    TempData["SuccessMessage"] = "Student created successfully!";
    TempData["CreatedId"] = newStudent.Id;   // Integers work too
    return RedirectToAction("Index");         // Redirect happens here
}

// Controller — GET action (after redirect)
public IActionResult Index() {
    // TempData["SuccessMessage"] is still available here (first read)
    return View();
}
```

```html
@* View *@
@if (TempData["SuccessMessage"] != null) {
    <div class="alert alert-success">
        @TempData["SuccessMessage"]
    </div>
}
```

**TempData.Keep() and TempData.Peek():**
```csharp
// Peek — read without marking for deletion
var msg = TempData.Peek("SuccessMessage");

// Keep — retain for another request
TempData.Keep("SuccessMessage");
```

## 7.2 Complete Comparison Table

| Feature | Model | ViewBag | ViewData | TempData |
|---------|-------|---------|----------|----------|
| Type Safety | ✅ Strong | ❌ Dynamic | ❌ Object | ❌ Object |
| IntelliSense | ✅ Full | ❌ None | ❌ None | ❌ None |
| Survives Redirect | ❌ | ❌ | ❌ | ✅ (once) |
| Null-safe | ✅ | ⚠️ Silently null | ⚠️ | ⚠️ |
| Unit Testable | ✅ | ⚠️ Harder | ⚠️ | ⚠️ |
| Best Use | Primary data | Quick values | Legacy | Flash messages |
| Storage | Request | Request | Request | Session/Cookie |

---

## 🎤 Interview Questions — Section 7

**Q1: Which data passing mechanism do you prefer and why?**

> "Strongly-typed Models, without question. They provide IntelliSense in Views, compile-time error checking, and make the code self-documenting — anyone reading the View knows exactly what data it expects just from the `@model` directive. For supplementary data that doesn't warrant its own model property — like a page title or a success flag — I'll use ViewBag sparingly. For flash messages after redirects, TempData is the right choice. I avoid ViewData entirely since ViewBag provides the same capability with cleaner syntax."

**Q2: TempData survives a redirect — how exactly does that work under the hood?**

> "TempData is backed by a storage provider — by default it uses the session. When you set a TempData value, it's serialized and saved to the session store. After the redirect, on the next request, ASP.NET Core loads TempData from the session and marks each accessed key for deletion. After the response is sent, those marked keys are removed. This is why TempData only survives one request after being read. If you need to keep it longer, you call `TempData.Keep('KeyName')` which removes the deletion marker."

**Q3: What's the risk of using ViewBag extensively?**

> "The main risks are runtime errors instead of compile-time errors, and poor maintainability. If I rename a property from `ViewBag.Studens` (typo) to `ViewBag.Students`, the view silently gets null and renders nothing — no warning at build time. With a typed model, the compiler catches it immediately. In a large team, ViewBag-heavy code also becomes hard to maintain because there's no contract — Views can access any ViewBag key without the controller necessarily setting it. I treat ViewBag as a 'quick hack' tool and refactor to typed ViewModels for anything beyond a simple string or count."

---

# PART 8 — MODEL BINDING & FORM HANDLING

## 8.1 What is Model Binding?

Model Binding is the automatic process by which ASP.NET Core maps incoming HTTP request data to action method parameters. It eliminates the need to manually parse `Request.Form` or `Request.QueryString`.

## 8.2 Binding Sources — Priority Order

When ASP.NET Core binds a parameter, it checks these sources in order:
1. **Route data** — `{id}` from the URL pattern
2. **Query string** — `?name=ravi&page=2`
3. **Form body** — HTML form POST data

```csharp
// URL: /Student/Edit/5?section=details
// Form Body: name=Ravi&email=ravi@test.com

public IActionResult Edit(
    int id,              // ← from route (id=5)
    string section,      // ← from query string (section=details)
    StudentViewModel model  // ← from form body (complex type)
) { }
```

## 8.3 Complex Type Binding (Forms)

```csharp
public class AddressViewModel {
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
}

public class StudentViewModel {
    public string Name { get; set; }
    public string Email { get; set; }
    public AddressViewModel Address { get; set; }   // Nested complex type
}
```

```html
<!-- HTML Form — dot notation for nested properties -->
<input name="Name" />
<input name="Email" />
<input name="Address.Street" />    @* ← dot notation for nested *@
<input name="Address.City" />
<input name="Address.PostalCode" />
```

ASP.NET Core will correctly populate `model.Address.Street` from `Address.Street` form field.

## 8.4 Collection Binding

```csharp
public class OrderViewModel {
    public List<OrderItemViewModel> Items { get; set; }
}
```

```html
<!-- Index-based binding for collections -->
<input name="Items[0].ProductName" value="Widget" />
<input name="Items[0].Quantity" value="2" />
<input name="Items[1].ProductName" value="Gadget" />
<input name="Items[1].Quantity" value="1" />
```

## 8.5 GET vs POST — Complete Example

```csharp
// SEARCH FORM — GET request (parameters in query string)
// URL after submit: /Student/Search?name=Ravi&courseId=3

[HttpGet]
public IActionResult Search(string name, int? courseId) {
    var results = _repo.Search(name, courseId);
    return View(results);
}
```

```html
<!-- GET Form -->
<form method="get" action="/Student/Search">
    <input type="text" name="name" placeholder="Search name" />
    <select name="courseId">
        <option value="1">Math</option>
        <option value="2">Science</option>
    </select>
    <button type="submit">Search</button>
</form>
```

```csharp
// REGISTRATION FORM — POST request (body, not URL)
[HttpGet]
public IActionResult Register() {
    return View(new StudentRegistrationViewModel());
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Register(StudentRegistrationViewModel model) {
    if (!ModelState.IsValid) {
        return View(model);    // Redisplay form with errors
    }

    // Check business rules
    if (_repo.EmailExists(model.Email)) {
        ModelState.AddModelError(nameof(model.Email), "Email already registered");
        return View(model);
    }

    _repo.Register(model);
    TempData["Success"] = "Registration successful!";
    return RedirectToAction("Login");
}
```

## 8.6 [Bind] Attribute — Preventing Over-Posting

```csharp
public class StudentViewModel {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsAdmin { get; set; }   // Should NOT be user-editable!
}

// WRONG — user could POST IsAdmin=true and become an admin
[HttpPost]
public IActionResult Edit(StudentViewModel model) { }

// CORRECT — explicitly whitelist bindable properties
[HttpPost]
public IActionResult Edit([Bind("Name,Email")] StudentViewModel model) { }

// EVEN BETTER — use a dedicated BindingModel/InputModel
public class EditStudentRequest {
    public string Name { get; set; }    // Only the fields users can change
    public string Email { get; set; }
    // IsAdmin is NOT here — can't be bound at all
}
```

---

## 🎤 Interview Questions — Section 8

**Q1: What is over-posting and how do you prevent it?**

> "Over-posting, also called mass assignment, is when a malicious user submits additional form fields that get bound to model properties they shouldn't be able to modify — for example, submitting `IsAdmin=true` or `Salary=999999` in a form that was only supposed to accept Name and Email. You prevent it in two ways: using `[Bind('Name,Email')]` attribute to whitelist bindable properties, or — my preferred approach — creating dedicated Input/Request models that only contain properties you expect from the user. The domain model never hits the action parameter directly. This is a security-critical practice."

**Q2: How does model binding work with complex nested objects?**

> "ASP.NET Core's model binder uses property name matching with dot notation. For a `StudentViewModel` that has an `Address` property of type `AddressViewModel`, form fields named `Address.Street`, `Address.City` etc. will be automatically mapped to `model.Address.Street` and `model.Address.City`. The binder recursively instantiates nested types. For collections, it expects index-based notation like `Items[0].Name`, `Items[1].Name`. This is important to understand when building complex forms or when designing APIs that accept nested JSON."

**Q3: When should you use GET vs POST for forms?**

> "GET is appropriate for **read operations** — search forms, filters, pagination — because the query parameters appear in the URL, making results bookmarkable and shareable. Search engines can index them. POST is for **state-changing operations** — creating, updating, deleting — because: the data goes in the request body (not URL), sensitive data like passwords isn't logged in server access logs or browser history, and POST requests aren't accidentally re-executed if the user bookmarks the URL. Never use GET for operations that change server state."

---

# PART 9 — DATA ANNOTATIONS & VALIDATION

## 9.1 What are Data Annotations?

Data Annotations are attributes applied to model properties that define validation rules, display behavior, and data type hints. They live in `System.ComponentModel.DataAnnotations`.

```csharp
using System.ComponentModel.DataAnnotations;

public class StudentRegistrationViewModel {

    // ── Required ─────────────────────────────────────────────
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Full Name")]              // Display label in views
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Name must be 2-100 characters")]
    public string Name { get; set; }

    // ── Email ────────────────────────────────────────────────
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    // ── Numeric Range ─────────────────────────────────────────
    [Required]
    [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
    public int Age { get; set; }

    // ── Password ─────────────────────────────────────────────
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$",
        ErrorMessage = "Password must contain uppercase letter and number")]
    public string Password { get; set; }

    // ── Compare (Confirm Password) ────────────────────────────
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; }

    // ── Phone ─────────────────────────────────────────────────
    [Phone]
    public string PhoneNumber { get; set; }

    // ── URL ───────────────────────────────────────────────────
    [Url]
    public string Website { get; set; }

    // ── Date ─────────────────────────────────────────────────
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; set; }

    // ── Credit Card ───────────────────────────────────────────
    [CreditCard]
    public string CardNumber { get; set; }
}
```

## 9.2 Server-Side vs Client-Side Validation

ASP.NET Core validates on the **server** automatically. For client-side (before form submit), you include the jQuery Validation library:

```html
@* In your layout or view — enables client-side validation *@
<script src="~/lib/jquery/jquery.min.js"></script>
<script src="~/lib/jquery-validation/jquery.validate.min.js"></script>
<script src="~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"></script>
```

The `asp-validation-for` Tag Helper generates the client-side validation attributes automatically:
```html
<input asp-for="Email" class="form-control" />
<span asp-validation-for="Email" class="text-danger"></span>
```

**Critical rule:** Always validate server-side regardless of client-side validation. Client-side can be bypassed.

## 9.3 Custom Validation Attributes

```csharp
// Custom validator example — must be a future date
public class FutureDateAttribute : ValidationAttribute {
    protected override ValidationResult IsValid(
        object value, ValidationContext validationContext) {

        if (value is DateTime date) {
            if (date > DateTime.Now) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Date must be in the future");
        }
        return new ValidationResult("Invalid date");
    }
}

// Usage:
[FutureDate]
public DateTime EventDate { get; set; }
```

## 9.4 IValidatableObject — Complex Business Rule Validation

When validation depends on multiple properties together:

```csharp
public class BookingViewModel : IValidatableObject {
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int Guests { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context) {
        // Rule: CheckOut must be after CheckIn
        if (CheckOut <= CheckIn) {
            yield return new ValidationResult(
                "Check-out must be after check-in",
                new[] { nameof(CheckOut) });
        }

        // Rule: Maximum 7-day stay for >4 guests
        if (Guests > 4 && (CheckOut - CheckIn).Days > 7) {
            yield return new ValidationResult(
                "Large groups cannot book more than 7 nights");
        }
    }
}
```

---

## 🎤 Interview Questions — Section 9

**Q1: What's the difference between client-side and server-side validation? Which is more important?**

> "Server-side validation is more important — it's non-negotiable because client-side can always be bypassed. A user can disable JavaScript, use browser developer tools to remove validation attributes, or craft raw HTTP requests with tools like Postman or curl. Server-side validation in ASP.NET Core runs automatically when model binding occurs — Data Annotations are evaluated and `ModelState.IsValid` reflects the result. Client-side validation improves UX by giving instant feedback without a round-trip to the server. You should have both, but server-side is the security backstop."

**Q2: When would you use IValidatableObject instead of Data Annotations?**

> "When your validation logic involves comparing multiple properties of the same model — cross-property validation. Data Annotations validate each property in isolation. For example, validating that a checkout date is after a check-in date, or that a password and confirm-password match (the `[Compare]` attribute is one built-in exception). `IValidatableObject` is also appropriate when validation needs to hit an external resource — like checking if a username is already taken in the database. Though for that scenario, I usually add manual errors to ModelState in the controller after checking the DB, rather than injecting repository into the model."

**Q3: How do you display validation errors in a View?**

> "ASP.NET Core provides several ways. The `asp-validation-for='PropertyName'` Tag Helper renders validation messages for a specific property. `asp-validation-summary='All'` renders a summary of all errors at the top of the form. In combination with unobtrusive jQuery validation libraries, these also work client-side. I always add `input-validation-error` CSS class styling to highlight invalid fields. The key is that when `ModelState.IsValid` is false in the controller, you return `View(model)` — this passes the existing ModelState errors back to the view so they display inline."

---

# PART 10 — HTML HELPERS (COMPLETE REFERENCE)

## 10.1 What are HTML Helpers?

HTML Helpers are C# extension methods on `HtmlHelper` that generate HTML markup. They abstract away raw HTML strings and provide a programmatic way to generate form controls.

## 10.2 Standard (Loosely-Typed) HTML Helpers

These take a **string** as the field name — no compile-time checking:

```html
@using (Html.BeginForm("Register", "Student", FormMethod.Post)) {
    @Html.AntiForgeryToken()

    @* Label *@
    @Html.Label("Name", "Full Name:")

    @* Text input *@
    @Html.TextBox("Name", "", new { @class = "form-control", placeholder = "Enter name" })

    @* Password *@
    @Html.Password("Password", "", new { @class = "form-control" })

    @* TextArea *@
    @Html.TextArea("Description", "", 5, 50, new { @class = "form-control" })

    @* CheckBox *@
    @Html.CheckBox("IsActive", true)

    @* Radio Button *@
    @Html.RadioButton("Gender", "Male") Male
    @Html.RadioButton("Gender", "Female") Female

    @* Dropdown *@
    @Html.DropDownList("CourseId",
        new SelectList(ViewBag.Courses, "Id", "Name"),
        "-- Select Course --",
        new { @class = "form-select" })

    @* Multi-select *@
    @Html.ListBox("Tags",
        new MultiSelectList(ViewBag.Tags, "Id", "Name"),
        new { @class = "form-control" })

    @* Hidden field *@
    @Html.Hidden("UserId", 42)

    @* Validation message for a field *@
    @Html.ValidationMessage("Name", "", new { @class = "text-danger" })

    @* Summary of all errors *@
    @Html.ValidationSummary(true, "Please fix the following errors:")

    <button type="submit">Submit</button>
}
```

## 10.3 Strongly-Typed HTML Helpers

These use lambda expressions to reference model properties — compile-time safe:

```html
@model StudentRegistrationViewModel

@using (Html.BeginForm("Register", "Student", FormMethod.Post,
    new { @class = "registration-form" })) {
    @Html.AntiForgeryToken()

    @* LabelFor — reads [Display(Name="...")] attribute *@
    @Html.LabelFor(m => m.Name, new { @class = "form-label" })

    @* TextBoxFor *@
    @Html.TextBoxFor(m => m.Name,
        new { @class = "form-control", placeholder = "Full Name" })

    @* PasswordFor *@
    @Html.PasswordFor(m => m.Password, new { @class = "form-control" })

    @* TextAreaFor *@
    @Html.TextAreaFor(m => m.Bio, 4, 0, new { @class = "form-control" })

    @* CheckBoxFor *@
    @Html.CheckBoxFor(m => m.AgreeToTerms)

    @* DropDownListFor *@
    @Html.DropDownListFor(m => m.CourseId,
        new SelectList(ViewBag.Courses, "Id", "Name"),
        "-- Select --",
        new { @class = "form-select" })

    @* HiddenFor *@
    @Html.HiddenFor(m => m.Id)

    @* Strongly-typed validation message *@
    @Html.ValidationMessageFor(m => m.Name, "",
        new { @class = "text-danger small" })

    <button type="submit" class="btn btn-primary">Register</button>
}
```

**Why strongly typed is better:**
```csharp
// If you rename model property from "Name" to "FullName":

// Standard helper — SILENTLY BREAKS at runtime (no binding)
@Html.TextBox("Name")         ← broken, returns null

// Strongly typed — COMPILE ERROR, you fix it immediately
@Html.TextBoxFor(m => m.Name) ← Red squiggle, caught at build time
```

## 10.4 Templated HTML Helpers

Templated helpers inspect the model property's type and Data Annotations to automatically render the most appropriate HTML:

```html
@model StudentViewModel

@* EditorFor — generates input based on property type/annotations *@
@Html.EditorFor(m => m.Name)          @* → <input type="text"> *@
@Html.EditorFor(m => m.Password)      @* → <input type="password"> (DataType.Password) *@
@Html.EditorFor(m => m.DateOfBirth)   @* → <input type="date"> *@
@Html.EditorFor(m => m.IsActive)      @* → <input type="checkbox"> *@
@Html.EditorFor(m => m.Age)           @* → <input type="number"> *@
@Html.EditorFor(m => m.Bio)           @* → <textarea> (DataType.MultilineText) *@

@* DisplayFor — read-only rendering *@
@Html.DisplayFor(m => m.Name)         @* → plain text span *@
@Html.DisplayFor(m => m.DateOfBirth)  @* → formatted date string *@

@* EditorForModel — renders editor for ALL properties *@
@Html.EditorForModel()

@* DisplayForModel — displays ALL properties read-only *@
@Html.DisplayForModel()
```

### Custom Display Templates
```
Views/Shared/DisplayTemplates/DateTime.cshtml
    → Customizes how ALL DateTime properties display via @Html.DisplayFor

Views/Shared/EditorTemplates/DateTime.cshtml
    → Customizes how ALL DateTime editors render
```

## 10.5 HTML Helpers vs Tag Helpers (Modern Comparison)

ASP.NET Core introduced Tag Helpers as a cleaner alternative:

```html
@* HTML Helper approach *@
@Html.TextBoxFor(m => m.Name, new { @class = "form-control" })
@Html.ValidationMessageFor(m => m.Name)

@* Tag Helper approach (same result, reads more like HTML) *@
<input asp-for="Name" class="form-control" />
<span asp-validation-for="Name" class="text-danger"></span>
```

Tag Helpers are preferred in modern ASP.NET Core because they blend naturally with HTML and are more readable to designers.

---

## 🎤 Interview Questions — Section 10

**Q1: What is the key difference between Standard and Strongly Typed HTML Helpers?**

> "Standard helpers take the field name as a string literal — `Html.TextBox('Name')`. If I rename the `Name` property in my model, this helper silently stops binding — the form still renders but no data flows. Strongly typed helpers use lambda expressions — `Html.TextBoxFor(m => m.Name)`. If I rename the property, the compiler immediately shows an error. In production codebases, I always use strongly typed helpers because they make refactoring safe and give full IntelliSense in the IDE. The standard helpers exist mainly for legacy code and dynamic scenarios where you don't have a compile-time type."

**Q2: What is EditorFor and how does it decide what HTML to render?**

> "`EditorFor` is a templated helper that inspects the property's CLR type and its Data Annotation attributes to generate the most semantically correct HTML input. An `int` property becomes `<input type='number'>`, a `bool` becomes a checkbox, a `[DataType(DataType.Password)]` string becomes `<input type='password'>`, a `DateTime` becomes `<input type='date'>`. You can override this behavior by creating custom Editor Templates in `Views/Shared/EditorTemplates/`. This makes forms easier to maintain because changing a property's data type automatically updates its form control."

**Q3: Should you use HTML Helpers or Tag Helpers in new projects?**

> "Tag Helpers for new projects, without question. They produce cleaner code that reads like HTML — `<input asp-for='Name' class='form-control' />` vs `@Html.TextBoxFor(m => m.Name, new { @class = 'form-control' })`. Designers who don't know Razor can read and modify Tag Helper views without confusion. They also play better with HTML editors and tooling. HTML Helpers still work and are fine, but Tag Helpers are the modern ASP.NET Core approach. I use HTML Helpers only when dealing with legacy codebases that haven't migrated or when writing an extension that can't use Tag Helpers for some reason."

---

# PART 11 — TAG HELPERS (MODERN MVC)

## 11.1 What are Tag Helpers?

Tag Helpers are server-side components that look like HTML attributes. They're processed on the server and generate HTML, but they read more naturally than HTML Helpers.

Enable them globally via `_ViewImports.cshtml`:
```csharp
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

## 11.2 Form Tag Helpers

```html
@model StudentViewModel

@* Form *@
<form asp-action="Register" asp-controller="Student" method="post">

    @* Anti-forgery token is added automatically! *@

    @* Label — reads [Display(Name="...")] annotation *@
    <label asp-for="Name" class="form-label"></label>

    @* Input — type inferred from property type/annotations *@
    <input asp-for="Name" class="form-control" />

    @* Validation message *@
    <span asp-validation-for="Name" class="text-danger"></span>

    @* Textarea *@
    <textarea asp-for="Bio" class="form-control" rows="4"></textarea>

    @* Select/Dropdown *@
    <select asp-for="CourseId" asp-items="ViewBag.Courses"
            class="form-select">
        <option value="">-- Select Course --</option>
    </select>

    @* Checkbox *@
    <input asp-for="IsActive" class="form-check-input" />

    <button type="submit" class="btn btn-primary">Submit</button>
</form>

@* Validation Summary *@
<div asp-validation-summary="All" class="text-danger"></div>
```

## 11.3 Anchor Tag Helpers

```html
@* Generates: <a href="/Student/Edit/5">Edit</a> *@
<a asp-controller="Student" asp-action="Edit" asp-route-id="5">Edit</a>

@* With multiple route values *@
<a asp-controller="Student" asp-action="Search"
   asp-route-name="Ravi" asp-route-page="2">Search</a>
@* Generates: /Student/Search?name=Ravi&page=2 *@
```

## 11.4 Environment Tag Helper

```html
@* Only renders in Development *@
<environment include="Development">
    <script src="~/js/site.js"></script>
</environment>

@* Only renders in Production/Staging *@
<environment exclude="Development">
    <script src="~/js/site.min.js"></script>
</environment>
```

## 11.5 Custom Tag Helper

```csharp
// Renders an email link with mailto: automatically
[HtmlTargetElement("email-link")]
public class EmailLinkTagHelper : TagHelper {
    public string Address { get; set; }
    public string DisplayText { get; set; }

    public override void Process(TagHelperContext context,
                                  TagHelperOutput output) {
        output.TagName = "a";
        output.Attributes.SetAttribute("href", $"mailto:{Address}");
        output.Content.SetContent(DisplayText ?? Address);
    }
}

// Usage in view:
<email-link address="support@myapp.com" display-text="Contact Support" />
// Renders: <a href="mailto:support@myapp.com">Contact Support</a>
```

---

# PART 12 — DEPENDENCY INJECTION (DI)

## 12.1 What is Dependency Injection?

Dependency Injection is a design pattern where objects receive their dependencies from an external source rather than creating them internally. ASP.NET Core has DI built into the framework.

**Without DI (tightly coupled — bad):**
```csharp
public class StudentController : Controller {
    private readonly StudentRepository _repo;

    public StudentController() {
        _repo = new StudentRepository();  // Hard dependency! Can't test/swap.
    }
}
```

**With DI (loosely coupled — good):**
```csharp
public class StudentController : Controller {
    private readonly IStudentRepository _repo;

    public StudentController(IStudentRepository repo) {
        _repo = repo;  // Injected by the framework — can be swapped/mocked
    }
}
```

## 12.2 Service Lifetimes

```csharp
// Transient — new instance EVERY time it's requested
builder.Services.AddTransient<IEmailService, SmtpEmailService>();
// Use for: lightweight, stateless services

// Scoped — one instance PER HTTP REQUEST
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
// Use for: DbContext, Unit of Work, per-request services

// Singleton — ONE instance for the app's lifetime
builder.Services.AddSingleton<ICacheService, MemoryCacheService>();
// Use for: shared caches, configuration, expensive-to-create services
```

**Lifetime dangers:**
- Never inject a Scoped service into a Singleton (Scoped will become Singleton — bugs!)
- Never inject a Transient service into a Singleton for shared state

## 12.3 Registering Services

```csharp
// Interface → Implementation
builder.Services.AddScoped<IStudentRepository, EfStudentRepository>();

// Concrete type (no interface)
builder.Services.AddScoped<StudentService>();

// Factory (when creation needs logic)
builder.Services.AddScoped<IEmailService>(provider => {
    var config = provider.GetRequiredService<IConfiguration>();
    var host = config["Email:SmtpHost"];
    return new SmtpEmailService(host);
});

// DbContext (Entity Framework)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
```

---

## 🎤 Interview Questions — Section 12

**Q1: What are the three service lifetimes in ASP.NET Core DI?**

> "Transient creates a new instance every single time it's requested from the container — good for lightweight, stateless services like formatters or validators. Scoped creates one instance per HTTP request — all components in the same request share the same instance, then it's discarded. This is the right choice for DbContext. Singleton creates one instance for the application's lifetime — all requests share it. Good for caches or configuration services, but be careful about thread safety. The golden rule: never inject a shorter-lived service into a longer-lived one — a Scoped into a Singleton will effectively become a Singleton with request-specific state leaking across requests."

**Q2: What is the benefit of programming against interfaces rather than concrete classes?**

> "Programming against interfaces enables loose coupling and makes the code testable. When a Controller depends on `IStudentRepository` instead of `EfStudentRepository`, I can: swap to a different repository implementation without changing the controller, and in unit tests, inject a mock implementation using Moq or similar. For example, testing a Controller that depends on a database repository — in tests, I inject a `FakeStudentRepository` that returns hardcoded data instead of hitting the DB. This makes tests fast and reliable. It also enforces the SOLID principle of Dependency Inversion."

---

# PART 13 — ENTITY FRAMEWORK CORE (INTRODUCTION)

## 13.1 What is EF Core?

Entity Framework Core is an ORM (Object-Relational Mapper) — it lets you work with a database using .NET objects instead of SQL strings.

```csharp
// Model class (maps to DB table)
public class Student {
    public int Id { get; set; }             // → Primary Key (INT IDENTITY)
    public string Name { get; set; }        // → nvarchar column
    public string Email { get; set; }       // → nvarchar column
    public DateTime CreatedAt { get; set; } // → datetime2 column
    public int CourseId { get; set; }       // → Foreign Key
    public Course Course { get; set; }      // → Navigation property
}

// DbContext — represents the database
public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }    // → Students table
    public DbSet<Course> Courses { get; set; }      // → Courses table
}
```

## 13.2 CRUD Operations

```csharp
public class StudentRepository : IStudentRepository {
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context) {
        _context = context;
    }

    // READ — all
    public List<Student> GetAll() =>
        _context.Students.Include(s => s.Course).ToList();

    // READ — by ID
    public Student GetById(int id) =>
        _context.Students.FirstOrDefault(s => s.Id == id);

    // READ — filtered
    public List<Student> Search(string name) =>
        _context.Students
            .Where(s => s.Name.Contains(name))
            .OrderBy(s => s.Name)
            .ToList();

    // CREATE
    public void Add(Student student) {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    // UPDATE
    public void Update(Student student) {
        _context.Students.Update(student);
        _context.SaveChanges();
    }

    // DELETE
    public void Delete(int id) {
        var student = _context.Students.Find(id);
        if (student != null) {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}
```

## 13.3 Migrations

```bash
# Create migration (snapshot of model changes)
dotnet ef migrations add InitialCreate

# Apply migrations to database
dotnet ef database update

# Rollback to specific migration
dotnet ef database update PreviousMigrationName
```

---

# PART 14 — AUTHENTICATION & AUTHORIZATION (OVERVIEW)

## 14.1 ASP.NET Core Identity

Identity provides user management: registration, login, password hashing, roles:

```csharp
// Setup in Program.cs
builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Lockout.MaxFailedAccessAttempts = 5;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();
```

## 14.2 Authorization Attributes

```csharp
// Require login
[Authorize]
public class StudentController : Controller { }

// Require specific role
[Authorize(Roles = "Admin")]
public IActionResult AdminDashboard() { }

// Require specific policy
[Authorize(Policy = "CanEditStudents")]
public IActionResult Edit(int id) { }

// Allow anonymous even if controller requires auth
[AllowAnonymous]
public IActionResult Login() { }
```

---

## 🎤 Final Interview Questions — Advanced Topics

**Q1: What is the difference between Authentication and Authorization?**

> "Authentication is about identity — 'Who are you?' It's the process of verifying credentials (username/password, OAuth token, certificate). Authorization is about permissions — 'What are you allowed to do?' It runs after authentication. In ASP.NET Core, `UseAuthentication()` must come before `UseAuthorization()` in the middleware pipeline — you must know who the user is before deciding what they can access. `[Authorize]` on a controller requires a logged-in user; `[Authorize(Roles='Admin')]` requires the user to additionally have the Admin role."

**Q2: What is CSRF and how does ASP.NET Core prevent it?**

> "CSRF — Cross-Site Request Forgery — is an attack where a malicious site tricks a logged-in user's browser into sending a request to your application. The browser automatically attaches the user's session cookie, so your server thinks it's a legitimate request. ASP.NET Core prevents it with anti-forgery tokens: a unique token is embedded in each HTML form, and the server validates this token on every POST. The malicious site can't read the token due to same-origin policy. Tag Helpers automatically include the token in forms, and `[ValidateAntiForgeryToken]` on POST actions validates it."

**Q3: What are some performance best practices in ASP.NET Core?**

> "Several key practices: First, use `async/await` throughout — especially for DB calls and HTTP requests, to avoid blocking threads. Second, use Response Caching and Output Caching for pages that don't change often. Third, use `IMemoryCache` or `IDistributedCache` (Redis) for frequently-read data. Fourth, serve static files efficiently — use CDN and response compression. Fifth, use pagination for large datasets — never load all records. Sixth, use `AsNoTracking()` in EF Core for read-only queries to avoid change tracking overhead. Finally, use bundling and minification for CSS/JS in production."

---

# 📋 MASTER INTERVIEW CHEAT SHEET

## Top 20 Questions You Must Be Ready For

| # | Question | Key Points |
|---|----------|-----------|
| 1 | What is MVC? | Model-View-Controller, Separation of Concerns, request flow |
| 2 | .NET Core vs .NET Framework | Cross-platform, performance, open-source, unified from .NET 5 |
| 3 | What is Middleware? | Pipeline, order matters, request/response chain |
| 4 | ViewBag vs ViewData vs TempData | Dynamic vs Dictionary vs Cross-redirect persistence |
| 5 | What is Model Binding? | Automatic HTTP→parameter mapping, sources order |
| 6 | What is CSRF? | Forged requests, anti-forgery tokens |
| 7 | Routing types? | Conventional vs Attribute routing |
| 8 | IActionResult types? | View, Json, Redirect, NotFound, File |
| 9 | What is Dependency Injection? | Loose coupling, testability, lifetimes |
| 10 | DI lifetimes? | Transient/Scoped/Singleton — when to use each |
| 11 | HTML Helpers vs Tag Helpers? | Strongly typed vs natural HTML syntax |
| 12 | What are Data Annotations? | Validation rules, display metadata |
| 13 | What is PRG Pattern? | Post-Redirect-Get, prevents duplicate submissions |
| 14 | What is a ViewModel? | View-specific model, prevents over-posting |
| 15 | What is over-posting? | Mass assignment attack, [Bind], dedicated input models |
| 16 | Auth vs Authorization? | Who are you vs What can you do |
| 17 | What is Razor? | Server-side template engine, @ syntax, compiled |
| 18 | Partial View vs View Component? | Static display vs own logic/DI |
| 19 | Program.cs structure? | Services then Middleware, builder.Build() divides them |
| 20 | EF Core vs raw SQL? | ORM benefits, migrations, LINQ queries, tradeoffs |
