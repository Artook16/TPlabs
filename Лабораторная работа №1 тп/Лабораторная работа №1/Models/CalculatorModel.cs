using System.ComponentModel.DataAnnotations;

namespace Лабораторная_работа__1.Models
{
    public class CalculatorModel
    {
        [Required(ErrorMessage = "Поле 'Операнд 1' обязательно для заполнения.")]
        [Display(Name = "Операнд 1 (ulong):")]
        public string Operand1String { get; set; } = string.Empty;

        [StringLength(10, MinimumLength = 1, ErrorMessage = "Длина строки операнда 2 должна быть от 1 до 10 символов.")]
        [Display(Name = "Операнд 2 (float):")]
        public string Operand2String { get; set; } = string.Empty;

        [Display(Name = "Операция")]
        public string Operation { get; set; } = string.Empty;

        [Display(Name = "Результат")]
        public float? Result { get; set; }
    }
}