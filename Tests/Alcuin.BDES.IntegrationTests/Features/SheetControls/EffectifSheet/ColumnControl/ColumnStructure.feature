Feature: Structure column Control

Scenario: Processing file with missing column 'Structure' in 'effectifs' worksheet should fail
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Nom    | Prenom   | Age |
		| 1254      | CAIO   | John     | 33  |
		| 1235      | LEGROS | Isabelle | 33  |
	When I start processing the file mybook.xlsx for the period of 2015
	Then the process should fail
	And I should found the following Error messages
		| Message                                                                                                                                                                                                  |
		| Dans l'onglet 'effectifs' la colonne 'Structure' n'est pas présente. Cette colonne est obligatoire, veuillez vérifier que la colonne est correctement nommée et que celle-ci est présente dans l’onglet. |

Scenario: Processing file within column 'Structure' in 'effectifs' worksheet should have a success message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Nom    | Prenom   | Age |
		| 1254      | Alcuin    | CAIO   | John     | 33  |
		| 1235      | Alcuin    | LEGROS | Isabelle | 33  |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succes messages
		| Message                                                                  |
		| La colonne 'Structure' de l'onglet 'effectifs' est bien prise en compte. |

Scenario: Processing file with empty cell in column 'Structure' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 12345     |           | Cadre | Homme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Warrning messages
		| Message                                                                                                                     |
		| Certaines cellules textes sont vides dans votre fichier, les données vides ne seront pas prises en compte dans les calculs. |

Scenario: Processing file with invalid cell content in column 'Structure' should have an error message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Sexe  | Structure                                                                                                                                                                                                                                                         | CSP   |
		| 1235      | Femme | Alcuin                                                                                                                                                                                                                                                            | Cadre |
		| 214       | Homme | A2542222222222222222222222222222222222222222222222222222222222222222222AAAAAAAAAAAAAAAAAAAAAAAAAAAAnbbbbbbvggggfffffffffdasAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA | Cadre |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                                                 |
		| Dans l'onglet 'effectifs', la colonne 'Structure' contient la donnée [A2542222222222222222222222222222222222222222222222222222222222222222222AAAAAAAAAAAAAAAAAAAAAAAAAAAAnbbbbbbvggggfffffffffdasAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA] qui dépasse la limite des 255 caractères. |