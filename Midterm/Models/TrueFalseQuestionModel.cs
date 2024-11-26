using System.ComponentModel.DataAnnotations;
namespace Midterm;

public class TrueFalseQuestionModel : TestQuestionModel
{
    [Required]
    [RegularExpression("^(True|False)$", ErrorMessage = "Answer must be 'True' or 'False'.")]
    public override string Answer { get; set; }
}
