Feature: Workflow control
Scenario: All monitoring messages should be notified
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP       | Sexe  |
		| 1254      | Alcuin    | Cadre | Homme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should get a notification when the process is finished
	And all monitoring message should be notified