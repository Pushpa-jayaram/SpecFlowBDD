Feature: Admin user search
  Verify that Admin user appears in Admin -> Users list after filtering

  Scenario: Search for Admin user and verify present
    Given the user navigates to "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login"
    When the user logs in with username "Admin" and password "admin123"
    And the user navigates to the "Admin" tab
    And the user selects User Role "Admin" and Status "Enabled"
    And the user clicks "Search"
    Then the user "Admin" should be displayed in the results