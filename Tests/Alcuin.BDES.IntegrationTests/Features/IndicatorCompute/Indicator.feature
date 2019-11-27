Feature: Indicator computation

Scenario: Load and compute indicators
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Sexe  | CSP     | Nationalité | Type de contrat | Nature de la fin de contrat | Date de naissance |
		| 1254      | Alcuin    | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1986        |
		| 1255      | Alcuin    | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/04/1987        |
		| 1256      | CGI       | Homme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1987        |
		| 1257      | CGI       | Femme | Cadre   | Francaise   | CDI             | dem                         | 16/03/1987        |
		| 1235      | Alcuin    | Femme | ouvrier | Autre       | CDI             | dem                         | 16/03/1983        |
	And I have the folowing indicators definition
		| Onglet   | Domaine  | Sous Domaine      | Indicateur        | Champs            | Formule                                                                                       |
		| Effectif | Effectif | Effectif au 31/12 | Naissance 1986    | Cadre             | ∑ [matricule] par [structure] dont [CSP] est 'Cadre' et année[date de naissance] >> reference |
		| Effectif | Effectif | Effectif au 31/12 | total des cadres  | Agent de Maitrise | ∑ [matricule] par [structure] dont [CSP] est 'Cadre'                                          |
		| Effectif | Effectif | Effectif au 31/12 | total des ouvrier | Agent de Maitrise | ∑ [matricule] par [structure] dont [CSP] est 'ouv'                                            |
		| Effectif | Effectif | Effectif au 31/12 | indicateur 1      | Agent de Maitrise | ∑ [matricule] par [structure] dont [CSP] est 'Cadre' et [sexe] est 'H'                        |
		| Effectif | Effectif | Effectif au 31/12 | indicateur 2      | Agent de Maitrise | ∑ [matricule] par [structure] dont [CSP] est 'Cadre' et [Salaire mensuel brut] == '3500'      |
	When I start processing the file mybook.xlsx for the period of 1986
	Then I should found the following indicators
		| Indicator         | Group  | Count |
		| Naissance 1986    | Alcuin | 1     |
		| Naissance 1986    | CGI    | 2     |
		| total des cadres  | Alcuin | 2     |
		| total des cadres  | CGI    | 2     |
		| total des ouvrier | Alcuin | 1     |
		| total des ouvrier | CGI    | 0     |
		| indicateur 1      | Alcuin | 2     |
		| indicateur 1      | CGI    | 1     |
	And I should found the following Avertissement messages
		| Message                                                                                                                                        |
		| L'indicateur 'indicateur 2' ne sera pas calculé, il se base sur la colonne 'salaire mensuel brut' qui est manquante dans l'onglet 'effectifs'. |