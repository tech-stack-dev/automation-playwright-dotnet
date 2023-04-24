Feature: ContactUs

@Regression @ContactUsForm @TSWEB149
Scenario: CheckErrorMessagesForRequiredFieldsWithSpacesOnContactForm
	Given User is on career website
	When User clicks on 'Contact us' tab on 'NavigationHeader' container
	Then 'Contact us' title is displayed on Contact Us form
	When User set '     ' text to 'Full name' input on 'ContactUsPage' container
	When User set '     ' text to 'Email' input on 'ContactUsPage' container
	When User set '     ' text to 'Tel' input on 'ContactUsPage' container
	When User clicks 'Submit' button on 'ContactUsPage' container
	Then Error messages are displayed under fields
		| Input     | ErrorMessage                      |
		| Full name | Please enter your name1            |
		| Email     | Please enter a valid email        |
		| Tel       | Please enter a valid phone number |