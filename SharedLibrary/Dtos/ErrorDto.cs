﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class ErrorDto
    {
        public List<String> Errors { get; private set; }
        public bool IsShow { get; private set; } //kullanıcı için değil clieint için

        public ErrorDto()
        {
            Errors = new List<String>();

            
        }
        public ErrorDto(string error,bool isShow)
        {
            Errors.Add(error);
            isShow = true;
            
        }
        public ErrorDto(List<String> errors,bool isShow)
        {
            Errors= errors;
            IsShow = isShow;
            
        }
    }
}
