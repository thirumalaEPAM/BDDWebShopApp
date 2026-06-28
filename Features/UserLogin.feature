Feature: User Login and Add Product to Cart
  As a registered user
  I want to log in to the Demo Web Shop portal
  So that I can access my account and use the application features

A short summary of the feature


  Scenario Outline: Successfully login with valid credentials
    Given I navigate to the Demo Web Shop login page
	When I enter username "<Username>" and password "<Password>" 
    And I click on the login button
    Then I should be navigated to the valid account page	

    Examples:
      | Username             | Password |
      | thiru10011192@test.com| Test@123 |
      | thiru9090011@test.com | Test@123 |
      |thiru1001@test.com     | Test@123 |


  Scenario Outline:: Add Electronic Product to Cart
    Given I navigate to the Demo Web Shop login page
	When I enter username "<Username>" and password "<Password>" 
    And I click on the login button
    And I navigate to the Electronics category page
	And I select a product from the Electronics category
    And Click on Add to Cart button
    And I navigate to my shopping cart
    Then I should see the product should be listed in my shopping cart
    
    Examples:
      | Username             | Password |
      | thiru100111922@test.com| Test@123 |

Scenario Outline: : Order a Product from Computers Category
    Given I navigate to the Demo Web Shop login page
	When I enter username "<Username>" and password "<Password>" 
    And I click on the login button
	And I navigate to the Computers Manu and Click on Desktop Submenu
	And I search for Simple Computer product and Click on Search button
    And Click on Add to Cart button
    And I Select Processor radio button
    And I navigate to my shopping cart    
    And Click on Confirmation Check box and Click on Checkout button
	And I enter billing address details and click on continue button
	And Click on shipping address continue button
	And Click on shipping method continue button
	And Click on payment method continue button
	And Click on payment information continue button
    And Click on Confirm button	    
	Then I should see order placed successfully message
    
    Examples:
      | Username             | Password |
      | thiru10011192@test.com| Test@123 |