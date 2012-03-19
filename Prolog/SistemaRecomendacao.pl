% Autor:
% Data: 18/03/2012

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Base de Conhecimento
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% Grafo de relacionamentos
amigos(joao, [jose,maria,gustavo]).
amigos(gustavo, [wallace, welligton,maria,cleyton,clara]).
amigos(maria, [welligton,gustavo,joao,ivana]).
amigos(cleyton, [welligton,gustavo]).
amigos(wallace, [gustavo]).

% Lista de gostos por pessoa
gosta(joao, [futebol,carros,esportes,azul]).
gosta(maria, [moda,rosa,cinema]).
gosta(jose, [futebol,literatura,amarelo]).
gosta(gustavo, [carros,cinema,azul]).
gosta(welligton, [cinema,literatura,azul]).
gosta(clara, [musica,rosa,esportes]).
gosta(ivana, [esportes,moda,azul,cinema]).
gosta(cleyton, [futebol,musica,amarelo]).

% Lista de compras por pessoa
comprou(joao,[corsa_sedan_azul,camisa_selecao_futebol]).
comprou(maria,[vestido_rosa,dvd_opoderosochefao,dvd_setimoselo]).
comprou(jose,[camisa_selecao_futebol,livro_cemanosdesolidao]).
comprou(gustavo,[corsa_sedan_azul,dvd_opoderosochefao]).
comprou(welligton,[dvd_opoderosochefao,livro_codigodavinci]).
comprou(clara,[camisa_selecao_futebol,dvd_lenineaovivo,vestido_rosa).
comprou(ivana,[jaqueta_jeans]).
comprou(cleyton,[dvd_caetanoveloso,dvd_lenineaovivo]).

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Regras
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% Verifica se a lista [A|B] contém um item igual a C
contem([], C, Resultado) :- Resultado is 0.
contem([A|B], C, Resultado) :-  A = C, Resultado is 1, ! ; contem(B, C, Resultado).

% Conta quantos elementos da lista A são iguais aos da lista B
compara([], C, Resultado) :- Resultado is 0.
compara([A|B], C, Resultado) :-
    compara(B, C, X),
    contem(C, A, W),
    Resultado is W + X.
    
%Retorna o tamanho de uma lista
tamanho([],Resultado) :- Resultado is 0.
tamanho([A | B],Resultado) :- tamanho(B,R), Resultado is R + 1.

similaridadeAmigos(A,B,Similaridade) :-
    amigos(A,AmigosA),
    %amigos(B,AmigosB),
    tamanho(AmigosA, T),
    compara(AmigosA,B,C),
    Similaridade is C / T.
    
similaridadeGostos(A,B,Similaridade) :-
    gosta(A,GostoA),
    %gosta(B,GostoB),
    tamanho(GostoA, T),
    compara(GostoA,B,C),
    Similaridade is C / T.

similaridade(A,Amigos,Gostos,Similaridade) :-
    similaridadeAmigos(A,Amigos,X),
    similaridadeGostos(A,Gostos,Y),
    Similaridade is (X + Y) / 2.

recomenda(Nome,Amigos,Gostos,X) :-
    %asserta(amigos(Nome,Amigos)),
    %asserta(gosta(Nome,Gostos)).
    amigos(A,_),
    similaridade(A,Amigos,Gostos,Sim),
    Sim > 0,
    comprou(A,Itens),
    X = Itens.