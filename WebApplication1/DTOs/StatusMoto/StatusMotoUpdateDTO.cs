using System.ComponentModel.DataAnnotations;

public class StatusMotoUpdateDTO
{
    [Required]
    public string Status { get; set; }

    [Required]
    public string Area { get; set; }
}
