# Calculator with SQL Server Integration

A GUI-based calculator built in C# (Windows Forms) that performs basic and advanced arithmetic operations and logs every calculation to a SQL Server database.

## Features

- Addition
- Subtraction
- Multiplication
- Division
- Square
- Square Root
- Each operation's inputs and results are stored in and retrieved from a SQL Server database (CalculatorDB) via full CRUD operations

## Tech Stack

- **Language**: C#
- **UI Framework**: Windows Forms (.NET)
- **Database**: Microsoft SQL Server
- **Database Tooling**: SQL Server Management Studio (SSMS)
- **IDE**: Visual Studio

## Project Structure

```
├── MyCalculator/              # C# Windows Forms application
│   ├── Form1.cs                # Main calculator UI logic
│   ├── Program.cs              # Application entry point
│   └── DbLabAssignment.sln     # Visual Studio solution file
├── mycalculator.bacpac         # Database backup file (CalculatorDB)
└── README.md
```

## Prerequisites

Before running this project, install:

1. [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
2. [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
3. [Visual Studio](https://visualstudio.microsoft.com/) (with the ".NET desktop development" workload)

## Database Setup

1. Open SSMS and connect to your local SQL Server instance.
2. Right-click **Databases** → **Import Data-tier Application**.
3. Follow the wizard and select `mycalculator.bacpac` from this repo to restore the `CalculatorDB` database.
4. This will recreate the database along with tables for each operation (e.g., `Addition_table`, `Subtraction_table`, etc.), storing input values and results.

## Running the Application

1. Open `MyCalculator/DbLabAssignment.sln` in Visual Studio.
2. Update the database connection string in the project (typically in `Form1.cs` or an app config file) to match your local SQL Server instance name.
3. Build and run the project (F5).
4. Use the calculator UI to perform operations — each result is automatically saved to its corresponding table in `CalculatorDB`.

## Database Schema

Each operation has its own table storing:

- Input value(s)
- Result
- (Optionally) timestamp of calculation

## CRUD Operations Implemented

- **Create**: New calculation results are inserted into the relevant table
- **Read**: Past calculations can be retrieved and displayed
- **Update**: Existing records can be modified
- **Delete**: Records can be removed from the database

## Author

Zainab Khalid
