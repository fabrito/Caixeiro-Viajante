% Autor: Petrônio Cândido Lima e Silva
% Data: 14/03/2012

max([],Resultado) :- Resultado is -10000.
max([A | B],Resultado) :- max(B, R), (A >= R, Resultado is A ; Resultado is R), !.

min([],Resultado) :- Resultado is 100000.
min([A | B],Resultado) :- min(B, R), (A >= R, Resultado is R ; Resultado is A), !.

triangular(X,[A,B,C],Resultado) :- min([(X-A)/(B-A), (C-X)/(C-B)], M), max([M,0],R), Resultado is R.
trapezoidal(X,[A,B,C,D],Resultado) :- min([(X-A)/(B-A), 1, (D-X)/(D-C)], M),  max([M,0],R), Resultado is R.

implicacao(X,[A,B,C],Resultado) :- Tmp is B * X, max([A, Tmp, C], Res), Resultado is Res.
implicacao(X,[A,B,C,D],Resultado) :- Tmp is B * X, Tmp2 is D * X, max([A, Tmp, Tmp2, C],Res), Resultado is Res.

quente([30,40,50,60]).
morno([20,30,40]).
fresco([10,20,30]).
frio([-10,0,10,20]).

fn_quente(X,P) :- quente(Conj), trapezoidal(X,Conj,P).
fn_morno(X,P) :- morno(Conj), triangular(X,Conj,P).
fn_fresco(X,P) :- fresco(Conj), triangular(X,Conj,P).
fn_frio(X,P) :- frio(Conj), trapezoidal(X,Conj,P).

temperatura(X,Pertinencia) :- fn_quente(X,Q), fn_morno(X,M), fn_fresco(X,Fc), fn_frio(X,Fr), Pertinencia = [Q,M,Fc,Fr].

% Se SensacaoTermica = quente Então ArCondicionado = frio
regra1([Q,M,Fc,Fr],Resultado) :- Q > 0, frio(Conj), implicacao(Q,Conj,Resultado).
regra1([Q,M,Fc,Fr],Resultado) :- Q =:= 0, Resultado is 0.

% Se SensacaoTermica = morno Então ArCondicionado = fresco
regra2([Q,M,Fc,Fr],Resultado) :- M > 0, fresco(Conj), implicacao(M,Conj,Resultado).
regra2([Q,M,Fc,Fr],Resultado) :- M =:= 0, Resultado is 0.

% Se SensacaoTermica = fresco Então ArCondicionado = morno
regra3([Q,M,Fc,Fr],Resultado) :- Fc > 0, morno(Conj), implicacao(Fc,Conj,Resultado).
regra3([Q,M,Fc,Fr],Resultado) :- Fc =:= 0, Resultado is 0.

% Se SensacaoTermica = frio Então ArCondicionado = quente
regra4([Q,M,Fc,Fr],Resultado) :- Fr > 0, quente(Conj), implicacao(Fr,Conj,Resultado).
regra4([Q,M,Fc,Fr],Resultado) :- Fr =:= 0, Resultado is 0.

defuzzyficacao(Conj, Resultado) :- min(Conj, Min), max(Conj, Max), Resultado is (Max-Min)/2.

controladorFuzzy(SensacaoTermica,ArCondicionado) :-

      %Fuzzyficação
      temperatura(SensacaoTermica, P),
      
      % Inferência - Implicação e Agregação
      regra1(P,A),
      regra2(P,B),
      regra3(P,C),
      regra4(P,D),
      
      %Defuzzyficação
      defuzzyficacao([A,B,C,D],ArCondicionado), !.


