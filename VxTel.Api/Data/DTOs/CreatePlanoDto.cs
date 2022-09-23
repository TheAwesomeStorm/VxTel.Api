﻿using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs;

public class CreatePlanoDto
{
    [Required]
    public string Nome { get; set; }
    [Required] public int Minutos { get; set; }
}