Feature: Identifier column Control

Scenario: Processing file with missing column 'Matricule' in the 'effectif' worksheet should have an error message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Nom    | Prenom   | Age |
		| CAIO   | John     | 33  |
		| LEGROS | Isabelle | 33  |
	When I start processing the file mybook.xlsx for the period of 2015
	Then  I should found the following Error messages
		| Message                                                                                                                                                                                                  |
		| Dans l'onglet 'Effectifs' la colonne 'Matricule' n'est pas présente. Cette colonne est obligatoire, veuillez vérifier que la colonne est correctement nommée et que celle-ci est présente dans l’onglet. |

Scenario: Processing file within column 'Matricule' in the 'effectif' worksheet should have a success message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Nom    | Prenom   | Age |
		| 1254      | CAIO   | John     | 33  |
		| 1255      | LEGROS | Isabelle | 33  |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succes messages
		| Message                                                                  |
		| La colonne 'Matricule' de l’onglet 'Effectifs' est bien prise en compte. |

Scenario: Processing file within duplicate values in column 'Matricule' in the 'effectif' worksheet should have an error message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 1254      | Alcuin    | Cadre | Homme |
		| 1254      | Alcuin    | Cadre | Femme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                             |
		| Dans l'onglet «Effectifs» des doublons de «Matricule» ont été trouvé. Veuillez vérifier qu’il n’y est pas de «Matricule» en double. |

Scenario: Processing file with empty cell in column 'Matricule' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		|           | Alcuin    | Cadre | Homme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                              |
		| Dans l'onglet «Effectifs», la colonne «Matricule» contient des cellules texte vides. |

Scenario: Processing file with invalid cell content in column 'Matricule' should have an error message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule                                                                                                                                                                                                                                                         | Sexe  | Structure | CSP   |
		| 1235                                                                                                                                                                                                                                                              | Femme | Interne   | Cadre |
		| 125422222222222222222222222222222222222222222222222222222222222222222221111111111111111111111111111nbbbbbbvggggfffffffffdas11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111 | Homme | Externe   | Cadre |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                                                 |
		| Dans l'onglet «Effectifs», la colonne «Matricule» contient une valeur texte qui dépasse la limite des 255 caractères. Veuillez vérifier que les valeurs textes respectent cette limite. |