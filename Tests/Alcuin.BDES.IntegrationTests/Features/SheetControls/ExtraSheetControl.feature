Feature: Extrasheet Control

Scenario: Processing file having extra worksheets should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet Effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 1254      | Alcuin    | CADRE | Homme |
		| 1235      | Alcuin    | CADRE | Femme |
	And it has also a workSheet otherSheet with the following content
		| Matricule | Nom  | Prenom |
		| 1254      | John | CONNOR |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Warrning messages
		| Message                                                                         |
		| D’autres onglets existent dans votre fichier, ils ne seront pas pris en compte. |