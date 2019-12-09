Feature: Age indicator computation

Background:
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Sexe  | CSP     | Date de naissance | Date de sortie |
		| 1254      | Alcuin    | Homme | Cadre   | 16/03/1985        |                |
		| 1255      | Alcuin    | Homme | Cadre   | 16/03/1978        |                |
		| 1256      | CGI       | Homme | Cadre   | 16/03/1986        |                |
		| 1257      | CGI       | Femme | Cadre   | 16/03/1988        |                |
		| 1235      | Alcuin    | Femme | ouvrier | 16/03/1990        |                |

Scenario: Load and compute indicator withing 'Age equals value' computation in filter creteria
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine      | Indicateur             | Champs | Formule                                                                               |
		| Effectifs | Effectif | Effectif au 31/12 | Jeunes de 34 ou 33 ans | Cadre  | ∑ [matricule] par [structure] dont age > 20 ou Age >= '31' ou Age <> '33' ou age = 20 |
	When I start processing the file mybook.xlsx for the period of 2019
	Then I should found the following indicators
		| Indicator              | Group  | Count |
		| Jeunes de 34 ou 33 ans | Alcuin | 0     |
		| Jeunes de 34 ou 33 ans | CGI    | 2     |

Scenario: Load and compute indicator withing 'Age less than value' computation in filter creteria
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine      | Indicateur                | Champs | Formule                                             |
		| Effectifs | Effectif | Effectif au 31/12 | Jeunes de plus de 33 ans  | Cadre  | Count [matricule] par [structure] dont  Age >= '33' |
		| Effectifs | Effectif | Effectif au 31/12 | Jeunes de moins de 33 ans | Cadre  | Count [matricule] par [structure] dont  Age << '33' |
	When I start processing the file mybook.xlsx for the period of 2019
	Then I should found the following indicators
		| Indicator                 | Group  | Count |
		| Jeunes de plus de 33 ans  | Alcuin | 2     |
		| Jeunes de plus de 33 ans  | CGI    | 1     |
		| Jeunes de moins de 33 ans | Alcuin | 1     |
		| Jeunes de moins de 33 ans | CGI    | 1     |