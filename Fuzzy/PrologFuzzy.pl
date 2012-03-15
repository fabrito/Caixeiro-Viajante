% Autor: Petrônio Cândido Lima e Silva
% Data: 14/03/2012

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Funções Auxiliares
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%Retorna o tamanho de uma lista
tamanho([],Resultado) :- Resultado is 0.
tamanho([A | B],Resultado) :- tamanho(B,R), Resultado is R + 1.

%Retorna o maior elemento de uma lista
max([],Resultado) :- Resultado is -10000.
max([A | B],Resultado) :- max(B, R), (A >= R, Resultado is A ; Resultado is R), !.

%Retorna o menor elemento de uma lista
min([],Resultado) :- Resultado is 100000.
min([A | B],Resultado) :- min(B, R), (A >= R, Resultado is R ; Resultado is A), !.

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Funções de Pertinência
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

triangular(X,[A,B,C],Resultado) :- min([(X-A)/(B-A), (C-X)/(C-B)], M), max([M,0],R), Resultado is R.
trapezoidal(X,[A,B,C,D],Resultado) :- min([(X-A)/(B-A), 1, (D-X)/(D-C)], M),  max([M,0],R), Resultado is R.

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Calcula o centro de um polígono
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

centroideA(Tam,Conj,[],Resultado) :- Resultado is 0.
centroideA(Tam,Conj,[A | B],Resultado) :-
     centroideA(Tam, Conj, B, Res),
     (Tam =:= 4, trapezoidal(A,Conj,Tmp),! ; triangular(A,Conj,Tmp),!),
     Resultado is Res + A*Tmp.

centroideB(Tam, Conj,[],Resultado) :- Resultado is 0.
centroideB(Tam, Conj,[A | B],Resultado) :-
     centroideB(Tam, Conj, B, Res),
     (Tam =:= 4, trapezoidal(A,Conj,Tmp),! ; triangular(A,Conj,Tmp),!),
     Resultado is Res + Tmp.

centroide(Conj, Resultado) :-
     tamanho(Conj, Tam),
     centroideA(Tam,Conj,Conj,A),
     centroideB(Tam,Conj,Conj,B),
     (B > 0, Resultado is A / B ; Resultado is 0).
     
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Conjuntos Fuzzy
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%Delimitação dos conjuntos
quente([30,40,50,60]).
morno([20,30,40]).
fresco([10,20,30]).
frio([-10,0,10,20]).

%Funções de pertinência para cada conjunto
fn_quente(X,P) :- quente(Conj), trapezoidal(X,Conj,P).
fn_morno(X,P) :- morno(Conj), triangular(X,Conj,P).
fn_fresco(X,P) :- fresco(Conj), triangular(X,Conj,P).
fn_frio(X,P) :- frio(Conj), trapezoidal(X,Conj,P).

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Variável Linquística
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

temperatura(X,Pertinencia) :- fn_quente(X,Q), fn_morno(X,M), fn_fresco(X,Fc), fn_frio(X,Fr), Pertinencia = [Q,M,Fc,Fr].

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Regras de inferência e implicação
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% Se SensacaoTermica = quente Então ArCondicionado = frio
regra1([Q,M,Fc,Fr],Resultado) :- Q > 0, Resultado is Q ; Resultado is 0.

% Se SensacaoTermica = morno Então ArCondicionado = fresco
regra2([Q,M,Fc,Fr],Resultado) :- M > 0, Resultado is M ; Resultado is 0.

% Se SensacaoTermica = fresco Então ArCondicionado = morno
regra3([Q,M,Fc,Fr],Resultado) :- Fc > 0, Resultado is Fc ; Resultado is 0.

% Se SensacaoTermica = frio Então ArCondicionado = quente
regra4([Q,M,Fc,Fr],Resultado) :- Fr > 0, Resultado is Fr ; Resultado is 0.

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Defuzzyficação
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

defuzzyficacao([Fr,Fc,M,Q],Resultado) :-
       frio(Frio),centroide(Frio,FrOut),
       fresco(Fresco),centroide(Fresco,FcOut),
       morno(Morno),centroide(Morno,MOut),
       quente(Quente),centroide(Quente,QOut),
       Resultado is FrOut*Fr + Fc*FcOut + M*MOut + Q*QOut, !.
       
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Controlador fuzzy
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

controladorFuzzy(SensacaoTermica,ArCondicionado) :-

      %Fuzzyficação
      temperatura(SensacaoTermica, Pertinencias),
      
      % Inferência - Implicação e Agregação
      regra1(Pertinencias,Frio),
      regra2(Pertinencias,Fresco),
      regra3(Pertinencias,Morno),
      regra4(Pertinencias,Quente),
      
      %Defuzzyficação
      defuzzyficacao([Frio,Fresco,Morno,Quente],ArCondicionado), !.

      


