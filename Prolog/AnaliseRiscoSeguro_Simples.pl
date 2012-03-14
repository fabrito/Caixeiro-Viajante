% Autor: Petrônio Cândido Lima e Silva
% Data: 11/02/2012

% Variáveis: Sexo,Idade,EstadoCivil,TipoCarro(popular, picape, esportivo, utilitario, minivan), ModeloCarro(celta,gol,ferrari,camaro,golf), AnoCarro
sexo(andre,masculino).
idade(andre,29).
estcivil(andre,solteiro).
carro(andre,celta).
sexo(ivana, feminino).
estcivil(ivana,solteiro).
carro(ivana,celta).
sexo(jose,masculino).
estcivil(jose,casado).

%carrotipo(modelo, tipo, ano, valor_seguro)
carrotipo(corsa, popular, 2010, 1000).
carrotipo(corsa, popular, 2011, 1000).
carrotipo(s10, picape).
carrotipo(ferrari, esportivo).

valorseguro(corsa, 1000).
valorseguro(celta, 1000).
valorseguro(astra, 1000).
valorseguro(s10, 1000).

fator_risco(baixo,1).
fator_risco(medio,0.4).
fator_risco(alto,0.8).

%analise(X,Y) :- sexo(X, masculino), idade(X, Z), Z =< 30, estcivil(X, solteiro), Y = alto,!.
%analise(X,Y) :- sexo(X, masculino), idade(X, Z), Z =< 30, estcivil(X, casado), Y = medio,!.
%analise(X,Y) :- sexo(X, masculino), idade(X, Z), Z > 30, estcivil(X, solteiro), Y = medio,!.
%analise(X,Y) :- sexo(X, masculino), idade(X, Z), Z > 30, estcivil(X, casado), Y = baixo,!.
%analise(X,Y) :- sexo(X, feminino), estcivil(X, solteiro), Y = medio,!.
%analise(X,Y) :- sexo(X, feminino), estcivil(X, casado), Y = baixo,!.


perfil(Sexo,Idade,EstadoCivil,Carro,Risco) :- Sexo =:= masculino, Idade =< 30, EstadoCivil =:= solteiro, Risco = alto, !.
perfil(Sexo,Idade,EstadoCivil,Carro,Risco) :- Sexo =:= masculino, Idade =< 30, EstadoCivil =:= casado, Risco = medio, !.
perfil(Sexo,Idade,EstadoCivil,Carro,Risco) :- Sexo =:= masculino, Idade > 30, EstadoCivil =:= solteiro, Risco = medio, !.
perfil(Sexo,Idade,EstadoCivil,Carro,Risco) :- Sexo =:= masculino, Idade > 30, EstadoCivil =:= casado, Risco = baixo, !.
perfil(Sexo,Idade,EstadoCivil,Carro,Risco) :- Sexo =:= feminino, EstadoCivil =:= solteiro, Risco = medio, !.
perfil(Sexo,Idade,EstadoCivil,Carro,Risco) :- Sexo =:= feminino, EstadoCivil =:= casado, Risco = baixo, !.

valorseguro(X,Y) :- analise(X,Z), carro(X,W), valorseguro(W,K), risco(Z,R), Y is K+K*R.