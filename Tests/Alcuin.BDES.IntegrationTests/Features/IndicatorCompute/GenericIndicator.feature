Feature: Generic indicator computation

Background:
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Sexe  | CSP     | Nationalité | Type de contrat | Nature de la fin de contrat | Date de naissance | Durée du temps de travail hebdomadaire | Date d'entrée | Date de sortie |
		| 1254      | Alcuin    | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1986        | 40                                     | 12/12/2012    |                |
		| 1255      | Alcuin    | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/04/1987        | 40                                     | 12/12/2015    |                |
		| 1256      | CGI       | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1987        | 40                                     | 12/12/2012    |                |
		| 1257      | CGI       | Femme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1987        | 40                                     | 12/12/2013    |                |
		| 1235      | Alcuin    | Femme | ouvrier | Autre       | CDI             | dem                         | 16/03/1983        | 40                                     | 12/12/2012    |                |

Scenario: Load and compute simple generic indicators
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine      | Indicateur      | Champs | Formule                                                     |
		| Effectifs | Effectif | Effectif au 31/12 | Nombre de [CSP] | Cadre  | Count [matricule] group by [structure] where [CSP] = 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators
	And I should found the following indicators
		| Indicator       | Group  | Count |
		| Nombre de Cadre | Alcuin | 2     |
		| Nombre de Cadre | CGI    | 2     |

Scenario: Load and compute generic indicators
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine      | Indicateur             | Champs | Formule                                                                           |
		| Effectifs | Effectif | Effectif au 31/12 | Nombre de [CSP] [sexe] | Cadre  | Count [matricule] group by [structure] where [CSP] is 'Enum' and [Sexe] is 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 10 indicators

Scenario: Load and compute generic complexe indicators
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine      | Indicateur                                                  | Champs | Formule                                                                                                                    |
		| Effectifs | Effectif | Effectif au 31/12 | Nombre de [CSP] par [Nature de la fin de contrat] et [Sexe] | Cadre  | Count [matricule] group by [structure] where [CSP] = 'Enum' and [Sexe] = 'Enum' and [Nature de la fin de contrat] = 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 80 indicators