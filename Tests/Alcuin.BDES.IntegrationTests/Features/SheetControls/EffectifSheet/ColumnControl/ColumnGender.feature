﻿Feature: Gender column Control

Scenario: Processing file with missing column 'Sexe' in 'effectifs' worksheet should have an error message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Nom    | Prenom   | Age | CSP   |
		| 1254      | Alcuin    | CAIO   | John     | 33  | CADRE |
		| 1235      | Alcuin    | LEGROS | Isabelle | 33  | CADRE |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                                                             |
		| Dans l'onglet 'Effectifs' la colonne 'Sexe' n'est pas présente. Cette colonne est obligatoire, veuillez vérifier que la colonne est correctement nommée et que celle-ci est présente dans l’onglet. |

Scenario: Processing file within column 'Sexe' in 'effectifs' worksheet should have a success message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Nom    | Prenom   | Age | CSP   | Sexe  |
		| 1254      | Alcuin    | CAIO   | John     | 33  | CADRE | Homme |
		| 1235      | Alcuin    | LEGROS | Isabelle | 33  | CADRE | Femme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succes messages
		| Message                                                             |
		| La colonne 'Sexe' de l’onglet 'Effectifs' est bien prise en compte. |

Scenario: Processing file with invalid cell content in column 'Sexe' should have an error message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe |
		| 1254      | Alcuin    | Cadre | Chat |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                |
		| Dans l'onglet «Effectifs», la colonne «Sexe» à une valeur texte qui n’est pas reconnue 'Chat'. Les valeurs pouvant être utilisées sont «Homme, Femme». |

Scenario: Processing file with empty cell in column 'Sexe' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe |
		| 1254      | Alcuin    | Cadre |      |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                            |
		| Dans l'onglet «Effectifs», la colonne «Sexe» à une valeur texte qui n’est pas reconnue ''. Les valeurs pouvant être utilisées sont «Homme, Femme». |