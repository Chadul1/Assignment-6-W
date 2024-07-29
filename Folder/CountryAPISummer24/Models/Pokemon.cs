using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryAPISummer24.Models
{
    /// <summary>
    /// The struct class for the JSON Schema to convert into objects.
    /// </summary>
    public class Pokemon
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public List<string> Abilities { get; set; }
        public List<string> Weakness { get; set; }
        public List<string> Type { get; set; }
        public string ThumbnailAltText { get; set; }
        public string ThumbnailImage { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
