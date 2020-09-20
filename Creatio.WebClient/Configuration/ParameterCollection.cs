namespace Creatio.WebClient.Configuration
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ParameterCollection : IEnumerable, IEnumerable<Parameter>
    {
        private Parameter[] _parameters;

        public int Count
        {
            get
            {
                return _parameters.Length;
            }
        }

        public ParameterCollection()
        {
            _parameters = new Parameter[0];
        }

        public bool Add(Parameter parameter)
        {
            if (_parameters.Contains(parameter))
                return false;
            Parameter[] parameters = _parameters;
            _parameters = new Parameter[parameters.Length + 1];
            for (int i = 0; i < parameters.Length; i++)
            {
                _parameters[i] = parameters[i];
            }
            _parameters[Count - 1] = parameter;
            return true;
        }

        public bool Remove(Parameter parameter)
        {
            if (!_parameters.Contains(parameter))
                return false;
            Parameter[] parameters = _parameters;
            _parameters = new Parameter[parameters.Length - 1];
            IEnumerator paramEnumerator = parameters.GetEnumerator();
            int i = 0;
            while (paramEnumerator.MoveNext())
            {
                Parameter current = paramEnumerator.Current as Parameter;
                if (current != parameter) 
                {
                    _parameters[i++] = current;
                }
            }
            return true;
        }

        public IEnumerator<Parameter> GetEnumerator()
        {
            for (int i = 0; i < _parameters.Length; i++)
            {
                yield return _parameters[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        //private void CreateNewArray
    }
}
