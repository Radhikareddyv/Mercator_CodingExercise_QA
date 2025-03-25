Feature: Add Highest Price Item to Cart

  Scenario: User selects the most expensive item and adds it to the cart
    Given I navigate to the login page
    When I enter username standard_user and password secret_sauce
    And I click the login button
    Then I should be redirected to the product listing page
    When I select the highest-priced item
    Then The item should be added to the cart successfully
    When I click shopping cart badge
    And I should be redirected to the cart page
    Then I verify the highest-priced item added to the cart
