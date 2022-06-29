Feature: Employee
	

@mytag
Scenario: Get list of Employees
	When User sends Get request
	Then User should be able to verify result successfully

Scenario:Post Create new employee
     When User sends post Create
	 Then User should be able to verify Id and see success

Scenario: Delete request
      When user sends the delete request
      Then user should be able to delete the details and see success
