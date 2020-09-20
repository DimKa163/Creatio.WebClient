using System;
using System.Collections.Generic;
using System.Text;

namespace Creatio.WebClient.Configuration
{
    public abstract class ArgumentBuilder
    {
        private readonly ParameterCollection _parameters;
        protected ParameterCollection Parameters
        {
            get
            {
                return _parameters;
            }
        }
        public ArgumentBuilder(ParameterCollection parameters)
        {
            _parameters = parameters;
        }

        public abstract string Serialize();
    }
}
