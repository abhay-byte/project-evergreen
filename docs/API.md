# Project Evergreen - API Contract

**Version: 1.0**

This document is the single source of truth for the Project Evergreen REST API. The frontend team builds against these specifications, and the backend team implements them.

**Base URL:** `http://localhost:3001` (for local development)

---

## Authentication

All protected routes require a JSON Web Token (JWT) to be passed in the `Authorization` header.

**Format:** `Authorization: Bearer <your_jwt_token>`

---

## 1. Authentication Routes

### `POST /api/auth/register`
*   **Description:** Creates a new user account.
*   **Body:**
```json
{
"email": "test@example.com",
"password": "strongpassword123",
"fullName": "Test User",
"role": "shopper"
}
```
*   **Response (201 Created):**
```json
{
"message": "User registered successfully",
"user": { "id": 1, "email": "test@example.com", "role": "shopper" },
"token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### `POST /api/auth/login`
*   **Description:** Logs in a user and returns a JWT.
*   **Body:**
```json
{
"email": "test@example.com",
"password": "strongpassword123"
}
```
*   **Response (200 OK):** (Same as register response)

### `GET /api/auth/me`
*   **Description:** Gets the profile of the currently authenticated user.
*   **Authentication:** Required.
*   **Response (200 OK):**
```json
{
"id": 1,
"email": "test@example.com",
"fullName": "Test User",
"role": "shopper",
"cumulative_green_score": 150
}
```

---

## 2. Product Routes

### `GET /api/products`
*   **Description:** Retrieves a paginated list of products.
*   **Authentication:** Optional.
*   **Query Parameters:**
    *   `category` (string, e.g., "furniture")
    *   `page` (number, default: 1)
    *   `limit` (number, default: 10)
*   **Response (200 OK):**
```json
{
"products": [
{
"id": 101,
"name": "Eco-Friendly Sofa",
"price": "899.99",
"image_url": "https://example.com/sofa.jpg",
"green_score": 95
}
],
"totalPages": 5,
"currentPage": 1
}
```

### `GET /api/products/:id`
*   **Description:** Retrieves detailed information for a single product.
*   **Authentication:** Optional.
*   **Response (200 OK):**
```json
{
"id": 101,
"name": "Eco-Friendly Sofa",
"description": "A beautiful sofa made from recycled materials.",
"price": "899.99",
"image_url": "https://example.com/sofa.jpg",
"green_score": 95,
"green_score_details": {
"packaging": "9/10",
"sourcing": "10/10",
"carbon_footprint": "8/10"
},
"model_3d_url": "https://example.com/sofa.gltf",
"category": "furniture"
}
```

---

## 3. Donation Workflow Routes

### `GET /api/donations/pending`
*   **Description:** For Store Managers. Gets a list of donation manifests awaiting approval.
*   **Authentication:** Required (Role: `store_manager`).
*   **Response (200 OK):** `[{ "id": 1, "status": "pending_approval", "createdAt": "..." }]`

### `POST /api/donations/:manifestId/approve`
*   **Description:** For Store Managers. Approves a pending donation manifest.
*   **Authentication:** Required (Role: `store_manager`).
*   **Response (200 OK):** `{ "message": "Manifest approved and is now available for charities." }`

### `GET /api/donations/available`
*   **Description:** For Charity Reps. Gets a list of available donation manifests.
*   **Authentication:** Required (Role: `charity_rep`).
*   **Response (200 OK):** `[{ "id": 1, "status": "available", "createdAt": "...", "items": [...] }]`

### `POST /api/donations/:manifestId/claim`
*   **Description:** For Charity Reps. Claims an available donation manifest.
*   **Authentication:** Required (Role: `charity_rep`).
*   **Response (200 OK):** `{ "message": "Donation successfully claimed." }`

---

## 4. Admin Routes

(Routes like `POST /api/admin/products` and `POST /api/admin/charities/:id/verify` go here)
