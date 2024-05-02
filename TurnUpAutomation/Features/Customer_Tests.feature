Feature: This test suite tests scenarios for the following

1.Create Customer Record
2.Edit Customer Record
3.Delete Customer record

Scenario: Verify user is able to create a new Customer Record
Given user logs into turnup portal
And user navigates to the Customer page
When user creates a new Customer record
Then system should save the new Customer record

Scenario: Verify user is able to edit an existing Customer Record
Given user logs into turnup portal
And user navigates to the Customer page
When user edits an existing Customer record
Then system should save the edited Customer record

Scenario: Verify user is able to delete an existing Customer Record
Given user logs into turnup portal
And user navigates to the Customer page
When user deletes an existing Customer record
Then system should delete the Customer record
