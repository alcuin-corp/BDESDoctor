Feature: Leaving date column Control

Scenario: Processing file within column 'Date de sortie' in 'effectifs' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 1254      | Alcuin    | CADRE | Homme |
		| 1235      | Alcuin    | CADRE | Femme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Warrning messages
		| Message                                                                                                                                               |
		| La colonne 'Date de sortie' n'est pas présente dans L'onglet 'Effectifs', aucun indicateur lié à cette colonne ne sera calculé lors de la conversion. |

Scenario: Processing file within column 'Date de sortie' in 'effectifs' worksheet should have a success log
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Nom    | Prenom   | Age | CSP   | Sexe  | Date de naissance | Type de contrat | Date d'entrée | Date de sortie |
		| 1254      | Alcuin    | CAIO   | John     | 33  | CADRE | Homme | 16/03/1986        | CDI             | 12/11/2019    | 12/11/2021     |
		| 1235      | Alcuin    | LEGROS | Isabelle | 33  | CADRE | Femme | 13/05/1993        | CDD             | 14/11/2019    | 14/11/2020     |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succes messages
		| Message                                                                       |
		| La colonne 'Date de sortie' de l’onglet 'Effectifs' est bien prise en compte. |

Scenario: Processing file with invalid cell content in column 'Date de sortie' should faild
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Date de sortie |
		| 1254      | Alcuin    | CADRE | Homme | 31/AA/2019     |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                                                        |
		| Dans l'onglet «Effectifs», la colonne «Date de sortie» contient une date n’est pas dans le bon format. Le format attendu est JJ/MM/AAAA. Veuillez vérifier que les dates respectent ce format. |