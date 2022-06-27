using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoutineApp.Models
{
    public class User
    {
        public string Opid {get;set;}
        public string Name {get;set;}
        public string Email {get;set;}
    }
}