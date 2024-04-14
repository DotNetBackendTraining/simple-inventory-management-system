CREATE TABLE Products
(
    ID       INT IDENTITY (1,1) PRIMARY KEY,
    Name     NVARCHAR(100)  NOT NULL,
    Price    DECIMAL(18, 2) NOT NULL CHECK (Price > 0),
    Quantity INT            NOT NULL CHECK (Quantity >= 0) DEFAULT 0
);
