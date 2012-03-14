% Autor: Petrônio Cândido Lima e Silva
% Data: 11/02/2012

% Variáveis: Sexo,Idade,EstadoCivil,TipoCarro(popular, picape, esportivo, utilitario, minivan), ModeloCarro(celta,gol,ferrari,camaro,golf), AnoCarro, Kilometragem

%carrotipo(modelo, tipo, ano, valor_seguro)
carro(corsa, popular, 2010, 1000).
carro(corsa, popular, 2011, 1000).
carro(gol, popular, 2007, 1500).
carro(gol, popular, 2008, 1500).
carro(gol, popular, 2009, 1000).
carro(gol, popular, 2010, 1000).
carro(s10, picape, 2008, 2000).
carro(s10, picape, 2009, 2000).
carro(s10, picape, 2010, 2500).
carro(s10, picape, 2010, 2500).
carro(ferrari, esportivo, 1965, 10000).
carro(ferrari, esportivo, 2000, 10000).

risco(X,Risco) :- X =< 0.3, Risco = baixo.
risco(X,Risco) :- X > 0.3, X =< 0.7, Risco = medio.
risco(X,Risco) :- X > 0.7, Risco = alto.

fator_risco(baixo,1).
fator_risco(medio,0.4).
fator_risco(alto,0.8).

risco_km(Km,Risco) :- Km =< 10000, Risco is 0.1,!.
risco_km(Km,Risco) :- Km =< 60000, Risco is 0.5,!.
risco_km(Km,Risco) :- Km > 60000, Risco is 0.9,!.

ano_atual(2012).

risco_ano(Ano, Risco) :- ano_atual(Hoje), Tmp is Hoje - Ano, Tmp =< 2, Risco is 0.1,!.
risco_ano(Ano, Risco) :- ano_atual(Hoje), Tmp is Hoje - Ano, Tmp =< 5, Risco is 0.5,!.
risco_ano(Ano, Risco) :- ano_atual(Hoje), Tmp is Hoje - Ano, Tmp > 5, Risco is 0.9,!.

risco_tipo(popular, 0.3).
risco_tipo(picape, 0.6).
risco_tipo(esportivo, 0.9).

perfil(Sexo,Idade,EstadoCivil,Risco) :- Sexo = masculino, Idade =< 30, EstadoCivil = solteiro, Risco is 0.9, !.
perfil(Sexo,Idade,EstadoCivil,Risco) :- Sexo = masculino, Idade =< 30, EstadoCivil = casado, Risco is 0.5, !.
perfil(Sexo,Idade,EstadoCivil,Risco) :- Sexo = masculino, Idade > 30, EstadoCivil = solteiro, Risco is 0.5, !.
perfil(Sexo,Idade,EstadoCivil,Risco) :- Sexo = masculino, Idade > 30, EstadoCivil = casado, Risco is 0.1, !.
perfil(Sexo,Idade,EstadoCivil,Risco) :- Sexo = feminino, EstadoCivil = solteiro, Risco is 0.5, !.
perfil(Sexo,Idade,EstadoCivil,Risco) :- Sexo = feminino, EstadoCivil = casado, Risco is 0.1, !.

sum([],0).
sum([H|T],S) :- sum(T,G), S is H + G.

tamL([_], 1):- !.
tamL([_|L], T):- tamL(L, X), T is X + 1.

avg(X,Avg) :- sum(X,S), tamL(X,T), Avg is S / T.

valorsegurocarro(Modelo,Tipo,Ano,Risco,Valor) :-
     carro(Modelo,Tipo,Ano,ValorS),
     fator_risco(Risco,X),
     Valor is ValorS + ValorS * X.

valorseguro(Sexo,Idade,EstadoCivil,Modelo,Ano,Km) :-
     carro(Modelo,Tipo,Ano,_),
     perfil(Sexo,Idade,EstadoCivil,R1),
     risco_km(Km,R2),
     risco_ano(Ano,R3),
     risco_tipo(Tipo,R4),
     avg([R1,R2,R3,R4],Media),
     risco(Media, R),
     write('Categoria de Risco: '),write(R),nl,
     valorsegurocarro(Modelo,Tipo,Ano,R,Valor),
     write('Valor do seguro: '),write(Valor),nl.