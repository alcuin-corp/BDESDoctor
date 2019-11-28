Feature: Empty Column Header Control

Scenario: Processing file within empty column header should not fail
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure |        |          | Age | CSP   | Sexe  |
		| 1254      | Alcuin    | CAIO   | John     | 33  | CADRE | Homme |
		| 1235      | Alcuin    | LEGROS | Isabelle | 33  | CADRE | Femme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should get a progress rate notification at 20 %