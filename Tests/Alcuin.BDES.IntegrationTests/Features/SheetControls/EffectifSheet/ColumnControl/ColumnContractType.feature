Feature: Contract type column Control

Scenario: Processing file within column 'Type de contrat' in 'effectifs' worksheet should have a success log
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Type de contrat |
		| 1254      | Alcuin    | CADRE | Homme | CDI             |
		| 1235      | Alcuin    | CADRE | Femme | CDD             |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succès messages
		| Message                                                                        |
		| La colonne 'Type de contrat' de l’onglet 'effectifs' est bien prise en compte. |

Scenario: Processing file within column 'Type de contrat' in 'effectifs' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 1254      | Alcuin    | CADRE | Homme |
		| 1235      | Alcuin    | CADRE | Femme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Avertissement messages
		| Message                                                                                                                                                |
		| La colonne 'Type de contrat' n'est pas présente dans L'onglet 'effectifs', aucun indicateur lié à cette colonne ne sera calculé lors de la conversion. |

Scenario: Processing file with empty cell in column 'Type de contrat' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Type de contrat |
		| 12345     | Alcuin    | Cadre | Homme |                 |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Avertissement messages
		| Message                                                                                                                     |
		| Certaines cellules textes sont vides dans votre fichier, les données vides ne seront pas prises en compte dans les calculs. |

Scenario: Processing file with invalid cell content in column 'Type de contrat' should faild
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Type de contrat |
		| 1254      | Alcuin    | Cadre | Homme | Contrat         |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Erreur messages
		| Message                                                                                                                                                                                                                |
		| Dans l'onglet «effectifs», la colonne «Type de contrat» à une valeur qui texte n’est pas reconnue 'Contrat'. Les valeurs pouvant être utilisées sont «CDI, CDD, CIE, Alternance, Professionnalisation, CTT, CUI, CAE». |