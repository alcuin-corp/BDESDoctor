Feature: CSP column Control

Scenario: Processing file with missing column 'CSP' in 'effectifs' worksheet should fail
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Nom    | Prenom   | Age |
		| 1254      | Alcuin    | CAIO   | John     | 33  |
		| 1235      | Alcuin    | LEGROS | Isabelle | 33  |
	When I start processing the file mybook.xlsx for the period of 2015
	Then the process should fail
	And I should found the following Error messages
		| Message                                                                                                                                                                                            |
		| Dans l'onglet 'effectifs' la colonne 'CSP' n'est pas présente. Cette colonne est obligatoire, veuillez vérifier que la colonne est correctement nommée et que celle-ci est présente dans l’onglet. |

Scenario: Processing file within column 'CSP' in 'effectifs' should have a success message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | Nom    | Prenom   | Age | CSP   |
		| 1254      | Alcuin    | CAIO   | John     | 33  | CADRE |
		| 1235      | Alcuin    | LEGROS | Isabelle | 33  | CADRE |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Succes messages
		| Message                                                            |
		| La colonne 'CSP' de l'onglet 'effectifs' est bien prise en compte. |

Scenario: Processing file with empty cell in column 'CSP' should have a warrning message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP | Sexe  |
		| 12345     | Alcuin    |     | Homme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Warrning messages
		| Message                                                                                                                     |
		| Certaines cellules textes sont vides dans votre fichier, les données vides ne seront pas prises en compte dans les calculs. |

Scenario: Processing file with invalid cell content in column 'CSP' should an error message
	Given I have a workbook mybook.xlsx
	And it has a workSheet effectifs with the following content
		| Matricule | Structure | CSP       | Sexe  |
		| 1254      | Alcuin    | Ingénieur | Homme |
	When I start processing the file mybook.xlsx for the period of 2015
	Then I should found the following Error messages
		| Message                                                                                                                                                                                              |
		| Dans l'onglet 'effectifs', la colonne 'CSP' contient une donnée non reconnue [Ingénieur] (valeurs autorisées [Cadre, Employé, Ouvrier, Agent de maitrise, Technicien]). |