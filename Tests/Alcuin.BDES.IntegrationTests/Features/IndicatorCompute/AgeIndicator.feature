Feature: Age indicator computation

Scenario: Load and compute indicator withing 'Age equals value' computation in filter creteria
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Sexe  | CSP     | Date de naissance |
		| 1254      | Alcuin    | Homme | Cadre   | 16/03/1985        |
		| 1255      | Alcuin    | Homme | Cadre   | 16/03/1978        |
		| 1256      | CGI       | Homme | Cadre   | 16/03/1986        |
		| 1257      | CGI       | Femme | Cadre   | 16/03/1988        |
		| 1235      | Alcuin    | Femme | ouvrier | 16/03/1990        |
	And I have the folowing indicators definition
		| Onglet   | Domaine  | Sous Domaine      | Indicateur             | Champs | Formule                                                    |
		| Effectif | Effectif | Effectif au 31/12 | Jeunes de 34 ans       | Cadre  | ∑ [matricule] par [structure] dont  Age == 34              |
		| Effectif | Effectif | Effectif au 31/12 | Jeunes de 34 ou 33 ans | Cadre  | ∑ [matricule] par [structure] dont  Age == 31 ou Age == 33 |
	When I start processing the file mybook.xlsx for the period of 2019
	Then I should found the following indicators
		| Indicator              | Group  | Count |
		| Jeunes de 34 ans       | Alcuin | 1     |
		| Jeunes de 34 ans       | CGI    | 0     |
		| Jeunes de 34 ou 33 ans | Alcuin | 0     |
		| Jeunes de 34 ou 33 ans | CGI    | 2     |

Scenario: Load and compute indicator withing 'Age less than value' computation in filter creteria
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Sexe  | CSP     | Date de naissance |
		| 1254      | Alcuin    | Homme | Cadre   | 16/03/1985        |
		| 1255      | Alcuin    | Homme | Cadre   | 16/03/1978        |
		| 1256      | CGI       | Homme | Cadre   | 16/03/1986        |
		| 1257      | CGI       | Femme | Cadre   | 16/03/1988        |
		| 1235      | Alcuin    | Femme | ouvrier | 16/03/1990        |
	And I have the folowing indicators definition
		| Onglet   | Domaine  | Sous Domaine      | Indicateur                | Champs | Formule                                       |
		| Effectif | Effectif | Effectif au 31/12 | Jeunes de plus de 33 ans  | Cadre  | ∑ [matricule] par [structure] dont  Age >= 33 |
		| Effectif | Effectif | Effectif au 31/12 | Jeunes de moins de 33 ans | Cadre  | ∑ [matricule] par [structure] dont  Age << 33 |
	When I start processing the file mybook.xlsx for the period of 2019
	Then I should found the following indicators
		| Indicator                 | Group  | Count |
		| Jeunes de plus de 33 ans  | Alcuin | 2     |
		| Jeunes de plus de 33 ans  | CGI    | 1     |
		| Jeunes de moins de 33 ans | Alcuin | 1     |
		| Jeunes de moins de 33 ans | CGI    | 1     |