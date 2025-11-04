# Write Error Log

**Write Error Log** is a simple utility built with **C#** and **.NET** that captures application errors and writes them to a text file. Each day, a new log file is created with the filename corresponding to the current date (e.g., `2025-11-04.txt`), making it easy to track and organize errors by day.

## Features
- Logs errors automatically to a `.txt` file
- Creates a new log file for each day using the current date
- Easy to integrate into any C#/.NET application
- Lightweight and simple to use

## Technologies Used
- **C#**
- **.NET Core / .NET 5+**
- **File System** for storing logs

## Getting Started

## Prerequisites
- [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet/5.0)
- Visual Studio 2019/2022 or Visual Studio Code

## Installation
### 1. Clone the repository:
   ```bash
   git clone https://github.com/rashedulalam46/write-error-log.git
   ```
### 2. Navigate to the project folder: 
```
cd write-error-log
```
### 3. Restore dependencies:
```
dotnet restore
```
### 4. Run the application:
```
dotnet run
```
## Usage

- Include the ErrorLogger class in your project.
- Call the logging methods whenever an exception occurs.
- Errors will be appended to a daily log file named with the current date in the designated log folder.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for enhancements or bug fixes.

