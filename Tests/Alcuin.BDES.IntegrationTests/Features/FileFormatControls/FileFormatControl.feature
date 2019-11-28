Feature: File format control

Scenario: Processing file with wrong extension should fail
	Given I have a workbook Alcuin.xls
	When I start processing the file Alcuin.xls for the period of 2015
	Then the process should fail
	And the process should be exited in the step : FileAnalyzing
	And I should found the following Error messages
		| Message                                                                                                            |
		| le format du fichier chargé est incorrect. Veuillez vérifier qu’il est bien au format Excel avec l’extension .xlsx |

Scenario: File with correct extension should be accepted
	Given I have a workbook Alcuin.xlsx
	When I start processing the file Alcuin.xlsx for the period of 2015
	Then I should found the following Succes messages
		| Message                           |
		| Le format de fichier est correct. |