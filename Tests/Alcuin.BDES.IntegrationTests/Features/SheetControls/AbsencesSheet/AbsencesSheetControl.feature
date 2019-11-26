Feature: Absence workSheet Control
	In order to validate 'Absence' worksheet control
	As a user
	I want to control 'Absences' worksheet.

Scenario: Processing file with missing 'Absences' worksheet should fail
	Given I have a workbook mybook.xlsx
	And it has a workSheet Effectifs with the following content
		| Matricule | Nom  | Prenom |
		| 1254      | John | CONNOR |
	When I start processing the file mybook.xlsx for the period of 2015
	Then the process should fail
	And I should found the following Avertissement messages
		| Message                                                                                                                            |
		| L'onglet 'absences' n'est pas présent dans votre fichier, aucun indicateur lié aux absences ne sera calculé lors de la conversion. |

Scenario: Processing file within 'Effectifs' worksheet should have a success log
	Given I have a workbook mybook.xlsx
	And it has a workSheet Effectifs with the following content
		| Matricul | Nom  | Prenom |
		| 1254     | John | CONNOR |
	And it has also a workSheet Absences with the following content
		| Matricule | Nom  | Prenom |
		| 1254      | John | CONNOR |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succès messages
		| Message                                      |
		| L’onglet 'absences' est bien pris en compte. |