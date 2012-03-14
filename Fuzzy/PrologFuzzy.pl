% Autor: Petrônio Cândido Lima e Silva
% Data: 14/03/2012

max(A,B,Resultado) :- A > B, Resultado is A,!.
max(A,B,Resultado) :- B > A, Resultado is B.

min(A,B,Resultado) :- A < B, Resultado is A,!.
min(A,B,Resultado) :- B < A, Resultado is B.

triangular(X,A,B,C,Resultado) :- min((X-A)/(B-A), (C-X)/(C-B), M), max(M,0,R), Resultado is R.
trapezoidal(X,A,B,C,D,Resultado) :- min((X-A)/(B-A), 1, M1), min((D-X)/(D-C), 1, M2), min(M1,M2,M), max(M,0,R), Resultado is R.

quente(X,P) :- trapezoidal(X,30,40,50,60,P).
morno(X,P) :- triangular(X,20,30,40,P).
fresco(X,P) :- triangular(X,10,20,30,P).
frio(X,P) :- trapezoidal(X,-10,0,10,20,P).

temperatura(X,Pertinencia) :- quente(X,Q), morno(X,M), fresco(X,Fc), frio(X,Fr), Pertinencia = [Q,M,Fc,Fr].


