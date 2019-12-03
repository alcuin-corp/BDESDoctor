﻿Feature: Indicator computations

Background:
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Sexe  | CSP     | Nationalité | Type de contrat | Nature de la fin de contrat | Date de naissance | Durée du temps de travail hebdomadaire |
		| 1254      | Alcuin    | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1986        | 40                                     |
		| 1255      | Alcuin    | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/04/1987        | 40                                     |
		| 1256      | CGI       | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1987        | 40                                     |
		| 1257      | CGI       | Femme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1987        | 40                                     |
		| 1235      | Alcuin    | Femme | ouvrier | Autre       | CDI             | dem                         | 16/03/1983        | 40                                     |

Scenario: Generating indicator : Effectif total au 31/12
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine      | Indicateur              | Champs | Formule                                                  |
		| Effectifs | Effectif | Effectif au 31/12 | Effectif total au 31/12 | [CSP]  | Nombre [matricule] par [structure] dont [CSP] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Effectif permanent
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine      | Indicateur         | Champs | Formule                                                                                                                                     |
		| Effectifs | Effectif | Effectif au 31/12 | Effectif permanent | [CSP]  | Nombre [matricule] par [structure] dont [type de contrat] est 'CDI' et [Durée du temps de travail hebdomadaire] >= '35' et [CSP] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Nombre de salariés titulaires d'un contrat de travail à durée déterminée au 31/12
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine      | Indicateur                                                                        | Champs | Formule                                                                                 |
		| Effectifs | Effectif | Effectif au 31/12 | Nombre de salariés titulaires d'un contrat de travail à durée déterminée au 31/12 | [CSP]  | Nombre [matricule] par [structure] dont [type de contrat] est 'CDD' et [CSP] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Répartition de l'effectif total au 31/12 par sexe
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine              | Indicateur                                                | Champs | Formule                                                                       |
		| Effectifs | Effectif | Répartition de l'effectif | Répartition de l'effectif total au 31/12 pour les [Sexe]s | [CSP]  | Nombre [matricule] par [structure] dont [Sexe] est 'Enum' et [CSP] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 10 indicators

Scenario: Generating indicator : Répartition de l'effectif total au 31/12 par nationalité
	Given I have the folowing indicators definition
		| Onglet    | Domaine  | Sous Domaine              | Indicateur                                                            | Champs | Formule                                                                              |
		| Effectifs | Effectif | Répartition de l'effectif | Répartition de l'effectif total au 31/12 de nationalité [Nationalité] | [CSP]  | Nombre [matricule] par [structure] dont [Nationalité] est 'Enum' et [CSP] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 10 indicators