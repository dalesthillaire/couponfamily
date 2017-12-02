using System.Collections.Generic;

namespace app.Models
{
    public class PrimaryCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SecondaryCategory> SecondaryCategories;
    }
}