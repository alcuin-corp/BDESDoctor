Feature: Identifier column Control

Scenario: Processing file with missing column 'Matricule' in the 'Absences' worksheet should fail
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 12345     | Alcuin    | Cadre | Homme |
	And it has also a workSheet Absences with the following content
		| Id   | Nom  | Prenom |
		| 1254 | John | CONNOR |
	When I start processing the file mybook.xlsx for the period of 2015
	Then the process should fail
	And I should found the following Error messages
		| Message                                                                                                                                                                                                 |
		| Dans l'onglet 'absences' la colonne 'Matricule' n'est pas présente. Cette colonne est obligatoire, veuillez vérifier que la colonne est correctement nommée et que celle-ci est présente dans l’onglet. |

Scenario: Processing file within column 'Matricule' in the 'effectif' worksheet should have a success log
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 12345     | Alcuin    | Cadre | Homme |
	And it has also a workSheet Absences with the following content
		| Matricule | Col1 | Col2   |
		| 1254      | John | CONNOR |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succes messages
		| Message                                                                 |
		| La colonne 'Matricule' de l’onglet 'absences' est bien prise en compte. |

Scenario: Processing file with empty cell in column 'Matricule' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 12345     | Alcuin    | Cadre | Homme |
	And it has also a workSheet Absences with the following content
		| Matricule | Col1 | Col2   |
		|           | John | CONNOR |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Warrning messages
		| Message                                                                                                                     |
		| Certaines cellules textes sont vides dans votre fichier, les données vides ne seront pas prises en compte dans les calculs. |

Scenario: Processing file with invalid cell content in column 'Matricule' should have an error message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 12345     | Alcuin    | Cadre | Homme |
	And it has also a workSheet Absences with the following content
		| Matricule                                                                                                                                                                                                                                                         | Col1 | Col2   |
		| 125422222222222222222222222222222222222222222222222222222222222222222221111111111111111111111111111nbbbbbbvggggfffffffffdas11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111 | John | CONNOR |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                                                |
		| Dans l'onglet «absences», la colonne «Matricule» contient une valeur texte qui dépasse la limite des 255 caractères. Veuillez vérifier que les valeurs textes respectent cette limite. |