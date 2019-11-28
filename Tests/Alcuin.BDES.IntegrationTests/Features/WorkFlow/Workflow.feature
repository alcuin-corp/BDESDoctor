Feature: Workflow control

Background:
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP   | Sexe  |
		| 1254      | Alcuin    | Cadre | Homme |
	And I have the folowing indicators definition
		| Onglet   | Domaine  | Sous Domaine      | Indicateur     | Champs | Formule                                             |
		| Effectif | Effectif | Effectif au 31/12 | Naissance 1986 | Cadre  | ∑ [matricule] par [structure] dont [CSP] == 'Cadre' |
	When I start processing the file mybook.xlsx for the period of 2015

Scenario: I should receive a notification when the process is finished
	Then I should get a notification when the process is finished

Scenario: I should receive a notification for each monitoring message
	Then all monitoring message should be notified

Scenario: I should receive a notifications with progress rate at the AnalyzingFileFormat step
	Then I should get a progress rate notification at 1 %
	And I should get a progress rate notification at 2 %
	And I should get a progress rate notification at 3 %
	And I should get a progress rate notification at 5 %

Scenario: I should receive a notifications with progress rate at the DataAnalyzing step
	Then I should get a progress rate notification at 10 %
	And I should get a progress rate notification at 20 %

Scenario: I should receive a notifications with progress rate at the IndicatorComputing step
	Then I should get a progress rate notification at 25 %
	And I should get a progress rate notification at 95 %

Scenario: I should receive a notifications with progress rate at the OutputGeneration step
	Then I should get a progress rate notification at 98 %

Scenario: I should receive a notifications with progress rate After dumping log file
	Then I should get a progress rate notification at 100 %
	And I should found a log file : log-mybook.txt

Scenario: I should get a log file with all processing errors and warrnings
	Then the log file log-mybook.txt should contain all error and warrning message