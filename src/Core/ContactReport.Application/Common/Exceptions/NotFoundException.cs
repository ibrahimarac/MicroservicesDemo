﻿using System;

namespace ContactReport.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NotFoundException(string name, object key)
            : base($"\"{name}\" içerisinde ({key}) değerine bağlı bir kayıt bulunamadı.")
        {
        }
    }
}
