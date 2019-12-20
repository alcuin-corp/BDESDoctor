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
		| Onglet    | Domaine  | Sous Domaine      | Indicateur             | Champs | Formule                                                                                             |
		| Effectifs | Effectif | Effectif au 31/12 | Jeunes de 34 ou 33 ans | Cadre  | Count [matricule] group by [structure] where age > '20' or Age >= '31' or Age <> '33' Or age = '20' |
	When I start processing the file mybook.xlsx for the period of 2019
	Then I should found the following indicators
		| Indicator              | Group  | Count |
		| Jeunes de 34 ou 33 ans | Alcuin | 3     |
		| Jeunes de 34 ou 33 ans | CGI    | 2     |

Scenario: Load and compute indicator withing 'Age less than value' computation in filter creteria
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine      | Indicateur                | Champs | Formule                                                   |
		| Effectifs | Effectif | Effectif au 31/12 | Jeunes de plus de 33 ans  | Cadre  | Count [matricule] group by [structure] Where  Age >= '33' |
		| Effectifs | Effectif | Effectif au 31/12 | Jeunes de moins de 33 ans | Cadre  | Count [matricule] group by [structure] Where  Age < '33'  |
	When I start processing the file mybook.xlsx for the period of 2019
	Then I should found the following indicators
		| Indicator                 | Group  | Count |
		| Jeunes de plus de 33 ans  | Alcuin | 2     |
		| Jeunes de plus de 33 ans  | CGI    | 1     |
		| Jeunes de moins de 33 ans | Alcuin | 1     |
		| Jeunes de moins de 33 ans | CGI    | 1     |