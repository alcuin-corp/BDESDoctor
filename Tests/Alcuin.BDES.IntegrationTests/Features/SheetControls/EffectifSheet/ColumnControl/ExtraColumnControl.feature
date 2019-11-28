Feature: ExtraColumnControl

Scenario: Processing file within extra columns in 'effectifs' worksheet should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Nom    | Prenom   | Age | CSP   | Sexe  |
		| 1254      | Alcuin    | CAIO   | John     | 33  | CADRE | Homme |
		| 1235      | Alcuin    | LEGROS | Isabelle | 33  | CADRE | Femme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Warrning messages
		| Message                                                                                                                                                   |
		| Des colonnes non reconnues sont présentes dans votre fichier, elles ne seront pas prises en compte. Veuillez vérifier que les colonnes sont bien nommées. |

