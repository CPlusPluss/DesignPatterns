## Factory Method

A fábrica (interface) cria objetos que só serão definidos em tempo de execução pela suas subclasses

No exemplo criamos um template(fabricaDeCarros) que tem informações para criar diversas fábricas(FabricaFiat, Volks, Chevrolet,
Ford) que irão criar carros especificos(Palio, gol, celta, fiesta) através de um template(Carro) que tem as informações para os
carros preencherem

Usamos uma fábrica quando temos que isolar o processo de criação de um objeto em um único lugar. Essa fábrica pode descobrir como criar o
objeto dentro dela própria, mas geralmente ela não precisa de muitas informações para criar o objeto.

![Diagrama de classe](https://cloud.githubusercontent.com/assets/14116020/25073732/db2a3eb6-22c2-11e7-9caa-f7b28eb1eb8b.png)

* **Carro**: Classe ou interface que define informações do objeto a ser criado.

* **Palio, Gol, Celta, Fiesta**: Uma implementação particular do objeto.

* **FabricaDeCarro**: Classe ou interface que define a assinatura dos métodos responsáveis pela criação do objeto

* **FabricaFiat, FabricaFord, FrabricaVolks, ...**: Classe que implementa ou sobrescreve os métodos de criação do objeto.:q
