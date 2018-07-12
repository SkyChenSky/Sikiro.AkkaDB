using System;

namespace Sikiro.AkkaDB.Entity
{
    public class NullValueException : ApplicationException
    {
        public NullValueException(string msg) : base(msg)
        {
        }
    }
}
