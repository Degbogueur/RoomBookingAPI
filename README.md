# RoomBookingAPI

API de réservation de salles développée avec ASP.NET Core.


## 📦 Fonctionnalités

- CRUD pour les salles, utilisateurs, réservations
- Vérification des disponibilités
- Middleware de logging
- Gestion globale des erreurs
- API versionnée (en cours)
- Swagger intégré


## 🚀 Lancement de l'application

### 1. Configuration

Dans `appsettings.json`, configure la chaîne de connexion :
````
"ConnectionStrings": {
  "DatabaseConnection": "Server=.;Database=RoomBookingDb;Trusted_Connection=True;"
}
````

### 2. Appliquer les migrations

Dans le terminal :
````
dotnet ef migrations add InitialCreate
dotnet ef database update
````


## 🧪 Exemples de requêtes

### Créer un utilisateur
POST : `/api/users`
````
{
  "fullName": "John Doe",
  "email": "johndoe@example.com"
}
````

### Obtenir toutes les réservations
GET : `/api/bookings`

### Filtrer les salles par capacité
GET : `/api/rooms/available?minCapacity=10`


## 👨‍💻 Auteur
#### Komi Obed Degbo
Développeur .NET passionné