Feature: Raw monthly salary column Control

Scenario: Processing file within column 'Salaire mensuel brut' in 'effectifs' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 1254      | Alcuin    | CADRE | Homme |
		| 1235      | Alcuin    | CADRE | Femme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Warrning messages
		| Message                                                                                                                                                     |
		| La colonne 'Salaire mensuel brut' n'est pas présente dans L'onglet 'Effectifs', aucun indicateur lié à cette colonne ne sera calculé lors de la conversion. |

Scenario: Processing file within column 'Salaire mensuel brut' in 'effectifs' should have a success log
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Nom    | Prenom   | Age | CSP   | Sexe  | Date de naissance | Type de contrat | Date d'entrée | Date de sortie | Nature de la fin de contrat | Horaire hebdomadaire | Salaire mensuel brut |
		| 1254      | Alcuin    | CAIO   | John     | 33  | CADRE | Homme | 16/03/1986        | CDI             | 12/11/2019    | 12/11/2021     | Dem                         | 35                   | 55000                |
		| 1235      | Alcuin    | LEGROS | Isabelle | 33  | CADRE | Femme | 13/05/1993        | CDD             | 14/11/2019    | 14/11/2020     | Dem                         | 38                   | 35000                |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succes messages
		| Message                                                                             |
		| La colonne 'Salaire mensuel brut' de l’onglet 'Effectifs' est bien prise en compte. |

Scenario: Processing file with empty cell in column 'Salaire mensuel brut' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Salaire mensuel brut |
		| 12345     | Alcuin    | Cadre | Homme |                      |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                                                                                            |
		| Dans l'onglet «Effectifs», la colonne «Salaire mensuel brut» contient une valeur numérique qui n’est pas dans le bon format. Le format attendu est « ####,## ». Veuillez vérifier que les valeurs numériques respectent ce format. |

Scenario: Processing file with invalid cell content in column 'Salaire mensuel brut' should faild
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Salaire mensuel brut |
		| 1254      | Alcuin    | CADRE | Homme | 211.21               |
		| 1235      | Alcuin    | CADRE | Femme | 254                  |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                                                                                            |
		| Dans l'onglet «Effectifs», la colonne «Salaire mensuel brut» contient une valeur numérique qui n’est pas dans le bon format. Le format attendu est « ####,## ». Veuillez vérifier que les valeurs numériques respectent ce format. |