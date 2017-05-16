## Observer
***

![observer](https://cloud.githubusercontent.com/assets/14116020/26085324/d588f7b4-39b9-11e7-9372-84ae045ef90a.png)

Atribui aos objetos que tem seus estados alterados a tarefa de notificar os objetos interessados nessas mudanças, por exemplo, Na bolsa de valores as ações estão em constante mudança e as corretoras e bancos sempre querem ficar observando as alterações nessas ações.


* **Subject (AcaoSubject)**: Interface usada para padronizar os objetos que serão observados.

* **ConcreteSubject (Acao)**: Implementação de um Subject.

* **Observer (AcaoObserver)**: Interface dos objetos interessados no estado dos Subjects.

* **ConcreteObserver(Corretora, Bancos)**: Implementação particular de um Observer.

***
#### Implementação
***

1. Crie uma interface de objetos interessados (**Observer**) nas mudanças do (**Subject**) e defina a função para receber notificações para que as classes concretas (**ConcreteObserver**) possa implementar.

2. Crie a interface (**Subject**) que irá padronizar os objetos que serão observados (**ConcreteSubject**), essa classe leva a definição ou implementação de registrar o interessado na lista de interessados e remover ele dessa lista.

3. Por ultimo o método de **setState()** do (**Subject**) irá modificar o valor dos objetos observados e irá percorrer a lista de observadores notificando eles que houve mudanças nos objetos observados.

***
#### Grasps
***

