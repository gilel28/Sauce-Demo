SauceDemo Automation Task
Here is my submission for the automation testing assignment. The project is built using C#, NUnit, and Selenium WebDriver.

How to Run
No special setup or configuration is required. To run the tests, open your terminal, navigate to the project directory, and execute:

dotnet test

Test Coverage
The project contains 3 independent test cases (no shared state between tests). Each test initializes its own WebDriver instance and cleans it up after execution.

Test 1 (Invalid Password): Attempts to log in with a valid user but a wrong password, and validates that the exact expected error message appears.

Test 2 (Locked Out User): Attempts to log in with the locked_out_user credentials and verifies the specific error message.

Test 3 (Successful Login & Sorting): Logs in successfully, navigates to the inventory page, sorts the products by "Price (low to high)", and extracts the prices to programmatically assert that the items are actually sorted in ascending order.

Notes:

TestContext.Progress.WriteLine is used to provide simple console logs for easy tracking of the execution steps.