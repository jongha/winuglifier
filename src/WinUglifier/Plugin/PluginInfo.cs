using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinUglifier.Plugin
{
    /// <summary>
    /// References: http://madskristensen.net/post/generic-plug-in-application-in-c
    /// </summary>
    public class PluginInfo : IDisposable
    {
        public PluginInfo()
        {
        }

        public PluginInfo(string fileName)
        {
            _FileName = fileName;
        }

        private string _Id = Guid.NewGuid().ToString();
        private bool _IsNew = true;
        private bool _IsDisposed;
        private static string _Folder = System.Windows.Forms.Application.StartupPath + "\\plugins\\";

        private string _Description;
        [XmlElement("Description")]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _FileName;
        [XmlElement("Filename")]
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        private string _Name;
        [XmlElement("Name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private Icon _Icon;
        [XmlIgnore]
        public Icon Icon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }

        [XmlElementAttribute("Icon")]
        public byte[] PictureByteArray
        {
            get
            {
                if (_Icon != null)
                {
                    TypeConverter BitmapConverter =
                         TypeDescriptor.GetConverter(_Icon.GetType());
                    return (byte[])
                         BitmapConverter.ConvertTo(_Icon, typeof(byte[]));
                }
                else
                    return null;
            }

            set
            {
                if (value != null)
                    _Icon = new Icon(new MemoryStream(value));
                else
                    _Icon = null;
            }
        }

        public void Save()
        {
            if (_IsNew)
            {
                IPlugin plugin = CreateInstance();
                if (plugin != null)
                {
                    Name = plugin.Name;

                    plugin.Dispose();
                }
            }

            if (!Directory.Exists(_Folder))
                Directory.CreateDirectory(_Folder);

            Serializer<PluginInfo>.Save(this, _Folder + _Id + ".xml");
            OnChanged(this);
            _IsNew = false;
        }

        /// <summary>
        /// Loads a Plug-in based on the specified file name.
        /// </summary>
        public static PluginInfo Load(string fileName)
        {
            if (!File.Exists(fileName))
                return null;

            try
            {
                PluginInfo info = Serializer<PluginInfo>.Load(fileName);
                info._Id = new FileInfo(fileName).Name.Replace(".xml", string.Empty);
                info._IsNew = false;
                return info;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Removes the plug-in from the list.
        /// </summary>
        public void Delete()
        {
            string filename = _Folder + _Id + ".xml";
            if (File.Exists(filename))
            {
                File.Delete(filename);
                OnChanged(this);
            }
        }

        public static Collection<PluginInfo> LoadAll()
        {
            Collection<PluginInfo> infos = new Collection<PluginInfo>();

            if (!Directory.Exists(_Folder))
                Directory.CreateDirectory(_Folder);
            else
            {
                foreach (string filename in Directory.GetFiles(_Folder))
                {
                    PluginInfo info = Load(filename);
                    if (info != null)
                        infos.Add(Load(filename));
                }
            }

            return infos;
        }

        /// <summary>
        /// Creates an instance of the PluginForm.
        /// </summary>
        public IPlugin CreateInstance()
        {
            if (!File.Exists(FileName))
                return null;

            Assembly ass = Assembly.LoadFile(FileName);
            foreach (Type type in ass.GetTypes())
            {
                if (type.BaseType == typeof(Plugin))
                {
                    return (Plugin)Activator.CreateInstance(type);
                }
            }

            return null;
        }

        public static event EventHandler<EventArgs> Changed;
        /// <summary>
        /// Occurs when the class is Changed
        /// </summary>
        protected static void OnChanged(PluginInfo plugin)
        {
            if (Changed != null)
            {
                Changed(plugin, new EventArgs());
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_IsDisposed)
            {
                if (_Icon != null) _Icon.Dispose();
                _IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
