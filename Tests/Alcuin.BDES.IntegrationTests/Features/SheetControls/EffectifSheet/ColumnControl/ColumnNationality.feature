Feature: Nationality column Control

Scenario: Processing file within column 'Nationalité' in 'effectifs' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 1254      | Alcuin    | CADRE | Homme |
		| 1235      | Alcuin    | CADRE | Femme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Warrning messages
		| Message                                                                                                                                            |
		| La colonne 'Nationalité' n'est pas présente dans l'onglet 'effectifs', aucun indicateur lié à cette colonne ne sera calculé lors de la conversion. |

Scenario: Processing file within column 'Nationalité' in 'effectifs' should have a success message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Nationalité |
		| 12345     | Alcuin    | Cadre | Homme | Francaise   |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succes messages
		| Message                                                                    |
		| La colonne 'Nationalité' de l'onglet 'effectifs' est bien prise en compte. |

Scenario: Processing file with empty cell in column 'Nationalité' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Nationalité |
		| 12345     | Alcuin    | Cadre | Homme |             |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Warrning messages
		| Message                                                                                                                     |
		| Certaines cellules textes sont vides dans votre fichier, les données vides ne seront pas prises en compte dans les calculs. |

Scenario: Processing file with invalid cell content in column 'Nationalité' should have an error message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Nationalité  |
		| 1254      | Alcuin    | Cadre | Homme | invalid data |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                                   |
		| Dans l'onglet 'effectifs', la colonne 'Nationalité' contient une donnée non reconnue [invalid data] (valeurs autorisées [Francaise, autre]). |