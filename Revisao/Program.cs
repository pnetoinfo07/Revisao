using Revisao;

Prova provaMatematica = new Prova();
provaMatematica.Id = 1;
provaMatematica.Disciplina = "Matematica";
provaMatematica.Nota = 10;
provaMatematica.Questoes.Add("1 - Quanto é 2+2?");
provaMatematica.Questoes.Add("2 - Quanto é 5x5?");
provaMatematica.Questoes.Add("3- Quanto é 10x5?");
provaMatematica.Gabarito.Add('A');
provaMatematica.Gabarito.Add('C');
provaMatematica.Gabarito.Add('B');

Prova provaPortugues = new Prova();
provaPortugues.Id = 2;
provaPortugues.Disciplina = "Português";
provaPortugues.Nota = 15;

provaPortugues.ExibirDados();
provaMatematica.ExibirDados();

Prova provaGeografia = new Prova();
provaGeografia.Disciplina = "Geografia";
provaGeografia.ExibirDados();












