Feature: Weekly working time column Control

Scenario: Processing file within column 'Durée du temps de travail hebdomadaire' in 'effectifs' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 1254      | Alcuin    | CADRE | Homme |
		| 1235      | Alcuin    | CADRE | Femme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Warrning messages
		| Message                                                                                                                                                                       |
		| La colonne 'Durée du temps de travail hebdomadaire' n'est pas présente dans L'onglet 'effectifs', aucun indicateur lié à cette colonne ne sera calculé lors de la conversion. |

Scenario: Processing file within column 'Durée du temps de travail hebdomadaire' in 'effectifs' should have a success log
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Durée du temps de travail hebdomadaire |
		| 1254      | Alcuin    | CADRE | Homme | 35                                     |
		| 1235      | Alcuin    | CADRE | Femme | 35                                     |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succes messages
		| Message                                                                                               |
		| La colonne 'Durée du temps de travail hebdomadaire' de l’onglet 'effectifs' est bien prise en compte. |

Scenario: Processing file with empty cell in column 'Durée du temps de travail hebdomadaire' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Durée du temps de travail hebdomadaire |
		| 12345     | Alcuin    | Cadre | Homme |                                        |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Warrning messages
		| Message                                                                                                                         |
		| Certaines cellules numériques sont vides dans votre fichier, les données vides ne seront pas prises en compte dans les calculs. |

Scenario: Processing file with invalid cell content in column 'Durée du temps de travail hebdomadaire' should faild
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Durée du temps de travail hebdomadaire |
		| 1254      | Alcuin    | CADRE | Homme | 211.21                                 |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                                                                                                              |
		| Dans l'onglet «effectifs», la colonne «Durée du temps de travail hebdomadaire» contient une valeur numérique qui n’est pas dans le bon format. Le format attendu est « ####,## ». Veuillez vérifier que les valeurs numériques respectent ce format. |