
# **UserAuth Project**

## **Overview**
UserAuth is a .NET-based application for user authentication and subscription management. It follows a clean and layered architecture with PostgreSQL as the database.

---

## **Project Structure**
### **Controllers**
Handle API requests:
- `AccountController.cs`
- `SubscriptionsController.cs`
- `UserSubscriptionsController.cs`

### **Data**
- Contains `Db.cs` for PostgreSQL database context.

### **Extensions**
- `StringExt.cs`: Provides reusable string utilities.

### **Interfaces**
Define contracts for repositories:
- `IUserRepository.cs`
- `ISubscriptionRepository.cs`
- `IUserSubscriptionsRepository.cs`

### **Middleware**
- `ExceptionMiddleware.cs`: Centralized error handling.

### **Models**
- **Entities**: Database models.
- **Requests**: Incoming API models.
- **Responses**: Outgoing API models.

### **Repositories**
- Data access logic for PostgreSQL.

### **Services**
Business logic for authentication and subscriptions:
- `JwtService.cs`
- `UserService.cs`
- `SubscriptionsService.cs`

### **Config**
- `appsettings.json`: Holds PostgreSQL connection and app configuration.

---

## **PostgreSQL Integration**

### **Connection String**
Add the following connection string in `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=UserAuthDb;Username=postgres;Password=your_password"
}
```

### **Run Migrations**
1. Add a migration:
   ```bash
   dotnet ef migrations add MigrationName
   ```
2. Apply the migration to the database:
   ```bash
   dotnet ef database update
   ```

---

## **Getting Started**

### **Steps to Run the Project**
1. **Configure PostgreSQL**:
   - Update the connection string in `appsettings.json`.

2. **Restore Dependencies**:
   ```bash
   dotnet restore
   ```

3. **Apply Migrations**:
   ```bash
   dotnet ef database update
   ```

4. **Run the Project**:
   ```bash
   dotnet run
   ```

---
