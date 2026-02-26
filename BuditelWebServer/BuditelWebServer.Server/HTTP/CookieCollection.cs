using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuditelWebServer.Server.HTTP
{
    public class CookieCollection : IEnumerable<Cookie>
    {
        private Dictionary<string, Cookie> cookies;
        public CookieCollection()
        {
            cookies = new Dictionary<string, Cookie>();
        }

        public string this[string name]
        {
            get => cookies[name].Value;
            set => cookies[name] = new Cookie(name, value);
        }

        public void Add(string name, string value)
        {
            cookies[name] = new Cookie(name, value);
        }

        public bool Contains(string name)
        {
            return cookies.ContainsKey(name);
        }
        public IEnumerator<Cookie> GetEnumerator()
        {
            return cookies.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
