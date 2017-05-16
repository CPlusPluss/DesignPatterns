## Template Method

Quanto temos diferentes algoritmos que possuem estruturas parecidas, ele tem uma estrutura parecida com às linhas de montagem de carro, pois
permite definir a ordem de execução dos passos que resolvem um determinado problema e permite que cada passo possa ser implementado de maneiras
diferentes.

![templatemethod](https://cloud.githubusercontent.com/assets/14116020/26087802/6a33da5a-39c9-11e7-9284-5a5bd5e3e195.png)

* **AbstractClass**: Classe abstrata que define os templates methods baseados em métodos abstratos que serão implementados nas ConcreteClasses,
  define a ordem de execução desse métodos.

* **ConcreteClass**: Classes concretas que implementam os métodos abstratos definidos pela AbstractClass e que são utilizados pelos templates methods.

***
#### Implementação
***

1. Crie a classe abstrata com a definição dos métodos que irão ser ordenados no método template()

2. Crie as classes concretas que irão implementar esse métodos ordenados no template()
