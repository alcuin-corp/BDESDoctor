﻿Feature: Contract type column Control

Scenario: Processing file within column 'Type de contrat' in 'effectifs' worksheet should have a success log
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Type de contrat |
		| 1254      | Alcuin    | CADRE | Homme | CDI             |
		| 1235      | Alcuin    | CADRE | Femme | CDD             |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succes messages
		| Message                                                                        |
		| La colonne 'Type de contrat' de l’onglet 'Effectifs' est bien prise en compte. |

Scenario: Processing file within column 'Type de contrat' in 'effectifs' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 1254      | Alcuin    | CADRE | Homme |
		| 1235      | Alcuin    | CADRE | Femme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Warrning messages
		| Message                                                                                                                                                |
		| La colonne 'Type de contrat' n'est pas présente dans L'onglet 'Effectifs', aucun indicateur lié à cette colonne ne sera calculé lors de la conversion. |

Scenario: Processing file with empty cell in column 'Type de contrat' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Type de contrat |
		| 12345     | Alcuin    | Cadre | Homme |                 |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                                                                                |
		| Dans l'onglet «Effectifs», la colonne «Type de contrat» à une valeur texte qui n’est pas reconnue ''. Les valeurs pouvant être utilisées sont «CDI, CDD, CIE, Alternance, Professionnalisation, CTT, CUI, CAE, Stage». |

Scenario: Processing file with invalid cell content in column 'Type de contrat' should faild
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  | Type de contrat |
		| 1254      | Alcuin    | Cadre | Homme | Contrat         |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                                                                                       |
		| Dans l'onglet «Effectifs», la colonne «Type de contrat» à une valeur texte qui n’est pas reconnue 'Contrat'. Les valeurs pouvant être utilisées sont «CDI, CDD, CIE, Alternance, Professionnalisation, CTT, CUI, CAE, Stage». |