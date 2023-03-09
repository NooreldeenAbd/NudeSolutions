using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Assignment.DAL.Models
{
    /// <summary>
    /// Represents a single insured item
    /// </summary>
    public class InsuredItem
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Item's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Item's value in $
        /// </summary>
        public int value { get; set; }

        /// <summary>
        /// What type of catagory this item belongs to
        /// </summary>
        public int catagoryId { get; set; }
    }
}
