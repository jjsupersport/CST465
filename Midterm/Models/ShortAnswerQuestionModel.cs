using System.ComponentModel.DataAnnotations;
namespace Midterm;
public class ShortAnswerQuestionModel : TestQuestionModel
{
    [Required]
    [MaxLength(100, ErrorMessage = "Answer must not exceed 100 characters.")]
    public override string Answer { get; set; }
}
