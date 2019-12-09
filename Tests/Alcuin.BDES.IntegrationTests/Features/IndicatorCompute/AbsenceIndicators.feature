Feature: Absence Indicators

Background:
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Sexe  | CSP     | Nationalité | Type de contrat | Nature de la fin de contrat | Date de naissance | Durée du temps de travail hebdomadaire | Date d'entrée | Date de sortie |
	And it has also a workSheet Absences with the following content
		| Matricule | Structure | CSP   | Nature de l'absence | Nombre de jour d'absence | Sexe |
		| 1254      | Alcuin    | Cadre | RTT                 | 5                        | H    |
		| 1254      | Alcuin    | Cadre | CP                  | 3                        | H    |
		| 1254      | Alcuin    | Cadre | RTT                 | 1                        | H    |
		| 1555      | CGI       | CADRE | Maladie             | 10                       | F    |

Scenario: Generating indicator :  Nombre de salariés ayant bénéficié d'un repos compensateur au titre du présent code
	Given I have the folowing indicators definition
		| Onglet   | Domaine                      | Sous Domaine                             | Indicateur                                                                          | Champs | Formule                                                                                                                 |
		| Absences | Autres conditions de travail | Durée et aménagement du temps de travail | Nombre de salariés ayant bénéficié d'un repos compensateur au titre du présent code | [CSP]  | Count [Matricule] group by [Structure] Where [Nature de l'absence] = 'repos compensateur équivalent' And [CSP] = 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator :  Nombre de salariés ayant bénéficié d'un repos compensateur au titre d'un régime conventionnel
	Given I have the folowing indicators definition
		| Onglet   | Domaine                      | Sous Domaine                             | Indicateur                                                                                    | Champs | Formule                                                                                                           |
		| Absences | Autres conditions de travail | Durée et aménagement du temps de travail | Nombre de salariés ayant bénéficié d'un repos compensateur au titre d'un régime conventionnel | [CSP]  | Count [Matricule] group by [Structure] Where [Nature de l'absence] = 'repos compensateur nuit' And [CSP] = 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator :  Nombre de journées d'absence pour maladie
	Given I have the folowing indicators definition
		| Onglet   | Domaine               | Sous Domaine | Indicateur                                | Champs | Formule                                                                                                        |
		| Absences | Conditions de travail | Absentéisme  | Nombre de journées d'absence pour maladie | [CSP]  | Sum [Nombre de jour d'absence] Group by [Structure] Where [nature de l'absence] = 'maladie' And [CSP] = 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Nombre de journées d'absence imputables à d'autres causes
	Given I have the folowing indicators definition
		| Onglet   | Domaine               | Sous Domaine | Indicateur                                                | Champs | Formule                                                                                                                                                                                                                                          |
		| Absences | Conditions de travail | Absentéisme  | Nombre de journées d'absence imputables à d'autres causes | [CSP]  | Sum [Nombre de jour d'absence] Group by [structure] Where [Nature de l'absence] notin ('évènement familial','congés spéciaux','maternité', 'maladie professionnelle', 'accident de travail', 'accident de trajet', 'maladie') And [CSP] = 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Nombre de journées d'absence pour congés autorisés
	Given I have the folowing indicators definition
		| Onglet   | Domaine               | Sous Domaine | Indicateur                                         | Champs | Formule                                                                                                                                      |
		| Absences | Conditions de travail | Absentéisme  | Nombre de journées d'absence pour congés autorisés | [CSP]  | Sum [Nombre de jour d'absence] Group by [Structure] Where [nature de l'absence] In ('évènement familial','congé spécial') And [CSP] = 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Nombre de journées d'absence pour maternité
	Given I have the folowing indicators definition
		| Onglet   | Domaine               | Sous Domaine | Indicateur                                  | Champs | Formule                                                                                                                  |
		| Absences | Conditions de travail | Absentéisme  | Nombre de journées d'absence pour maternité | [CSP]  | Sum [Nombre de jour d'absence] Group by [Structure] Where [nature de l'absence] = 'absence maternité' And [CSP] = 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Nombre de journées d'absence pour accident de travail, accident de trajet ou maladie professionnelle
	Given I have the folowing indicators definition
		| Onglet   | Domaine                                             | Sous Domaine                                        | Indicateur                                                                                           | Champs | Formule                                                                                                                                                                            |
		| Absences | Conditions de travail, santé et sécurité au travail | Conditions de travail, santé et sécurité au travail | Nombre de journées d'absence pour accident de travail, accident de trajet ou maladie professionnelle | [CSP]  | Sum [Nombre de jour d'absence] Group by [Structure] Where [nature de l'absence]  dans ('maladie professionnelle','accident de travail','accident de trajet') And [CSP] est  'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 5 indicators

Scenario: Generating indicator : Nombre d'accidents avec arrêts de travail
	Given I have the folowing indicators definition
		| Onglet   | Domaine                                                                       | Sous Domaine                  | Indicateur                                | Champs | Formule                                                                                                                                 |
		| Absences | Condition de travail et Articulation entre vie professionnelle et personnelle | Accident de travail et trajet | Nombre d'accidents avec arrêts de travail | [Sexe] | Count [Matricule] group by [Structure] Where [Nature de l'absence] In ('accident de travail', 'accident de trajet') And [Sexe] = 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 2 indicators

Scenario: Generating indicator : Nombre d'accidents de trajet ayant entrainé un arrêt de travail (par sexe)
	Given I have the folowing indicators definition
		| Onglet   | Domaine                                             | Sous Domaine                                        | Indicateur                                                                 | Champs | Formule                                                                                                       |
		| Absences | Conditions de travail, santé et sécurité au travail | Conditions de travail, santé et sécurité au travail | Nombre d'accidents de trajet ayant entrainé un arrêt de travail (par sexe) | [Sexe] | Count [Matricule] group by [Structure] Where [Nature de l'absence] = 'accident de trajet' And [Sexe] = 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 2 indicators

Scenario: Generating indicator : Nombre d'accidents de travail ayant entrainé un arrêt de travail
	Given I have the folowing indicators definition
		| Onglet   | Domaine                                             | Sous Domaine                                        | Indicateur                                                       | Champs | Formule                                                                                                        |
		| Absences | Conditions de travail, santé et sécurité au travail | Conditions de travail, santé et sécurité au travail | Nombre d'accidents de travail ayant entrainé un arrêt de travail | [Sexe] | Count [Matricule] group by [Structure] Where [Nature de l'absence] = 'accident de travail' And [Sexe] = 'Enum' |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should compute 2 indicators