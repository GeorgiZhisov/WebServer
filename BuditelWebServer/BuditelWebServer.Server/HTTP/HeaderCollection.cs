using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuditelWebServer.Server.HTTP
{
	public class HeaderCollection : IEnumerable<Header>
	{
		private readonly Dictionary<string, Header> headers;
        public HeaderCollection()
        {
            headers = new Dictionary<string, Header>();
        }

        public int Count => headers.Count;

        public void Add(string name,string value)
        {
		
				var header = new Header(name, value);
				headers[name] = header;
        }
		public string this[string name]
		{
			get
			{
				return headers[name].Value;
			}
			set
			{
				headers[name].Value = value;
			}
		}

		public bool Contains(string name)
		{
			return headers.ContainsKey(name);
		}

		public IEnumerator<Header> GetEnumerator()
		{
			return headers.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
