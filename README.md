# Shooter Monomyto Test

O desafio era criar um jogo no estilo **Diep.io** na Unity, buscando um código limpo e bem estruturado.

## **O que foi desenvolvido:**
- [x] Mecânica de movimentação de personagem;
- [x] Caixas destrutíveis (recarregam uma quantidade de um tipo de munição);
- [x] Mecânica de soco (chamei de Dash, na minha versão, além de destruir as caixas de munição, também pode matar inimigos e também para se movimentar mais rápido);
- [x] 4 tipos de armas, a normal, double (tiro na frente e nas costas), scare (faz com que o inimigo corra de medo) e frozen (inimigo fica congelado por um tempo);
- [x] Bot simples com máquina de estados (movement, shooting, awareness, chase e frozen);
- [x] Sistema de pontuação, quebrando caixas de munição dá 10 pontos e matar inimigo dá 20;
- [x] Gameover com pontuação atingida, tela de vitória (podendo reiniciar e sair do jogo)

- Dentro do projeto, o dev pode criar scriptable objects com dados do nível, podendo setar os limites de movimentação, quantidade inicial de munição, quantidade de inimigos e de caixas recarregáveis.
- Nesse mesmo scriptable object, o dev pode setar o KeyCode referente ao **tiro, troca de arma e Dash**

- Foram utilizadas classes abstratas, polimorfismo, máquina de estados e também Action events.

## **Instruções para jogar:**
- Baixar o conteúdo da branch **release-0.1**
- Executar o arquivo **ShooterMonomytoTest.exe**
- As teclas setadas para essa release são :

### **Teclas**
- Movimentação - **WASD ou setas**
- Dash - **botão direito do mouse**
- Tiro - **botão esquerdo do mouse**
- Troca de arma - **clique da roda do mouse**

## TO DO 
- [] Adicionar mais feedbacks;
- [] Adicionar sons;
- [] Criar um menu de seleção de níveis;
- [] Criar um menu inicial;
- [] Desenvolver mais tipos de inimigos, armas e caixas de munição;
- [] Criar um object pooling para melhoria de performance;
- [] Melhorias de código; (sempre tem)


