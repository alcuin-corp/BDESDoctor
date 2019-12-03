Feature: Contract termination nature column Control

Scenario: Processing file within column 'Nature de la fin de contrat' in 'effectifs' worksheet should have a success log
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Nom    | Prenom   | Age | CSP   | Sexe  | Date de naissance | Type de contrat | Date d'entrée | Date de sortie | Nature de la fin de contrat |
		| 1254      | Alcuin    | CAIO   | John     | 33  | CADRE | Homme | 16/03/1986        | CDI             | 12/11/2019    | 12/11/2021     | Dem                         |
		| 1235      | Alcuin    | LEGROS | Isabelle | 33  | CADRE | Femme | 13/05/1993        | CDD             | 14/11/2019    | 14/11/2020     | Dem                         |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succes messages
		| Message                                                                                    |
		| La colonne 'Nature de la fin de contrat' de l’onglet 'Effectifs' est bien prise en compte. |

Scenario: Processing file without column 'Nature de la fin de contrat' in 'effectifs' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 1254      | Alcuin    | CADRE | Homme |
		| 1235      | Alcuin    | CADRE | Femme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Warrning messages
		| Message                                                                                                                                                            |
		| La colonne 'Nature de la fin de contrat' n'est pas présente dans L'onglet 'Effectifs', aucun indicateur lié à cette colonne ne sera calculé lors de la conversion. |

Scenario: Processing file with invalid cell content in column 'Nature de la fin de contrat' should faild
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Nature de la fin de contrat |
		| 1254      | Alcuin    | Cadre | Homme | Contrat                     |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                                                                                                                  |
		| Dans l'onglet «Effectifs», la colonne «Nature de la fin de contrat» à une valeur texte qui n’est pas reconnue 'Contrat'. Les valeurs pouvant être utilisées sont «Retraite, Démission, Fin de CDD, Licenciement, Licenciement économique, Pré-retraite». |