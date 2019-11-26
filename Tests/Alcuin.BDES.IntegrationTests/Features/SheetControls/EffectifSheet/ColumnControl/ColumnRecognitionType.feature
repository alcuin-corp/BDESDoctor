Feature: Recognition type column Control

Scenario: Processing file within column 'Type de reconnaissance' in 'effectifs' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 1254      | Alcuin    | CADRE | Homme |
		| 1235      | Alcuin    | CADRE | Femme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Avertissement messages
		| Message                                                                                                                                                       |
		| La colonne 'Type de reconnaissance' n'est pas présente dans L'onglet 'effectifs', aucun indicateur lié à cette colonne ne sera calculé lors de la conversion. |

Scenario: Processing file within column 'Type de reconnaissance' in 'effectifs' should have a success message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Type de reconnaissance |
		| 1254      | Alcuin    | CADRE | Homme | T1                     |
		| 1235      | Alcuin    | CADRE | Femme | T2                     |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succès messages
		| Message                                                                               |
		| La colonne 'Type de reconnaissance' de l’onglet 'effectifs' est bien prise en compte. |

Scenario: Processing file with empty cell in column 'Type de reconnaissance' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Type de reconnaissance |
		| 12345     | Alcuin    | Cadre | Homme |                        |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Avertissement messages
		| Message                                                                                                                     |
		| Certaines cellules textes sont vides dans votre fichier, les données vides ne seront pas prises en compte dans les calculs. |

Scenario: Processing file with invalid cell content in column 'Type de reconnaissance' should faild
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Type de reconnaissance |
		| 1254      | Alcuin    | Cadre | Homme | HTTP                   |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Erreur messages
		| Message                                                                                                                                                          |
		| Dans l'onglet «effectifs», la colonne «Type de reconnaissance» à une valeur qui texte n’est pas reconnue 'HTTP'. Les valeurs pouvant être utilisées sont «RQTH». |