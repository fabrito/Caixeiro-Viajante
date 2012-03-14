% Autor: Petrônio Cândido Lima e Silva
% Data: 11/02/2012

%FATOS
pai(eustaquio, joao).
pai(eustaquio, mateus).
pai(joao, jose).
pai(joao, maria).
pai(jose, vitor).
mae(ana, jose).
mae(ana, maria).
mae(maria, clara).

%REGRAS
irmaos(X,Y) :- filho(X,Z), filho(Y,Z).
filho(X,Y) :- pai(Y,X) ; mae(Y,X).
avo(X,Z) :- pai(X,Y), pai(Y,Z).
avo(X,Z) :- mae(X,Y), mae(Y,Z).
avo(X,Z) :- mae(X,Y), pai(Y,Z).
avo(X,Z) :- pai(X,Y), mae(Y,Z).
primo(X,Y) :- filho(X,Z), filho(Y,W), irmaos(Z,W).
tio(X,Y) :- irmaos(Z,X), filho(Y,Z), not(filho(Y,X)).
avos(X) :- avo(Y,X), write(Y).
tios(X) :- tio(Y,X), write(Y).
primos(X) :- primo(Y,X), write(Y).
pais(X) :- pai(Y,X) ; mae(Y,X), write(Y).
filhos(X) :- pai(X,Y), write(Y) ; mae(X,Y), write(Y).