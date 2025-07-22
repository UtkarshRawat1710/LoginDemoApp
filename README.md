# 🚗 Car Rental Management System

The Car Rental Management System is a web-based application built using ASP.NET Core MVC. It enables a seamless car booking experience for users, allows them to provide feedback, and offers complete car, booking, and feedback management functionalities for admins.

<img width="2841" height="1268" alt="Screenshot 2025-07-22 162913" src="https://github.com/user-attachments/assets/89cf1807-fae0-4377-8572-d10f67bfdbe3" />



## 🔑 User Interfaces

The application is built with role-based access for two user types:

- 👤 **User Interface**
- 🔐 **Admin Interface**

---

## 👤 User Interface

Users can interact with the following modules:

### 1. **Login/Register**

- New users can register.
- Existing users can log in using credentials.
<img width="2835" height="1250" alt="Screenshot 2025-07-22 163514" src="https://github.com/user-attachments/assets/e832715d-8def-4339-b7ba-9ada370772fa" />
<br>
<br>
<img width="2845" height="1224" alt="Screenshot 2025-07-22 163531" src="https://github.com/user-attachments/assets/af88745b-41a9-4d6c-a973-1f32fe38e1fc" />

### 2. **Search Cars**

- Users can search available cars from the dynamic database.
<img width="2849" height="1269" alt="Screenshot 2025-07-22 163939" src="https://github.com/user-attachments/assets/be13eabe-481f-4229-b0d5-d5aba4714e49" />

### 3. **Book Cars**


- Select a car
- Choose start & end dates
- Rent is auto-calculated before confirmation
- Proceed to book the car
<img width="2852" height="1177" alt="Screenshot 2025-07-22 164231" src="https://github.com/user-attachments/assets/0b340af1-668f-4250-b706-98141c99dbd9" />
<br>
<br>

<img width="2842" height="1209" alt="Screenshot 2025-07-22 164246" src="https://github.com/user-attachments/assets/004ec230-3c1a-431d-bd98-22829afaf143" />

### 4. **View Booking History**

- See all current and past bookings by the logged-in user.
<img width="2839" height="1265" alt="Screenshot 2025-07-22 164310" src="https://github.com/user-attachments/assets/896f1cbf-c6cf-4c50-95d1-c6bfeb7a91b0" />



### 5. **Feedback**

- Submit feedback that is visible to the admin.
- Helps improve service quality.
  <br>
  <br>
  <img width="2848" height="1193" alt="Screenshot 2025-07-22 164341" src="https://github.com/user-attachments/assets/5785669b-2d23-4271-8838-3d305e9e30cd" />


---

## 🔐 Admin Interface

Admins have the following access:


### 1. **Login**

- Admins can log in using their role-based credentials.
  
<img width="2835" height="1250" alt="Screenshot 2025-07-22 163514" src="https://github.com/user-attachments/assets/69df4536-0607-4d38-aafc-193cf3712991" />

### 2. **Manage Bookings**

- View all bookings done by all users.
- Delete any booking as required.
  
  <img width="2827" height="1220" alt="Screenshot 2025-07-22 172422" src="https://github.com/user-attachments/assets/15caaec8-861c-4d1f-8618-9ef533eb2a48" />


### 3. **Add Cars**

- Add new cars with details like:
  - Car name
  - Model
  - Rent price
  - Description


    <img width="2850" height="1268" alt="Screenshot 2025-07-22 172455" src="https://github.com/user-attachments/assets/98eab703-1fc8-49fe-a5ba-73322c13df99" />


### 4. **Search Customers**

- Search user details based on their name or email (optional feature).


  <img width="2846" height="1261" alt="Screenshot 2025-07-22 172514" src="https://github.com/user-attachments/assets/4248ebbb-fd7d-4de2-a745-e51bd82cee9d" />


### 5. **Manage Feedbacks**

- View all feedback submitted by users.
- Delete inappropriate or irrelevant feedback.

 
<img width="2847" height="1182" alt="Screenshot 2025-07-22 172540" src="https://github.com/user-attachments/assets/656fb0cd-f448-497b-a3d6-a9bc61ef2da0" />



---

## ⚙️ Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap 5
- HTML5 / CSS3
- JavaScript

---

## 🗂️ Folder Structure

CarRentalSystem/
 <br>
├── Controllers/
<br>
├── Models/
<br>
├── Views/
<br>
├── wwwroot/
<br>
├── appsettings.json
<br>
├── CarRentalSystem.csproj
<br>
└── CarRentalSystem.

---

## 🔧 How to Run

Follow these steps to set up and run the project locally:<br><br>

### 1. Clone the Repository

git clone https://github.com/your-username/CarRentalManagementSystem.git
<br>
2. Open the Solution in Visual Studio
Open the .sln file using Visual Studio.<br><br>

3. Update the Connection String
In the appsettings.json file, update the connection string as per your SQL Server:<br>

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=CarRentalDB;Trusted_Connection=True;"
}
<br>
4. Apply Migrations and Update the Database
Open the Package Manager Console in Visual Studio and run:<br>

powershell
Copy
Edit
Add-Migration InitialCreate
Update-Database
<br>
Note: If migrations already exist, you can skip Add-Migration.<br><br>

5. Run the Project
Run the project using IIS Express or Kestrel (dotnet run).<br>
The app will launch in your default browser.
