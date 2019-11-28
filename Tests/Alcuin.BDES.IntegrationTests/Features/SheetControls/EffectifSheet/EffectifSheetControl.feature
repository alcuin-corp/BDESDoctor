Feature: Effectif workSheet Control
	In order to validate 'Effectif' worksheet control
	As a user
	I want to control 'effectif' worksheet.

Scenario: Processing file with missing 'Effectif' worksheet should fail
	Given I have a workbook mybook.xlsx
	And it has a workSheet MySheet with the following content
		| Matricul | Nom  | Prenom |
		| 1254     | John | CONNOR |
	When I start processing the file mybook.xlsx for the period of 2015
	Then the process should fail
	And I should found the following Error messages
		| Message                                                                                                                                                                            |
		| L'onglet 'effectifs' n'est pas présent dans le fichier, cet onglet est obligatoire. Veuillez vérifier que cet onglet est bien nommé ainsi et qu'il est présent dans votre fichier. |

Scenario: Processing file within 'Effectifs' worksheet should have a success log
	Given I have a workbook mybook.xlsx
	And it has a workSheet Effectifs with the following content
		| Matricule | Nom  | Prenom |
		| 1254      | John | CONNOR |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succes messages
		| Message                                       |
		| L’onglet 'effectifs' est bien pris en compte. |