% Autor:
% Data: 18/03/2012

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Base de Conhecimento
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% Grafo de relacionamentos
amigos(joao, [jose,maria,gustavo]).
amigos(gustavo, [welligton,maria,cleyton,clara]).
amigos(maria, [welligton,gustavo,joao,ivana]).
amigos(cleyton, [welligton,gustavo]).
amigos(gustavo, [wallace).

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
