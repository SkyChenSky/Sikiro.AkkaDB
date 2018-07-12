using System;

namespace Sikiro.AkkaDB.Entity
{
    public class ConfigCenterServerException : ApplicationException
    {
        public ConfigCenterServerException(string msg) : base(msg)
        {
        }
    }
}
