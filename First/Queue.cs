namespace First;

public class Queue
{
    private string[] _array = new string[10];

    private int _pointer = 0;

    public void Add(string element)
    {
        _array[_pointer] = element;
        _pointer += 1;

        if (_pointer == _array.Length)
        {
            var extendedArray = new int[_array.Length * 2];
            for (var i = 0; i < _array.Length; i++)
            {
                extendedArray[i] = _array[i];
            }

            _array = extendedArray;
        }
    }
    // we should write Out
    public object Out()
    {
        if (_pointer == 0)
        {
            return null;
        }

        var value = _array[0];
        _pointer--;
        for (var i = 0; i < _pointer; i++)
        {
            _array[i] = _array[i + 1];
        }
        return value;
    }

    public void Pick(int smth)
    {
        _array[pointer];
    }
}