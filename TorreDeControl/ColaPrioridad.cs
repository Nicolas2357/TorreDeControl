namespace TorreDeControl;

/// <summary>
/// Cola de prioridad implementada con una lista enlazada simple ORDENADA por prioridad
/// (menor número = mayor prioridad). Entre elementos con la misma prioridad se respeta
/// el orden de llegada (FIFO), porque cada nuevo elemento se inserta después de los de
/// su misma prioridad.
/// Encolar: O(n) en el peor caso, O(1) si va al final. Desencolar y VerFrente: O(1).
/// </summary>
public class ColaPrioridad<T>
{
    /// <summary>Nodo interno: valor, prioridad y referencia al siguiente.</summary>
    private sealed class Nodo
    {
        public Nodo(T valor, int prioridad)
        {
            Valor = valor;
            Prioridad = prioridad;
        }

        public T Valor { get; }
        public int Prioridad { get; }
        public Nodo? Siguiente { get; set; }
    }

    private Nodo? _frente;   // elemento con mayor prioridad (el siguiente en salir)
    private Nodo? _final;    // último elemento (menor prioridad)
    private int _cantidad;

    public int Cantidad => _cantidad;
    public bool EstaVacia => _cantidad == 0;

    /// <summary>Inserta el valor en su posición según la prioridad (FIFO entre iguales).</summary>
    public void Encolar(T valor, int prioridad)
    {
        var nuevo = new Nodo(valor, prioridad);

        if (_frente is null)                              // cola vacía
        {
            _frente = _final = nuevo;
        }
        else if (prioridad < _frente.Prioridad)           // más urgente que todos: va al frente
        {
            nuevo.Siguiente = _frente;
            _frente = nuevo;
        }
        else if (prioridad >= _final!.Prioridad)          // igual o menos urgente que el último: va al final, O(1)
        {
            _final.Siguiente = nuevo;
            _final = nuevo;
        }
        else                                              // va en medio: después del último de su prioridad
        {
            var actual = _frente;
            while (actual.Siguiente!.Prioridad <= prioridad)
                actual = actual.Siguiente;

            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;
        }
        _cantidad++;
    }

    /// <summary>Saca y devuelve el elemento de mayor prioridad. O(1).</summary>
    /// <exception cref="InvalidOperationException">Si la cola está vacía.</exception>
    public T Desencolar()
    {
        if (_frente is null)
            throw new InvalidOperationException("La cola de prioridad está vacía.");

        Nodo nodo = _frente;
        _frente = nodo.Siguiente;
        if (_frente is null)
            _final = null;

        _cantidad--;
        return nodo.Valor;
    }

    /// <summary>Devuelve el elemento de mayor prioridad sin sacarlo. O(1).</summary>
    public T VerFrente()
    {
        if (_frente is null)
            throw new InvalidOperationException("La cola de prioridad está vacía.");

        return _frente.Valor;
    }

    /// <summary>Recorre los elementos del frente al final, con su prioridad.</summary>
    public IEnumerable<(T Valor, int Prioridad)> Recorrer()
    {
        for (var actual = _frente; actual is not null; actual = actual.Siguiente)
            yield return (actual.Valor, actual.Prioridad);
    }

    public void Limpiar()
    {
        _frente = _final = null;
        _cantidad = 0;
    }
}