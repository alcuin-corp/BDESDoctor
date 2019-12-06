Feature: Absence Indicators

Background:
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Sexe  | CSP     | Nationalité | Type de contrat | Nature de la fin de contrat | Date de naissance | Durée du temps de travail hebdomadaire | Date d'entrée | Date de sortie |
		| 1254      | Alcuin    | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1986        | 15                                     | 12/12/2012    |                |
		| 1255      | Alcuin    | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/04/1987        | 40                                     | 12/12/2012    | 13/05/2013     |
		| 1256      | CGI       | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1987        | 33                                     | 12/12/2012    | 16/03/1986     |
		| 1257      | CGI       | Femme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1987        | 40                                     | 12/12/2012    | 30/06/2019     |
		| 1235      | Alcuin    | Femme | ouvrier | Autre       | CDI             | dem                         | 16/03/1983        | 40                                     | 12/12/2012    |                |
	And it has also a workSheet Absences with the following content
		| Matricule | Structure | CSP   | Nature de l'absence | Nombre de jour d'absence | Sexe |
		| 1254      | Alcuin    | Cadre | RTT                 | 5                        | H    |
		| 1254      | Alcuin    | Cadre | CP                  | 3                        | H    |
		| 1254      | Alcuin    | Cadre | RTT                 | 1                        | H    |
		| 1555      | CGI       | CADRE | Maladie             | 10                       | F    |

Scenario: Generating indicator :  Nombre de salariés ayant bénéficié d'un repos compensateur au titre du présent code
	Given I have the folowing indicators definition
		| Onglet   | Domaine                      | Sous Domaine                             | Indicateur                                                                          | Champs | Formule                                                                                                               |
		| Absences | Autres conditions de travail | Durée et aménagement du temps de travail | Nombre de salariés ayant bénéficié d'un repos compensateur au titre du présent code | [CSP]  | Nombre [Matricule] par [Structure] dont [Nature de l'absence] est 'repos compensateur équivalent' et [CSP] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator :  Nombre de salariés ayant bénéficié d'un repos compensateur au titre d'un régime conventionnel
	Given I have the folowing indicators definition
		| Onglet   | Domaine                      | Sous Domaine                             | Indicateur                                                                                    | Champs | Formule                                                                                                         |
		| Absences | Autres conditions de travail | Durée et aménagement du temps de travail | Nombre de salariés ayant bénéficié d'un repos compensateur au titre d'un régime conventionnel | [CSP]  | Nombre [Matricule] par [Structure] dont [Nature de l'absence] est 'repos compensateur nuit' et [CSP] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator :  Nombre de journées d'absence pour maladie
	Given I have the folowing indicators definition
		| Onglet   | Domaine               | Sous Domaine | Indicateur                                | Champs | Formule                                                                                                       |
		| Absences | Conditions de travail | Absentéisme  | Nombre de journées d'absence pour maladie | [CSP]  | Somme [Nombre de jour d'absence] par [Structure] dont [nature de l'absence] est 'maladie' et [CSP] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Nombre de journées d'absence imputables à d'autres causes
	Given I have the folowing indicators definition
		| Onglet   | Domaine               | Sous Domaine | Indicateur                                                | Champs | Formule                                                                                                                                                                                                                                       |
		| Absences | Conditions de travail | Absentéisme  | Nombre de journées d'absence imputables à d'autres causes | [CSP]  | Somme [Nombre de jour d'absence] par [structure] dont [Nature de l'absence] notin ('évènement familial','congés spéciaux','maternité', 'maladie professionnelle', 'accident de travail', 'accident de trajet', 'maladie') et [CSP] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Nombre de journées d'absence pour congés autorisés
	Given I have the folowing indicators definition
		| Onglet   | Domaine               | Sous Domaine | Indicateur                                         | Champs | Formule                                                                                                                                     |
		| Absences | Conditions de travail | Absentéisme  | Nombre de journées d'absence pour congés autorisés | [CSP]  | Somme [Nombre de jour d'absence] par [Structure] dont [nature de l'absence] dans ('évènement familial','congé spécial') et [CSP] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Nombre de journées d'absence pour maternité
	Given I have the folowing indicators definition
		| Onglet   | Domaine               | Sous Domaine | Indicateur                                  | Champs | Formule                                                                                                                 |
		| Absences | Conditions de travail | Absentéisme  | Nombre de journées d'absence pour maternité | [CSP]  | Somme [Nombre de jour d'absence] par [Structure] dont [nature de l'absence] est 'absence maternité' et [CSP] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Nombre de journées d'absence pour accident de travail, accident de trajet ou maladie professionnelle
	Given I have the folowing indicators definition
		| Onglet   | Domaine                                             | Sous Domaine                                        | Indicateur                                                                                           | Champs | Formule                                                                                                                                                                       |
		| Absences | Conditions de travail, santé et sécurité au travail | Conditions de travail, santé et sécurité au travail | Nombre de journées d'absence pour accident de travail, accident de trajet ou maladie professionnelle | [CSP]  | Somme [Nombre de jour d'absence] par [Structure] dont [nature de l'absence]  dans ('maladie professionnelle','accident de travail','accident de trajet') et [CSP] est  'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Nombre d'accidents avec arrêts de travail
	Given I have the folowing indicators definition
		| Onglet   | Domaine                                                                       | Sous Domaine                  | Indicateur                                | Champs | Formule                                                                                                                               |
		| Absences | Condition de travail et Articulation entre vie professionnelle et personnelle | Accident de travail et trajet | Nombre d'accidents avec arrêts de travail | [Sexe] | Nombre [Matricule] par [structure] dont [Nature de l'absence] dans ('accident de travail', 'accident de trajet') et [Sexe] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 2 indicators

Scenario: Generating indicator : Nombre d'accidents de trajet ayant entrainé un arrêt de travail (par sexe)
	Given I have the folowing indicators definition
		| Onglet   | Domaine                                             | Sous Domaine                                        | Indicateur                                                                 | Champs | Formule                                                                                                      |
		| Absences | Conditions de travail, santé et sécurité au travail | Conditions de travail, santé et sécurité au travail | Nombre d'accidents de trajet ayant entrainé un arrêt de travail (par sexe) | [Sexe] | Nombre [Matricule] par [structure] dont [Nature de l'absence] est 'accident de trajet'  et [Sexe] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 2 indicators

Scenario: Generating indicator : Nombre d'accidents de travail ayant entrainé un arrêt de travail
	Given I have the folowing indicators definition
		| Onglet   | Domaine                                             | Sous Domaine                                        | Indicateur                                                       | Champs | Formule                                                                                                       |
		| Absences | Conditions de travail, santé et sécurité au travail | Conditions de travail, santé et sécurité au travail | Nombre d'accidents de travail ayant entrainé un arrêt de travail | [Sexe] | Nombre [Matricule] par [structure] dont [Nature de l'absence] est 'accident de travail'  et [Sexe] est 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 2 indicators