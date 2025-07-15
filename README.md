# Project Evergreen: The Walmart Smart Retail Ecosystem

<!-- Optional: Create a cool banner for your project -->

Welcome to the official repository for **Project Evergreen**! This project combines three powerful ideas into a single, cohesive retail platform designed to enhance customer experience, promote sustainability, and improve operational efficiency.

---

## ✨ Project Vision

Our goal is to revolutionize the retail experience by integrating intelligent, value-driven technology. We empower customers to make sustainable choices with **GreenScore**, help them visualize products in their own space with **RoomScape AI**, and reduce food waste through our AI-powered logistics platform, **Waste-Knot**.

---

## 🚀 Core Features

This project is a monorepo containing two main parts: a **Unity 6 frontend** and a **Node.js (Express) backend**.

### Frontend (Mobile App - `/unity-app`)
*   **GreenScore:** A gamified system that scores products on sustainability. Users earn points and rewards for making eco-friendly choices, all presented in a rich, interactive UI.
*   **RoomScape AI:** An Augmented Reality feature that allows users to place photorealistic 3D models of furniture in their own room. Built with Unity 6 and ARCore for high-fidelity rendering and stable world tracking.

### Backend (Server - `/backend`)
*   **Waste-Knot:** An AI-driven logistics system that identifies near-expiry food items and automates the process of donating them to local charities.
*   **Core API:** A robust REST API that serves data for products, user authentication, and donation management.

---

## 🛠️ Tech Stack

| Area      | Technology                                                                                                    |
| --------- | ------------------------------------------------------------------------------------------------------------- |
| **Frontend**  | ![Unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white) ![ARCore](https://img.shields.io/badge/ARCore-F44336?style=for-the-badge&logo=google&logoColor=white) |
| **Backend**   | ![Node.js](https://img.shields.io/badge/Node.js-339933?style=for-the-badge&logo=nodedotjs&logoColor=white) ![Express.js](https://img.shields.io/badge/Express.js-000000?style=for-the-badge&logo=express&logoColor=white) |
| **Database**  | ![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white) |
| **DevOps**    | ![Git](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white) ![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white) |

---

## 🏁 Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

*   Node.js (v16 or later)
*   npm or yarn
*   Git
*   PostgreSQL server running locally
*   **Unity Hub**
*   **Unity Editor (Version 6 or later)**
*   **Android Build Support** module in Unity (with SDK & NDK tools)

### Installation & Setup

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/project-evergreen.git
    cd project-evergreen
    ```

2.  **Set up the Backend:**
    ```bash
    # Go to the backend directory
    cd backend

    # Install dependencies
    npm install

    # Create your environment file from the example
    cp .env.example .env

    # Edit .env with your local PostgreSQL credentials
    nano .env

    # Run database migrations (if using an ORM like Sequelize/Prisma)
    # npx sequelize-cli db:migrate

    # Start the server
    npm run dev
    ```
    The backend server should now be running on `http://localhost:3001` (or your configured port).

3.  **Set up the Frontend (Unity):**
    
    The Unity project is located in the `/unity-app` folder.
    
    1.  Open **Unity Hub**.
    2.  In the 'Projects' tab, click **'Open'**.
    3.  Navigate to the cloned repository and select the `unity-app` folder.
    4.  The project will open in the Unity Editor. This may take a few minutes to import all assets and packages for the first time.

    *   To run in the Editor for UI testing, press the **Play** button.
    *   To deploy to a device for AR testing:
        1.  Connect an [ARCore-supported](https://developers.google.com/ar/devices) Android device to your computer.
        2.  In Unity, go to `File > Build Settings`.
        3.  Ensure **Android** is the selected platform. If not, select it and click **Switch Platform**.
        4.  Click **Build and Run**. Unity will build the `.apk` and install it on your connected device.

---

## 👥 Team

*   **Abhay:** Frontend Lead (RoomScape AI & GreenScore)
*   **Tejaswini:** Backend Lead (Core API & "AI" Logic)
*   **Mayank:** Backend Lead (Donation Workflow & Web Dashboards)

Please refer to the documentation in the `/docs` folder for our API contract and workflow guidelines.
