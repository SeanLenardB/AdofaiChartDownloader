using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdofaiChartDownloader
{
    internal class AdofaiChart
	{
        public AdofaiChart(int id, string name, string creator, string artist, string url, string level)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Creator = creator ?? throw new ArgumentNullException(nameof(creator));
            Artist = artist ?? throw new ArgumentNullException(nameof(artist));
            Url = url ?? throw new ArgumentNullException(nameof(url));
            Level = level;
        }



        private int _id = -1;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

        private string _name = "NaN";

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

		private string _creator = "NaN";

		public string Creator
		{
			get { return _creator; }
			set { _creator = value; }
		}

		private string _artist = "NaN";

		public string Artist
		{
			get { return _artist; }
			set { _artist = value; }
		}

		private string _url = "NaN";

		public string Url
		{
			get { return _url; }
			set { _url = value; }
		}

		private string _level = "?";

        public string Level
		{
			get { return _level; }
			set { _level = value; }
		}

		

	}
}
