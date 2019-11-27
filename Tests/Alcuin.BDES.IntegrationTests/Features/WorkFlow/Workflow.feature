Feature: Workflow control

Scenario: All monitoring messages should be notified
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 1254      | Alcuin    | Cadre | Homme |
	And I have the folowing indicators definition
		| Onglet   | Domaine  | Sous Domaine      | Indicateur     | Champs | Formule                                             |
		| Effectif | Effectif | Effectif au 31/12 | Naissance 1986 | Cadre  | ∑ [matricule] par [structure] dont [CSP] == 'Cadre' |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should get a notification when the process is finished
	And all monitoring message should be notified
	And I should get a progress rate notification at 1 %
	And I should get a progress rate notification at 5 %
	And I should get a progress rate notification at 15 %
	And I should get a progress rate notification at 75 %
	And I should get a progress rate notification at 100 %