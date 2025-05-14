# TaxSystem
Tax system for Municipality
This is C# Web API project using entity framework.
We are using Sqlite database. which exist in the Repository

# To Run
  Open the Solution in Visual Studio TaxSystem/TaxSystem.sln 
  OR 
  Run the project from cmd prompt "dotnet run" 
  
  Then open the below link in the web browser.
  http://localhost:5175/swagger/index.html

# Unit Test
there are unit test project TaxSystem.Tests that contain unit test for given scenarion. 

# Example Scenario
Municipality Copenhagen has its taxes scheduled as follows:
* Yearly tax = 0.2 (for the period between Jan 1, 2025 and Dec 31, 2025),
* Monthly tax = 0.4 (for the period between May 1, 2025 and May 31, 2025),
* No weekly taxes scheduled,
* Two daily taxes = 0.1 (on specific days Jan 1, 2025 and Dec 25, 2025).

# Tax Type
We have defined follwoing TaxType ( need while adding data) 
* Daily = 0 
* Weekly = 1,
* Monthly = 2,
* Yearly= 3
