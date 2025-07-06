# Project Evergreen - Database Schema

This document details the structure of our PostgreSQL database. It includes the SQL `CREATE TABLE` statements and a visual Entity-Relationship Diagram (ERD).


---

## SQL Table Definitions

These are the SQL commands used to create the database schema.

```sql
-- Custom Types for ENUMs
CREATE TYPE user_role AS ENUM ('shopper', 'store_manager', 'charity_rep', 'admin');
CREATE TYPE manifest_status AS ENUM ('pending_approval', 'available', 'claimed', 'completed', 'cancelled');

-- Users Table
CREATE TABLE Users (
id SERIAL PRIMARY KEY,
email VARCHAR(255) UNIQUE NOT NULL,
password_hash TEXT NOT NULL,
full_name VARCHAR(255),
role user_role NOT NULL DEFAULT 'shopper',
cumulative_green_score INT NOT NULL DEFAULT 0,
created_at TIMESTAMP WITH TIME ZONE DEFAULT now(),
updated_at TIMESTAMP WITH TIME ZONE DEFAULT now()
);

-- Products Table
CREATE TABLE Products (
id SERIAL PRIMARY KEY,
name VARCHAR(255) NOT NULL,
description TEXT,
price NUMERIC(10, 2) NOT NULL,
image_url TEXT,
green_score INT CHECK (green_score >= 0 AND green_score <= 100),
green_score_details JSONB,
model_3d_url TEXT,
category VARCHAR(100),
inventory_quantity INT NOT NULL DEFAULT 0,
expiry_date DATE
);

-- Charities Table
CREATE TABLE Charities (
id SERIAL PRIMARY KEY,
name VARCHAR(255) NOT NULL,
address TEXT,
contact_email VARCHAR(255),
is_verified BOOLEAN NOT NULL DEFAULT false,
user_id INT UNIQUE REFERENCES Users(id) ON DELETE SET NULL
);

-- Donation_Manifests Table
CREATE TABLE Donation_Manifests (
id SERIAL PRIMARY KEY,
status manifest_status NOT NULL DEFAULT 'pending_approval',
created_by_user_id INT REFERENCES Users(id),
claimed_by_charity_id INT REFERENCES Charities(id),
scheduled_pickup_time TIMESTAMP WITH TIME ZONE,
created_at TIMESTAMP WITH TIME ZONE DEFAULT now(),
updated_at TIMESTAMP WITH TIME ZONE DEFAULT now()
);

-- Manifest_Items Linking Table
CREATE TABLE Manifest_Items (
id SERIAL PRIMARY KEY,
manifest_id INT NOT NULL REFERENCES Donation_Manifests(id) ON DELETE CASCADE,
product_id INT NOT NULL REFERENCES Products(id),
quantity INT NOT NULL CHECK (quantity > 0),
UNIQUE (manifest_id, product_id)
);
