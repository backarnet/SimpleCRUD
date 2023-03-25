using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD
{
    internal class Auth
    {
        public int Id { get; set; }
        [Required, Index(IsUnique = true),MaxLength(20)]
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
