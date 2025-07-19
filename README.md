# 🧪 BitcoinConverterApp — Test-Driven Development with xUnit in .NET Core

This project demonstrates a clean and structured approach to **Test-Driven Development (TDD)** using **xUnit** in a .NET Core solution. It includes a sample currency conversion service (`CurrencyRateService`) and unit tests that validate its behavior using the **Red-Green-Refactor** cycle.

---

## 📁 Project Structure

BitcoinConveterApp/

├── BitcoinConverterApp.sln # Solution file

├── BitcoinConverterApp.Code/ # Class Library (Business Logic)

│ └── CurrencyRateService.cs

├── BitcoinConverterApp.Tests/ # xUnit Test Project

│ └── CurrencyRateServiceTests.cs


---

## 🚀 Getting Started

### 🔧 Prerequisites
- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio Code](https://code.visualstudio.com/) or any .NET-compatible IDE
- Git (for version control)

---

## 📦 Setup Instructions

Run the following commands in your terminal:

```bash
# Step 1: Create a solution and navigate into it
dotnet new sln -o BitcoinConveterApp
cd ./BitcoinConveterApp

# Step 2: Create the xUnit test project
dotnet new xunit -o BitcoinConverterApp.Tests
dotnet sln add ./BitcoinConverterApp.Tests/BitcoinConverterApp.Tests.csproj

# Step 3: Open the solution in VS Code (or any editor)
code .

# Step 4: Run tests (optional - will be empty at this point)
dotnet test

# Step 5: Create the class library for business logic
dotnet new classlib -o BitcoinConverterApp.Code
dotnet sln add ./BitcoinConverterApp.Code/BitcoinConverterApp.Code.csproj

# Step 6: Add reference from test project to class library
dotnet add BitcoinConverterApp.Tests/BitcoinConverterApp.Tests.csproj reference BitcoinConverterApp.Code/BitcoinConverterApp.Code.csproj


✅ Features Implemented

📚 Class Library: CurrencyRateService with a method FetchRate(string currencyCode)
🧪 Unit Tests: xUnit-based tests for CurrencyRateService
🎯 Red-Green-Refactor cycle demonstrated
🧱 Structured using the Arrange-Act-Assert pattern
🔍 Assertion for behavior and exceptions using Assert.Equal, Assert.Throws

🧪 Example Test

[Fact]
public void FetchRate_USD_ReturnsExpectedRate()
{
    // Arrange
    var rateService = new CurrencyRateService();

    // Act
    var actualRate = rateService.FetchRate("USD");

    // Assert
    var expectedRate = 98;
    Assert.Equal(expectedRate, actualRate);
}

🧠 Best Practices Followed

Clear and descriptive test naming: MethodName_State_ExpectedBehavior
Use of Fact and Theory attributes from xUnit
Business logic fully covered by automated unit tests
TDD-first approach: tests written before code

📌 Next Steps
Add more currencies and tests using [Theory] with [InlineData]
Integrate mocking for external rate APIs (e.g., using Moq)
Set up CI pipeline to run tests automatically (GitHub Actions, Azure DevOps)

📝 License
This project is open-source and available under the MIT License.

👨‍💻 Author
Surendrakumar Laggisetty
TDD & .NET Core Enthusiast | Full Stack Developer
