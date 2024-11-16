CREATE TABLE users (
    id INT PRIMARY KEY IDENTITY(1,1),  
    email_address VARCHAR(255) UNIQUE NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    first_name VARCHAR(255) NOT NULL,
    phone_number INT(11) NOT NULL,  
    password VARCHAR(255) NOT NULL,  -- Storing plain text passwords (not recommended)
    role VARCHAR(10) CHECK (role IN ('admin', 'student')),  -- Using CHECK constraint for roles
    created_at DATETIME DEFAULT GETDATE()  -- Default to current date and time
);

SELECT * FROM users;