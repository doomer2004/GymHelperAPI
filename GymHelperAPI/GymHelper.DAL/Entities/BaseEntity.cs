using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GymHelper.DAL.Entities;

public class BaseEntity<T> where T : struct
{
    [Key]
    public T Id { get; set; }
}