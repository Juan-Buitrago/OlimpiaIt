/* HERENCIA */
public class Persona
{
  public int Identificacion;
  public string Nombre;
}

public class Estudiante : Persona
{
  public Estudiante(int Identificacion, string Nombre) : base(Identificacion, Nombre);
}

/* POLIMORFISMO */
public abstract class Persona
{
  public string Nombre { get; set; }

  public abstract string Saludar();
}
public class Alumno : Persona
{
  public Alumno(string nombre)
  {
    this.Nombre = nombre;
  }
  public override string Saludar()
  {
    string saludo = "Bienvenido " + this.Nombre;
    return saludo;
  }
}
public class Empleado : Persona
{
  public Empleado(string nombre)
  {
    this.Nombre = nombre;
  }
  public override string Saludar()
  {
    string saludo = "Hola " + this.Nombre;
    return saludo;
  }
}

/* ENCAPSULAMIENTO */
public class Persona
{
  private DateTime _fechaNacimiento
  { get; set; }

  public Persona()
  {
    _fechaNacimiento = DateTime.Now;
  }

  public int obtenerMesActual()
  {
    return _fechaNacimiento.Month;
  }
}

/* SOBRECARGA DE METODOS */
public class Numeros
{

  public int sumarNumeros(int a, int b)
  {
    return a + b;
  }

  public int sumarNumeros(int a, int b, int c)
  {
    return a + b + c;
  }

}

/* CONSTRUCTOR */
public class Persona
{
  private string _nombre;
  private string _apellido;
  public Persona(string nombre, string apellido)
  {
    _nombre = nombre;
    _apellido = apellido;
  }

}

/* GENERICS */
var nombre = "Juan Camilo";
var anios = 2;
var list = new ArrayList();
