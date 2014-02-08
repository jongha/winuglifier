using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUglifier.Plugin
{
    public abstract class Plugin : IPlugin
    {
        
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public Plugin(string name)
        {
            this.name = name;
        }

        public virtual object Execute(object input)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
        }
    }
}
