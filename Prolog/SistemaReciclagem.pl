% Autor: Petrônio Cândido de Lima Silva
% Data: 17/04/2012

tipo_reciclavel(papel,[papelao,branco],sim).
tipo_reciclavel(plastico,[mole],sim).
tipo_reciclavel(metal,[latao,aluminio,aco,ferro],sim).
tipo_reciclavel(biologico,[],sim).

limpo_reciclavel(biologico,_,sim).
limpo_reciclavel(metal,_,sim).
limpo_reciclavel(papel,sim,sim).
limpo_reciclavel(papel,nao,nao).
limpo_reciclavel(platico,sim,sim).
limpo_reciclavel(platico,nao,nao).

reciclavel(biologico,_,_,Reciclavel) :- Reciclavel = sim,!.

reciclavel(Tipo,SubTipo,Limpo,Reciclavel) :- tipo_reciclavel(Tipo,ST,L1),
    member(SubTipo, ST), limpo_reciclavel(Tipo,Limpo,L2),
    L1 == sim, L2 == sim, Reciclavel = sim, ! ; Reciclavel = nao, !.