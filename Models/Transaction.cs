using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_tracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId {  get; set; }
        public Category? Category {get; set; }
        public int? Amount { get; set; }

        public string? Note { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? Date { get; set; } = DateTime.Now;
        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }

        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                int amountValue = Amount ?? 0;
                return ((Category == null || Category.Type == "Expense") ? "- " : "+ ")
                       + amountValue.ToString("C0");
            }
        }
    }
}
