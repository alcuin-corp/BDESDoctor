Feature: Birthday column Control

Scenario: Processing file within column 'Date de naissance' in 'effectifs' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 1254      | Alcuin    | CADRE | Homme |
		| 1235      | Alcuin    | CADRE | Femme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Avertissement messages
		| Message                                                                                                                                                  |
		| La colonne 'Date de naissance' n'est pas présente dans L'onglet 'effectifs', aucun indicateur lié à cette colonne ne sera calculé lors de la conversion. |

Scenario: Processing file within column 'Date de naissance' in 'effectifs' should have a success message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Nom    | Prenom   | Age | CSP   | Sexe  | Date de naissance |
		| 1254      | Alcuin    | CAIO   | John     | 33  | CADRE | Homme | 16/03/1986        |
		| 1235      | Alcuin    | LEGROS | Isabelle | 33  | CADRE | Femme | 13/05/1993        |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succès messages
		| Message                                                                          |
		| La colonne 'Date de naissance' de l’onglet 'effectifs' est bien prise en compte. |

Scenario: Processing file with empty cell in column 'Date de naissance' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Date de naissance |
		| 1254      | Alcuin    | Cadre | Homme |                   |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Avertissement messages
		| Message                                                                                                                    |
		| Certaines cellules dates sont vides dans votre fichier, les données vides ne seront pas prises en compte dans les calculs. |

Scenario: Processing file with invalid cell content in column 'Date de naissance' should have an error message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Date de naissance |
		| 1254      | Alcuin    | CADRE | Homme | 2012/02/19        |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Erreur messages
		| Message                                                                                                                                                                                           |
		| Dans l'onglet «effectifs», la colonne «Date de naissance» contient une date n’est pas dans le bon format. Le format attendu est JJ/MM/AAAA. Veuillez vérifier que les dates respectent ce format. |