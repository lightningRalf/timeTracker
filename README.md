# timeTracker

## Setting up OneDrive Sync

To enable OneDrive sync for the timetracker app, follow these steps:

1. **Register your application in the Azure portal:**
   - Go to the [Azure portal](https://portal.azure.com/).
   - Navigate to "Azure Active Directory" > "App registrations" > "New registration".
   - Enter a name for your application.
   - Set the "Redirect URI" to `http://localhost`.
   - Click "Register".

2. **Configure API permissions:**
   - In the "API permissions" section, click "Add a permission".
   - Select "Microsoft Graph".
   - Choose "Delegated permissions".
   - Add the following permissions: `Files.ReadWrite.All`.
   - Click "Add permissions".

3. **Configure authentication:**
   - In the "Authentication" section, add a platform configuration for "Mobile and desktop applications".
   - Add the redirect URI `http://localhost`.

4. **Update the `Settings.cs` file:**
   - Open the `TimeTracker.MAUI/Helpers/Settings.cs` file.
   - Set the `OneDriveClientId` and `OneDriveRedirectUri` properties with the values from the Azure portal.

5. **Run the application:**
   - Build and run the timetracker app.
   - The app will prompt you to sign in to your Microsoft account and grant the necessary permissions.
   - Once authenticated, the app will sync data to OneDrive.

## Categories and Subcategories

The timetracker app includes the following categories and subcategories:

* Unterrichtsvorbereitung 📚
  * Jahresplanung 📅
  * Trimesterplanung 📆
  * Sequenzplanung 📋
  * Stundenplanung 🕒
  * Besondere Events 🎉
* Besprechungen 🗣️
  * Lehrerkonferenz 🏫
  * Fachkonferenz 📚
  * Klassenkonferenz 🏫
  * Elterngespräche 👨‍👩‍👧‍👦
  * Gespräch mit Kollegen 🗣️
* Verwaltung 🗂️
  * Organisation 📂
  * Dokumentation 📝
  * Korrektur und Bewertung 📝
* Fortbildung 🎓
  * Kurse - Seminare 🏫
  * Selbststudium (berufsbezogen) 📖
* Schülerbetreuung 👩‍🏫
  * Beratung 🗣️
  * Förderung 📚
  * AG - Projekte 🛠️
* Soziales 🤝
  * Jacqueline 👩
  * Simon 👨
  * Fabian 👦
  * Elternbeirat 👨‍👩‍👧‍👦
  * Freunde 👥
* Persönliche Zeit 🕒
  * Unproduktive Zeit 💤
  * Haushalt 🏠
  * Sport und Gesundheit 🏋️‍♂️
  * Buch lesen 📖
  * App Programmierung 💻
