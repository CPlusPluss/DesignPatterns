## Mediator
***
#### Definição
***

Quando uma situação em que um relacionamento muitos para muitos é necessário, uma boa prática é criar uma tabela intermediária e deixar que ela
relaciona uma entidade com outras várias e vice versa. É semelhante a central telefônica, pois diminui a quantidade de ligações entre objetos
introduzindo um mediador, através da qual toda comunicação entre os objetos será realizada, ou seja, eliminar conexões excessivas entre elementos
por meio da introdução de um intermediário único.

***
#### Diagrama de classe
***

![mediador](https://cloud.githubusercontent.com/assets/14116020/26086490/54b7a060-39c1-11e7-86d9-3007d2cc3565.png)

* **Mediator**: Interface que padroniza as operações que serão chamadas pelos Colleagues.

* **ConcreateMediator**: Implementação particular do Mediator , que coordena a interação entre os Colleagues.

* **Colleague**: Possível interface para padronizar os ConcreateColleagues.

* **ConcreateColleague**: Classes que interagem entre si por meio do Mediator.

***
#### Implementação
***

Muito especifico para cada contexto...
