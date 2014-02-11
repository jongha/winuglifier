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
        private PluginType type;

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

        public Plugin(PluginType type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public virtual object Execute(object input)
        {
            throw new NotImplementedException();
        }

        public PluginType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public virtual void Dispose()
        {
        }
    }
}
