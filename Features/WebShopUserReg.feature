Feature: User Registration
  As a new user
  I want to register on the Demo Web Shop portal
  So that I can access the application

  Scenario: Successfully register a new user
    Given I navigate to the Demo Web Shop registration page
    When I enter valid registration details
      | Gender | FirstName | LastName | Email            | Password | ConfirmPassword |
      | female   | thirumala      | rajolu      | thirumala2026@test.com | Test@123 | Test@123        |
    And I click on the register button
    Then I should see the registration success message
    And my account should be created successfully

