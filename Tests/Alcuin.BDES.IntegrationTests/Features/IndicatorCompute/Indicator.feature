Feature: Indicator computations

Background:
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Sexe  | CSP     | Nationalité | Type de contrat | Nature de la fin de contrat | Date de naissance | Durée du temps de travail hebdomadaire | Date d'entrée | Date de sortie |
		| 1254      | Alcuin    | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1986        | 15                                     | 12/12/2012    |                |
		| 1255      | Alcuin    | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/04/1987        | 40                                     | 12/12/2012    | 13/05/2013     |
		| 1256      | CGI       | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1987        | 33                                     | 12/12/2012    | 16/03/1986     |
		| 1257      | CGI       | Femme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1987        | 40                                     | 12/12/2012    | 30/06/2019     |
		| 1235      | Alcuin    | Femme | ouvrier | Autre       | CDI             | dem                         | 16/03/1983        | 40                                     | 12/12/2012    |                |

Scenario: Generating indicator : Effectif total au 31/12
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine      | Indicateur              | Champs | Formule                                                      |
		| Effectifs | Effectif | Effectif au 31/12 | Effectif total au 31/12 | [CSP]  | Count [matricule] group by [structure] where [CSP] is 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Effectif permanent
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine      | Indicateur         | Champs | Formule                                                                                                                                         |
		| Effectifs | Effectif | Effectif au 31/12 | Effectif permanent | [CSP]  | Count [matricule] group by [structure] where [type de contrat] is 'CDI' and [Durée du temps de travail hebdomadaire] >= '35' and [CSP] = 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Nombre de salariés titulaires d'un contrat de travail à durée déterminée au 31/12
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine      | Indicateur                                                                        | Champs | Formule                                                                                     |
		| Effectifs | Effectif | Effectif au 31/12 | Nombre de salariés titulaires d'un contrat de travail à durée déterminée au 31/12 | [CSP]  | Count [matricule] group by [structure] where [type de contrat] is 'CDD' and [CSP] is 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Répartition de l'effectif total au 31/12 par sexe
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine              | Indicateur                                                | Champs | Formule                                                                           |
		| Effectifs | Effectif | Répartition de l'effectif | Répartition de l'effectif total au 31/12 pour les [Sexe]s | [CSP]  | Count [matricule] group by [structure] where [Sexe] is 'Enum' and [CSP] is 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 10 indicators

Scenario: Generating indicator : Répartition de l'effectif total au 31/12 par nationalité
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine              | Indicateur                                                            | Champs | Formule                                                                                  |
		| Effectifs | Effectif | Répartition de l'effectif | Répartition de l'effectif total au 31/12 de nationalité [Nationalité] | [CSP]  | Count [matricule] group by [structure] where [Nationalité] is 'Enum' and [CSP] is 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 10 indicators

Scenario: Generating indicator : Nombre de salariés employés en autres formes de temps partiel
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine              | Indicateur                                                    | Champs | Formule                                                                                                                          |
		| Effectifs | Effectif | Répartition de l'effectif | Nombre de salariés employés en autres formes de temps partiel | Cadre  | Count [matricule] group by [structure] where [Durée du temps de travail hebdomadaire] between '30' and '35' and [CSP] is 'Cadre' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 1 indicators

Scenario: Generating indicator : Nombre d'embauche de l'année
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine              | Indicateur        | Champs | Formule                                                                                               |
		| Effectifs | Effectif | Répartition de l'effectif | Nombre d'embauche | Cadre  | Count [matricule] group by [structure] where Yearof[Date d'entrée] is 'reference' and [CSP] is 'Cadre' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 1 indicators

Scenario: Generating indicator : Nombre de sorties de l'année
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine              | Indicateur        | Champs | Formule                                                                                                          |
		| Effectifs | Effectif | Répartition de l'effectif | Nombre d'embauche | Cadre  | Count [matricule] Group by [structure] where YearOf[Date de sortie] In ('reference','null') and [CSP] is 'Cadre' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 1 indicators

Scenario: Generating indicator :  Nombre de salariés en temps partiel (autres formes de temps partiel)
	Given I have the folowing indicators definition
		| Onglet    | Domaine                       | Sous Domaine                     | Indicateur                                                           | Champs | Formule                                                                                                                                                                                                                                |
		| Effectifs | Conditions générales d'emploi | Durée et organisation du travail | Nombre de salariés en temps partiel (autres formes de temps partiel) | [Sexe] | count [matricule] group by [structure] where [Durée du temps de travail hebdomadaire] between '30' and '35' or [Durée du temps de travail hebdomadaire] < '20' and [Sexe] is 'Enum' and YearOf[Date de sortie] in ('reference','null') |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 2 indicators

Scenario: Generating indicator :  Nombre de salariés
	Given I have the folowing indicators definition
		| Onglet    | Domaine                       | Sous Domaine                     | Indicateur         | Champs   | Formule                                |
		| Effectifs | Conditions générales d'emploi | Durée et organisation du travail | Nombre de salariés | salariés | Count [matricule] Group by [structure] |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 1 indicators