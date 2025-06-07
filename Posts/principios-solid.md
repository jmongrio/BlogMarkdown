# 🧱 ¿Qué significa SOLID?
Es un acrónimo que representa 5 principios:

- **S** – Single Responsibility
- **O** – Open/Closed
- **L** – Liskov Substitution
- **I** – Interface Segregation
- **D** – Dependency Inversion

## 1. S – Single Responsibility Principle
👉 Principio de responsabilidad única
Una clase debe tener una sola razón para cambiar.
Es decir, debe encargarse de una sola cosa.

🔧 Ejemplo:
```
// ❌ Mezcla responsabilidades
class Report {
    public void Generate() { }
    public void SaveToFile() { }
}

// ✅ Separación de responsabilidades
class ReportGenerator {
    public void Generate() { }
}

class FileSaver {
    public void SaveToFile(Report report) { }
}
```

## 2. O – Open/Closed Principle
👉 Abierto para extensión, cerrado para modificación
Tu código debe poder extenderse sin tener que modificar lo que ya funciona.

🔧 Ejemplo:
```
// ✅ Uso de polimorfismo para extender sin tocar código existente
abstract class Shape {
    public abstract double Area();
}

class Circle : Shape {
    public override double Area() => Math.PI * 5 * 5;
}

class Square : Shape {
    public override double Area() => 4 * 4;
}
```

## 3. L – Liskov Substitution Principle
👉 Una clase hija debe poder usarse como si fuera su clase padre
Si una clase *Base* funciona, cualquier clase *Derivada* también debe funcionar sin romper el comportamiento.

🔧 Ejemplo:

```
// ✅ Un pato es un ave, y se comporta como tal
class Bird {
    public virtual void Fly() => Console.WriteLine("Flying...");
}

class Duck : Bird {
    public override void Fly() => Console.WriteLine("Duck flying!");
}
```
## 4. I – Interface Segregation Principle
👉 No obligues a una clase a implementar métodos que no necesita
Mejor tener interfaces pequeñas y específicas que una muy grande.

🔧 Ejemplo:
```
// ❌ Interface con demasiados métodos
interface IWorker {
    void Work();
    void Eat();
}

// ✅ Interfaces separadas
interface IWorkable {
    void Work();
}

interface IFeedable {
    void Eat();
}
```
## 5. D – Dependency Inversion Principle
👉 Las clases deben depender de abstracciones, no de implementaciones concretas
Permite inyectar dependencias y facilita cambiar o simular comportamientos.

🔧 Ejemplo:
```
// ❌ Depende directamente de una clase concreta
class Light {
    public void TurnOn() { }
}

class Switch {
    private Light light = new Light();
    public void Toggle() => light.TurnOn();
}

// ✅ Depende de una interfaz (abstracción)
interface IDevice {
    void TurnOn();
}

class Light : IDevice {
    public void TurnOn() { }
}

class Switch {
    private IDevice device;
    public Switch(IDevice device) => this.device = device;
    public void Toggle() => device.TurnOn();
}
```