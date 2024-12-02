Description
This project implements a URL Shortener Service with a React.js frontend and an ASP.NET Core backend. The service allows users to enter a long URL to generate a shorter version. Users can visit the shortened URL to get redirected to the original URL.


How to Run the Project
1. Backend
Navigate to the backend folder
2. Restore dependencies:
dotnet restore
3. Build the project:
dotnet build
4. Run the backend:
dotnet run
5. The backend will run on http://localhost:5000 or another specified port.


1. Open the frontend:
Visit http://localhost:3000 in your browser.

2. Shorten a URL:
Enter a long URL into the input field.
Click the Shorten button.
A shortened URL will be displayed.

3. Access the shortened URL:
Click the displayed shortened URL.
It should redirect you to the original long URL.


